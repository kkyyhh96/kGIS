using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.GeoAnalyst;
using ESRI.ArcGIS.SpatialAnalyst;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Editor;

namespace kGIS_App
{
    public partial class DensityAnalystForm : Form
    {
        private object cellSize = 50;//像元大小
        private object searchRadius = 600;//搜索半径
        private object Missing = Type.Missing;
        private IRasterAnalysisEnvironment rasterEnvironment;//环境分析对象
        private IDensityOp densityObject;//密度分析对象
        private IFeatureClass featureClass;
        private IFeatureClassDescriptor featureDescriptor;
        private IGeoDataset inGeoDataset;//输入数据集
        private IGeoDataset outGeoDataset;//输出数据集
        private object extentEnvironment;

        private AxMapControl mainMapControl = new AxMapControl();

        public DensityAnalystForm(AxMapControl mapControl)
        {
            InitializeComponent();
            this.mainMapControl = mapControl;
        }

        #region 核密度算法
        /// <summary>
        /// 核密度算法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKernelDensity_Click(object sender, EventArgs e)
        {
            try
            {
                densityObject = rasterEnvironment as IDensityOp;
                //核密度分析方法
                outGeoDataset = densityObject.KernelDensity(inGeoDataset, ref searchRadius, Missing);//核密度分析方法
                ShowResult(outGeoDataset, "KernelDensity");
            }
            catch
            {
                MessageBox.Show("请输入点图层");
            };
        }
        #endregion
        #region 点密度算法
        /// <summary>
        /// 点密度算法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPointDensity_Click(object sender, EventArgs e)
        {
            densityObject = rasterEnvironment as IDensityOp;
            //点密度分析方法
            //outGeoDataset = densityObject.PointDensity(inGeoDataset, ref searchRadius, Missing);//核密度分析方法
            //ShowResult(outGeoDataset, "PointDensity");
        }
        #endregion

        //显示分析结果
        private void ShowResult(IGeoDataset geoDataset, string densityType)
        {
            IRasterLayer rasterLayer = new RasterLayerClass();
            IRaster raster = new Raster();
            raster = (IRaster)geoDataset;
            rasterLayer.CreateFromRaster(raster);
            rasterLayer.Name = densityType;

            mainMapControl.AddLayer((ILayer)rasterLayer);
            mainMapControl.ActiveView.Refresh();
        }


        #region 设置环境参数
        /*
                private void cmbNbType_SelectedIndexChanged(object sender, EventArgs e)
                {
                    try
                    {
                        rnh = new RasterNeighborhoodClass();
                        switch (cmbNbType.SelectedIndex)
                        {
                            case 0://邻域分析类型为圆形，半径为20像元
                                rnh.SetCircle(20, esriGeoAnalysisUnitsEnum.esriUnitsCells);
                                break;
                            case 1://邻域分析类型为矩形，高为10像元，宽为20像元
                                rnh.SetRectangle(20, 20, esriGeoAnalysisUnitsEnum.esriUnitsCells);
                                break;
                            case 2://邻域分析类型为环形，内半径为10像元，外半径为30像元
                                rnh.SetAnnulus(10, 30, esriGeoAnalysisUnitsEnum.esriUnitsCells);
                                break;
                        }
                    }
                    catch { }
                }
        */
        #endregion

        /// <summary>
        /// 点击输入数据集获取所有的图层
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbInDataset_MouseClick(object sender, MouseEventArgs e)
        {
            //获取当前所有图层
            this.cmbInDataset.Items.Clear();

            IMap map = mainMapControl.Map;
            if (map != null)
            {
                for (int i = 0; i < map.LayerCount; i++)
                {
                    this.cmbInDataset.Items.Add(map.get_Layer(i).Name);
                }
            }
        }

        /// <summary>
        /// 获取所有的字段名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbInDataset_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //根据图层名获取图层
                string layerName = cmbInDataset.Text;
                IMap map = mainMapControl.Map;
                ILayer layer = null;
                for (int i = 0; i < map.LayerCount; i++)
                {
                    layer = map.get_Layer(i);
                    if (layerName == layer.Name)
                        break;
                }

                //获取所有的字段添加到字段下拉列表中
                IFeatureLayer featureLayer = layer as IFeatureLayer;
                featureClass = featureLayer.FeatureClass;
                for (int i = 0; i < featureClass.Fields.FieldCount; i++)
                {
                    cmbField.Items.Add(featureClass.Fields.get_Field(i).Name);
                }

                extentEnvironment = layer;
                rasterEnvironment.SetExtent(esriRasterEnvSettingEnum.esriRasterEnvValue, ref extentEnvironment, Missing);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DensityAnalystForm_Load(object sender, EventArgs e)
        {
            rasterEnvironment = new RasterDensityOpClass();
        }
        /// <summary>
        /// 获取像元大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxResolution_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cellSize = Convert.ToDouble(tbxResolution.Text);
                rasterEnvironment.SetCellSize(esriRasterEnvSettingEnum.esriRasterEnvValue, ref cellSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 获取核密度算法的搜索半径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxSearchRadius_TextChanged(object sender, EventArgs e)
        {
            try
            {
                searchRadius = Convert.ToDouble(tbxSearchRadius.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 创建输入数据集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbField_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                featureDescriptor = new FeatureClassDescriptorClass();
                featureDescriptor.Create(featureClass, null, cmbField.SelectedText);

                inGeoDataset = featureDescriptor as IGeoDataset;
            }
            catch { }
        }
    }
}
