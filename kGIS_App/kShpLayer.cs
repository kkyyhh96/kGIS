using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geometry;

namespace kGIS_App
{
    /// <summary>
    /// shp图层
    /// </summary>
    public class kShpLayer
    {
        //shp文件里所有的属性值
        public List<kShpField> fieldList = new List<kShpField>();

        //shp文件属性
        public class kShpField
        {
            public string fieldName;
            public int pid;
            public esriFieldType type;
            public kShpField(string name, int pid)
            {
                fieldName = name;
                this.pid = pid;
                switch (pid)
                {
                    case 23: type = esriFieldType.esriFieldTypeInteger; break;
                    case 701: type = esriFieldType.esriFieldTypeDouble; break;
                    default: type = esriFieldType.esriFieldTypeString; break;
                }
            }
        }
        /// <summary>
        /// shp文件点数据
        /// </summary>
        public class kShpPoint
        {
            public double x;
            public double y;
            public List<string> fieldValue = new List<string>();

            public kShpPoint() { }
            public kShpPoint(double x, double y)
            {
                this.x = x;
                this.y = y;
            }
            public kShpPoint(IPoint point)
            {
                this.x = point.X;
                this.y = point.Y;
            }
            public kShpPoint(string coordinates)
            {
                this.x = Convert.ToDouble(coordinates.Split(',')[0].Split('(')[1]);
                this.y = Convert.ToDouble(coordinates.Split(',')[1].Split(')')[0]);
            }
        }
        #region 从点数据中创建一个shp图层
        /// <summary>
        /// 从点数据中创建一个shp图层
        /// </summary>
        /// <param name="kShpPointList">点数据列表</param>
        /// <param name="filePath">shp文件保存路径</param>
        /// <returns></returns>
        public IFeatureLayer CreateShpFromPoint(List<kShpPoint> kShpPointList, string filePath)
        {
            try
            {
                //获取shp文件的名称
                int index = filePath.LastIndexOf('\\');
                string folder = filePath.Substring(0, index);
                string shpName = filePath.Substring(index + 1);

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
                kGeometryDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPoint;//设置为点数据

                //定义坐标系
                ISpatialReferenceFactory spatialReferenceFactory = new SpatialReferenceEnvironmentClass();
                ISpatialReference spatialReference = spatialReferenceFactory.CreateGeographicCoordinateSystem((int)esriSRGeoCSType.esriSRGeoCS_WGS1984);
                kGeometryDefEdit.SpatialReference_2 = spatialReference;
                kFieldEdit.GeometryDef_2 = kGeometryDef;

                //添加几何属性字段
                fieldsEdit.AddField(kField);

                //添加所有字段
                for (int i = 0; i < fieldList.Count; i++)
                {
                    IFieldEdit fieldEdit = new FieldClass();
                    fieldEdit.Name_2 = fieldList[i].fieldName;
                    fieldEdit.Type_2 = fieldList[i].type;
                    //testFieldEdit.Type_2 = ESRI.ArcGIS.Geodatabase.esriFieldType.esriFieldTypeString;
                    fieldsEdit.AddField(fieldEdit);
                }

                //建立要素集
                IFeatureClass featureClass = kFeatureWorkSpace.CreateFeatureClass(shpName, fields, null, null, esriFeatureType.esriFTSimple, "Shape", "");
                IPoint point = new PointClass();

                //使用流的方法批量添加点
                IFeatureCursor featureCursor = featureClass.Insert(true);

                for (int i = 0; i < kShpPointList.Count; i++)
                {
                    point.X = kShpPointList[i].x;
                    point.Y = kShpPointList[i].y;
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
                return featureLayer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        #endregion
        #region 从点数据中创建一个shp线图层
        /// <summary>
        /// 从点数据中创建一个shp线图层
        /// </summary>
        /// <param name="kShpPointList">点数据列表</param>
        /// <param name="filePath">shp文件保存路径</param>
        /// <returns></returns>
        public IFeatureLayer CreateShpLineFromPoint(List<kShpPoint> kShpPointList, string filePath)
        {
            try
            {
                //获取shp文件的名称
                int index = filePath.LastIndexOf('\\');
                string folder = filePath.Substring(0, index);
                string shpName = filePath.Substring(index + 1);

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
                kGeometryDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPolyline;//设置为线数据

                //定义坐标系
                ISpatialReferenceFactory spatialReferenceFactory = new SpatialReferenceEnvironmentClass();
                ISpatialReference spatialReference = spatialReferenceFactory.CreateGeographicCoordinateSystem((int)esriSRGeoCSType.esriSRGeoCS_WGS1984);
                kGeometryDefEdit.SpatialReference_2 = spatialReference;
                kFieldEdit.GeometryDef_2 = kGeometryDefEdit;

                //添加几何属性字段
                fieldsEdit.AddField(kField);

                //添加所有字段
                for (int i = 0; i < fieldList.Count; i++)
                {
                    IFieldEdit fieldEdit = new FieldClass();
                    fieldEdit.Name_2 = fieldList[i].fieldName;
                    fieldEdit.Type_2 = fieldList[i].type;
                    fieldsEdit.AddField(fieldEdit);
                }

                //建立要素集
                IFeatureClass featureClass = kFeatureWorkSpace.CreateFeatureClass(shpName, fields, null, null, esriFeatureType.esriFTSimple, "Shape", "");
                IPoint point = new PointClass();
                IPointCollection pointCollection = new PolylineClass();
                IPolyline polyline;

                //使用流的方法批量添加点
                IFeatureCursor featureCursor = featureClass.Insert(true);

                for (int i = 1; i < kShpPointList.Count; i++)
                {
                    point.X = kShpPointList[i].x;
                    point.Y = kShpPointList[i].y;
                    pointCollection.AddPoint(point);
                }
                polyline = (IPolyline)pointCollection;
                IFeatureBuffer featureBuffer = featureClass.CreateFeatureBuffer();
                featureBuffer.Shape = polyline;
                featureCursor.InsertFeature(featureBuffer);
                featureCursor.Flush();

                IFeatureLayer featureLayer = new FeatureLayerClass();
                featureLayer.Name = shpName;
                featureLayer.FeatureClass = featureClass;
                return featureLayer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        #endregion
    }
}
