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
    class connections_disability
    {
        public MySqlConnection conn;
        MySqlCommand comm;
        MySqlDataAdapter get;
        DataTable set;
        public main_form reference_to_main { get; set; }
        public connections_disability()
        {
            conn = new MySqlConnection("Server=localhost;Database=p_dao;Uid=root;Pwd=root;Allow User Variables=True");
        }

        public bool get_disability_data(DataGridView disability_grid)
        {
            bool has_data = false;
            try
            {
                conn.Open();
                Console.WriteLine("[DBY] - [CONNECTIONS_DISABILITY] > { [GET_DISABILITY_LIST] }");
                comm = new MySqlCommand("SELECT disability.disability_id, "
                                             + "disability_type, "
                                             + "disability_desc, "
                                             + "(SELECT COUNT(*) FROM pwd WHERE pwd.disability_id = disability.disability_id) AS result "
                                             + "FROM disability WHERE disability.isArchived != 1", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                DataTable disability_data = new DataTable();
                DataColumn column;
                DataRow row;
                DataView view;

                #region Columns
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "disability_id";
                disability_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "disability_type";
                disability_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "disability_desc";
                disability_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "result";
                disability_data.Columns.Add(column);
                #endregion

                int count = set.Rows.Count;
                if (count == 0)
                {
                    string none = "None";
                    row = disability_data.NewRow();
                    row["disability_id"] = none;
                    row["disability_type"] = "There are no disabilities listed.";
                    row["disability_desc"] = none;
                    row["result"] = " ";
                    disability_data.Rows.Add(row);
                    has_data = false;
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        row = disability_data.NewRow();
                        row["disability_id"] = set.Rows[i]["disability_id"].ToString();
                        row["disability_type"] = set.Rows[i]["disability_type"].ToString();
                        row["disability_desc"] = set.Rows[i]["disability_desc"].ToString();
                        row["result"] = set.Rows[i]["result"].ToString();
                        disability_data.Rows.Add(row);
                    }
                    has_data = true;
                }

                view = new DataView(disability_data);

                disability_grid.DataSource = view;

                conn.Close();
                Console.WriteLine("[DBY] - [CONNECTIONS_DISABILITY] > { [GET_DISABILITY_LIST_SUCCESS] }");
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("[DBY] - [CONNECTIONS_DISABILITY] > { [GET_DISABILITY_LIST_ERROR] } :" + e.Message);
                has_data = false;
            }
            return has_data;
        }

        public bool disability_add(string disability_type, string disability_desc)
        {
            bool success = false;
            try
            {
                conn.Open();
                Console.WriteLine("[DBY] - [CONNECTIONS_DISABILITY] > { [DISABILITY_ADD] }");

                comm = new MySqlCommand("INSERT INTO p_dao.disability(disability_type, disability_desc) VALUES ('" + disability_type + "','" + disability_desc + "')", conn);
                comm.ExecuteNonQuery();
                success = true;

                conn.Close();
                Console.WriteLine("[DBY] - [CONNECTIONS_DISABILITY] > { [DISABILITY_ADD_SUCCESS] }");
            } catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("[DBY] - [CONNECTIONS_DISABILITY] > { [DISABILITY_ADD_ERROR] } : " + e.Message);
                success = false;
            }

            return success;
        }

        public bool disability_update(string disability_id, string disability_type, string disability_desc)
        {
            bool success = false;

            try
            {
                conn.Open();
                Console.WriteLine("[DBY] - [CONNECTIONS_DISABILITY] > { [DISABILITY_UPDATE] }");

                comm = new MySqlCommand("UPDATE disability SET disability_type = '"+ disability_type +"', disability_desc = '"+ disability_desc +"' WHERE disability_id = " + disability_id, conn);
                comm.ExecuteNonQuery();
                success = true;

                conn.Close();
                Console.WriteLine("[DBY] - [CONNECTIONS_DISABILITY] > { [DISABILITY_UPDATE_SUCCESS] }");
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("[DBY] - [CONNECTIONS_DISABILITY] > { [DISABILITY_UPDATE_ERROR] } : " + e.Message);
                success = false;
            }

            return success;
        }

        public bool disability_check_duplicate(string new_name, string prev_name)
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

                    Console.WriteLine("[DBY] - [CONNECTIONS_DISABILITY] > { [DISABILITY_DUPLICATE] }");
                    MySqlCommand comm = new MySqlCommand("SELECT COUNT(*) FROM disability WHERE isArchived != 1 AND disability_type = '" + new_name + "'", conn);
                    MySqlDataAdapter get = new MySqlDataAdapter(comm);
                    DataTable set = new DataTable();
                    get.Fill(set);
                    int count = int.Parse(set.Rows[0]["COUNT(*)"].ToString());
                    if (count == 0)
                        has_duplicate = false;
                    else
                        has_duplicate = true;

                    conn.Close();
                    Console.WriteLine("[DBY] - [CONNECTIONS_DISABILITY] > { [DISABILITY_DUPLICATE_SUCCESS_CHECK] }");
                }
                catch (Exception e)
                {
                    Console.WriteLine("[DBY] - [CONNECTIONS_DISABILITY] > { [DISABILITY_DUPLICATE_ERROR] } : " + e.Message);
                    conn.Close();
                }
            }
            return has_duplicate;
        }

        public bool disability_archive(string disability_id)
        {
            bool success = false;
            try
            {
                conn.Open();

                Console.WriteLine("[DBY] - [CONNECTIONS_DISABILITY] > Archive disability");
                comm = new MySqlCommand("UPDATE p_dao.disability SET isArchived = 1 WHERE disability_id = " + disability_id, conn);
                comm.ExecuteNonQuery();

                conn.Close();
                Console.WriteLine("[CONNECTIONS_DISABILITY] > Archived disability : " + disability_id);
                success = true;
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("[CONNECTIONS_DISABILITY] > Archived disability error : " + e.Message);
                success = false;
            }
            return success;
        }
        public string count_rows_disability()
        {
            string result;
            try
            {
                conn.Open();

                Console.WriteLine("[DBY] - [CONNECTIONS_DISABILITY] > { [DISABILITY_COUNT_ROWS] }");
                comm = new MySqlCommand("SELECT COUNT(*) AS result FROM disability WHERE isArchived != 1", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                result = "Total results: " + set.Rows[0]["result"].ToString();

                conn.Close();
                Console.WriteLine("[DBY] - [CONNECTIONS_DISABILITY] > { [DISABILITY_COUNT_ROWS_SUCCESS] }");
            }
            catch (Exception e)
            {
                result = "Total results: 0";
                conn.Close();
                Console.WriteLine("[DBY] - [CONNECTIONS_DISABILITY] > { [DISABILITY_COUNT_ROWS_ERROR] } :" + e.Message);
            }
            return result;
        }

        public string get_disability_by_name(string disability_name)
        {
            string ret_disability_id;
            try
            {
                Console.WriteLine("[DBY] - [CONNECTIONS_DISABILITY] > { [GET_DISABILITY_BY_NAME] } : " + disability_name);
                conn.Open();
                comm = new MySqlCommand("SELECT disability_id FROM disability WHERE disability_type = '" + disability_name + "'", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                ret_disability_id = set.Rows[0]["disability_id"].ToString();

                Console.WriteLine("[DBY] - [CONNECTIONS_DISABILITY] > { [GET_DISABILITY_BY_SUCCESS] } " + ret_disability_id);
                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
                ret_disability_id = "0";
                Console.WriteLine("[DBY] - [CONNECTIONS_DISABILITY] > { [GET_DISABILITY_BY_ERROR] } : " + e.Message);
            }
            return ret_disability_id;
        }
    }
}
