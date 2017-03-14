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

namespace kGIS_App
{
    public partial class ConnectPostgreSQL : Form
    {
        string connectIP, connectPort, connectDatabaseName, connectUserName, connectPassword;
        NpgsqlConnection connection;
        string coordinateField, shpPath;

        public ConnectPostgreSQL()
        {
            InitializeComponent();
        }

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

        private void cmbPoint_SelectedValueChanged(object sender, EventArgs e)
        {
            coordinateField = cmbPoint.Text;
        }

        private void cmbPoint_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 将PostgreSQL的数据导出为shp文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportData_Click(object sender, EventArgs e)
        {
            string sqlCommand = "select " + coordinateField + " from " + tbxTableName + " limit 1;";
            NpgsqlCommand command = new NpgsqlCommand(sqlCommand, connection);
            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(0));
                kShpLayer.kShpPoint pt = new kShpLayer.kShpPoint();

            }
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
                    Console.WriteLine(reader.GetString(0));
                    cmbPoint.Items.Add(reader.GetString(0));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("未连接到数据库");
            }
        }

    }
}
