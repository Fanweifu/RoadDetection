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


            
        private void imageIO1_DoImgChange(object sender, EventArgs e)
        {
            if (imageIO1.Image1 == null) return;

            var img = imageIO1.Image1 as Image<Bgr, Byte>;
            var imggray = img.Convert<Gray, byte>();
            var imgblur = imggray.SmoothMedian(5);
            Image<Gray, Byte> line =null , road =null;
            BaseFunc.GetSplitRoadImg(imgblur,ref line,ref road);

            if (imageIO1.Image2!=null)
            {
                imageIO1.Image2.Dispose();
            }
            imageIO1.Image2 = line| road;
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
