namespace kGIS_App
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.mainMapControl = new ESRI.ArcGIS.Controls.AxMapControl();
            this.button1 = new System.Windows.Forms.Button();
            this.mapViewer = new System.Windows.Forms.TabControl();
            this.mapTabPage = new System.Windows.Forms.TabPage();
            this.pageLayoutTabPage = new System.Windows.Forms.TabPage();
            this.mainPageLayout = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.�ļ�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewWorkFactoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenMxdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveWorkFactorySpaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsWorkFactorySpaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadShpDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadGridDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadPostGISDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadPersonalDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.LargeScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SmallScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LargeScaleRecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SmallScaleRecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.��ѯToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AttributeQueryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SpatialQueryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ʸ�����ݿռ����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BufferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.���ӷ���ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ʸդת��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.դ�����ݿռ����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.դ�����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.դ��ͳ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DensityAnalystToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�ط���ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.mainTocControl = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.eagleEyeMapControl = new ESRI.ArcGIS.Controls.AxMapControl();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AttributeFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.contextMenuStrip2.SuspendLayout();
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
            this.mainMapControl.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.mainMapControl_OnMouseDown);
            this.mainMapControl.OnExtentUpdated += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnExtentUpdatedEventHandler(this.mainMapControl_OnExtentUpdated);
            this.mainMapControl.OnMapReplaced += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMapReplacedEventHandler(this.mainMapControl_OnMapReplaced);
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
            this.mapViewer.Location = new System.Drawing.Point(330, 70);
            this.mapViewer.Name = "mapViewer";
            this.mapViewer.SelectedIndex = 0;
            this.mapViewer.Size = new System.Drawing.Size(500, 490);
            this.mapViewer.TabIndex = 3;
            // 
            // mapTabPage
            // 
            this.mapTabPage.Controls.Add(this.mainMapControl);
            this.mapTabPage.Location = new System.Drawing.Point(4, 4);
            this.mapTabPage.Name = "mapTabPage";
            this.mapTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.mapTabPage.Size = new System.Drawing.Size(492, 464);
            this.mapTabPage.TabIndex = 0;
            this.mapTabPage.Text = "������ͼ";
            this.mapTabPage.UseVisualStyleBackColor = true;
            // 
            // pageLayoutTabPage
            // 
            this.pageLayoutTabPage.Controls.Add(this.mainPageLayout);
            this.pageLayoutTabPage.Location = new System.Drawing.Point(4, 4);
            this.pageLayoutTabPage.Name = "pageLayoutTabPage";
            this.pageLayoutTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.pageLayoutTabPage.Size = new System.Drawing.Size(492, 464);
            this.pageLayoutTabPage.TabIndex = 1;
            this.pageLayoutTabPage.Text = "������ͼ";
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
            this.�ļ�ToolStripMenuItem,
            this.����ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.��ѯToolStripMenuItem,
            this.ʸ�����ݿռ����ToolStripMenuItem,
            this.դ�����ݿռ����ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(840, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // �ļ�ToolStripMenuItem
            // 
            this.�ļ�ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewWorkFactoryToolStripMenuItem,
            this.OpenMxdToolStripMenuItem,
            this.SaveWorkFactorySpaceToolStripMenuItem,
            this.SaveAsWorkFactorySpaceToolStripMenuItem});
            this.�ļ�ToolStripMenuItem.Name = "�ļ�ToolStripMenuItem";
            this.�ļ�ToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.�ļ�ToolStripMenuItem.Text = "�ļ�";
            // 
            // NewWorkFactoryToolStripMenuItem
            // 
            this.NewWorkFactoryToolStripMenuItem.Name = "NewWorkFactoryToolStripMenuItem";
            this.NewWorkFactoryToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.NewWorkFactoryToolStripMenuItem.Text = "�½������ռ�";
            this.NewWorkFactoryToolStripMenuItem.Click += new System.EventHandler(this.NewWorkFactoryToolStripMenuItem_Click);
            // 
            // OpenMxdToolStripMenuItem
            // 
            this.OpenMxdToolStripMenuItem.Name = "OpenMxdToolStripMenuItem";
            this.OpenMxdToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.OpenMxdToolStripMenuItem.Text = "�򿪹����ռ�";
            this.OpenMxdToolStripMenuItem.Click += new System.EventHandler(this.OpenMxdToolStripMenuItem_Click);
            // 
            // SaveWorkFactorySpaceToolStripMenuItem
            // 
            this.SaveWorkFactorySpaceToolStripMenuItem.Name = "SaveWorkFactorySpaceToolStripMenuItem";
            this.SaveWorkFactorySpaceToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.SaveWorkFactorySpaceToolStripMenuItem.Text = "���湤���ռ�";
            this.SaveWorkFactorySpaceToolStripMenuItem.Click += new System.EventHandler(this.SaveWorkFactorySpaceToolStripMenuItem_Click);
            // 
            // SaveAsWorkFactorySpaceToolStripMenuItem
            // 
            this.SaveAsWorkFactorySpaceToolStripMenuItem.Name = "SaveAsWorkFactorySpaceToolStripMenuItem";
            this.SaveAsWorkFactorySpaceToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.SaveAsWorkFactorySpaceToolStripMenuItem.Text = "���Ϊ�����ռ�";
            this.SaveAsWorkFactorySpaceToolStripMenuItem.Click += new System.EventHandler(this.SaveAsWorkFactorySpaceToolStripMenuItem_Click);
            // 
            // ����ToolStripMenuItem
            // 
            this.����ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadShpDocumentToolStripMenuItem,
            this.LoadGridDataToolStripMenuItem,
            this.LoadPostGISDataToolStripMenuItem,
            this.LoadPersonalDBToolStripMenuItem});
            this.����ToolStripMenuItem.Name = "����ToolStripMenuItem";
            this.����ToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.����ToolStripMenuItem.Text = "����";
            // 
            // LoadShpDocumentToolStripMenuItem
            // 
            this.LoadShpDocumentToolStripMenuItem.Name = "LoadShpDocumentToolStripMenuItem";
            this.LoadShpDocumentToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.LoadShpDocumentToolStripMenuItem.Text = "����shp�ĵ�";
            this.LoadShpDocumentToolStripMenuItem.Click += new System.EventHandler(this.LoadShpDocumentToolStripMenuItem_Click);
            // 
            // LoadGridDataToolStripMenuItem
            // 
            this.LoadGridDataToolStripMenuItem.Name = "LoadGridDataToolStripMenuItem";
            this.LoadGridDataToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.LoadGridDataToolStripMenuItem.Text = "����դ������";
            this.LoadGridDataToolStripMenuItem.Click += new System.EventHandler(this.LoadGridDataToolStripMenuItem_Click);
            // 
            // LoadPostGISDataToolStripMenuItem
            // 
            this.LoadPostGISDataToolStripMenuItem.Name = "LoadPostGISDataToolStripMenuItem";
            this.LoadPostGISDataToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.LoadPostGISDataToolStripMenuItem.Text = "����PostGIS����";
            this.LoadPostGISDataToolStripMenuItem.Click += new System.EventHandler(this.LoadPostGISDataToolStripMenuItem_Click);
            // 
            // LoadPersonalDBToolStripMenuItem
            // 
            this.LoadPersonalDBToolStripMenuItem.Name = "LoadPersonalDBToolStripMenuItem";
            this.LoadPersonalDBToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.LoadPersonalDBToolStripMenuItem.Text = "���ظ��˵������ݿ�";
            this.LoadPersonalDBToolStripMenuItem.Click += new System.EventHandler(this.LoadPersonalDBToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LargeScaleToolStripMenuItem,
            this.SmallScaleToolStripMenuItem,
            this.LargeScaleRecToolStripMenuItem,
            this.SmallScaleRecToolStripMenuItem,
            this.PanToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(45, 20);
            this.toolStripMenuItem1.Text = "��ͼ";
            // 
            // LargeScaleToolStripMenuItem
            // 
            this.LargeScaleToolStripMenuItem.Name = "LargeScaleToolStripMenuItem";
            this.LargeScaleToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.LargeScaleToolStripMenuItem.Text = "�Ŵ�";
            this.LargeScaleToolStripMenuItem.Click += new System.EventHandler(this.LargeScaleToolStripMenuItem_Click);
            // 
            // SmallScaleToolStripMenuItem
            // 
            this.SmallScaleToolStripMenuItem.Name = "SmallScaleToolStripMenuItem";
            this.SmallScaleToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.SmallScaleToolStripMenuItem.Text = "��С";
            this.SmallScaleToolStripMenuItem.Click += new System.EventHandler(this.SmallScaleToolStripMenuItem_Click);
            // 
            // LargeScaleRecToolStripMenuItem
            // 
            this.LargeScaleRecToolStripMenuItem.Name = "LargeScaleRecToolStripMenuItem";
            this.LargeScaleRecToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.LargeScaleRecToolStripMenuItem.Text = "����Ŵ�";
            this.LargeScaleRecToolStripMenuItem.Click += new System.EventHandler(this.LargeScaleRecToolStripMenuItem_Click);
            // 
            // SmallScaleRecToolStripMenuItem
            // 
            this.SmallScaleRecToolStripMenuItem.Name = "SmallScaleRecToolStripMenuItem";
            this.SmallScaleRecToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.SmallScaleRecToolStripMenuItem.Text = "������С";
            this.SmallScaleRecToolStripMenuItem.Click += new System.EventHandler(this.SmallScaleRecToolStripMenuItem_Click);
            // 
            // PanToolStripMenuItem
            // 
            this.PanToolStripMenuItem.Name = "PanToolStripMenuItem";
            this.PanToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.PanToolStripMenuItem.Text = "����";
            this.PanToolStripMenuItem.Click += new System.EventHandler(this.PanToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(45, 20);
            this.toolStripMenuItem2.Text = "�༭";
            // 
            // ��ѯToolStripMenuItem
            // 
            this.��ѯToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AttributeQueryToolStripMenuItem,
            this.SpatialQueryToolStripMenuItem});
            this.��ѯToolStripMenuItem.Name = "��ѯToolStripMenuItem";
            this.��ѯToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.��ѯToolStripMenuItem.Text = "��ѯ";
            // 
            // AttributeQueryToolStripMenuItem
            // 
            this.AttributeQueryToolStripMenuItem.Name = "AttributeQueryToolStripMenuItem";
            this.AttributeQueryToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.AttributeQueryToolStripMenuItem.Text = "���Բ�ѯ";
            this.AttributeQueryToolStripMenuItem.Click += new System.EventHandler(this.AttributeQueryToolStripMenuItem_Click);
            // 
            // SpatialQueryToolStripMenuItem
            // 
            this.SpatialQueryToolStripMenuItem.Name = "SpatialQueryToolStripMenuItem";
            this.SpatialQueryToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.SpatialQueryToolStripMenuItem.Text = "�ռ��ѯ";
            this.SpatialQueryToolStripMenuItem.Click += new System.EventHandler(this.SpatialQueryToolStripMenuItem_Click);
            // 
            // ʸ�����ݿռ����ToolStripMenuItem
            // 
            this.ʸ�����ݿռ����ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BufferToolStripMenuItem,
            this.���ӷ���ToolStripMenuItem,
            this.ʸդת��ToolStripMenuItem});
            this.ʸ�����ݿռ����ToolStripMenuItem.Name = "ʸ�����ݿռ����ToolStripMenuItem";
            this.ʸ�����ݿռ����ToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.ʸ�����ݿռ����ToolStripMenuItem.Text = "ʸ������";
            // 
            // BufferToolStripMenuItem
            // 
            this.BufferToolStripMenuItem.Name = "BufferToolStripMenuItem";
            this.BufferToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.BufferToolStripMenuItem.Text = "������";
            this.BufferToolStripMenuItem.Click += new System.EventHandler(this.BufferToolStripMenuItem_Click);
            // 
            // ���ӷ���ToolStripMenuItem
            // 
            this.���ӷ���ToolStripMenuItem.Name = "���ӷ���ToolStripMenuItem";
            this.���ӷ���ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.���ӷ���ToolStripMenuItem.Text = "���ӷ���";
            // 
            // ʸդת��ToolStripMenuItem
            // 
            this.ʸդת��ToolStripMenuItem.Name = "ʸդת��ToolStripMenuItem";
            this.ʸդת��ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.ʸդת��ToolStripMenuItem.Text = "ʸդת��";
            // 
            // դ�����ݿռ����ToolStripMenuItem
            // 
            this.դ�����ݿռ����ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.դ�����ToolStripMenuItem,
            this.դ��ͳ��ToolStripMenuItem,
            this.DensityAnalystToolStripMenuItem,
            this.�������ToolStripMenuItem,
            this.�ط���ToolStripMenuItem});
            this.դ�����ݿռ����ToolStripMenuItem.Name = "դ�����ݿռ����ToolStripMenuItem";
            this.դ�����ݿռ����ToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.դ�����ݿռ����ToolStripMenuItem.Text = "դ�����";
            // 
            // դ�����ToolStripMenuItem
            // 
            this.դ�����ToolStripMenuItem.Name = "դ�����ToolStripMenuItem";
            this.դ�����ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.դ�����ToolStripMenuItem.Text = "դ�����";
            // 
            // դ��ͳ��ToolStripMenuItem
            // 
            this.դ��ͳ��ToolStripMenuItem.Name = "դ��ͳ��ToolStripMenuItem";
            this.դ��ͳ��ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.դ��ͳ��ToolStripMenuItem.Text = "դ��ͳ��";
            // 
            // DensityAnalystToolStripMenuItem
            // 
            this.DensityAnalystToolStripMenuItem.Name = "DensityAnalystToolStripMenuItem";
            this.DensityAnalystToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.DensityAnalystToolStripMenuItem.Text = "�ܶȷ���";
            this.DensityAnalystToolStripMenuItem.Click += new System.EventHandler(this.DensityAnalystToolStripMenuItem_Click);
            // 
            // �������ToolStripMenuItem
            // 
            this.�������ToolStripMenuItem.Name = "�������ToolStripMenuItem";
            this.�������ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.�������ToolStripMenuItem.Text = "�������";
            // 
            // �ط���ToolStripMenuItem
            // 
            this.�ط���ToolStripMenuItem.Name = "�ط���ToolStripMenuItem";
            this.�ط���ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.�ط���ToolStripMenuItem.Text = "�ط���";
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
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 30);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(830, 36);
            this.axToolbarControl1.TabIndex = 7;
            // 
            // mainTocControl
            // 
            this.mainTocControl.Location = new System.Drawing.Point(0, 70);
            this.mainTocControl.Name = "mainTocControl";
            this.mainTocControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mainTocControl.OcxState")));
            this.mainTocControl.Size = new System.Drawing.Size(322, 265);
            this.mainTocControl.TabIndex = 8;
            this.mainTocControl.OnMouseDown += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseDownEventHandler(this.mainTocControl_OnMouseDown);
            // 
            // eagleEyeMapControl
            // 
            this.eagleEyeMapControl.Location = new System.Drawing.Point(0, 340);
            this.eagleEyeMapControl.Name = "eagleEyeMapControl";
            this.eagleEyeMapControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("eagleEyeMapControl.OcxState")));
            this.eagleEyeMapControl.Size = new System.Drawing.Size(322, 206);
            this.eagleEyeMapControl.TabIndex = 2;
            this.eagleEyeMapControl.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.eagleEyeMapControl_OnMouseDown);
            this.eagleEyeMapControl.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.eagleEyeMapControl_OnMouseMove);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AttributeFormToolStripMenuItem,
            this.RemoveLayerToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(127, 48);
            // 
            // AttributeFormToolStripMenuItem
            // 
            this.AttributeFormToolStripMenuItem.Name = "AttributeFormToolStripMenuItem";
            this.AttributeFormToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.AttributeFormToolStripMenuItem.Text = "���Ա�";
            this.AttributeFormToolStripMenuItem.Click += new System.EventHandler(this.AttributeFormToolStripMenuItem_Click);
            // 
            // RemoveLayerToolStripMenuItem
            // 
            this.RemoveLayerToolStripMenuItem.Name = "RemoveLayerToolStripMenuItem";
            this.RemoveLayerToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.RemoveLayerToolStripMenuItem.Text = "�Ƴ�ͼ��";
            this.RemoveLayerToolStripMenuItem.Click += new System.EventHandler(this.RemoveLayerToolStripMenuItem_Click);
            // 
            // MainForm
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
            this.Name = "MainForm";
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
            this.contextMenuStrip2.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem �ļ�ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewWorkFactoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenMxdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveWorkFactorySpaceToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private ESRI.ArcGIS.Controls.AxTOCControl mainTocControl;
        private ESRI.ArcGIS.Controls.AxMapControl eagleEyeMapControl;
        private System.Windows.Forms.ToolStripMenuItem SaveAsWorkFactorySpaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ����ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadShpDocumentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadGridDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ��ѯToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AttributeQueryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SpatialQueryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ʸ�����ݿռ����ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BufferToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ���ӷ���ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem դ�����ݿռ����ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem դ�����ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem դ��ͳ��ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DensityAnalystToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem �������ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem �ط���ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadPostGISDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ʸդת��ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem LargeScaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SmallScaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LargeScaleRecToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SmallScaleRecToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem AttributeFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadPersonalDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveLayerToolStripMenuItem;
    }
}

