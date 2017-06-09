namespace ShowOpenCVResult
{
    partial class ORC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ORC));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnOpenImg = new System.Windows.Forms.ToolStripButton();
            this.gboxParams = new System.Windows.Forms.GroupBox();
            this.numRectY = new System.Windows.Forms.NumericUpDown();
            this.numRectX = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imageIO1 = new ShowOpenCVResult.ImageIO();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.toolStrip1.SuspendLayout();
            this.gboxParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRectY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRectX)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnOpenImg});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(766, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnOpenImg
            // 
            this.tsbtnOpenImg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnOpenImg.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnOpenImg.Image")));
            this.tsbtnOpenImg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnOpenImg.Name = "tsbtnOpenImg";
            this.tsbtnOpenImg.Size = new System.Drawing.Size(23, 22);
            this.tsbtnOpenImg.Text = "7";
            this.tsbtnOpenImg.Click += new System.EventHandler(this.tsbtnOpenImg_Click);
            // 
            // gboxParams
            // 
            this.gboxParams.Controls.Add(this.numRectY);
            this.gboxParams.Controls.Add(this.numRectX);
            this.gboxParams.Dock = System.Windows.Forms.DockStyle.Top;
            this.gboxParams.Location = new System.Drawing.Point(0, 25);
            this.gboxParams.Name = "gboxParams";
            this.gboxParams.Size = new System.Drawing.Size(766, 100);
            this.gboxParams.TabIndex = 1;
            this.gboxParams.TabStop = false;
            this.gboxParams.Text = "Params";
            // 
            // numRectY
            // 
            this.numRectY.Location = new System.Drawing.Point(12, 47);
            this.numRectY.Name = "numRectY";
            this.numRectY.Size = new System.Drawing.Size(98, 21);
            this.numRectY.TabIndex = 1;
            this.numRectY.ValueChanged += new System.EventHandler(this.numRectY_ValueChanged);
            // 
            // numRectX
            // 
            this.numRectX.Location = new System.Drawing.Point(12, 20);
            this.numRectX.Name = "numRectX";
            this.numRectX.Size = new System.Drawing.Size(98, 21);
            this.numRectX.TabIndex = 0;
            this.numRectX.ValueChanged += new System.EventHandler(this.numRectX_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.imageIO1);
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 125);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(766, 319);
            this.panel1.TabIndex = 3;
            // 
            // imageIO1
            // 
            this.imageIO1.AutoDispose = false;
            this.imageIO1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageIO1.InImage = null;
            this.imageIO1.Location = new System.Drawing.Point(0, 0);
            this.imageIO1.Name = "imageIO1";
            this.imageIO1.OutImage = null;
            this.imageIO1.Size = new System.Drawing.Size(605, 319);
            this.imageIO1.SpOrientation = System.Windows.Forms.Orientation.Vertical;
            this.imageIO1.TabIndex = 4;
            this.imageIO1.DoImgChange += new System.EventHandler(this.imageIO1_DoImgChange);
            this.imageIO1.AfterImgLoaded += new System.EventHandler(this.imageIO1_AfterImgLoaded);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.richTextBox1.Location = new System.Drawing.Point(605, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(161, 319);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // ORC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 444);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gboxParams);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ORC";
            this.Text = "ORC";
            this.Load += new System.EventHandler(this.ORC_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gboxParams.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numRectY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRectX)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnOpenImg;
        private System.Windows.Forms.GroupBox gboxParams;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private ImageIO imageIO1;
        private System.Windows.Forms.NumericUpDown numRectY;
        private System.Windows.Forms.NumericUpDown numRectX;
    }
}