using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace ShowOpenCVResult
{
    public partial class FinalTest : MoveBlock
    {
        public FinalTest()
        {
            InitializeComponent();
        }



        public Point FindLoadSeedPoint(Image<Gray, Byte> img ,double xscale =0.5, double yscale = 0.95) {
            Point p = new Point((int)(img.Size.Width * xscale), (int)(img.Size.Height * yscale));
            int distance = img.Size.Width / 20, tims = 0;
            while (img[p.Y,p.X].Intensity>150) {
                tims++;
                p.X += (tims % 2 == 1 ? -1 : 1) * distance;
                distance += 5;
            }
            return p;
        }
            
        private void imageIO1_DoImgChange(object sender, EventArgs e)
        {
            if (imageIO1.Image1 == null) return;

            var img = imageIO1.Image1 as Image<Bgr, Byte>;
            var imggray = img.Convert<Gray, byte>();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            var imgblur = imggray.SmoothMedian(9);
            Image<Gray, Byte> line =null , unroad =null;
            BaseFunc.GetSplitRoadImg(imgblur,ref line,ref unroad);
            Rectangle rect = new Rectangle(100,100,100,100);
            int nums = CvInvoke.FloodFill(imgblur, null, FindLoadSeedPoint(imgblur), new MCvScalar(0), out rect, new MCvScalar(3), new MCvScalar(2), Emgu.CV.CvEnum.Connectivity.FourConnected, Emgu.CV.CvEnum.FloodFillType.Default);
            if (nums < imgblur.Size.Width * imgblur.Size.Height / 10) {
                nums = CvInvoke.FloodFill(imgblur, null, FindLoadSeedPoint(imgblur,0.3), new MCvScalar(0), out rect, new MCvScalar(3), new MCvScalar(2));
            }

            if (imageIO1.Image2!=null)
            {
                imageIO1.Image2.Dispose();
            }
            var result = line & imgblur;
            CvInvoke.Threshold(result, result,150, 255, Emgu.CV.CvEnum.ThresholdType.Binary);
            sw.Stop();

            imageIO1.Image2 = result;

            MessageBox.Show(string.Format("耗时{0}毫秒", sw.ElapsedMilliseconds));
        }



        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var img = OpencvForm.GetImage();
            if (img == null) return;

            imageIO1.SetInput(img);
        }

        private void myTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            imageIO1.DoChange();
        }

        private void imageIO1_AfterImgLoaded(object sender, EventArgs e)
        {
           
        }
    }
}
