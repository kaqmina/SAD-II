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
    }
}
