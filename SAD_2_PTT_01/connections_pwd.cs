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
    class connections_pwd
    {
        public MySqlConnection conn;
        MySqlCommand comm;
        MySqlDataAdapter get;
        DataTable set;
        public connections_pwd()
        {
            conn = new MySqlConnection("Server=localhost;Database=p_dao;Uid=root;Pwd=root");
        }

        #region GRID-MAIN_FORM
        public void pwd_grid_list(DataGridView pwd_grid)
        {
            try
            {
                conn.Open();
                comm = new MySqlCommand("SELECT pwd_id, "
                                             + "registration_no, "
                                             + "CONCAT(lastname,', ', firstname, ' ', UCASE(SUBSTRING(middlename,1,1)), SUBSTRING(middlename, 2)) AS fullname, "
                                             + "(CASE WHEN sex = 0 THEN 'M' ELSE 'F' END) as sex, "
                                             + "DATE_FORMAT(NOW(), '%Y') - DATE_FORMAT(birthdate, '%Y') - (DATE_FORMAT(NOW(), '00-%m-%d') < DATE_FORMAT(birthdate, '00-%m-%d')) AS age, "
                                             + "disability_type, "
                                             + "(CASE WHEN blood_type = 1 THEN 'O' WHEN blood_type = 2 THEN 'A' WHEN blood_type = 3 THEN 'B' ELSE 'AB' END) AS blood_type, "
                                             + "(CASE WHEN civil_status = 1 THEN 'Single' WHEN civil_status = 2 THEN 'Married' WHEN civil_status = 3 THEN 'Widow/er' WHEN civil_status = 4 THEN 'Separated' ELSE 'Co-Habitation' END) AS civil_status, "
                                             + "application_date, "
                                             + "added_date, "
                                             + "district_id, "
                                             + "status_pwd "
                                             + "FROM pwd LEFT JOIN p_dao.disability ON (disability.disability_id = pwd.disability_id) WHERE pwd.isArchived = 0", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);


                pwd_grid.DataSource = set;
                if (set.Rows.Count == 0)
                {
                    MessageBox.Show("No PWD Profiles added.");
                }
                conn.Close();
                Console.WriteLine("[PWD] - [CONNECTIONS_PWD]   > { PWD_GRID_LIST_LOADED }");
            }
            catch (Exception ex)
            {
                conn.Close();
                Console.WriteLine("--->>" + ex.Message + "<<---");
                MessageBox.Show("[ERROR_PWD_GRID_LOAD]"); //error
            }
        }

        #endregion

        #region VIEW-MODE
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
                comm = new MySqlCommand("SELECT pwd_id, "
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
                                                          + "(CASE WHEN educ_attainment = 1 THEN 'Elementary' WHEN educ_attainment = 2 THEN 'Elementary Undergraduate' WHEN educ_attainment = 3 THEN 'High School' WHEN educ_attainment = 4 THEN 'High School Undergraduate' WHEN educ_attainment = 5 THEN 'College' WHEN educ_attainment = 6 THEN 'College Undergraduate' WHEN educ_attainment = 7 THEN 'Graduate' WHEN educ_attainment = 8 THEN 'Post Graduate' WHEN educ_attainment = 9 THEN 'Vocational' ELSE 'None' END) AS educ_attainment, "
                                                          + "(CASE WHEN employment_status = 1 THEN 'Employed' WHEN employment_status = 2 THEN 'Unemployed' WHEN employment_status = 3 THEN 'Displaced Worker' WHEN employment_status = 4 THEN 'Resigned' WHEN employment_status = 5 THEN 'Retired' ELSE 'Returning Overseas Filipino Worker' END) AS employment_status, "
                                                          + "(CASE WHEN nature_of_employer = 2 THEN 'Government' ELSE 'Private' END) AS nature_of_employer, "
                                                          + "(CASE WHEN type_of_employment = 1 THEN 'Contractual' WHEN type_of_employment = 2 THEN 'Permanent' WHEN type_of_employment = 3 THEN 'Self-Employed' ELSE 'Seasonal' END) AS type_of_employment, "
                                                          + type_of_skill
                                                          + "(CASE WHEN status_pwd = 0 THEN 'Expired' ELSE 'Active' END) as status_pwd, "
                                                          + "CONCAT(address_house_no_street, ', ', address_barangay, ', ', address_municipality, ', ', address_province) as address,"
                                                          + "district_name "
                                                          + "FROM p_dao.pwd LEFT JOIN p_dao.disability ON (disability.disability_id = pwd.disability_id) LEFT JOIN p_dao.pwd_district ON (pwd.district_id = pwd_district.district_id) WHERE pwd.isArchived = 0 AND pwd_id = " + current_id, conn);
                MySqlDataAdapter main_data = new MySqlDataAdapter(comm);
                main_data.Fill(main);
                Console.WriteLine("[PWD] - [CONNECTIONS_PWD]   > { PWD_VIEW_PROFILE_MAIN_DATA_LOADED }");
                comm = new MySqlCommand("SELECT sss_no, "
                                             + "gsis_no, "
                                             + "phealth_no, "
                                             + "(CASE WHEN phealth_status = 1 THEN 'PhilHealth Member' ELSE 'PhilHealth Member Dependent' END) AS phealth_status, "
                                             + "organization_aff, "
                                             + "contact_person, "
                                             + "office_address, "
                                             + "tel_no, "
                                             + "name_of_reporting_unit, "
                                             + "CONCAT(UCASE(accomplished_by_ln), ', ', UCASE(accomplished_by_fn), ' ', accomplished_by_mn) AS accomplished_by "
                                             + "FROM pwd_otherinfo WHERE pwd_id = " + current_id, conn);
                MySqlDataAdapter other_data = new MySqlDataAdapter(comm);
                other_data.Fill(other_info);
                Console.WriteLine("[PWD] - [CONNECTIONS_PWD]   > { PWD_VIEW_PROFILE_OTHER_DATA_LOADED }");
                comm = new MySqlCommand("SELECT CONCAT(UCASE(fatherln), ', ', UCASE(fatherfn), ' ', fathermn) AS father, "
                                             + "CONCAT(UCASE(motherln), ', ', UCASE(motherfn), ' ', mothermn) AS mother, "
                                             + "CONCAT(UCASE(guardianln), ', ', UCASE (guardianfn), ' ', guardianmn) AS guardian "
                                             + "FROM parental_info WHERE pwd_id = " + current_id, conn);
                MySqlDataAdapter parent_data = new MySqlDataAdapter(comm);
                parent_data.Fill(parental_info);
                Console.WriteLine("[PWD] - [CONNECTIONS_PWD]   > { PWD_VIEW_PROFILE_PARENTAL_DATA_LOADED }");

                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("--->>" + e.Message + "<<---");
                MessageBox.Show("[ERROR_MAIN_OTHER_PARENTAL_DATA_LOAD]"); //error
            }
        }

        #endregion

        #region ADD-MODE
        public bool pwd_check_registration_has_duplicate(string registration_no, string original_registration_no) 
        {
            bool has_duplicate = false;
            if (registration_no != "" )
            {
                Console.WriteLine("[PWD] - [CONNECTIONS_PWD]   > { CHECK_REGISTRATION_HAS_DUPLICATE }");
                
                if (registration_no != original_registration_no)
                {
                    try
                    {
                        conn.Open();
                        MySqlCommand comm = new MySqlCommand("SELECT COUNT(*) FROM p_dao.pwd WHERE registration_no = " + registration_no, conn);
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
                        conn.Close();
                        Console.WriteLine("--->>" + e.Message + "<<---");
                        MessageBox.Show("[ERROR_REGISTRATION_NO_HAS_DUPLICATE]");
                    }
                }
            }
            
            return has_duplicate;
        }

        public void populate_cbox(ComboBox disability_type, ComboBox district_type)
        {
            Console.WriteLine("[PWD] - [CONNECTIONS_PWD]   > { DISABILITY_DISTRICT_COMBOBOX_LOAD }");
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("SELECT * FROM p_dao.disability", conn);
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

                comm = new MySqlCommand("SELECT * FROM p_dao.pwd_district", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                count = set.Rows.Count;
                if(count == 0)
                {
                    MessageBox.Show("No regions added.");
                } else
                {
                    foreach (DataRow data in set.Rows)
                    {
                        district_type.Items.Add(data["district_name"].ToString());
                    }
                }

                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("--->>" + e.Message + "<<---");
                MessageBox.Show("[ERROR_DISABILITY_DISTRICT_COMBOBOX]"); //error
            }
        }

        public bool pwd_add_profile(string main_data, string other_data, string parental_data)
        {
            bool success = false;
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
                success = true;
                Console.WriteLine("[PWD] - [CONNECTIONS_PWD]   > { PWD_ADD_PROFILE_DATA }");
            }
            catch (Exception e)
            {
                success = false;
                conn.Close();
                Console.WriteLine("--->>" + e.Message + "<<---");
                MessageBox.Show("[ERROR_PWD_ADD]");
            }
            return success;
        }

        #endregion

        #region ARCHIVE-MODE
        public void archive_profile(int current_id)
        {
            Console.WriteLine("[PWD] - [CONNECTIONS_PWD]   > { ARCHIVE_PROFILE }");
            conn.Open();

            comm = new MySqlCommand("UPDATE p_dao.pwd SET isArchived = 1 WHERE pwd_id = " + current_id, conn);
            comm.ExecuteNonQuery();

            conn.Close();
        }
        #endregion

        #region EDIT-MODE

        public void pwd_update_profile_data(int current_id, DataTable main, DataTable other_info, DataTable parental_info)
        {
            Console.WriteLine("[PWD] - [CONNECTIONS_PWD]   > { PWD_UPDATE_PROFILE_DATA }");
            try
            {
                conn.Open();
                comm = new MySqlCommand("SELECT * FROM p_dao.pwd WHERE isArchived = 0 AND pwd.pwd_id = " + current_id, conn);
                MySqlDataAdapter main_data = new MySqlDataAdapter(comm);
                main_data.Fill(main);
                comm = new MySqlCommand("SELECT * FROM pwd_otherinfo WHERE pwd_id = " + current_id, conn);
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
                Console.WriteLine("--->>" + e.Message + "<<---");
                MessageBox.Show("[ERROR_UPDATE_PROFILE_DATA]"); //error
            }
        }

        public bool pwd_update_profile(string main_data, string other_data, string parental_data)
        {
            Console.WriteLine("[PWD] - [CONNECTIONS_PWD]   > { PWD_UPDATE_PROFILE_ }");
            bool success = false;
            try
            {
                conn.Open();
                comm = new MySqlCommand(main_data, conn);
                Console.WriteLine("[PWD] - [CONNECTIONS_PWD]   > { PWD_UPDATE_PROFILE_MAIN_DATA }");
                comm.ExecuteNonQuery();
                comm = new MySqlCommand(other_data, conn);
                Console.WriteLine("[PWD] - [CONNECTIONS_PWD]   > { PWD_UPDATE_PROFILE_OTHER_DATA }");
                comm.ExecuteNonQuery();
                comm = new MySqlCommand(parental_data, conn);
                Console.WriteLine("[PWD] - [CONNECTIONS_PWD]   > { PWD_UPDATE_PROFILE_PARENTAL_DATA }");
                comm.ExecuteNonQuery();
                conn.Close();
                success = true;
            }
            catch (Exception e)
            {
                success = false;
                conn.Close();
                Console.WriteLine("--->>" + e.Message + "<<---");
                MessageBox.Show("[ERROR_PWD_UPDATE_PROFILE]");
            }

            return success;
        }

        #endregion

        #region FILTER-MODE

        public void pwd_search(DataGridView pwd_grid, TextBox pwd_searchbox)
        {
            conn.Open();
            string regis;
            string lastname;
            string firstname;
            string middlename;
            string app_date;
            //string 
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
                }
                else
                {
                    regis += ("registration_no LIKE '%" + word + "%' OR ");
                    lastname += ("lastname LIKE '%" + word + "%' OR ");
                    firstname += ("firstname LIKE '%" + word + "%' OR ");
                    middlename += ("middlename LIKE '%" + word + "%' OR ");
                    app_date += ("application_date LIKE '%" + word + "%' OR ");
                }
            }
            /*
            string word = pwd_searchbox.Text;
            regis += ("registration_no LIKE '%" + word + "%' ");
            lastname += ("lastname LIKE '%" + word + "%' ");
            firstname += ("firstname LIKE '%" + word + "%' ");
            middlename += ("middlename LIKE '%" + word + "%' ");
            app_date += ("application_date LIKE '%" + word + "%' ");*/

            MySqlCommand comm = new MySqlCommand("SELECT pwd_id, "
                                                      + "registration_no, "
                                                      + "CONCAT(lastname,', ', firstname, ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS fullname, "
                                                      + "lastname, "
                                                      + "firstname, "
                                                      + "middlename, "
                                                      + "(CASE WHEN sex = 0 THEN 'Male' ELSE 'Female' END) as sex, "
                                                      + "DATE_FORMAT(NOW(), '%Y') - DATE_FORMAT(birthdate, '%Y') - (DATE_FORMAT(NOW(), '00-%m-%d') < DATE_FORMAT(birthdate, '00-%m-%d')) AS age, "
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

        public bool two = false;

        public void filter_gender (string gender, DataGridView pwd_grid)
        {
            (pwd_grid.DataSource as DataTable).DefaultView.RowFilter = string.Format("sex LIKE '{0}%' ", gender);
        }

        public void filter_status (string status, DataGridView pwd_grid)
        {
            (pwd_grid.DataSource as DataTable).DefaultView.RowFilter = string.Format("CONVERT(status_pwd, System.String) Like '%{0}%' ", status);

        }

        public void filter_status_gender (string status, string gender, DataGridView pwd_grid)
        {
            (pwd_grid.DataSource as DataTable).DefaultView.RowFilter = string.Format("sex LIKE '{0}%' AND CONVERT(status_pwd, System.String) LIKE '{1}%' ", gender, status);
        }
        #endregion

        #region EMP_LOG

        public void emp_log_add(string uname, int pwd_id, string action)
        {
            try
            {
                conn.Open();
                if (action == "add")
                {
                    comm = new MySqlCommand("INSERT INTO p_dao.pwd_emp_log(pwd_id, recent_emp_id, date_updated) VALUES (LAST_INSERT_ID(), (SELECT employee_id FROM p_dao.employee WHERE username = '" + uname + "'), CURDATE())", conn);
                }
                else
                {
                    comm = new MySqlCommand("UPDATE p_dao.pwd_emp_log SET pwd_id = " + pwd_id + ", recent_emp_id = (SELECT employee_id FROM p_dao.employee WHERE username = '" + uname + "'), date_updated = CURDATE())", conn);
                    comm.ExecuteNonQuery();
                }
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                MessageBox.Show(e.Message);
            }
        }

        #endregion

        public void get_pwd_list_device(DataGridView b)
        {

        }
    }
}
