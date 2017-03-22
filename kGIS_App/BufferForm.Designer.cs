namespace kGIS_App
{
    partial class BufferForm
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
            this.cmbLayerName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.tbxRadius = new System.Windows.Forms.TextBox();
            this.tbxPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbLayerName
            // 
            this.cmbLayerName.FormattingEnabled = true;
            this.cmbLayerName.Location = new System.Drawing.Point(71, 6);
            this.cmbLayerName.Name = "cmbLayerName";
            this.cmbLayerName.Size = new System.Drawing.Size(201, 20);
            this.cmbLayerName.TabIndex = 3;
            this.cmbLayerName.SelectedIndexChanged += new System.EventHandler(this.cmbLayerName_SelectedIndexChanged);
            this.cmbLayerName.Click += new System.EventHandler(this.cmbLayerName_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "图层名称";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(197, 79);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tbxRadius
            // 
            this.tbxRadius.Location = new System.Drawing.Point(83, 79);
            this.tbxRadius.Name = "tbxRadius";
            this.tbxRadius.Size = new System.Drawing.Size(100, 21);
            this.tbxRadius.TabIndex = 5;
            // 
            // tbxPath
            // 
            this.tbxPath.Location = new System.Drawing.Point(83, 42);
            this.tbxPath.Name = "tbxPath";
            this.tbxPath.Size = new System.Drawing.Size(189, 21);
            this.tbxPath.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "输出路径";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "缓冲区半径";
            // 
            // BufferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 114);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxPath);
            this.Controls.Add(this.tbxRadius);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cmbLayerName);
            this.Controls.Add(this.label1);
            this.Name = "BufferForm";
            this.Text = "BufferForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbLayerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox tbxRadius;
        private System.Windows.Forms.TextBox tbxPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}