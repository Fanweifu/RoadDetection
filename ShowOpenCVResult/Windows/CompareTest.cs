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
    public partial class CompareTest : MoveBlock
    {
        public CompareTest()
        {
            InitializeComponent();
        }

        Point[] pts = new Point[3] { new Point(10, 10), new Point(20, 10), new Point(10, 20) };


   
        

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Image<Bgr, byte> img = OpencvForm.GetImage() as Image<Bgr, byte>;
            if (img == null) return;
            drawImageBox1.Image = img;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Image<Bgr, byte> img = OpencvForm.GetImage() as Image<Bgr, byte>;
            if (img == null) return;
            drawImageBox3.Image = img;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Rectangle outr = new Rectangle();
            Mat[] mats =ContentFinder.Find((drawImageBox1.Image as Image<Bgr, byte>).Mat, (drawImageBox3.Image as Image<Bgr, byte>).Mat, new Rectangle(337, 140, 140, 213),ref outr,(int)numericUpDown1.Value,(double)numericUpDown2.Value);
            if (mats == null) return;
            drawImageBox2.Image = mats[0];
            drawImageBox4.Image = mats[1];
        }

        
    }
}
