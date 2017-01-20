namespace kGIS_App
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.mainMapControl = new ESRI.ArcGIS.Controls.AxMapControl();
            this.button1 = new System.Windows.Forms.Button();
            this.mapViewer = new System.Windows.Forms.TabControl();
            this.mapTabPage = new System.Windows.Forms.TabPage();
            this.pageLayoutTabPage = new System.Windows.Forms.TabPage();
            this.mainPageLayout = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenMxdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.另存为工作空间ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.另存为工作空间ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadShpDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadGridDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.mainTocControl = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.eagleEyeMapControl = new ESRI.ArcGIS.Controls.AxMapControl();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainMapControl)).BeginInit();
            this.mapViewer.SuspendLayout();
            this.mapTabPage.SuspendLayout();
            this.pageLayoutTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPageLayout)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainTocControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eagleEyeMapControl)).BeginInit();
            this.SuspendLayout();
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(775, 12);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 0;
            // 
            // mainMapControl
            // 
            this.mainMapControl.Location = new System.Drawing.Point(6, 6);
            this.mainMapControl.Name = "mainMapControl";
            this.mainMapControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mainMapControl.OcxState")));
            this.mainMapControl.Size = new System.Drawing.Size(480, 462);
            this.mainMapControl.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(54, 258);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // mapViewer
            // 
            this.mapViewer.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.mapViewer.Controls.Add(this.mapTabPage);
            this.mapViewer.Controls.Add(this.pageLayoutTabPage);
            this.mapViewer.Location = new System.Drawing.Point(328, 62);
            this.mapViewer.Name = "mapViewer";
            this.mapViewer.SelectedIndex = 0;
            this.mapViewer.Size = new System.Drawing.Size(500, 500);
            this.mapViewer.TabIndex = 3;
            // 
            // mapTabPage
            // 
            this.mapTabPage.Controls.Add(this.mainMapControl);
            this.mapTabPage.Location = new System.Drawing.Point(4, 4);
            this.mapTabPage.Name = "mapTabPage";
            this.mapTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.mapTabPage.Size = new System.Drawing.Size(492, 474);
            this.mapTabPage.TabIndex = 0;
            this.mapTabPage.Text = "数据视图";
            this.mapTabPage.UseVisualStyleBackColor = true;
            // 
            // pageLayoutTabPage
            // 
            this.pageLayoutTabPage.Controls.Add(this.mainPageLayout);
            this.pageLayoutTabPage.Location = new System.Drawing.Point(4, 4);
            this.pageLayoutTabPage.Name = "pageLayoutTabPage";
            this.pageLayoutTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.pageLayoutTabPage.Size = new System.Drawing.Size(492, 474);
            this.pageLayoutTabPage.TabIndex = 1;
            this.pageLayoutTabPage.Text = "布局视图";
            this.pageLayoutTabPage.UseVisualStyleBackColor = true;
            // 
            // mainPageLayout
            // 
            this.mainPageLayout.Location = new System.Drawing.Point(7, 7);
            this.mainPageLayout.Name = "mainPageLayout";
            this.mainPageLayout.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mainPageLayout.OcxState")));
            this.mainPageLayout.Size = new System.Drawing.Size(479, 461);
            this.mainPageLayout.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.数据ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(840, 25);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建ToolStripMenuItem,
            this.OpenMxdToolStripMenuItem,
            this.另存为工作空间ToolStripMenuItem,
            this.另存为工作空间ToolStripMenuItem1});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.新建ToolStripMenuItem.Text = "新建工作空间";
            // 
            // OpenMxdToolStripMenuItem
            // 
            this.OpenMxdToolStripMenuItem.Name = "OpenMxdToolStripMenuItem";
            this.OpenMxdToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.OpenMxdToolStripMenuItem.Text = "打开工作空间";
            this.OpenMxdToolStripMenuItem.Click += new System.EventHandler(this.OpenMxdToolStripMenuItem_Click);
            // 
            // 另存为工作空间ToolStripMenuItem
            // 
            this.另存为工作空间ToolStripMenuItem.Name = "另存为工作空间ToolStripMenuItem";
            this.另存为工作空间ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.另存为工作空间ToolStripMenuItem.Text = "保存工作空间";
            // 
            // 另存为工作空间ToolStripMenuItem1
            // 
            this.另存为工作空间ToolStripMenuItem1.Name = "另存为工作空间ToolStripMenuItem1";
            this.另存为工作空间ToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.另存为工作空间ToolStripMenuItem1.Text = "另存为工作空间";
            // 
            // 数据ToolStripMenuItem
            // 
            this.数据ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadShpDocumentToolStripMenuItem,
            this.LoadGridDataToolStripMenuItem});
            this.数据ToolStripMenuItem.Name = "数据ToolStripMenuItem";
            this.数据ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.数据ToolStripMenuItem.Text = "数据";
            // 
            // LoadShpDocumentToolStripMenuItem
            // 
            this.LoadShpDocumentToolStripMenuItem.Name = "LoadShpDocumentToolStripMenuItem";
            this.LoadShpDocumentToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.LoadShpDocumentToolStripMenuItem.Text = "加载shp文档";
            this.LoadShpDocumentToolStripMenuItem.Click += new System.EventHandler(this.LoadShpDocumentToolStripMenuItem_Click);
            // 
            // LoadGridDataToolStripMenuItem
            // 
            this.LoadGridDataToolStripMenuItem.Name = "LoadGridDataToolStripMenuItem";
            this.LoadGridDataToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.LoadGridDataToolStripMenuItem.Text = "加载栅格数据";
            this.LoadGridDataToolStripMenuItem.Click += new System.EventHandler(this.LoadGridDataToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 545);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(840, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 28);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(828, 28);
            this.axToolbarControl1.TabIndex = 7;
            // 
            // mainTocControl
            // 
            this.mainTocControl.Location = new System.Drawing.Point(0, 62);
            this.mainTocControl.Name = "mainTocControl";
            this.mainTocControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mainTocControl.OcxState")));
            this.mainTocControl.Size = new System.Drawing.Size(322, 265);
            this.mainTocControl.TabIndex = 8;
            // 
            // eagleEyeMapControl
            // 
            this.eagleEyeMapControl.Location = new System.Drawing.Point(0, 336);
            this.eagleEyeMapControl.Name = "eagleEyeMapControl";
            this.eagleEyeMapControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("eagleEyeMapControl.OcxState")));
            this.eagleEyeMapControl.Size = new System.Drawing.Size(322, 206);
            this.eagleEyeMapControl.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 567);
            this.Controls.Add(this.eagleEyeMapControl);
            this.Controls.Add(this.mapViewer);
            this.Controls.Add(this.mainTocControl);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.axLicenseControl1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainMapControl)).EndInit();
            this.mapViewer.ResumeLayout(false);
            this.mapTabPage.ResumeLayout(false);
            this.pageLayoutTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainPageLayout)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainTocControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eagleEyeMapControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxMapControl mainMapControl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl mapViewer;
        private System.Windows.Forms.TabPage mapTabPage;
        private System.Windows.Forms.TabPage pageLayoutTabPage;
        private ESRI.ArcGIS.Controls.AxPageLayoutControl mainPageLayout;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenMxdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 另存为工作空间ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private ESRI.ArcGIS.Controls.AxTOCControl mainTocControl;
        private ESRI.ArcGIS.Controls.AxMapControl eagleEyeMapControl;
        private System.Windows.Forms.ToolStripMenuItem 另存为工作空间ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadShpDocumentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadGridDataToolStripMenuItem;
    }
}

