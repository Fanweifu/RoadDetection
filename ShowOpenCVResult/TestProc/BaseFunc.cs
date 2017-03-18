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

namespace ShowOpenCVResult
{
    static class  BaseFunc
    {
        public static void AnchorTransformat<TColor, TDepth>(Image<TColor, TDepth> inputimg, ref Image<TColor, TDepth> Outimg, float xk, float yk, float ltk, int outwidth, int outheight)
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
            CvInvoke.WarpPerspective(inputimg, Outimg, m, new Size(outwidth, outheight));
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

        static public IEnumerable<int> GetTopIndexs( params int [] list ) { 
            int cnt =list.Count();
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


        static public void DrawRotatedRect(RotatedRect rr, IInputOutputArray backimg) {
            PointF[] pts = rr.GetVertices();
            Point[] intpts = new Point[4];
            for (int i = 0; i < 4; i++)
            {
                intpts[i] = new Point((int)pts[i].X, (int)pts[i].Y);
            }
            for (int i = 0; i < 4; i++) {
                CvInvoke.Line(backimg, intpts[i % 4], intpts[(i + 1) % 4],new MCvScalar(255,0,0));
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
            
            Mat inmat = new Mat(gray.Mat,vpr);

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
            CvInvoke.Resize(r, r, Setting.ExampleSize);
            return r;
        }

        static public void CreatAnglesImg(string filepath , params double[] angles)
        {

            Image<Bgr, byte> img = new Image<Bgr, byte>(filepath);
            foreach(double angle in angles){
                Image<Bgr, byte> rotate = img.Rotate(angle, new Bgr(0, 0, 0), true);
                rotate.Save(string.Format("{0}\\{1}_{2}{3}", Path.GetDirectoryName(filepath), Path.GetFileNameWithoutExtension(filepath), angle, Path.GetExtension(filepath)));
            }
        }

        static Image<Bgr, Byte>  GetImgPart(Image<Bgr, Byte> Img, Point[] pts )
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
            Image<Gray, float> img = new Image<Gray, float>(inputimg.Size.Height * inputimg.Size.Width, 1);
            
            for (int h = 0; h < inputimg.Height; h++)
                for (int w = 0; w < inputimg.Width; w++)
                    img[0, h * inputimg.Width + w] = inputimg[h, w];
            return img;
        }


    }

    static class Setting
    {
        public static int KicknessScale = 200;
        public static Size ExampleSize = new Size(50, 50); 
    }
}
        

