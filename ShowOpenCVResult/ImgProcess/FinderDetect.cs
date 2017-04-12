using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ShowOpenCVResult
{
    class ContentFinder
    {
        public static Mat[] Find(Mat image, Mat findimage, Rectangle r,ref Rectangle outr,int cr = 100,double eps =0.01)
        {
            double scale =0.2;
            Mat imaRoi = new Mat(image, r);
            var hsvROI = new Mat();
            int minSat = 65;
            CvInvoke.CvtColor(imaRoi, hsvROI, ColorConversion.Bgr2Hsv);
            var hsvROIImg = hsvROI.ToImage<Hsv, byte>(); 
            var mask = new Mat();
            CvInvoke.Threshold(hsvROIImg.Split()[0], mask, minSat, 255, ThresholdType.Binary);  


            DenseHistogram hist = new DenseHistogram(256, new RangeF(0, 255));
            hist.Calculate<byte>(new Image<Gray, byte>[] { hsvROIImg.Split()[0] }, false, mask.ToImage<Gray, byte>());
            //CvInvoke.Normalize(hist, hist, 0, 255, NormType.MinMax);
            Mat findhsv = new Mat();;  
            CvInvoke.CvtColor(findimage, findhsv, ColorConversion.Bgr2Hsv);
            var result = hist.BackProject<byte>(new Image<Gray, byte>[] { findhsv.ToImage<Hsv, byte>().Split()[0] });

            MCvTermCriteria criteria = new MCvTermCriteria(cr, eps);
            outr = r;
            resizeRectangle(ref outr,scale);
            Mat resizemat = new Mat();
            CvInvoke.Resize(result, resizemat, new Size((int)(result.Width * scale), (int)(result.Height * scale)));
            CvInvoke.CamShift(resizemat, ref outr, criteria);

            resizeRectangle(ref outr, 1.0 / scale);
            CvInvoke.Rectangle(result, outr, new MCvScalar(255, 0, 0));

            CvInvoke.Rectangle(image, r, new Emgu.CV.Structure.MCvScalar(255, 0, 0));
            return new Mat[2] { image, result.Mat };
        }

        static void resizeRectangle(ref Rectangle r,double scale) {
            Size s = r.Size;
            r.Size = new Size((int)(s.Width * scale), (int)(s.Height * scale));
            r.X = (int)(r.X * scale);
            r.Y = (int)(r.Y * scale);
        }

    };


}
