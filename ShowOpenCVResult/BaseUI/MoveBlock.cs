using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace ShowOpenCVResult
{
    public partial class MoveBlock : DockContent
    {
        public MoveBlock(string name)
        {
            this.Name = name;
            InitializeComponent();
        }
        public MoveBlock()
        {
            InitializeComponent();
        }

       

         private void FrmFunction_DockStateChanged(object sender, EventArgs e)
       {
              if (this.DockState ==DockState.Unknown || this.DockState == DockState.Hidden)
              {
                    return;
              }
              AppConfig.ms_FrmFunction =this.DockState;
            
       }  
       private void FrmFunction_FormClosing(object sender, FormClosingEventArgs e)
       {
         
       }

       private void FrmFunction_Load(object sender, EventArgs e)
       {

       }

    
    }

    class AppConfig
    {
        public static DockState ms_FrmFunction = DockState.DockLeft;   // 功能窗体，左端停靠  
    }
}
