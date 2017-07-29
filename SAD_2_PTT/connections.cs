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

        public void pwd_grid_list(DataGridView pwd_grid)
        {
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("SELECT pwd_id, registration_no, CONCAT(lastname,', ', firstname, ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS fullname, (CASE WHEN sex = 0 THEN 'Male' ELSE 'Female' END) as sex, disability_id, blood_type, (CASE WHEN civil_status = 1 THEN 'Single' WHEN civil_status = 2 THEN 'Married' WHEN civil_status = 3 THEN 'Widow/er' WHEN civil_status = 4 THEN 'Separated' ELSE 'Co-Habitation' END) AS civil_status, application_date, added_date FROM pwd WHERE isArchived = 0", conn);
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
                } else
                {
                    foreach (DataRow data in set.Rows)
                    {
                        disability_type.Items.Add(data["disability_type"].ToString());
                    }
                }
                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
                MessageBox.Show(e.Message); //error
            }
        }

        #region PWD ADD PA - 11
        public void pwd_add_profile(string query, string variable)
        {
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand((query + variable), conn);
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
        
        public void pwd_view_profile (int current_id, DataTable set)
        {
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("SELECT pwd_id, registration_no, CONCAT(UCASE(lastname), ', ', firstname, ' ', middlename) AS fullname, (CASE WHEN sex = 0 THEN 'Male' ELSE 'Female' END) as sex, disability_id, blood_type, (CASE WHEN civil_status = 1 THEN 'Single' WHEN civil_status = 2 THEN 'Married' WHEN civil_status = 3 THEN 'Widow/er' WHEN civil_status = 4 THEN 'Separated' ELSE 'Co-Habitation' END) AS civil_status, application_date, added_date, end_date, nationality, birthdate, tel_no, mobile_no, email_add, accomplished_by, educ_attainment, employment_status, nature_of_employer, type_of_skill, (CASE WHEN status_pwd = 0 THEN 'Inactive/Expired' ELSE 'Active' END) as status_pwd, address FROM pwd WHERE isArchived = 0 AND pwd_id = " + current_id, conn);
                MySqlDataAdapter get = new MySqlDataAdapter(comm);
                
                get.Fill(set);
                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
                MessageBox.Show(e.Message); //error
            }
        }

        public void pwd_employee_list(DataGridView employee_grid)
        {
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("SELECT employee_id, CONCAT(lastname,', ', firstname, ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS fullname, address, position, contact_no, birthdate, status_id, username, password FROM employee", conn);
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
    }
}
