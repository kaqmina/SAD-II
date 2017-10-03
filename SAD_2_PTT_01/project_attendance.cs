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
        system_functions sys_func = new system_functions();
        public main_form reference_to_main { get; set; }
        public string project_id = "0";
        public string current_project_persons_id = "0";
        public string title = "";
        public string attendance;
        int current_index = 0;

        private void projects_grid_persons_involved_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                sys_func.btn_inactive(btn_toggle);
            }
            else
            {
                if (has_data == false)
                {
                    sys_func.btn_inactive(btn_toggle);
                } else
                {
                    sys_func.btn_active(btn_toggle);
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
                    current_index = e.RowIndex;
                }
            }
        }
        bool has_data = false;

        public void load_persons_involved()
        {
            has_data = conn_proj.persons_involved(project_id, projects_grid_persons_involved);
            lbl_title.Text = title;


            projects_grid_persons_involved.Columns["no"].HeaderText = "No.";
            projects_grid_persons_involved.Columns["id_no"].HeaderText = "ID No.";
            projects_grid_persons_involved.Columns["fullname"].HeaderText = "Fullname";
            projects_grid_persons_involved.Columns["disability_type"].HeaderText = "Disability";
            projects_grid_persons_involved.Columns["attendance"].HeaderText = "Attendance";
            projects_grid_persons_involved.Columns["display_text"].HeaderText = "Results";

            if (has_data == false)
            {
                projects_grid_persons_involved.Columns["no"].Visible = false;
                projects_grid_persons_involved.Columns["id_no"].Visible = false;
                projects_grid_persons_involved.Columns["fullname"].Visible = false;
                projects_grid_persons_involved.Columns["disability_type"].Visible = false;
                projects_grid_persons_involved.Columns["attendance"].Visible = false;
                projects_grid_persons_involved.Columns["display_text"].Visible = true;
            } else
            {
                projects_grid_persons_involved.Columns["no"].Visible = true;
                projects_grid_persons_involved.Columns["id_no"].Visible = true;
                projects_grid_persons_involved.Columns["fullname"].Visible = true;
                projects_grid_persons_involved.Columns["disability_type"].Visible = true;
                projects_grid_persons_involved.Columns["attendance"].Visible = true;
                projects_grid_persons_involved.Columns["display_text"].Visible = false;
            }

            projects_grid_persons_involved.Columns["personsIN_id"].Visible = false;

            projects_grid_persons_involved.ClearSelection();
        }

        private void project_attendance_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            load_persons_involved();
            startup_opacity.Start();
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

        private void startup_opacity_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
                this.Opacity += 0.1;
            else
                startup_opacity.Stop();
        }

        private void exit_opacity_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                this.Opacity -= 0.1;
            }
            else
            {
                exit_opacity.Stop();
            }
        }

        private void project_attendance_FormClosing(object sender, FormClosingEventArgs e)
        {
            exit_opacity.Start();
        }
    }
}
