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
        public connections_pwd()
        {
            conn = new MySqlConnection("Server=localhost;Database=p_dao;Uid=root;Pwd=root");
        }

        public void pwd_grid_list(DataGridView pwd_grid)
        {
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("SELECT pwd_id, "
                                                          + "registration_no, "
                                                          + "CONCAT(lastname,', ', firstname, ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS fullname, "
                                                          + "(CASE WHEN sex = 0 THEN 'M' ELSE 'F' END) as sex, "
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
                                                          + "FORMAT(birthdate,'YYYY-MM-DD') AS birthdate, "
                                                          + "tel_no, "
                                                          + "mobile_no, "
                                                          + "email_add, "
                                                          + "REPLACE(accomplished_by, '|', '') AS accomplished_by,"
                                                          + "(CASE WHEN educ_attainment = 1 THEN 'Elementary' WHEN educ_attainment = 2 THEN 'Elementary Undergraduate' WHEN educ_attainment = 3 THEN 'High School' WHEN educ_attainment = 4 THEN 'High School Undergraduate' WHEN educ_attainment = 5 THEN 'College' WHEN educ_attainment = 6 THEN 'College Undergraduate' WHEN educ_attainment = 7 THEN 'Graduate' WHEN educ_attainment = 8 THEN 'Post Graduate' WHEN educ_attainment = 9 THEN 'Vocational' ELSE 'None' END) AS educ_attainment, "
                                                          + "(CASE WHEN employment_status = 1 THEN 'Employed' WHEN employment_status = 2 THEN 'Unemployed' WHEN employment_status = 3 THEN 'Displaced Worker' WHEN employment_status = 4 THEN 'Resigned' WHEN employment_status = 5 THEN 'Retired' ELSE 'Returning Overseas Filipino Worker' END) AS employment_status, "
                                                          + "(CASE WHEN nature_of_employer = 2 THEN 'Government' ELSE 'Private' END) AS nature_of_employer, "
                                                          + "(CASE WHEN type_of_employment = 1 THEN 'Contractual' WHEN type_of_employment = 2 THEN 'Permanent' WHEN type_of_employment = 3 THEN 'Self-Employed' ELSE 'Seasonal' END) AS type_of_employment, "
                                                          + type_of_skill
                                                          + "(CASE WHEN status_pwd = 0 THEN 'Expired' ELSE 'Active' END) as status_pwd, "
                                                          + "REPLACE(address, '|', '') AS address "
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

        public bool pwd_check_registration_no_duplicate(int registration_no) 
        {
            bool has_duplicate = false;
            try
            {
                conn.Open();

                MySqlCommand comm = new MySqlCommand("SELECT COUNT(*) FROM p_dao.pwd WHERE pwd_id = " + registration_no, conn);
                MySqlDataAdapter get = new MySqlDataAdapter(comm);
                DataTable set = new DataTable();
                get.Fill(set);
                int count = int.Parse(set.Rows[0]["COUNT(*)"].ToString());
                if (count == 0)
                    has_duplicate = false;
                else
                    has_duplicate = true;
                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
                MessageBox.Show(e.Message);
            }
            return has_duplicate;
        }

        public void populate_cbox(ComboBox disability_type, ComboBox district_type)
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
                MessageBox.Show(e.Message); //error
            }
        }
    }
}
