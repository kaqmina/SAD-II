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
        MySqlCommand comm;
        MySqlDataAdapter get;
        DataTable set;

        public bool login_user(string uname, string pword)
        {
            bool valid = false;
            try
            {
                conn.Open();

                comm = new MySqlCommand("SELECT * FROM p_dao.employee WHERE username = '" + uname + "' AND password = '" + pword + "'", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                if (set.Rows.Count == 1)
                    valid = true;
                else
                    valid = false;

                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                MessageBox.Show(e.Message);
            }
            return valid;

        }

        public void login_get_user_name (int emp_id, string uname)
        {
            try
            {
                conn.Open();

                comm = new MySqlCommand("SELECT * FROM p_dao.employee WHERE employee_id = " + emp_id, conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                uname = set.Rows[0]["username"].ToString();

                conn.Close();
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
                MessageBox.Show("[ERROR_LOGIN_GET_USER_NAME]");
            }
        }
    }
}
