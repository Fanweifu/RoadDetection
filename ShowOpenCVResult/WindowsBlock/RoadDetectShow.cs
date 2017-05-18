using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using Emgu.CV.CvEnum;
using System.Threading.Tasks;
using Accord.MachineLearning.VectorMachines;
using Emgu.CV.Structure;
using System.Diagnostics;
using System.Drawing;
using ShowOpenCVResult.ImgProcess;

namespace ShowOpenCVResult
{
    public partial class RoadDetectShow : MoveBlock
    {
        Task playthead = null;
        Thread imgprocess = null;
        Capture m_captrue = null;
        long timesum = 0;
        int playcnt = 0;
        int fps = 0;
        int curplayindex = 0;
        int detectInternal = 1;
        bool isclosewindows = false;
        string[] exs = new string[] { ".jpg", ".png", ".bmp", "jpeg" };

        MulticlassSupportVectorMachine m_svm = null;
        Dictionary<int, int> svmresult = new Dictionary<int, int>();
        RoadDetect m_detector = null;

        public RoadDetectShow()
        {
            initTimer();
            iniPictPlay();
            InitializeComponent();
        }
        Queue<Mat> m_queue = new Queue<Mat>();

        List<string> imgspath = new List<string>();
        bool isinplay = true;
        System.Timers.Timer m_timer = new System.Timers.Timer();
        ManualResetEvent mr = new ManualResetEvent(true);
        private void tsbtnOpenImg_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fb = new FolderBrowserDialog())
            {
                if (fb.ShowDialog() != DialogResult.OK) return;
                DirectoryInfo dt = new DirectoryInfo(fb.SelectedPath);
                foreach (FileInfo fi in dt.GetFiles())
                {
                    if (exs.Contains(fi.Extension))
                    {
                        imgspath.Add(fi.FullName);
                    }
                }
                toolStripProgressBar1.Maximum = imgspath.Count;
                toolStripProgressBar1.Value = 0;
                toolStripButton2.Enabled = true;
                iniPictPlay();
            }

        }


        void iniPictPlay()
        {
            playthead = new Task(() =>
            {
                foreach (var path in imgspath)
                {
                    if (!isinplay)
                    {
                        mr.WaitOne();
                    }
                    if (isclosewindows)
                        return;

                    Mat matimg = new Mat(path, LoadImageType.Unchanged);
                    if (imageIOControl1.Image1 != null)
                        imageIOControl1.Image1.Dispose();
                    imageIOControl1.Image1 = matimg;
                    if (tsbtnUpdate.Checked)
                    {
                        long time = 0;
                        Mat road = null;
                        Mat result = OpencvMath.FinalLineProcess(matimg, out time, true);
                        var vpp = OpencvMath.WalkRoadImg(result);
                        for (int i = 0; i < vpp.Size; i++)
                        {
                            OpencvMath.DrawRotatedRect(CvInvoke.MinAreaRect(vpp[i]), result);
                        }
                        if (imageIOControl1.Image2 != null)
                            imageIOControl1.Image2.Dispose();
                        imageIOControl1.Image2 = result;
                        playcnt++;
                        timesum += time;

                        Invoke(new Action(() =>
                        {
                            toolStripStatusLabel4.Text = path;
                            tsslbShow.Text = string.Format("当前耗时:{0}ms,播放帧数{1},平均耗时{2}", time, playcnt, timesum / playcnt);
                        }));
                    }
                    Thread.Sleep(1000);
                }


              

            });
            playthead.Start();
        }
        void initTimer()
        {
            m_timer.Elapsed += M_timer_Tick;
            m_timer.Interval = 500;

        }

        private void M_timer_Tick(object sender, EventArgs e)
        {
            if (curplayindex >= imgspath.Count)
            {
                m_timer.Stop();
            }
            mr.WaitOne();
            mr.Reset();
            Mat matimg = new Mat(imgspath[curplayindex++], LoadImageType.Unchanged);
            if (imageIOControl1.Image1 != null)
                imageIOControl1.Image1.Dispose();
            imageIOControl1.Image1 = matimg;
            long time = 0;
            Mat road = null;
            Mat result = OpencvMath.FinalLineProcess(matimg, out time, true);
            var vpp = OpencvMath.WalkRoadImg(result);
            for (int i = 0; i < vpp.Size; i++)
            {
                OpencvMath.DrawRotatedRect(CvInvoke.MinAreaRect(vpp[i]), result);
            }

            road.Dispose();

            if (imageIOControl1.Image2 != null)
                imageIOControl1.Image2.Dispose();
            imageIOControl1.Image2 = result;

            playcnt++;
            timesum += time;

            Thread.Sleep(1000);
            Invoke(new Action(() =>
            {
                tsslbShow.Text = string.Format("总体耗时:{0}ms,播放帧数{1},平均耗时{2}", timesum, playcnt, timesum / playcnt);

            }));
            mr.Set();
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



        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            imageIOControl1.DoChange();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (isinplay)
            {
                isinplay = false;
                mr.Reset();
            }
            else
            {
                isinplay = true;
                mr.Set();
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }


        void iniVideotPlay()
        {
            Mat last = new Mat();
            playthead = new Task(() =>
            {
                if (m_captrue == null) return;
                int cnt = 0;
                long sumtime = 0;
                while (cnt++ < playcnt)
                {
                    if (!isinplay)
                        mr.WaitOne();
                    Stopwatch sw = Stopwatch.StartNew();

                    Mat img = m_captrue.QueryFrame();
                    imageIOControl1.Image1 = img;
                    m_queue.Enqueue(img);

                    if (tsbtnUpdate.Checked && cnt % detectInternal == 0)
                    {

                        new Thread(() =>
                        {
                            long time = 0;
                            if (m_detector == null) return;
                            doprocess(img, out time);
                            sumtime += time;
                            Invoke(new Action(() =>
                            {
                                if (!imageIOControl1.IsDisposed) imageIOControl1.Refresh();
                                tsslbShow.Text = string.Format("总体耗时:{0}ms,播放帧数{1},当前耗时:{2}平均耗时{3}", sumtime, cnt, time, sumtime / cnt);
                            }));

                        }).Start();

                    }

                    if (m_queue.Count > 4) {
                        Mat outimg = m_queue.Dequeue();
                        outimg.Dispose();
                    }

                    sw.Stop();
                    int sleeptime = 1000 / fps - (int)sw.ElapsedMilliseconds;
                    if(sleeptime>0)
                        Thread.Sleep(sleeptime);
                    
                }
            });

        }

        int lastoffset = 0;
        int lastlane = 0;
        void doprocess(Mat img, out long time)
        {
            if (m_detector == null) { time = 0; return; }

            //img = img.Clone();
            //LineSegment2D[] lines = null;

            //Mat todoprocess = new Mat(img, Properties.Settings.Default.DetectArea);
            //var result = OpencvMath.SpeedProcess(todoprocess, out time, out lines, false);
            //Mat svmimg = OpencvMath.SvmResult(result, svmresult, m_svm);
            //result.Dispose();
            //Mat trans = new Mat();
            //CvInvoke.WarpPerspective(svmimg, trans, RoadTransform.TranforMatInv, Properties.Settings.Default.DetectArea.Size);
            //sw.Stop();
            //time = sw.ElapsedMilliseconds;
            //if (lines.Count() == 2)
            //{
            //    Point[] pts = new Point[] { lines[0].P1, lines[0].P2, lines[1].P1, lines[1].P2 };
            //    PointF[] ptfs = Array.ConvertAll<Point, PointF>(pts, (x) => { return new PointF(x.X, x.Y); });
            //    ptfs = CvInvoke.PerspectiveTransform(ptfs, RoadTransform.TranforMatInv);
            //    pts = Array.ConvertAll<PointF, Point>(ptfs, Point.Round);
            //    lines[0].P1 = pts[0];
            //    lines[0].P2 = pts[1];
            //    lines[1].P1 = pts[2];
            //    lines[1].P2 = pts[3];
            //    foreach (var item in lines)
            //    {
            //        CvInvoke.Line(trans, item.P1, item.P2, new MCvScalar(0, 255, 0), 2);
            //    }
            //    OpencvMath.DrawMiddlePos(trans, lines);
            //}
            //Mat rect = new Mat(img, Properties.Settings.Default.DetectArea);
            //OpencvMath.MyAddWeight(rect, trans, 0.8);

            int offest = lastoffset, lanewidth = lastlane;
            Mat imgroi = new Mat(img.Clone(), Properties.Settings.Default.DetectArea);
            Mat result = m_detector.DetectAndShow(imgroi, ref  offest, ref lanewidth,out time);

            //if ((offest - lastoffset) > (lastlane + lanewidth) / 3)
            //{
            //    Invoke(new Action(() =>
            //    {
            //        tsslbshowturn.Text = "change lane to left";
            //        toolStripButton2_Click(null,null);
            //    }));
            //}
            //else if ((offest - lastoffset) < -(lastlane + lanewidth) / 3)
            //{
            //    Invoke(new Action(() =>
            //    {
            //        tsslbshowturn.Text = "change lane to right";
            //        toolStripButton2_Click(null, null);
            //    }));
            //}
            lastoffset = offest;
            lastlane = lanewidth;

            imageIOControl1.Image2 = result;

        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //using (OpenFileDialog of = new OpenFileDialog())
            //{
            //    of.Filter = "DAT|*.dat";
            //    if (of.ShowDialog() != DialogResult.OK) return;
            //    
            //}
            m_svm = MulticlassSupportVectorMachine.Load("svm.dat");

             m_detector = new RoadDetect("svm.dat");
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton5_Click_1(object sender, EventArgs e)
        {
            if (null == imageIOControl1.Image1) return;
            Mat img = imageIOControl1.Image1 as Mat;
            long time = 0;
            doprocess(img,out time);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            m_detector.ReLoadParams();
            if (null == imageIOControl1.Image1) return;
            Mat img = imageIOControl1.Image1 as Mat;
            long time = 0;
            doprocess(img, out time);
        }

        private void numDetectInternal_ValueChanged(object sender, EventArgs e)
        {
            detectInternal = (int)numDetectInternal.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbDirectory.Text) || File.Exists(tbDirectory.Text))
            {
                Process.Start(tbDirectory.Text);
            }
        }

        private void tsbtnConnectcam_Click(object sender, EventArgs e)
        {
            m_captrue = new Emgu.CV.Capture(1);
            playthead = new Task(() =>
            {
                while (true)
                {
                    if (isclosewindows)
                        return;
                    imageIOControl1.Image1 = m_captrue.QueryFrame();
                    Thread.Sleep(33);
                }

            });

            playthead.Start();
        }

        private void RoadDetectShow_FormClosing(object sender, FormClosingEventArgs e)
        {
            isclosewindows = true;
        }
    }
}
