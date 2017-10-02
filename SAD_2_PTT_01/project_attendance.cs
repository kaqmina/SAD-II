using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAD_2_PTT_01
{
    public partial class project_attendance : Form
    {
        public project_attendance()
        {
            InitializeComponent();
        }
        connections_project conn_proj = new connections_project();

        public string project_id = "0";
        public string current_project_persons_id = "0";
        public string attendance;
        int current_index = 0;

        private void projects_grid_persons_involved_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                btn_toggle.Enabled = false;
            }
            else
            {
                current_project_persons_id = projects_grid_persons_involved.Rows[e.RowIndex].Cells["personsIN_id"].Value.ToString();
                attendance = projects_grid_persons_involved.Rows[e.RowIndex].Cells["attendance"].Value.ToString();
                if (attendance == "Present")
                {
                    btn_toggle.Text = "MARK AS ABSENT";
                }
                else if (attendance == "Absent")
                {
                    btn_toggle.Text = "MARK AS PRESENT";
                }
                btn_toggle.Enabled = true;
                current_index = e.RowIndex;
            }
        }

        public void load_persons_involved()
        {
            conn_proj.persons_involved(project_id, projects_grid_persons_involved);
            
            if (current_index >= 0)
            {
                btn_toggle.Enabled = true;
            }
            else
            {
                btn_toggle.Enabled = false;
            }

            projects_grid_persons_involved.Columns["no"].HeaderText = "No.";
            projects_grid_persons_involved.Columns["id_no"].HeaderText = "ID No.";
            projects_grid_persons_involved.Columns["fullname"].HeaderText = "Fullname";
            projects_grid_persons_involved.Columns["disability_type"].HeaderText = "Disability";
            projects_grid_persons_involved.Columns["attendance"].HeaderText = "Attendance";

            projects_grid_persons_involved.Columns["personsIN_id"].Visible = false;

            projects_grid_persons_involved.ClearSelection();
        }

        private void project_attendance_Load(object sender, EventArgs e)
        {
            load_persons_involved();
        }

        private void btn_toggle_Click(object sender, EventArgs e)
        {
            if (attendance == "Present")
            {
                conn_proj.persons_involved_attendance("0", current_project_persons_id.ToString());
                attendance = "Absent";
            }
            else if (attendance == "Absent")
            {
                conn_proj.persons_involved_attendance("1", current_project_persons_id.ToString());
                attendance = "Present";
            }
            load_persons_involved();
            projects_grid_persons_involved.Rows[current_index].Selected = true;
        }
    }
}
