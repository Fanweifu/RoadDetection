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

namespace ShowOpenCVResult
{
    public partial class FinalTest : MoveBlock
    {
        public FinalTest()
        {
            InitializeComponent();
        }

        Image<Gray, float> imgweight;

            
        private void imageIO1_DoImgChange(object sender, EventArgs e)
        {
            if (imgweight == null) return;
            var result = new Image<Gray, float>(imgweight.Size);
            CvInvoke.Normalize(imgweight, result);
            CvInvoke.Threshold(result, result,(double) myTrackBar1.Value/100,255, Emgu.CV.CvEnum.ThresholdType.Binary);
            if (imageIO1.Image2!=null)
            {
                imageIO1.Image2.Dispose();
            }
            imageIO1.Image2 = result;
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
            if (imageIO1.Image1 == null) return;
            var img = imageIO1.Image1 as Image<Bgr, Byte>;
            var imggray = img.Convert<Gray, Byte>();
            var imgblur = imggray.SmoothBilatral(20, 40, 10);
            imgblur._EqualizeHist();
            imgweight = imgblur.Sobel(1, 0, 3).AddWeighted(imgblur.Sobel(0, 1, 3), 0.5, 0.5, 0);
        }
    }
}
