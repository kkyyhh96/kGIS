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
            byte[] strMemoByte = binaryReader.ReadBytes(39);
            var encoding = Encoding.Default;
            this.verinfo.strMemo = encoding.GetChars(strMemoByte);

            //读取点集数据
            int[] tInt = new int[50];
            for (int i = 0; i < 50; i++)
            {
                tInt[i] = binaryReader.ReadInt32();
            }


            byte[] tBytes = binaryReader.ReadBytes(500);
            Console.WriteLine(encoding.GetChars(tBytes));





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
