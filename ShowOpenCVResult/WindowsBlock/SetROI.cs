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
    public partial class SetROI : MoveBlock
    {
        public SetROI()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            IImage img = OpencvForm.GetImage();
            if (img == null) return;
            imageIO1.SetInput(img);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var config = Properties.Settings.Default;
            config.DetectArea = new Rectangle(new Point((int)numericUpDown1.Value, (int)numericUpDown2.Value), new Size((int)numericUpDown3.Value, (int)numericUpDown4.Value));
            config.Save();
        }

        private void imageIO1_DoImgChange(object sender, EventArgs e)
        {
            var img = imageIO1.Image1 as Image<Bgr, byte>;
            if (img == null) return;
            int x = (int)numericUpDown1.Value, y = (int)numericUpDown2.Value, w = (int)numericUpDown3.Value, h = (int)numericUpDown4.Value;
            if (x + w > img.Width || y + h > img.Height)  return;

            Mat roi = new Mat(img.Mat, new Rectangle(new Point(x, y), new Size(w, h))).Clone();

            if (imageIO1.Image2 != null)
                imageIO1.Image2.Dispose();
            imageIO1.Image2 = roi;            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            imageIO1.DoChange();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            imageIO1.DoChange();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            imageIO1.DoChange();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            imageIO1.DoChange();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var config = Properties.Settings.Default;
            numericUpDown1.Maximum = numericUpDown3.Maximum = config.InputWidth;
            numericUpDown2.Maximum = numericUpDown4.Maximum = config.InputHeigth;
            numericUpDown1.Value = config.DetectArea.X;
            numericUpDown2.Value = config.DetectArea.Y;
            numericUpDown3.Value = config.DetectArea.Width;
            numericUpDown4.Value = config.DetectArea.Height;
        }

        private void imageIO1_AfterImgLoaded(object sender, EventArgs e)
        {
            var img = imageIO1.Image1 as Image<Bgr, byte>;
            if (img == null) return;
            numericUpDown1.Maximum = numericUpDown3.Maximum = img.Width;
            numericUpDown2.Maximum = numericUpDown4.Maximum = img.Height;
            
        }
    }
}
