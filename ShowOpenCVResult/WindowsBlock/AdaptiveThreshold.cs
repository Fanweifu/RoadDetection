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
    public partial class AdaptiveThreshold : MoveBlock
    {
        public AdaptiveThreshold()
        {
            InitializeComponent();
        }

        private void tsbtnOpen_Click(object sender, EventArgs e)
        {
            string path = OpencvForm.SelectImg();
            if(path!=null)
                imageIOControl1.SetInput(new Image<Bgr, byte>(path));
        }

        private void imageIOControl1_DoImgChange(object sender, EventArgs e)
        {
            if (imageIOControl1.InImage == null) return;
            Mat img = OpencvMath.MyBgrToGray((imageIOControl1.InImage as Image<Bgr, byte>).Mat);
            Mat adresult = new Mat();
            Mat otusresult = new Mat();
            CvInvoke.AdaptiveThreshold(img, adresult, 255, (radioButton1.Checked ? AdaptiveThresholdType.GaussianC : AdaptiveThresholdType.MeanC),ThresholdType.Binary, 2 * blockSizeBar.Value + 1, (double)prama1Bar.Value);
            //CvInvoke.Threshold(img, otusresult, 100, 255, ThresholdType.Otsu);
            //CvInvoke.BitwiseAnd(adresult, otusresult, adresult);

            imageIOControl1.OutImage = adresult;
        }

        private void myTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            imageIOControl1.DoChange();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            imageIOControl1.DoChange();
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            var config = Properties.Settings.Default;
            config.AdaptiveBlockSize = blockSizeBar.Value;
            config.AdaptiveParam = prama1Bar.Value;
            config.Save();
        }

        private void AdaptiveThreshold_Load(object sender, EventArgs e)
        {
            var config = Properties.Settings.Default;
            blockSizeBar.Value = config.AdaptiveBlockSize;
            prama1Bar.Value = config.AdaptiveParam;
        }
    }
}
