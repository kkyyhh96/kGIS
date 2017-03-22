namespace kGIS_App
{
    partial class ConnectPostgreSQL
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
            this.btnDatabaseConnect = new System.Windows.Forms.Button();
            this.tbxIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxPort = new System.Windows.Forms.TextBox();
            this.tbxDatabaseName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxUserName = new System.Windows.Forms.TextBox();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbxTableName = new System.Windows.Forms.TextBox();
            this.btnImportData = new System.Windows.Forms.Button();
            this.cmbPoint = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxShpPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnDatabaseConnect
            // 
            this.btnDatabaseConnect.Location = new System.Drawing.Point(278, 68);
            this.btnDatabaseConnect.Name = "btnDatabaseConnect";
            this.btnDatabaseConnect.Size = new System.Drawing.Size(75, 23);
            this.btnDatabaseConnect.TabIndex = 0;
            this.btnDatabaseConnect.Text = "Connect";
            this.btnDatabaseConnect.UseVisualStyleBackColor = true;
            this.btnDatabaseConnect.Click += new System.EventHandler(this.btnDatabaseConnect_Click);
            // 
            // tbxIP
            // 
            this.tbxIP.Location = new System.Drawing.Point(12, 24);
            this.tbxIP.Name = "tbxIP";
            this.tbxIP.Size = new System.Drawing.Size(100, 21);
            this.tbxIP.TabIndex = 1;
            this.tbxIP.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP";
            // 
            // tbxPort
            // 
            this.tbxPort.Location = new System.Drawing.Point(140, 24);
            this.tbxPort.Name = "tbxPort";
            this.tbxPort.Size = new System.Drawing.Size(100, 21);
            this.tbxPort.TabIndex = 3;
            this.tbxPort.Text = "5432";
            // 
            // tbxDatabaseName
            // 
            this.tbxDatabaseName.Location = new System.Drawing.Point(272, 24);
            this.tbxDatabaseName.Name = "tbxDatabaseName";
            this.tbxDatabaseName.Size = new System.Drawing.Size(100, 21);
            this.tbxDatabaseName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(270, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "Database_Name";
            // 
            // tbxUserName
            // 
            this.tbxUserName.Location = new System.Drawing.Point(12, 70);
            this.tbxUserName.Name = "tbxUserName";
            this.tbxUserName.Size = new System.Drawing.Size(100, 21);
            this.tbxUserName.TabIndex = 7;
            this.tbxUserName.Text = "postgres";
            // 
            // tbxPassword
            // 
            this.tbxPassword.Location = new System.Drawing.Point(140, 70);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.Size = new System.Drawing.Size(100, 21);
            this.tbxPassword.TabIndex = 8;
            this.tbxPassword.Text = "postgres";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "User_Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(138, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "Password";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(138, 139);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "Point";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 139);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 13;
            this.label10.Text = "Table_name";
            // 
            // tbxTableName
            // 
            this.tbxTableName.Location = new System.Drawing.Point(12, 154);
            this.tbxTableName.Name = "tbxTableName";
            this.tbxTableName.Size = new System.Drawing.Size(100, 21);
            this.tbxTableName.TabIndex = 12;
            // 
            // btnImportData
            // 
            this.btnImportData.Location = new System.Drawing.Point(278, 206);
            this.btnImportData.Name = "btnImportData";
            this.btnImportData.Size = new System.Drawing.Size(75, 23);
            this.btnImportData.TabIndex = 11;
            this.btnImportData.Text = "Import";
            this.btnImportData.UseVisualStyleBackColor = true;
            this.btnImportData.Click += new System.EventHandler(this.btnImportData_Click);
            // 
            // cmbPoint
            // 
            this.cmbPoint.FormattingEnabled = true;
            this.cmbPoint.Location = new System.Drawing.Point(140, 154);
            this.cmbPoint.Name = "cmbPoint";
            this.cmbPoint.Size = new System.Drawing.Size(121, 20);
            this.cmbPoint.TabIndex = 22;
            this.cmbPoint.DropDown += new System.EventHandler(this.cmbPoint_DropDown);
            this.cmbPoint.SelectedValueChanged += new System.EventHandler(this.cmbPoint_SelectedValueChanged);
            this.cmbPoint.Click += new System.EventHandler(this.cmbPoint_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 24;
            this.label6.Text = "Shp Path";
            // 
            // tbxShpPath
            // 
            this.tbxShpPath.Location = new System.Drawing.Point(12, 208);
            this.tbxShpPath.Name = "tbxShpPath";
            this.tbxShpPath.Size = new System.Drawing.Size(249, 21);
            this.tbxShpPath.TabIndex = 23;
            // 
            // ConnectPostgreSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 241);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbxShpPath);
            this.Controls.Add(this.cmbPoint);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbxTableName);
            this.Controls.Add(this.btnImportData);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxPassword);
            this.Controls.Add(this.tbxUserName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxDatabaseName);
            this.Controls.Add(this.tbxPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxIP);
            this.Controls.Add(this.btnDatabaseConnect);
            this.Name = "ConnectPostgreSQL";
            this.Text = "ConnectPostgreSQL";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConnectPostgreSQL_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDatabaseConnect;
        private System.Windows.Forms.TextBox tbxIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxPort;
        private System.Windows.Forms.TextBox tbxDatabaseName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxUserName;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbxTableName;
        private System.Windows.Forms.Button btnImportData;
        private System.Windows.Forms.ComboBox cmbPoint;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxShpPath;
    }
}