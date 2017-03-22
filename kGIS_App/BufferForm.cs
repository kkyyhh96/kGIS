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

            //定义坐标系
            ISpatialReferenceFactory spatialReferenceFactory = new SpatialReferenceEnvironmentClass();
            ISpatialReference spatialReference = spatialReferenceFactory.CreateGeographicCoordinateSystem((int)esriSRGeoCSType.esriSRGeoCS_WGS1984);
            kGeometryDefEdit.SpatialReference_2 = spatialReference;
            kFieldEdit.GeometryDef_2 = kGeometryDef;

            //建立要素集
            IFeatureClass featureClass = kFeatureWorkSpace.CreateFeatureClass(shpName, fields, null, null, esriFeatureType.esriFTSimple, "Shape", "");

            //使用流的方法批量添加点
            IFeatureCursor featureCursor = featureClass.Insert(true);

            for (int i = 0; i < kShpPointList.Count; i++)
            {
                point.X = kShpPointList[i].x;
                point.Y = kShpPointList[i].y;
                point.Z = 10;
                point.M = 10;
                IFeatureBuffer featureBuffer = featureClass.CreateFeatureBuffer();
                featureBuffer.Shape = point;
                //添加字段值
                for (int j = 0; j < kShpPointList[i].fieldValue.Count; j++)
                {

                    featureBuffer.set_Value(2 + j, kShpPointList[i].fieldValue[j]);
                }
                featureCursor.InsertFeature(featureBuffer);
            }
            featureCursor.Flush();

            IFeatureLayer featureLayer = new FeatureLayerClass();
            featureLayer.Name = shpName;
            featureLayer.FeatureClass = featureClass;
        }

        private void cmbLayerName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
