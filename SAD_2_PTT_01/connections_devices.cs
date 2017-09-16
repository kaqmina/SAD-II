﻿using System;
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

        #region PENDING-REQUESTS
        public void get_pending_requests(DataGridView pending_requests)
        {
            Console.WriteLine("[DVC] - [CONNECTIONS_DEVICES] > { [DEVICE_PENDING_REQUESTS_LOAD] }");
            try
            {
                conn.Open();
                comm = new MySqlCommand("SELECT (@s:=@s+1) no, "
                                             + "deviceLOG_id, "
                                             + "registration_no, "
                                             + "dp_name, "
                                             + "device_log.pwd_id, "
                                             + "req_date "
                                             + "FROM device_log JOIN device_provider ON device_log.dp_id = device_provider.dp_id "
                                             + "JOIN pwd ON device_log.pwd_id = pwd.pwd_id, "
                                             + "(SELECT @s:=0) AS s "
                                             + "WHERE device_log.status = 1 AND device_log.isArchived != 1 ORDER BY req_date DESC", conn);
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
                comm = new MySqlCommand("SELECT (@s:=@s+1) no, "
                                             + "deviceLOG_id, "
                                             + "registration_no, "
                                             + "dp_name, "
                                             + "device_log.pwd_id, "
                                             + "date_in "
                                             + "FROM device_log JOIN device_provider ON device_log.dp_id = device_provider.dp_id "
                                             + "JOIN pwd ON device_log.pwd_id = pwd.pwd_id, "
                                             + "(SELECT @s:=0) AS s "
                                             + "WHERE device_log.status = 2 AND device_log.isArchived != 1 ORDER BY date_in DESC", conn);
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

                comm = new MySqlCommand("SELECT CONCAT(pwd.lastname, ', ', pwd.firstname,' ', pwd.middlename) AS fullname, "
                                             + "pwd.registration_no, "
                                             + "employee.username, "
                                             + "device_log.req_date, "
                                             + "device.dev_name, "
                                             + "device_provider.dp_name "
                                             + "FROM device_log JOIN pwd ON pwd.pwd_id = device_log.pwd_id "
                                             + "JOIN device ON device_log.device_id = device.device_id "
                                             + "JOIN device_provider ON device_provider.dp_id = device_log.dp_id "
                                             + "JOIN employee ON device_log.req_emp_id = employee.employee_id "
                                             + "WHERE device_log.isArchived != 1 AND deviceLOG_id = " + dev_id, conn);
                get = new MySqlDataAdapter(comm);
                get.Fill(data);

                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
            }
        }

        public void get_pending_received_data(string pwd_id, string dev_id, DataTable data)
        {
            try
            {
                conn.Open();

                comm = new MySqlCommand("SELECT CONCAT(pwd.lastname, ', ', pwd.firstname, ' ', pwd.middlename) AS fullname, "
                                             + "pwd.registration_no, "
                                             + "employee.username, "
                                             + "device_log.req_date, "
                                             + "device.dev_name, "
                                             + "device_provider.dp_name, "
                                             + "device_log.date_in, "
                                             + "device_log.in_emp_id, "
                                             + "(SELECT username FROM employee JOIN device_log ON employee.employee_id = device_log.in_emp_id WHERE device_log.deviceLOG_id = " + dev_id + ") AS username_in "
                                             + "FROM device_log JOIN pwd ON pwd.pwd_id = device_log.pwd_id "
                                             + "JOIN device ON device_log.device_id = device.device_id "
                                             + "JOIN device_provider ON device_provider.dp_id = device_log.dp_id "
                                             + "JOIN employee ON device_log.req_emp_id = employee.employee_id "
                                             + "WHERE device_log.isArchived != 1 AND deviceLOG_id =" + dev_id, conn);
                get = new MySqlDataAdapter(comm);
                get.Fill(data);

                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        public void get_device_list(DataGridView device_grid)
        {
            try
            {
                conn.Open();

                comm = new MySqlCommand("SELECT * FROM device JOIN disability ON device.disability_id = disability.disability_id WHERE device.isArchived != 1 ORDER BY disability_type ASC ", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                device_grid.DataSource = set;

                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
            }
        }

        public string count_rows()
        {
            string result;
            try
            {
                conn.Open();

                comm = new MySqlCommand("SELECT COUNT(*) AS result FROM device JOIN disability ON device.disability_id = disability.disability_id WHERE device.isArchived != 1", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                result = "Total results: " + set.Rows[0]["result"].ToString();

                conn.Close();
            }
            catch (Exception e)
            {
                result = "Total results: 0";
                conn.Close();
                Console.WriteLine(e.Message);
            }
            return result;
        }

        public void get_disability_list(ComboBox disability_cbox)
        {
            try
            {
                conn.Open();

                comm = new MySqlCommand("SELECT disability_type FROM disability WHERE isArchived != 1", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                int count = set.Rows.Count;
                if (count == 0)
                {
                    disability_cbox.Items.Add("No disabilities added.");
                }
                else
                {
                    foreach (DataRow data in set.Rows)
                    {
                        disability_cbox.Items.Add(data["disability_type"].ToString());
                    }
                }

                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
            }
        }

        public void device_add(string dev_name, string dev_desc, int disability_id)
        {
            try
            {
                conn.Open();

                comm = new MySqlCommand("INSERT INTO p_dao.device(dev_name, "
                                                               + "dev_desc, "
                                                               + "disability_id) "
                                                               + "VALUES ('"
                                                               + dev_name 
                                                               +"','"
                                                               + dev_desc 
                                                               +"', "
                                                               + disability_id 
                                                               +") ", conn);
                comm.ExecuteNonQuery();

                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
            }
        }

        public void device_update(string dev_name, string dev_desc, int disability_id, string device_id)
        {
            try
            {
                conn.Open();

                comm = new MySqlCommand("UPDATE device SET dev_name = '" 
                                                         + dev_name + "', dev_desc = '"
                                                         + dev_desc +"', disability_id =" 
                                                         + disability_id 
                                                         + " WHERE device_id = " + device_id, conn);
                comm.ExecuteNonQuery();

                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
            }
        }

        public bool device_check_duplicate(string new_name, string prev_name)
        {
            bool has_duplicate = false;
            if (new_name == prev_name || new_name == "")
            {
                has_duplicate = false;
            } else
            {
                try
                {
                    conn.Open();
                    
                    MySqlCommand comm = new MySqlCommand("SELECT COUNT(*) FROM device WHERE dev_name = " + new_name, conn);
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
