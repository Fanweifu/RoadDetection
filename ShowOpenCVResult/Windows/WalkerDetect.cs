using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShowOpenCVResult.Windows
{
    public partial class WalkerDetect : MoveBlock
    {
        public WalkerDetect()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var input = OpencvForm.GetImage();
            if (input == null) return;
            imageIO1.SetInput((input as Image<Bgr, Byte>));
            int time=0;
            imageIO1.OutImage=PedestrianDetection.FindPedestrian.Run((imageIO1.InImage as Image<Bgr, Byte>).Mat,out time);
        }

        
        

    }
}
