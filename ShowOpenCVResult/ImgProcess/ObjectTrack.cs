using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace ShowOpenCVResult.ImgProcess
{
    public class ObjectTrack
    {
        bool m_isInDetect = false;
        int m_detectnum = 0;
        Size m_size = default(Size);
        Rectangle m_startrect = default(Rectangle);
        Rectangle m_currect = default(Rectangle);
        RotatedRect m_rrect = default(RotatedRect);
        Mat lastimg = null;
        MCvTermCriteria m_criteria = new MCvTermCriteria(100, 0.01);

        public bool IsInDetect
        {
            get
            {
                return m_isInDetect;
            }
        }

        /// <summary>
        /// 追踪对象构造函数
        /// </summary>
        /// <param name="size">图像第一帧</param>
        /// <param name="beginrect">物体在第一帧所在位置,即包含检测物体的矩阵</param>
        public ObjectTrack()
        {

        }
        public ObjectTrack(Rectangle beginrect, Bitmap firstmap)
        {
            lastimg = new Image<Bgr, byte>(firstmap).Mat;
            SetData(beginrect, lastimg);
        }

        public ObjectTrack(Rectangle beginrect, Mat firstmap)
        {
            SetData(beginrect, lastimg);
        }

        public void SetData(Rectangle beginrect, Mat img)
        {
            lastimg = img;
            m_size = img.Size;
            m_startrect = beginrect;
            m_currect = m_startrect;
            m_isInDetect = true;
        }


        Image<Gray, byte> getHimg(Mat img,int chnindex =1)
        {
            Mat hsvmat = new Mat();
            CvInvoke.CvtColor(img, hsvmat, ColorConversion.Bgr2Hsv);
            VectorOfMat vm = new VectorOfMat();
            CvInvoke.Split(hsvmat, vm);
            var hmat = vm[chnindex].Clone();
            vm.Dispose();
            hsvmat.Dispose();
            return hmat.ToImage<Gray, byte>();
        }

        bool judgeRectInSize(Size size, Rectangle rect)
        {
            return rect.X >= 0 && rect.X + rect.Width < size.Width && rect.Y >= 0 && rect.Y + rect.Height < size.Height;
        }

        Rectangle getrectfromRectangle(RotatedRect rr)
        {
            double area = rr.Size.Height * rr.Size.Width;
            int length = (int)Math.Sqrt(area) / 4 * 3;
            return new Rectangle(new Point((int)rr.Center.X - length / 2, (int)rr.Center.Y - length / 2), new Size(length, length));
        }

        public Rectangle Track(Mat orimg ,int index =1,int stopsize =3)
        {
            if (lastimg == null || lastimg.IsEmpty || lastimg.NumberOfChannels != 3
                || orimg == null || orimg.IsEmpty || orimg.NumberOfChannels != 3
            ) return m_currect;
            if (!judgeRectInSize(orimg.Size, m_currect)||m_currect.Size.Height<stopsize|| m_currect.Size.Width < stopsize)
            {
                Reset();
                return m_currect;
            }

            Mat dataimg = orimg.Clone();
            
            Mat matroi = new Mat(lastimg, m_currect);
            var himg = getHimg(matroi, index);

            DenseHistogram dh = new DenseHistogram(256, new RangeF(0, 255));
            dh.Calculate(new Image<Gray, byte>[] { himg }, false, null);
            var curh = getHimg(dataimg, index);
            var bpimg = dh.BackProject(new Image<Gray, byte>[] { curh });

            //int[] bins = new int[] { 181, 256, 256 };
            //RangeF[] ranges = new RangeF[] { new RangeF(0, 180), new RangeF(0, 255), new RangeF(0, 255) };
            //DenseHistogram dh = new DenseHistogram(bins, ranges);
            //dh.Calculate(matroi.ToImage<Bgr,byte>().Convert<Hsv,byte>().Split(), false, null);
            //var curh = getHimg(curimg);
            //var bpimg = dh.BackProject((curimg.ToImage<Bgr, byte>().Convert<Hsv, byte>().Split()));

            m_rrect = CvInvoke.CamShift(bpimg, ref m_currect, m_criteria);
            m_currect = getrectfromRectangle(m_rrect);

            //CvInvoke.MeanShift(bpimg, ref m_currect, m_criteria);
            lastimg.Dispose();
            lastimg = dataimg;
            return m_currect;
        }

        /// <summary>
        /// 获取当前帧物体所在位置
        /// </summary>
        /// <param name="curmap">当前帧图像</param>
        /// <returns>包含物体的矩形</returns>
        public Rectangle Track(Bitmap curmap)
        {
            var curimg = new Image<Bgr, byte>(curmap).Mat;
            return Track(curimg);
        }

        public Mat DrawRectangle(MCvScalar color)
        {
            var imgblack = lastimg.Clone();
            CvInvoke.Rectangle(imgblack, m_currect, color, 2);
            if (!m_rrect.Equals(default(RotatedRect)))
                CvInvoke.Polylines(imgblack, Array.ConvertAll<PointF, Point>(m_rrect.GetVertices(), Point.Round), true, new MCvScalar(0, 0, 255), 2);
            return imgblack;
        }
        /// <summary>
        /// 按照一定颜色绘制检测结果
        /// </summary>
        /// <param name="b">B 通道</param>
        /// <param name="g">G 通道</param>
        /// <param name="r">R 通道</param>
        /// <returns></returns>

        public Bitmap DrawRectangle(int b = 0, int g = 255, int r = 255)
        {
            return DrawRectangle(new MCvScalar(b, g, r)).Bitmap;
        }

        public void Reset()
        {
            m_startrect = default(Rectangle);
            m_currect = default(Rectangle);
            m_rrect = default(RotatedRect);
            m_detectnum = 0;
            m_isInDetect = false;
        }
    }
}
