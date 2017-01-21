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

        /// <summary>
        /// ����mxd�ĵ�
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
                    }
                    else return;
                }
                catch (Exception except)
                {
                    MessageBox.Show("���ĵ�ʧ�ܣ�\n" + except.ToString());
                }
            }
        }

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
            //mainMapControl.AddLayer(layer);
        }
    }
}