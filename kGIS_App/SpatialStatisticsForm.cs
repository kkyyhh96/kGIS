using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;

namespace kGIS_App
{
    public partial class SpatialStatisticsForm : Form
    {
        ILayer layer;
        IFeatureLayer featureLayer;
        AxMapControl mainMapControl;
        public SpatialStatisticsForm(AxMapControl mapControl)
        {
            InitializeComponent();
            mainMapControl = mapControl;
        }

        private void cmbLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            layer = mainMapControl.get_Layer(cmbLayer.SelectedIndex);
            featureLayer = (IFeatureLayer)layer;
            for (int i = 0; i < featureLayer.FeatureClass.Fields.FieldCount; i++)
            {
                cmbField.Items.Add(featureLayer.FeatureClass.Fields.get_Field(i).Name);
            }
        }

        private void cmbField_SelectedIndexChanged(object sender, EventArgs e)
        {
            IDataStatistics dataStatistics = new DataStatisticsClass();
            dataStatistics.Field = featureLayer.FeatureClass.Fields.get_Field(cmbField.SelectedIndex).Name;
            IFeatureSelection featureSelection = featureLayer as IFeatureSelection;
            ICursor cursor = null;
            featureSelection.SelectionSet.Search(null, false, out cursor);
            dataStatistics.Cursor = cursor;
            IStatisticsResults statisticsResult = dataStatistics.Statistics;
            ShowStatisticsResult(statisticsResult.Count, statisticsResult.Minimum, statisticsResult.Maximum, statisticsResult.Sum, statisticsResult.Mean, statisticsResult.StandardDeviation);
        }
        private void ShowStatisticsResult(double count, double min, double max, double sum, double avg, double dev)
        {
            string countString = "统计总数: " + count.ToString() + "\n";
            string minString = "最小值: " + min.ToString() + "\n";
            string maxString = "最大值: " + max.ToString() + "\n";
            string sumString = "总计: " + sum.ToString() + "\n";
            string avgString = "平均值: " + avg.ToString() + "\n";
            string devString = "标准差: " + dev.ToString() + "\n";
            label3.Text = countString + minString + maxString + sumString + avgString + devString;
        }

        private void cmbLayer_MouseClick(object sender, MouseEventArgs e)
        {
            cmbLayer.Items.Clear();
            cmbField.Items.Clear();
            for (int i = 0; i < mainMapControl.LayerCount; i++)
            {
                cmbLayer.Items.Add(mainMapControl.get_Layer(i).Name);
            }
        }
    }
}
