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
using System.ComponentModel;

namespace ShowOpenCVResult
{
    public enum RoadObjectType{
        FullLine,//实线
        PartOfDottedLine,//虚线
        SignInLoad,//路面标志
        Unkown,// 未知
    }

    static class OpencvMath
    {

        static public Mat CalTransformatMat(Size img, float xk, float yk, float ltk, int outwidth, int outheight) {
            PointF[] srcTri = new PointF[4];
            PointF[] dstTri = new PointF[4];
            int inw = img.Width;
            int inh = img.Height;
            srcTri[0] = new PointF(xk * inw, yk * inh);
            srcTri[1] = new PointF(inw - xk * inw, yk * inh);
            srcTri[2] = new PointF(ltk * inw + (inw / 2 + 1), inh - 1);
            srcTri[3] = new PointF((inw / 2) - ltk * inw, inh - 1);
            dstTri[0] = new PointF(0, 0);
            dstTri[1] = new PointF(outwidth - 1, 0);
            dstTri[2] = new PointF(outwidth - 1, outheight - 1);
            dstTri[3] = new PointF(0, outheight - 1);
            return CvInvoke.GetPerspectiveTransform(srcTri, dstTri);
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

        static public void DrawRotatedRect(RotatedRect rr, IInputOutputArray backimg, int kickness = 2) {
            PointF[] pts = rr.GetVertices();
            Point[] intpts = new Point[4];
            for (int i = 0; i < 4; i++)
            {
                intpts[i] = new Point((int)pts[i].X, (int)pts[i].Y);
            }
            for (int i = 0; i < 4; i++) {
                CvInvoke.Line(backimg, intpts[i % 4], intpts[(i + 1) % 4], new MCvScalar(255, 0, 0), 2);
            }
        }

        static public void DrawRotatedRectInGray(RotatedRect rr, IInputOutputArray backimg, int kickness = 2)
        {
            PointF[] pts = rr.GetVertices();
            Point[] intpts = new Point[4];
            for (int i = 0; i < 4; i++)
            {
                intpts[i] = new Point((int)pts[i].X, (int)pts[i].Y);
            }
            for (int i = 0; i < 4; i++)
            {
                CvInvoke.Line(backimg, intpts[i % 4], intpts[(i + 1) % 4], new MCvScalar(127), 2);
            }
        }

        static public Mat GetSquareExampleImg(VectorOfPoint vp, Size orgimgsize, bool angleadjust = true, bool needthreshold = true)
        {
            var rightvp = AngleAdjustVp(vp);

            Rectangle vpr = CvInvoke.BoundingRectangle(rightvp);
            Image<Gray, Byte> gray = new Image<Gray, byte>(orgimgsize);
            int scale = Math.Max(orgimgsize.Height, orgimgsize.Width);
            VectorOfVectorOfPoint vvp = new VectorOfVectorOfPoint();
            vvp.Push(rightvp);
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
            Mat result = r.Clone();
            CvInvoke.Resize(result, result, RoadTransform.ExampleSize);
            if (needthreshold)
            {
                CvInvoke.Threshold(result, result, 127, 255, ThresholdType.Binary);
            }

            return result;
        }

        static public VectorOfPoint AngleAdjustVp(VectorOfPoint vp)
        {
            RotatedRect rr = CvInvoke.MinAreaRect(vp);
            double angle = rr.Size.Width > rr.Size.Height ? 90.0 + rr.Angle : rr.Angle;
            PointF center = rr.Center;
            Mat rote = new Mat();
            CvInvoke.GetRotationMatrix2D(center, angle, 1, rote);
            PointF[] pfs = Array.ConvertAll<Point, PointF>(vp.ToArray(), (Point x) => { return new PointF(x.X, x.Y); });
            VectorOfPointF dst = new VectorOfPointF();
            CvInvoke.Transform(new VectorOfPointF(pfs), dst, rote);
            Point[] resultpts = Array.ConvertAll<PointF, Point>(dst.ToArray(), Point.Round);
            return new VectorOfPoint(resultpts);
        }

        static public void CreatAnglesImg(string filepath, params double[] angles)
        {

            Image<Bgr, byte> img = new Image<Bgr, byte>(filepath);
            foreach (double angle in angles) {
                Image<Bgr, byte> rotate = img.Rotate(angle, new Bgr(0, 0, 0), true);
                rotate.Save(string.Format("{0}\\{1}_{2}{3}", Path.GetDirectoryName(filepath), Path.GetFileNameWithoutExtension(filepath), angle, Path.GetExtension(filepath)));
            }
        }

        static public Image<Bgr, byte>[] CreatAnglesImg(Image<Bgr, byte> img, params double[] angles)
        {
            int cnt = angles.Count();
            var imgs = new Image<Bgr, byte>[cnt];
            for (int i = 0; i < cnt; i++)
            {
                imgs[i] = img.Rotate(angles[i], new Bgr(0, 0, 0), true);
            }
            return imgs;
        }

        static Image<Bgr, Byte> GetImgPart(Image<Bgr, Byte> Img, Point[] pts)
        {
            Image<Gray, Byte> ImgMask = new Image<Gray, byte>(Img.Size);

            VectorOfVectorOfPoint vvp = new VectorOfVectorOfPoint(new Point[1][] { pts });
            CvInvoke.DrawContours(ImgMask, vvp, -1, new MCvScalar(255), -1);
            Image<Bgr, Byte> result = Img.Copy(ImgMask);

            vvp.Dispose();
            ImgMask.Dispose();

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

        static public Mat GetBlindnessMask(IInputArray inputimg, int thresholdlow = 5) {
            Mat m = new Mat();
            CvInvoke.Threshold(inputimg, m, thresholdlow, 255, ThresholdType.Binary);
            return m;
        }

        static public void RoadPreProcess(Mat inputimg, IInputArray mask = null, int openSize = 1, int meadinSize = 2) {
            Mat result = new Mat();
            int width = inputimg.Width, height = inputimg.Height;

            Mat intmat = new Mat();
            inputimg.ConvertTo(intmat, DepthType.Cv32S);

            Mat rect = new Mat(intmat, new Rectangle(new Point(width / 10, height / 10), new Size(width / 10 * 8, height / 10 * 8)));
            double min = 0, max = 0;
            int[] maxid = new int[2], minid = new int[2];
            CvInvoke.MinMaxIdx(rect, out min, out max,minid,maxid );
            Mat empty = new Mat(intmat.Size, DepthType.Cv32S, 1);
            CvInvoke.AddWeighted(intmat, 256.0 / (max - min), empty, 0, -256.0 / (max - min) * min,intmat);
            intmat.ConvertTo(inputimg, DepthType.Cv8U);
            intmat.Dispose();

            CvInvoke.Normalize(inputimg, inputimg, 0, 255, NormType.MinMax, DepthType.Default, mask);
            CvInvoke.MedianBlur(inputimg, inputimg, meadinSize * 2 + 1);
            CvInvoke.MorphologyEx(inputimg, inputimg, MorphOp.Close, CvInvoke.GetStructuringElement(ElementShape.Cross, new Size( 3, openSize * 2 + 1), new Point(-1, -1)), new Point(-1, -1), 1, BorderType.Default, new MCvScalar(0));
            EdgeEnhancement(inputimg);
        }

        static public void EdgeEnhancement(Mat img) {
            if (img == null || img.IsEmpty || img.NumberOfChannels != 1) throw new ArgumentException("img is empty or not one channel");
            Mat laplace = new Mat();
            Mat gussbulr = new Mat();
            CvInvoke.GaussianBlur(img, gussbulr, new Size(3, 3), 0, 0);
            CvInvoke.Laplacian(gussbulr, laplace, DepthType.Cv16S);
            Mat laplacemat8u = new Mat();
            laplace.ConvertTo(laplacemat8u, DepthType.Cv8U);
            CvInvoke.Add(img, laplacemat8u, img);
            laplacemat8u.Dispose();
            laplace.Dispose();
            gussbulr.Dispose();
            
        }

        static public Mat GetLine(IInputArray inputimg, int width) {
            var lineimg = new Mat();
            CvInvoke.AdaptiveThreshold(inputimg, lineimg, 255, AdaptiveThresholdType.MeanC, ThresholdType.Binary, 2 * (width / 6) + 1, -20);
            return lineimg;
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
                var type = OpencvMath.JugdeLineShape(vp, back.Size);
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

        static public Point FindSeedPointToFill(Mat img, double upos = 0.5, double vpos = 0.95)
        {
            if (img.Depth != DepthType.Cv8U || img.NumberOfChannels != 1) throw new ArgumentException("img.Depth!= DepthType.Cv8U||img.NumberOfChannels!=1");
            Point p = new Point((int)(img.Size.Width * upos), (int)(img.Size.Height * vpos));
            int distance = img.Size.Width / 20, tims = 0;
            int rows = img.Rows, cols = img.Cols;
            unsafe
            {
                byte* ptr = (byte*)img.DataPointer;
                while (*(ptr+p.Y*cols+p.X) > 150)
                {
                    tims++;
                    p.X += (tims % 2 == 1 ? -1 : 1) * distance;
                    distance += 5;
                    if (p.X < 0 || p.X > img.Cols - 1)
                        break;
                }

                if (p.X < 0 || p.X >= rows) {
                    p = new Point((int)(img.Size.Width * upos), (int)(img.Size.Height * vpos));
                }
            }
            return p;
        }
        /// <summary>
        /// 基于跨越的行扫描算法：检测人行道区域
        /// </summary>
        /// <param name="binaryimg">包含人行道的二值图</param>
        /// <param name="rowstep">横向扫描跳跃行数</param>
        /// <param name="minrownums">最小行数要求</param>
        /// <param name="changePointsNumThreshold">当行跳变条点数要求</param>
        /// <param name="minwritertoblack">最小白黑比</param>
        /// <param name="maxwritertoblack">最大白黑比</param>
        /// <param name="maxerrorstep">最大容忍误检次数</param>
        /// <param name="minAreaRate">最小占面比</param>
        /// <returns></returns>
        static public VectorOfVectorOfPoint WalkRoadImg(Mat binaryimg, int rowstep = 4, int minrownums = 20 ,  int changePointsNumThreshold = 5 ,double minwritertoblack = 0.4, double maxwritertoblack = 2 ,int maxerrorstep = 4,double minAreaRate = 0.05) {
            if(binaryimg.NumberOfChannels!=1) return null;

            VectorOfVectorOfPoint vvp = new VectorOfVectorOfPoint();
            List<Point> left = new List<Point>();
            List<Point> right = new List<Point>();
            int rows = binaryimg.Rows, colums = binaryimg.Cols;
            //CvInvoke.Threshold(binaryimg, binaryimg, 100, 255, ThresholdType.Binary);
            unsafe
            {
                byte* ptr = (byte*) binaryimg.DataPointer;
                int beginRowIndex = 0, endRowIndex = 0 , curlostnum = 0;
                bool find = false;

                for (int i = 0; i < rows; i += rowstep)
                {
                    byte* rowhead = (ptr + i * colums);
                    bool isBeginAtBlack = *rowhead == 0;

                    int blackwidthsum = 0, writewidthsum = 0, blacknum = 0, writenum = 0;
                    int lastchangeindex = 0;
                    int beginIndex = 0, endIndex = 0;

                    for (int j = 1; j < colums; j++)
                    {
                        byte curvalue = *(rowhead + j), prevvalue = *(rowhead + j - 1); ;
                        if ((curvalue ==255|| prevvalue==255) && curvalue != prevvalue)
                        {
                            if (curvalue ==255)
                            {
                                if (lastchangeindex > 0)
                                {
                                    int backdis = (j - lastchangeindex);
                                    if (blacknum>0&&backdis > blackwidthsum/blacknum*3  && lastchangeindex > colums / 4&&writenum+blacknum>changePointsNumThreshold)
                                    {
                                        endIndex = lastchangeindex;
                                        break;
                                    }

                                    bool isclearprev = false;

                                    if (backdis > colums / 4 && backdis>lastchangeindex*2&& lastchangeindex<colums/4)
                                    {
                                        blackwidthsum = 0;
                                        writewidthsum = 0;
                                        blacknum = 0;
                                        writenum = 0;
                                        isclearprev = true;
                                        beginIndex = j;
                                        endIndex = 0;
                                        
                                    }

                                    if (isclearprev) {
                                        lastchangeindex = j;
                                    }
                                    else
                                    {
                                        blackwidthsum += (j - lastchangeindex);
                                        blacknum++;
                                        lastchangeindex = j;
                                    }


                                }
                                else
                                {
                                    beginIndex = j;
                                    lastchangeindex = j;
                                }

                                

                            }
                            else
                            {
                                writewidthsum += (j - lastchangeindex);
                                writenum++;
                                lastchangeindex = j;

                            }
                        }
                        if (j == colums - 1)
                        {
                            endIndex = curvalue > 0 ? colums - 1 : lastchangeindex;
                        }
                    }
                    bool isleagal = false;
                    if (writenum != 0 && blacknum != 0)
                    {
                        double rate = ((double)writewidthsum / writenum) / ((double)blackwidthsum / blacknum);
                        if (rate > minwritertoblack && rate < maxwritertoblack && blacknum + writenum >= changePointsNumThreshold) 
                        {
                            isleagal = true;
                            if (!find)
                            {
                                beginRowIndex = i;
                                find = true;
                                endRowIndex = i;
                            }
                            else
                            {
                                endRowIndex = i;
                            }

                            Point p1 = new Point(beginIndex, i);
                            left.Add(p1);
                            Point p2 = new Point(endIndex, i);
                            right.Add(p2);
                            curlostnum = 0;
                        }
                    }

                    if(!isleagal)
                    {
                        //到达不满足条件的行时
                        if (endRowIndex > 0)
                        {
                            //累加误行数量
                            curlostnum++;
                        }

                        //误行达到一定数量时被认为一个人行道对象识别结束
                        if (curlostnum >= maxerrorstep)
                        {
                            //如果行数达到要求 则该对象加入到结果中
                            if (endRowIndex - beginRowIndex > minrownums) {
                                VectorOfPoint vp = new VectorOfPoint(left.ToArray());
                                right.Reverse();
                                vp.Push(right.ToArray());
                                double area = CvInvoke.ContourArea(vp);
                                Rectangle ro = CvInvoke.BoundingRectangle(vp);
                                double wh = (double)ro.Width / ro.Height;
                                bool canadded = area / (colums * rows) > minAreaRate && wh > 1.5 && wh < 6;
                                if (canadded)
                                {
                                    vvp.Push(vp);
                                }
                                else
                                {
                                    vp.Dispose();
                                }



                            }
                            //重置局部变量
                            beginRowIndex = 0; endRowIndex = 0;
                            curlostnum = 0;
                            find = false;
                            right.Clear();
                            left.Clear();
                        }

                    }
                }

                if (find) {
                    if (endRowIndex - beginRowIndex > minrownums)
                    {
                        VectorOfPoint vp = new VectorOfPoint(left.ToArray());
                        right.Reverse();
                        vp.Push(right.ToArray());
                        vvp.Push(vp);
                    }
                }
            }

            return vvp;
        }

        static public VectorOfMat NormolizeHsvImg(Mat hsvimg,Mat mask=null) {
            VectorOfMat vm = new VectorOfMat();
            CvInvoke.Split(hsvimg, vm);
            CvInvoke.Normalize(vm[1], vm[1], 0, 255, NormType.MinMax, DepthType.Default, mask);
            CvInvoke.Normalize(vm[2], vm[2], 0, 255, NormType.MinMax, DepthType.Default, mask);
            return vm;
        }

        static public void FillRoad(ref Mat roadGray, int lowdiff = 3, int highdiff = 2)
        {
            Rectangle rect = new Rectangle();
            var backup = roadGray.Clone();
            Point p1 = OpencvMath.FindSeedPointToFill(roadGray);

            int nums = CvInvoke.FloodFill(backup, null,p1, new MCvScalar(0), out rect, new MCvScalar(lowdiff), new MCvScalar(highdiff),Connectivity.EightConnected);
            if (nums < roadGray.Size.Width * roadGray.Size.Height / 10)
            {
                backup.Dispose();
                Point p2 = OpencvMath.FindSeedPointToFill(roadGray, 0.3);
                nums = CvInvoke.FloodFill(roadGray, null,p2 , new MCvScalar(0), out rect, new MCvScalar(lowdiff), new MCvScalar(highdiff));
            }
            else
            {
                roadGray.Dispose();
                roadGray = backup;
            }
        }

        static public void MyThreshold(Mat img, byte min, byte max, byte setvalue = 255, bool isorop = false) {
            if (img == null || img.IsEmpty || img.NumberOfChannels != 1||img.Depth!= DepthType.Cv8U) throw new ArgumentException("img is empty or img.chanaels!=1 or img.depth isnot CV8U");
            bool needor = min > max && isorop;
            unsafe {
                byte* ptr = (byte*)img.DataPointer;
                int cols = img.Cols, rows = img.Rows;
                for (int i = 0; i < rows; i++)
                {
                    byte* rowhead = ptr+i*cols;
                    for (int j = 0; j < cols; j++)
                    {
                        byte value = *(rowhead + j);
                        bool cond1 = value >= min, cond2 = value <= max;
                        bool isinrange = needor ? cond1 || cond2 : cond1 && cond2;
                        if (isinrange)
                        {
                            *(rowhead + j) = setvalue;
                        }
                        else {
                            *(rowhead + j) = 0;
                        }
                    }
                }
            }
     

        }

        static public Mat HsvThreshold(Mat img,double hmin, double smin, double vmin, double hmax = 180,double smax=255, double vmax=255,  bool doNormalize = true) {
            if (img == null || img.IsEmpty) return null;

            Mat hsv = new Mat();
            CvInvoke.CvtColor(img, hsv, ColorConversion.Bgr2Hsv);
            var vm = new VectorOfMat();
            CvInvoke.Split(hsv, vm);
            hsv.Dispose();

            if (doNormalize)
            {
                CvInvoke.Normalize(vm[1], vm[1], 0, 255, NormType.MinMax, DepthType.Default);
                CvInvoke.Normalize(vm[2], vm[2], 0, 255, NormType.MinMax, DepthType.Default);
            }

            MyThreshold(vm[0], (byte)hmin, (byte)hmax, 255, true);

            MyThreshold(vm[1], (byte)smin, (byte)smax, 255, false);

            MyThreshold(vm[2], (byte)vmin, (byte)vmax, 255, false);

            Mat result1 = new Mat();
            img.CopyTo(result1, vm[0]);
            Mat result2 = new Mat();
            result1.CopyTo(result2, vm[1]);
            Mat result3 = new Mat();
            result2.CopyTo(result3, vm[2]);
            vm.Dispose(); ;
            result1.Dispose();
            result2.Dispose();
            return result3;
        }

        static public VectorOfVectorOfPoint FindMaxAreaIndexCon(Mat img,out int index) {
            VectorOfVectorOfPoint vvp = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(img, vvp, null, RetrType.List, ChainApproxMethod.ChainApproxNone);
            double max = 0;
            int maxindex = 0;
            for (int i = 0; i < vvp.Size; i++)
            {
                double area = CvInvoke.ContourArea(vvp[i]);
                if (area > max)
                {
                    max = area;
                    maxindex = i;
                }
            }
            index = maxindex;
            return vvp;
        }


        static public Mat FinalLineProcess(Mat img, out long time, bool needtrans = false, bool hascolor = false)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var imgs = img.Split();
            imgs[0].Dispose();
            imgs[1].Dispose();

            Mat tranform = null;
            Mat unroad = null;

            if (needtrans && !RoadTransform.TransformMat.IsEmpty)
            {
                tranform = RoadTransform.WarpPerspective(imgs[2]);
                imgs[2].Dispose();
                unroad = RoadTransform.Roadmask;
            }
            else
            {
                unroad = new Mat(imgs[2].Size, DepthType.Cv8U, 1);
                unroad.SetTo(new MCvScalar(255));
                tranform = imgs[2];
            }

    
            RoadPreProcess(tranform, null, 2);

            var line = GetLine(tranform, tranform.Width);
            FillRoad(ref tranform);

            CvInvoke.BitwiseAnd(line, tranform, line);
            CvInvoke.Threshold(tranform, tranform, 5, 127, ThresholdType.BinaryInv);
            CvInvoke.Threshold(line, line, 140, 255, ThresholdType.Otsu);
            CvInvoke.Add(line, tranform, line);
            tranform.Dispose();
            CvInvoke.MorphologyEx(line, line, MorphOp.Close, CvInvoke.GetStructuringElement(ElementShape.Cross, new Size(1, 5), new Point(-1, -1)), new Point(-1, -1), 1, BorderType.Default, new MCvScalar(0));
            CvInvoke.BitwiseAnd(line, unroad, line);
            sw.Stop();
            time = sw.ElapsedMilliseconds;

            if (hascolor)
            {
                Mat bgrresult = new Mat();
                img.CopyTo(bgrresult, line);
                line.Dispose();
                return bgrresult;
            }
            else
            {
                return line;
            }
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
            var result = OpencvMath.GetOneLineVector(img2);
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

    static class RoadTransform
    {

        #region SaveImgOption
        public static int KicknessScale = 200;
        public static Size ExampleSize = new Size(32, 32);
        #endregion

        #region transfrom
        private static float m_AX = 0.25f;
        private static float m_AY = 0.50f;
        private static float m_LT = 0.50f;

        private static Mat transformMat = new Mat();
        private static Mat m_roadmask = new Mat();
        
        public static Mat Roadmask
        {
            get
            {
                return m_roadmask;
            }
        }

        [DefaultValue(typeof(Size))]
        public static  Size InputSize
        {
            get;
            set;
        }

        [DefaultValue(typeof(Size))]
        public static Size OutSize
        {
            get;
            set;
        }

        public static Mat TransformMat
        {
            get
            {
                return transformMat;
            }
        }

        public static float AX
        {
            get
            {
                return m_AX;
            }
        }

        public static float AY
        {
            get
            {
                return m_AY;
            }
        }

        public static float LT
        {
            get{return m_LT;}
        }

        public static void SetTransform(int iw,int ih,float ax,float ay, float lt,int ow,int oh) {
            InputSize = new Size(iw, ih);
            OutSize = new Size(ow, oh);
            m_AX = ax; m_AY = ay; m_LT = lt; 
            transformMat = OpencvMath.CalTransformatMat(InputSize, ax, ay, lt, ow, oh);
            if (m_roadmask != null)
            {
                m_roadmask.Dispose();
            }
            m_roadmask = new Mat(InputSize, DepthType.Cv8U, 1);
            m_roadmask.SetTo(new MCvScalar(255));
            CvInvoke.WarpPerspective(m_roadmask, m_roadmask, transformMat, OutSize);
        }

        public static Mat WarpPerspective(Mat img) {
            Mat result = new Mat();
            CvInvoke.WarpPerspective(img, result, TransformMat, OutSize, Inter.Area, Warp.Default, BorderType.Reflect);
            return result;
        }

        #endregion

    }
}
        

