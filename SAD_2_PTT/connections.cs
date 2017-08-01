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
            MySqlCommand comm = new MySqlCommand("SELECT pwd_id, "
                                                          + "registration_no, "
                                                          + "CONCAT(lastname,', ', firstname, ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS fullname, "
                                                          + "(CASE WHEN sex = 0 THEN 'Male' ELSE 'Female' END) as sex, "
                                                          + "disability_type, "
                                                          + "blood_type, "
                                                          + "(CASE WHEN civil_status = 1 THEN 'Single' WHEN civil_status = 2 THEN 'Married' WHEN civil_status = 3 THEN 'Widow/er' WHEN civil_status = 4 THEN 'Separated' ELSE 'Co-Habitation' END) AS civil_status, "
                                                          + "application_date, "
                                                          + "added_date, "
                                                          + "status_pwd "
                                                          + "FROM pwd LEFT JOIN disability ON pwd.disability_id = disability.disability_id WHERE CONCAT_WS('|', registration_no, fullname, sex, disability_type, blood_type, civil_status, application_date, added_date) LIKE '%" + pwd_searchbox.Text + "%'", conn);
            MySqlDataAdapter getresult = new MySqlDataAdapter(comm);
            DataTable resulttable = new DataTable();
            getresult.Fill(resulttable);

            pwd_grid.DataSource = resulttable;
            conn.Close();
        }

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
        //has mun bar prov reg
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

        #endregion

        #region [ Device Module ]

        #region Methods
        public void getDisability(ComboBox cmbox_dis)
        {
            MySqlCommand com = new MySqlCommand("SELECT disability_type FROM disability", conn);
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

        public void getProvider(ComboBox cmbox_prov)
        {
            MySqlCommand com = new MySqlCommand("SELECT dp_name FROM device_provider", conn);
            MySqlDataReader dr;

            try
            {
                conn.Open();
                dr = com.ExecuteReader();

                while (dr.Read())
                {
                    string provider = dr.GetString("dp_name");
                    cmbox_prov.Items.Add(provider);
                }
                if (cmbox_prov.Items.Count == 0)
                {
                    MessageBox.Show("No device provider added.");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in getProvider() : " + ex);
                conn.Close();
            }
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
        #endregion

        #endregion

        #region [ SETTINGS ]
        public void employee_list(DataGridView employee_grid)
        {
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("SELECT employee_id, "
                                                          + "CONCAT(lastname,', ', firstname, ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS fullname, "
                                                          + "address,"
                                                          + " position, "
                                                          + "contact_no, "
                                                          + "birthdate, "
                                                          + "status_id, "
                                                          + "username, "
                                                          + "password "
                                                          + "FROM employee", conn);
                MySqlDataAdapter get = new MySqlDataAdapter(comm);
                DataTable set = new DataTable();
                get.Fill(set);

                employee_grid.DataSource = set;
                if (set.Rows.Count == 0)
                {
                    MessageBox.Show("No Employee Profiles added.");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message); //error
            }
        }

        #endregion
    }
}
