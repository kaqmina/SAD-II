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
    class connections_user
    {
        public MySqlConnection conn;
        MySqlCommand comm;
        MySqlDataAdapter get;
        DataTable set;
        public main_form reference_to_main { get; set; }
        public connections_user()
        {
            conn = new MySqlConnection("Server=localhost;Database=p_dao;Uid=root;Pwd=root;Allow User Variables=True");
        }

        public bool get_user_cbox(ComboBox user_cbox)
        {
            bool has_data = false;
            user_cbox.Items.Clear();
            user_cbox.Items.Add("");
            try
            {
                conn.Open();
                comm = new MySqlCommand("SELECT username FROM employee WHERE status_id = 1 ORDER BY username ASC", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                int count = set.Rows.Count;
                if (count == 0)
                {
                    user_cbox.Items.Add("No users added.");
                    has_data = false;
                }
                else
                {
                    foreach (DataRow data in set.Rows)
                    {
                        user_cbox.Items.Add(data["username"].ToString());
                    }
                    has_data = true;
                }
                
                conn.Close();
            }  catch (Exception e)
            {
                conn.Close();
                has_data = false;
            }
            return has_data;
        }

        public string get_user_id_by_name(string username)
        {
            string ret_user_id;
            try
            {
                conn.Open();

                comm = new MySqlCommand("SELECT employee_id FROM employee WHERE username = '" + username + "'", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                ret_user_id = set.Rows[0]["employee_id"].ToString();

                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
                ret_user_id = "";
            }
            return ret_user_id;
        }
    }
}
