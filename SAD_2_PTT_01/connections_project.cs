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
    class connections_project
    {
        public MySqlConnection conn;
        MySqlCommand comm;
        MySqlDataAdapter get;
        DataTable set;
        public connections_project()
        {
            conn = new MySqlConnection("Server=localhost;Database=p_dao;Uid=root;Pwd=root");
        }

        #region GRID-MAINFORM

        public void project_grid_list(DataGridView projects_grid)
        {
            Console.WriteLine("[PJT] - [CONNECTIONS_PROJECT] > { [PROJECTS_GRID_LOADED] }");
            try
            {
                conn.Open();

                comm = new MySqlCommand("SELECT * FROM p_dao.project LEFT JOIN p_dao.project_progress ON project.project_id = project_progress.project_id WHERE project.isArchived = 0", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                projects_grid.DataSource = set;

                conn.Close();
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
                MessageBox.Show("[ERROR_PROJECT_GRID]");
            }
        }

        public void project_data_load (int project_id, DataTable main, DataTable item)
        {
            Console.WriteLine("[PJT] - [CONNECTIONS_PROJECT] > { [PROJECTS_DATA_LOAD] }");
            try
            {
                conn.Open();

                comm = new MySqlCommand("SELECT * FROM p_dao.project WHERE project_id = " + project_id, conn);
                MySqlDataAdapter main_data = new MySqlDataAdapter(comm);
                main_data = new MySqlDataAdapter(comm);
                main_data.Fill(main);

                comm = new MySqlCommand("SELECT * FROM p_dao.project_items WHERE project_id = " + project_id, conn);
                MySqlDataAdapter item_data = new MySqlDataAdapter(comm);
                item_data.Fill(item);

                conn.Close();
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
                MessageBox.Show("[ERROR_PROJECT_DATA_LOAD]");
            }
        }

        #endregion

        #region FILTER-MODE

        public void filter_status(string status, DataGridView projects_grid)
        {
            (projects_grid.DataSource as DataTable).DefaultView.RowFilter = string.Format("CONVERT(progress_type, System.String) Like '%{0}%' ", status);

        }

        #endregion

        public void persons_involved(int project_id, DataTable persons_grid)
        {
            try
            {
                conn.Open();

                comm = new MySqlCommand("SELECT registration_no, "
                                             + "personsIN_id, "
                                             + "CONCAT(UCASE(lastname), ', ', firstname, ' ', middlename) AS fullname, "
                                             + "disability_type, "
                                             + "(CASE WHEN attendance = 0 THEN 'Absent' WHEN attendance = 1 THEN 'Present' END) as attendance "
                                             + "FROM p_dao.project_persons LEFT JOIN p_dao.pwd ON (project_persons.pwd_id = pwd.pwd_id) "
                                             + "LEFT JOIN p_dao.disability ON (pwd.disability_id = disability.disability_id) WHERE project_id = " + project_id, conn);
                get = new MySqlDataAdapter(comm);
                get.Fill(persons_grid);

                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
                MessageBox.Show(e.Message);
            }
        }

        public void persons_involved_attendance (string attendance, string persons_id)
        {
            try
            {
                conn.Open();

                comm = new MySqlCommand("UPDATE p_dao.project_persons SET attendance = " + attendance + " WHERE personsIN_id = " + persons_id, conn);
                comm.ExecuteNonQuery();

                conn.Close();
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("[ERROR_PERSONS_INVOLVED_ATTENDANCE]");
                conn.Close();
            }
        }

        public void persons_involved_add_search(string regis_no, ComboBox add_persons_involved_search)
        {
            try
            {
                conn.Open();

                comm = new MySqlCommand("SELECT registration_no, "
                                             + "CONCAT(lastname,', ', firstname, ' ', UCASE(SUBSTRING(middlename,1,1)), SUBSTRING(middlename, 2)) AS fullname "
                                             + "FROM p_dao.pwd WHERE registration_no LIKE '%" + regis_no + "%' ", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                add_persons_involved_search.DataSource = set.DefaultView;

                conn.Close();
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("[ERROR_PERSONS_INVOLVED_ADD]");
                conn.Close();
            }
        }

        public void project_add_data(string query)
        {
            try
            {
                conn.Open();

                comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();

            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("[ERROR_ADD_PROJECTS]");
                conn.Close();
            }
        }
    }
}
