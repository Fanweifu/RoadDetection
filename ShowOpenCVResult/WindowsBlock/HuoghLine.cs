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
    public partial class HuoghLine : MoveBlock
    {
        public HuoghLine()
        {
            InitializeComponent();
        }
        Image<Bgr, Byte> m_src;

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            imageIOControl1.SetInput(OpencvForm.GetImage());
        }

        private void imageIOControl1_DoImgChange(object sender, EventArgs e)
        {
            if (m_src == null) return;
            Image<Gray, Byte> img = m_src.Convert<Gray, Byte>();
            Image<Gray, Byte> bw = img.ThresholdBinary(new Gray(130), new Gray(255));

            if (toolStripButton2.Checked)
            {
                CvInvoke.Canny(bw, bw, myTrackBar1.Value, myTrackBar2.Value);
            }

            if (imageIOControl1.Image1 != null) imageIOControl1.Image1.Dispose();
            imageIOControl1.Image1 = bw;
            LineSegment2D[] lns = CvInvoke.HoughLinesP(bw, (double)myTrackBar3.Value / 100, (double)myTrackBar4.Value / 100, myTrackBar5.Value, myTrackBar6.Value, myTrackBar7.Value);
            Image<Bgr, Byte> outimg = new Image<Bgr, Byte>(m_src.Size);
            foreach (var ln in lns)
                CvInvoke.Line(outimg, ln.P1, ln.P2, new MCvScalar(0, 0, 255), 1);

            if (imageIOControl1.Image2 != null) imageIOControl1.Image2.Dispose();
            imageIOControl1.Image2 = outimg;
            
        }

        private void imageIOControl1_AfterImgLoaded(object sender, EventArgs e)
        {
            m_src = (imageIOControl1.Image1 as Image<Bgr,Byte>).Clone();
        }

        
    }
}
