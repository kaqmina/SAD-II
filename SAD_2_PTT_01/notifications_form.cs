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
    public partial class notifications_form : Form
    {
        public notifications_form()
        {
            InitializeComponent();
        }
        connections_notifications conn_noti = new connections_notifications();

        public main_form reference_to_main { get; set; }

        #region OPACITY
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
        #endregion

        bool has_projects = false;
        bool has_pwd = false;

        private void notifications_form_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            startup_opacity.Start();
            load_pwd();
            load_project();
        }

        public void load_pwd()
        {
            has_pwd = conn_noti.get_pwd_data(pwd_grid);
            pwd_format();
        }

        public void load_project()
        {
            has_projects = conn_noti.get_7_days_data(project_grid);
            project_format();
        }

        public void project_format()
        {
            project_grid.Columns["project_id"].Visible = false;
            project_grid.Columns["project_title"].HeaderText = "Title";
            project_grid.Columns["days_left"].HeaderText = "Days left to Start";
            project_grid.Columns["display_text"].HeaderText = "Results";

            if (has_projects == false)
            {
                project_grid.Columns["project_title"].Visible = false;
                project_grid.Columns["days_left"].Visible = false;
                project_grid.Columns["display_text"].Visible = true;
            } else
            {
                project_grid.Columns["project_title"].Visible = true;
                project_grid.Columns["days_left"].Visible = true;
                project_grid.Columns["display_text"].Visible = false;
            }
        }

        public void pwd_format()
        {
            pwd_grid.Columns["renewPWD_id"].Visible = false;
            pwd_grid.Columns["pwd_id"].Visible = false;
            pwd_grid.Columns["id_no"].HeaderText = "ID No.";
            pwd_grid.Columns["fullname"].HeaderText = "Name";
            pwd_grid.Columns["days_left"].HeaderText = "Days left to Expire";
            pwd_grid.Columns["display_text"].HeaderText = "Results";

            if (has_pwd == false)
            {
                pwd_grid.Columns["id_no"].Visible = false;
                pwd_grid.Columns["fullname"].Visible = false;
                pwd_grid.Columns["days_left"].Visible = false;
                pwd_grid.Columns["display_text"].Visible = true;
            } else
            {
                pwd_grid.Columns["id_no"].Visible = true;
                pwd_grid.Columns["fullname"].Visible = true;
                pwd_grid.Columns["days_left"].Visible = true;
                pwd_grid.Columns["display_text"].Visible = false;
            }
        }

        private void btn_resolve_Click(object sender, EventArgs e)
        {
            
        }
    }
}
