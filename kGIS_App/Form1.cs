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
                        int lastIndex = shpFullPath.LastIndexOf("\\");
                        mainMapControl.AddShapeFile(shpFullPath.Substring(0, lastIndex), shpFullPath.Substring(lastIndex + 1));
                    }
                    else return;
                }
                catch (Exception except)
                {
                    MessageBox.Show("���ĵ�ʧ�ܣ�\n" + except.ToString());
                }
            }
        }

        private void LoadGridDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.Title = "����դ������";
            openFileDialog.Filter = "Shape�ĵ�(*.shp)|*.shp;";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string shpFullPath = openFileDialog.FileName;
                int lastIndex = shpFullPath.LastIndexOf("\\");
            }
        }
    }
}