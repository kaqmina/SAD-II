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
        public main_form reference_to_main { get; set; }
        public connections_devices()
        {
            conn = new MySqlConnection("Server=localhost;Database=p_dao;Uid=root;Pwd=root;Allow User Variables=True");
        }

        public void get_pending_requests(DataGridView pending_requests)
        {
            Console.WriteLine("[DVC] - [CONNECTIONS_DEVICES] > { [DEVICE_PENDING_REQUESTS_LOAD] }");
            try
            {
                conn.Open();
                comm = new MySqlCommand("SELECT (@s:=@s+1) no, deviceLOG_id, registration_no, dp_name, device_log.pwd_id, req_date FROM device_log JOIN device_provider ON device_log.dp_id = device_provider.dp_id JOIN pwd ON device_log.pwd_id = pwd.pwd_id, (SELECT @s:=0) AS s WHERE device_log.status = 1 ORDER BY req_date DESC", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                DataTable pending_data = new DataTable();
                DataColumn column;
                DataRow row;
                DataView view;

                #region pending_data columns
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "no";
                pending_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "deviceLOG_id";
                pending_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "registration_no";
                pending_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "dp_name";
                pending_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "pwd_id";
                pending_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "req_date";
                pending_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "request_text";
                pending_data.Columns.Add(column);
            #endregion
                
                int count = set.Rows.Count;
                if (count == 0)
                {
                    string none = "None";
                    row = pending_data.NewRow();
                    row["no"] = none;
                    row["deviceLOG_id"] = none;
                    row["registration_no"] = none;
                    row["dp_name"] = none;
                    row["pwd_id"] = none;
                    row["req_date"] = none;
                    string text = "There are no pending requests.";
                    row["request_text"] = text;
                    pending_data.Rows.Add(row);
                    reference_to_main.device_has_data_requests = false;
                } else
                {
                    for (int i = 0; i < count; i++)
                    {
                        row = pending_data.NewRow();
                        row["no"] = set.Rows[i]["no"].ToString();
                        row["deviceLOG_id"] = set.Rows[i]["deviceLOG_id"].ToString();
                        row["registration_no"] = set.Rows[i]["registration_no"].ToString();
                        row["dp_name"] = set.Rows[i]["dp_name"].ToString();
                        row["pwd_id"] = set.Rows[i]["pwd_id"].ToString();
                        string[] req = set.Rows[i]["req_date"].ToString().Split();
                        row["req_date"] = req[0];
                        string text = "# " + set.Rows[i]["no"].ToString() + " " + "RID: " + set.Rows[i]["registration_no"].ToString() + ", " + req[0] + Environment.NewLine + set.Rows[i]["dp_name"].ToString();
                        row["request_text"] = text;
                        pending_data.Rows.Add(row);
                    }
                    reference_to_main.device_has_data_requests = true;
                }

                view = new DataView(pending_data);

                pending_requests.DataSource = view;

                conn.Close();
                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICES] > { [DEVICE_PENDING_REQUESTS_LOADED] }");
            } catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
            }
        }

        public void get_pending_recieved(DataGridView pending_requests)
        {
            Console.WriteLine("[DVC] - [CONNECTIONS_DEVICES] > { [DEVICE_PENDING_REQUESTS_LOAD] }");
            try
            {
                conn.Open();
                comm = new MySqlCommand("SELECT (@s:=@s+1) no, deviceLOG_id, registration_no, dp_name, device_log.pwd_id, date_in FROM device_log JOIN device_provider ON device_log.dp_id = device_provider.dp_id JOIN pwd ON device_log.pwd_id = pwd.pwd_id, (SELECT @s:=0) AS s WHERE device_log.status = 2 ORDER BY date_in DESC", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                DataTable pending_data = new DataTable();
                DataColumn column;
                DataRow row;
                DataView view;

                #region pending_data columns
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "no";
                pending_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "deviceLOG_id";
                pending_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "registration_no";
                pending_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "dp_name";
                pending_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "pwd_id";
                pending_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "date_in";
                pending_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "recieved_text";
                pending_data.Columns.Add(column);
                #endregion

                int count = set.Rows.Count;
                if (count == 0)
                {
                    string none = "None";
                    row = pending_data.NewRow();
                    row["no"] = none;
                    row["deviceLOG_id"] = none;
                    row["registration_no"] = none;
                    row["dp_name"] = none;
                    row["pwd_id"] = none;
                    row["date_in"] = none;
                    string text = "There are no pending recieved devices.";
                    row["recieved_text"] = text;
                    pending_data.Rows.Add(row);
                    reference_to_main.device_has_data_recieved = false;
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        row = pending_data.NewRow();
                        row["no"] = set.Rows[i]["no"].ToString();
                        row["deviceLOG_id"] = set.Rows[i]["deviceLOG_id"].ToString();
                        row["registration_no"] = set.Rows[i]["registration_no"].ToString();
                        row["pwd_id"] = set.Rows[i]["pwd_id"].ToString();
                        row["dp_name"] = set.Rows[i]["dp_name"].ToString();
                        string[] req = set.Rows[i]["date_in"].ToString().Split();
                        row["date_in"] = req[0];
                        string text = "# " + set.Rows[i]["no"].ToString() + " " + "RID: " + set.Rows[i]["registration_no"].ToString() + ", " + req[0] + Environment.NewLine + set.Rows[i]["dp_name"].ToString();
                        row["recieved_text"] = text;
                        pending_data.Rows.Add(row);
                    }
                    reference_to_main.device_has_data_recieved = true;
                }

                view = new DataView(pending_data);

                pending_requests.DataSource = view;

                conn.Close();
                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICES] > { [DEVICE_PENDING_REQUESTS_LOADED] }");
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
            }
        }

        public void get_pending_requests_data(string pwd_id, string dev_id, DataTable data)
        {
            try
            {
                conn.Open();

                comm = new MySqlCommand("SELECT CONCAT(pwd.lastname, ', ', pwd.firstname,' ', pwd.middlename) AS fullname, pwd.registration_no, employee.username, device_log.req_date, device.dev_name, device_provider.dp_name FROM device_log JOIN pwd ON pwd.pwd_id = device_log.pwd_id JOIN device ON device_log.device_id = device.device_id JOIN device_provider ON device_provider.dp_id = device_log.dp_id JOIN employee ON device_log.req_emp_id = employee.employee_id WHERE deviceLOG_id = " + dev_id, conn);
                get = new MySqlDataAdapter(comm);
                get.Fill(data);

                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
            }
        }
    }
}
