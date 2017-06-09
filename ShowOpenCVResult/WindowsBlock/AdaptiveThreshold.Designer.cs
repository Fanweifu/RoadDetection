namespace ShowOpenCVResult
{
    partial class AdaptiveThreshold
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdaptiveThreshold));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.prama1Bar = new ShowOpenCVResult.MyTrackBar();
            this.blockSizeBar = new ShowOpenCVResult.MyTrackBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSave = new System.Windows.Forms.ToolStripButton();
            this.imageIOControl1 = new ShowOpenCVResult.ImageIO();
            this.checkUseOtus = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkUseOtus);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.prama1Bar);
            this.panel1.Controls.Add(this.blockSizeBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(723, 108);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "AdaptiveThresholdType";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(223, 4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(53, 16);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.Text = "MeanC";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(140, 4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(77, 16);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "GaussianC";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // prama1Bar
            // 
            this.prama1Bar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.prama1Bar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.prama1Bar.Location = new System.Drawing.Point(0, 22);
            this.prama1Bar.Maximum = 100;
            this.prama1Bar.Minimum = -100;
            this.prama1Bar.Name = "prama1Bar";
            this.prama1Bar.Size = new System.Drawing.Size(723, 43);
            this.prama1Bar.TabIndex = 1;
            this.prama1Bar.Title = "Prama1";
            this.prama1Bar.Value = 0;
            this.prama1Bar.ValueChanged += new System.EventHandler(this.myTrackBar1_ValueChanged);
            // 
            // blockSizeBar
            // 
            this.blockSizeBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.blockSizeBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.blockSizeBar.Location = new System.Drawing.Point(0, 65);
            this.blockSizeBar.Maximum = 400;
            this.blockSizeBar.Minimum = 1;
            this.blockSizeBar.Name = "blockSizeBar";
            this.blockSizeBar.Size = new System.Drawing.Size(723, 43);
            this.blockSizeBar.TabIndex = 0;
            this.blockSizeBar.Title = "BlockSize";
            this.blockSizeBar.Value = 1;
            this.blockSizeBar.ValueChanged += new System.EventHandler(this.myTrackBar1_ValueChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnOpen,
            this.tsbtnSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(723, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnOpen
            // 
            this.tsbtnOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnOpen.Image")));
            this.tsbtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnOpen.Name = "tsbtnOpen";
            this.tsbtnOpen.Size = new System.Drawing.Size(60, 22);
            this.tsbtnOpen.Text = "Open";
            this.tsbtnOpen.Click += new System.EventHandler(this.tsbtnOpen_Click);
            // 
            // tsbtnSave
            // 
            this.tsbtnSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSave.Image")));
            this.tsbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSave.Name = "tsbtnSave";
            this.tsbtnSave.Size = new System.Drawing.Size(99, 22);
            this.tsbtnSave.Text = "Save Setting";
            this.tsbtnSave.Click += new System.EventHandler(this.tsbtnSave_Click);
            // 
            // imageIOControl1
            // 
            this.imageIOControl1.AutoDispose = false;
            this.imageIOControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageIOControl1.InImage = null;
            this.imageIOControl1.Location = new System.Drawing.Point(0, 133);
            this.imageIOControl1.Name = "imageIOControl1";
            this.imageIOControl1.OutImage = null;
            this.imageIOControl1.Size = new System.Drawing.Size(723, 311);
            this.imageIOControl1.SpOrientation = System.Windows.Forms.Orientation.Vertical;
            this.imageIOControl1.TabIndex = 2;
            this.imageIOControl1.DoImgChange += new System.EventHandler(this.imageIOControl1_DoImgChange);
            // 
            // checkUseOtus
            // 
            this.checkUseOtus.AutoSize = true;
            this.checkUseOtus.Location = new System.Drawing.Point(298, 4);
            this.checkUseOtus.Name = "checkUseOtus";
            this.checkUseOtus.Size = new System.Drawing.Size(144, 16);
            this.checkUseOtus.TabIndex = 5;
            this.checkUseOtus.Text = "combineOutsThreshold";
            this.checkUseOtus.UseVisualStyleBackColor = true;
            // 
            // AdaptiveThreshold
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 444);
            this.Controls.Add(this.imageIOControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "AdaptiveThreshold";
            this.Text = "BitmapAdaptiveThreshold";
            this.Load += new System.EventHandler(this.AdaptiveThreshold_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnOpen;
        private System.Windows.Forms.Panel panel1;
        private ImageIO imageIOControl1;
        private MyTrackBar prama1Bar;
        private MyTrackBar blockSizeBar;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton tsbtnSave;
        private System.Windows.Forms.CheckBox checkUseOtus;
    }
}