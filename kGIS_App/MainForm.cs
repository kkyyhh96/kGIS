using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Editor;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.DataSourcesGDB;
using DevComponents.DotNetBar;
using ESRI.ArcGIS.esriSystem;

namespace kGIS_App
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        #region �ļ�
        #region ��mxd�ĵ�
        /// <summary>
        /// ��mxd�ĵ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenMxdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.Title = "�򿪵�ͼ�ĵ�";
            openFileDialog.Filter = "ArcMap�ĵ�(*.mxd)|*.mxd;|�����ļ�(*.*)|*.*";
            openFileDialog.Multiselect = false;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string mxdFileName = openFileDialog.FileName;
                    if (mxdFileName != "")//����ļ�����Ϊ��,�����mxd�ĵ�
                    {
                        mainMapControl.LoadMxFile(mxdFileName);
                    }
                    else return;
                }
                catch (Exception except)
                {
                    MessageBox.Show("���ĵ�ʧ�ܣ�\n" + except.ToString());
                }
            }
        }
        #endregion
        #region ����mxd�ĵ�
        /// <summary>
        /// ����mxd�ĵ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveWorkFactorySpaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string saveMxdFileName = mainMapControl.DocumentFilename;
                IMapDocument mapDocument = new MapDocumentClass();
                mapDocument.New(saveMxdFileName);
                mapDocument.ReplaceContents(mainMapControl.Map as IMxdContents);
                mapDocument.Save(mapDocument.UsesRelativePaths, true);
                mapDocument.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion
        #region ���Ϊ��ͼ�ĵ�
        /// <summary>
        /// ���Ϊ��ͼ�ĵ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAsWorkFactorySpaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "��ѡ������·��";
                saveFileDialog.OverwritePrompt = true;
                saveFileDialog.Filter = "Arcmap�ĵ�(*.mxd)|x.mxd|ArcMapģ��(*.mxt)|*.mxt";
                saveFileDialog.RestoreDirectory = true;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string saveMxdFileName = saveFileDialog.FileName;

                    IMapDocument mapDocument = new MapDocumentClass();
                    mapDocument.New(saveMxdFileName);
                    mapDocument.ReplaceContents(mainMapControl.Map as IMxdContents);
                    mapDocument.Save(mapDocument.UsesRelativePaths, true);
                    mapDocument.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion
        #region �½��հ�mxd�ĵ�
        /// <summary>
        /// �½��հ�mxd�ĵ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewWorkFactoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string saveMxdFileName = mainMapControl.DocumentFilename;
                IMapDocument mapDocument = new MapDocumentClass();
                if (saveMxdFileName == null)
                {
                    //������Ʋ�����,����������
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Title = "��ѡ�񱣴�·��";
                    saveFileDialog.OverwritePrompt = true;
                    saveFileDialog.Filter = "Arcmap�ĵ�(*.mxd)|x.mxd|ArcMapģ��(*.mxt)|*.mxt";
                    saveFileDialog.RestoreDirectory = true;
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        saveMxdFileName = saveFileDialog.FileName;
                        mainMapControl.DocumentFilename = saveMxdFileName;
                    }
                    else
                    {
                        return;
                    }
                }
                mapDocument.New(saveMxdFileName);
                mapDocument.ReplaceContents(mainMapControl.Map as IMxdContents);
                mapDocument.Save(mapDocument.UsesRelativePaths, true);
                mapDocument.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        #endregion
        #endregion
        #region ����
        #region ����shp�ļ�
        /// <summary>
        /// ����shp�ĵ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadShpDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.Title = "����shp�ĵ�";
            openFileDialog.Filter = "Shape�ĵ�(*.shp)|*.shp;";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string shpFullPath = openFileDialog.FileName;
                    if (shpFullPath != "")
                    {
                        int indexOfShpFullPath = shpFullPath.LastIndexOf("\\");//��ȡshp�ĵ����������и�
                        mainMapControl.AddShapeFile(shpFullPath.Substring(0, indexOfShpFullPath), shpFullPath.Substring(indexOfShpFullPath + 1));

                        //ͬ��ӥ��
                        SynchronizeEagleEye();
                    }
                    else return;
                }
                catch (Exception except)
                {
                    MessageBox.Show("���ĵ�ʧ�ܣ�\n" + except.ToString());
                }
            }
        }
        #endregion
        #region ����դ������
        /// <summary>
        /// ����դ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadGridDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.Title = "����դ������";
            openFileDialog.Filter = "դ���ĵ�(*.*)|*.bmp;*.tif;*.jpg;*.img|(*.bmp)|*.bmp|(*.tif)|*.tif|(*.jpg)|*.jpg|(*.img)|*.img";
            openFileDialog.RestoreDirectory = true;

            openFileDialog.ShowDialog();
            string rasterFullPath = openFileDialog.FileName;
            int indexOfRasterFullPath = rasterFullPath.LastIndexOf("\\");
            string rasterFilePath = rasterFullPath.Substring(0, indexOfRasterFullPath);//�ļ�·��
            string rasterFileName = rasterFullPath.Substring(indexOfRasterFullPath + 1);//�ļ���

            IWorkspaceFactory workspaceFactory = new RasterWorkspaceFactory();
            IWorkspace workspace = workspaceFactory.OpenFromFile(rasterFilePath, 0);
            IRasterWorkspace rasterWorkspace = workspace as IRasterWorkspace;
            IRasterDataset rasterDataset = rasterWorkspace.OpenRasterDataset(rasterFileName);

            //����Ӱ�������
            IRasterPyramid rasterPyramid = rasterDataset as IRasterPyramid;
            if (rasterPyramid != null)
            {
                //�ж��Ƿ��Ѿ�������Ӱ�������,û���򴴽�
                if (!(rasterPyramid.Present))
                {
                    rasterPyramid.Create();
                }
            }

            IRaster raster = rasterDataset.CreateDefaultRaster();
            IRasterLayer rasterLayer = new RasterLayerClass();
            rasterLayer.CreateFromRaster(raster);
            ILayer layer = rasterLayer as ILayer;
            mainMapControl.AddLayer(layer, 0);

            //ͬ��ӥ��
            SynchronizeEagleEye();
        }
        #endregion
        #region ����PostGIS����
        /// <summary>
        /// �������PostGIS����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadPostGISDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //��������PostgreSQL���ݿ�Ĵ���
            ConnectPostgreSQL connectPostgreSQL = new ConnectPostgreSQL(this, this.mainMapControl);
            connectPostgreSQL.Show();
            //ͬ��ӥ��
            SynchronizeEagleEye();
        }
        #endregion
        #region ���ظ��˵�����Ϣ���ݿ�
        /// <summary>
        /// ���ظ��˵�����Ϣ���ݿ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadPersonalDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IWorkspaceFactory pAccessWorkspaceFactory;

            OpenFileDialog pOpenFileDialog = new OpenFileDialog();
            pOpenFileDialog.Filter = "Personal Geodatabase(*.mdb)|*.mdb";
            pOpenFileDialog.Title = "��PersonGeodatabase�ļ�";
            pOpenFileDialog.ShowDialog();

            string pFullPath = pOpenFileDialog.FileName;
            if (pFullPath == "")
            {
                return;
            }
            pAccessWorkspaceFactory = new AccessWorkspaceFactory(); //using ESRI.ArcGIS.DataSourcesGDB;
            //��ȡ�����ռ�
            IWorkspace pWorkspace = pAccessWorkspaceFactory.OpenFromFile(pFullPath, 0);

            //���ع����ռ��������
            IEnumDataset pEnumDataset = pWorkspace.get_Datasets(ESRI.ArcGIS.Geodatabase.esriDatasetType.esriDTAny);
            pEnumDataset.Reset();
            //��Enum���ݼ��е�����һ��������DataSet��
            IDataset pDataset = pEnumDataset.Next();
            //�ж����ݼ��Ƿ�������
            while (pDataset != null)
            {
                if (pDataset is IFeatureDataset)  //Ҫ�����ݼ�
                {
                    IFeatureWorkspace pFeatureWorkspace = (IFeatureWorkspace)pWorkspace;
                    IFeatureDataset pFeatureDataset = pFeatureWorkspace.OpenFeatureDataset(pDataset.Name);
                    IEnumDataset pEnumDataset1 = pFeatureDataset.Subsets;
                    pEnumDataset1.Reset();
                    IGroupLayer pGroupLayer = new GroupLayerClass();
                    pGroupLayer.Name = pFeatureDataset.Name;
                    IDataset pDataset1 = pEnumDataset1.Next();
                    while (pDataset1 != null)
                    {
                        if (pDataset1 is IFeatureClass)  //Ҫ����
                        {
                            IFeatureLayer pFeatureLayer = new FeatureLayerClass();
                            pFeatureLayer.FeatureClass = pFeatureWorkspace.OpenFeatureClass(pDataset1.Name);
                            if (pFeatureLayer.FeatureClass != null)
                            {
                                pFeatureLayer.Name = pFeatureLayer.FeatureClass.AliasName;
                                pGroupLayer.Add(pFeatureLayer);
                                mainMapControl.Map.AddLayer(pFeatureLayer);
                            }
                        }
                        pDataset1 = pEnumDataset1.Next();
                    }
                }
                else if (pDataset is IFeatureClass) //Ҫ����
                {
                    IFeatureWorkspace pFeatureWorkspace = (IFeatureWorkspace)pWorkspace;
                    IFeatureLayer pFeatureLayer = new FeatureLayerClass();
                    pFeatureLayer.FeatureClass = pFeatureWorkspace.OpenFeatureClass(pDataset.Name);

                    pFeatureLayer.Name = pFeatureLayer.FeatureClass.AliasName;
                    mainMapControl.Map.AddLayer(pFeatureLayer);
                }
                else if (pDataset is IRasterDataset) //դ�����ݼ�
                {
                    IRasterWorkspaceEx pRasterWorkspace = (IRasterWorkspaceEx)pWorkspace;
                    IRasterDataset pRasterDataset = pRasterWorkspace.OpenRasterDataset(pDataset.Name);
                    //Ӱ��������ж��봴��
                    IRasterPyramid3 pRasPyrmid;
                    pRasPyrmid = pRasterDataset as IRasterPyramid3;
                    if (pRasPyrmid != null)
                    {
                        if (!(pRasPyrmid.Present))
                        {
                            pRasPyrmid.Create(); //����������
                        }
                    }
                    IRasterLayer pRasterLayer = new RasterLayerClass();
                    pRasterLayer.CreateFromDataset(pRasterDataset);
                    ILayer pLayer = pRasterLayer as ILayer;
                    mainMapControl.AddLayer(pLayer, 0);
                }
                pDataset = pEnumDataset.Next();
            }

            mainMapControl.ActiveView.Refresh();
            //ͬ��ӥ��
            SynchronizeEagleEye();
        }
        #endregion
        #region ����poy����
        /// <summary>
        /// ����poy����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadPoyDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.Title = "����poy�ĵ�";
            openFileDialog.Filter = "poy�ĵ�(*.poy)|*.poy;";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string poyFullPath = openFileDialog.FileName;
                    if (poyFullPath != "")
                    {
                        kShpLayer shpLayer = new kShpLayer();
                        List<kShpLayer.kShpPoint> poyPoints = new List<kShpLayer.kShpPoint>();

                        //�ļ��ж�ȡ������
                        StreamReader streamReader = new StreamReader(poyFullPath);
                        string pointLine = streamReader.ReadLine();
                        while (pointLine != null)
                        {
                            double x, y;
                            x = Convert.ToDouble(pointLine.Split(' ')[0]);
                            y = Convert.ToDouble(pointLine.Split(' ')[1]);
                            kShpLayer.kShpPoint point = new kShpLayer.kShpPoint(x, y);
                            poyPoints.Add(point);
                            pointLine = streamReader.ReadLine();
                        }
                        //����һ����shp�ļ�
                        IFeatureLayer featureLayer = shpLayer.CreateShpLineFromPoint(poyPoints, poyFullPath);
                        mainMapControl.Map.AddLayer(featureLayer);
                        //ͬ��ӥ��
                        SynchronizeEagleEye();
                    }
                    else return;
                }
                catch (Exception except)
                {
                    MessageBox.Show("���ĵ�ʧ�ܣ�\n" + except.ToString());
                }
            }
        }
        #endregion
        #region ����TIN����
        /// <summary>
        /// ����TIN����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadTINDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.CheckFileExists = true;
                openFileDialog.Title = "����TIN�ĵ�";
                openFileDialog.Filter = "TIN�ĵ�(*.ctin)|*.ctin;";
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string tinFullPath = openFileDialog.FileName;
                        string output = "";
                        if (tinFullPath != "")
                        {
                            BinaryReader br = new BinaryReader(new System.IO.FileStream(tinFullPath, FileMode.Open));
                            string info = br.ReadDouble().ToString();
                            int i = 0;
                            while (info != null)
                            {
                                output += (info + "\n");
                                i++;
                                if (i >= 40) break;

                                info = br.ReadDouble().ToString();
                            }
                            MessageBox.Show(output.ToString());
                        }
                        else return;
                    }
                    catch (Exception except)
                    {
                        MessageBox.Show("���ĵ�ʧ�ܣ�\n" + except.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion
        #endregion
        #region ӥ��
        #region ͬ��ӥ��
        /// <summary>
        /// ͬ��ӥ��
        /// </summary>
        public void SynchronizeEagleEye()
        {
            //��ȡ��ͼͼ��
            if (mainMapControl.LayerCount > 0)
            {
                eagleEyeMapControl.Map = new MapClass();
                //ȷ��ӥ����ͼ��������ͼ��ͼ������˳�򱣳�һ��
                for (int i = mainMapControl.Map.LayerCount - 1; i >= 0; i--)
                {
                    eagleEyeMapControl.AddLayer(mainMapControl.get_Layer(i));
                }
                eagleEyeMapControl.Extent = mainMapControl.FullExtent;
                eagleEyeMapControl.Refresh();
            }
        }
        #endregion
        #region ӥ��
        private void mainMapControl_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            // �õ��·�Χ
            IEnvelope pEnvelope = (IEnvelope)e.newEnvelope;
            IGraphicsContainer pGraphicsContainer = eagleEyeMapControl.Map as IGraphicsContainer;
            IActiveView pActiveView = pGraphicsContainer as IActiveView;
            //�ڻ���ǰ�����axMapControl2�е��κ�ͼ��Ԫ��
            pGraphicsContainer.DeleteAllElements();
            IRectangleElement pRectangleEle = new RectangleElementClass();
            IElement pElement = pRectangleEle as IElement;
            pElement.Geometry = pEnvelope;
            //����ӥ��ͼ�еĺ��߿�
            IRgbColor pColor = new RgbColorClass();
            pColor.Red = 255; pColor.Green = 0; pColor.Blue = 0; pColor.Transparency = 255;
            //����һ���߷��Ŷ���
            ILineSymbol pOutline = new SimpleLineSymbolClass();
            pOutline.Width = 3; pOutline.Color = pColor;
            //������ɫ����
            pColor = new RgbColorClass();
            pColor.Red = 255; pColor.Green = 0; pColor.Blue = 0; pColor.Transparency = 0;
            //���������ŵ�����
            IFillSymbol pFillSymbol = new SimpleFillSymbolClass();
            pFillSymbol.Color = pColor; pFillSymbol.Outline = pOutline;
            IFillShapeElement pFillShapeEle = pElement as IFillShapeElement;
            pFillShapeEle.Symbol = pFillSymbol;
            pGraphicsContainer.AddElement((IElement)pFillShapeEle, 0);
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);//����ˢ��
        }

        private void mainMapControl_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            SynchronizeEagleEye();
            CopyMapFromMapControlToPageLayoutControl();
        }

        private void eagleEyeMapControl_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            if (e.button == 1)
            {
                IPoint pPoint = new PointClass();
                pPoint.PutCoords(e.mapX, e.mapY);
                mainMapControl.CenterAt(pPoint);
                mainMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
            }
        }

        private void eagleEyeMapControl_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (eagleEyeMapControl.Map.LayerCount > 0)
            {
                if (e.button == 1)
                {
                    IPoint pPoint = new PointClass();
                    pPoint.PutCoords(e.mapX, e.mapY);
                    mainMapControl.CenterAt(pPoint);
                    mainMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                }
                else if (e.button == 2)
                {
                    IEnvelope pEnv = eagleEyeMapControl.TrackRectangle();
                    mainMapControl.Extent = pEnv;
                    mainMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                }
            }
        }
        #endregion
        #endregion
        #region դ�����
        #region �ܶȷ���
        /// <summary>
        /// ����ܶȷ����İ�ť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DensityAnalystToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //�����ܶȷ����Ĵ���
            DensityAnalystForm densityAnalystForm = new DensityAnalystForm(mainMapControl);
            densityAnalystForm.Show();
        }
        #endregion
        #endregion
        #region ��ʾ
        #region �Ŵ�
        /// <summary>
        /// �Ŵ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LargeScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IEnvelope envelope = mainMapControl.Extent;
            //���÷Ŵ���
            envelope.Expand(0.5, 0.5, true);
            mainMapControl.Extent = envelope;
            mainMapControl.ActiveView.Refresh();
        }
        #endregion

        #region ��С
        /// <summary>
        /// ��С
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SmallScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IEnvelope envelope = mainMapControl.Extent;
            //������С����
            envelope.Expand(1.5, 1.5, true);
            mainMapControl.Extent = envelope;
            mainMapControl.ActiveView.Refresh();
        }
        #endregion

        #region ����
        /// <summary>
        /// ����ȫͼ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        bool panMode = false;
        private void PanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clickMode = 1;
            panMode = !panMode;
        }
        #endregion

        #region ����Ŵ�
        public int clickMode = 0;
        bool largeScaleRec = false;
        private void LargeScaleRecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            largeScaleRec = !largeScaleRec;
            smallScaleRec = false;
            clickMode = 1;
        }
        #endregion

        #region ������С
        bool smallScaleRec = false;
        private void SmallScaleRecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            smallScaleRec = !smallScaleRec;
            largeScaleRec = false;
            clickMode = 1;
        }

        #endregion

        #region ����
        private void mainMapControl_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            switch (clickMode)
            {
                case 1://���������Ŵ������С
                    LargeOrSmall(); break;
                case 2://����ǿռ�ѡ��
                    SelectFeature(e); break;
                case 3://����Ǳ༭
                    EditFeature(e);
                    break;
            }
            mainMapControl.ActiveView.Refresh();
        }

        private void LargeOrSmall()
        {
            //�����ΧΪ���򷵻�
            if (panMode)
            {
                mainMapControl.Pan();
                return;
            }
            IEnvelope envelope = mainMapControl.TrackRectangle();
            if (envelope == null || envelope.IsEmpty || envelope.Height == 0 || envelope.Width == 0)
            {
            }
            //������С
            else if (smallScaleRec == true)
            {
                IActiveView activeView = mainMapControl.ActiveView;
                double dWidth = activeView.Extent.Width * activeView.Extent.Width / envelope.Width;
                double dHeight = activeView.Extent.Height * activeView.Extent.Height / envelope.Height;
                double dXmin = activeView.Extent.XMin -
                               ((envelope.XMin - activeView.Extent.XMin) * activeView.Extent.Width /
                                envelope.Width);
                double dYmin = activeView.Extent.YMin -
                               ((envelope.YMin - activeView.Extent.YMin) * activeView.Extent.Height /
                                envelope.Height);
                double dXmax = dXmin + dWidth;
                double dYmax = dYmin + dHeight;
                envelope.PutCoords(dXmin, dYmin, dXmax, dYmax);
                mainMapControl.Extent = envelope;
            }
            //����Ŵ�
            else if (largeScaleRec == true)
            {
                mainMapControl.Extent = envelope;
            }
        }
        #endregion

        /// <summary>
        /// ͼ��ؼ��Ҽ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        IFeatureLayer tocSelectFeatureLayer = null;//���ͼ��ؼ�ѡ���ͼ��
        private void mainTocControl_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            if (e.button == 2)
            {
                esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;
                IBasicMap basicMap = null;
                object data = null, unk = null;
                ILayer layer = null;
                //��ȡ�����λ��,ͼ���
                mainTocControl.HitTest(e.x, e.y, ref item, ref basicMap, ref layer, ref unk, ref data);

                tocSelectFeatureLayer = layer as IFeatureLayer;
                if (item == esriTOCControlItem.esriTOCControlItemLayer && tocSelectFeatureLayer != null)
                {
                    contextMenuStrip2.Show(Control.MousePosition);
                }
            }
        }
        #endregion
        #region �Ҽ�
        #region �����Ա�
        private void AttributeFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataAttributeForm dataAttributeForm = new DataAttributeForm();
            dataAttributeForm.Show();
            dataAttributeForm.currentLayer = tocSelectFeatureLayer;
            dataAttributeForm.SetTable();
        }
        #endregion
        #region �Ƴ�ͼ��
        private void RemoveLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainMapControl.Map.DeleteLayer(tocSelectFeatureLayer);
        }
        #endregion
        #endregion
        #region ��ѯ
        #region ���Բ�ѯ
        private void AttributeQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpatialQueryForm spatialQueryForm = new SpatialQueryForm(mainMapControl);
            spatialQueryForm.Show();
        }
        #endregion
        public int selectMethod { set; get; }
        #region �ռ��ѯ
        private void SpatialQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpatialSelectForm selectForm = new SpatialSelectForm(this, this.mainMapControl);
            selectForm.Show();
        }
        #endregion
        public double selectRadius;
        #region ѡ��Ҫ��
        /// <summary>
        /// ѡ��Ҫ��
        /// </summary>
        /// <param name="e"></param>
        private void SelectFeature(IMapControlEvents2_OnMouseDownEvent e)
        {
            //���ԭ�ȵ�ѡ��
            mainMapControl.Map.ClearSelection();
            IGeometry selectGeometry = null;
            IPoint point = new PointClass();
            switch (selectMethod)
            {
                case 1:
                    //��ȡ����
                    IActiveView activeView = this.mainMapControl.ActiveView;
                    point = activeView.ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y);

                    //�½���������Ϊ��ѯ�ķ�Χ
                    ITopologicalOperator topologicalOperator = (ITopologicalOperator)point;
                    selectGeometry = topologicalOperator.Buffer(10).Envelope;
                    break;
                case 2:
                    //��ȡ����
                    selectGeometry = mainMapControl.TrackRectangle();
                    break;
                case 3:
                    //��ȡԲ��
                    selectGeometry = mainMapControl.TrackCircle();
                    break;
                case 4:
                    //��ȡ����
                    IActiveView activeView_1 = this.mainMapControl.ActiveView;
                    point = activeView_1.ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y);

                    //�½���������Ϊ��ѯ�ķ�Χ
                    ITopologicalOperator topologicalOperator_1 = (ITopologicalOperator)point;
                    selectGeometry = topologicalOperator_1.Buffer(selectRadius).Envelope;
                    break;
            }
            selectQueryFeature(selectGeometry);
        }
        #endregion
        public ILayer selectLayer;
        #region �ռ��ѯ��ʽ
        /// <summary>
        /// �ռ��ѯ��ʽ
        /// </summary>
        /// <param name="geometry"></param>
        private void selectQueryFeature(IGeometry geometry)
        {
            //�ռ��ѯ,���÷�ΧΪ����
            ISpatialFilter spatialFilter = new SpatialFilterClass();
            spatialFilter.Geometry = geometry;
            spatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;

            IFeatureLayer featureLayer = (IFeatureLayer)selectLayer;
            IFeatureSelection featureSelection = featureLayer as IFeatureSelection;

            featureSelection.SelectFeatures((IQueryFilter)spatialFilter, esriSelectionResultEnum.esriSelectionResultAdd, false);
            IActiveView activeView = mainMapControl.Map as IActiveView;
            activeView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, activeView.Extent);
        }
        #endregion
        #endregion
        #region ʸ������
        #region ����������
        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BufferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BufferForm bufferForm = new BufferForm(mainMapControl);
            bufferForm.Show();
        }
        #endregion
        #region ������˹�տ��㷨
        /// <summary>
        /// ������˹�տ��㷨
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DouglasPeukerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DouglasPeukerForm douglasPeukerForm = new DouglasPeukerForm(this.mainMapControl);
            douglasPeukerForm.Show();
        }
        #endregion

        private void mapViewer_MouseClick(object sender, MouseEventArgs e)
        {
            IActiveView activeView = (IActiveView)mainPageLayout.ActiveView.FocusMap;
            IDisplayTransformation displayTransformation = activeView.ScreenDisplay.DisplayTransformation;
            displayTransformation.VisibleBounds = mainMapControl.Extent;
            mainPageLayout.ActiveView.FocusMap = mainMapControl.Map;
            mainMapControl.ActiveView.Refresh();
        }
        //��MapControl�еĵ�ͼ���Ƶ�PageLayoutControl��ȥ
        private void CopyMapFromMapControlToPageLayoutControl()
        {
            try
            {
                //���IObjectCopy�ӿ�
                IObjectCopy pObjectCopy = new ObjectCopyClass();
                //���Ҫ������ͼ�� 
                System.Object pSourceMap = mainMapControl.Map;
                //��ÿ���ͼ��
                System.Object pCopiedMap = pObjectCopy.Copy(pSourceMap);
                //���Ҫ�ػ�ĵ�ͼ 
                System.Object pOverwritedMap = mainPageLayout.ActiveView.FocusMap;
                //�ػ�pagelayout��ͼ
                pObjectCopy.Overwrite(pCopiedMap, ref pOverwritedMap);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }
        #endregion

        private void mainMapControl_OnViewRefreshed(object sender, IMapControlEvents2_OnViewRefreshedEvent e)
        {
            CopyMapFromMapControlToPageLayoutControl();
        }
        /// <summary>
        /// ��ͼ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapExportForm exportForm = new MapExportForm(this.mainMapControl);
            exportForm.Show();
        }

        /// <summary>
        /// �ռ�ͳ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpatialStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpatialStatisticsForm statisticsForm = new SpatialStatisticsForm(this.mainMapControl);
            statisticsForm.Show();
        }

        private void ShortPathToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void EditFeatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditFeatureForm editFeatureForm = new EditFeatureForm(this.mainMapControl);
            editFeatureForm.Show();
        }
        private void EditFeature(IMapControlEvents2_OnMouseDownEvent e)
        {
        }
    }
}