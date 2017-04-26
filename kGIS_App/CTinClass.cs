using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using System.Runtime.InteropServices;

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
                IntPtr _StructIntPtr;
                int _StructSize;
                byte[] data;

                //读取三角集数据
                for (int i = 0; i < datasetTriSize; i++)
                {
                    _StructSize = Marshal.SizeOf(typeof(_dct_tri));
                    data = binaryReader.ReadBytes(_StructSize);
                    _StructIntPtr = Marshal.AllocHGlobal(_StructSize);
                    Marshal.Copy(data, 0, _StructIntPtr, _StructSize);
                    dct_tri = (_dct_tri)Marshal.PtrToStructure(_StructIntPtr, typeof(_dct_tri));
                    if (dct_tri.b == 1)
                    {
                        triList.Add(dct_tri);
                    }
                    Marshal.FreeHGlobal(_StructIntPtr);
                }
                binaryReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        private bool IfTri(_dct_tri tri, int count)
        {
            if (tri.b != 1) return false;
            else if (tri.p1 <= 0 || tri.p2 <= 0 || tri.p3 <= 0) return false;
            else if (tri.p1 > count || tri.p2 > count || tri.p3 > count) return false;
            else return true;
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
            try
            {
                kShpLayer kshpLayer = new kShpLayer();
                List<kShpLayer.kShpLine> shpLineList = new List<kShpLayer.kShpLine>();
                for (int i = 0; i < triList.Count; i++)
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

        /// <summary>
        /// 创建泰森多边形shp文件
        /// </summary>
        /// <param name="thiessanPath"></param>
        /// <returns></returns>
        public IFeatureLayer CreateShpThiessan(string thiessanPath)
        {
            try
            {
                kShpLayer kshpLayer = new kShpLayer();
                List<kShpLayer.kShpLine> shpLineList = new List<kShpLayer.kShpLine>();

                //创建泰森多边形
                List<Thiessan> thiessanList = new List<Thiessan>();
                //初始化泰森多边形的中心点
                for (int i = 0; i < point3dList.Count; i++)
                {
                    Thiessan thiessan = new Thiessan(triList, point3dList);
                    thiessan.ptNum = i;
                    thiessanList.Add(thiessan);
                }

                //将点和三角网对应起来
                for (int i = 0; i < triList.Count; i++)
                {
                    //如果不存在三角网则跳过
                    if (triList[i].b == 0) continue;
                    //如果存在三角网则将本三角形的序号赋给每一个点
                    thiessanList[triList[i].p1].triListNum.Add(i);
                    thiessanList[triList[i].p2].triListNum.Add(i);
                    thiessanList[triList[i].p3].triListNum.Add(i);
                }
                //创建泰森多边形
                for (int i = 0; i < thiessanList.Count; i++)
                {
                    thiessanList[i].CreateTriangle();
                }

                //创建泰森多边形的shp文件
                for (int i = 0; i < thiessanList.Count; i++)
                {
                    List<IPoint> pts = new List<IPoint>();
                    for (int j = 0; j < thiessanList[i].triangleList.Count; j++)
                    {
                        z_doublepoint3d pt = new z_doublepoint3d();
                        pt.x = thiessanList[i].triangleList[j].circlePoint.x;
                        pt.y = thiessanList[i].triangleList[j].circlePoint.y;
                        pt.z = point3dList[thiessanList[i].ptNum].z;
                        IPoint point = new PointClass();
                        point.X = pt.x; point.Y = pt.y; point.Z = pt.z;
                        pts.Add(point);
                    }
                    kShpLayer.kShpLine shpLine = new kShpLayer.kShpLine(pts);
                    shpLineList.Add(shpLine);
                }
                //kShpLayer.kShpLine shpLine = new kShpLayer.kShpLine(pt1, pt2, pt3, true);
                //shpLineList.Add(shpLine);

                return kshpLayer.CreateShpLineFromLine(shpLineList, thiessanPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        class z_verinfo
        {
            public float fver;
            public char[] strMemo;
        }
        [StructLayout(LayoutKind.Sequential), Serializable]
        class _dct_tri
        {
            public int p1, p2, p3;
            public byte b;
        }
        public class z_doublepoint
        {
            public double x, y;
        }
        public class z_doublepoint3d : z_doublepoint
        {
            public double z;
        }
        class _dct_edge2
        {
            public int ptNum1, ptNum2;
        }
        //泰森多边形
        class Thiessan
        {
            public int ptNum;//泰森多边形中心点的编号
            public List<int> triListNum = new List<int>();//中心点所连接的所有三角网的编号
            public List<Triangle> triangleList = new List<Triangle>();//泰森多边形所有的三角网


            List<_dct_tri> triList = new List<_dct_tri>();//所有的三角网以供查询
            List<z_doublepoint3d> ptList = new List<z_doublepoint3d>();//所有的点以供查询

            public Thiessan(List<_dct_tri> triList, List<z_doublepoint3d> ptList)
            {
                this.triList = triList;
                this.ptList = ptList;
            }

            /// <summary>
            /// 创建泰森多边形
            /// </summary>
            public void CreateTriangle()
            {
                //建立泰森多边形的三角网
                for (int i = 0; i < triListNum.Count; i++)
                {
                    //三角形的三个点
                    z_doublepoint3d p1, p2, p3;
                    p1 = ptList[triList[triListNum[i]].p1];
                    p2 = ptList[triList[triListNum[i]].p2];
                    p3 = ptList[triList[triListNum[i]].p3];
                    Triangle triangle = new Triangle(p1, p2, p3);
                    //将本三角网的编号赋值给三角形
                    triangle.triNum = triListNum[i];
                    triangleList.Add(triangle);
                }
                //计算每一个三角形的圆心坐标和与中心点的夹角
                for (int i = 0; i < triListNum.Count; i++)
                {
                    triangleList[i].CirclePoint();
                    //传入中心点计算夹角
                    triangleList[i].ComputeVector(ptList[ptNum]);
                }
                //将所有的圆心点排序
                triangleList.Sort(new AngleCompare());
            }
        }
        public class AngleCompare : IComparer<Triangle>
        {
            public int Compare(Triangle x, Triangle y)
            {
                if (x.angle == y.angle) return 0;
                if (x.angle > y.angle) return 1;
                if (x.angle < y.angle) return -1;
                return 0;
            }
        }

        public class Triangle
        {
            public int triNum;//三角形的编号
            public z_doublepoint3d p1, p2, p3;//三个点
            public z_doublepoint circlePoint;//圆心点
            public double angle;//与中心点的角度
            public Triangle(z_doublepoint3d x, z_doublepoint3d y, z_doublepoint3d z)
            {
                this.p1 = x; this.p2 = y; this.p3 = z;
            }
            //求解三角形外接圆的圆心坐标
            public void CirclePoint()
            {
                circlePoint = new z_doublepoint();
                double a, b, c;
                a = Math.Sqrt(Math.Pow(p1.x - p2.x, 2) + Math.Pow(p1.y - p2.y, 2));
                b = Math.Sqrt(Math.Pow(p1.x - p3.x, 2) + Math.Pow(p1.y - p3.y, 2));
                c = Math.Sqrt(Math.Pow(p3.x - p2.x, 2) + Math.Pow(p3.y - p2.y, 2));
                circlePoint.y = (a + b + c) / 2;
                circlePoint.x = Math.Sqrt(circlePoint.y * (circlePoint.y - a) * (circlePoint.y - b) * (circlePoint.y - c));
            }
            //计算与中心点的角度
            public void ComputeVector(z_doublepoint3d centerPt)
            {
                //计算角度
                angle = ((centerPt.x - circlePoint.x) * (centerPt.x - 1) + (centerPt.y - circlePoint.y) * centerPt.y) /
                ((Math.Sqrt(Math.Pow(centerPt.x - 1, 2) + centerPt.y * centerPt.y)) *
                (Math.Sqrt(Math.Pow(centerPt.x - circlePoint.x, 2) + Math.Pow(centerPt.y - circlePoint.y, 2))));
                angle = Math.Acos(angle);
            }
        }
    }
}