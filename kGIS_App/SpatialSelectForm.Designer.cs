namespace kGIS_App
{
    partial class SpatialSelectForm
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
            this.rbnClick = new System.Windows.Forms.RadioButton();
            this.rbnRectangle = new System.Windows.Forms.RadioButton();
            this.rbnCircle = new System.Windows.Forms.RadioButton();
            this.cmbLayer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbnSetRadius = new System.Windows.Forms.RadioButton();
            this.tbxRadius = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // rbnClick
            // 
            this.rbnClick.AutoSize = true;
            this.rbnClick.Location = new System.Drawing.Point(191, 11);
            this.rbnClick.Name = "rbnClick";
            this.rbnClick.Size = new System.Drawing.Size(47, 16);
            this.rbnClick.TabIndex = 0;
            this.rbnClick.TabStop = true;
            this.rbnClick.Text = "点选";
            this.rbnClick.UseVisualStyleBackColor = true;
            this.rbnClick.CheckedChanged += new System.EventHandler(this.rbnClick_CheckedChanged);
            // 
            // rbnRectangle
            // 
            this.rbnRectangle.AutoSize = true;
            this.rbnRectangle.Location = new System.Drawing.Point(191, 33);
            this.rbnRectangle.Name = "rbnRectangle";
            this.rbnRectangle.Size = new System.Drawing.Size(71, 16);
            this.rbnRectangle.TabIndex = 1;
            this.rbnRectangle.TabStop = true;
            this.rbnRectangle.Text = "矩形框选";
            this.rbnRectangle.UseVisualStyleBackColor = true;
            this.rbnRectangle.CheckedChanged += new System.EventHandler(this.rbnRectangle_CheckedChanged);
            // 
            // rbnCircle
            // 
            this.rbnCircle.AutoSize = true;
            this.rbnCircle.Location = new System.Drawing.Point(191, 55);
            this.rbnCircle.Name = "rbnCircle";
            this.rbnCircle.Size = new System.Drawing.Size(71, 16);
            this.rbnCircle.TabIndex = 2;
            this.rbnCircle.TabStop = true;
            this.rbnCircle.Text = "圆形框选";
            this.rbnCircle.UseVisualStyleBackColor = true;
            this.rbnCircle.CheckedChanged += new System.EventHandler(this.rbnCircle_CheckedChanged);
            // 
            // cmbLayer
            // 
            this.cmbLayer.FormattingEnabled = true;
            this.cmbLayer.Location = new System.Drawing.Point(59, 11);
            this.cmbLayer.Name = "cmbLayer";
            this.cmbLayer.Size = new System.Drawing.Size(121, 20);
            this.cmbLayer.TabIndex = 4;
            this.cmbLayer.SelectedIndexChanged += new System.EventHandler(this.cmbLayer_SelectedIndexChanged);
            this.cmbLayer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbLayer_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "图层";
            // 
            // rbnSetRadius
            // 
            this.rbnSetRadius.AutoSize = true;
            this.rbnSetRadius.Location = new System.Drawing.Point(12, 55);
            this.rbnSetRadius.Name = "rbnSetRadius";
            this.rbnSetRadius.Size = new System.Drawing.Size(71, 16);
            this.rbnSetRadius.TabIndex = 6;
            this.rbnSetRadius.TabStop = true;
            this.rbnSetRadius.Text = "设定半径";
            this.rbnSetRadius.UseVisualStyleBackColor = true;
            this.rbnSetRadius.CheckedChanged += new System.EventHandler(this.rbnSetRadius_CheckedChanged);
            // 
            // tbxRadius
            // 
            this.tbxRadius.Location = new System.Drawing.Point(12, 77);
            this.tbxRadius.Name = "tbxRadius";
            this.tbxRadius.Size = new System.Drawing.Size(100, 21);
            this.tbxRadius.TabIndex = 7;
            this.tbxRadius.TextChanged += new System.EventHandler(this.tbxRadius_TextChanged);
            // 
            // SpatialSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 115);
            this.Controls.Add(this.tbxRadius);
            this.Controls.Add(this.rbnSetRadius);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbLayer);
            this.Controls.Add(this.rbnCircle);
            this.Controls.Add(this.rbnRectangle);
            this.Controls.Add(this.rbnClick);
            this.Name = "SpatialSelectForm";
            this.Text = "SpatialSelectForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbnClick;
        private System.Windows.Forms.RadioButton rbnRectangle;
        private System.Windows.Forms.RadioButton rbnCircle;
        private System.Windows.Forms.ComboBox cmbLayer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbnSetRadius;
        private System.Windows.Forms.TextBox tbxRadius;
    }
}