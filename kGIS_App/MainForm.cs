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
            DensityAnalystForm densityAnalystForm = new DensityAnalystForm();
            densityAnalystForm.Show();
        }
        #endregion
        #endregion
    }
}