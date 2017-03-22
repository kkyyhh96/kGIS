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
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geometry;

namespace kGIS_App
{
    public partial class BufferForm : Form
    {

        AxMapControl mainMapControl;
        public BufferForm(AxMapControl map)
        {
            InitializeComponent();
            mainMapControl = map;
        }

        private void cmbLayerName_Click(object sender, EventArgs e)
        {
            cmbLayerName.Items.Clear();
            for (int i = 0; i < mainMapControl.Map.LayerCount; i++)
            {
                cmbLayerName.Items.Add(mainMapControl.Map.get_Layer(i).Name);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                //获取shp文件的名称
                int index = tbxPath.Text.LastIndexOf('\\');
                string folder = tbxPath.Text.Substring(0, index);
                string shpName = tbxPath.Text.Substring(index + 1);

                //创建工作空间工厂和工作空间
                IWorkspaceFactory kWorkSpaceFactory = new ShapefileWorkspaceFactoryClass();
                IFeatureWorkspace kFeatureWorkSpace = (IFeatureWorkspace)kWorkSpaceFactory.OpenFromFile(folder, 0);

                //创建字段
                IFields fields = new FieldsClass();
                IFieldsEdit fieldsEdit = (IFieldsEdit)fields;

                IField kField = new FieldClass();
                IFieldEdit kFieldEdit = (IFieldEdit)kField;
                kFieldEdit.Name_2 = "Shape";
                kFieldEdit.Type_2 = esriFieldType.esriFieldTypeGeometry;
                IGeometryDef kGeometryDef = new GeometryDefClass();
                IGeometryDefEdit kGeometryDefEdit = (IGeometryDefEdit)kGeometryDef;
                kGeometryDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPolygon;//设置为面数据
                fieldsEdit.AddField(kField);

                //定义坐标系
                ISpatialReferenceFactory spatialReferenceFactory = new SpatialReferenceEnvironmentClass();
                ISpatialReference spatialReference = spatialReferenceFactory.CreateGeographicCoordinateSystem((int)esriSRGeoCSType.esriSRGeoCS_WGS1984);
                kGeometryDefEdit.SpatialReference_2 = spatialReference;
                kFieldEdit.GeometryDef_2 = kGeometryDef;

                //建立要素集
                IFeatureClass featureClass = kFeatureWorkSpace.CreateFeatureClass(shpName, fields, null, null, esriFeatureType.esriFTSimple, "Shape", "");
                IFeatureCursor featureCursor = featureClass.Insert(true);

                //获取图层中所有需要构建缓冲区的要素
                IFeatureLayer selectFeatureLayer = mainMapControl.Map.get_Layer(cmbLayerName.SelectedIndex) as IFeatureLayer;
                IFeatureClass selectFeatureClass = selectFeatureLayer.FeatureClass;
                IFeatureCursor selectFeatureCursor = selectFeatureClass.Search(null, false);
                IFeature selectFeature = selectFeatureCursor.NextFeature();
                //遍历所有需要构建缓冲区的要素
                while (selectFeature != null)
                {
                    IGeometry selectGeometry = selectFeature.Shape;
                    ITopologicalOperator topologicalOperator = (ITopologicalOperator)selectGeometry;

                    //进行缓冲区分析
                    IGeometry bufferGeometry = topologicalOperator.Buffer(Convert.ToDouble(tbxRadius.Text));

                    //创建新的要素作为缓冲区结果
                    IFeatureBuffer featureBuffer = featureClass.CreateFeatureBuffer();
                    featureBuffer.Shape = bufferGeometry;
                    featureCursor.InsertFeature(featureBuffer);
                    selectFeature = selectFeatureCursor.NextFeature();
                }
                featureCursor.Flush();
                //将缓冲区结果创建为新的shp文件并保存和显示
                IFeatureLayer featureLayer = new FeatureLayerClass();
                featureLayer.Name = shpName;
                featureLayer.FeatureClass = featureClass;
                mainMapControl.Map.AddLayer(featureLayer);
                mainMapControl.ActiveView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
