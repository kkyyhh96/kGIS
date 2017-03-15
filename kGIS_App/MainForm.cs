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
            DensityAnalystForm densityAnalystForm = new DensityAnalystForm();
            densityAnalystForm.Show();
        }
        #endregion
        #endregion
    }
}