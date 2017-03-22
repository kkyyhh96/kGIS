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

namespace kGIS_App
{
    public partial class DataAttributeForm : Form
    {
        public DataAttributeForm()
        {
            InitializeComponent();
        }
        private ILayer pLayer;//打开属性表的图层
        private IFeatureLayer pFeatureLayer;
        private IFeatureClass pFeatureClass;
        private ILayerFields pLayerFields;

        public IFeatureLayer currentLayer { set; get; }
        public void SetTable()
        {
            try
            {
                pLayer = currentLayer;

                pFeatureLayer = pLayer as IFeatureLayer;
                pFeatureClass = pFeatureLayer.FeatureClass;
                pLayerFields = pFeatureLayer as ILayerFields;
                DataSet ds = new DataSet("dsTest");
                DataTable dt = new DataTable(pFeatureLayer.Name);
                DataColumn dc = null;
                for (int i = 0; i < pLayerFields.FieldCount; i++)
                {
                    dc = new DataColumn(pLayerFields.get_Field(i).Name);
                    dt.Columns.Add(dc);
                    dc = null;
                }
                IFeatureCursor pFeatureCursor = pFeatureClass.Search(null, false);
                IFeature pFeature = pFeatureCursor.NextFeature();
                while (pFeature != null)
                {
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < pLayerFields.FieldCount; j++)
                    {
                        if (pLayerFields.FindField(pFeatureClass.ShapeFieldName) == j)
                        {
                            dr[j] = pFeatureClass.ShapeType.ToString();
                        }
                        else
                        {
                            dr[j] = pFeature.get_Value(j);
                        }
                    }
                    dt.Rows.Add(dr);
                    pFeature = pFeatureCursor.NextFeature();
                }
                dataGridView.DataSource = dt;
                //if (currentLayer == null) { return; }
                //IFeature feature = null;
                //DataTable dataTable = new DataTable();
                //DataRow dataRow = null;
                //DataColumn dataColumn = null;
                //IField field = null;
                ////创建表的字段名
                //for (int i = 0; i < currentLayer.FeatureClass.Fields.FieldCount; i++)
                //{
                //    dataColumn = new DataColumn();
                //    field = currentLayer.FeatureClass.Fields.get_Field(i);
                //    dataColumn.ColumnName = field.AliasName;
                //    dataTable.Columns.Add(dataColumn);
                //}
                ////添加具体的数据
                //IFeatureCursor cursor = currentLayer.Search(null, true);
                //feature = cursor.NextFeature();
                //while (feature != null)
                //{
                //    dataRow = dataTable.NewRow();
                //    for (int i = 0; i < dataTable.Columns.Count; i++)
                //    {
                //        dataRow[i] = feature.get_Value(i);
                //    }
                //    dataTable.Rows.Add(dataRow);
                //    cursor.NextFeature();
                //}
                ////释放指针
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(cursor);
                ////设置为数据源
                //dataGridView.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.Dispose();
            }
        }
    }
}
