using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;

namespace ShowOpenCVResult.Windows
{
    public partial class ConvertVideoToImgs : MoveBlock
    {
        Capture m_cap = null;
        int m_framecnt = 0;

        public ConvertVideoToImgs()
        {
            InitializeComponent();
        }

        


        private void btnSelectVideo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog sf = new OpenFileDialog())
            {
                sf.Filter = "Videos|*.avi;*.mp4;*.flv";
                if (sf.ShowDialog() != DialogResult.OK) return;
                try
                {
                    m_cap = new Capture(sf.FileName);
                    m_framecnt = (int)m_cap.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameCount);
                    tbVideoPath.Text = sf.FileName;
                    tsspbarShowProcess.Maximum = m_framecnt;
                    tsspbarShowProcess.Value = 0;
                    tsslbFrameCnt.Text = string.Format("{0}/{1}", 0, m_framecnt);
                }
                catch
                {
                    MessageBox.Show("Fail to read the video");
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fb = new FolderBrowserDialog())
            {
                if (fb.ShowDialog() != DialogResult.OK) return;
                tbOutputImgDirectory.Text = fb.SelectedPath;
            }
        }

        private void btnStrat_Click(object sender, EventArgs e)
        {

            if (!Directory.Exists(tbOutputImgDirectory.Text))
            {
                MessageBox.Show("output directory not found!");
                return;

            }

            string ex = comboBox1.SelectedItem.ToString();
            Task exportthread = new Task(() =>
            {
                int curindex = 0;
                while (curindex++ < m_framecnt)
                {
                    Mat img = m_cap.QueryFrame();
                    if (drawImageBox1.Image != null)
                        drawImageBox1.Image = img;
                    string imgpath = string.Format("{0}\\{1}_{2}{3}", tbOutputImgDirectory.Text, Path.GetFileNameWithoutExtension(tbVideoPath.Text),curindex ,ex);
                    img.Save(imgpath);
                    Invoke(new Action(() =>
                    {
                        tsspbarShowProcess.Value++;
                        tsslbFrameCnt.Text = string.Format("{0}/{1}", curindex, m_framecnt);
                    }));
                }



            });
            exportthread.Start();

        }
    }
}
