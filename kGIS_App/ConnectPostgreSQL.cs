using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Controls;

namespace kGIS_App
{
    public partial class ConnectPostgreSQL : Form
    {
        string connectIP, connectPort, connectDatabaseName, connectUserName, connectPassword;//连接相关设置
        NpgsqlConnection connection;//与数据库的连接
        string coordinateField, shpPath;//资料相关设置
        AxMapControl mainMapControl = new AxMapControl();//主窗口中的主地图
        MainForm mainForm = new MainForm();//获取主窗口

        public ConnectPostgreSQL(MainForm mainForm, AxMapControl mainMap)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            mainMapControl = mainMap;
        }

        #region 窗体信息获取
        #region 连接数据库
        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDatabaseConnect_Click(object sender, EventArgs e)
        {
            bool connectionResult = false;
            try
            {
                //读取数据库连接信息
                connectIP = tbxIP.Text;
                connectPort = tbxPort.Text;
                connectDatabaseName = tbxDatabaseName.Text;
                connectUserName = tbxUserName.Text;
                connectPassword = tbxPassword.Text;

                //连接数据库
                connection = new NpgsqlConnection("Server = " + connectIP + "; Port = " + connectPort +
                                   "; UserId = " + connectUserName + "; Password = " + connectPassword + ";Database = " + connectDatabaseName);
                connection.Open();
                connectionResult = true;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
            if (connectionResult == true)
            {
                //如果连接成功
                MessageBox.Show("Connection Successfully!");
            }
        }
        #endregion

        private void cmbPoint_SelectedValueChanged(object sender, EventArgs e)
        {
            coordinateField = cmbPoint.Text;
        }

        private void cmbPoint_Click(object sender, EventArgs e)
        {

        }

        private void cmbPoint_DropDown(object sender, EventArgs e)
        {
            try
            {
                //查询字段名称
                string tableName = tbxTableName.Text;
                string sqlCommand = "select attname from pg_attribute where attrelid = ( select relfilenode from pg_class where relname = '" + tableName + "') and attnum > 0;";
                NpgsqlCommand command = new NpgsqlCommand(sqlCommand, connection);

                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cmbPoint.Items.Add(reader.GetString(0));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("未连接到数据库");
            }
        }

        private void ConnectPostgreSQL_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.SynchronizeEagleEye();
        }
        #endregion
        #region 从数据库中导出数据为shp文件
        /// <summary>
        /// 将PostgreSQL的数据导出为shp文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportData_Click(object sender, EventArgs e)
        {
            List<kShpLayer.kShpPoint> shpPoints = new List<kShpLayer.kShpPoint>();//从数据库中读取的所有点
            kShpLayer shpLayer = new kShpLayer();//新建的shp图层

            //从数据库中读取数据
            string sqlCommand = "select " + coordinateField + " from " + tbxTableName.Text + " limit 100;";
            NpgsqlCommand command = new NpgsqlCommand(sqlCommand, connection);
            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                kShpLayer.kShpPoint pt = new kShpLayer.kShpPoint(reader.GetString(0));
                shpPoints.Add(pt);
            }
            reader.Close();
            //读取数据完毕后添加到新图层中
            IFeatureLayer featureLayer = shpLayer.CreateShpFromPoint(shpPoints, tbxShpPath.Text);
            mainMapControl.Map.AddLayer(featureLayer);

            //同步鹰眼
            mainForm.SynchronizeEagleEye();
        }
        #endregion
    }
}
