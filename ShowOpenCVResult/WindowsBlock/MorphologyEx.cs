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
    public partial class MorphologyEx : MoveBlock
    {
        private bool m_isOpen = true;
        public bool IsOpen
        {
            get { return m_isOpen; }
            set
            {
                bool changed = m_isOpen != value;
                m_isOpen = value;
                if (changed)
                    imageIOControl1.DoChange();
            }
        }
        public MorphologyEx()
        {  
            InitializeComponent();
            comboBox1.DataSource = Enum.GetValues(typeof(MorphOp));
            comboBox2.DataSource = Enum.GetValues(typeof(ElementShape));
        }

        private void rbtnBoxBlur_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tsbtnOpenImg_Click(object sender, EventArgs e)
        {
            string imgpath = OpencvForm.SelectImg();
            if (imgpath == null) return;
            imageIOControl1.SetInput(new Image<Bgr, Byte>(imgpath));
        }

        private void imageIOControl1_DoImgChange(object sender, EventArgs e)
        {
            if (imageIOControl1.InImage == null) return;
            
            int x = mybarX.Value;
            int y = mybarY.Value;
            Image<Bgr, Byte> img = new Image<Bgr, byte>(imageIOControl1.InImage.Size);
            Mat element = CvInvoke.GetStructuringElement((ElementShape)comboBox2.SelectedItem, new Size(2 * x + 1, 2 * y + 1), new Point(-1, -1));
            CvInvoke.MorphologyEx(imageIOControl1.InImage as Image<Bgr, byte>, img, (MorphOp)comboBox1.SelectedItem, element, new Point(-1, -1), (int)numericUpDown1.Value, BorderType.Default, new MCvScalar(0));  

            imageIOControl1.OutImage = img;
        }

        private void myTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            imageIOControl1.DoChange();
        }

        private void rbtnBoxBlur_Click(object sender, EventArgs e)
        {
            IsOpen = true;
        }

        private void rbtnBlur_Click(object sender, EventArgs e)
        {
            IsOpen = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            imageIOControl1.DoChange();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            imageIOControl1.DoChange();
        }

        private void MorphologyEx_Load(object sender, EventArgs e)
        {

        }
    }
}
