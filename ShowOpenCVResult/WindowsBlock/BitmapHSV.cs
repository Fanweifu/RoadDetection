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
            //Image<Hsv, byte> hsvimg = (imageIOControl1.Image1 as Image<Bgr, Byte>).Convert<Hsv, Byte>();
            //Hsv threshold = new Hsv(0, myTrackBar1.Value, myTrackBar2.Value);
            //Image<Hsv, byte> result1 = hsvimg.ThresholdToZero(threshold);
            //Image<Hsv, byte> result2 = hsvimg.ThresholdBinaryInv(new Hsv(0, 0, 40), new Hsv(0, 0, 255));
            //imageIOControl1.Image2 = result1|result2;
            Image<Gray, byte> grayimg = (imageIOControl1.Image1 as Image<Bgr, Byte>).Convert<Gray, Byte>();
            Image<Gray, byte> line = null, road = null;
             BaseFunc.GetSplitRoadImg(grayimg,ref line,ref road);
            imageIOControl1.Image2 = line | road;


        }

    }
}
