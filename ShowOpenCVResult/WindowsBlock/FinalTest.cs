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
using Emgu.CV.CvEnum;

namespace ShowOpenCVResult
{
    public partial class FinalTest : MoveBlock
    {
        public FinalTest()
        {
            InitializeComponent();
        }


            
        private void imageIO1_DoImgChange(object sender, EventArgs e)
        {
            if (imageIO1.Image1 == null) return;

            var img = imageIO1.Image1 as Image<Bgr, Byte>;
            var imggray = img.Convert<Hsv, byte>().Split()[2];
            
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var unroad = OpencvMath.GetBlindnessMask(imggray);
            var processimg = OpencvMath.RoadPreProcess(imggray, unroad,2);
            var line = OpencvMath.GetLine(processimg);

            Rectangle rect = new Rectangle(100,100,100,100);
            var processclone = processimg.Clone();
            int nums = CvInvoke.FloodFill(processclone, null,  OpencvMath.FindSeedPointToFill(processimg), new MCvScalar(0), out rect, new MCvScalar(3), new MCvScalar(2), Emgu.CV.CvEnum.Connectivity.FourConnected, Emgu.CV.CvEnum.FloodFillType.Default);
            if (nums < processimg.Size.Width * processimg.Size.Height / 10)
            {
                processclone.Dispose();
                nums = CvInvoke.FloodFill(processimg, null, OpencvMath.FindSeedPointToFill(processimg, 0.3), new MCvScalar(0), out rect, new MCvScalar(3), new MCvScalar(2));
            }
            else {
                processimg.Dispose();
                processimg = processclone;
            }

            var result = line & processimg;
            line.Dispose();
            processimg.Dispose();
            CvInvoke.Threshold(result, result, 135, 255, ThresholdType.Binary);
            CvInvoke.Threshold(result, result,140, 255, Emgu.CV.CvEnum.ThresholdType.Binary);
            CvInvoke.MorphologyEx(result, result, MorphOp.Close, CvInvoke.GetStructuringElement(ElementShape.Cross, new Size(5, 5), new Point(-1, -1)), new Point(-1, -1), 1, BorderType.Default, new MCvScalar(0));
            var imgresult = new Image<Bgr, byte>(img.Size);
            img.Copy(imgresult, result);
            result.Dispose();


            sw.Stop();

            if (imageIO1.Image2 != null)
            {
                imageIO1.Image2.Dispose();
            }

            imageIO1.Image2 = imgresult;

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
