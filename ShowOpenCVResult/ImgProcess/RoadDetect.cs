using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Accord.MachineLearning.VectorMachines;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using ShowOpenCVResult.Properties;

namespace ShowOpenCVResult.ImgProcess
{
    interface ILoadPramas
    {
        void LoadSetting();

    }

    public class RoadTransform: ILoadPramas
    {


        #region Field
        private float m_AX = 0.25f;
        private float m_AY = 0.50f;
        private float m_LT = 0.50f;
        private Size m_inputSize;
        private Size m_outputSize;

        private Mat m_transformMat = new Mat();
        private Mat m_roadMask = new Mat();
        private Mat m_tranforMatInv = new Mat();

        private Inter m_interType = Inter.Area;
        private BorderType m_borderType = BorderType.Replicate;

        static RoadTransform m_default = null;
        #endregion

        #region Property

        public Mat RoadMask
        {
            get
            {
                return m_roadMask;
            }
        }

        public Size InSize
        {
            get
            {
                return m_inputSize;
            }

        }

        public Size OutSize
        {
            get
            {
                return m_outputSize;
            }
        }

        public float AX
        {
            get
            {
                return m_AX;
            }
        }

        public float AY
        {
            get
            {
                return m_AY;
            }
        }

        public float LT
        {
            get { return m_LT; }
        }

        public bool IsEmpty
        {
            get
            {
                return m_transformMat == null;
            }
        }

        public static RoadTransform Default
        {
            get
            {
                if (m_default == null)
                {
                    m_default = new RoadTransform();
                    m_default.LoadSetting();
                }

                return m_default;
            }
        }

        public Inter InterType
        {
            get
            {
                return m_interType;
            }

            set
            {
                m_interType = value;
            }
        }

        public BorderType BorderType
        {
            get
            {
                return m_borderType;
            }

            set
            {
                m_borderType = value;
            }
        }

        #endregion

        #region Construct

        private RoadTransform()
        {

        }

        #endregion

        #region Funcation

        public void SetTransform(Size inputsize, float ax, float ay, float lt, int ow, int oh)
        {
            m_inputSize = inputsize;
            m_outputSize = new Size(ow, oh);
            m_AX = ax; m_AY = ay; m_LT = lt;
            m_transformMat= CalTransformatMat(InSize, ax, ay, lt, ow, oh);
            if (m_roadMask != null)
            {
                m_roadMask.Dispose();
            }
            m_roadMask = new Mat(InSize, DepthType.Cv8U, 1);
            m_roadMask.SetTo(new MCvScalar(255));
            CvInvoke.WarpPerspective(m_roadMask, m_roadMask, m_transformMat, OutSize);
            CvInvoke.Invert(m_transformMat, m_tranforMatInv, DecompMethod.LU);
        }
        public void LoadSetting()
        {
            var config = Settings.Default;
            SetTransform(config.DetectArea.Size,  config.AX, config.AY, config.LT, config.OW, config.OH);

        }
        public Mat ImgWarpPerspective(Mat img)
        {
            Mat result = new Mat();
            CvInvoke.WarpPerspective(img, result, m_transformMat, OutSize, Inter.Cubic, Warp.Default,m_borderType);
            return result;
        }
        public PointF[] PointsWarpPerspective(params PointF[] pts)
        {
            return CvInvoke.PerspectiveTransform(pts, m_transformMat);
        }
        public Mat ImgWarpPerspectiveInv(Mat img)
        {
            Mat result = new Mat();
            CvInvoke.WarpPerspective(img, result, m_tranforMatInv, InSize, Inter.Area, Warp.Default, BorderType.Constant);
            return result;
        }
        public PointF[] PointsWarpPerspectiveInv(params PointF[] pts)
        {
            return CvInvoke.PerspectiveTransform(pts, m_tranforMatInv);
        }
        static public Mat CalTransformatMat(Size img, float xk, float yk, float ltk, int outwidth, int outheight)
        {
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

        #endregion
    }

    public class LaneDetect:ILoadPramas
    {
        #region Field
        int m_HuoghThreshold = 0;
        int m_HuoghMinLength = 0;
        int m_HuoghMaxGrap = 0;
        int m_CannyThreshold = 0;
        int m_CannyThresholdLink = 0;
        double m_rho = 1;
        double m_theata = 0.01;
        Size m_size = default(Size);
        bool m_loadParams = false;
        private Comparison<LineSegment2D> m_comparefun;
        #endregion

        #region Construct
        public LaneDetect(Size inputSize)
        {
            LoadSetting();
            m_loadParams = true;
            m_comparefun = (LineSegment2D ln1, LineSegment2D ln2) =>
            {
                double ln1x = compare(ln1, m_size.Height);
                double ln2x = compare(ln2, m_size.Height);
                if (ln1x == ln2x) return 0;
                else if (ln1x < ln2x) return -1;
                else return 1;
            };

        }
        #endregion

        #region Funcation

        private LineSegment2D[] detectLines(Mat img)
        {
            if (!m_loadParams) return null;
            if (img == null || img.IsEmpty || img.Depth != DepthType.Cv8U || img.NumberOfChannels != 1) throw new ArgumentException("img is unvalid");
            m_size = img.Size;
            Mat edge = new Mat();
            CvInvoke.Canny(img, edge, m_CannyThreshold, m_CannyThresholdLink);
            var result = CvInvoke.HoughLinesP(edge, m_rho, m_theata, m_HuoghThreshold, m_HuoghMinLength, m_HuoghMaxGrap);
            ///to  delect
            var mat = new Mat(edge.Size, DepthType.Cv8U, 3);
            mat.SetTo(new MCvScalar());
            foreach (var item in result)
            {
                CvInvoke.Line(mat, item.P1, item.P2, new MCvScalar(0, 255, 255), 2);
            }

            edge.Dispose();
            return result;
        }
        private LineSegment2D[] select(LineSegment2D  [] lines)
        { 
            int spindex = (m_size.Width - 1) / 2; 
            Array.Sort(lines, m_comparefun);
            int lastindex = -1;
            double lastx = double.MinValue;
            int cnt = lines.Count();
            for (int i = 0; i < cnt; i++)
            {
                var line = lines[i];
                double x = compare(lines[i],m_size.Height);
                if (x > spindex && lastx < spindex && i >= 1 && lastindex != -1)
                {
                    for (int j = i; j < cnt; j++)
                    {
                        var lnj = lines[j];
                        if (lnj.Length < m_size.Height / 4 || Math.Max(lnj.P1.Y, lnj.P2.Y) < m_size.Height / 3 * 2) continue;
                        for (int k = lastindex; k >= 0; k--)
                        {

                            var lnk = lines[k];
                            if (lnk.Length < m_size.Height / 4 || Math.Max(lnk.P1.Y, lnk.P2.Y) < m_size.Height / 3 * 2) continue;
                            double jx = compare(lnj, m_size.Height);
                            double kx = compare(lnk, m_size.Height);
                            double angle = Math.Abs(lnj.GetExteriorAngleDegree(lnk));
                            if (angle > 90)
                                angle = 180 - angle;
                            if (/*Math.Abs(result.Y) < size.Height / 5 && result.Y > 0 &&*/ Math.Abs(jx - kx) > m_size.Width/ 4 && angle < 5)
                                return new LineSegment2D[] { lines[k], lines[j] };
                        }
                    }
                }
                lastx = x;
                lastindex = i;

            }

            return new LineSegment2D[0];
       
    }
        public LineSegment2D[] Detect(Mat img)
        {
            if (img.Size != m_size) return null;
            return select(detectLines(img));
        }
        static double compare(LineSegment2D ln,int height)
        {
            if (ln.Direction.Y == 0) return double.MinValue;
            else
            {
                return (height - 1 - ln.P1.Y) / ln.Direction.Y * ln.Direction.X + ln.P1.X;
            }
        }
        static PointF getPoint(LineSegment2D ln1, LineSegment2D ln2)
        {
            float a = ln1.Direction.Y, b = ln1.Direction.X, m = ln1.Direction.Y * ln1.P1.X - ln1.Direction.X * ln1.P1.Y;
            float c = ln2.Direction.Y, d = ln2.Direction.X, n = ln2.Direction.Y * ln2.P1.X - ln2.Direction.X * ln2.P1.Y;
            float x = (m * d - b * n) / (a * d - b * c);
            float y = (m * c - a * n) / (b * c - a * d);
            return new PointF(x, y);

        }
        public void LoadSetting()
        {
            var config = Settings.Default;
            m_CannyThreshold = config.CannyThreshold;
            m_CannyThresholdLink = config.CannyLink;
            m_HuoghThreshold = config.LineThreshold;
            m_HuoghMinLength = config.LineMinLength;
            m_HuoghMaxGrap = config.LineMaxGrap;
            m_loadParams = true;
            m_size = new Size(config.OW, config.OH);
        }

        #endregion
    }

    public class PreProcess
    {
        #region Field
        int m_meadinSize = 2;
        Size m_vertialOpenSize = default(Size);
        Mat m_structElement = null;

        #endregion

        #region Contruct
        public PreProcess() {
            VertialOpenSize = new Size(5, 1);
        }
        #endregion

        #region Property

        public int MeadinSize
        {
            get
            {
                return m_meadinSize;
            }

            set
            {
                m_meadinSize = value;
            }
        }
        public Size VertialOpenSize
        {
            get
            {
                return m_vertialOpenSize;
            }

            set
            {
                if (m_vertialOpenSize != value)
                {
                    m_structElement = CvInvoke.GetStructuringElement(ElementShape.Rectangle, value, new Point(-1, -1));
                    m_vertialOpenSize = value;
                }

            }
        }

        #endregion

        void normalize(Mat inputimg,out double mingray, out double maxgray)
        {
            Mat rect = new Mat(inputimg, new Rectangle(new Point(inputimg.Width / 6, inputimg.Height / 4), new Size(inputimg.Width / 3 * 2, inputimg.Height / 2)));
            int[] maxid = new int[2], minid = new int[2];
            CvInvoke.MinMaxIdx(rect, out mingray, out maxgray, minid, maxid);
            OpencvMath.MyMinMaxNormalize(inputimg, mingray, maxgray);
        }

        public void RoadPreProcess(Mat inputimg, out double mingray, out double maxgray)
        {
            normalize(inputimg, out mingray, out maxgray);
            CvInvoke.MedianBlur(inputimg, inputimg, MeadinSize * 2 + 1);
            CvInvoke.MorphologyEx(inputimg, inputimg, MorphOp.Close,m_structElement, new Point(-1, -1), 1, BorderType.Default, new MCvScalar(0));
        }

    }

    public class ContoursSegment : ILoadPramas
    {
        #region Field
        double m_minLenght = 0;
        double m_minArea = 0;
        double m_maxArea = 0;
        double m_maxwidth = 0;
        double m_epsilon = 0;

        int m_adBlockSize = 0;
        double m_adParams = 0;
        
        //MulticlassSupportVectorMachine m_svm = null;

        bool[] m_usetag = null;

        #endregion

        public void LoadSetting()
        {
            var config = Settings.Default;
            m_minArea = config.MinArea;
            m_minLenght = config.MinLength;
            m_maxArea = config.MaxArea;
            m_maxwidth = config.MaxAreaToLength;
            m_adBlockSize = config.AdaptiveBlockSize;
            m_adParams = config.AdaptiveParam;
            m_epsilon = config.Epsilon;
        }

        #region Constrcut
        public ContoursSegment()
        {
            //m_svm = MulticlassSupportVectorMachine.Load("svm.dat");
            LoadSetting();
        }


        #endregion

        Mat imgSegment(Mat img)
        {
            Mat linesegmentimg = new Mat();
            CvInvoke.AdaptiveThreshold(img, linesegmentimg, 255, AdaptiveThresholdType.MeanC, ThresholdType.Binary, m_adBlockSize * 2 + 1, m_adParams);
            CvInvoke.BitwiseAnd(linesegmentimg, RoadTransform.Default.RoadMask, linesegmentimg);
            return linesegmentimg;
        }

        VectorOfVectorOfPoint getContours(Mat img, ref bool [] usetag)
        {
            VectorOfVectorOfPoint vvp = new VectorOfVectorOfPoint();
            int[,] treearray = CvInvoke.FindContourTree(img, vvp, ChainApproxMethod.ChainApproxSimple);
            int cnt = vvp.Size;
            usetag = new bool[cnt];
            for (int i = 0; i < cnt; i++)
            {
                var vp = vvp[i];
                if (!isWriteContoursIndex(treearray, i)) continue;
                Rectangle brect = CvInvoke.BoundingRectangle(vp);
                if (brect.Height < brect.Width) continue;

                CvInvoke.ApproxPolyDP(vp, vp, m_epsilon, true);
                double area = CvInvoke.ContourArea(vp);
                double length = CvInvoke.ArcLength(vp, true);
                if (!(area >= m_minArea && area <=m_maxArea &&length >= m_minLenght  && area / length < m_maxwidth)) continue;

                var rect = CvInvoke.MinAreaRect(vp);
                //double rate = area / (rect.Size.Width * rect.Size.Height);
                //if (rate < config.MinRateToRect) continue;
                usetag[i] = true;
            }

            return vvp;
        }

        bool isWriteContoursIndex(int[,] array, int id)
        {
            int inedx = id;
            int layer = 0;
            while (array[inedx, 3] > 0)
            {
                inedx = array[inedx, 3];
                layer++;
            }

            return layer % 2 == 0;
        }

        public VectorOfVectorOfPoint GetSelectContours(Mat img, ref Mat imgseg, ref bool [] usetag)
        {
            var seg = imgSegment(img);
            imgseg = seg.Clone();
            var result = getContours(seg, ref usetag);
            seg.Dispose();
            return result;
        }

    }
        
    public class RoadSvm
    {
        static Size m_svmSize = new Size(32, 32);
        Rectangle m_detectRect = new Rectangle();
        MulticlassSupportVectorMachine svm = null;
        bool isSetROi = false;

        public RoadSvm(string path, Rectangle believableRect)
        {
            svm = MulticlassSupportVectorMachine.Load(path);
            m_detectRect = believableRect;
            isSetROi = true;
        }
        public RoadSvm(string path)
        {
            svm = MulticlassSupportVectorMachine.Load(path);
            m_detectRect = new Rectangle(0,0,10000,10000);
        }

        public int Predict(VectorOfPoint vp)
        {
            Mat img = OpencvMath.GetSquareExampleImg(vp, m_svmSize);
            double[] array = extract(img);
            return svm.Compute(array, MulticlassComputeMethod.Elimination);
        }
        public int[] Predict(VectorOfVectorOfPoint vvp, bool[] usetag = null)
        {
            int cnt = vvp.Size;
            int[] result = new int[cnt];
            for (int i = 0; i < cnt; i++)
            {
                if (usetag != null && !usetag[i])
                    result[i] = -1;
                else
                {
                    var vp = vvp[i];
                    Point p = weightCentre(vp);
                    if (!isSetROi||pointInRectangle(m_detectRect, p))
                    {
                        result[i] = Predict(vp);
                    }else
                    {
                        result[i] = -1;
                    }
                }
            }
            return result;
        }

        Point weightCentre(VectorOfPoint vp)
        {
            var moment = CvInvoke.Moments(vp);
            return new Point((int)(moment.M10 / moment.M00), (int)(moment.M01 / moment.M00));
        }

        bool pointInRectangle(Rectangle rect, Point p)
        {
            return p.X > rect.Left && p.X < rect.Right && p.Y > rect.Top && p.Y < rect.Bottom;
        }


        double[] extract(Mat grayimg, int threshold = 30)
        {
            int width = grayimg.Size.Width, height = grayimg.Size.Height, step = grayimg.Step;
            int size = width * height;
            double[] result = new double[size];
            unsafe
            {
                byte* ptr = (byte*)grayimg.DataPointer;
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        result[i * step + j] = *(ptr + i * step + j) > threshold ? 1 : 0;
                    }
                }
            }

            return result;
        }
    }

    public class RoadDetect
    {
        private RoadTransform m_trans = null;// RoadTransform.Default;
        private PreProcess m_precess = null;// new PreProcess();
        private ContoursSegment m_contours = null;//= new ContoursSegment();
        private RoadSvm m_svm = null;
        private LaneDetect m_lane = null;// new LaneDetect();
        Settings m_config = Settings.Default;

        public RoadDetect(string svmDataPath)
        {
            int ow = m_config.OW, oh = m_config.OH;
            //Rectangle rect = new Rectangle(ow / 32 , oh / 8, ow / 16 * 15, oh / 32 * 27);
            m_trans = RoadTransform.Default;
            m_precess = new PreProcess();
            m_svm = new RoadSvm(svmDataPath);
            m_lane = new LaneDetect(new Size(ow,oh));
            m_contours = new ContoursSegment();
        }
        public VectorOfVectorOfPoint MainDetect(Mat roi,ref Mat segimg ,ref int[] labels , ref LineSegment2D[] lines)
        {
            bool[] usetag = null;
            Mat transimg = m_trans.ImgWarpPerspective(roi);
            double min = 0, max = 0;
            m_precess.RoadPreProcess(transimg, out min, out max);
            lines = m_lane.Detect(transimg);
            var vvp = m_contours.GetSelectContours(transimg, ref segimg, ref usetag);
            transimg.Dispose();
            labels = m_svm.Predict(vvp, usetag);
            return vvp;
        }
        public Point[][] GetOutputData(Mat orginimg, ref int[] labels, ref bool[] usetag, ref Point[][] linePts)
        {
            LineSegment2D[] lines = null;
            Mat segment = null;
            var result = MainDetect(orginimg, ref segment, ref labels, ref lines);

            if (lines == null || lines.Count() == 0)
                linePts = new Point[0][] { };
            else
                linePts = new Point[2][] { new Point[2] { lines[0].P1, lines[0].P2 }, new Point[2] { lines[1].P1, lines[1].P2 } };

            return result.ToArrayOfArray();
        }
        private double GetOffset(Mat imgroi, LineSegment2D[] lines_wrapInv, double verticalscaletop = 0, double verticalscalebottom = 0.95, bool isNeedDarwResult = true, int drawWidth = 1)
        {
            if (lines_wrapInv == null || lines_wrapInv.Count() != 2) return 404;

            int middleindex = (imgroi.Width - 1) / 2;
            int verticalvaluebottom = (int)(imgroi.Height * verticalscalebottom);
            int verticalvaluetop = (int)(imgroi.Height * verticalscaletop);
            Point cammid = new Point(middleindex, verticalvaluebottom);
            LineSegment2D lnleft = lines_wrapInv[0], lnright = lines_wrapInv[1];
            Point lpbuttpm = new Point((int)((double)(verticalvaluebottom - lnleft.P1.Y) / lnleft.Direction.Y * lnleft.Direction.X) + lnleft.P1.X, verticalvaluebottom);
            Point rpbuttom = new Point((int)((double)(verticalvaluebottom - lnright.P1.Y) / lnright.Direction.Y * lnright.Direction.X) + lnright.P1.X, verticalvaluebottom);
            Point lptop = new Point((int)((double)(verticalvaluetop - lnleft.P1.Y) / lnleft.Direction.Y * lnleft.Direction.X) + lnleft.P1.X, verticalvaluetop);
            Point rptop = new Point((int)((double)(verticalvaluetop - lnright.P1.Y) / lnright.Direction.Y * lnright.Direction.X) + lnright.P1.X, verticalvaluetop);
            Point midp = new Point((lpbuttpm.X + rpbuttom.X) / 2, verticalvaluebottom);
            Point midp2 = new Point((lptop.X + rptop.X) / 2, verticalvaluetop);
            double offset = (double)(middleindex - midp.X) / (rpbuttom.X - lpbuttpm.X) * 100;
            if (isNeedDarwResult)
            {
                Mat black = new Mat(imgroi.Size, DepthType.Cv8U, 3);
                black.SetTo(default(MCvScalar));
                MCvScalar linecol = new MCvScalar(0, 255, 255);
                MCvScalar resultlinescol = new MCvScalar(100, 100, 255);
                var vvp = new VectorOfVectorOfPoint(new Point[][] { new Point[] { lpbuttpm, rpbuttom, rptop, lptop, } });
                CvInvoke.DrawContours(black, vvp, -1, new MCvScalar(0, 50, 0), -1);
                CvInvoke.Line(black, lnleft.P1, lnleft.P2, linecol, drawWidth);
                CvInvoke.Line(black, lnright.P1, lnright.P2, linecol, drawWidth);
                CvInvoke.Line(black, midp, midp2, linecol, drawWidth);
                CvInvoke.ArrowedLine(black, midp, cammid, linecol, drawWidth);
                CvInvoke.Circle(black, lpbuttpm, 2, resultlinescol, -1);
                CvInvoke.Circle(black, rpbuttom, 2, resultlinescol, -1);
                CvInvoke.Circle(black, midp, 2, resultlinescol, -1);
                CvInvoke.PutText(black, string.Format("{0}%", offset.ToString("0.0")), midp, FontFace.HersheyComplex, 0.5, linecol, 1);
                Mat mask = new Mat();
                CvInvoke.CvtColor(black, mask, ColorConversion.Bgr2Gray);
                OpencvMath.MyAddWeight(imgroi, black, 0.5, mask);
            }

            return offset;
        }
        private void wrapLine(ref LineSegment2D ln)
        {
            PointF[] ptfs = new PointF[2] { new PointF(ln.P1.X, ln.P1.Y), new PointF(ln.P2.X, ln.P2.Y) };
            ptfs = m_trans.PointsWarpPerspectiveInv(ptfs);
            ln.P1 = new Point((int)ptfs[0].X, (int)ptfs[0].Y);
            ln.P2 = new Point((int)ptfs[1].X, (int)ptfs[1].Y);
        }
        MCvScalar getcolor(int lebel)
        {
            if (lebel >= 12)
                return new MCvScalar(127, 127, 127);
            else
            {
                int m = lebel / 3, n = lebel % 3;
                int b = 0, g = 0, r = 0;
                switch (n)
                {
                    case 0:
                        b = 256 * (4 - m) / 4 - 1;
                        g = 256 * m / 4 - 1;
                        r = 256 * m / 4 - 1;
                        break;
                    case 1:
                        g = 256 * (4 - m) / 4 - 1;
                        b = 256 * m / 4 - 1;
                        r = 256 * m / 4 - 1;
                        break;
                    case 2:
                        r = 256 * (4 - m) / 4 - 1;
                        b = 256 * m / 4 - 1;
                        g = 256 * m / 4 - 1;
                        break;
                }

                return new MCvScalar(b, g, r);
            }



        }
        private Mat SvmResultImg(Mat binaryimg, VectorOfVectorOfPoint vvp, int [] labels)
        {
            Mat black = new Mat();
            CvInvoke.CvtColor(binaryimg, black, ColorConversion.Gray2Bgr);
            for (int i = 0; i < vvp.Size; i++)
            {
                if (labels[i] != -1)
                {
                    CvInvoke.DrawContours(black, vvp, i, getcolor(labels[i]), -1);
                }
            }
            return black;
        }
        public Mat DetectAndShow(Mat imgsrc)
        {
            Mat img = imgsrc.Clone();
            Mat imgroi = new Mat(img, m_config.DetectArea);
            Mat imggray = OpencvMath.MyBgrToGray(imgroi);
            int[] lebels = null;
            bool[] usetag = null;
            LineSegment2D[] lines = null;
            Mat segmat = null;
            var vvp = MainDetect(imggray, ref segmat, ref lebels , ref lines);
            Mat svmresult = SvmResultImg(segmat, vvp, lebels);
            segmat.Dispose();
            Mat svmretran = m_trans.ImgWarpPerspectiveInv(svmresult);
            svmresult.Dispose();
            if (lines.Count() != 0)
            {
                wrapLine(ref lines[0]);
                wrapLine(ref lines[1]);
                double offset = GetOffset(svmretran, lines);
            }
            OpencvMath.MyAddWeight(imgroi, svmretran, 0.8);
            return img;
        }

        public void ReLoadParams()
        {
            m_trans.LoadSetting();
            m_trans.LoadSetting();
            m_lane.LoadSetting();
            m_contours.LoadSetting();
        }
    }
}
