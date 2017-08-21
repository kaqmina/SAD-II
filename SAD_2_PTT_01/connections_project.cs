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

        public void project_grid_list(DataGridView projects_grid)
        {
            Console.WriteLine("[PJT] - [CONNECTIONS_PROJECT] > { [PROJECTS_GRID_LOADED] }");
            try
            {
                conn.Open();

                comm = new MySqlCommand("SELECT project_id, project_title, start_time, end_time, date_proposed FROM p_dao.project WHERE isArchived = 0", conn);
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
    }
}
