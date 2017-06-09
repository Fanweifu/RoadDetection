using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace ShowOpenCVResult.Windows
{
    public partial class HSVRangeTest : MoveBlock
    {
        public HSVRangeTest()
        {
            InitializeComponent();
           
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            IImage img = OpencvForm.GetImage();
            if (img == null) return;
            imageIO1.SetInput(img);
        }

        private void imageIO1_DoImgChange(object sender, EventArgs e)
        {
            if (imageIO1.InImage == null) return;
            if (sminbar.Value > smaxbar.Value || vminbar.Value > vmaxbar.Value) return;

            var img = (imageIO1.InImage as Image<Bgr, byte>).Mat;
            Mat hsvreshold = OpencvMath.HsvThreshold(img, hminbar.Value, sminbar.Value, vminbar.Value, hmaxbar.Value, smaxbar.Value, vmaxbar.Value, true);
            

            
            imageIO1.OutImage = hsvreshold;


        }

        private void hmaxbar_ValueChanged(object sender, EventArgs e)
        {
            imageIO1.DoChange();
        }

        private void hminbar_ValueChanged(object sender, EventArgs e)
        {
            imageIO1.DoChange();
        }

        private void sminbar_ValueChanged(object sender, EventArgs e)
        {
            imageIO1.DoChange();
        }

        private void smaxbar_ValueChanged(object sender, EventArgs e)
        {
            imageIO1.DoChange();
        }

        private void vminbar_ValueChanged(object sender, EventArgs e)
        {
            imageIO1.DoChange();
        }

        private void vmaxbar_ValueChanged(object sender, EventArgs e)
        {
            imageIO1.DoChange();
        }
    }
}
