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

        #region PENDING-REQUESTS
        public void get_pending_requests(DataGridView pending_requests)
        {
            Console.WriteLine("[DVC] - [CONNECTIONS_DEVICES] > { [DEVICE_PENDING_REQUESTS_LOAD] }");
            try
            {
                conn.Open();
                comm = new MySqlCommand("SELECT @row_number:=@row_number+1 AS no, "
                                             + "fullname, "
                                             + "deviceLOG_id, "
                                             + "registration_no, "
                                             + "dp_name, "
                                             + "reference_no, "
                                             + "pwd_id, "
                                             + "req_date "
                                             + "FROM (SELECT (CONCAT(lastname, ',', firstname,' ' ,SUBSTRING(middlename, 1, 1), '.')) AS fullname, "
                                                          + "deviceLOG_id, "
                                                          + "registration_no, "
                                                          + "dp_name, "
                                                          + "reference_no, "
                                                          + "device_log.pwd_id, "
                                                          + "req_date "
                                                          + "FROM device_log "
                                                          + "JOIN device_provider ON device_log.dp_id = device_provider.dp_id "
                                                          + "JOIN pwd ON device_log.pwd_id = pwd.pwd_id WHERE device_log.status = 1 AND device_log.isArchived != 1 "
                                                          + "ORDER BY dp_name ASC) t1, (SELECT @row_number:=0) t2;", conn);
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
                column.ColumnName = "fullname";
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
                column.ColumnName = "reference_no";
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
                    row["fullname"] = none;
                    row["deviceLOG_id"] = none;
                    row["registration_no"] = none;
                    row["dp_name"] = none;
                    row["pwd_id"] = none;
                    row["req_date"] = none;
                    row["reference_no"] = none;
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
                        row["fullname"] = set.Rows[i]["fullname"].ToString();
                        row["deviceLOG_id"] = set.Rows[i]["deviceLOG_id"].ToString();
                        row["registration_no"] = set.Rows[i]["registration_no"].ToString();
                        row["dp_name"] = set.Rows[i]["dp_name"].ToString();
                        row["reference_no"] = set.Rows[i]["reference_no"].ToString();
                        row["pwd_id"] = set.Rows[i]["pwd_id"].ToString();
                        string[] req = set.Rows[i]["req_date"].ToString().Split();
                        row["req_date"] = req[0];
                        string text = "# " + set.Rows[i]["no"].ToString() + " " + "RID: " + set.Rows[i]["registration_no"].ToString() + ", " + req[0] + Environment.NewLine + set.Rows[i]["fullname"].ToString() + Environment.NewLine +  set.Rows[i]["dp_name"].ToString();
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
                Console.WriteLine("[DVC] - [CONNECTION_DEVICES] > { [DEVICES_PENDING_REQUESTS_ERROR] } " + e.Message);
            }
        }

        public void get_pending_recieved(DataGridView pending_requests)
        {
            Console.WriteLine("[DVC] - [CONNECTIONS_DEVICES] > { [DEVICE_PENDING_RECEIVED_LOAD] }");
            try
            {
                conn.Open();
                comm = new MySqlCommand("SELECT @row_number:=@row_number+1 AS no, "
                                             + "fullname, "
                                             + "deviceLOG_id, "
                                             + "registration_no, "
                                             + "dp_name, "
                                             + "reference_no, "
                                             + "pwd_id, "
                                             + "date_in "
                                             + "FROM (SELECT CONCAT(lastname, ',' , firstname, ' ', SUBSTRING(middlename, 1, 1), '.') AS fullname, "
                                                          + "deviceLOG_id, "
                                                          + "registration_no, "
                                                          + "dp_name, "
                                                          + "reference_no, "
                                                          + "device_log.pwd_id, "
                                                          + "date_in "
                                                          + "FROM device_log JOIN device_provider ON device_log.dp_id = device_provider.dp_id "
                                                          + "JOIN pwd ON device_log.pwd_id = pwd.pwd_id WHERE device_log.status = 2 AND device_log.isArchived != 1 "
                                                          + "ORDER BY dp_name ASC) t1, (SELECT @row_number:=0) t2;", conn);
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
                column.ColumnName = "fullname";
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
                column.ColumnName = "reference_no";
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
                    row["fullname"] = none;
                    row["deviceLOG_id"] = none;
                    row["registration_no"] = none;
                    row["dp_name"] = none;
                    row["pwd_id"] = none;
                    row["date_in"] = none;
                    row["reference_no"] = none;
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
                        row["fullname"] = set.Rows[i]["fullname"].ToString();
                        row["deviceLOG_id"] = set.Rows[i]["deviceLOG_id"].ToString();
                        row["registration_no"] = set.Rows[i]["registration_no"].ToString();
                        row["pwd_id"] = set.Rows[i]["pwd_id"].ToString();
                        row["dp_name"] = set.Rows[i]["dp_name"].ToString();
                        row["reference_no"] = set.Rows[i]["reference_no"].ToString();
                        string[] req = set.Rows[i]["date_in"].ToString().Split();
                        row["date_in"] = req[0];
                        string text = "# " + set.Rows[i]["no"].ToString() + " " + "RID: " + set.Rows[i]["registration_no"].ToString() + ", " + req[0] + Environment.NewLine + set.Rows[i]["fullname"].ToString() + Environment.NewLine + set.Rows[i]["dp_name"].ToString();
                        row["recieved_text"] = text;
                        pending_data.Rows.Add(row);
                    }
                    reference_to_main.device_has_data_recieved = true;
                }

                view = new DataView(pending_data);

                pending_requests.DataSource = view;

                conn.Close();
                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICES] > { [DEVICE_PENDING_RECEIVED_LOADED] }");
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("[DVC] - [CONNECTION_DEVICES] > { [DEVICE_PENDING_RECEIVED_ERROR] }" + e.Message);
            }
        }

        public void get_pending_requests_data(string pwd_id, string dev_id, DataTable data)
        {
            try
            {
                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICES] > { [LOAD_PENDING_RECEIVED] }");
                conn.Open();

                comm = new MySqlCommand("SELECT CONCAT(pwd.lastname, ', ', pwd.firstname,' ', pwd.middlename) AS fullname, "
                                             + "pwd.registration_no, "
                                             + "user.username, "
                                             + "DATE(device_log.req_date) AS req_date, "
                                             + "device.dev_name, "
                                             + "device_provider.dp_name, "
                                             + "req_desc, "
                                             + "reference_no, "
                                             + "pwd.id_no, "
                                             + "pwd.mobile_no, "
                                             + "pwd.tel_no, "
                                             + "disability.disability_type "
                                             + "FROM device_log JOIN pwd ON pwd.pwd_id = device_log.pwd_id "
                                             + "JOIN device ON device_log.device_id = device.device_id "
                                             + "JOIN device_provider ON device_provider.dp_id = device_log.dp_id "
                                             + "JOIN user ON device_log.req_emp_id = user.user_id "
                                             + "JOIN disability ON disability.disability_id = pwd.disability_id "
                                             + "WHERE device_log.isArchived != 1 AND deviceLOG_id = " + dev_id, conn);
                get = new MySqlDataAdapter(comm);
                get.Fill(data);

                conn.Close();
                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICES] > { [LOAD_PENDING_RECEIVED_SUCCESS] }");
            } catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICES] > { [LOAD_PENDING_RECEIVED_ERROR] }" + e.Message);
            }
        }

        public void get_pending_received_data(string pwd_id, string dev_id, DataTable data)
        {
            try
            {
                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICES] > { [LOAD_PENDING_REQUESTS] }");
                conn.Open();

                comm = new MySqlCommand("SELECT CONCAT(pwd.lastname, ', ', pwd.firstname, ' ', pwd.middlename) AS fullname, "
                                             + "pwd.registration_no, "
                                             + "user.username, "
                                             + "DATE(device_log.req_date) AS req_date, "
                                             + "device.dev_name, "
                                             + "device_provider.dp_name, "
                                             + "DATE(device_log.date_in) AS date_in, "
                                             + "device_log.in_emp_id, "
                                             + "req_desc, "
                                             + "reference_no, "
                                             + "pwd.id_no, "
                                             + "pwd.mobile_no, "
                                             + "pwd.tel_no, "
                                             + "disability.disability_type, "
                                             + "(SELECT username FROM user JOIN device_log ON user.user_id = device_log.in_emp_id WHERE device_log.deviceLOG_id = " + dev_id + ") AS username_in "
                                             + "FROM device_log JOIN pwd ON pwd.pwd_id = device_log.pwd_id "
                                             + "JOIN device ON device_log.device_id = device.device_id "
                                             + "JOIN device_provider ON device_provider.dp_id = device_log.dp_id "
                                             + "JOIN user ON device_log.req_emp_id = user.user_id "
                                             + "JOIN disability ON pwd.disability_id = disability.disability_id "
                                             + "WHERE device_log.isArchived != 1 AND deviceLOG_id =" + dev_id, conn);
                get = new MySqlDataAdapter(comm);
                get.Fill(data);

                conn.Close();
                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICES] > { [LOAD_PENDING_REQUESTS_SUCCESS] }");
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICES] > { [LOAD_PENDING_REQUESTS_ERROR] }" + e.Message);
            }
        }
        #endregion

        #region C-BOX - DUPLICATE

        public void get_disability_list(ComboBox disability_cbox)
        {
            disability_cbox.Items.Clear();
            disability_cbox.Items.Add("");
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
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
            }
        }

        public bool get_provider_list(ComboBox sponsor_cbox)
        {
            sponsor_cbox.Items.Clear();
            sponsor_cbox.Items.Add("");
            bool has_data = false;
            try
            {
                conn.Open();
                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICE] > { [ GET_PROVIDER_LIST ] }");
                comm = new MySqlCommand("SELECT * FROM device_provider WHERE isArchived != 1", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                int count = set.Rows.Count;
                if (count == 0)
                {
                    sponsor_cbox.Items.Add("No providers added.");
                    has_data = false;
                }
                else
                {
                    foreach (DataRow data in set.Rows)
                    {
                        sponsor_cbox.Items.Add(data["dp_name"].ToString());
                    }
                    has_data = true;
                }

                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICE] > { [ GET_PROVIDER_LIST_SUCCESS ] }");
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICE] > { [ GET_PROVIDER_LIST_ERROR ] } : " + e.Message);
                conn.Close();
                has_data = false;
            }
            return has_data;
        }

        public bool get_device_list(ComboBox device_cbox)
        {
            device_cbox.Items.Clear();
            device_cbox.Items.Add("");
            bool has_data = false;
            try
            {
                conn.Open();
                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICE] > { [ GET_DEVICE_LIST ] }");
                comm = new MySqlCommand("SELECT * FROM device WHERE isArchived != 1", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                int count = set.Rows.Count;
                if (count == 0)
                {
                    device_cbox.Items.Add("No devices added.");
                    has_data = false;
                }
                else
                {
                    foreach (DataRow data in set.Rows)
                    {
                        device_cbox.Items.Add(data["dev_name"].ToString());
                    }
                    has_data = true;
                }

                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICE] > { [ GET_DEVICE_LIST_SUCCESS ] }");
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICE] > { [ GET_DEVICE_LIST_ERROR ] } : " + e.Message);
                conn.Close();
                has_data = false;
            }
            return has_data;
        }

        public bool get_device_list(ComboBox device_cbox, string for_disability)
        {
            device_cbox.Items.Clear();
            device_cbox.Items.Add("");
            bool has_data = false;
            try
            {
                conn.Open();
                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICE] > { [ GET_DEVICE_LIST ] }");
                comm = new MySqlCommand("SELECT * FROM device WHERE isArchived != 1 AND disability_id = " + for_disability, conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                int count = set.Rows.Count;
                if (count == 0)
                {
                    device_cbox.Items.Add("No devices added.");
                    has_data = false;
                }
                else
                {
                    foreach (DataRow data in set.Rows)
                    {
                        device_cbox.Items.Add(data["dev_name"].ToString());
                    }
                    has_data = true;
                }

                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICE] > { [ GET_DEVICE_LIST_SUCCESS ] }");
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICE] > { [ GET_DEVICE_LIST_ERROR ] } : " + e.Message);
                conn.Close();
                has_data = false;
            }
            return has_data;
        }

        public bool device_check_duplicate(string new_name, string prev_name)
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

                    MySqlCommand comm = new MySqlCommand("SELECT COUNT(*) FROM device WHERE isArchived != 1 AND dev_name = '" + new_name + "'", conn);
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

        public bool provider_check_duplicate(string new_name, string prev_name)
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

                    MySqlCommand comm = new MySqlCommand("SELECT COUNT(*) FROM device_provider WHERE isArchived != 1 AND dp_name = '" + new_name + "'", conn);
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

        #endregion

        #region [MODE - DEVICE]

        #region [DEVICE] ADD-MODE

        public void device_add(string dev_name, string dev_desc, string disability_id)
        {
            try
            {
                conn.Open();

                comm = new MySqlCommand("INSERT INTO p_dao.device(dev_name, "
                                                               + "dev_desc, "
                                                               + "disability_id) "
                                                               + "VALUES ('"
                                                               + dev_name
                                                               + "','"
                                                               + dev_desc
                                                               + "', "
                                                               + disability_id
                                                               + ") ", conn);
                comm.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
            }
        }

        #endregion

        #region [DEVICE] VIEW-MODE

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

        public bool get_device_list(DataGridView device_grid)
        {
            bool has_data = false;
            try
            {
                conn.Open();

                comm = new MySqlCommand("SELECT * FROM device JOIN disability ON device.disability_id = disability.disability_id WHERE device.isArchived != 1 ORDER BY disability_type ASC ", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                DataTable device_data = new DataTable();
                DataColumn column;
                DataRow row;
                DataView view;

                #region Columns
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "device_id";
                device_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "disability_id";
                device_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "dev_desc";
                device_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "disability_desc";
                device_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "disability_id1";
                device_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "isArchived";
                device_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "isArchived1";
                device_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "dev_name";
                device_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "disability_type";
                device_data.Columns.Add(column);
                #endregion

                int count = set.Rows.Count;
                if (count == 0)
                {
                    string none = "None";
                    row = device_data.NewRow();
                    row["device_id"] = none;
                    row["disability_id"] = none;
                    row["dev_desc"] = none;
                    row["disability_desc"] = none;
                    row["disability_id1"] = none;
                    row["isArchived"] = none;
                    row["isArchived1"] = none;
                    row["dev_name"] = "There are no devices.";
                    row["disability_type"] = "";
                    device_data.Rows.Add(row);
                    has_data = false;
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        row = device_data.NewRow();
                        row["device_id"] = set.Rows[i]["device_id"].ToString();
                        row["disability_id"] = set.Rows[i]["disability_id"].ToString();
                        row["dev_desc"] = set.Rows[i]["dev_desc"].ToString();
                        row["disability_desc"] = set.Rows[i]["disability_desc"].ToString();
                        row["disability_id1"] = set.Rows[i]["disability_id1"].ToString();
                        row["isArchived"] = set.Rows[i]["isArchived"].ToString();
                        row["isArchived1"] = set.Rows[i]["isArchived1"].ToString();
                        row["dev_name"] = set.Rows[i]["dev_name"].ToString();
                        row["disability_type"] = set.Rows[i]["disability_type"].ToString();
                        device_data.Rows.Add(row);
                    }
                    has_data = true;
                }

                view = new DataView(device_data);

                device_grid.DataSource = view;

                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
            }
            return has_data;
        }

        #endregion

        #region [DEVICE] EDIT-MODE

        public void device_update(string dev_name, string dev_desc, string disability_id, string device_id)
        {
            try
            {
                conn.Open();

                comm = new MySqlCommand("UPDATE device SET dev_name = '"
                                                         + dev_name + "', dev_desc = '"
                                                         + dev_desc + "', disability_id = "
                                                         + disability_id
                                                         + " WHERE device_id = " + device_id, conn);
                comm.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
            }
        }

        #endregion

        #region [DEVICE] ARCHIVE-MODE

        public void device_archive(string device_id)
        {
            try
            {
                conn.Open();

                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICE] > Archive device");
                comm = new MySqlCommand("UPDATE p_dao.device SET isArchived = 1 WHERE device_id = " + device_id, conn);
                comm.ExecuteNonQuery();

                conn.Close();
                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICE] > Archived device : " + device_id);
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICE] > Archived device error : " + e.Message);
            }
        }

        #endregion

        #endregion

        #region [MODE - PROVIDER]

        #region [PROVIDER] ADD-MODE

        public bool provider_add(string dp_name, string dp_address, int dp_type, string mobile_no, string tel_no, string email_add)
        {
            bool success = false;
            try
            {
                conn.Open();

                comm = new MySqlCommand("INSERT INTO p_dao.device_provider(dp_name, "
                                                                        + "dp_address, "
                                                                        + "dp_type, "
                                                                        + "mobile_no, "
                                                                        + "tel_no, "
                                                                        + "email_add) VALUES ('"
                                                                        + dp_name + "', '"
                                                                        + dp_address + "', "
                                                                        + dp_type + ", '"
                                                                        + mobile_no + "', '"
                                                                        + tel_no + "', '"
                                                                        + email_add + "')", conn);
                comm.ExecuteNonQuery();

                conn.Close();
                success = true;
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                success = false;
            }
            return success;
        }

        #endregion

        #region [PROVIDER] EDIT-MODE

        public bool provider_update(string dp_name, string dp_address, int dp_type, string mobile_no, string tel_no, string email_add, string dp_id)
        {
            bool success = false;
            try
            {
                conn.Open();

                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICES] > { PROVIDER_UPDATE }");
                comm = new MySqlCommand("UPDATE p_dao.device_provider SET dp_name = '" + dp_name
                                                      + "', dp_address = '" + dp_address
                                                      + "', dp_type = " + dp_type
                                                      + ", mobile_no = '" + mobile_no
                                                      + "', tel_no = '" + tel_no
                                                      + "', email_add = '" + email_add
                                                      + "' WHERE dp_id = " + dp_id, conn);
                comm.ExecuteNonQuery();

                conn.Close();
                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICES] > { PROVIDER_UPDATE_SUCCESS }");
                success = true;
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICES] > { PROVIDER_UPDATE_ERROR } : " + e.Message);
                success = false;
            }
            return success;
        }

        #endregion

        #region [PROVIDER] VIEW-MODE

        public string count_rows_provider()
        {
            string result;
            try
            {
                conn.Open();

                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICES] > { [PROVIDER_COUNT_ROWS] }");
                comm = new MySqlCommand("SELECT COUNT(*) AS result FROM device_provider WHERE isArchived != 1", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                result = "Total results: " + set.Rows[0]["result"].ToString();

                conn.Close();
                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICES] > { [PROVIDER_COUNT_ROWS_SUCCESS] }");
            }
            catch (Exception e)
            {
                result = "Total results: 0";
                conn.Close();
                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICES] > { [PROVIDER_COUNT_ROWS_ERROR] } :" + e.Message);
            }
            return result;
        }

        public bool get_provider_list(DataGridView provider_grid)
        {
            bool has_data = false;
            try
            {
                conn.Open();
                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICES] > { [GET_PROVIDER_LIST] }");
                comm = new MySqlCommand("SELECT device_provider.dp_id, "
                                             + "dp_name, "
                                             + "dp_address, "
                                             + "(CASE WHEN dp_type = 0 THEN 'Government' ELSE 'Sponsor' END) AS dp_type_name, "
                                             + "dp_type AS dp_type_id, "
                                             + "mobile_no, "
                                             + "tel_no, "
                                             + "email_add, "
                                             + "COUNT(device_log.dp_id) as result "
                                             + "FROM device_provider LEFT JOIN device_log ON device_provider.dp_id = device_log.dp_id WHERE device_provider.isArchived != 1 GROUP BY dp_id", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                DataTable provider_data = new DataTable();
                DataColumn column;
                DataRow row;
                DataView view;

                #region Columns
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "dp_id";
                provider_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "dp_name";
                provider_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "dp_address";
                provider_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "dp_type_name";
                provider_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "dp_type_id";
                provider_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "mobile_no";
                provider_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "tel_no";
                provider_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "email_add";
                provider_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "result";
                provider_data.Columns.Add(column);
                #endregion

                int count = set.Rows.Count;
                if (count == 0)
                {
                    string none = "None";
                    row = provider_data.NewRow();
                    row["dp_id"] = none;
                    row["dp_name"] = "There are no providers listed.";
                    row["dp_address"] = none;
                    row["dp_type_name"] = none;
                    row["dp_type_id"] = "0";
                    row["mobile_no"] = none;
                    row["tel_no"] = none;
                    row["email_add"] = none;
                    row["result"] = " ";
                    provider_data.Rows.Add(row);
                    has_data = false;
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        row = provider_data.NewRow();
                        row["dp_id"] = set.Rows[i]["dp_id"].ToString();
                        row["dp_name"] = set.Rows[i]["dp_name"].ToString();
                        row["dp_address"] = set.Rows[i]["dp_address"].ToString();
                        row["dp_type_name"] = set.Rows[i]["dp_type_name"].ToString();
                        row["dp_type_id"] = set.Rows[i]["dp_type_id"].ToString();
                        row["mobile_no"] = set.Rows[i]["mobile_no"].ToString();
                        row["tel_no"] = set.Rows[i]["tel_no"].ToString();
                        row["email_add"] = set.Rows[i]["email_add"].ToString();
                        row["result"] = set.Rows[i]["result"].ToString();
                        provider_data.Rows.Add(row);
                    }
                    has_data = true;
                }

                view = new DataView(provider_data);

                provider_grid.DataSource = view;

                conn.Close();
                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICES] > { [GET_PROVIDER_LIST_SUCCESS] }");
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICES] > { [GET_PROVIDER_LIST_ERROR] } :" + e.Message);
            }
            return has_data;
        }

        public bool provider_devices_provided(DataGridView devices_provided_grid, string dp_id)
        {
            bool has_data = false;
            try
            {
                conn.Open();

                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICES] > { [PROVIDER_DEVICE_PROVIDED] }");
                comm = new MySqlCommand("SELECT dev_name, COUNT(*) AS result FROM device_log JOIN device ON device_log.device_id = device.device_id WHERE dp_id = " + dp_id + " GROUP BY dev_name", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                DataTable device_provided_data = new DataTable();
                DataColumn column;
                DataRow row;
                DataView view;

                #region Columns
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "dev_name";
                device_provided_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "result";
                device_provided_data.Columns.Add(column);
                #endregion

                int count = set.Rows.Count;
                if (count == 0 || set.Rows[0]["result"].ToString() == "0")
                {
                    string none = "No devices provided yet.";
                    row = device_provided_data.NewRow();
                    row["dev_name"] = none;
                    row["result"] = " ";
                    device_provided_data.Rows.Add(row);
                    has_data = false;
                    Console.WriteLine("No devices provided.");
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        row = device_provided_data.NewRow();
                        row["dev_name"] = set.Rows[i]["dev_name"].ToString();
                        row["result"] = set.Rows[i]["result"].ToString();
                        device_provided_data.Rows.Add(row);
                    }
                    has_data = true;
                }

                view = new DataView(device_provided_data);

                devices_provided_grid.DataSource = view;

                conn.Close();
                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICES] > { [PROVIDER_DEVICE_PROVIDED_SUCCESS] }");
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICES] > { [PROVIDER_DEVICE_PROVIDED_ERROR] } :" + e.Message);
            }
            return has_data;
        }

        #endregion

        #region [PROVIDER] ARCHIVE-MODE

        public bool provider_archive(string dp_id)
        {
            bool success = false;
            try
            {
                conn.Open();

                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICE] > Archive provider");
                comm = new MySqlCommand("UPDATE p_dao.device_provider SET isArchived = 1 WHERE dp_id = " + dp_id, conn);
                comm.ExecuteNonQuery();

                conn.Close();
                Console.WriteLine("[CONNECTIONS_DEVICE] > Archived provider : " + dp_id);
                success = true;
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("[CONNECTIONS_DEVICE] > Archived provider error : " + e.Message);
                success = false;
            }
            return success;
        }

        #endregion

        #endregion

        #region [MODE - REQUEST-ADD]

        public bool get_pwd_list(DataGridView pwd_grid)
        {
            Console.WriteLine("[DVC] - [CONNECTIONS_DEVICES] > { [GET_PWD_LIST] }");
            bool has_data = false;

            try
            {
                conn.Open();

                comm = new MySqlCommand("SELECT pwd_id, "
                                             + "registration_no, "
                                             + "CONCAT(lastname,', ',firstname,' ',middlename) as fullname, "
                                             + "id_no, "
                                             + "CONCAT(address_house_no_street, ', ',address_barangay, ', ',address_municipality, ', ' ,address_province) as address, "
                                             + "pwd.disability_id AS dis_id, "
                                             + "disability_type, "
                                             + "tel_no, "
                                             + "mobile_no "
                                             + "FROM pwd JOIN disability ON pwd.disability_id = disability.disability_id WHERE pwd.isArchived != 1 AND "
                                             + "(SELECT EXISTS(SELECT pwd_id FROM device_log WHERE pwd_id = pwd.pwd_id AND isArchived != 1 AND status != 4)) = 0 ORDER BY fullname ASC ", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                DataTable provider_data = new DataTable();
                DataColumn column;
                DataRow row;
                DataView view;

                #region Columns
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "pwd_id";
                provider_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "registration_no";
                provider_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "fullname";
                provider_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "id_no";
                provider_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "address";
                provider_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "dis_id";
                provider_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "disability_type";
                provider_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "tel_no";
                provider_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "mobile_no";
                provider_data.Columns.Add(column);
                #endregion

                int count = set.Rows.Count;
                if (count == 0)
                {
                    string none = "None";
                    row = provider_data.NewRow();
                    row["pwd_id"] = none;
                    row["registration_no"] = none;
                    row["fullname"] = none;
                    row["id_no"] = none;
                    row["address"] = none;
                    row["dis_id"] = none;
                    row["disability_type"] = none;
                    row["tel_no"] = none;
                    row["mobile_no"] = none;
                    provider_data.Rows.Add(row);
                    has_data = false;
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        row = provider_data.NewRow();
                        row["pwd_id"] = set.Rows[i]["pwd_id"].ToString();
                        row["registration_no"] = set.Rows[i]["registration_no"].ToString();
                        row["fullname"] = set.Rows[i]["fullname"].ToString();
                        row["id_no"] = set.Rows[i]["id_no"].ToString();
                        row["address"] = set.Rows[i]["address"].ToString();
                        row["dis_id"] = set.Rows[i]["dis_id"].ToString();
                        row["disability_type"] = set.Rows[i]["disability_type"].ToString();
                        row["tel_no"] = set.Rows[i]["tel_no"].ToString();
                        row["mobile_no"] = set.Rows[i]["mobile_no"].ToString();

                        provider_data.Rows.Add(row);
                    }
                    has_data = true;
                }

                view = new DataView(provider_data);

                pwd_grid.DataSource = view;

                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
            }
            return has_data;
        }

        public bool request_add(string query)
        {
            bool success = false;
            try
            {
                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICES] > { [REQUEST_ADD] }");
                conn.Open();

                comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                success = true;

                conn.Close();
                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICES] > { [REQUEST_ADD_SUCESS] }");
            } catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICES] > { [REQUEST_ADD_ERROR] } : " + e.Message);
                success = false;
            }
            return success;
        }

        public string get_device_by_name(string dev_name)
        {
            string ret_dev_id;
            try
            {
                conn.Open();
                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICES] > { [GET_DEVICE_BY_NAME] }");

                comm = new MySqlCommand("SELECT device_id FROM device WHERE dev_name = '"+ dev_name +"' AND isArchived != 1", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                ret_dev_id = set.Rows[0]["device_id"].ToString();

                conn.Close();
                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICES] > { [GET_DEVICE_BY_NAME_SUCCESS] }");
            }
            catch (Exception e)
            {
                conn.Close();
                ret_dev_id = "0";
                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICES] > { [GET_DEVICE_BY_NAME_ERROR] } : " + e.Message);
            }
            return ret_dev_id;
        }

        public string get_sponsor_by_name(string dp_name)
        {
            string ret_dp_id;
            try
            {
                conn.Open();
                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICES] > { [GET_PROVIDER_BY_NAME] }");

                comm = new MySqlCommand("SELECT dp_id FROM device_provider WHERE dp_name = '" + dp_name + "' AND isArchived != 1", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                ret_dp_id = set.Rows[0]["dp_id"].ToString();

                conn.Close();
                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICES] > { [GET_PROVIDER_BY_NAME_SUCCESS] }");
            }
            catch (Exception e)
            {
                conn.Close();
                ret_dp_id = "0";
                Console.WriteLine("[DVC] - [CONNECTIONS_DEVICES] > { [GET_PROVIDER_BY_NAME_ERROR] } : " + e.Message);
            }
            return ret_dp_id;
        }
        #endregion

        public void mark_as_received(string deviceLOG_id, string in_emp_id, string date)
        {
            try
            {
                Console.WriteLine("Mark as Received.");
                conn.Open();

                comm = new MySqlCommand("UPDATE device_log SET date_in = '"+ date +"', in_emp_id = "+ in_emp_id +", status = 2 WHERE deviceLOG_id = " + deviceLOG_id, conn);
                comm.ExecuteNonQuery();

                conn.Close();
                Console.WriteLine("Marked as Received.");
            } catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("Mark as Received Out Failed : " + e.Message);
            }
        }

        public void mark_as_handed_out(string deviceLOG_id, string out_emp_id, string date)
        {
            try
            {
                Console.WriteLine("Mark as Handed Out.");
                conn.Open();

                comm = new MySqlCommand("UPDATE device_log SET date_out = '"+ date +"', out_emp_id = "+ out_emp_id +",status = 3 WHERE deviceLOG_id = " + deviceLOG_id, conn);
                comm.ExecuteNonQuery();

                conn.Close();
                Console.WriteLine("Marked as Handed Out.");
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("Mark as Handed Out Failed : " + e.Message);
            }
        }

        public void mark_as_cancelled(string deviceLOG_id, string cancel_emp_id, string date)
        {

            try
            {
                Console.WriteLine("Mark as Cancelled.");
                conn.Open();

                comm = new MySqlCommand("UPDATE device_log SET cancel_date = '"+ date +"', cancel_emp_id = "+ cancel_emp_id +", status = 4 WHERE deviceLOG_id = " + deviceLOG_id, conn);
                comm.ExecuteNonQuery();

                conn.Close();
                Console.WriteLine("Marked as Cancelled.");
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("Mark as Cancelled Failed : " + e.Message);
            }
        }

        public bool request_update(string desc, string user_id, string date_requested, string device_requested_id, string sponsor_id, string reference_no, string current_dev_log_id)
        {
            bool success = false;

            try
            {
                conn.Open();
                Console.WriteLine("[EXECUTE] : request_update() >" + desc + Environment.NewLine + user_id + Environment.NewLine + date_requested + Environment.NewLine + device_requested_id + Environment.NewLine + sponsor_id + Environment.NewLine + reference_no);
                comm = new MySqlCommand("UPDATE device_log SET req_desc = '"+ desc +"', "
                                                            + "req_emp_id = "+ user_id +", "
                                                            + "req_date = '"+ date_requested +"', "
                                                            + "device_id = "+ device_requested_id +", "
                                                            + "dp_id = "+ sponsor_id +", "
                                                            + "reference_no = '"+ reference_no +"' WHERE isArchived != 1 AND deviceLOG_id = " + current_dev_log_id, conn);
                comm.ExecuteNonQuery();
                success = true;
                Console.WriteLine("[SUCCESS] : request_update()");
                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
                success = false;
                Console.WriteLine("[ERROR] : request_update() > " + e.Message);
            }

            return success;
        }

        public bool received_update(string desc, string user_id, string date_requested, string device_requested_id, string sponsor_id, string reference_no, string current_dev_log_id, string user_in_id, string date_in)
        {
            bool success = false;

            try
            {
                conn.Open();
                Console.WriteLine("[EXECUTE] : received_update() >" + desc + Environment.NewLine + user_id + Environment.NewLine + date_requested + Environment.NewLine + device_requested_id + Environment.NewLine + sponsor_id + Environment.NewLine + reference_no + Environment.NewLine + user_in_id + Environment.NewLine + date_in);
                comm = new MySqlCommand("UPDATE device_log SET req_desc = '" + desc + "', "
                                                            + "req_emp_id = " + user_id + ", "
                                                            + "req_date = '" + date_requested + "', "
                                                            + "device_id = " + device_requested_id + ", "
                                                            + "dp_id = " + sponsor_id + ", "
                                                            + "in_emp_id = " + user_in_id + ", "
                                                            + "date_in = '" + date_in + "', " 
                                                            + "reference_no = '" + reference_no + "' WHERE isArchived != 1 AND deviceLOG_id = " + current_dev_log_id, conn);
                comm.ExecuteNonQuery();
                success = true;
                Console.WriteLine("[SUCCESS] : received_update()");
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                success = false;
                Console.WriteLine("[ERROR] : received_update() > " + e.Message);
            }

            return success;
        }

        public bool get_handedout_list(DataGridView handedout_grid)
        {
            bool has_data = false;
            try
            {
                conn.Open();

                comm = new MySqlCommand("SELECT (@row_number := @row_number+1) AS no, "
                                              + "deviceLOG_id, "
                                              + "dp_name, "
                                              + "fullname, "
                                              + "dev_name, "
                                              + "req_date, "
                                              + "req_desc, "
                                              + "user_req, "
                                              + "date_in, "
                                              + "user_in, "
                                              + "date_out, "
                                              + "user_out, "
                                              + "status, "
                                              + "reference_no,"
                                              + "disability_type, "
                                              + "mobile_no, "
                                              + "tel_no, "
                                              + "id_no, "
                                              + "registration_no "
                                              + "FROM(SELECT "
                                                  + "deviceLOG_id, "
                                                  + "dp_name, "
                                                  + "(CONCAT(lastname, ',', firstname, ' ', SUBSTRING(middlename, 1, 1))) AS fullname, "
                                                  + "dev_name, "
                                                  + "req_date, "
                                                  + "req_desc, "
                                                  + "(SELECT username FROM user WHERE user.user_id = device_log.req_emp_id) AS user_req,"
                                                  + "device_log.date_in, "
                                                  + "(SELECT username FROM user WHERE user.user_id = device_log.in_emp_id) AS user_in, "
                                                  + "device_log.date_out, "
                                                  + "(SELECT username FROM user WHERE user.user_id = device_log.out_emp_id) AS user_out, "
                                                  + "device_log.status, "
                                                  + "device_log.reference_no, "
                                                  + "disability.disability_type, "
                                                  + "pwd.mobile_no, "
                                                  + "pwd.tel_no, "
                                                  + "pwd.id_no, "
                                                  + "pwd.registration_no "
                                                  + "FROM device_log JOIN device ON device_log.device_id = device.device_id "
                                                  + "JOIN pwd ON pwd.pwd_id = device_log.pwd_id "
                                                  + "JOIN disability ON pwd.disability_id = disability.disability_id "
                                                  + "JOIN device_provider ON device_log.dp_id = device_provider.dp_id "
                                                  + "WHERE device_log.isArchived != 1 AND status = 3 "
                                                  + "ORDER BY date_out DESC) t1, (SELECT @row_number:= 0) t2;", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                DataTable handout_data = new DataTable();
                DataColumn column;
                DataRow row;
                DataView view;

                #region Columns
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "no";
                handout_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "deviceLOG_id";
                handout_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "dp_name";
                handout_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "fullname";
                handout_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "dev_name";
                handout_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "req_date";
                handout_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "req_desc";
                handout_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "user_req";
                handout_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "date_in";
                handout_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "user_in";
                handout_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "date_out";
                handout_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "user_out";
                handout_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "status";
                handout_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "reference_no";
                handout_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "disability_type";
                handout_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "mobile_no";
                handout_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "tel_no";
                handout_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "id_no";
                handout_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "registration_no";
                handout_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "handed_out_text";
                handout_data.Columns.Add(column);
                #endregion

                int count = set.Rows.Count;
                if (count == 0)
                {
                    string none = "None";
                    row = handout_data.NewRow();
                    row["no"] = none;
                    row["deviceLOG_id"] = "0";
                    row["dp_name"] = none;
                    row["fullname"] = none;
                    row["dev_name"] = none;
                    row["req_date"] = none;
                    row["req_desc"] = none;
                    row["user_req"] = none;
                    row["date_in"] = none;
                    row["user_in"] = none;
                    row["date_out"] = none;
                    row["user_out"] = none;
                    row["status"] = none;
                    row["reference_no"] = none;
                    row["disability_type"] = none;
                    row["mobile_no"] = none;
                    row["tel_no"] = none;
                    row["id_no"] = none;
                    row["registration_no"] = none;
                    row["handed_out_text"] = "There are currently no devices handed out.";
                    handout_data.Rows.Add(row);
                    has_data = false;
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        row = handout_data.NewRow();
                        row["no"] = set.Rows[i]["no"].ToString();
                        row["deviceLOG_id"] = set.Rows[i]["deviceLOG_id"].ToString();
                        row["dp_name"] = set.Rows[i]["dp_name"].ToString();
                        row["fullname"] = set.Rows[i]["fullname"].ToString();
                        row["dev_name"] = set.Rows[i]["dev_name"].ToString();
                        string[] req_date = set.Rows[i]["req_date"].ToString().Split();
                        row["req_date"] = req_date[0];
                        row["req_desc"] = set.Rows[i]["req_desc"].ToString();
                        row["user_req"] = set.Rows[i]["user_req"].ToString();
                        string[] date_in = set.Rows[i]["date_in"].ToString().Split();
                        row["date_in"] = date_in[0];
                        row["user_in"] = set.Rows[i]["user_in"].ToString();
                        string[] date_out = set.Rows[i]["date_out"].ToString().Split();
                        row["date_out"] = date_out[0];
                        row["user_out"] = set.Rows[i]["user_out"].ToString();
                        row["status"] = set.Rows[i]["status"].ToString();
                        row["reference_no"] = set.Rows[i]["reference_no"].ToString();
                        row["disability_type"] = set.Rows[i]["disability_type"].ToString();
                        row["mobile_no"] = set.Rows[i]["mobile_no"].ToString();
                        row["tel_no"] = set.Rows[i]["tel_no"].ToString();
                        row["id_no"] = set.Rows[i]["id_no"].ToString();
                        row["registration_no"] = set.Rows[i]["registration_no"].ToString();
                        row["handed_out_text"] = " ";
                        handout_data.Rows.Add(row);
                    }
                    has_data = true;
                }

                view = new DataView(handout_data);

                handedout_grid.DataSource = view;

                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("[ERROR] get_cancelled_handedout_list() : " + e.Message);
            }

            return has_data;
        }

        public bool handout_update(string query)
        {
            bool success = false;
            try
            {
                conn.Open();

                comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();

                success = true;
                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                success = false;
            }
            return success;
        }
    }
}
