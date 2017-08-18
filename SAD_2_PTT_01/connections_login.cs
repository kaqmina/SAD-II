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
    class connections_login
    {
        public MySqlConnection conn;
        public connections_login()
        {
            conn = new MySqlConnection("Server=localhost;Database=p_dao;Uid=root;Pwd=root");
        }

        public bool login_user(string uname, string pword)
        {
            bool valid = false;
            try
            {
                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT * FROM p_dao.employee WHERE username = '" + uname + "' AND password = '" + pword + "'", conn);
                MySqlDataAdapter get = new MySqlDataAdapter(comm);
                DataTable set = new DataTable();
                get.Fill(set);

                if (set.Rows.Count == 1)
                    valid = true;
                else
                    valid = false;

                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return valid;

        }
    }
}
