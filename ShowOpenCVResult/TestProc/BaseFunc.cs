using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using System.IO;
using System.Diagnostics;

namespace ShowOpenCVResult
{
    public enum RoadObjectType{
        FullLine,
        PartOfDottedLine,
        SignInLoad,
        Unkown,
    }

    static class BaseFunc
    {
        public static void AnchorTransformat<TColor, TDepth>(Image<TColor, TDepth> inputimg, ref Image<TColor, TDepth> Outimg, float xk, float yk, float ltk, int outwidth, int outheight, Inter way = Inter.Linear)
            where TColor : struct, Emgu.CV.IColor
            where TDepth : new()
        {
            PointF[] srcTri = new PointF[4];
            PointF[] dstTri = new PointF[4];
            int inw = inputimg.Size.Width;
            int inh = inputimg.Size.Height;
            srcTri[0] = new PointF(xk * inw, yk * inh);
            srcTri[1] = new PointF(inw - xk * inw, yk * inh);
            srcTri[2] = new PointF(ltk * inw + (inw / 2 + 1), inh - 1);
            srcTri[3] = new PointF((inw / 2) - ltk * inw, inh - 1);
            dstTri[0] = new PointF(0, 0);
            dstTri[1] = new PointF(outwidth - 1, 0);
            dstTri[2] = new PointF(outwidth - 1, outheight - 1);
            dstTri[3] = new PointF(0, outheight - 1);
            Outimg = new Image<TColor, TDepth>(outwidth, outheight);
            Mat m = CvInvoke.GetPerspectiveTransform(srcTri, dstTri);
            //return inputimg.WarpPerspective<double>(m, Emgu.CV.CvEnum.INTER.CV_INTER_AREA, Emgu.CV.CvEnum.WARP.CV_WARP_FILL_OUTLIERS, new TColor());
            CvInvoke.WarpPerspective(inputimg, Outimg, m, new Size(outwidth, outheight), way);
        }

        public static bool ArraySmooth(double[] value, int rangeLen, double e, ref double[] value2)
        {
            if (value == null || rangeLen <= 0 || value.Count() < (rangeLen * 2 + 1)) return false;
            int cnt = value.Count();
            uint Num = (uint)rangeLen;

            if (null == value2 || value2.Length != value2.Length) value2 = new double[cnt];

            if (1 == rangeLen)
            {
                Array.Copy(value, value2, value.Length);
                return true;
            }

            for (int i = 0; i < cnt; i++)
            {
                if (e > 0 && System.Math.Abs(value[i]) > e) { value2[i] = value[i]; continue; }

                double dSum = value[i];
                int iSCnt = 1;

                int t0 = System.Math.Max(i - rangeLen, 0);
                int t1 = System.Math.Min(i + rangeLen, cnt - 1);

                for (int t = i - 1; t >= t0; --t)
                {
                    if (e > 0 && System.Math.Abs(value[t]) > e) break;

                    dSum += value[t];
                    iSCnt += 1;
                }

                for (int t = i + 1; t <= t1; ++t)
                {
                    if (e > 0 && System.Math.Abs(value[t]) > e) break;

                    dSum += value[t];
                    iSCnt += 1;
                }

                if (1 == iSCnt)
                {
                    value2[i] = value[i];
                }
                else
                {
                    double v = dSum / iSCnt;
                    double v0 = System.Math.Abs(value[i]);
                    double v1 = System.Math.Abs(v);

                    //if (v0!=0 && (v0 < v1 * 0.1 || v0 > v1 * 10)) value2[i] = value[i];
                    //else value2[i] = v;
                    value2[i] = v;
                }

            }
            return true;
        }

        static public IEnumerable<int> GetTopIndexs(params int[] list) {
            int cnt = list.Count();
            List<int> indexs = new List<int>();
            for (int i = 1; i <= cnt - 2; i++)
                if ((list[i] - list[i - 1]) * (list[i] - list[i + 1]) > 0)
                    indexs.Add(i);
            return indexs;
        }

        static public void GetVPImg(VectorOfPoint vp)
        {
            if (vp == null) {
                throw new ArgumentException();
            }
            RotatedRect rr = CvInvoke.MinAreaRect(vp);


        }


        static public void DrawRotatedRect(RotatedRect rr, IInputOutputArray backimg,int kickness = 2) {
            PointF[] pts = rr.GetVertices();
            Point[] intpts = new Point[4];
            for (int i = 0; i < 4; i++)
            {
                intpts[i] = new Point((int)pts[i].X, (int)pts[i].Y);
            }
            for (int i = 0; i < 4; i++) {
                CvInvoke.Line(backimg, intpts[i % 4], intpts[(i + 1) % 4], new MCvScalar(255, 0, 0),2);
            }
        }

        static public Mat GetSquareExampleImg(VectorOfPoint vp, Size orgimgsize)
        {
            Rectangle vpr = CvInvoke.BoundingRectangle(vp);
            Image<Gray, Byte> gray = new Image<Gray, byte>(orgimgsize);
            int scale = Math.Max(orgimgsize.Height, orgimgsize.Width);
            VectorOfVectorOfPoint vvp = new VectorOfVectorOfPoint();
            vvp.Push(vp);
            CvInvoke.DrawContours(gray, vvp, 0, new MCvScalar(255), -1, LineType.AntiAlias);

            Mat inmat = new Mat(gray.Mat, vpr);

            int w = inmat.Width, h = inmat.Height;
            Mat r;
            if (w >= h)
            {
                r = new Image<Gray, byte>(w, w).Mat;
                Mat roi = new Mat(r, new Rectangle(0, (w - h) / 2, w, h));
                inmat.CopyTo(roi, null);

            }
            else
            {

                r = new Image<Gray, byte>(h, h).Mat;
                Mat roi = new Mat(r, new Rectangle((h - w) / 2, 0, w, h));
                inmat.CopyTo(roi, null);

            }
            vvp.Dispose();
            CvInvoke.Resize(r, r, Setting.ExampleSize);
            return r;
        }

        static public void CreatAnglesImg(string filepath, params double[] angles)
        {

            Image<Bgr, byte> img = new Image<Bgr, byte>(filepath);
            foreach (double angle in angles) {
                Image<Bgr, byte> rotate = img.Rotate(angle, new Bgr(0, 0, 0), true);
                rotate.Save(string.Format("{0}\\{1}_{2}{3}", Path.GetDirectoryName(filepath), Path.GetFileNameWithoutExtension(filepath), angle, Path.GetExtension(filepath)));
            }
        }

        static Image<Bgr, Byte> GetImgPart(Image<Bgr, Byte> Img, Point[] pts)
        {
            Image<Gray, Byte> ImgMask = new Image<Gray, byte>(Img.Size);
            VectorOfPoint vp = new VectorOfPoint(pts);
            VectorOfVectorOfPoint vvp = new VectorOfVectorOfPoint();
            vvp.Push(vp);
            CvInvoke.DrawContours(ImgMask, vvp, -1, new MCvScalar(255), -1);
            vp.Dispose();
            vvp.Dispose();
            Image<Bgr, Byte> result = Img.Copy(ImgMask);
            return result;
        }

        static public Image<Gray, float> GetOneLineVector(Image<Gray, float> inputimg)
        {

            Image<Gray, float> outimg = new Image<Gray, float>(inputimg.Size.Height * inputimg.Size.Width, 1);
            unsafe {
                float* inputhead = (float*)inputimg.Mat.DataPointer;
                float* outputhead = (float*)outimg.Mat.DataPointer;
                int w = inputimg.Width, h = inputimg.Height, instep = inputimg.Mat.Step;

                for (int hidx = 0; hidx < h; hidx++)
                    for (int widx = 0; widx < w; widx++)
                    {
                        *(outputhead + hidx * w + widx) = *(inputhead + hidx * w + widx);
                    }
            }

            return outimg;
        }
        static public void GetSplitRoadImg(Image<Gray, byte> inputimg, ref Image<Gray, byte> lineimg, ref Image<Gray, byte> blindness, int thresholdup = 170, int thresholdlow = 10) {
            CvInvoke.Normalize(inputimg, inputimg, 0, 255, Emgu.CV.CvEnum.NormType.MinMax);
            Gray g = new Gray(thresholdup);
            if (lineimg != null) lineimg.Dispose();
            lineimg = new Image<Gray, byte>(inputimg.Size);
            CvInvoke.AdaptiveThreshold(inputimg, lineimg, 255, AdaptiveThresholdType.MeanC, ThresholdType.Binary, 2*(inputimg.Size.Width /10)+1, -10);
                //= inputimg.ThresholdBinary(g, new Gray(255));
            if (blindness != null) blindness.Dispose();
            blindness = inputimg.ThresholdBinaryInv(new Gray(thresholdlow), new Gray(100));

        }

        
        static public RoadObjectType JugdeLineShape(VectorOfPoint vp,Size imgsize)
        {
            double imgarea = imgsize.Height * imgsize.Width;
            double max = 0.25, min = 0.0005;
            double conarea = CvInvoke.ContourArea(vp);
            double length = CvInvoke.ArcLength(vp, true);
            double width = conarea / length * 2;
            double rate = conarea / imgarea;
            if (rate > max || rate < min) return RoadObjectType.Unkown;

            if (length > imgsize.Height) {
                if (width < imgsize.Width * 0.05) 
                    return RoadObjectType.FullLine;
                else
                    return RoadObjectType.Unkown;
            } 
            RotatedRect rr = CvInvoke.MinAreaRect(vp);
            double w_h = rr.Size.Width / rr.Size.Height;
            double k = w_h > 1 ? w_h : 1 / w_h;



            double rectrate = conarea / (rr.Size.Width * rr.Size.Height);
            if (rectrate > 0.8&&k>5) return RoadObjectType.PartOfDottedLine;
            else return RoadObjectType.SignInLoad;

        }

        static public Mat JugdeTest(VectorOfVectorOfPoint cons,Mat back,ref long time) {
            Mat test = back.Clone();
            time = 0;
            Stopwatch sw = new Stopwatch();
            for (int i = 0; i < cons.Size; i++)
            {

                var vp = cons[i];
                if (vp == null||vp.Size==0) continue;

                sw.Start();
                var type = BaseFunc.JugdeLineShape(vp, back.Size);
                sw.Stop();
                time += sw.ElapsedMilliseconds;

                MCvScalar ms = new MCvScalar();
                switch (type)
                {
                    case RoadObjectType.FullLine:
                        ms = new MCvScalar(255, 255, 0);
                        break;
                    case RoadObjectType.PartOfDottedLine:
                        ms = new MCvScalar(0, 255, 0);
                        break;
                    case RoadObjectType.SignInLoad:
                        ms = new MCvScalar(255, 0, 0);
                        break;
                    case RoadObjectType.Unkown:
                        ms = new MCvScalar(0, 0, 255);
                        break;
                    default:
                        break;
                }

                var vvp = new VectorOfVectorOfPoint();
                vvp.Push(vp);
                CvInvoke.DrawContours(test, vvp, -1, ms, -1);
                vvp.Dispose();
            }
            return test;
          
        }

        #region PtrTest
        static public void PtrTest() {

            Image<Bgr, byte> imgimg = new Image<Bgr, byte>(new Size(500,500));
            imgimg[0, 0] = new Bgr(0, 0, 0);
            imgimg[0, 1] = new Bgr(1, 11, 111);
            imgimg[1, 0] = new Bgr(2, 22, 222);
            imgimg[1, 1] = new Bgr(3, 33, 250);
            
      
            Stopwatch Watch = new Stopwatch();
            Watch.Start();
            var result2 = imgimg.Resize(250000, 1, Inter.Linear);
            Watch.Stop();
            long time1 = Watch.ElapsedMilliseconds;

            Stopwatch Watch1 = new Stopwatch();
            Watch1.Start();
            var img2 = imgimg.Convert<Gray, float>();
            Watch1.Stop();
            long time2 = Watch1.ElapsedMilliseconds;

            Stopwatch Watch2 = new Stopwatch();
            Watch2.Start();
            var result = BaseFunc.GetOneLineVector(img2);
            Watch2.Stop();
            long time3 = Watch2.ElapsedMilliseconds;



            Mat img = imgimg.Mat;
            int w = img.Width, h = img.Width, step = img.Step, chs = img.NumberOfChannels;
            unsafe
            {
                byte* pt = (byte*)img.DataPointer;
                for (int i = 0; i < h; i++)
                {
                    for (int j = 0; j < w; j++)
                    {
                        byte* value = pt + step * i + j * chs;
                        for (int k = 0; k < chs; k++)
                        {
                            byte onevalue = *(value + k);
                            //TODO:
                        }
                    }
                }
            }

        
        }

        #endregion
    }

    static class Setting
    {

        #region SaveImgOption
        public static int KicknessScale = 200;
        public static Size ExampleSize = new Size(50, 50);
        #endregion

        #region transfrom

        
        
        #endregion

    }
}
        

