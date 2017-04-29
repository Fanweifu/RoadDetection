using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;

namespace ShowOpenCVResult
{
    public partial class CarDetect : MoveBlock
    {
        Capture m_captrue = null;
        int playcnt = 0, fps = 0;
        int curidx = 0;
        Task playthread = null;
        CascadeClassifier m_classifier = null;
        public CarDetect()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string videopath = @"D:\Youku Files\download\高速公路-阴险放坑-行车记录仪_标清.flv";

            using (OpenFileDialog of = new OpenFileDialog())
            {
                of.Filter = "(*.*)|*.*|(MP4)|*.mp4|(AVI)|*.avi|(FLV)|*.flv";
                if (of.ShowDialog() != DialogResult.OK) return;
                videopath = of.FileName;
            }
            m_captrue = new Capture(videopath);
            playcnt = (int)m_captrue.GetCaptureProperty(CapProp.FrameCount);
            fps = (int)m_captrue.GetCaptureProperty(CapProp.Fps);

            iniVideotPlay();
            playthread.Start();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog of = new OpenFileDialog())
            {
                of.Filter = "XML|*.xml";
                if (of.ShowDialog() != DialogResult.OK) return;
                m_classifier = new CascadeClassifier(of.FileName);

            }
        }

        void iniVideotPlay()
        {
            curidx = 0;
            playthread = new Task(() =>
            {
                if (m_captrue == null || m_classifier == null) return;
          
                while (curidx++ < playcnt)
                {
                    Stopwatch sw = Stopwatch.StartNew();
                    Mat img = m_captrue.QueryFrame();
                    imageIO1.Image1 = img;
                    Mat backimg = new Mat();
                    CvInvoke.CvtColor(img, backimg, ColorConversion.Bgr2Gray);
                    if (curidx % 5 == 0)
                    {
                        new Task(() =>
                        {
                            Rectangle[] rects = m_classifier.DetectMultiScale(backimg);
                            foreach (var item in rects)
                            {
                                CvInvoke.Rectangle(backimg, item, new Emgu.CV.Structure.MCvScalar(255));
                            }

                            if (imageIO1.Image2 != null)
                                imageIO1.Image2.Dispose();
                            imageIO1.Image2 = backimg;
                        }).Start();
                    }
                    sw.Stop();
                    int time = 1000 / fps - (int)sw.ElapsedMilliseconds;
                    if(time>0)
                        Thread.Sleep(time);

                }

            });

        }

    }
}
