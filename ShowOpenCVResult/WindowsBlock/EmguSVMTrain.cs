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
using System.IO;
using Emgu.CV.ML;

namespace ShowOpenCVResult
{
    public partial class EmguSVMTrain : MoveBlock
    {
        private SVM svm;
        private DataTable m_mytb;
        private List<Image<Gray, Byte>> m_imglist;
        string xmlpath = null;
        public EmguSVMTrain()
        {
            InitializeComponent();
            OnNew();
        }

        void OnNew() {
            m_imglist = new List<Image<Gray,byte>>();
            m_mytb = new DataTable();
            m_mytb.Columns.Add("ID", typeof(int));
            m_mytb.Columns.Add("Type", typeof(int));
            m_mytb.Columns.Add("FileName", typeof(string));
            m_mytb.Columns.Add("Size", typeof(Size));
            m_mytb.DefaultView.Sort = "Type,ID";
           
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fb = new FolderBrowserDialog()) {
                if (fb.ShowDialog() != DialogResult.OK) return;
                dataGridView1.ReadOnly = false;
                LoadTable(fb.SelectedPath);
                tsbtnSaveLabels.Enabled = true;
                toolStripButton3.Enabled = false;
            }
        }

        void LoadTable(string filefold) {

            DirectoryInfo d = new DirectoryInfo(filefold);
            m_mytb.Rows.Clear();
            m_imglist.Clear();
            foreach (DirectoryInfo di in d.GetDirectories()) {

                int i = 0;
                try
                {
                    string[] strs = di.Name.Split('_');
                    i = int.Parse(strs[0]);
                }
                catch {
                    i = 0;
                }

                foreach (FileInfo fi in di.GetFiles()) {
                    try
                    {
                        var m = new Image<Gray, byte>(fi.FullName);
                        m_imglist.Add(m);
                        DataRow dr = m_mytb.NewRow();
                        dr[0] = m_imglist.Count - 1;
                        dr[1] = i;
                        dr[2] = fi.Name;
                        dr[3] = m.Size;
                        m_mytb.Rows.Add(dr);
                    }
                    catch {

                    }
                }
            }

            dataGridView1.DataSource = m_mytb;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            toolStripButton3.Enabled = true;
            tsbtnSaveLabels.Enabled = false;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex > dataGridView1.Rows.Count - 1) return;

            DataGridViewRow dgvr = dataGridView1.Rows[e.RowIndex];
            int index = (int)(dgvr.Cells[0].Value);
            drawImageBox1.Image = m_imglist[index];
        }

        void svmtrain() {
            svm = new SVM();
            svm.SetKernel(SVM.SvmKernelType.Linear);
            svm.Type = SVM.SvmType.CSvc;
            svm.TermCriteria = new MCvTermCriteria(100, 1e-6);
            Size imgsize = m_imglist[0].Size;
            Image<Gray, float> examples = new Image<Gray, float>(imgsize.Height * imgsize.Height, m_imglist.Count);
            for (int i = 0; i < m_imglist.Count; i++)
            {
                var img = m_imglist[i];
                for (int w = 0; w < img.Width; w++)
                    for (int h = 0; h < img.Height; h++)
                        examples[i, h * img.Width + w] = img[h,w];

            }

            //

            Image<Gray, int> lables = new Image<Gray, int>(m_imglist.Count,1);
            for (int i = 0; i < m_mytb.Rows.Count; i++) {
                lables[0, i] = new Gray((int)(m_mytb.Rows[i][1]));
            }
            Mat ex = new Mat();
            //examples.Mat.ConvertTo(ex, Emgu.CV.CvEnum.DepthType.Cv32F);
            TrainData td = new TrainData(examples, Emgu.CV.ML.MlEnum.DataLayoutType.RowSample, lables);
            svm.TrainAuto(td);
        
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            svmtrain();
            
       }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }

        

        private void 图片测试_Click(object sender, EventArgs e)
        {
            if (svm == null) return;
            var _img = OpencvForm.GetImage();
            if (_img == null) return;
            Image<Gray, float> img = (_img as Image<Bgr, Byte>).Convert<Gray, float>();
            //if (img.Size != BaseFunc.ExampleSize) return;
            Image<Gray, float> example = OpencvMath.GetOneLineVector(img);
            double result = svm.Predict(example);
            tslblSVMResult.Text = result.ToString();
        }

        private void tsbtnSaveToXML_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sf = new SaveFileDialog())
            {
                sf.Title = "保存XML文件";
                sf.Filter = "(XML)*.xml|*.xml";
                if (sf.ShowDialog() != DialogResult.OK) return;

                svm.Save(sf.FileName);

            }
        }
    }
}
