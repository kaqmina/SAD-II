using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace SAD_2_PTT
{
    class connections
    {
        public MySqlConnection conn;
        public connections()
        {
            conn = new MySqlConnection("Server=localhost;Database=p_dao;Uid=root;Pwd=root");
        }

        #region [ PWD Profiling Module ]

        #region PWD Searchbox | Grid | CBox

        public void pwd_grid_list(DataGridView pwd_grid)
        {
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("SELECT pwd_id, "
                                                          + "registration_no, "
                                                          + "CONCAT(lastname,', ', firstname, ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS fullname, "
                                                          + "(CASE WHEN sex = 0 THEN 'Male' ELSE 'Female' END) as sex, "
                                                          + "disability_type, "
                                                          + "(CASE WHEN blood_type = 1 THEN 'O' WHEN blood_type = 2 THEN 'A' WHEN blood_type = 3 THEN 'B' ELSE 'AB' END) AS blood_type, "
                                                          + "(CASE WHEN civil_status = 1 THEN 'Single' WHEN civil_status = 2 THEN 'Married' WHEN civil_status = 3 THEN 'Widow/er' WHEN civil_status = 4 THEN 'Separated' ELSE 'Co-Habitation' END) AS civil_status, "
                                                          + "application_date, "
                                                          + "added_date, "
                                                          + "status_pwd "
                                                          + "FROM pwd LEFT JOIN p_dao.disability ON (disability.disability_id = pwd.disability_id) WHERE isArchived = 0", conn);
                MySqlDataAdapter get = new MySqlDataAdapter(comm);
                DataTable set = new DataTable();
                get.Fill(set);


                pwd_grid.DataSource = set;
                if (set.Rows.Count == 0)
                {
                    MessageBox.Show("No PWD Profiles added.");
                }
                conn.Close();
                Console.WriteLine("Grid Loaded");
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message); //error
            }
        }

        public void populate_cbox(ComboBox disability_type)
        {
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("SELECT * FROM disability", conn);
                MySqlDataAdapter get = new MySqlDataAdapter(comm);
                DataTable set = new DataTable();
                get.Fill(set);

                int count = set.Rows.Count;
                if (count == 0)
                {
                    MessageBox.Show("No disabilities added.");
                }
                else
                {
                    foreach (DataRow data in set.Rows)
                    {
                        disability_type.Items.Add(data["disability_type"].ToString());
                    }
                }
                conn.Close();
                Console.WriteLine("Populated Disability Combobox");
            }
            catch (Exception e)
            {
                conn.Close();
                MessageBox.Show(e.Message); //error
            }
        }

        public void pwd_search(DataGridView pwd_grid, TextBox pwd_searchbox)
        {
            conn.Open();
            string regis;
            string lastname;
            string firstname;
            string middlename;
            string app_date;
            lastname = firstname = middlename = app_date = regis = " ";
            string[] separators = { " " };
            string value = pwd_searchbox.Text;
            string[] search = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string last = search.Last();
            foreach (string word in search)
            {
                if (word == last)
                {
                    regis += ("registration_no LIKE '%" + word + "%' ");
                    lastname += ("lastname LIKE '%" + word + "%' ");
                    firstname += ("firstname LIKE '%" + word + "%' ");
                    middlename += ("middlename LIKE '%" + word + "%' ");
                    app_date += ("application_date LIKE '%" + word + "%' ");
                } else
                {
                    regis += ("registration_no LIKE '%" + word + "%' OR ");
                    lastname += ("lastname LIKE '%" + word + "%' OR ");
                    firstname += ("firstname LIKE '%" + word + "%' OR ");
                    middlename += ("middlename LIKE '%" + word + "%' OR ");
                    app_date += ("application_date LIKE '%" + word + "%' OR ");
                }
            }
            MySqlCommand comm = new MySqlCommand("SELECT pwd_id, "
                                                      + "registration_no, "
                                                      + "CONCAT(lastname,', ', firstname, ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS fullname, "
                                                      + "lastname, "
                                                      + "firstname, "
                                                      + "middlename, "
                                                      + "(CASE WHEN sex = 0 THEN 'Male' ELSE 'Female' END) as sex, "
                                                      + "disability_type, "
                                                      + "blood_type, "
                                                      + "(CASE WHEN civil_status = 1 THEN 'Single' WHEN civil_status = 2 THEN 'Married' WHEN civil_status = 3 THEN 'Widow/er' WHEN civil_status = 4 THEN 'Separated' ELSE 'Co-Habitation' END) AS civil_status, "
                                                      + "application_date, "
                                                      + "added_date, "
                                                      + "status_pwd "
                                                      + "FROM pwd LEFT JOIN disability ON pwd.disability_id = disability.disability_id WHERE "
                                                      + regis + " OR "
                                                      + lastname + " OR "
                                                      + firstname + " OR "
                                                      + middlename + " OR "
                                                      + app_date, conn);

            MySqlDataAdapter getresult = new MySqlDataAdapter(comm);
            DataTable resulttable = new DataTable();
            getresult.Fill(resulttable);
            pwd_grid.DataSource = resulttable;


            conn.Close();
        }

        #endregion

        #region PWD ADD PA - 11
        public void pwd_add_profile(string main_data, string other_data, string parental_data)
        {
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand(main_data, conn);
                comm.ExecuteNonQuery();
                comm = new MySqlCommand(other_data, conn);
                comm.ExecuteNonQuery();
                comm = new MySqlCommand(parental_data, conn);
                comm.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                MessageBox.Show(e.Message);
            }
        }
        #endregion

        #region PWD VIEW PV - 12
        public void pwd_view_profile(int current_id, DataTable main, DataTable other_info, DataTable parental_info)
        {
            try
            {
                conn.Open();
                string type_of_skill = "(CASE WHEN type_of_skill = 1 THEN 'Officials of Government and Special Interest Organizations, Corporate Executives, Managers, Managing Proprietors and Supervisors' "
                                           + "WHEN type_of_skill = 2 THEN 'Professionals' "
                                           + "WHEN type_of_skill = 3 THEN 'Technicians and Associate Professionals' "
                                           + "WHEN type_of_skill = 4 THEN 'Farmers, Forestry Workers and Fishermen' "
                                           + "WHEN type_of_skill = 5 THEN 'Trades and Related Workers' "
                                           + "WHEN type_of_skill = 6 THEN 'Plant and Machine Operators and Assemblers' "
                                           + "WHEN type_of_skill = 7 THEN 'Laborers' "
                                           + "WHEN type_of_skill = 8 THEN 'Unskilled Workers' "
                                           + "ELSE 'Special Occupation' END) AS type_of_skill, ";
                MySqlCommand comm = new MySqlCommand("SELECT pwd_id, "
                                                          + "registration_no, "
                                                          + "CONCAT(UCASE(lastname), ', ', firstname, ' ', middlename) AS fullname, "
                                                          + "(CASE WHEN sex = 0 THEN 'Male' ELSE 'Female' END) as sex, "
                                                          + "disability_type, "
                                                          + "blood_type, "
                                                          + "(CASE WHEN civil_status = 1 THEN 'Single' WHEN civil_status = 2 THEN 'Married' WHEN civil_status = 3 THEN 'Widow/er' WHEN civil_status = 4 THEN 'Separated' ELSE 'Co-Habitation' END) AS civil_status, "
                                                          + "application_date, "
                                                          + "added_date, "
                                                          + "end_date, "
                                                          + "nationality, "
                                                          + "birthdate, "
                                                          + "tel_no, "
                                                          + "mobile_no, "
                                                          + "email_add, "
                                                          + "accomplished_by, "
                                                          + "(CASE WHEN educ_attainment = 1 THEN 'Elementary' WHEN educ_attainment = 2 THEN 'Elementary Undergraduate' WHEN educ_attainment = 3 THEN 'High School' WHEN educ_attainment = 4 THEN 'High School Undergraduate' WHEN educ_attainment = 5 THEN 'College' WHEN educ_attainment = 6 THEN 'College Undergraduate' WHEN educ_attainment = 7 THEN 'Graduate' WHEN educ_attainment = 8 THEN 'Post Graduate' WHEN educ_attainment = 9 THEN 'Vocational' ELSE 'None' END) AS educ_attainment, "
                                                          + "(CASE WHEN employment_status = 1 THEN 'Employed' WHEN employment_status = 2 THEN 'Unemployed' WHEN employment_status = 3 THEN 'Displaced Worker' WHEN employment_status = 4 THEN 'Resigned' WHEN employment_status = 5 THEN 'Retired' ELSE 'Returning Overseas Filipino Worker' END) AS employment_status, "
                                                          + "(CASE WHEN nature_of_employer = 2 THEN 'Government' ELSE 'Private' END) AS nature_of_employer, "
                                                          + "(CASE WHEN type_of_employment = 1 THEN 'Contractual' WHEN type_of_employment = 2 THEN 'Permanent' WHEN type_of_employment = 3 THEN 'Self-Employed' ELSE 'Seasonal' END) AS type_of_employment, "
                                                          + type_of_skill
                                                          + "(CASE WHEN status_pwd = 0 THEN 'Inactive/Expired' ELSE 'Active' END) as status_pwd, "
                                                          + "address "
                                                          + "FROM p_dao.pwd LEFT JOIN p_dao.disability ON (disability.disability_id = pwd.disability_id) WHERE isArchived = 0 AND pwd_id = " + current_id, conn);
                MySqlDataAdapter main_data = new MySqlDataAdapter(comm);
                main_data.Fill(main);
                comm = new MySqlCommand("SELECT sss_no, "
                                             + "gsis_no, "
                                             + "phealth_no, "
                                             + "(CASE WHEN phealth_status = 1 THEN 'PhilHealth Member' ELSE 'PhilHealth Member Dependent' END) AS phealth_status, "
                                             + "organization_aff, "
                                             + "contact_person, "
                                             + "office_address, "
                                             + "tel_no, "
                                             + "name_of_reporting_unit "
                                             + "FROM pwd_otherinfo WHERE pwd_id = " + current_id, conn);
                MySqlDataAdapter other_data = new MySqlDataAdapter(comm);
                other_data.Fill(other_info);
                comm = new MySqlCommand("SELECT CONCAT(UCASE(fatherln), ', ', UCASE(fatherfn), ' ', fathermn) AS father, "
                                             + "CONCAT(UCASE(motherln), ', ', UCASE(motherfn), ' ', mothermn) AS mother, "
                                             + "CONCAT(UCASE(guardianln), ', ', UCASE (guardianfn), ' ', guardianmn) AS guardian "
                                             + "FROM parental_info WHERE pwd_id = " + current_id, conn);
                MySqlDataAdapter parent_data = new MySqlDataAdapter(comm);
                parent_data.Fill(parental_info);

                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                MessageBox.Show(e.Message); //error
            }
        }
        #endregion

        #region PWD UPDATE PU - 13
        public void pwd_update_profile(string main_data, string other_data, string parental_data)
        {
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand(main_data, conn);
                comm.ExecuteNonQuery();
                comm = new MySqlCommand(other_data, conn);
                comm.ExecuteNonQuery();
                comm = new MySqlCommand(parental_data, conn);
                comm.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                MessageBox.Show(e.ToString());
            }
        }

        public void pwd_update_profile_data(int current_id, DataTable main, DataTable other_info, DataTable parental_info)
        {
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("SELECT pwd_id, "
                                                          + "registration_no, "
                                                          + "lastname, "
                                                          + "firstname, "
                                                          + "middlename, "
                                                          + "sex, "
                                                          + "disability_id, "
                                                          + "blood_type, "
                                                          + "civil_status, "
                                                          + "application_date, "
                                                          + "added_date, "
                                                          + "end_date, "
                                                          + "nationality, "
                                                          + "birthdate, "
                                                          + "tel_no, "
                                                          + "mobile_no, "
                                                          + "email_add, "
                                                          + "accomplished_by, "
                                                          + "educ_attainment, "
                                                          + "employment_status, "
                                                          + "nature_of_employer, "
                                                          + "type_of_employment, "
                                                          + "type_of_skill, "
                                                          + "status_pwd, "
                                                          + "address "
                                                          + "FROM p_dao.pwd WHERE isArchived = 0 AND pwd.pwd_id = " + current_id, conn);
                MySqlDataAdapter main_data = new MySqlDataAdapter(comm);
                main_data.Fill(main);
                comm = new MySqlCommand("SELECT sss_no, "
                                             + "gsis_no, "
                                             + "phealth_no, "
                                             + "phealth_status, "
                                             + "organization_aff, "
                                             + "contact_person, "
                                             + "office_address, "
                                             + "tel_no, "
                                             + "name_of_reporting_unit "
                                             + "FROM pwd_otherinfo WHERE pwd_id = " + current_id, conn);
                MySqlDataAdapter other_data = new MySqlDataAdapter(comm);
                other_data.Fill(other_info);
                comm = new MySqlCommand("SELECT * FROM parental_info WHERE pwd_id = " + current_id, conn);
                MySqlDataAdapter parent_data = new MySqlDataAdapter(comm);
                parent_data.Fill(parental_info);

                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                MessageBox.Show(e.Message); //error
            }
        }


        #endregion

        #region PWD ARCHIVE PA - 14
        public void archive_profile(int current_id)
        {
            conn.Open();

            MySqlCommand comm = new MySqlCommand("UPDATE p_dao.pwd SET isArchived = 1 WHERE pwd_id = " + current_id, conn);
            comm.ExecuteNonQuery();

            conn.Close();
        }
        #endregion

        #region PWD FILTER - PF 15
        public void pwd_grid_filter(string category)
        {
            //Name, Age, Gender, Disability, District, Membership Expired, Archived
        }

        #endregion

        #endregion

        #region [ Device Module ]

        #region Methods
        public void getDisability(ComboBox cmbox_dis)
        {
            MySqlCommand com = new MySqlCommand("SELECT disability_type FROM p_dao.disability", conn);
            MySqlDataReader dr;

            try
            {
                conn.Open();
                dr = com.ExecuteReader();

                while (dr.Read())
                {
                    string dis = dr.GetString("disability_type");
                    if (dis == "") MessageBox.Show("No disabilities added.");
                    else cmbox_dis.Items.Add(dis);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in getDisability() : " + ex);
                conn.Close();
            }
        }

        public void getDevice(int d, ComboBox cmbox_dev)
        {
            try
            {
                conn.Open();

                cmbox_dev.Items.Clear();
                cmbox_dev.Items.Add("");


                MySqlCommand com = new MySqlCommand("SELECT dev_name FROM p_dao.device WHERE disability_id = " + d, conn);
                MySqlDataAdapter get = new MySqlDataAdapter(com);
                DataTable set = new DataTable();
                get.Fill(set);

                int count = set.Rows.Count;
                if (count == 0)
                {
                    MessageBox.Show("No devices added for this disability.");
                }
                else
                {
                    foreach (DataRow data in set.Rows)
                    {
                        cmbox_dev.Items.Add(data["dev_name"].ToString());
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in getDevice(): " + ex);
                conn.Close();
            }
        }


        public void getProvider(ComboBox cmbox_prov)
        {
            MySqlCommand com = new MySqlCommand("SELECT dp_name FROM p_dao.device_provider", conn);
            MySqlDataReader dr;

            try
            {
                conn.Open();
                dr = com.ExecuteReader();

                while (dr.Read())
                {
                    string provider = dr.GetString("dp_name");
                    if (cmbox_prov.Items.Count == 0) MessageBox.Show("No device provider added.");
                    else cmbox_prov.Items.Add(provider);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in getProvider() : " + ex);
                conn.Close();
            }
        }

        public void device_log_emp(string user)
        {
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("SELECT employee_id FROM p_dao.employee WHERE username = '" + user + "')", conn);
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in device_log_emp(): " + ex);
            }
        }

        public void device_out_Format(DataGridView dev_editreq)
        {
            dev_editreq.Columns["pwd_id"].Visible = false;
            dev_editreq.Columns["dp_id"].Visible = false;
            dev_editreq.Columns["device_id"].Visible = false;
            dev_editreq.Columns["disability_id"].Visible = false;
            dev_editreq.Columns["deviceLOG_id"].Visible = false;
            dev_editreq.Columns["req_desc"].Visible = false;
            dev_editreq.Columns["registration_no"].HeaderText = "Reg. No.";
            dev_editreq.Columns["pwd_name"].HeaderText = "Name";
            dev_editreq.Columns["date_in"].HeaderText = "Date IN";
            dev_editreq.Columns["date_out"].HeaderText = "Date OUT";
            dev_editreq.Columns["dev_name"].HeaderText = "Device";
            dev_editreq.Columns["dp_name"].HeaderText = "Device Provider";
            dev_editreq.Columns["req_date"].HeaderText = "Requested Date";
            dev_editreq.Columns["Status"].HeaderText = "Status";
        }

        public void device_in_Format(DataGridView dev_editreq)
        {
            dev_editreq.Columns["pwd_id"].Visible = false;
            dev_editreq.Columns["dp_id"].Visible = false;
            dev_editreq.Columns["device_id"].Visible = false;
            dev_editreq.Columns["disability_id"].Visible = false;
            dev_editreq.Columns["deviceLOG_id"].Visible = false;
            dev_editreq.Columns["req_desc"].Visible = false;
            dev_editreq.Columns["date_out"].Visible = false;
            dev_editreq.Columns["registration_no"].HeaderText = "Reg. No.";
            dev_editreq.Columns["pwd_name"].HeaderText = "Name";
            dev_editreq.Columns["date_in"].HeaderText = "Date IN";
            dev_editreq.Columns["dev_name"].HeaderText = "Device";
            dev_editreq.Columns["dp_name"].HeaderText = "Device Provider";
            dev_editreq.Columns["req_date"].HeaderText = "Requested Date";
            dev_editreq.Columns["Status"].HeaderText = "Status";
        }


        public bool checkStatus(string stat)
        {
            bool check = false;
            device_view v = new device_view();
            try
            {
                conn.Open();
                if (stat == "in")
                {
                    MySqlCommand comm = new MySqlCommand("SELECT in_emp_id FROM device_log WHERE deviceLOG_id = '" + v.id + "'");
                    MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    if (!dt.Rows.Contains("")) check = true;
                    else check = false;
                }
                else if(stat == "out")
                {
                    MySqlCommand comm = new MySqlCommand("SELECT out_emp_id FROM device_log WHERE deviceLOG_id = '" + v.id + "'");
                    MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    if (!dt.Rows.Contains("")) check = true;
                    else check = false;
                }
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error in checkStatus(): " + ex);
                conn.Close();
            }
            return check;
        }
        #endregion

        #region DataLoad
        public void device_add_grid(DataGridView dev_addgrid)
        {
            try
            {
                conn.Open();
                MySqlCommand com = new MySqlCommand("SELECT * FROM device", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dev_addgrid.DataSource = dt;
                dev_addgrid.Columns["device_id"].Visible = false;
                dev_addgrid.Columns["disability_id"].Visible = false;
                dev_addgrid.Columns["dev_desc"].Visible = false;
                dev_addgrid.Columns["dev_name"].HeaderText = "Device Name";

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in device_add_grid() : " + ex);
            }
        }

        public void device_prov_grid(DataGridView dev_provgrid)
        {
            try
            {
                conn.Open();
                MySqlCommand com = new MySqlCommand("SELECT * FROM device_provider", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dev_provgrid.DataSource = dt;
                dev_provgrid.Columns["dp_id"].Visible = false;
                dev_provgrid.Columns["dp_desc"].Visible = false;
                dev_provgrid.Columns["dp_type"].Visible = false;
                dev_provgrid.Columns["mobile_no"].Visible = false;
                dev_provgrid.Columns["tel_no"].Visible = false;
                dev_provgrid.Columns["email_add"].Visible = false;
                dev_provgrid.Columns["dp_name"].HeaderText = "Device Provider";

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in device_prov_grid() : " + ex);
                conn.Close();
            }
        }

        public void device_dis_grid(DataGridView dev_disgrid)
        {
            try
            {
                conn.Open();
                MySqlCommand com = new MySqlCommand("SELECT * FROM disability", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dev_disgrid.DataSource = dt;
                dev_disgrid.Columns["disability_id"].Visible = false;
                dev_disgrid.Columns["disability_desc"].Visible = false;
                dev_disgrid.Columns["disability_type"].HeaderText = "Disability Type";

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in device_dis_grid() : " + ex);
            }
        }

        public void device_addreq_grid(DataGridView dev_addreq)
        {
            try
            {
                conn.Open();
                MySqlCommand com = new MySqlCommand("SELECT pwd_id,registration_no, CONCAT(lastname, ', ' , firstname, ' ', middlename) AS fullname FROM pwd", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dev_addreq.DataSource = dt;
                dev_addreq.Columns["pwd_id"].Visible = false;
                dev_addreq.Columns["registration_no"].HeaderText = "Reg. No.";
                dev_addreq.Columns["fullname"].HeaderText = "Full Name";
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in device_addreq_grid() : " + ex);
            }
        }

        public void device_editreq_grid(DataGridView dev_editreq, string status)
        {
            try
            {
                conn.Open();
                string query, current; // current status selected
                string date_in = "(CASE WHEN date_in IS NULL THEN 'Pending' ELSE DATE_FORMAT(date_in,'%d/%m/%Y') END) AS date_in";
                if (status == "Requested")
                {
                    current = "(CASE WHEN status = 0 THEN 'Requested' END)";
                    query = "SELECT device_log.pwd_id, device_log.dp_id, device_log.device_id, device.disability_id, deviceLOG_id, registration_no, CONCAT(lastname, ', ' , firstname, ' ', middlename) AS pwd_name, " + date_in + ", date_out, req_date, dev_name, dp_name, req_desc, "
                                   + current + " AS Status FROM device_log"
                                   + " JOIN p_dao.device_provider ON device_log.dp_id = device_provider.dp_id"
                                   + " JOIN p_dao.device ON device_log.device_id = device.device_id"
                                   + " JOIN pwd ON device_log.pwd_id = pwd.pwd_id"
                                   + " WHERE status = 0";
                    MySqlCommand com = new MySqlCommand(query, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    dev_editreq.DataSource = dt;
                    device_in_Format(dev_editreq);
                }
                else if (status == "Received")
                {
                    current = "(CASE WHEN status = 1 THEN 'Received' END)";
                    query = "SELECT device_log.pwd_id, device_log.dp_id, device_log.device_id, device.disability_id, deviceLOG_id, registration_no, CONCAT(lastname, ', ' , firstname, ' ', middlename) AS pwd_name, " + date_in + ", date_out, req_date, dev_name, dp_name, req_desc, "
                                   + current + " AS Status FROM device_log"
                                   + " JOIN device_provider ON device_log.dp_id = device_provider.dp_id"
                                   + " JOIN device ON device_log.device_id = device.device_id"
                                   + " JOIN pwd ON device_log.pwd_id = pwd.pwd_id"
                                   + " WHERE status = 1";
                    MySqlCommand com = new MySqlCommand(query, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    dev_editreq.DataSource = dt;
                    device_in_Format(dev_editreq);
                }
                else if(status == "default")
                {
                    current = "(CASE WHEN status = 0 THEN 'Requested' WHEN status = 1 THEN 'Received' END)";
                    query = "SELECT device_log.pwd_id, device_log.dp_id, device_log.device_id, device.disability_id, deviceLOG_id, registration_no, CONCAT(lastname, ', ' , firstname, ' ', middlename) AS pwd_name, " + date_in + ", date_out, req_date, dev_name, dp_name, req_desc,"
                                    + current + "AS Status FROM p_dao.device_log"
                                    + " JOIN device_provider ON device_log.dp_id = device_provider.dp_id"
                                    + " JOIN device ON device_log.device_id = device.device_id"
                                    + " JOIN pwd ON device_log.pwd_id = pwd.pwd_id"
                                    + " WHERE Status NOT IN(SELECT status FROM device_log WHERE Status = 2)";
                    MySqlCommand com = new MySqlCommand(query, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    dev_editreq.DataSource = dt;
                    device_in_Format(dev_editreq);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in device_editreq_grid() : " + ex);
                conn.Close();
            }
        }

        public void device_out_grid(DataGridView device_grid)
        {
            string current = "(CASE WHEN status = 2 THEN 'Handed Out' END)";
            string query = "SELECT device_log.pwd_id, device_log.dp_id, device_log.device_id, device.disability_id, deviceLOG_id, registration_no, CONCAT(lastname, ', ', firstname, ' ', middlename) AS pwd_name, req_date, date_in, date_out, dev_name, dp_name, req_desc, "
                            + current + " AS Status FROM p_dao.device_log"
                            + " JOIN device_provider ON device_log.dp_id = device_provider.dp_id"
                            + " JOIN device ON device_log.device_id = device.device_id"
                            + " JOIN pwd ON device_log.pwd_id = pwd.pwd_id"
                            + " WHERE status = 2";
            MySqlCommand com = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(com);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            device_grid.DataSource = dt;
            device_out_Format(device_grid);
        }
        #endregion

        #region Add | Edit | Search | Delete
        public void Add(string query, string values)
        {
            try
            {
                conn.Open();
                MySqlCommand com = new MySqlCommand(query + values, conn);
                com.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Added Successfully!", "", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Add() : " + ex);
                conn.Close();
            }
        }

        public void Edit(string query, bool cont)
        {
            if (cont == true)
            {
                try
                {
                    conn.Open();
                    MySqlCommand com = new MySqlCommand(query, conn);
                    com.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Updated Successfully!", "", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in Edit() : " + ex);
                    conn.Close();
                }
            }
            else
            {
                //do nothing
            }
        }

        public void Search(string query, DataGridView form)
        {
            try
            {
                conn.Open();
                MySqlCommand com = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                DataTable dt = new DataTable();

                adp.Fill(dt);
                form.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Search(): " + ex);
                conn.Close();
            }
        }

        public void Delete(string query, bool cont)
        {
            if (cont == true)
            {
                try
                {
                    conn.Open();
                    MySqlCommand com = new MySqlCommand(query, conn);
                    com.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Removed Successfully!", "", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in Delete() : " + ex);
                    conn.Close();
                }
            }
            else
            {
                // do nothing 
            }
        }
        #endregion

        #endregion

        #region [ SETTINGS ]
      

        #endregion

        public bool login_user(string uname, string pword)
        {
            bool valid = false;
            try
            {
                conn.Open();

                MySqlCommand comm = new MySqlCommand( "SELECT * FROM p_dao.employee WHERE username = '" + uname + "' AND password = '" + pword + "'" ,conn);
                MySqlDataAdapter get = new MySqlDataAdapter(comm);
                DataTable set = new DataTable();
                get.Fill(set);

                if (set.Rows.Count == 1)
                    valid = true;
                else
                    valid = false;

                conn.Close();
            } catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return valid;
            
        }
    }
}
