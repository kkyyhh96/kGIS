using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
                doublepoint3d.x = binaryReader.ReadInt64();
                doublepoint3d.y = binaryReader.ReadInt64();
                doublepoint3d.z = binaryReader.ReadInt64();
                point3dList.Add(doublepoint3d);
                doublepoint3d = new z_doublepoint3d();
            }

            //读取边数据
            //边数据集的大小
            int datasetEdgeSize = binaryReader.ReadInt32();
            //读取边集数据
            for (int i = 0; i < datasetEdgeSize; i++)
            {
                dct_edge2.ptNum1 = binaryReader.ReadInt64();
                dct_edge2.ptNum2 = binaryReader.ReadInt64();
                edgeList.Add(dct_edge2);
                dct_edge2 = new _dct_edge2();
            }

            //读取三角数据
            //三角数据集的大小
            int datasetTriSize = binaryReader.ReadInt32();
            //读取三角集数据
            for (int i = 0; i < datasetTriSize; i++)
            {
                dct_tri.p1 = binaryReader.ReadInt64();
                dct_tri.p2 = binaryReader.ReadInt64();
                dct_tri.p3 = binaryReader.ReadInt64();
                dct_tri.b = binaryReader.ReadByte();
                triList.Add(dct_tri);
                dct_tri = new _dct_tri();
            }
            binaryReader.Close();
        }
    }
    class z_verinfo
    {
        public float fver;
        public char[] strMemo;
    }
    class _dct_tri
    {
        public long p1, p2, p3;
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
        public long ptNum1, ptNum2;
    }
}
