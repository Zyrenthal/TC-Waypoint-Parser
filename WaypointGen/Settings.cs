using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaypointGen
{
    public partial class Settings : Form
    {
        public ConfigurationSettings configSettings;
        public Settings(ConfigurationSettings configSettings)
        {
            this.configSettings = configSettings;
            InitializeComponent();
            mysqlHostTxt.Text = configSettings.MySQLHost;
            mysqlPortTxt.Text = configSettings.MySQLPort.ToString();
            mysqlUserTxt.Text = configSettings.MySQLUser;
            mysqlPassTxt.Text = configSettings.MySQLPass;
            checkBox1.Checked = configSettings.MySQLEnabled;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.configSettings.MySQLEnabled = checkBox1.Checked;
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            var data = JsonConvert.SerializeObject(this.configSettings);
            File.WriteAllText("config.json", data);
        }

        private void mysqlHostTxt_TextChanged(object sender, EventArgs e)
        {
            this.configSettings.MySQLHost = mysqlHostTxt.Text;
        }

        private void mysqlUserTxt_TextChanged(object sender, EventArgs e)
        {
            this.configSettings.MySQLUser = mysqlUserTxt.Text;
        }

        private void mysqlPortTxt_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(Text, out int value))
            {
                this.configSettings.MySQLPort = value;
            }
        }

        private void mysqlPortTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void testMysqlConnection_Click(object sender, EventArgs e)
        {
            Database database = Database.Instance();
            database.UserName = this.configSettings.MySQLUser;
            database.Password = this.configSettings.MySQLPass;
            database.Server = this.configSettings.MySQLHost;
            database.Port = this.configSettings.MySQLPort;

            if (database.IsConnect())
            {
                MessageBox.Show("Success!  MySQL Connected!");
                //database.Close();
            } else
            {
                MessageBox.Show("Failed!  MySQL not Connected!");
            }
        }
    }

    public class ConfigurationSettings
    {
        public bool MySQLEnabled = false;
        public string MySQLHost = "127.0.0.1";
        public int MySQLPort = 3306;
        public string MySQLUser = "trinity";
        public string MySQLPass = "trinity";
    }
}
