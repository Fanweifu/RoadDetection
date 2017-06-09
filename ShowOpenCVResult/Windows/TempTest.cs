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
using Emgu.CV.Features2D;
using Emgu.CV.Util;
using Emgu.CV.ML;
namespace ShowOpenCVResult.Windows
{
    public partial class TempTest : MoveBlock
    {
        public TempTest()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string file = OpencvForm.SelectImg();
            if (file == null) return;
            imageIOControl1.InImage = new Image<Bgr, byte>(file);


            //
            Image<Gray, Byte> img1 = (imageIOControl1.InImage as Image<Bgr, Byte>).Convert<Gray, Byte>();
            double max, min;
            int[] maxind = new int[2], minidx = new int[2];
            CvInvoke.MinMaxIdx(img1,out  min, out max, minidx, maxind);

            CvInvoke.Circle((imageIOControl1.InImage as Image<Bgr, Byte>), new Point(minidx[1], minidx[0]), 5, new MCvScalar(255,0,255));
            
        }

        private void imageIOControl1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string file = OpencvForm.SelectImg();
            if (file == null) return;
            imageIOControl1.OutImage = new Image<Bgr, byte>(file);

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            SVM sm = new SVM();
            sm.SetKernel(SVM.SvmKernelType.Linear);
            sm.Type = SVM.SvmType.CSvc;
            Image<Gray, float> a = new Image<Gray, float>(2, 4);

            Image<Gray, int> b = new Image<Gray, int>(4, 1);
            a[0, 0] = new Gray(400);
            a[0, 1] = new Gray(30);
            a[1, 0] = new Gray(255);
            a[1, 1] = new Gray(10);
            a[2, 0] = new Gray(350);
            a[2, 1] = new Gray(255);
            a[3, 0] = new Gray(10);
            a[3, 1] = new Gray(501);

            b[0, 0] = new Gray(1);
            b[0, 1] = new Gray(-1);
            b[0, 2] = new Gray(1);
            b[0, 3] = new Gray(-1);
            imageIOControl1.InImage = a;
            imageIOControl1.OutImage = b;
         

        }
    }
       
}
