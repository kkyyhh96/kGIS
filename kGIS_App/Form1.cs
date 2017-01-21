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

namespace kGIS_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

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

        /// <summary>
        /// 加载mxd文档
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
                    }
                    else return;
                }
                catch (Exception except)
                {
                    MessageBox.Show("打开文档失败！\n" + except.ToString());
                }
            }
        }

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
            //mainMapControl.AddLayer(layer);
        }
    }
}