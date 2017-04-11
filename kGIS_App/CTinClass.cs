using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;

namespace kGIS_App
{
    public class CTinClass
    {
        z_verinfo verinfo = new z_verinfo();
        _dct_tri dct_tri = new _dct_tri();
        z_doublepoint doublepoint = new z_doublepoint();
        z_doublepoint3d doublepoint3d = new z_doublepoint3d();
        _dct_edge2 dct_edge2 = new _dct_edge2();

        List<z_doublepoint3d> point3dList = new List<z_doublepoint3d>();
        List<_dct_edge2> edgeList = new List<_dct_edge2>();
        List<_dct_tri> triList = new List<_dct_tri>();

        /// <summary>
        /// 读取ctin文件的数据
        /// </summary>
        /// <param name="filePath"></param>
        public void ReadData(string filePath)
        {
            try
            {
                BinaryReader binaryReader = new BinaryReader(new System.IO.FileStream(filePath, FileMode.Open));

                //读取版本信息
                this.verinfo.fver = binaryReader.ReadSingle();
                //跳过读取系统时间
                binaryReader.ReadBytes(16);
                //读取备注
                byte[] strMemoByte = binaryReader.ReadBytes(1000);
                var encoding = Encoding.Default;
                this.verinfo.strMemo = encoding.GetChars(strMemoByte);

                //读取点数据
                //x,y,z最大最小值
                double xMin = binaryReader.ReadDouble();
                double xMax = binaryReader.ReadDouble();
                double yMin = binaryReader.ReadDouble();
                double yMax = binaryReader.ReadDouble();
                double zMin = binaryReader.ReadDouble();
                double zMax = binaryReader.ReadDouble();
                //点数据集的大小
                int datasetPointSize = binaryReader.ReadInt32();
                //读取点集数据
                for (int i = 0; i < datasetPointSize; i++)
                {
                    doublepoint3d.x = binaryReader.ReadDouble();
                    doublepoint3d.y = binaryReader.ReadDouble();
                    doublepoint3d.z = binaryReader.ReadDouble();
                    point3dList.Add(doublepoint3d);
                    doublepoint3d = new z_doublepoint3d();
                }

                //读取边数据
                //边数据集的大小
                int datasetEdgeSize = binaryReader.ReadInt32();
                //读取边集数据
                for (int i = 0; i < datasetEdgeSize; i++)
                {
                    dct_edge2.ptNum1 = binaryReader.ReadInt32();
                    dct_edge2.ptNum2 = binaryReader.ReadInt32();
                    edgeList.Add(dct_edge2);
                    dct_edge2 = new _dct_edge2();
                }

                //读取三角数据
                //三角数据集的大小
                int datasetTriSize = binaryReader.ReadInt32();
                //读取三角集数据
                for (int i = 0; i < datasetTriSize; i++)
                {
                    dct_tri.p1 = binaryReader.ReadInt32();
                    dct_tri.p2 = binaryReader.ReadInt32();
                    dct_tri.p3 = binaryReader.ReadInt32();
                    dct_tri.b = binaryReader.ReadByte();
                    if (dct_tri.b == 1)
                        triList.Add(dct_tri);
                    dct_tri = new _dct_tri();
                }
                binaryReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// 创建点shp文件
        /// </summary>
        /// <param name="pointPath"></param>
        /// <returns></returns>
        public IFeatureLayer CreateShpPts(string pointPath)
        {
            try
            {
                kShpLayer kshpLayer = new kShpLayer();
                List<kShpLayer.kShpPoint> shpPointList = new List<kShpLayer.kShpPoint>();

                for (int i = 0; i < point3dList.Count; i++)
                {
                    kShpLayer.kShpPoint shpPoint = new kShpLayer.kShpPoint(point3dList[i].x, point3dList[i].y, point3dList[i].z);
                    shpPointList.Add(shpPoint);
                }
                return kshpLayer.CreateShpPointFromPoint(shpPointList, pointPath);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// 创建边shp文件
        /// </summary>
        /// <param name="edgePath"></param>
        /// <returns></returns>
        public IFeatureLayer CreateShpEdge(string edgePath)
        {
            try
            {
                kShpLayer kshpLayer = new kShpLayer();
                List<kShpLayer.kShpLine> shpLineList = new List<kShpLayer.kShpLine>();

                for (int i = 0; i < edgeList.Count; i++)
                {
                    IPoint pt1 = new PointClass();
                    IPoint pt2 = new PointClass();
                    z_doublepoint3d ptStart = point3dList[edgeList[i].ptNum1];
                    z_doublepoint3d ptEnd = point3dList[edgeList[i].ptNum2];
                    pt1.X = ptStart.x;
                    pt1.Y = ptStart.y;
                    pt1.Z = ptStart.z;
                    pt2.X = ptEnd.x;
                    pt2.Y = ptEnd.y;
                    pt2.Z = ptEnd.z;
                    kShpLayer.kShpLine shpLine = new kShpLayer.kShpLine(pt1, pt2);
                    shpLineList.Add(shpLine);
                }
                return kshpLayer.CreateShpLineFromLine(shpLineList, edgePath);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// 创建三角shp文件
        /// </summary>
        /// <param name="triPath"></param>
        /// <returns></returns>
        public IFeatureLayer CreateShpTri(string triPath)
        {
            int i;
            try
            {
                kShpLayer kshpLayer = new kShpLayer();
                List<kShpLayer.kShpLine> shpLineList = new List<kShpLayer.kShpLine>();
                for (i = 0; i < triList.Count; i++)
                {
                    //如果不存在三角网则跳过
                    if (triList[i].b == 0) continue;
                    //如果存在三角网则添加
                    IPoint pt1 = new PointClass();
                    IPoint pt2 = new PointClass();
                    IPoint pt3 = new PointClass();
                    z_doublepoint3d ptStart = point3dList[triList[i].p1];
                    z_doublepoint3d ptMid = point3dList[triList[i].p2];
                    z_doublepoint3d ptEnd = point3dList[triList[i].p3];
                    pt1.X = ptStart.x;
                    pt1.Y = ptStart.y;
                    pt1.Z = ptStart.z;
                    pt2.X = ptMid.x;
                    pt2.Y = ptMid.y;
                    pt2.Z = ptMid.z;
                    pt3.X = ptEnd.x;
                    pt3.Y = ptEnd.y;
                    pt3.Z = ptEnd.z;
                    kShpLayer.kShpLine shpLine = new kShpLayer.kShpLine(pt1, pt2, pt3, true);
                    shpLineList.Add(shpLine);
                }
                return kshpLayer.CreateShpLineFromLine(shpLineList, triPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
    class z_verinfo
    {
        public float fver;
        public char[] strMemo;
    }
    class _dct_tri
    {
        public int p1, p2, p3;
        public byte b;
    }
    class z_doublepoint
    {
        public double x, y;
    }
    class z_doublepoint3d
    {
        public double x, y, z;
    }
    class _dct_edge2
    {
        public int ptNum1, ptNum2;
    }
}
