using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Editor;
using ESRI.ArcGIS.Geometry;

namespace kGIS_App
{
    public partial class DouglasPeukerForm : Form
    {
        AxMapControl mainMapControl;
        double radius;
        ILayer layer;

        public DouglasPeukerForm(AxMapControl mainMap)
        {
            InitializeComponent();
            mainMapControl = mainMap;
        }

        private void DouglasPeukerForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < mainMapControl.LayerCount; i++)
            {
                cmbLayer.Items.Add(mainMapControl.get_Layer(i).Name);
            }
        }

        private void btnDouglasPeuker_Click(object sender, EventArgs e)
        {
            try
            {
                layer = mainMapControl.get_Layer(cmbLayer.SelectedIndex);
                this.radius = Convert.ToDouble(tbxRadius.Text);

                IFeatureLayer featureLayer = layer as IFeatureLayer;
                IFeatureClass featureClass = featureLayer.FeatureClass;
                IFeatureCursor selectFeatureCursor = featureClass.Search(null, false);
                IFeature feature = selectFeatureCursor.NextFeature();

                IPolyline polyline = feature.ShapeCopy as IPolyline;
                IPointCollection pointCollection = polyline as IPointCollection;

                DouglasPeuker(pointCollection);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// 传入点和线方程,获取点到直线距离
        /// </summary>
        /// <param name="point"></param>
        /// <param name="line"></param>
        /// <returns></returns>
        private double DistancePoint2Line(IPoint point, LineEquation line)
        {
            return Math.Abs(line.k * point.X - point.Y + line.b) / Math.Sqrt(1 + line.k * line.k);
        }
        /// <summary>
        /// 传入两个点,获取直线方程
        /// </summary>
        private class LineEquation
        {
            public double k { set; get; }
            public double b { set; get; }
            public LineEquation(IPoint pt1, IPoint pt2)
            {
                k = (pt2.Y - pt1.Y) / (pt2.X - pt1.X);
                b = pt1.Y - k * pt1.X;
            }
        }
        private void DouglasPeuker(IPointCollection pts)
        {
            List<kPoint> kPointPts = new List<kPoint>();
            for (int i = 0; i < pts.PointCount; i++)
            {
                kPointPts.Add(new kPoint(pts.get_Point(i)));
            }
            LineJudge(kPointPts, 0, kPointPts.Count);

            List<kShpLayer.kShpPoint> shpPoints = new List<kShpLayer.kShpPoint>();//从数据库中读取的所有点
            kShpLayer shpLayer = new kShpLayer();
            for (int i = 0; i < pts.PointCount; i++)
            {
                kPoint pt = kPointPts.ElementAt(i);
                if (pt.isSave == true)
                {
                    kShpLayer.kShpPoint point = new kShpLayer.kShpPoint(pt.point);
                    shpPoints.Add(point);
                }
            }

            IFeatureLayer featureLayer = shpLayer.CreateShpLineFromPoint(shpPoints, tbxFilePath.Text);
            mainMapControl.Map.AddLayer(featureLayer);
        }
        private void LineJudge(List<kPoint> pts, int start, int end)
        {
            //获取一条线段
            IPoint pt1 = pts.ElementAt(start).point;
            IPoint pt2 = pts.ElementAt(end - 1).point;
            LineEquation line = new LineEquation(pt1, pt2);

            double disMax = 0;
            int ptIndex = start;
            for (int i = start + 1; i < end; i++)
            {
                IPoint point = pts.ElementAt(i).point;
                double distance;
                distance = DistancePoint2Line(point, line);
                if (distance >= disMax)
                {
                    disMax = distance;
                    ptIndex = i;
                }
            }

            if (disMax < this.radius)
            {
                for (int i = start + 1; i < end - 1; i++)
                {
                    pts.ElementAt(i).isSave = false;
                }
            }
            else
            {
                LineJudge(pts, start, ptIndex);
                LineJudge(pts, ptIndex + 1, end);
            }
        }
        private class kPoint
        {
            public IPoint point { set; get; }
            public bool isSave { set; get; }
            public kPoint(IPoint point)
            {
                this.point = point;
                this.isSave = true;
            }
        }
    }
}
