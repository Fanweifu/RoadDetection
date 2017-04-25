﻿using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using Emgu.CV.CvEnum;
using System.Threading.Tasks;

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
        string[] exs = new string[] { ".jpg", ".png", ".bmp", "jpeg" };

        public RoadDetectShow()
        {
            initTimer();
            iniPictPlay();
            InitializeComponent();
        }

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

                    Mat matimg = new Mat(path, LoadImageType.Unchanged);
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
                    if (imageIOControl1.Image2 != null)
                        imageIOControl1.Image2.Dispose();
                    imageIOControl1.Image2 = result;
                    playcnt++;
                    timesum += time;
                    Invoke(new Action(() =>
                    {
                        toolStripStatusLabel4.Text = path;
                        toolStripStatusLabel2.Text = string.Format("当前耗时:{0}ms,播放帧数{1},平均耗时{2}", time, playcnt, timesum / playcnt);
                    }));
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
                toolStripStatusLabel2.Text = string.Format("总体耗时:{0}ms,播放帧数{1},平均耗时{2}", timesum, playcnt, timesum / playcnt);

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
            string videopath = null;

            using (OpenFileDialog of = new OpenFileDialog())
            {
                of.Filter = "(MP4)|*.mp4|(AVI)|*.avi|(FLV)|*.flv";
                if (of.ShowDialog() != DialogResult.OK) return;
                videopath = of.FileName;
            }
            m_captrue = new Capture(videopath);
            playcnt = (int)m_captrue.GetCaptureProperty(CapProp.FrameCount);
            fps = (int)m_captrue.GetCaptureProperty(CapProp.Fps);
            toolStripButton2.Enabled = true;
            iniVideotPlay();
            playthead.Start();
        }


        void iniVideotPlay()
        {
            Mat last = new Mat();
            playthead = new Task(() =>
            {
                if (m_captrue == null) return;
                int cnt = 0;
                while (cnt++ < playcnt)
                {
                    if (!isinplay)
                        mr.WaitOne();

                    Mat img = m_captrue.QueryFrame();

                    if (cnt % 4 == 0) {

                        new Thread(() =>
                        {
                            long time = 0;
                            Mat todoprocess = new Mat(img.Clone(), Properties.Settings.Default.DetectArea);
                            var result = OpencvMath.SpeedProcess(todoprocess, out time, true);
                            imageIOControl1.Image2 = result;
                            Invoke(new Action(() => { imageIOControl1.Refresh(); }));
                            img.Dispose();
                        }).Start();

                    }

                    imageIOControl1.Image1 = img;
                    last.Dispose();
                    last = img;
                }
            });

        }
    }
}
