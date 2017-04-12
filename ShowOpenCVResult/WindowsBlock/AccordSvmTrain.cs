using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Accord.MachineLearning.VectorMachines;
using Emgu.CV;
using Emgu.CV.Structure;

namespace ShowOpenCVResult
{
    public partial class AccordSvmTrain : MoveBlock
    {
        public AccordSvmTrain()
        {
            InitializeComponent();
        }

        Size trainSize =new Size(32,32);
        int classesnum = 0;
        string workspace = null;
        readonly Color[] colors = { Color.YellowGreen, Color.DarkOliveGreen, Color.DarkKhaki, Color.Olive,
            Color.Honeydew, Color.PaleGoldenrod, Color.Indigo, Color.Olive, Color.SeaGreen };
        Dictionary<int, string> labelDescription = new Dictionary<int, string>();
        Dictionary<int, string> folders = new Dictionary<int, string>();

        #region Event
        private void 导出训练结果ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 载入样本ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string foldpath = null;
            using (FolderBrowserDialog f = new FolderBrowserDialog())
            {
                if (f.ShowDialog() != DialogResult.OK) return;
                foldpath = f.SelectedPath;
            }

            dgvTrainingSource.Rows.Clear();
            richTextBox1.Text = "";
            labelDescription.Clear();
            folders.Clear();

            lbStatus.Text = "加载数据。这可能需要一段时间...";

            Application.DoEvents();

            DirectoryInfo theFolder = new DirectoryInfo(foldpath);
            DirectoryInfo[] dirInfo = theFolder.GetDirectories();
            
            //遍历文件夹
            foreach (DirectoryInfo NextFolder in dirInfo)
            {
                string[] strs = NextFolder.Name.Split('_');
                int idnum = 0;
                if (!int.TryParse(strs[0], out idnum)) continue;

                string des = strs.Count() >= 2 ? strs[1] : "";

                labelDescription.Add(idnum, des);
                folders.Add(idnum,NextFolder.FullName);
                richTextBox1.Text += string.Format("{0}-{1}\r\n", idnum, des);

                FileInfo[] fileInfo = NextFolder.GetFiles();
                foreach (FileInfo NextFile in fileInfo)  //遍历文件
                {
                    double[] array =null;
                    Bitmap map = CalArray(NextFile.FullName, ref array);
                    dgvTrainingSource.Rows.Add(map, idnum, array);
                }
                classesnum++;
            }

            workspace = theFolder.FullName;
            lbStatus.Text = String.Format(
                "数据集加载 (训练样本: {0}). 载入测试样本",
                dgvTrainingSource.Rows.Count);
        }

        private void btnDoTrain_Click(object sender, EventArgs e)
        {
            lbStatus.Text = "开始训练网络...";
            Application.DoEvents();
            int rows = dgvTrainingSource.Rows.Count;
            double[][] input = new double[rows][];
            int[] output = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                input[i] = (double[])dgvTrainingSource.Rows[i].Cells[2].Value;
                output[i] = (int)dgvTrainingSource.Rows[i].Cells[1].Value;
            }

            lbStatus.Text = "训练网络中...";
            svmControl.InitSVM(trainSize.Height * trainSize.Height, classesnum);
            Application.DoEvents();
            Stopwatch sw = Stopwatch.StartNew();

            try
            {
                double error = svmControl.Train(input, output);
                sw.Stop();
                lbStatus.Text = String.Format("训练 完成 ({0}ms, {1}er). 单击开始校准按钮", sw.ElapsedMilliseconds, error);
            }
            catch(Exception ex ) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 载入测试样本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string foldpath = null;
            using (FolderBrowserDialog f = new FolderBrowserDialog())
            {
                if (f.ShowDialog() != DialogResult.OK) return;
                foldpath = f.SelectedPath;
            }

            dgvAnalysisTesting.Rows.Clear();
            lbStatus.Text = "加载数据。这可能需要一段时间...";

            Application.DoEvents();
            DirectoryInfo theFolder = new DirectoryInfo(foldpath);
            DirectoryInfo[] dirInfo = theFolder.GetDirectories();
            foreach (DirectoryInfo NextFolder in dirInfo)
            {
                string id = NextFolder.Name.Split('_')[0];
                int idnum = int.Parse(id);

                FileInfo[] fileInfo = NextFolder.GetFiles();
                foreach (FileInfo NextFile in fileInfo)  //遍历文件
                {
                    double[] features = null;
                    Bitmap map = CalArray(NextFile.FullName, ref features);
                    dgvAnalysisTesting.Rows.Add(map, idnum, null, features);
                }
            }
        }

        private void btnClassfly_Click(object sender, EventArgs e)
        {
            if (dgvAnalysisTesting.Rows.Count == 0)
            {
                MessageBox.Show("请在单击此按钮前加载测试数据");
                return;
            }
            else if (!svmControl.HasTrain)
            {
                MessageBox.Show("请在尝试分类前进行培训");
                return;
            }

            lbStatus.Text = "分类 起动. 这可能需要一段时间...";
            Application.DoEvents();

            int hits = 0;
            progressBar.Visible = true;
            progressBar.Value = 0;
            progressBar.Step = 1;
            progressBar.Maximum = dgvAnalysisTesting.Rows.Count;
            foreach (DataGridViewRow row in dgvAnalysisTesting.Rows)// 循环测试图片列表
            {
                double[] input = (double[])row.Cells[3].Value;//获取图片指纹
                int expected = (int)row.Cells[1].Value;//获取人工标记结果
                int output;//识别结果
                if (sender == btnClassifyElimination)//判断识别核心
                {
                    output = svmControl.Pridect(input, MulticlassComputeMethod.Elimination);// 使用Elimination 核心进行特征比对返回 output 结果
                }
                else
                {
                    output = svmControl.Pridect(input, MulticlassComputeMethod.Voting);// 使用Voting 核心进行特征比对返回 output 结果
                }
                row.Cells[2].Value = output;//写入测试图片列表结果存储列

                if (expected == output)// 识别结果跟人工标记结果相等 则设置测试结果集合对应行的背景色为绿色
                {
                    row.Cells[0].Style.BackColor = Color.LightGreen;
                    row.Cells[1].Style.BackColor = Color.LightGreen;
                    row.Cells[2].Style.BackColor = Color.LightGreen;
                    hits++;
                }
                else// 识别结果跟人工标记结果不相等 则设置测试结果集合对应行的背景色为白色
                {
                    row.Cells[0].Style.BackColor = Color.White;
                    row.Cells[1].Style.BackColor = Color.White;
                    row.Cells[2].Style.BackColor = Color.White;
                }
                progressBar.PerformStep();
            }
            progressBar.Visible = false;

            lbStatus.Text = String.Format("测试：{2}个  成功: {0}个  失败：{1}个   成功率：({3:0%})",
                hits, dgvAnalysisTesting.Rows.Count - hits, dgvAnalysisTesting.Rows.Count, (double)hits / dgvAnalysisTesting.Rows.Count);
        }

        private void 载入训练结果ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            var gray = drawImageBox1.Image as Image<Gray, byte>;
            if (gray == null) return;
            double [] array = Extract(gray.Resize(trainSize.Width,trainSize.Height, Emgu.CV.CvEnum.Inter.Linear));
            if (!svmControl.HasTrain) return;

            int result = svmControl.Pridect(array, MulticlassComputeMethod.Elimination);

            MessageBox.Show(string.Format("{0}-{1}", result, labelDescription[result]));
            
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var img = OpencvForm.GetImage();
            if (img == null) return;
            var gray = (img as Image<Bgr, byte>).Convert<Gray, byte>();
            if (drawImageBox1.Image != null) {
                drawImageBox1.Image.Dispose();
            }
            drawImageBox1.Image = gray;
            
        }

        #endregion

        #region Function

        double[] Extract(Image<Gray, byte> grayimg, int threshold = 30)
        {
            int width = grayimg.Size.Width, height = grayimg.Size.Height;
            int size = width * height;
            double[] result = new double[size];
            unsafe
            {
                byte* ptr = (byte*)grayimg.Mat.DataPointer;
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        result[i * width + j] = *(ptr + i * width + j) > threshold ? 1 : 0;
                    }
                }
            }

            return result;
        }

        Bitmap CalArray(string path, ref double[] features)
        {
            var img = new Emgu.CV.Image<Gray, byte>(path);
            var imgsize = img.Resize(trainSize.Width, trainSize.Height, Emgu.CV.CvEnum.Inter.Linear);
            img.Dispose();
            features = Extract(imgsize);//二值化
            Bitmap map = imgsize.ToBitmap();
            imgsize.Dispose();
            return map;
        }

        #endregion

        private void button1_Click_1(object sender, EventArgs e)
        {
            int key = (int)numericUpDown1.Value;
            if (folders.Keys.Contains(key) && drawImageBox1.Image != null) {
                DateTime dt = DateTime.Now;
                string path = string.Format("{0}\\{1}{2}{3}.png", folders[key], dt.Hour,dt.Minute,dt.Second);
                drawImageBox1.Image.Save(path);
                MessageBox.Show(string.Format("分类：{0}，保存在{1}", key, path));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Image<Gray, byte> Img = null;
            if (drawImageBox1.Image == null) return;
            if (!(drawImageBox1.Image is Image<Gray, byte>))
            {
                Img = (drawImageBox1.Image as Image<Bgr, byte>).Convert<Gray, byte>();
            }
            else {
                Img = (drawImageBox1.Image as Image<Gray, byte>);
            }

            double[] array = Extract(Img.Resize(trainSize.Width, trainSize.Height, Emgu.CV.CvEnum.Inter.Linear));
            if (!svmControl.HasTrain) return;

            int result = svmControl.Pridect(array, MulticlassComputeMethod.Elimination);

            MessageBox.Show(string.Format("{0}-{1}", result, labelDescription[result]));

        }
    }
}
