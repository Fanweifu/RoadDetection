using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace ShowOpenCVResult
{
    //[Guid("52F0F7CF-B73F-4AD4-A04E-DAEF6333A9B0")]
    //[ComVisible(true)]
    //public interface IComTest        
    //{
    //    [DispId(1)]       
    //    int Plus(int one, int two);
    //}

    //[Guid("2293C017-26F7-459B-BA3C-38E76E05E5DE")]
    //[ClassInterface(ClassInterfaceType.None)]
    public partial class VideoFindMechine : MoveBlock/*,IComTest*/
    {
        bool isvideo = false;
        Capture m_cp = new Capture();
        double fps = 0;
        int count = 0;
        Thread video = null;

        public VideoFindMechine()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog op = new OpenFileDialog())
            {
                op.Filter = "(AVI)*.avi|*.avi";
                if (op.ShowDialog() != DialogResult.OK) return;
                m_cp = new Capture(op.FileName);
                fps = m_cp.GetCaptureProperty(CapProp.Fps);
                count = (int)m_cp.GetCaptureProperty(CapProp.FrameCount);
                isvideo = true;
            }

            imageIO1.DoChange();

        }

        private void imageIO1_DoImgChange(object sender, EventArgs e)
        {
            Mat img = null;

            if (isvideo)
            {
                if (m_cp == null) return;
                int nums = 0;

                if (video != null) {
                    video.Abort();
                    video = null;
                }

                video = new Thread(() =>
                {
                    while (nums < count)
                    {
                        img = m_cp.QueryFrame();
                        var backup = img.Clone();
                        //OpencvMath.NormalizeBGR(backup);
                        Thread.Sleep((int)(1000.0 / fps));
                        Mat mask = new Mat();

                        imageIO1.Image1 = img;
                        imageIO1.Image2 = backup;
                        nums++;
                    }

                });

                video.Start();

            }
            else {
                if (video != null) {
                    video.Abort();
                    video = null;
                }

                img = (imageIO1.Image1 as Image<Bgr, byte>).Mat;
                dothing(img);


            }
       
        }

        void dothing( Mat img ) {

            if (img == null) return;
        
            Mat mask = new Mat();
            Rectangle rect = new Rectangle();
            var imgresult = img.Clone();
            CvInvoke.CvtColor(imgresult , mask, ColorConversion.Bgr2Gray);
            CvInvoke.FloodFill(mask, null, new Point(1, 1), new MCvScalar(0),out rect,new MCvScalar(2),new MCvScalar(30));
            CvInvoke.Threshold(mask, mask, 0, 255, ThresholdType.Binary);


            // Hsv
            CvInvoke.CvtColor(imgresult, imgresult, ColorConversion.Bgr2Hsv);
            Mat hsv = new Mat();
            imgresult.CopyTo(hsv, mask);

            VectorOfMat bgr = OpencvMath.NormolizeHsvImg(hsv, mask);

            Mat resultv = new Mat();
            //CvInvoke.MorphologyEx(bgr[1], resultv, MorphOp.Open, CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(21, 21), new Point(-1, -1)), new Point(-1, -1), 1, BorderType.Default, new MCvScalar(0));
            //Mat redmask = new Mat();
            //Mat redmask1 = new Mat();
            //Mat redmask2 = new Mat();
            //CvInvoke.Threshold(bgr[0], redmask1, (int)myTrackBar1.Value, 255, ThresholdType.Binary);
            //CvInvoke.Threshold(bgr[0], redmask2, (int)myTrackBar2.Value, 255, ThresholdType.BinaryInv);
            //CvInvoke.Add(redmask1, redmask2, redmask);
            //Mat hsand = new Mat();
            //CvInvoke.BitwiseAnd(redmask, bgr[1], hsand);

            Mat result = new Mat();
            CvInvoke.Merge(bgr, result);
            CvInvoke.CvtColor(result, result, ColorConversion.Hsv2Bgr);

            if (imageIO1.Image2 != null)
                imageIO1.Image2.Dispose();
            imageIO1.Image2 = bgr[1];


            
            CvInvoke.CvtColor(imgresult, imgresult, ColorConversion.Bgr2Gray);
            CvInvoke.Normalize(imgresult, imgresult, 0, 255, NormType.MinMax, DepthType.Default, mask);

            mask.Dispose();
            imgresult.Dispose();
            //redmask.Dispose();
            //redmask1.Dispose();
            //redmask2.Dispose();
            //bgr.Dispose();



        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            IImage img = OpencvForm.GetImage();
            if (img == null) return;

            isvideo = false;
            imageIO1.SetInput(img);


        }

        private void myTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            imageIO1.DoChange();
        }

        private void myTrackBar2_ValueChanged(object sender, EventArgs e)
        {
            imageIO1.DoChange();
        }


        //public int Plus(int one, int two)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
