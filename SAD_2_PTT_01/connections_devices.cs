using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace SAD_2_PTT_01
{
    class connections_devices
    {
        public MySqlConnection conn;
        MySqlCommand comm;
        MySqlDataAdapter get;
        DataTable set;
        public connections_devices()
        {
            conn = new MySqlConnection("Server=localhost;Database=p_dao;Uid=root;Pwd=root");
        }

        public void get_pending_requests()
        {
            try
            {
                conn.Open();
                comm = new MySqlCommand("SELECT deviceLOG_id, registration_no, dp_name FROM device_log JOIN device_provider ON device_log.dp_id = device_provider.dp_id JOIN pwd ON device_log.pwd_id = pwd.pwd_id ", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);
                DataTable pending_data = new DataTable();


                int count = set.Rows.Count;
                int i = 0;
                while (i != count)
                {

                }

                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
            }
        }
    }
}
