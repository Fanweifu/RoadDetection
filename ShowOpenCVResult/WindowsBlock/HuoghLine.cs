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
        Mat m_src;

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            imageIOControl1.SetInput(OpencvForm.GetImage());
        }

        private void imageIOControl1_DoImgChange(object sender, EventArgs e)
        {
            if (m_src == null) return;
            Mat grayimg = m_src.Clone();

            if (toolStripButton2.Checked)
            {
                CvInvoke.Canny(grayimg, grayimg, myTrackBar1.Value, myTrackBar2.Value);
            }
            else
            {
                CvInvoke.Threshold(grayimg, grayimg, 130, 255, Emgu.CV.CvEnum.ThresholdType.Binary);
            }

            if (imageIOControl1.InImage != null) imageIOControl1.InImage.Dispose();
            imageIOControl1.InImage = grayimg;
            LineSegment2D[] lns = CvInvoke.HoughLinesP(grayimg, (double)rhoBar.Value / 100, (double)thetaBar.Value / 100, thresholdBar.Value, minLenghtBar.Value, maxgrapBar.Value);
            Image<Bgr, byte> outimg = new Image<Bgr, byte>(m_src.Size);

            if (toolStripButton4.Checked)
                lns = OpencvMath.SelectLines(lns);
            Random rm = new Random();
            foreach (var ln in lns)
            {
                int b = rm.Next(0, 255), g = rm.Next(0, 255), r = rm.Next(0, 255);
                CvInvoke.Line(outimg, ln.P1, ln.P2, new MCvScalar(b, g, r), 1);
            }

            if (imageIOControl1.OutImage != null) imageIOControl1.OutImage.Dispose();
            imageIOControl1.OutImage = outimg;
            
        }

        private void imageIOControl1_AfterImgLoaded(object sender, EventArgs e)
        {
            m_src = OpencvMath.MyBgrToGray((imageIOControl1.InImage as Image<Bgr, Byte>).Mat);
        }

        private void HuoghLine_Load(object sender, EventArgs e)
        {
            var config = Properties.Settings.Default;
            myTrackBar1.Value = config.CannyThreshold;
            myTrackBar2.Value = config.CannyLink;
            rhoBar.Value  = (int)(config.LineRho*100);
            thetaBar.Value = (int)(config.LineTheta * 100);
            thresholdBar.Value = config.LineThreshold;
            minLenghtBar.Value = config.LineMinLength;
            maxgrapBar.Value = config.LineMaxGrap;
    
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var config = Properties.Settings.Default;
            config.CannyThreshold = myTrackBar1.Value;
            config.CannyLink = myTrackBar2.Value;
            config.LineRho = (double)rhoBar.Value / 100;
            config.LineTheta = (double)thetaBar.Value / 100;
            config.LineThreshold = thresholdBar.Value;
            config.LineMinLength = minLenghtBar.Value;
            config.LineMaxGrap = maxgrapBar.Value;
            config.Save();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            imageIOControl1.DoChange();
        }
    }
}
