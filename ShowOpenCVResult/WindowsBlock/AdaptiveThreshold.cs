using Emgu.CV;
using Emgu.CV.CvEnum;
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
    public partial class AdaptiveThreshold : MoveBlock
    {
        public AdaptiveThreshold()
        {
            InitializeComponent();
        }

        private void tsbtnOpen_Click(object sender, EventArgs e)
        {
            string path = OpencvForm.SelectImg();
            if(path!=null)
                imageIOControl1.SetInput(new Image<Bgr, byte>(path));
        }

        private void imageIOControl1_DoImgChange(object sender, EventArgs e)
        {
            if (imageIOControl1.Image1 == null) return;
            if (imageIOControl1.Image2 != null) imageIOControl1.Image2.Dispose();
            Image<Gray, Byte> img = (imageIOControl1.Image1 as Image<Bgr, Byte>).Convert<Gray, Byte>();
           
            CvInvoke.AdaptiveThreshold(img, img, 255, (radioButton1.Checked ? AdaptiveThresholdType.GaussianC : AdaptiveThresholdType.MeanC),ThresholdType.Binary, 2 * myTrackBar1.Value + 1, (double)myTrackBar2.Value);
            imageIOControl1.Image2 = img;
        }

        private void myTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            imageIOControl1.DoChange();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            imageIOControl1.DoChange();
        } 
    }
}
