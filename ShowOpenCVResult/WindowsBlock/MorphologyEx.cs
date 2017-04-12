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
            if (imageIOControl1.Image1 == null) return;
            if (imageIOControl1.Image2 != null) { imageIOControl1.Image2.Dispose(); }

            int size = (int)myTrackBar1.Value;
            Image<Bgr, Byte> img = new Image<Bgr, byte>(imageIOControl1.Image1.Size);
            Mat element = CvInvoke.GetStructuringElement(ElementShape.Rectangle,new Size(2*size+1,2*size+1),new Point(-1,-1));
            CvInvoke.MorphologyEx(imageIOControl1.Image1 as Image<Bgr, byte>, img, (MorphOp)comboBox1.SelectedItem, element, new Point(-1, -1), (int)numericUpDown1.Value, BorderType.Default, new MCvScalar(0));  

            imageIOControl1.Image2 = img;
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
    }
}
