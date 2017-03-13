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
        /// <summary>
        /// shp文件点数据
        /// </summary>
        public class kShpPoint
        {
            public double x;
            public double y;
            public Dictionary<string, string> attribute = new Dictionary<string, string>();
        }

        /// <summary>
        /// 从点数据中创建一个shp图层
        /// </summary>
        /// <param name="kShpPointList">点数据列表</param>
        /// <param name="filePath">shp文件保存路径</param>
        /// <returns></returns>
        private IFeatureLayer CreateShpFromPoint(List<kShpPoint> kShpPointList,string filePath)
        {
            //获取shp文件的名称
            int index = filePath.LastIndexOf('\\');
            string folder = filePath.Substring(0, index);
            string shpName = filePath.Substring(index + 1);

            //创建工作空间工厂和工作空间
            IWorkspaceFactory kWorkSpaceFactory = new ShapefileWorkspaceFactoryClass();
            IFeatureWorkspace kFeatureWorkSpace = (IFeatureWorkspace)kWorkSpaceFactory.OpenFromFile(folder, 0);
            
            //创建字段
            IField kField = new FieldClass();
            IFieldEdit kFieldEdit=(IFieldEdit)kField;
            kFieldEdit.Name_2 = "Shape";
            kFieldEdit.Type_2 = esriFieldType.esriFieldTypeGeometry;
            IGeometryDef kGeometryDef = new GeometryDefClass();
            IGeometryDefEdit kGeometryDefEdit = (IGeometryDefEdit)kGeometryDef;
            kGeometryDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPoint;//设置为点数据

            ISpatialReferenceFactory kSRF = new SpatialReferenceEnvironmentClass();
            //定义坐标系

        }
    }
}
