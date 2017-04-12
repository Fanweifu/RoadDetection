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

namespace ShowOpenCVResult
{
    public partial class HarrisTest : MoveBlock
    {
        public HarrisTest()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var img = OpencvForm.GetImage() as Image<Bgr, Byte>;
            if (img == null) return;
            var img2 = img.SmoothMedian(11);
             imageIOControl1.SetInput (img2);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
         
        }

        private void imageIOControl1_DoImgChange(object sender, EventArgs e)
        {
            if (imageIOControl1.Image1 == null) return;
            Image<Gray,Byte> img = (imageIOControl1.Image1 as Image<Bgr,Byte>).Convert<Gray,Byte>();

            Harris hs = new Harris();
            hs.detect(img);
            VectorOfPoint vp = new VectorOfPoint();
            hs.GetCorners(vp, 0.3);
            Mat img2 = img.Mat.Clone();
            hs.DrawOnImage(img2, vp, new MCvScalar(255, 255, 255));
            imageIOControl1.Image2 = img2;
        }
    }
}
