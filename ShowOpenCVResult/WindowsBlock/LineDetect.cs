using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace ShowOpenCVResult
{
    public partial class LineDetect : MoveBlock
    {
        public LineDetect()
        {
            InitializeComponent();
        }

        Mat gray = new Mat();

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            IImage img = OpencvForm.GetImage();
            if (img == null) return;
            imageIO1.SetInput(img);
        }

        private void imageIO1_AfterImgLoaded(object sender, EventArgs e)
        {
            if (imageIO1.Image1 == null) return;

            gray = (imageIO1.Image1 as Image<Bgr, byte>).Split()[2].Mat.Clone();
            
        }

        private void imageIO1_DoImgChange(object sender, EventArgs e)
        {
            if (gray == null) return;
            if (imageIO1.Image2 != null) imageIO1.Image2.Dispose();
            imageIO1.Image2 = OpencvMath.RoadLineDetect(gray, myTrackBar1.Value, (byte)myTrackBar2.Value,comboBox1.SelectedIndex<1);
        }

        private void myTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            imageIO1.DoChange();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            imageIO1.DoChange();
        }
    }
}
