namespace kGIS_App
{
    partial class DensityAnalystForm
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
            this.btnKernelDensity = new System.Windows.Forms.Button();
            this.btnPointDensity = new System.Windows.Forms.Button();
            this.cmbField = new System.Windows.Forms.ComboBox();
            this.cmbInDataset = new System.Windows.Forms.ComboBox();
            this.tbxResolution = new System.Windows.Forms.TextBox();
            this.tbxSearchRadius = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxOutDataset = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnKernelDensity
            // 
            this.btnKernelDensity.Location = new System.Drawing.Point(83, 105);
            this.btnKernelDensity.Name = "btnKernelDensity";
            this.btnKernelDensity.Size = new System.Drawing.Size(75, 23);
            this.btnKernelDensity.TabIndex = 0;
            this.btnKernelDensity.Text = "核密度分析";
            this.btnKernelDensity.UseVisualStyleBackColor = true;
            this.btnKernelDensity.Click += new System.EventHandler(this.btnKernelDensity_Click);
            // 
            // btnPointDensity
            // 
            this.btnPointDensity.Location = new System.Drawing.Point(83, 105);
            this.btnPointDensity.Name = "btnPointDensity";
            this.btnPointDensity.Size = new System.Drawing.Size(75, 23);
            this.btnPointDensity.TabIndex = 1;
            this.btnPointDensity.Text = "点密度分析";
            this.btnPointDensity.UseVisualStyleBackColor = true;
            this.btnPointDensity.Click += new System.EventHandler(this.btnPointDensity_Click);
            // 
            // cmbField
            // 
            this.cmbField.FormattingEnabled = true;
            this.cmbField.Location = new System.Drawing.Point(142, 55);
            this.cmbField.Name = "cmbField";
            this.cmbField.Size = new System.Drawing.Size(121, 20);
            this.cmbField.TabIndex = 2;
            this.cmbField.SelectedIndexChanged += new System.EventHandler(this.cmbField_SelectedIndexChanged);
            // 
            // cmbInDataset
            // 
            this.cmbInDataset.FormattingEnabled = true;
            this.cmbInDataset.Location = new System.Drawing.Point(142, 12);
            this.cmbInDataset.Name = "cmbInDataset";
            this.cmbInDataset.Size = new System.Drawing.Size(121, 20);
            this.cmbInDataset.TabIndex = 1;
            this.cmbInDataset.SelectedIndexChanged += new System.EventHandler(this.cmbInDataset_SelectedIndexChanged);
            this.cmbInDataset.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbInDataset_MouseClick);
            // 
            // tbxResolution
            // 
            this.tbxResolution.Location = new System.Drawing.Point(142, 101);
            this.tbxResolution.Name = "tbxResolution";
            this.tbxResolution.Size = new System.Drawing.Size(100, 21);
            this.tbxResolution.TabIndex = 3;
            this.tbxResolution.TextChanged += new System.EventHandler(this.tbxResolution_TextChanged);
            // 
            // tbxSearchRadius
            // 
            this.tbxSearchRadius.Location = new System.Drawing.Point(126, 16);
            this.tbxSearchRadius.Name = "tbxSearchRadius";
            this.tbxSearchRadius.Size = new System.Drawing.Size(100, 21);
            this.tbxSearchRadius.TabIndex = 4;
            this.tbxSearchRadius.TextChanged += new System.EventHandler(this.tbxSearchRadius_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "输入数据集";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "字段";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "搜索半径";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "像元大小";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 174);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(260, 160);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnKernelDensity);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.tbxSearchRadius);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(252, 134);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "核密度分析";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.comboBox3);
            this.tabPage2.Controls.Add(this.btnPointDensity);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(252, 134);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "点密度分析";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "搜索半径";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(126, 57);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "形状";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(115, 19);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 20);
            this.comboBox3.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "输入数据集";
            // 
            // tbxOutDataset
            // 
            this.tbxOutDataset.Location = new System.Drawing.Point(142, 147);
            this.tbxOutDataset.Name = "tbxOutDataset";
            this.tbxOutDataset.Size = new System.Drawing.Size(100, 21);
            this.tbxOutDataset.TabIndex = 12;
            // 
            // DensityAnalystForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 346);
            this.Controls.Add(this.tbxOutDataset);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxResolution);
            this.Controls.Add(this.cmbInDataset);
            this.Controls.Add(this.cmbField);
            this.Name = "DensityAnalystForm";
            this.Text = "DensityAnalystForm";
            this.Load += new System.EventHandler(this.DensityAnalystForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnKernelDensity;
        private System.Windows.Forms.Button btnPointDensity;
        private System.Windows.Forms.ComboBox cmbField;
        private System.Windows.Forms.ComboBox cmbInDataset;
        private System.Windows.Forms.TextBox tbxResolution;
        private System.Windows.Forms.TextBox tbxSearchRadius;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxOutDataset;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
    }
}