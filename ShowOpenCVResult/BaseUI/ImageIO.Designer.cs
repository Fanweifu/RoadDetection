namespace ShowOpenCVResult
{
    partial class ImageIO
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.imageBoxInput = new ShowOpenCVResult.DrawImageBox();
            this.imageBoxOutput = new ShowOpenCVResult.DrawImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.imageBoxInput);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.imageBoxOutput);
            this.splitContainer1.Size = new System.Drawing.Size(600, 300);
            this.splitContainer1.SplitterDistance = 297;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.Resize += new System.EventHandler(this.splitContainer1_Resize);
            // 
            // imageBox1
            // 
           
            this.imageBoxInput.AllowDrop = true;
            this.imageBoxInput.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.imageBoxInput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imageBoxInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageBoxInput.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.RightClickMenu;
            this.imageBoxInput.Location = new System.Drawing.Point(0, 0);
            this.imageBoxInput.Name = "imageBox1";
            this.imageBoxInput.Size = new System.Drawing.Size(297, 300);
            this.imageBoxInput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBoxInput.TabIndex = 0;
            this.imageBoxInput.TabStop = false;
            // 
            // imageBox2
            // 

            this.imageBoxOutput.AllowDrop = true;
            this.imageBoxOutput.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.imageBoxOutput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imageBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageBoxOutput.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.RightClickMenu;
            this.imageBoxOutput.Location = new System.Drawing.Point(0, 0);
            this.imageBoxOutput.Name = "imageBox2";
            this.imageBoxOutput.Size = new System.Drawing.Size(299, 300);
            this.imageBoxOutput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBoxOutput.TabIndex = 0;
            this.imageBoxOutput.TabStop = false;
            // 
            // ImageIOControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ImageIOControl";
            this.Size = new System.Drawing.Size(600, 300);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxOutput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DrawImageBox imageBoxInput;
        private DrawImageBox imageBoxOutput;
    }
}
