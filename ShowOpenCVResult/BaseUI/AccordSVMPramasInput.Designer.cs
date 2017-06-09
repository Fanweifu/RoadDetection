namespace ShowOpenCVResult
{
    partial class AccordSVMParamsInput
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cbStrategy = new System.Windows.Forms.ComboBox();
            this.btnEstimateC = new System.Windows.Forms.Button();
            this.btnEstimate = new System.Windows.Forms.Button();
            this.numTolerance = new System.Windows.Forms.NumericUpDown();
            this.numComplexity = new System.Windows.Forms.NumericUpDown();
            this.numConstant = new System.Windows.Forms.NumericUpDown();
            this.numCache = new System.Windows.Forms.NumericUpDown();
            this.numDegree = new System.Windows.Forms.NumericUpDown();
            this.numSigma = new System.Windows.Forms.NumericUpDown();
            this.rbPolynomial = new System.Windows.Forms.RadioButton();
            this.rbGaussian = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTolerance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numComplexity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numConstant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCache)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDegree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSigma)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cbStrategy);
            this.groupBox6.Controls.Add(this.btnEstimateC);
            this.groupBox6.Controls.Add(this.btnEstimate);
            this.groupBox6.Controls.Add(this.numTolerance);
            this.groupBox6.Controls.Add(this.numComplexity);
            this.groupBox6.Controls.Add(this.numConstant);
            this.groupBox6.Controls.Add(this.numCache);
            this.groupBox6.Controls.Add(this.numDegree);
            this.groupBox6.Controls.Add(this.numSigma);
            this.groupBox6.Controls.Add(this.rbPolynomial);
            this.groupBox6.Controls.Add(this.rbGaussian);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(279, 261);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "参数配置";
            // 
            // cbStrategy
            // 
            this.cbStrategy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbStrategy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStrategy.FormattingEnabled = true;
            this.cbStrategy.Location = new System.Drawing.Point(144, 228);
            this.cbStrategy.Name = "cbStrategy";
            this.cbStrategy.Size = new System.Drawing.Size(128, 20);
            this.cbStrategy.TabIndex = 9;
            // 
            // btnEstimateC
            // 
            this.btnEstimateC.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstimateC.Location = new System.Drawing.Point(71, 120);
            this.btnEstimateC.Name = "btnEstimateC";
            this.btnEstimateC.Size = new System.Drawing.Size(50, 18);
            this.btnEstimateC.TabIndex = 8;
            this.btnEstimateC.Text = "Estimate";
            this.btnEstimateC.UseVisualStyleBackColor = true;
            // 
            // btnEstimate
            // 
            this.btnEstimate.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstimate.Location = new System.Drawing.Point(59, 49);
            this.btnEstimate.Name = "btnEstimate";
            this.btnEstimate.Size = new System.Drawing.Size(60, 18);
            this.btnEstimate.TabIndex = 8;
            this.btnEstimate.Text = "Estimate";
            this.btnEstimate.UseVisualStyleBackColor = true;
            // 
            // numTolerance
            // 
            this.numTolerance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numTolerance.DecimalPlaces = 5;
            this.numTolerance.Location = new System.Drawing.Point(144, 172);
            this.numTolerance.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numTolerance.Name = "numTolerance";
            this.numTolerance.Size = new System.Drawing.Size(128, 21);
            this.numTolerance.TabIndex = 7;
            this.numTolerance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numTolerance.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            // 
            // numComplexity
            // 
            this.numComplexity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numComplexity.DecimalPlaces = 5;
            this.numComplexity.Location = new System.Drawing.Point(144, 145);
            this.numComplexity.Name = "numComplexity";
            this.numComplexity.Size = new System.Drawing.Size(128, 21);
            this.numComplexity.TabIndex = 7;
            this.numComplexity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numComplexity.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            // 
            // numConstant
            // 
            this.numConstant.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numConstant.DecimalPlaces = 4;
            this.numConstant.Location = new System.Drawing.Point(125, 120);
            this.numConstant.Name = "numConstant";
            this.numConstant.Size = new System.Drawing.Size(147, 21);
            this.numConstant.TabIndex = 7;
            this.numConstant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numConstant.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numCache
            // 
            this.numCache.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numCache.Location = new System.Drawing.Point(144, 200);
            this.numCache.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numCache.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numCache.Name = "numCache";
            this.numCache.Size = new System.Drawing.Size(128, 21);
            this.numCache.TabIndex = 7;
            this.numCache.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numCache.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // numDegree
            // 
            this.numDegree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numDegree.Location = new System.Drawing.Point(125, 96);
            this.numDegree.Name = "numDegree";
            this.numDegree.Size = new System.Drawing.Size(147, 21);
            this.numDegree.TabIndex = 7;
            this.numDegree.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numDegree.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numSigma
            // 
            this.numSigma.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numSigma.DecimalPlaces = 4;
            this.numSigma.Location = new System.Drawing.Point(125, 49);
            this.numSigma.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSigma.Name = "numSigma";
            this.numSigma.Size = new System.Drawing.Size(147, 21);
            this.numSigma.TabIndex = 7;
            this.numSigma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numSigma.Value = new decimal(new int[] {
            62,
            0,
            0,
            65536});
            // 
            // rbPolynomial
            // 
            this.rbPolynomial.AutoSize = true;
            this.rbPolynomial.Checked = true;
            this.rbPolynomial.Location = new System.Drawing.Point(6, 75);
            this.rbPolynomial.Name = "rbPolynomial";
            this.rbPolynomial.Size = new System.Drawing.Size(71, 16);
            this.rbPolynomial.TabIndex = 6;
            this.rbPolynomial.TabStop = true;
            this.rbPolynomial.Text = "多项式核";
            this.rbPolynomial.UseVisualStyleBackColor = true;
            // 
            // rbGaussian
            // 
            this.rbGaussian.AutoSize = true;
            this.rbGaussian.Location = new System.Drawing.Point(6, 27);
            this.rbGaussian.Name = "rbGaussian";
            this.rbGaussian.Size = new System.Drawing.Size(83, 16);
            this.rbGaussian.TabIndex = 6;
            this.rbGaussian.Text = "高斯核函数";
            this.rbGaussian.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 231);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "Strategy:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "Cache size:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tolerance:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "Complexity:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "Constant:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Degree:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sigma:";
            // 
            // AccordSVMParamsInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox6);
            this.Name = "AccordSVMParamsInput";
            this.Size = new System.Drawing.Size(279, 261);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTolerance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numComplexity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numConstant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCache)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDegree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSigma)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cbStrategy;
        private System.Windows.Forms.Button btnEstimateC;
        private System.Windows.Forms.Button btnEstimate;
        private System.Windows.Forms.NumericUpDown numTolerance;
        private System.Windows.Forms.NumericUpDown numComplexity;
        private System.Windows.Forms.NumericUpDown numConstant;
        private System.Windows.Forms.NumericUpDown numCache;
        private System.Windows.Forms.NumericUpDown numDegree;
        private System.Windows.Forms.NumericUpDown numSigma;
        private System.Windows.Forms.RadioButton rbPolynomial;
        private System.Windows.Forms.RadioButton rbGaussian;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
    }
}

