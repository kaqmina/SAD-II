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
    public partial class main_form : Form
    {
        public main_form()
        {
            InitializeComponent();
        }
        system_sidenav_active system_sidenav = new system_sidenav_active();
        connections_pwd conn_pwd = new connections_pwd();

        #region OnLoad
        private void main_form_Load(object sender, EventArgs e)
        {
            //<---[ System ]--->
            load_references();
            main_properties();
            grid_borderstyles();
            
            btn_current = btn_dashboard;
            system_sidenav.lbl_current_text("dashboard");
            btn_dashboard_Click(sender, e);

            this.Opacity = 0;
            startup_opacity.Start();
            //<---[ Modules ]--->
            load_pwd();
        }

        private void main_properties()
        {
            bool status = false;
            //visibility
            pnl_pwd.Visible = status;
            //pnl_notif_pp.Visible = status;
            pnl_devices.Visible = status;
            pnl_reports.Visible = status;
            pnl_projects.Visible = status;
            pnl_settings.Visible = status;

        }

        public void load_references()
        {
            system_sidenav.reference_to_main = this;
        }

        public void grid_borderstyles()
        {
            pwd_grid.BorderStyle = BorderStyle.None;
        }

        //Timer
        private void startup_opacity_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
                this.Opacity += 0.1;
            else
                startup_opacity.Stop();
        }
        #endregion

        #region PWD Module
        public void load_pwd()
        {
            conn_pwd.pwd_grid_list(pwd_grid);
            pwd_format();
        }

        public void pwd_format()
        {
            pwd_grid.Columns["pwd_id"].Visible = false;
            pwd_grid.Columns["status_pwd"].Visible = false;
            pwd_grid.Columns["registration_no"].HeaderText = "Registration #";
            pwd_grid.Columns["fullname"].HeaderText = "Full Name";
            pwd_grid.Columns["sex"].HeaderText = "Sex";
            pwd_grid.Columns["disability_type"].HeaderText = "Disability";
            pwd_grid.Columns["blood_type"].HeaderText = "Blood Type";
            pwd_grid.Columns["civil_status"].HeaderText = "Civil Status";
            pwd_grid.Columns["application_date"].HeaderText = "Date Applied";
            pwd_grid.Columns["added_date"].HeaderText = "Date Added";

            pwd_grid.Columns["registration_no"].Width = 90;
            pwd_grid.Columns["sex"].Width = 40;
            int count = pwd_grid.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                if (pwd_grid.Rows[i].Cells["status_pwd"].Value.ToString() == "0") //inactive = 0
                {
                    pwd_grid.Rows[i].DefaultCellStyle.BackColor = Color.Salmon;
                }
            }
        }
        #endregion

        #region Form_Head

        public Point mouseLocation;

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void dragdown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        public void dragmove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePos;
            }
        }

        private void dboard_head_MouseDown(object sender, MouseEventArgs e)
        {
            dragdown(sender, e);
        }

        private void dboard_head_MouseMove(object sender, MouseEventArgs e)
        {
            dragmove(sender, e);
        }

        #endregion

        #region Sidenav
        Button btn_current;

        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            system_sidenav.btn_method(btn_current, btn_dashboard);
            system_sidenav.pnl_deactivate(btn_current.Name);
            btn_current = btn_dashboard;
            system_sidenav.lbl_current_text("dashboard");
        }

        private void btn_pwd_Click(object sender, EventArgs e)
        {
            system_sidenav.btn_method(btn_current, btn_pwd);
            system_sidenav.pnl_deactivate(btn_current.Name);
            btn_current = btn_pwd;
            system_sidenav.lbl_current_text("pwd");
        }

        private void btn_device_Click(object sender, EventArgs e)
        {
            system_sidenav.btn_method(btn_current, btn_device);
            system_sidenav.pnl_deactivate(btn_current.Name);
            btn_current = btn_device;
            system_sidenav.lbl_current_text("devices");
        }

        private void btn_project_Click(object sender, EventArgs e)
        {
            system_sidenav.btn_method(btn_current, btn_project);
            system_sidenav.pnl_deactivate(btn_current.Name);
            btn_current = btn_project;
            system_sidenav.lbl_current_text("projects");
        }

        private void btn_reports_Click(object sender, EventArgs e)
        {
            system_sidenav.btn_method(btn_current, btn_reports);
            system_sidenav.pnl_deactivate(btn_current.Name);
            btn_current = btn_reports;
            system_sidenav.lbl_current_text("reports");
        }

        private void btn_settings_Click(object sender, EventArgs e)
        {
            system_sidenav.btn_method(btn_current, btn_settings);
            system_sidenav.pnl_deactivate(btn_current.Name);
            btn_current = btn_settings;
            system_sidenav.lbl_current_text("settings");
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        
    }
}
