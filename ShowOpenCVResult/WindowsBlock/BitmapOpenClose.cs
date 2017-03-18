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
    public partial class BitmapOpenClose : MoveBlock
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
        public BitmapOpenClose()
        {
            InitializeComponent();
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
            
            //imageIOControl1.OutputImage = GclrOpencvProces.BitmapGetOpenCloseImg(imageIOControl1.InputImage as Bitmap, m_isOpen, myTrackBar1.Value);
            int size = (int)myTrackBar1.Value;
            Image<Bgr, Byte> img = new Image<Bgr, byte>(imageIOControl1.Image1.Size);
            Mat element = CvInvoke.GetStructuringElement(ElementShape.Rectangle,new Size(2*size+1,2*size+1),new Point(1+size,1+size) );
            if (!IsOpen)
            {
                CvInvoke.Erode(imageIOControl1.Image1, img, element, new Point(), 1, BorderType.Default, new MCvScalar(1, 2));
            }
            else {
                CvInvoke.Dilate(imageIOControl1.Image1, img, element, new Point(), 1, BorderType.Default, new MCvScalar(1, 2));
            }
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

    }
}
