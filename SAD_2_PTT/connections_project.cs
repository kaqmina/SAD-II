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
    class connections_project
    {
        public MySqlConnection conn;
        public connections_project()
        {
            conn = new MySqlConnection("Server=localhost;Database=p_dao;Uid=root;Pwd=root");
        }

        public void project_grid_list(DataGridView proj_grid)
        {
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("SELECT project_id, "
                                                          + "items_id, "
                                                          + "progress_id, "
                                                          + "project_title, "
                                                          + "project_desc, "
                                                          + "start_time, "
                                                          + "end_time, "
                                                          + "date_proposed, "
                                                          + "approved_by, "
                                                          + "event_held, "
                                                          + "budget, "
                                                          + "budget_desc, "
                                                          + "username "
                                                          + "FROM p_dao.project LEFT JOIN p_dao.employee ON (project.employee_id = employee.employee_id) WHERE isArchived = 0", conn);
                MySqlDataAdapter get = new MySqlDataAdapter(comm);
                DataTable set = new DataTable();
                get.Fill(set);


                proj_grid.DataSource = set;
                if (set.Rows.Count == 0)
                {
                    MessageBox.Show("No Projects added.");
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
