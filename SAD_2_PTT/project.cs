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
    class project
    {
        connections_project conn = new connections_project();

        public void project_grid(DataGridView proj_grid)
        {
            conn.project_grid_list(proj_grid);
            project_format(proj_grid);
        }

        public void project_format(DataGridView proj_grid)
        {
            proj_grid.Columns["project_id"].Visible = false;
            proj_grid.Columns["items_id"].Visible = false;
            proj_grid.Columns["progress_id"].Visible = false;
            proj_grid.Columns["project_desc"].Visible = false;
            proj_grid.Columns["budget"].Visible = false;
            proj_grid.Columns["budget_desc"].Visible = false;
            proj_grid.Columns["start_time"].HeaderText = "Start Time";
            proj_grid.Columns["end_time"].HeaderText = "End Time";
            proj_grid.Columns["date_proposed"].HeaderText = "Date Proposed";
            proj_grid.Columns["approved_by"].HeaderText = "Approved by:";
            proj_grid.Columns["event_held"].HeaderText = "Venue";
            proj_grid.Columns["project_title"].HeaderText = "Title";
            proj_grid.Columns["username"].HeaderText = "Added by: ";
        }
    }
}
