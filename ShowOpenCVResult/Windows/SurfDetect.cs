using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShowOpenCVResult.Windows
{
    public partial class SurfDetect : MoveBlock
    {
        Image<Bgr, Byte> imgModel;
        Image<Bgr, Byte> imgObsever;
        Image<Bgr, Byte> imgModelPts;
        Image<Bgr, Byte> imgObseverPts;
        Image<Bgr, Byte> imgModelPt;
        Image<Bgr, Byte> imgObseverPt;
        VectorOfKeyPoint mp;
        VectorOfKeyPoint op;
        public SurfDetect()
        {
            InitializeComponent();
        }

        private void SuftDetect_Load(object sender, EventArgs e)
        {
            #region PtrTest

            Image<Bgr, byte> imgimg = new Image<Bgr, byte>(new Size(2, 2));
            imgimg[0, 0] = new Bgr(0,0,0);
            imgimg[0, 1] = new Bgr(1,11,111);
            imgimg[1, 0] = new Bgr(2,22,222);
            imgimg[1, 1] = new Bgr(3,33,250);
            Mat img = imgimg.Mat;
            int w = img.Width, h = img.Width, step = img.Step, chs = img.NumberOfChannels;
            unsafe {
                byte* pt = (byte*)img.DataPointer;
                for (int i = 0; i <h; i++) {
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
            
            #endregion

            #region POVIMGCREAT

            //double radius = 20;
            //int offset = 100;
            //Image<Bgr, Byte> img1 = new Image<Bgr, byte>(2000, 1000);
            //Image<Bgr, Byte> img2 = new Image<Bgr, byte>(2000, 1000);
            //Image<Bgr, Byte> img3 = new Image<Bgr, byte>(2000, 1000);
            //CvInvoke.Circle(img1, new Point(750, 500), (int)(radius / Math.Sqrt(2)), new MCvScalar(255, 255, 255), -1);
            //CvInvoke.Circle(img1, new Point(1250, 500), (int)(radius / Math.Sqrt(2)), new MCvScalar(255, 0, 255), -1);
            //CvInvoke.Circle(img2, new Point(500, 500), (int)radius, new MCvScalar(255, 255, 255), -1);
            //CvInvoke.Circle(img2, new Point(1500, 500), (int)radius, new MCvScalar(255, 0, 255), -1);
            //CvInvoke.Circle(img3, new Point(250, 500), (int)(radius / Math.Sqrt(2)), new MCvScalar(255, 255, 255), -1);
            //CvInvoke.Circle(img3, new Point(1750, 500), (int)(radius / Math.Sqrt(2)), new MCvScalar(255, 0, 255), -1);
            //for (int i = 0; i <= 10; i++) {
            //    CvInvoke.Line(img1, new Point(0, i * offset), new Point(2000, i * offset), new MCvScalar(0, 255, 255));
            //    CvInvoke.Line(img2, new Point(0, i * offset), new Point(2000, i * offset), new MCvScalar(0, 255, 255));
            //    CvInvoke.Line(img3, new Point(0, i * offset), new Point(2000, i * offset), new MCvScalar(0, 255, 255));
            //}
            //offset = 9;
            //for (int i = 0; i < 10; i++) {
            //    if (i == 5) continue;
            //    CvInvoke.Line(img1, new Point(0, 500 + (i - 5) * offset), new Point(2000, 500 + (i - 5) * offset), new MCvScalar(255, 0, 255));
            //    CvInvoke.Line(img2, new Point(0, 500 + (i - 5) * offset), new Point(2000, 500 + (i - 5) * offset), new MCvScalar(255, 0, 255));
            //    CvInvoke.Line(img3, new Point(0, 500 + (i - 5) * offset), new Point(2000, 500 + (i - 5) * offset), new MCvScalar(255, 0, 255));

            //}

            //    img1.Save(@"E:\Users\fwf\Desktop\全景测量数据\全景测试材料\Img\ladybug_Panoramic_3500x1750_00000000.jpg");
            //img2.Save(@"E:\Users\fwf\Desktop\全景测量数据\全景测试材料\Img\ladybug_Panoramic_3500x1750_00000001.jpg");
            //img3.Save(@"E:\Users\fwf\Desktop\全景测量数据\全景测试材料\Img\ladybug_Panoramic_3500x1750_00000002.jpg");
            #endregion

            
        }

        private void tsbtnOpenImg1_Click(object sender, EventArgs e)
        {

            IImage img = OpencvForm.GetImage();
            if (img as Image<Bgr, Byte> == null) return;
            imgModel = img as Image<Bgr, Byte>;
            drawImageBox1.Image = img;
        }

        private void tsbtnOpenIma2_Click(object sender, EventArgs e)
        {
            IImage img = OpencvForm.GetImage();
            if (img as Image<Bgr, Byte> == null) return;
            imgObsever = img as Image<Bgr, Byte>;
            drawImageBox2.Image = img;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (imgModel == null || imgObsever == null) return;
            long time = 0;
            imgModelPts = imgModel.Clone();
            imgObseverPts = imgObsever.Clone();
            Mat result = DrawMatches.Draw(imgModelPts.Mat, imgObseverPts.Mat, out time, out mp, out op);
            drawImageBox3.Image = result;
            drawImageBox1.Image = imgModelPts;
            drawImageBox2.Image = imgObseverPts;
        }



        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            drawImageBox1.Image = imgModel;
            drawImageBox2.Image = imgObsever;
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            drawImageBox1.Image = imgModelPt;
            drawImageBox2.Image = imgObseverPt;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            drawImageBox1.Image = imgModelPts;
            drawImageBox2.Image = imgObseverPts;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (mp != null && numericUpDown1.Value >= 0 && numericUpDown1.Value < mp.Size)
            {
                PointF pf = mp[(int)numericUpDown1.Value].Point;
                Point p = new Point((int)pf.X, (int)pf.Y);
                var c = imgModelPts.Clone();
                CvInvoke.Circle(c, p, 5, new MCvScalar(255, 255, 255), -1);
                if (imgModelPt != null)
                {
                    imgModelPt.Dispose();
                }
                imgModelPt = c;
                drawImageBox1.Image = imgModelPt;
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (op != null && numericUpDown2.Value >= 0 && numericUpDown2.Value < op.Size)
            {
                PointF pf = op[(int)numericUpDown2.Value].Point;
                Point p = new Point((int)pf.X, (int)pf.Y);
                var c = imgObseverPts.Clone();
                CvInvoke.Circle(c, p, 5, new MCvScalar(255, 255, 255), -1);
                if (imgObseverPt != null)
                {
                    imgObseverPt.Dispose();
                }
                imgObseverPt = c;
                drawImageBox2.Image = imgObseverPt;
            }
        }



    }
}
