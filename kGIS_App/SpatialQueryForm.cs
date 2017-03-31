using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Controls;

namespace kGIS_App
{
    public partial class SpatialQueryForm : Form
    {
        AxMapControl mainMapControl;
        IFeatureLayer featureLayer;
        public SpatialQueryForm(AxMapControl mapControl)
        {
            InitializeComponent();
            this.mainMapControl = mapControl;
        }

        #region 按钮
        private void button1_Click(object sender, EventArgs e)
        {
            this.tbxQueryText.Text += this.button1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.tbxQueryText.Text += this.button2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.tbxQueryText.Text += this.button3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.tbxQueryText.Text += this.button4.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.tbxQueryText.Text += this.button5.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.tbxQueryText.Text += this.button6.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.tbxQueryText.Text += this.button7.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.tbxQueryText.Text += this.button8.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.tbxQueryText.Text += this.button9.Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.tbxQueryText.Text += this.button10.Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.tbxQueryText.Text += this.button11.Text;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.tbxQueryText.Text += this.button12.Text;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.tbxQueryText.Text += this.button13.Text;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.tbxQueryText.Text += this.button14.Text;
        }
        #endregion

        private void button15_Click(object sender, EventArgs e)
        {
            this.tbxQueryText.Text = "";
        }

        /// <summary>
        /// 获取所有的图层名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbLayerName_Click(object sender, EventArgs e)
        {
            cmbLayerName.Items.Clear();
            for (int i = 0; i < mainMapControl.Map.LayerCount; i++)
            {
                cmbLayerName.Items.Add(mainMapControl.Map.get_Layer(i).Name);
            }
        }

        /// <summary>
        /// 获取所选图层的所有字段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbLayerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbxFieldName.Items.Clear();
            lbxGetValue.Items.Clear();
            label4.Text = "SELECT * FROM " + cmbLayerName.SelectedItem.ToString() + " WHERE";
            try
            {
                //获取所有的字段名
                ILayer layer = mainMapControl.Map.get_Layer(cmbLayerName.SelectedIndex);
                featureLayer = layer as IFeatureLayer;
                for (int i = 0; i < featureLayer.FeatureClass.Fields.FieldCount; i++)
                {
                    lbxFieldName.Items.Add(featureLayer.FeatureClass.Fields.get_Field(i).AliasName.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 获取该字段下的所有值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbxFieldName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fieldName = lbxFieldName.Text;
            //清空原先的选项
            lbxGetValue.Items.Clear();

            IFeatureCursor featureCursor = featureLayer.FeatureClass.Search(null, true);
            IFeature feature = featureCursor.NextFeature();
            int fieldIndex = lbxFieldName.SelectedIndex;
            //获取所有的值
            while (feature != null)
            {
                if (!lbxGetValue.Items.Contains(feature.get_Value(fieldIndex)))
                {
                    lbxGetValue.Items.Add(feature.get_Value(fieldIndex));
                }
                feature = featureCursor.NextFeature();
            }
        }

        private void lbxFieldName_DoubleClick(object sender, EventArgs e)
        {
            tbxQueryText.Text += lbxFieldName.SelectedItem.ToString();
        }

        private void lbxGetValue_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tbxQueryText.Text += lbxGetValue.SelectedItem.ToString();
        }

        //空间查询
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                mainMapControl.Map.ClearSelection(); //清除上次查询结果
                IActiveView pActiveView = mainMapControl.Map as IActiveView;
                //pQueryFilter的实例化 
                IQueryFilter pQueryFilter = new QueryFilterClass();
                //设置查询过滤条件 
                pQueryFilter.WhereClause = tbxQueryText.Text;

                IFeatureSelection featureSelection = featureLayer as IFeatureSelection;
                featureSelection.SelectFeatures(pQueryFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
                pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, ((IActiveView)mainMapControl.Map).Extent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
