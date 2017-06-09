using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ShowOpenCVResult.Windows
{
    public partial class CreatAnglesImg : ShowOpenCVResult.MoveBlock
    {
        Image<Gray, Byte>[] imgs;
        List<double> angles;
        string path;
        public CreatAnglesImg()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            path = OpencvForm.SelectImg();
            if (path == null) return;
            imageIO1.InImage = new Image<Gray,Byte>(path);

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (imageIO1.InImage == null) return ;
            Image<Gray, Byte> gray = imageIO1.InImage as Image<Gray, Byte>;
            angles = new List<double>();
            foreach (Control c in flowLayoutPanel1.Controls) {
                CheckBox cb =c as CheckBox;
                if(cb!=null&&cb.Checked==true){
                   angles.Add(double.Parse(cb.Text));
                }
            }
            imgs = new Image<Gray, byte>[angles.Count];
            treeView1.Nodes.Clear();
            for (int i = 0; i < angles.Count; i++) {
                treeView1.Nodes.Add(new TreeNode(angles[i].ToString()));
                imgs[i] = gray.Rotate(angles[i], new Gray(0), true);
            }

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (imgs != null) {
                imageIO1.OutImage = imgs[e.Node.Index];
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if(imgs==null) return;
            string dir = Path.GetDirectoryName(path);
            string name = Path.GetFileNameWithoutExtension(path);
            for (int i = 0; i < imgs.Length; i++) {
                imgs[i].Save(string.Format("{0}\\{1}_{2}.png", dir, name, angles[i]));
            }
        }
    }
}
