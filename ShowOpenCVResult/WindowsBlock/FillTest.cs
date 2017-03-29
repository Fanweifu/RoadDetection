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
    public partial class FillTest : MoveBlock
    {
        public FillTest()
        {
            InitializeComponent();
        }

        Rectangle rc = new Rectangle();
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var img = OpencvForm.GetImage();
            if (img != null)
            {
                imageIO1.SetInput(img);
            }
        }

        private void imageIO1_DoImgChange(object sender, EventArgs e)
        {
            if (imageIO1.Image1 == null) return;
            var imgbgr = imageIO1.Image1 as Image<Bgr, byte>;
            var imggray = imgbgr.Convert<Gray, byte>();
          
            MCvScalar low = new MCvScalar((int)numericUpDown3.Value/*, (int)numericUpDown4.Value, (int)numericUpDown5.Value*/), high = new MCvScalar((int)numericUpDown6.Value/*, (int)numericUpDown7.Value, (int)numericUpDown8.Value*/);
            
            CvInvoke.FloodFill(imggray, null, new Point((int)numericUpDown1.Value, (int)numericUpDown2.Value), new MCvScalar(255, 0, 0), out rc, low, high, Emgu.CV.CvEnum.Connectivity.FourConnected, (Emgu.CV.CvEnum.FloodFillType)comboBox1.SelectedItem);
            CvInvoke.Rectangle(imggray, rc, new MCvScalar(0, 255, 0));
            if (imageIO1.Image2 != null)
            {
                imageIO1.Image2.Dispose();
            }

            imageIO1.Image2 = imggray;


        }

        private void FillTest_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = Enum.GetValues(typeof(Emgu.CV.CvEnum.FloodFillType));
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            imageIO1.DoChange();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            imageIO1.DoChange();
        }
    }
}
