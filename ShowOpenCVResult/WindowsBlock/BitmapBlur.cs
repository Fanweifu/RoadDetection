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
    public partial class BitmapBlur : MoveBlock
    {
        int m_blurID = 0;

        public int BlurID
        {
            get { return m_blurID; }
            set {
                bool changed = m_blurID != value;
                m_blurID = value;
                if(changed)
                    imageIOControl1.DoChange();
            }
        }
        public BitmapBlur()
        {
            InitializeComponent();
        }


        private void tsbtnOpenImg_Click(object sender, EventArgs e)
        {
            string imgpath = OpencvForm.SelectImg();
            if (imgpath == null) return;
            imageIOControl1.SetInput(new Image<Bgr, Byte>(imgpath));

        }

        private void imageIOControl1_DoImgChange(object sender, EventArgs e)
        {

            if (myTrackBar1.Value == 0) return;
            if (imageIOControl1.Image1 == null) return;
            if (imageIOControl1.Image2 != null) imageIOControl1.Image2.Dispose();
            int kernalsize = (int)myTrackBar1.Value;

            Image<Bgr, Byte> image = new Image<Bgr, byte>(imageIOControl1.Image1.Size);//imageIOControl1.OutputImage as Image<Bgr, Byte>;
            //imageIOControl1.OutputImage = GclrOpencvProces.BitmapGetBlurImg(imageIOControl1.InputImage as Bitmap,m_blurID, myTrackBar1.Value);
            switch (BlurID)
            {
                case 0:
                    CvInvoke.BoxFilter(imageIOControl1.Image1, image, Emgu.CV.CvEnum.DepthType.Default, new Size(2 * kernalsize + 1, 2 * kernalsize + 1), new Point(-1, -1));
                    break;
                case 1:
                    CvInvoke.Blur(imageIOControl1.Image1,  image, new Size(2 * kernalsize + 1, 2 * kernalsize + 1), new Point(-1, -1));
                    break;
                case 2:
                    CvInvoke.GaussianBlur(imageIOControl1.Image1, image, new Size(2 * kernalsize + 1, 2 * kernalsize + 1),0,0);
                    break;
                case 3:
                    CvInvoke.MedianBlur(imageIOControl1.Image1, image, 2 * kernalsize + 1);
                    break;
                case 4:
                    CvInvoke.BilateralFilter(imageIOControl1.Image1,image, kernalsize, kernalsize * 2, kernalsize / 2);
                    break;
            }
            imageIOControl1.Image2 = image;
        }

        private void myTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            imageIOControl1.DoChange();
        }

        private void rbtnBoxBlur_Click(object sender, EventArgs e)
        {
            BlurID = 0;
        }

        private void rbtnBlur_Click(object sender, EventArgs e)
        {
            BlurID = 1;
        }

        private void rbtnGaussian_Click(object sender, EventArgs e)
        {
            BlurID = 2;
        }

        private void rbtnMiddleValue_Click(object sender, EventArgs e)
        {
            BlurID = 3;
        }

        private void rbtnBilateral_Click(object sender, EventArgs e)
        {
            BlurID = 4;
        }


    }
}
