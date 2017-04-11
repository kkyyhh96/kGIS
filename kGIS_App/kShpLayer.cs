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
            public double z = 0;
            public List<string> fieldValue = new List<string>();

            public kShpPoint() { }
            public kShpPoint(double x, double y, double z = 0)
            {
                this.x = x;
                this.y = y;
                this.z = z;
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
        public class kShpLine
        {
            public IPointCollection pointCollection = new PolylineClass();
            public kShpLine(IPoint pt1, IPoint pt2, bool circle = false)
            {
                pointCollection.AddPoint(pt1);
                pointCollection.AddPoint(pt2);
                if (circle)
                {
                    pointCollection.AddPoint(pt1);
                }
            }
            public kShpLine(IPoint pt1, IPoint pt2, IPoint pt3, bool circle = false)
            {
                pointCollection.AddPoint(pt1);
                pointCollection.AddPoint(pt2);
                pointCollection.AddPoint(pt3);
                if (circle)
                {
                    pointCollection.AddPoint(pt1);
                }
            }

        }

        /// <summary>
        /// 将要素类传入并创建图层
        /// </summary>
        /// <param name="shpName"></param>
        /// <param name="featureClass"></param>
        /// <returns></returns>
        private static IFeatureLayer CreateFeatureLayer(string shpName, IFeatureClass featureClass)
        {
            IFeatureLayer featureLayer = new FeatureLayerClass();
            featureLayer.Name = shpName;
            featureLayer.FeatureClass = featureClass;
            return featureLayer;
        }

        /// <summary>
        /// 创建要素类所有的字段
        /// </summary>
        /// <param name="fieldsEdit"></param>
        private void CreateShpFields(IFieldsEdit fieldsEdit)
        {
            //添加所有字段
            for (int i = 0; i < fieldList.Count; i++)
            {
                IFieldEdit fieldEdit = new FieldClass();
                fieldEdit.Name_2 = fieldList[i].fieldName;
                fieldEdit.Type_2 = fieldList[i].type;
                //testFieldEdit.Type_2 = ESRI.ArcGIS.Geodatabase.esriFieldType.esriFieldTypeString;
                fieldsEdit.AddField(fieldEdit);
            }
        }

        /// <summary>
        /// shp文件所需的基本参数
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="shpName"></param>
        /// <param name="kFeatureWorkSpace"></param>
        /// <param name="fields"></param>
        /// <param name="fieldsEdit"></param>
        /// <param name="kField"></param>
        /// <param name="kGeometryDefEdit"></param>
        private static void CreateShpDefaultSetting(string filePath, out string shpName, out IFeatureWorkspace kFeatureWorkSpace, out IFields fields, out IFieldsEdit fieldsEdit, out IField kField, out IGeometryDefEdit kGeometryDefEdit)
        {
            //获取shp文件的名称
            int index = filePath.LastIndexOf('\\');
            string folder = filePath.Substring(0, index);
            shpName = filePath.Substring(index + 1);

            //创建工作空间工厂和工作空间
            IWorkspaceFactory kWorkSpaceFactory = new ShapefileWorkspaceFactoryClass();
            kFeatureWorkSpace = (IFeatureWorkspace)kWorkSpaceFactory.OpenFromFile(folder, 0);

            //创建字段
            fields = new FieldsClass();
            fieldsEdit = (IFieldsEdit)fields;

            kField = new FieldClass();
            IFieldEdit kFieldEdit = (IFieldEdit)kField;
            kFieldEdit.Name_2 = "Shape";
            kFieldEdit.Type_2 = esriFieldType.esriFieldTypeGeometry;
            IGeometryDef kGeometryDef = new GeometryDefClass();
            kGeometryDefEdit = (IGeometryDefEdit)kGeometryDef;

            //定义坐标系
            ISpatialReferenceFactory spatialReferenceFactory = new SpatialReferenceEnvironmentClass();
            ISpatialReference spatialReference = spatialReferenceFactory.CreateGeographicCoordinateSystem((int)esriSRGeoCSType.esriSRGeoCS_WGS1984);
            kGeometryDefEdit.SpatialReference_2 = spatialReference;
            kFieldEdit.GeometryDef_2 = kGeometryDef;
        }

        #region 从点数据中创建一个shp点图层
        /// <summary>
        /// 从点数据中创建一个shp点图层
        /// </summary>
        /// <param name="kShpPointList">点数据列表</param>
        /// <param name="filePath">shp文件保存路径</param>
        /// <returns></returns>
        public IFeatureLayer CreateShpPointFromPoint(List<kShpPoint> kShpPointList, string filePath)
        {
            try
            {
                string shpName;
                IFeatureWorkspace kFeatureWorkSpace;
                IFields fields;
                IFieldsEdit fieldsEdit;
                IField kField;
                IGeometryDefEdit kGeometryDefEdit;
                CreateShpDefaultSetting(filePath, out shpName, out kFeatureWorkSpace, out fields, out fieldsEdit, out kField, out kGeometryDefEdit);

                kGeometryDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPoint;//设置为点数据
                //添加几何属性字段
                fieldsEdit.AddField(kField);

                CreateShpFields(fieldsEdit);

                //建立要素集
                IFeatureClass featureClass = kFeatureWorkSpace.CreateFeatureClass(shpName, fields, null, null, esriFeatureType.esriFTSimple, "Shape", "");
                //创建点
                IPoint point = new PointClass();

                //使用流的方法批量添加点
                IFeatureCursor featureCursor = featureClass.Insert(true);

                for (int i = 1; i < kShpPointList.Count; i++)
                {
                    point.X = kShpPointList[i].x;
                    point.Y = kShpPointList[i].y;
                    point.Z = kShpPointList[i].z;
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

                return CreateFeatureLayer(shpName, featureClass);
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
                string shpName;
                IFeatureWorkspace kFeatureWorkSpace;
                IFields fields;
                IFieldsEdit fieldsEdit;
                IField kField;
                IGeometryDefEdit kGeometryDefEdit;
                CreateShpDefaultSetting(filePath, out shpName, out kFeatureWorkSpace, out fields, out fieldsEdit, out kField, out kGeometryDefEdit);

                kGeometryDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPolyline;//设置为线数据
                //添加几何属性字段
                fieldsEdit.AddField(kField);

                CreateShpFields(fieldsEdit);

                //建立要素集
                IFeatureClass featureClass = kFeatureWorkSpace.CreateFeatureClass(shpName, fields, null, null, esriFeatureType.esriFTSimple, "Shape", "");
                //创建线
                IPoint point = new PointClass();
                IPointCollection pointCollection = new PolylineClass();
                IPolyline polyline;

                //使用流的方法批量添加线
                IFeatureCursor featureCursor = featureClass.Insert(true);

                for (int i = 0; i < kShpPointList.Count; i++)
                {
                    point.X = kShpPointList[i].x;
                    point.Y = kShpPointList[i].y;
                    //将点添加到点集中
                    pointCollection.AddPoint(point);
                }
                polyline = (IPolyline)pointCollection;
                IFeatureBuffer featureBuffer = featureClass.CreateFeatureBuffer();
                featureBuffer.Shape = polyline;
                featureCursor.InsertFeature(featureBuffer);
                featureCursor.Flush();

                return CreateFeatureLayer(shpName, featureClass);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        #endregion

        #region 从线数据中创建一个shp线图层
        /// <summary>
        /// 从点数据中创建一个shp线图层
        /// </summary>
        /// <param name="kShpPointList">点数据列表</param>
        /// <param name="filePath">shp文件保存路径</param>
        /// <returns></returns>
        public IFeatureLayer CreateShpLineFromLine(List<kShpLine> kShpLineList, string filePath)
        {
            try
            {
                string shpName;
                IFeatureWorkspace kFeatureWorkSpace;
                IFields fields;
                IFieldsEdit fieldsEdit;
                IField kField;
                IGeometryDefEdit kGeometryDefEdit;
                CreateShpDefaultSetting(filePath, out shpName, out kFeatureWorkSpace, out fields, out fieldsEdit, out kField, out kGeometryDefEdit);

                kGeometryDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPolyline;//设置为线数据
                //添加几何属性字段
                fieldsEdit.AddField(kField);

                CreateShpFields(fieldsEdit);

                //建立要素集
                IFeatureClass featureClass = kFeatureWorkSpace.CreateFeatureClass(shpName, fields, null, null, esriFeatureType.esriFTSimple, "Shape", "");
                //创建线
                IPoint point = new PointClass();
                IPointCollection pointCollection = new PolylineClass();
                IPolyline polyline;

                //使用流的方法批量添加线
                IFeatureCursor featureCursor = featureClass.Insert(true);

                for (int i = 0; i < kShpLineList.Count; i++)
                {
                    polyline = (IPolyline)kShpLineList[i].pointCollection;
                    IFeatureBuffer featureBuffer = featureClass.CreateFeatureBuffer();
                    featureBuffer.Shape = polyline;
                    featureCursor.InsertFeature(featureBuffer);
                }
                featureCursor.Flush();

                return CreateFeatureLayer(shpName, featureClass);
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
