using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Editor;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.GeoAnalyst;
using ESRI.ArcGIS.SpatialAnalyst;

namespace kGIS_App
{
    public partial class DensityAnalystForm : Form
    {
        private double cellSize = 50;//像元大小
        private double searchRadius = 600;//搜索半径
        private IRasterAnalysisEnvironment rasterEnvironment;//环境分析对象
        private IDensityOp densityObject;//密度分析对象
        private IFeatureClass featureClass;
        private IFeatureClassDescriptor featureDescriptor;
        private IGeoDataset inGeoDataset;//输入数据集
        private IGeoDataset outGeoDataset;//输出数据集

        public DensityAnalystForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 核密度算法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKernelDensity_Click(object sender, EventArgs e)
        {

        }

        private void cmbInDataset_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }
    }
}
