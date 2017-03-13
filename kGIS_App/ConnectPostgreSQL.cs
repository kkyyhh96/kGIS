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
                NpgsqlConnection connection = new NpgsqlConnection("Server = " + connectIP + "; Port = " + connectPort +
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
    }
}
