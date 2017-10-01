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
                comm = new MySqlCommand("SELECT username FROM user WHERE status_id = 1 ORDER BY username ASC", conn);
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

                comm = new MySqlCommand("SELECT user_id FROM user WHERE username = '" + username + "'", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                ret_user_id = set.Rows[0]["user_id"].ToString();

                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
                ret_user_id = "";
            }
            return ret_user_id;
        }

        public bool get_user_data(DataGridView users_grid)
        {
            bool has_data = false;
            try
            {
                conn.Open();
                Console.WriteLine("[EXECUTE] - [CONNECTIONS_USER] get_user_data()");
                comm = new MySqlCommand("SELECT firstname, "
                                             + "middlename, "
                                             + "lastname, "
                                             + "(CASE WHEN position = 0 THEN 'Admin' WHEN position = 1 THEN 'Inventory Manager' WHEN position = 2 THEN 'Project Manager' ELSE 'IT Officer' END) AS position, "
                                             + "CONCAT(lastname, ', ', firstname, ' ', middlename) AS fullname, "
                                             + "contact_no, "
                                             + "(CASE WHEN status_id = 1 THEN 'Active' WHEN status_id = 0 THEN 'Inactive' ELSE 'Break' END) AS status_id, "
                                             + "username, "
                                             + "password, "
                                             + "user_id "
                                             + "FROM user ORDER BY user_id", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                DataTable user_data = new DataTable();
                DataColumn column;
                DataRow row;
                DataView view;

                #region Columns
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "firstname";
                user_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "middlename";
                user_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "lastname";
                user_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "position";
                user_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "fullname";
                user_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "contact_no";
                user_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "status_id";
                user_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "username";
                user_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "password";
                user_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "user_id";
                user_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "display_text";
                user_data.Columns.Add(column);
                #endregion

                int count = set.Rows.Count;
                if (count == 0)
                {
                    string none = "None";
                    row = user_data.NewRow();
                    row["firstname"] = none;
                    row["middlename"] = none;
                    row["position"] = none;
                    row["lastname"] = none;
                    row["contact_no"] = none;
                    row["fullname"] = none;
                    row["status_id"] = "0";
                    row["username"] = none;
                    row["password"] = none;
                    row["user_id"] = "0";
                    row["display_text"] = "There are no users added.";
                    user_data.Rows.Add(row);
                    has_data = false;
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        row = user_data.NewRow();
                        row["firstname"] = set.Rows[i]["firstname"].ToString();
                        row["middlename"] = set.Rows[i]["middlename"].ToString();
                        row["lastname"] = set.Rows[i]["lastname"].ToString();
                        row["position"] = set.Rows[i]["position"].ToString();
                        row["fullname"] = set.Rows[i]["fullname"].ToString();
                        row["contact_no"] = set.Rows[i]["contact_no"].ToString();
                        row["status_id"] = set.Rows[i]["status_id"].ToString();
                        row["username"] = set.Rows[i]["username"].ToString();
                        row["password"] = set.Rows[i]["password"].ToString();
                        row["user_id"] = set.Rows[i]["user_id"].ToString();
                        row["display_text"] = " ";
                        user_data.Rows.Add(row);
                    }
                    has_data = true;
                }

                view = new DataView(user_data);

                users_grid.DataSource = view;

                conn.Close();
                Console.WriteLine("[SUCCESS] - [CONNECTIONS_USER] get_user_data()");
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("[ERROR] - [CONNECTIONS_USER] get_user_data() : " + e.Message);
            }
            return has_data;
        }

        public bool add_user(string firstname, string middlename, string lastname, string position, string contact_no,
            string status, string username, string password)
        {
            bool success = false;

            try
            {
                conn.Open();

                comm = new MySqlCommand("INSERT INTO user(firstname, middlename, lastname, position, contact_no, status_id, username, password) VALUES "
                                                  + "('"+ firstname +"','"
                                                  + middlename +"','"
                                                  + lastname +"',"
                                                  + position +",'"
                                                  + contact_no +"',"
                                                  + status +",'"
                                                  + username +"','"
                                                  + password +"')", conn);
                comm.ExecuteNonQuery();
                success = true;

                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("[ERROR] - [CONNECTIONS_USER] add_user() : " + e.Message);
                success = false;
            }

            return success;
        }

        public bool update_user(string firstname, string middlename, string lastname, string position, string contact_no,
            string status, string username, string password, string user_id)
        {
            bool success = false;

            try
            {
                conn.Open();

                comm = new MySqlCommand("UPDATE user SET firstname = '"+ firstname +"', "
                                                          + "middlename = '"+ middlename +"', "
                                                          + "lastname = '"+ lastname +"', "
                                                          + "position = "+ position +", "
                                                          + "contact_no = '"+ contact_no +"',"
                                                          + "status_id = "+ status +","
                                                          + "username = '"+ username +"', "
                                                          + "password = '"+ password +"' WHERE user_id = " + user_id, conn);
                comm.ExecuteNonQuery();
                success = true;

                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("[ERROR] - [CONNECTIONS_USER] add_user() : " + e.Message);
                success = false;
            }

            return success;
        }

        public bool user_has_duplicate(string new_name, string prev_name)
        {
            bool has_duplicate = false;
            if (new_name == prev_name || new_name == "")
            {
                has_duplicate = false;
            }
            else
            {
                try
                {
                    conn.Open();

                    MySqlCommand comm = new MySqlCommand("SELECT COUNT(*) FROM user WHERE username = '" + new_name + "'", conn);
                    MySqlDataAdapter get = new MySqlDataAdapter(comm);
                    DataTable set = new DataTable();
                    get.Fill(set);
                    int count = int.Parse(set.Rows[0]["COUNT(*)"].ToString());
                    if (count == 0)
                        has_duplicate = false;
                    else
                        has_duplicate = true;

                    conn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    conn.Close();
                }
            }
            return has_duplicate;
        }
    }
}
