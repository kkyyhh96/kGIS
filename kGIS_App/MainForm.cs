using System;
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

namespace kGIS_App
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        #region 文件
        #region 打开mxd文档
        /// <summary>
        /// 打开mxd文档
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenMxdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.Title = "打开地图文档";
            openFileDialog.Filter = "ArcMap文档(*.mxd)|*.mxd;|所有文件(*.*)|*.*";
            openFileDialog.Multiselect = false;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string mxdFileName = openFileDialog.FileName;
                    if (mxdFileName != "")//如果文件名不为空,则加载mxd文档
                    {
                        mainMapControl.LoadMxFile(mxdFileName);
                    }
                    else return;
                }
                catch (Exception except)
                {
                    MessageBox.Show("打开文档失败！\n" + except.ToString());
                }
            }
        }
        #endregion
        #region 保存mxd文档
        /// <summary>
        /// 保存mxd文档
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
        #region 另存为地图文档
        /// <summary>
        /// 另存为地图文档
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAsWorkFactorySpaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "请选择另保存路径";
                saveFileDialog.OverwritePrompt = true;
                saveFileDialog.Filter = "Arcmap文档(*.mxd)|x.mxd|ArcMap模板(*.mxt)|*.mxt";
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
        #region 新建空白mxd文档
        /// <summary>
        /// 新建空白mxd文档
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
                    //如果名称不存在,则输入名称
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Title = "请选择保存路径";
                    saveFileDialog.OverwritePrompt = true;
                    saveFileDialog.Filter = "Arcmap文档(*.mxd)|x.mxd|ArcMap模板(*.mxt)|*.mxt";
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
        #region 数据
        #region 加载shp文件
        /// <summary>
        /// 加载shp文档
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadShpDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.Title = "加载shp文档";
            openFileDialog.Filter = "Shape文档(*.shp)|*.shp;";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string shpFullPath = openFileDialog.FileName;
                    if (shpFullPath != "")
                    {
                        int indexOfShpFullPath = shpFullPath.LastIndexOf("\\");//获取shp文档名并进行切割
                        mainMapControl.AddShapeFile(shpFullPath.Substring(0, indexOfShpFullPath), shpFullPath.Substring(indexOfShpFullPath + 1));

                        //同步鹰眼
                        SynchronizeEagleEye();
                    }
                    else return;
                }
                catch (Exception except)
                {
                    MessageBox.Show("打开文档失败！\n" + except.ToString());
                }
            }
        }
        #endregion
        #region 加载栅格数据
        /// <summary>
        /// 加载栅格数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadGridDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.Title = "加载栅格数据";
            openFileDialog.Filter = "栅格文档(*.*)|*.bmp;*.tif;*.jpg;*.img|(*.bmp)|*.bmp|(*.tif)|*.tif|(*.jpg)|*.jpg|(*.img)|*.img";
            openFileDialog.RestoreDirectory = true;

            openFileDialog.ShowDialog();
            string rasterFullPath = openFileDialog.FileName;
            int indexOfRasterFullPath = rasterFullPath.LastIndexOf("\\");
            string rasterFilePath = rasterFullPath.Substring(0, indexOfRasterFullPath);//文件路径
            string rasterFileName = rasterFullPath.Substring(indexOfRasterFullPath + 1);//文件名

            IWorkspaceFactory workspaceFactory = new RasterWorkspaceFactory();
            IWorkspace workspace = workspaceFactory.OpenFromFile(rasterFilePath, 0);
            IRasterWorkspace rasterWorkspace = workspace as IRasterWorkspace;
            IRasterDataset rasterDataset = rasterWorkspace.OpenRasterDataset(rasterFileName);

            //创建影像金字塔
            IRasterPyramid rasterPyramid = rasterDataset as IRasterPyramid;
            if (rasterPyramid != null)
            {
                //判断是否已经存在了影像金字塔,没有则创建
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

            //同步鹰眼
            SynchronizeEagleEye();
        }
        #endregion
        #region 加载PostGIS数据
        /// <summary>
        /// 点击加载PostGIS数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadPostGISDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //出现连接PostgreSQL数据库的窗体
            ConnectPostgreSQL connectPostgreSQL = new ConnectPostgreSQL(this, this.mainMapControl);
            connectPostgreSQL.Show();
            //同步鹰眼
            SynchronizeEagleEye();
        }
        #endregion
        #endregion
        #region 鹰眼
        #region 同步鹰眼
        /// <summary>
        /// 同步鹰眼
        /// </summary>
        public void SynchronizeEagleEye()
        {
            //获取主图图层
            if (mainMapControl.LayerCount > 0)
            {
                eagleEyeMapControl.Map = new MapClass();
                //确保鹰眼视图与数据视图的图层上下顺序保持一致
                for (int i = mainMapControl.Map.LayerCount - 1; i >= 0; i--)
                {
                    eagleEyeMapControl.AddLayer(mainMapControl.get_Layer(i));
                }
                eagleEyeMapControl.Extent = mainMapControl.FullExtent;
                eagleEyeMapControl.Refresh();
            }
        }
        #endregion
        #region 鹰眼
        private void mainMapControl_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            // 得到新范围
            IEnvelope pEnvelope = (IEnvelope)e.newEnvelope;
            IGraphicsContainer pGraphicsContainer = eagleEyeMapControl.Map as IGraphicsContainer;
            IActiveView pActiveView = pGraphicsContainer as IActiveView;
            //在绘制前，清除axMapControl2中的任何图形元素
            pGraphicsContainer.DeleteAllElements();
            IRectangleElement pRectangleEle = new RectangleElementClass();
            IElement pElement = pRectangleEle as IElement;
            pElement.Geometry = pEnvelope;
            //设置鹰眼图中的红线框
            IRgbColor pColor = new RgbColorClass();
            pColor.Red = 255; pColor.Green = 0; pColor.Blue = 0; pColor.Transparency = 255;
            //产生一个线符号对象
            ILineSymbol pOutline = new SimpleLineSymbolClass();
            pOutline.Width = 3; pOutline.Color = pColor;
            //设置颜色属性
            pColor = new RgbColorClass();
            pColor.Red = 255; pColor.Green = 0; pColor.Blue = 0; pColor.Transparency = 0;
            //设置填充符号的属性
            IFillSymbol pFillSymbol = new SimpleFillSymbolClass();
            pFillSymbol.Color = pColor; pFillSymbol.Outline = pOutline;
            IFillShapeElement pFillShapeEle = pElement as IFillShapeElement;
            pFillShapeEle.Symbol = pFillSymbol;
            pGraphicsContainer.AddElement((IElement)pFillShapeEle, 0);
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);//部分刷新
        }

        private void mainMapControl_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            SynchronizeEagleEye();
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
        #region 栅格分析
        #region 密度分析
        /// <summary>
        /// 点击密度分析的按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DensityAnalystToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //出现密度分析的窗体
            DensityAnalystForm densityAnalystForm = new DensityAnalystForm(mainMapControl);
            densityAnalystForm.Show();
        }
        #endregion
        #endregion
        #region 显示
        #region 放大
        /// <summary>
        /// 放大
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LargeScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IEnvelope envelope = mainMapControl.Extent;
            //设置放大倍数
            envelope.Expand(0.5, 0.5, true);
            mainMapControl.Extent = envelope;
            mainMapControl.ActiveView.Refresh();
        }
        #endregion

        #region 缩小
        /// <summary>
        /// 缩小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SmallScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IEnvelope envelope = mainMapControl.Extent;
            //设置缩小倍数
            envelope.Expand(1.5, 1.5, true);
            mainMapControl.Extent = envelope;
            mainMapControl.ActiveView.Refresh();
        }
        #endregion

        #region 漫游
        /// <summary>
        /// 漫游全图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainMapControl.Pan();
        }
        #endregion

        #region 拉框放大
        public int clickMode = 0;
        bool largeScaleRec = false;
        private void LargeScaleRecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            largeScaleRec = !largeScaleRec;
            smallScaleRec = false;
            clickMode = 1;
        }
        #endregion

        #region 拉框缩小
        bool smallScaleRec = false;
        private void SmallScaleRecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            smallScaleRec = !smallScaleRec;
            largeScaleRec = false;
            clickMode = 1;
        }

        #endregion

        #region 拉框
        private void mainMapControl_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            switch (clickMode)
            {
                case 1://如果是拉框放大或者缩小
                    LargeOrSmall(); break;
                case 2://如果是空间选择
                    SelectFeature(e); break;
            }
            mainMapControl.ActiveView.Refresh();
        }

        public double selectRadius;
        private void SelectFeature(IMapControlEvents2_OnMouseDownEvent e)
        {
            //清除原先的选择集
            mainMapControl.Map.ClearSelection();
            IGeometry selectGeometry = null;
            IPoint point = new PointClass();
            switch (selectMethod)
            {
                case 1:
                    //获取鼠标点
                    IActiveView activeView = this.mainMapControl.ActiveView;
                    point = activeView.ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y);

                    //新建缓冲区作为查询的范围
                    ITopologicalOperator topologicalOperator = (ITopologicalOperator)point;
                    selectGeometry = topologicalOperator.Buffer(10).Envelope;
                    break;
                case 2:
                    //获取矩形
                    selectGeometry = mainMapControl.TrackRectangle();
                    break;
                case 3:
                    //获取圆形
                    selectGeometry = mainMapControl.TrackCircle();
                    break;
                case 4:
                    //获取鼠标点
                    IActiveView activeView_1 = this.mainMapControl.ActiveView;
                    point = activeView_1.ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y);

                    //新建缓冲区作为查询的范围
                    ITopologicalOperator topologicalOperator_1 = (ITopologicalOperator)point;
                    selectGeometry = topologicalOperator_1.Buffer(selectRadius).Envelope;
                    break;
            }
            selectQueryFeature(selectGeometry);
        }
        public ILayer selectLayer;
        private void selectQueryFeature(IGeometry geometry)
        {
            //空间查询,设置范围为包含
            ISpatialFilter spatialFilter = new SpatialFilterClass();
            spatialFilter.Geometry = geometry;
            spatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;

            IFeatureLayer featureLayer = (IFeatureLayer)selectLayer;
            IFeatureSelection featureSelection = featureLayer as IFeatureSelection;

            featureSelection.SelectFeatures((IQueryFilter)spatialFilter, esriSelectionResultEnum.esriSelectionResultAdd, false);
            IActiveView activeView = mainMapControl.Map as IActiveView;
            activeView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, activeView.Extent);
        }
        private void LargeOrSmall()
        {
            IEnvelope envelope = mainMapControl.TrackRectangle();
            //如果范围为空则返回
            if (envelope == null || envelope.IsEmpty || envelope.Height == 0 || envelope.Width == 0)
            {
            }
            //拉框缩小
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
            }
            //拉框放大
            else if (largeScaleRec == true)
            {
                mainMapControl.Extent = envelope;
            }
        }
        #endregion

        private DataAttributeForm dataAttributeForm = new DataAttributeForm();
        private IFeatureLayer tocSelectFeatureLayer = null;//点击图层控件选择的图层
        /// <summary>
        /// 图层控件右键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainTocControl_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            if (e.button == 2)
            {
                esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;
                IBasicMap basicMap = null;
                object data = null, unk = null;
                ILayer layer = null;
                //获取点击的位置,图层等
                mainTocControl.HitTest(e.x, e.y, ref item, ref basicMap, ref layer, ref unk, ref data);

                tocSelectFeatureLayer = layer as IFeatureLayer;
                if (item == esriTOCControlItem.esriTOCControlItemLayer && tocSelectFeatureLayer != null)
                {
                    contextMenuStrip2.Show(Control.MousePosition);
                }
            }
        }
        #endregion

        private void LoadPersonalDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IWorkspaceFactory pAccessWorkspaceFactory;

            OpenFileDialog pOpenFileDialog = new OpenFileDialog();
            pOpenFileDialog.Filter = "Personal Geodatabase(*.mdb)|*.mdb";
            pOpenFileDialog.Title = "打开PersonGeodatabase文件";
            pOpenFileDialog.ShowDialog();

            string pFullPath = pOpenFileDialog.FileName;
            if (pFullPath == "")
            {
                return;
            }
            pAccessWorkspaceFactory = new AccessWorkspaceFactory(); //using ESRI.ArcGIS.DataSourcesGDB;
            //获取工作空间
            IWorkspace pWorkspace = pAccessWorkspaceFactory.OpenFromFile(pFullPath, 0);

            //加载工作空间里的数据
            IEnumDataset pEnumDataset = pWorkspace.get_Datasets(ESRI.ArcGIS.Geodatabase.esriDatasetType.esriDTAny);
            pEnumDataset.Reset();
            //将Enum数据集中的数据一个个读到DataSet中
            IDataset pDataset = pEnumDataset.Next();
            //判断数据集是否有数据
            while (pDataset != null)
            {
                if (pDataset is IFeatureDataset)  //要素数据集
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
                        if (pDataset1 is IFeatureClass)  //要素类
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
                else if (pDataset is IFeatureClass) //要素类
                {
                    IFeatureWorkspace pFeatureWorkspace = (IFeatureWorkspace)pWorkspace;
                    IFeatureLayer pFeatureLayer = new FeatureLayerClass();
                    pFeatureLayer.FeatureClass = pFeatureWorkspace.OpenFeatureClass(pDataset.Name);

                    pFeatureLayer.Name = pFeatureLayer.FeatureClass.AliasName;
                    mainMapControl.Map.AddLayer(pFeatureLayer);
                }
                else if (pDataset is IRasterDataset) //栅格数据集
                {
                    IRasterWorkspaceEx pRasterWorkspace = (IRasterWorkspaceEx)pWorkspace;
                    IRasterDataset pRasterDataset = pRasterWorkspace.OpenRasterDataset(pDataset.Name);
                    //影像金字塔判断与创建
                    IRasterPyramid3 pRasPyrmid;
                    pRasPyrmid = pRasterDataset as IRasterPyramid3;
                    if (pRasPyrmid != null)
                    {
                        if (!(pRasPyrmid.Present))
                        {
                            pRasPyrmid.Create(); //创建金字塔
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
            //同步鹰眼
            SynchronizeEagleEye();
        }

        private void AttributeFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataAttributeForm.Show();
            dataAttributeForm.currentLayer = tocSelectFeatureLayer;
            dataAttributeForm.SetTable();
        }

        private void RemoveLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainMapControl.Map.DeleteLayer(tocSelectFeatureLayer);
        }

        private void AttributeQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpatialQueryForm spatialQueryForm = new SpatialQueryForm(mainMapControl);
            spatialQueryForm.Show();
        }

        public int selectMethod { set; get; }
        private void SpatialQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpatialSelectForm selectForm = new SpatialSelectForm(this, this.mainMapControl);
            selectForm.Show();
        }

        private void BufferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BufferForm bufferForm = new BufferForm(mainMapControl);
            bufferForm.Show();
        }
    }
}