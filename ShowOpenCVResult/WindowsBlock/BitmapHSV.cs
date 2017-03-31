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
    public partial class BitmapHSV : MoveBlock
    {
        public BitmapHSV()
        {
            InitializeComponent();
        }

        private void tsbtnOpenImg_Click(object sender, EventArgs e)
        {
            string img = OpencvForm.SelectImg();
            if(img == null ) return;
            imageIOControl1.SetInput(new Image<Bgr, Byte>(img));

        }

        private void myTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            imageIOControl1.DoChange();
        }

        private void drawImageBox1_DragDrop(object sender, DragEventArgs e)
        {
            myTrackBar1_ValueChanged(null, null);
        }

        private void imageIOControl1_DoImgChange(object sender, EventArgs e)
        {
            if (imageIOControl1.Image1 == null) return;
            if (imageIOControl1.Image2 != null) imageIOControl1.Image2.Dispose();
            var imghsv = (imageIOControl1.Image1 as Image<Bgr, byte>).Convert<Hsv, byte>();

            imageIOControl1.Image2 = imghsv.Split()[(int)numericUpDown1.Value];


        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            imageIOControl1.DoChange();
        }
    }
}
