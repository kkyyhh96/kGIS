namespace kGIS_App
{
    partial class DouglasPeukerForm
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
            this.btnDouglasPeuker = new System.Windows.Forms.Button();
            this.cmbLayer = new System.Windows.Forms.ComboBox();
            this.tbxRadius = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxFilePath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDouglasPeuker
            // 
            this.btnDouglasPeuker.Location = new System.Drawing.Point(53, 139);
            this.btnDouglasPeuker.Name = "btnDouglasPeuker";
            this.btnDouglasPeuker.Size = new System.Drawing.Size(115, 23);
            this.btnDouglasPeuker.TabIndex = 0;
            this.btnDouglasPeuker.Text = "道格拉斯普客算法";
            this.btnDouglasPeuker.UseVisualStyleBackColor = true;
            this.btnDouglasPeuker.Click += new System.EventHandler(this.btnDouglasPeuker_Click);
            // 
            // cmbLayer
            // 
            this.cmbLayer.FormattingEnabled = true;
            this.cmbLayer.Location = new System.Drawing.Point(79, 6);
            this.cmbLayer.Name = "cmbLayer";
            this.cmbLayer.Size = new System.Drawing.Size(121, 20);
            this.cmbLayer.TabIndex = 1;
            // 
            // tbxRadius
            // 
            this.tbxRadius.Location = new System.Drawing.Point(79, 57);
            this.tbxRadius.Name = "tbxRadius";
            this.tbxRadius.Size = new System.Drawing.Size(121, 21);
            this.tbxRadius.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "限差";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "图层";
            // 
            // tbxFilePath
            // 
            this.tbxFilePath.Location = new System.Drawing.Point(79, 112);
            this.tbxFilePath.Name = "tbxFilePath";
            this.tbxFilePath.Size = new System.Drawing.Size(121, 21);
            this.tbxFilePath.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "保存路径";
            // 
            // DouglasPeukerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 174);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxFilePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxRadius);
            this.Controls.Add(this.cmbLayer);
            this.Controls.Add(this.btnDouglasPeuker);
            this.Name = "DouglasPeukerForm";
            this.Text = "DouglasPeukerForm";
            this.Load += new System.EventHandler(this.DouglasPeukerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDouglasPeuker;
        private System.Windows.Forms.ComboBox cmbLayer;
        private System.Windows.Forms.TextBox tbxRadius;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxFilePath;
        private System.Windows.Forms.Label label3;
    }
}