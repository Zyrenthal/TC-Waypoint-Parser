using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaypointGen
{
    public class Database
    {
        private Database() { }

        public string Server { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public MySqlConnection Connection { get; set; }

        private static Database _instance = null;
        public static Database Instance()
        {
            if (_instance == null)
                _instance = new Database();
            return _instance;
        }

        public bool IsConnect()
        {
            if (Connection == null)
            {
                string connstr = string.Format("Server={0}; Port={1}; database=world; UID={2}; password={3}", Server, Port, UserName, Password);
                Connection = new MySqlConnection(connstr);
                Connection.Open();
            }

            return true;
        }

        public void Close()
        {
            Connection.Close();
        }

        public int FindBestMatchMob(int entryId, int mapId, double pos_x, double pos_y)
        {
            if (!IsConnect())
            {
                return -1;
            }

            double pos_x_lower = Math.Floor(pos_x) - 5;
            double pos_x_higher = Math.Floor(pos_x) + 5;
            double pos_y_lower = Math.Floor(pos_y) - 5;
            double pos_y_higher = Math.Floor(pos_y) + 5;

            String query = string.Format("SELECT guid FROM creature WHERE id = {0} AND map = {1} AND (position_x < {2} AND position_x > {3}) AND (position_y < {4} AND position_y > {5}) LIMIT 1;",
                entryId, mapId, pos_x_higher, pos_x_lower, pos_y_higher, pos_y_lower);

            var cmd = new MySqlCommand(query, Connection);
            var reader = cmd.ExecuteReader();
            int guid = -1;
            if (reader.Read())
            {
                guid = reader.GetInt32(0);
            }
            reader.Close();
            return guid;
        }
    }
}
