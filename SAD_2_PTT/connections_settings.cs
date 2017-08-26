using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;

namespace SAD_2_PTT
{
    class connections_settings
    {
        public MySqlConnection conn;
        public main_form reference_to_main { get; set; }

        public connections_settings()
        {
            conn = new MySqlConnection("Server=localhost;Database=p_dao;Uid=root;Pwd=root");
        }

        #region DataLoad
        public void employee_list(DataGridView employee_grid)
        {
            try
            {
                string status = "(CASE WHEN status_id = 0 THEN 'Active' ELSE 'Inactive' END) AS status_id";
                conn.Open();
                MySqlCommand comm = new MySqlCommand("SELECT employee_id, "
                                                          + "CONCAT(lastname,', ', firstname, ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS fullname, "
                                                          + "address,"
                                                          + " position, "
                                                          + "contact_no, "
                                                          + "birthdate, "
                                                          + status
                                                          + "username, "
                                                          + "password "
                                                          + "FROM p_dao.employee", conn);
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

        public void settings_user_grid(DataGridView user_grid)
        {
            try
            {
                conn.Open();
                MySqlCommand com = new MySqlCommand("SELECT username, (CASE WHEN status_id = 0 THEN 'Active' ELSE 'Inactive' END) AS status FROM p_dao.employee", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                user_grid.DataSource = dt;
                user_grid.Columns[0].Width = 300;
                user_grid.Columns["status"].Visible = false;

                conn.Close();

                foreach (DataGridViewRow row in user_grid.Rows)
                {
                    if (row.Cells[1].Value.ToString().Contains("Inactive"))
                        row.DefaultCellStyle.BackColor = Color.Salmon;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in settings_user_grid() : " + ex);
            }
        }

        public void settings_info_grid(DataGridView info_grid)
        {
            info_grid.Size = new System.Drawing.Size(764, 447);

            try
            {
                conn.Open();
                MySqlCommand com = new MySqlCommand("SELECT CONCAT(lastname,', ', firstname, ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS fullname, address, position, contact_no, birthdate, (CASE WHEN status_id = 0 THEN 'Active' ELSE 'Inactive' END) AS status, password, username, employee_id, lastname, firstname, middlename FROM p_dao.employee ", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                info_grid.DataSource = dt;
                info_grid.Columns["password"].Visible = false;
                info_grid.Columns["username"].Visible = false;
                info_grid.Columns["employee_id"].Visible = false;
                info_grid.Columns["lastname"].Visible = false;
                info_grid.Columns["middlename"].Visible = false;
                info_grid.Columns["firstname"].Visible = false;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in settings_info_grid() : " + ex);
            }
        }
        #endregion

        #region Add | Edit 
        public void Add(string values)
        {
            try
            {
                conn.Open();
                MySqlCommand com = new MySqlCommand("INSERT INTO employee(lastname, firstname, middlename, address, position, contact_no, birthdate, status_id, username, password) "
                                                     + values, conn);
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
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    comm.ExecuteNonQuery();
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
        #endregion

        //don't mind muna [archive]
        // if status is red then inactive [grid]
        //Manage Accounts | panel_users
        // no header for username [grid_uname]
        //info users right side [grid]
    }
}
