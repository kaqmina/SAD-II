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
        shadow shadow_;
        system_notification system_notify;
        public string current_user;

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

            lbl_name.Text = "Hi, " + current_user.ToUpper() + ".";

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

        #region ON-LOAD
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
            cell_color();
        }

        #endregion

        #region PWD-GRID
        int current_pwd_id = 0;
        int current_grid_index = 1;

        private void pwd_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                //nothing
            }
            else
            {
                btn_pwd_viewmore.Enabled = true;
                btn_pwd_edit.Enabled = true;
                btn_archive.Enabled = true;
                if (pwd_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.Salmon)
                {
                    btn_renew.Enabled = true;
                    btn_archive.Enabled = true;
                }
                else
                {
                    btn_renew.Enabled = false;
                    btn_archive.Enabled = false;
                }
                current_pwd_id = int.Parse(pwd_grid.Rows[e.RowIndex].Cells["pwd_id"].Value.ToString());
                current_grid_index = e.RowIndex;
            }
        }

        public void cell_color()
        {
            int count = pwd_grid.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                if (pwd_grid.Rows[i].Cells["status_pwd"].Value.ToString() == "0") //inactive = 0
                {
                    pwd_grid.Rows[i].DefaultCellStyle.BackColor = Color.Salmon;
                }
            }
        }

        private void btn_pwd_refresh_Click(object sender, EventArgs e)
        {
            load_pwd();
            pwd_searchbox.Clear();
        }

        private void pwd_grid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cell_color();
        }

        #endregion

        #region PWD-VIEW-MODE
        private void btn_pwd_viewmore_Click(object sender, EventArgs e)
        {
            int loc_x = this.Location.X + 71;
            int loc_y = this.Location.Y + 28;

            pwd_view pwd_view_form = new pwd_view();
            side_tab.Enabled = false;
            dboard_head.Enabled = false;
            pwd_view_form.reference_to_main = this;
            pwd_view_form.Location = new Point(loc_x, loc_y);
            pwd_view_form.current_pwd = current_pwd_id;
            pwd_view_form.ShowDialog();
            side_tab.Enabled = true;
            dboard_head.Enabled = true;
        }

        #endregion

        #region PWD-ADD-MODE
        public bool success = false;

        private void btn_pwd_add_Click(object sender, EventArgs e)
        {
            int loc_x = this.Location.X + 71;
            int loc_y = this.Location.Y + 28;

            pwd_add pwd_fill_up_form = new pwd_add();
            side_tab.Enabled = false;
            dboard_head.Enabled = false;
            pwd_fill_up_form.reference_to_main = this;
            pwd_fill_up_form.Location = new Point(loc_x, loc_y);
            pwd_fill_up_form.ShowDialog();
            side_tab.Enabled = true;
            dboard_head.Enabled = true;
            if (success == true)
            {
                added_successfully();
            }
        }

        #endregion

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

        #region NOTIFICATIONS-[MODIFICATIONS ONLY]
        public void added_successfully()
        {
            //827, 531
            system_notify = new system_notification();
            system_notify.Location = new Point(this.Location.X + 827, this.Location.Y + 531);
            system_notify.message.Text = "Successfully added new PWD Profile!";
            system_notify.Show();
            notification.Start();
        }

        bool close = false;
        int stay = 100;

        private void notification_Tick(object sender, EventArgs e)
        {
            if (system_notify.Opacity < 1 && close == false)
            {
                system_notify.Opacity += 0.1;
            } else
            {
                close = true;
            }
            if (close == true)
            {
                if(stay != 0)
                {
                    stay--;
                } else
                {
                    if(system_notify.Opacity > 0)
                    {
                        system_notify.Opacity -= 0.1;
                    } else
                    {
                        system_notify.Close();
                        notification.Stop();
                    }
                }
            }
        }

        #endregion

        private void btn_pwd_edit_Click(object sender, EventArgs e)
        {
            int loc_x = this.Location.X + 71;
            int loc_y = this.Location.Y + 50;

            /*pwd_add edit = new pwd_add();
            edit.reference_to_main = this;
            edit.Location = new Point(loc_x, loc_y);
            edit.pwd_update_id = current_pwd_id;
            edit.paste_data();
            edit.btn_add_edit.Text = "UPDATE";
            edit.ShowDialog();*/
        }

        private void btn_archive_Click(object sender, EventArgs e)
        {
            pwd_archive show_prompt = new pwd_archive();
            shadow_ = new shadow();
            shadow_.Location = new Point(this.Location.X, this.Location.Y);
            show_prompt.current_id = current_pwd_id;
            show_prompt.reference_to_main = this;
            show_prompt.regis_no.Text = "Registration#: " + pwd_grid.Rows[current_grid_index].Cells["registration_no"].Value.ToString();
            show_prompt.name.Text = "Name: " + pwd_grid.Rows[current_grid_index].Cells["fullname"].Value.ToString();
            show_prompt.app_date.Text = "Application_date: " + pwd_grid.Rows[current_grid_index].Cells["application_date"].Value.ToString();
            show_prompt.prompt_title.Text = "Archive";
            show_prompt.action.Text = "The following profile will be archived:";
            shadow_.Show();
            show_prompt.ShowDialog();
            shadow_.Close();
            btn_renew.Enabled = false;
            btn_archive.Enabled = false;
        }
    }
}
