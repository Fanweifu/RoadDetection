//----------------------------------------------------------------------------
//  Copyright (C) 2004-2015 by EMGU Corporation. All rights reserved.       
//----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using Emgu.CV.Util;
#if !IOS
using Emgu.CV.Cuda;
#endif
using Emgu.CV.XFeatures2D;

namespace ShowOpenCVResult
{
   public static class DrawMatches
   {
       public static void FindMatch(Mat modelImage, Mat observedImage, out long matchTime, out VectorOfKeyPoint modelKeyPoints, out VectorOfKeyPoint observedKeyPoints, VectorOfVectorOfDMatch matches, out Mat mask, out Mat homography)
       {
           int k = 2;
           double uniquenessThreshold = 0.8;
           double hessianThresh = 300;

           Stopwatch watch;
           homography = null;

           modelKeyPoints = new VectorOfKeyPoint();
           observedKeyPoints = new VectorOfKeyPoint();

#if !IOS
           if (CudaInvoke.HasCuda)
           {
               CudaSURF surfCuda = new CudaSURF((float)hessianThresh);
               using (GpuMat gpuModelImage = new GpuMat(modelImage))
               //extract features from the object image
               using (GpuMat gpuModelKeyPoints = surfCuda.DetectKeyPointsRaw(gpuModelImage, null))
               using (GpuMat gpuModelDescriptors = surfCuda.ComputeDescriptorsRaw(gpuModelImage, null, gpuModelKeyPoints))
               using (CudaBFMatcher matcher = new CudaBFMatcher(DistanceType.L2))
               {
                   surfCuda.DownloadKeypoints(gpuModelKeyPoints, modelKeyPoints);
                   watch = Stopwatch.StartNew();

                   // extract features from the observed image
                   using (GpuMat gpuObservedImage = new GpuMat(observedImage))
                   using (GpuMat gpuObservedKeyPoints = surfCuda.DetectKeyPointsRaw(gpuObservedImage, null))
                   using (GpuMat gpuObservedDescriptors = surfCuda.ComputeDescriptorsRaw(gpuObservedImage, null, gpuObservedKeyPoints))
                   //using (GpuMat tmp = new GpuMat())
                   //using (Stream stream = new Stream())
                   {
                       matcher.KnnMatch(gpuObservedDescriptors, gpuModelDescriptors, matches, k);

                       surfCuda.DownloadKeypoints(gpuObservedKeyPoints, observedKeyPoints);

                       mask = new Mat(matches.Size, 1, DepthType.Cv8U, 1);
                       mask.SetTo(new MCvScalar(255));
                       Features2DToolbox.VoteForUniqueness(matches, uniquenessThreshold, mask);

                       int nonZeroCount = CvInvoke.CountNonZero(mask);
                       if (nonZeroCount >= 4)
                       {
                           nonZeroCount = Features2DToolbox.VoteForSizeAndOrientation(modelKeyPoints, observedKeyPoints,
                              matches, mask, 1.5, 20);
                           if (nonZeroCount >= 4)
                               homography = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures(modelKeyPoints,
                                  observedKeyPoints, matches, mask, 2);
                       }
                   }
                   watch.Stop();
               }
           }
           else
#endif
           {
               using (UMat uModelImage = modelImage.ToUMat(AccessType.Read))
               using (UMat uObservedImage = observedImage.ToUMat(AccessType.Read))
               {
                   UMat modelDescriptors = new UMat();
                   //SURF surfCPU = new SURF(hessianThresh);
                   ////extract features from the object image
                   //surfCPU.DetectAndCompute(uModelImage, null, modelKeyPoints, modelDescriptors, false);
                   watch = Stopwatch.StartNew();
                   ORBDetector od = new ORBDetector();
                   SIFT sf = new SIFT();//hessianThresh
                   //od.DetectAndCompute(uModelImage, null, modelKeyPoints, modelDescriptors, false);
                   modelKeyPoints = new VectorOfKeyPoint(od.Detect(uModelImage, null));
                   sf.Compute(uModelImage, modelKeyPoints, modelDescriptors);


                   // extract features from the observed image
                   UMat observedDescriptors = new UMat();
                   observedKeyPoints = new VectorOfKeyPoint(od.Detect(uObservedImage, null));
                   sf.Compute(uObservedImage, observedKeyPoints, observedDescriptors);
                   BFMatcher matcher = new BFMatcher(DistanceType.L2);
                   matcher.Add(modelDescriptors);

                   matcher.KnnMatch(observedDescriptors, matches, k, null);
                   mask = new Mat(matches.Size, 1, DepthType.Cv8U, 1);
                   mask.SetTo(new MCvScalar(255));
                   if (matches.Size >= 10)
                   {
                       Features2DToolbox.VoteForUniqueness(matches, uniquenessThreshold, mask);
                   }

                   int nonZeroCount = CvInvoke.CountNonZero(mask);
                   if (nonZeroCount >= 4)
                   {
                       nonZeroCount = Features2DToolbox.VoteForSizeAndOrientation(modelKeyPoints, observedKeyPoints,
                          matches, mask, 1.5, 20);
                       if (nonZeroCount >= 4)
                           homography = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures(modelKeyPoints,
                              observedKeyPoints, matches, mask, 2);
                   }

                   watch.Stop();
               }
           }
           matchTime = watch.ElapsedMilliseconds;
       }

      /// <summary>
      /// Draw the model image and observed image, the matched features and homography projection.
      /// </summary>
      /// <param name="modelImage">The model image</param>
      /// <param name="observedImage">The observed image</param>
      /// <param name="matchTime">The output total time for computing the homography matrix.</param>
      /// <returns>The model image and observed image, the matched features and homography projection.</returns>
      public static Mat Draw(Mat modelImage, Mat observedImage, out long matchTime, out VectorOfKeyPoint outmp, out VectorOfKeyPoint outop)
      {
         Mat homography;
         VectorOfKeyPoint modelKeyPoints;
         VectorOfKeyPoint observedKeyPoints;
         using (VectorOfVectorOfDMatch matches = new VectorOfVectorOfDMatch())
         {
             Mat mask;
             FindMatch(modelImage, observedImage, out matchTime, out modelKeyPoints, out observedKeyPoints, matches,
                out mask, out homography);

             //Draw the matched keypoints
             Mat result = new Mat();
             Features2DToolbox.DrawMatches(modelImage, modelKeyPoints, observedImage, observedKeyPoints,
                matches, result, new MCvScalar(255, 255, 255), new MCvScalar(255, 255, 255), mask);

             //todoTest
             Random rd = new Random();
             Byte[] bts = mask.GetData();
             for (int i = 0; i < matches.Size; i++)
             {
                 VectorOfDMatch vdm = matches[i];
                 MDMatch dm1 = vdm[0];
                 MKeyPoint mp1 = modelKeyPoints[dm1.TrainIdx];
                 MKeyPoint mp2 = observedKeyPoints[dm1.QueryIdx];

                 if (bts[dm1.QueryIdx] == 0) continue;
                 //Console.Write("({0})", i);
                 //Console.WriteLine("dm1[Distance:{0},QueryIdx:{1},TrainIdx:{2}],dm2[Distance:{3},QueryIdx:{4},TrainIdx:{5}]", dm1.Distance, dm1.QueryIdx, dm1.TrainIdx, dm2.Distance, dm2.QueryIdx, dm2.TrainIdx);






                 Point p1 = new Point((int)mp1.Point.X, (int)mp1.Point.Y);
                 Point p2 = new Point((int)mp2.Point.X, (int)mp2.Point.Y);
                 int B = rd.Next(0, 255), G = rd.Next(0, 255), R = rd.Next(0, 255);
                 CvInvoke.Circle(modelImage, p1, 5, new MCvScalar(B, G, R), -1);
                 CvInvoke.Circle(observedImage, p2, 5, new MCvScalar(B, G, R), -1);




             }

             #region draw the projected region on the image

             if (homography != null)
             {
                 //draw a rectangle along the projected model
                 Rectangle rect = new Rectangle(Point.Empty, modelImage.Size);
                 PointF[] pts = new PointF[]
               {
                  new PointF(rect.Left, rect.Bottom),
                  new PointF(rect.Right, rect.Bottom),
                  new PointF(rect.Right, rect.Top),
                  new PointF(rect.Left, rect.Top)
               };
                 pts = CvInvoke.PerspectiveTransform(pts, homography);

                 Point[] points = Array.ConvertAll<PointF, Point>(pts, Point.Round);
                 using (VectorOfPoint vp = new VectorOfPoint(points))
                 {
                     CvInvoke.Polylines(result, vp, true, new MCvScalar(255, 0, 0, 255), 5);
                 }

             }

             #endregion
             outmp = modelKeyPoints;
             outop = observedKeyPoints;

             return result;

         }
      }
   }
}
