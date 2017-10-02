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
        system_keypress key_ = new system_keypress();
        system_functions sys_func = new system_functions();
        connections_notifications conn_noti = new connections_notifications();
        connections_pwd conn_pwd = new connections_pwd();
        connections_project conn_proj = new connections_project();
        connections_devices conn_devi = new connections_devices();
        connections_disability conn_disa = new connections_disability();
        connections_user conn_user = new connections_user();
        connections_reports conn_rep = new connections_reports();
        disability disability_form;
        shadow shadow_;
        pwd_archive show_prompt;
        device_pending_req device_requests_form;
        device_pending_rec device_received_form;
        device_device_add dev_add;
        device_provider dev_pro;
        public system_notification system_notify;
        public string current_user;
        

        #region FORM-LOAD

        private void main_form_Load(object sender, EventArgs e)
        {
            conn_noti.reference_to_main = this;
            conn_noti.initial_rows_to_datatable();
            conn_noti.initial_font();
            notification_grid.ClearSelection();

            pnl_notif_pp.Visible = false;
            pnl_notif_pp.BringToFront();
            pnl_notif_pp.Size = new Size(299, 233);
            pnl_notif_pp.Location = new Point(838, 28);
            //<---[ System ]--->
            load_references();
            main_properties();
            grid_borderstyles();
            load_notifications();
            
            btn_current = btn_dashboard;
            system_sidenav.lbl_current_text("dashboard");
            btn_dashboard_Click(sender, e);

            lbl_name.Text = "Hi, " + current_user.ToUpper() + ".";

            this.Opacity = 0;
            startup_opacity.Start();
            //<---[ Modules ]--->
            load_pwd();

            load_projects();
            projects_default_data();

            load_device_requests();
            device_request_clear();
            device_pnl_request_new.BringToFront();
            load_handedout_data();
            device_handedout_clear_view();

            load_reports();
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
            conn_devi.reference_to_main = this;
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

        #region FORM-ACTIVATED
        bool pwd_archive = false;
        bool device_requests_ = false;
        bool device_received_ = false;
        bool device_device_add_ = false;
        bool device_provider_ = false;
        bool disability_form_ = false;

        bool notification_data_ = false; //independent

        private void main_form_Activated(object sender, EventArgs e)
        {
            if (pwd_archive == true)
            {
                this.BringToFront();
                show_prompt.BringToFront();
            }
            else if (device_requests_ == true)
            {
                this.BringToFront();
                device_requests_form.BringToFront();
            }
            else if (device_received_ == true)
            {
                this.BringToFront();
                device_received_form.BringToFront();
            }
            else if (device_device_add_ == true)
            {
                this.BringToFront();
                dev_add.BringToFront();
            }
            else if (device_provider_ == true)
            {
                this.BringToFront();
                dev_pro.BringToFront();
            } else if (disability_form_ == true)
            {
                this.BringToFront();
                disability_form.BringToFront();
            }

            if (notification_data_ == true)
            {
                system_notify.BringToFront();
            }
        }

        #endregion

        #region PWD Module

        #region ON-LOAD
        bool pwd_has_pwd = false;

        public void load_pwd()
        {
            pwd_has_pwd = conn_pwd.pwd_grid_list(pwd_grid);
            pwd_grid.ClearSelection();
            pwd_format();

            pwd_load_row_count();
            if (pwd_has_pwd == false)
            {
                sys_func.btn_inactive(btn_pwd_edit);
                sys_func.btn_inactive(btn_pwd_viewmore);
                sys_func.btn_inactive(btn_archive);
                sys_func.btn_inactive(btn_renew);
            }
        }

        public void pwd_load_row_count()
        {
            if (pwd_has_pwd == false)
            {
                pwd_grid_row_count.Text = "0";
            } else
            {
                pwd_grid_row_count.Text = pwd_grid.Rows.Count.ToString();
            }
        }

        public void pwd_format()
        {
            if (pwd_has_pwd == false)
            {
                pwd_grid.DefaultCellStyle.ForeColor = Color.Gray;
                pwd_grid.DefaultCellStyle.SelectionForeColor = Color.Gray;
                pwd_grid.DefaultCellStyle.SelectionBackColor = Color.White;
                pwd_grid.Columns["no"].Visible = false;
                pwd_grid.Columns["pwd_id"].Visible = false;
                pwd_grid.Columns["id_no"].Visible = false;
                pwd_grid.Columns["fullname"].Visible = false;
                pwd_grid.Columns["gender"].Visible = false;
                pwd_grid.Columns["age"].Visible = false;
                pwd_grid.Columns["disability_type"].Visible = false;
                pwd_grid.Columns["educ_attainment_type"].Visible = false;
                pwd_grid.Columns["application_date"].Visible = false;
                pwd_grid.Columns["district_name"].Visible = false;
                pwd_grid.Columns["status_pwd"].Visible = false;
                pwd_grid.Columns["registration_no"].Visible = false;

                pwd_grid.Columns["display_text"].Visible = true;
                pwd_grid.Columns["display_text"].HeaderText = "Full List";

            } else
            {
                pwd_grid.DefaultCellStyle.ForeColor = Color.FromArgb(41, 45, 56);
                pwd_grid.DefaultCellStyle.SelectionForeColor = Color.Black;
                pwd_grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 224, 224);
                pwd_grid.Columns["pwd_id"].Visible = false;
                pwd_grid.Columns["display_text"].Visible = false;
                pwd_grid.Columns["status_pwd"].Visible = false;
                pwd_grid.Columns["registration_no"].Visible = false;

                pwd_grid.Columns["no"].Visible = true;
                pwd_grid.Columns["fullname"].Visible = true;
                pwd_grid.Columns["id_no"].Visible = true;
                pwd_grid.Columns["gender"].Visible = true;
                pwd_grid.Columns["age"].Visible = true;
                pwd_grid.Columns["disability_type"].Visible = true;
                pwd_grid.Columns["educ_attainment_type"].Visible = true;
                pwd_grid.Columns["application_date"].Visible = true;
                pwd_grid.Columns["district_name"].Visible = true;

                pwd_grid.Columns["no"].HeaderText = "No.";
                pwd_grid.Columns["fullname"].HeaderText = "Name";
                pwd_grid.Columns["id_no"].HeaderText = "ID No.";
                pwd_grid.Columns["gender"].HeaderText = "Sex";
                pwd_grid.Columns["age"].HeaderText = "Age";
                pwd_grid.Columns["disability_type"].HeaderText = "Disability";
                pwd_grid.Columns["educ_attainment_type"].HeaderText = "Educational Attainment";
                pwd_grid.Columns["application_date"].HeaderText = "Date Applied";
                pwd_grid.Columns["district_name"].HeaderText = "District";
                pwd_grid.Columns["registration_no"].HeaderText = "Registration No.";
            }


            pwd_grid.Columns["no"].Width = 40;
            pwd_grid.Columns["gender"].Width = 40;
            pwd_grid.Columns["age"].Width = 40;
            pwd_cell_color();
        }

        #endregion

        #region PWD-GRID
        string current_pwd_id = "0";
        int current_pwd_grid_index = 0;

        private void pwd_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (pwd_has_pwd == false)
            {

            } else
            {
                if (e.RowIndex < 0)
                {
                    //nothing
                    sys_func.btn_inactive(btn_pwd_viewmore);
                    sys_func.btn_inactive(btn_pwd_edit);
                    sys_func.btn_inactive(btn_archive);
                }
                else
                {
                    sys_func.btn_active(btn_pwd_viewmore);
                    sys_func.btn_active(btn_pwd_edit);
                    sys_func.btn_active(btn_archive);
                    if (pwd_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.Salmon)
                    {
                        sys_func.btn_active(btn_renew);
                        sys_func.btn_active(btn_archive);
                    }
                    else
                    {
                        sys_func.btn_inactive(btn_renew);
                        sys_func.btn_inactive(btn_archive);
                    }
                    current_pwd_id = pwd_grid.Rows[e.RowIndex].Cells["pwd_id"].Value.ToString();
                    current_pwd_grid_index = e.RowIndex;
                }
            }
            
        }

        public void pwd_cell_color()
        {
            int count = pwd_grid.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                if (pwd_grid.Rows[i].Cells["status_pwd"].Value.ToString() == "0") //inactive = 0
                {
                    pwd_grid.Rows[i].DefaultCellStyle.BackColor = Color.Salmon;
                    pwd_grid.Rows[i].DefaultCellStyle.SelectionBackColor = Color.Tomato;
                }
            }
        }

        private void btn_pwd_refresh_Click(object sender, EventArgs e)
        {
            load_pwd();
            pwd_searchbox.Clear();
            pwd_filter_active.Checked = false;
            pwd_filter_inactive.Checked = false;
            pwd_filter_female.Checked = false;
            pwd_filter_male.Checked = false;
        }

        private void pwd_grid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            pwd_cell_color();
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
            Console.WriteLine("[PWD] ->> [VIEW-MODE]");
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
            Console.WriteLine("[PWD] ->> [ADD-MODE]");
            pwd_fill_up_form.ShowDialog();
            side_tab.Enabled = true;
            dboard_head.Enabled = true;
            if (success == true)
            {
                show_success_message();
            }
        }

        #endregion

        #region PWD-EDIT-MODE
        private void btn_pwd_edit_Click(object sender, EventArgs e)
        {
            int loc_x = this.Location.X + 71;
            int loc_y = this.Location.Y + 28;

            pwd_add edit = new pwd_add();
            edit.reference_to_main = this;
            edit.Location = new Point(loc_x, loc_y);
            edit.pwd_update_id = current_pwd_id;
            edit.update_mode = true;
            edit.update_regis_no = pwd_grid.Rows[current_pwd_grid_index].Cells["registration_no"].Value.ToString();
            edit.update_id_no = pwd_grid.Rows[current_pwd_grid_index].Cells["id_no"].Value.ToString();
            Console.WriteLine("[PWD] ->> [EDIT-MODE]");
            edit.ShowDialog();
            if (success == true)
            {
                show_success_message();
            }
        }

        #endregion

        #region PWD-ARCHIVE-MODE
        private void btn_archive_Click(object sender, EventArgs e)
        {
            pwd_archive = true;
            show_prompt = new pwd_archive();
            shadow_ = new shadow();
            shadow_.reference_to_main = this;
            show_prompt.current_id = current_pwd_id;
            show_prompt.reference_to_main = this;
            show_prompt.regis_no.Text = "Registration#: " + pwd_grid.Rows[current_pwd_grid_index].Cells["registration_no"].Value.ToString();
            show_prompt.name.Text = "Name: " + pwd_grid.Rows[current_pwd_grid_index].Cells["fullname"].Value.ToString();
            show_prompt.app_date.Text = "Application_date: " + pwd_grid.Rows[current_pwd_grid_index].Cells["application_date"].Value.ToString();
            show_prompt.prompt_title.Text = "Archive";
            show_prompt.action.Text = "The following profile will be archived:";
            shadow_.form_to_show = show_prompt;
            Console.WriteLine("[PWD] ->> [ARCHIVE-MODE]");
            shadow_.ShowDialog();
            btn_renew.Enabled = false;
            btn_archive.Enabled = false;
            pwd_archive = false;
        }

        #endregion

        #region PWD-SEARCH-MODE

        private void pwd_searchbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            key_.key_number_letter_space(sender, e);
        }

        private void pwd_searchbox_TextChanged(object sender, EventArgs e)
        {
            if (pwd_has_pwd == false)
            {
                //nothing
            } else
            {
                if (pwd_searchbox.Text.Trim() != "")
                {
                    conn_pwd.pwd_search(pwd_grid, pwd_searchbox); //error
                    pwd_grid.Columns["lastname"].Visible = false;
                    pwd_grid.Columns["firstname"].Visible = false;
                    pwd_grid.Columns["middlename"].Visible = false;
                    pwd_format();
                }
                else
                {
                    load_pwd();
                }
                pwd_load_row_count();
            }
        }

        #endregion

        #region PWD-FILTER-COMBOBOX

        bool gender_male = false;
        bool gender_female = false;
        bool status_active = false;
        bool status_inactive = false;

        private void pwd_filter_male_Click(object sender, EventArgs e)
        {
            if (pwd_filter_male.Checked && !gender_male)
                pwd_filter_male.Checked = false;
            else
            {
                pwd_filter_male.Checked = true;
                gender_male = false;
            }
        }

        private void pwd_filter_female_Click(object sender, EventArgs e)
        {
            if (pwd_filter_female.Checked && !gender_female)
                pwd_filter_female.Checked = false;
            else
            {
                pwd_filter_female.Checked = true;
                gender_female = false;
            }
        }

        private void pwd_filter_active_Click(object sender, EventArgs e)
        {
            if (pwd_filter_active.Checked && !status_active)
                pwd_filter_active.Checked = false;
            else
            {
                pwd_filter_active.Checked = true;
                status_active = false;
            }
        }

        private void pwd_filter_inactive_Click(object sender, EventArgs e)
        {
            if (pwd_filter_inactive.Checked && !status_inactive)
                pwd_filter_inactive.Checked = false;
            else
            {
                pwd_filter_inactive.Checked = true;
                status_inactive = false;
            }
        }

        private void pwd_filter_male_CheckedChanged(object sender, EventArgs e)
        {
            gender_male = pwd_filter_male.Checked;
            pwd_gender_ = "M";
            pwd_grid_filter();
        }

        private void pwd_filter_female_CheckedChanged(object sender, EventArgs e)
        {
            gender_female = pwd_filter_female.Checked;
            pwd_gender_ = "F";
            pwd_grid_filter();
        }

        private void pwd_filter_active_CheckedChanged(object sender, EventArgs e)
        {
            status_active = pwd_filter_active.Checked;
            pwd_status_ = "1";
            pwd_grid_filter();
        }

        private void pwd_filter_inactive_CheckedChanged(object sender, EventArgs e)
        {
            status_inactive = pwd_filter_inactive.Checked;
            pwd_status_ = "0";
            pwd_grid_filter();
        }

        public void pwd_grid_filter()
        {
            load_pwd();
            if (pwd_has_pwd == false)
            {
                //nothing
            } else
            {
                pwd_grid_filter_multiple();
                if (pwd_filter_ == true)
                {
                    Console.WriteLine("PWD_FILTER_MULTIPLE " + pwd_gender_ + " " + pwd_status_);
                    conn_pwd.filter_status_gender(pwd_status_, pwd_gender_, pwd_grid);
                }
                else
                {
                    Console.WriteLine("PWD_FILTER_ONCE");
                    if (pwd_filter_male.Checked)
                    {
                        conn_pwd.filter_gender("M", pwd_grid);
                    }
                    if (pwd_filter_female.Checked)
                    {
                        conn_pwd.filter_gender("F", pwd_grid);
                    }
                    if (pwd_filter_active.Checked)
                    {
                        conn_pwd.filter_status("1", pwd_grid);
                    }
                    if (pwd_filter_inactive.Checked)
                    {
                        conn_pwd.filter_status("0", pwd_grid);
                    }
                }


                pwd_grid.ClearSelection();
                pwd_cell_color();
            }
        }

        bool pwd_filter_ = false;
        string pwd_gender_;
        string pwd_status_;

        public void pwd_grid_filter_multiple()
        {
            if ((pwd_filter_female.Checked || pwd_filter_male.Checked) && (pwd_filter_active.Checked || pwd_filter_inactive.Checked))
            {
                pwd_filter_ = true;
            } else
            {
                pwd_filter_ = false;
            }
        }
        #endregion

        #endregion

        #region SYSTEM-DEFAULTS
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
            reports_pnl_visible();
        }

        private void btn_settings_Click(object sender, EventArgs e)
        {
            system_sidenav.btn_method(btn_current, btn_settings);
            system_sidenav.pnl_deactivate(btn_current.Name);
            btn_current = btn_settings;
            system_sidenav.lbl_current_text("settings");
            load_accounts();
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void reports_pnl_visible()
        {
            reports_pnl_pwd.Visible = false;
            reports_pnl_device.Visible = false;
            reports_pnl_projects.Visible = false;
        }


        #endregion
        #endregion

        #region NOTIFICATIONS

        public string notification_;

        public void show_success_message()
        {
            //827, 531
            success = false;
            notification_data_ = true;
            system_notify = new system_notification();
            system_notify.Location = new Point(this.Location.X + 827, this.Location.Y + 531);
            system_notify.notification_message = notification_;
            system_notify.Show();
            notification_data_ = false;
            notification_ = "";
        }

        public void load_notifications()
        {
            conn_noti.initial_font();
            conn_noti.update_font();
            notification_grid.ClearSelection();
        }

        bool show_notif = false;
        bool has_notification = false;

        private void btn_notification_Click(object sender, EventArgs e)
        {
            has_notification = false;

            for (int i = 0; i < notification_grid.Rows.Count; i++)
            {
                string clicked = notification_grid.Rows[i].Cells["type_clicked"].Value.ToString();
                if (clicked == "0")
                {
                    has_notification = true;
                    break;
                }
            }
            btn_notification.BackColor = Color.Transparent;

            if (show_notif == false)
            {
                show_notif = true;
                pnl_notif_pp.Visible = true;
                btn_notification.BackColor = btn_notification.FlatAppearance.MouseDownBackColor;
                if (has_notification)
                {
                    btn_notification.BackColor = Color.Red;
                }
            }
            else
            {
                show_notif = false;
                pnl_notif_pp.Visible = false;
                btn_notification.BackColor = Color.Transparent;
                if (has_notification)
                {
                    btn_notification.BackColor = Color.Red;
                }
            }
        }

        #endregion

        #region PROJECT-MODULE

        #region ON-LOAD

        public void load_projects()
        {
            conn_proj.project_grid_list(projects_grid);
            projects_format();

            project_load_row_count();
            projects_default_data();

            projects_grid.ClearSelection();
        }

        public void projects_format()
        {
            projects_grid.Columns["project_title"].HeaderText = "Title";
            projects_grid.Columns["start_time"].HeaderText = "Start Time";
            projects_grid.Columns["end_time"].HeaderText = "End Time";
            projects_grid.Columns["date_proposed"].HeaderText = "Date Proposed";

            projects_grid.Columns["project_id"].Visible = false;
            projects_grid.Columns["project_desc"].Visible = false;
            projects_grid.Columns["progress_id"].Visible = false;
            projects_grid.Columns["approved_by"].Visible = false;
            projects_grid.Columns["event_held"].Visible = false;
            projects_grid.Columns["budget"].Visible = false;
            projects_grid.Columns["isArchived"].Visible = false;
            projects_grid.Columns["user_id"].Visible = false;
            projects_grid.Columns["progress_id1"].Visible = false;
            projects_grid.Columns["project_id1"].Visible = false;
            projects_grid.Columns["progress_type"].Visible = false;
            projects_grid.Columns["date_changed"].Visible = false;

            //projects_grid.Columns["project_id"].Width = 35;
        }

        public void projects_default_data()
        {
            
        }

        public void project_load_row_count()
        {
            project_grid_row_count.Text = projects_grid.Rows.Count.ToString();
        }
        

        #endregion

        #region PROJECT-VIEW
        public int current_project_id = 0;
        int current_project_grid_index = 0;
        
        

        #endregion

        #region PROJECT-GRID

        private void projects_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            /*if (e.RowIndex < 0)
            {
                btn_projects_persons_involved.Enabled = false;
            }
            else
            {
                current_project_id = int.Parse(projects_grid.Rows[e.RowIndex].Cells["project_id"].Value.ToString());
                current_project_grid_index = e.RowIndex;
                projects_paste_data();
                btn_projects_persons_involved.Enabled = true;
            }*/
        }

        private void btn_projects_refresh_Click(object sender, EventArgs e)
        {
            load_projects();
        }

        #endregion

        #region PROJECT-FILTER

        bool project_status_pending = false;
        bool project_status_ongoing = false;
        bool project_status_cancelled = false;

        private void project_filter_pending_CheckedChanged(object sender, EventArgs e)
        {
            project_status_pending = project_filter_pending.Checked;
            project_status_ = "0";
            project_grid_filter();
        }

        private void project_filter_ongoing_CheckedChanged(object sender, EventArgs e)
        {
            project_status_ongoing = project_filter_ongoing.Checked;
            project_status_ = "1";
            project_grid_filter();
        }

        private void project_filter_cancelled_CheckedChanged(object sender, EventArgs e)
        {
            project_status_cancelled = project_filter_cancelled.Checked;
            project_status_ = "2";
            project_grid_filter();
        }


        private void project_filter_pending_Click(object sender, EventArgs e)
        {
            if (project_filter_pending.Checked && !project_status_pending)
                project_filter_pending.Checked = false;
            else
            {
                project_filter_pending.Checked = true;
                project_status_pending = false;
            }
        }

        private void project_filter_ongoing_Click(object sender, EventArgs e)
        {
            if (project_filter_ongoing.Checked && !project_status_ongoing)
                project_filter_ongoing.Checked = false;
            else
            {
                project_filter_ongoing.Checked = true;
                project_status_ongoing = false;
            }
        }

        private void project_filter_cancelled_Click(object sender, EventArgs e)
        {
            if (project_filter_cancelled.Checked && !project_status_cancelled)
                project_filter_cancelled.Checked = false;
            else
            {
                project_filter_cancelled.Checked = true;
                project_status_cancelled = false;
            }
        }

        string project_status_;
        bool project_filter_ = false;

        public void project_grid_filter()
        {
            load_projects();
            project_grid_filter_check();
            if (project_filter_)
            {
                Console.WriteLine("PROJECT_FILTER " + project_status_);
                conn_proj.filter_status(project_status_, projects_grid);

            }

            projects_grid.ClearSelection();
        }

        public void project_grid_filter_check()
        {
            if (project_filter_pending.Checked || project_filter_ongoing.Checked || project_filter_cancelled.Checked)
            {
                project_filter_ = true;
            }
            else
            {
                project_filter_ = false;
            }
        }



        #endregion

        int current_project_persons_id = 0;
        int current_project_persons_index;
        string attendance;
        
        

        private void btn_project_add_Click(object sender, EventArgs e)
        {
            shadow_ = new shadow();
            shadow_.reference_to_main = this;
            project_add proj_add = new project_add();
            shadow_.form_to_show = proj_add;
            proj_add.reference_to_main = this;
            shadow_.ShowDialog();
        }

        #endregion

        #region DEVICE-MODULE

        #region DEVICE-PENDING

        #region VIEW-MODE
        public bool device_has_data_requests = false;
        public bool device_has_data_recieved = false;

        public void load_device_requests()
        {
            device_pending_requests();
            device_requests_grid_format();
        }

        public void device_requests_grid_format()
        {
            Font def = new Font("Segoe UI", 8.25F);
            if (device_has_data_requests == false)
            {
                device_requests.DefaultCellStyle.SelectionBackColor = Color.White;
                device_requests.DefaultCellStyle.ForeColor = Color.Gray;
                device_requests.DefaultCellStyle.Font = new Font(def, FontStyle.Italic);
                device_requests.DefaultCellStyle.SelectionForeColor = Color.Gray;
            }
            else
            {
                device_requests.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 224, 224);
                device_requests.DefaultCellStyle.ForeColor = Color.FromArgb(41, 45, 56);
                device_requests.DefaultCellStyle.Font = new Font(def, FontStyle.Regular);
                device_requests.DefaultCellStyle.SelectionForeColor = Color.FromArgb(41, 45, 56);
            }

            if (device_has_data_recieved == false)
            {
                device_recieved.DefaultCellStyle.SelectionBackColor = Color.White;
                device_recieved.DefaultCellStyle.ForeColor = Color.Gray;
                device_recieved.DefaultCellStyle.Font = new Font(def, FontStyle.Italic);
                device_recieved.DefaultCellStyle.SelectionForeColor = Color.Gray;
            }
            else
            {
                device_recieved.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 224, 224);
                device_recieved.DefaultCellStyle.ForeColor = Color.FromArgb(41, 45, 56);
                device_recieved.DefaultCellStyle.Font = new Font(def, FontStyle.Regular);
                device_recieved.DefaultCellStyle.SelectionForeColor = Color.FromArgb(41, 45, 56);
            }
        }

        public void device_requests_format()
        {
            device_requests.Columns["no"].Visible = false;
            device_requests.Columns["deviceLOG_id"].Visible = false;
            device_requests.Columns["registration_no"].Visible = false;
            device_requests.Columns["pwd_id"].Visible = false;
            device_requests.Columns["dp_name"].Visible = false;
            device_requests.Columns["req_date"].Visible = false;
            device_requests.Columns["reference_no"].Visible = false;
            device_requests.Columns["fullname"].Visible = false;
        }

        public void device_recieved_format()
        {
            device_recieved.Columns["no"].Visible = false;
            device_recieved.Columns["deviceLOG_id"].Visible = false;
            device_recieved.Columns["registration_no"].Visible = false;
            device_recieved.Columns["pwd_id"].Visible = false;
            device_recieved.Columns["dp_name"].Visible = false;
            device_recieved.Columns["date_in"].Visible = false;
            device_recieved.Columns["reference_no"].Visible = false;
            device_recieved.Columns["fullname"].Visible = false;
        }

        #endregion

        #region CELL-CLICK

        private void device_recieved_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || device_has_data_recieved == false)
            {
                //do nothing
            }
            else
            {
                device_received_ = true;
                device_received_form = new device_pending_rec();
                device_received_form.reference_to_main = this;
                device_received_form.current_pwd_id = device_recieved.Rows[e.RowIndex].Cells["pwd_id"].Value.ToString();
                device_received_form.current_device_log_id = device_recieved.Rows[e.RowIndex].Cells["deviceLOG_id"].Value.ToString();
                device_received_form.header_text.Text = "# " + device_recieved.Rows[e.RowIndex].Cells["no"].Value.ToString();
                shadow_ = new shadow();
                shadow_.reference_to_main = this;
                shadow_.form_to_show = device_received_form;
                shadow_.ShowDialog();
                device_received_ = false;
                device_recieved.ClearSelection();
            }
        }

        private void device_requests_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || device_has_data_requests == false)
            {
                //do nothing
            }
            else
            {
                device_requests_ = true;
                device_requests_form = new device_pending_req();
                device_requests_form.reference_to_main = this;
                device_requests_form.current_pwd_id = device_requests.Rows[e.RowIndex].Cells["pwd_id"].Value.ToString();
                device_requests_form.current_device_log_id = device_requests.Rows[e.RowIndex].Cells["deviceLOG_id"].Value.ToString();
                device_requests_form.header_text.Text = "# " + device_requests.Rows[e.RowIndex].Cells["no"].Value.ToString();
                shadow_ = new shadow();
                shadow_.reference_to_main = this;
                shadow_.form_to_show = device_requests_form;
                shadow_.ShowDialog();
                device_requests_ = false;
            }
        }

        #endregion

        #region REQUEST Default Control Response

        private void device_requests_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (device_has_data_requests)
            {
                device_requests.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.FromArgb(224, 224, 224);
            }
            else
            {
                device_requests.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
            }
        }

        private void device_requests_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            device_requests.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
        }

        private void device_requests_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            device_requests.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.FromArgb(224, 224, 224);
        }

        private void device_requests_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            device_requests.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
        }

        private void device_btn_requested_Click(object sender, EventArgs e)
        {
            device_pending_requests();
        }

        public void device_pending_requests()
        {
            device_btn_recieved.BackColor = Color.FromArgb(240, 240, 240);
            conn_devi.get_pending_requests(device_requests);
            device_requests_format();
            device_btn_requested.BackColor = Color.Silver;
            device_requests.ClearSelection();
            device_recieved.Visible = false;
            device_requests.Visible = true;
            device_requests_grid_format();
        }

        #endregion

        #region RECIEVED Default Control Response

        public void device_pending_recieved()
        {
            device_btn_requested.BackColor = Color.FromArgb(240, 240, 240);
            conn_devi.get_pending_recieved(device_recieved);
            device_recieved_format();
            device_btn_recieved.BackColor = Color.Silver;
            device_recieved.ClearSelection();
            device_requests.Visible = false;
            device_recieved.Visible = true;
            device_requests_grid_format();
        }

        private void device_btn_recieved_Click(object sender, EventArgs e)
        {
            device_pending_recieved();
        }

        private void device_recieved_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            device_recieved.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
        }

        private void device_recieved_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (device_has_data_recieved)
            {
                device_recieved.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.FromArgb(224, 224, 224);
            }
            else
            {
                device_recieved.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
            }
        }

        private void device_recieved_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            device_recieved.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
        }

        private void device_recieved_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            device_recieved.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
        }



        #endregion

        #endregion

        #region DEVICE-DEVICE

        private void projects_devices_Click(object sender, EventArgs e)
        {
            device_device_add_ = true;
            dev_add = new device_device_add();
            shadow_ = new shadow();
            shadow_.reference_to_main = this;
            shadow_.form_to_show = dev_add;
            shadow_.ShowDialog();
            load_handedout_data();
            device_device_add_ = false;
        }

        #endregion

        #region DEVICE-PROVIDER

        private void projects_providers_Click(object sender, EventArgs e)
        {
            side_tab.Enabled = false;
            dboard_head.Enabled = false;
            device_provider_ = true;
            dev_pro = new device_provider();
            dev_pro.reference_to_main = this;
            dev_pro.ShowDialog();
            load_handedout_data();
            device_provider_ = false;
            side_tab.Enabled = true;
            dboard_head.Enabled = true;
        }


        #endregion

        #region DEVICE-REQUEST

        bool device_has_providers = false;
        bool device_has_devices = false;
        bool device_has_pwd = false;
        int device_pwd_list_index = 0;

        #region LOAD-RESET-REFRESH

        public void load_device_request_defaults()
        {
            device_has_providers = conn_devi.get_provider_list(device_sponsor_cbox);
            device_has_pwd = conn_devi.get_pwd_list(device_pwd_list);
            device_has_devices = conn_devi.get_device_list(device_device_cbox);

            conn_user.get_user_cbox(device_requested_by);
            device_device_cbox.Items.Clear();
            device_device_cbox.Items.Add("");
        }

        public void device_request_clear()
        {
            device_lbl_pwd_name.Text = "--";
            device_lbl_id_no.Text = "--";
            device_lbl_disability.Text = "--";
            device_lbl_tel_no.Text = "--";
            device_lbl_mobile_no.Text = "--";
            device_lbl_provider_address.Text = "--";
            device_sponsor_cbox.SelectedIndex = 0;
            device_request_date.MaxDate = DateTime.Now;
            device_request_desc.Clear();
            device_device_cbox.SelectedIndex = 0;
            device_requested_by.SelectedIndex = 0;
            device_sponsor_cbox.SelectedIndex = 0;
            device_reference_no.Clear();

            sys_func.lbl_reset(device_lbl_pwd_name);
            sys_func.lbl_reset(device_lbl_id_no);
            sys_func.lbl_reset(device_lbl_disability);
            sys_func.lbl_reset(device_lbl_tel_no);
            sys_func.lbl_reset(device_lbl_mobile_no);
            sys_func.lbl_reset(device_lbl_provider_address);
            sys_func.btn_inactive(device_btn_request_add);

        }

        private void device_btn_request_clear_Click(object sender, EventArgs e)
        {
            device_request_clear();
            load_device_request_defaults();
        }

        #endregion

        #region ADD-REQUEST


        private void device_request_new_Click(object sender, EventArgs e)
        {
            device_request_clear();
            load_device_request_defaults();
            if (device_has_providers == false || device_has_devices == false)
            {
                device_pnl_request_new.SendToBack();
                device_pnl_request_new.Visible = false;
                string start = "The following required fields are empty, please add records :" + Environment.NewLine;
                if (device_has_providers == false)
                {
                    start += "- Sponsors List" + Environment.NewLine;
                }
                if (device_has_devices == false)
                {
                    start += "- Device List" + Environment.NewLine;
                }
                MessageBox.Show(start, "Empty Database", MessageBoxButtons.OK);
            }
            else
            {
                device_pnl_request_new.BringToFront();
                device_pnl_request_new.Visible = true;
                device_request_clear();

                device_pwd_list.Columns["pwd_id"].Visible = false;
                device_pwd_list.Columns["id_no"].Visible = false;
                device_pwd_list.Columns["address"].Visible = false;
                device_pwd_list.Columns["mobile_no"].Visible = false;
                device_pwd_list.Columns["tel_no"].Visible = false;
                device_pwd_list.Columns["disability_type"].Visible = false;
                device_pwd_list.Columns["dis_id"].Visible = false;

                device_pwd_list.Columns["registration_no"].HeaderText = "Registration no.";
                device_pwd_list.Columns["fullname"].HeaderText = "Fullname";
            }

        }

        private void device_btn_request_add_Click(object sender, EventArgs e)
        {
            string pwd_id = device_pwd_list.Rows[device_pwd_list_index].Cells["pwd_id"].Value.ToString();
            string device_id = conn_devi.get_device_by_name(device_device_cbox.SelectedItem.ToString());
            string dp_id = conn_devi.get_sponsor_by_name(device_sponsor_cbox.SelectedItem.ToString());
            string req_date = device_request_date.Value.ToString("yyyy-MM-dd");
            string req_desc = device_request_desc.Text;
            string req_emp_id;
            if (device_requested_by.SelectedIndex <= 0)
            {
                req_emp_id = conn_user.get_user_id_by_name(current_user);
            }
            else
            {
                req_emp_id = conn_user.get_user_id_by_name(device_requested_by.SelectedItem.ToString());
            }
            string reference = device_reference_no.Text;
            string recent = conn_user.get_user_id_by_name(current_user);
            string query = "INSERT INTO device_log(pwd_id, device_id, dp_id, req_date, req_desc, req_emp_id, status, reference_no) VALUES ( "
                                                       + pwd_id + ", "
                                                       + device_id + ", "
                                                       + dp_id + ", '"
                                                       + req_date + "', '"
                                                       + req_desc + "', "
                                                       + req_emp_id + ", "
                                                       + "status = 1, '"
                                                       + reference + "') ";
            bool request_success = conn_devi.request_add(query);
            
            if (request_success == true)
            {
                notification_ = "Successfully Added Request!";
                device_request_clear();
                load_device_requests();
                load_device_request_defaults();
            }
            else
            {
                notification_ = "Unsuccessful in Adding Request, please try again with valid values.";
            }
            show_success_message();

        }

        #endregion

        #region SELECTION-CELL_CLICK

        private void device_pwd_list_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (device_has_pwd == false)
            {
                device_request_clear();
            }
            else
            {
                if (e.RowIndex >= 0)
                {
                    device_pwd_list_index = e.RowIndex;
                    device_pwd_selection();
                }
                else
                {
                    device_pwd_list_index = 0;
                    sys_func.btn_inactive(device_btn_request_add);
                    device_request_clear();
                    device_pwd_list.ClearSelection();
                }
            }
        }

        private void device_pwd_list_SelectionChanged(object sender, EventArgs e)
        {
            if (device_has_pwd == false)
            {
                device_request_clear();
            }
            else
            {
                device_pwd_list_index = device_pwd_list.CurrentCell.RowIndex;
                device_pwd_selection();
            }
        }

        public void device_pwd_selection()
        {
            device_lbl_pwd_name.Text = device_pwd_list.Rows[device_pwd_list_index].Cells["fullname"].Value.ToString();
            device_lbl_id_no.Text = device_pwd_list.Rows[device_pwd_list_index].Cells["id_no"].Value.ToString();
            device_lbl_disability.Text = device_pwd_list.Rows[device_pwd_list_index].Cells["disability_type"].Value.ToString();
            device_lbl_provider_address.Text = device_pwd_list.Rows[device_pwd_list_index].Cells["address"].Value.ToString();
            device_lbl_mobile_no.Text = device_pwd_list.Rows[device_pwd_list_index].Cells["mobile_no"].Value.ToString();
            device_lbl_tel_no.Text = device_pwd_list.Rows[device_pwd_list_index].Cells["tel_no"].Value.ToString();
            string dis_id = device_pwd_list.Rows[device_pwd_list_index].Cells["dis_id"].Value.ToString();

            device_has_devices = conn_devi.get_device_list(device_device_cbox, dis_id);

            sys_func.lbl_has_value(device_lbl_pwd_name);
            sys_func.lbl_has_value(device_lbl_id_no);
            sys_func.lbl_has_value(device_lbl_disability);
            sys_func.lbl_has_value(device_lbl_provider_address);
            sys_func.lbl_has_value(device_lbl_mobile_no);
            sys_func.lbl_has_value(device_lbl_tel_no);
        }

        #endregion

        #region SELECTED-INDEX-TEXT-CHANGED

        private void device_sponsor_cbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            device_request_check_required();
            string dp_id = conn_devi.get_sponsor_by_name(device_sponsor_cbox.SelectedItem.ToString());
        }

        private void device_device_cbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            device_request_check_required();
        }

        private void device_reference_no_TextChanged(object sender, EventArgs e)
        {
            device_request_check_required();
        }

        #endregion

        #region CHECK-REQUIRED

        public void device_request_check_required()
        {
            if (device_sponsor_cbox.Text == "" || device_device_cbox.Text == "" || device_reference_no.Text.Trim() == "" || device_has_devices == false)
            {
                sys_func.btn_inactive(device_btn_request_add);
                if (device_sponsor_cbox.SelectedIndex == 0)
                {
                    sys_func.lbl_required_error(device_lbl_head_sponsor);
                }
                else
                {
                    sys_func.lbl_required_success(device_lbl_head_sponsor);
                }

                if (device_device_cbox.SelectedIndex == 0 || device_has_devices == false)
                {
                    sys_func.lbl_required_error(device_lbl_head_device);
                }
                else
                {
                    sys_func.lbl_required_success(device_lbl_head_device);
                }

                if (device_reference_no.Text.Trim() == "")
                {
                    sys_func.lbl_required_error(device_lbl_head_reference);
                }
                else
                {
                    sys_func.lbl_required_success(device_lbl_head_reference);
                }
            }
            else
            {
                sys_func.btn_active(device_btn_request_add);
                sys_func.lbl_required_success(device_lbl_head_sponsor);
                sys_func.lbl_required_success(device_lbl_head_device);
                sys_func.lbl_required_success(device_lbl_head_reference);
            }
        }

        #endregion

        #endregion

        #region DEVICE-HANDED-OUT

        int device_handout_index = 0;
        bool device_has_handedout = false;

        #region LOAD-RESET-REFRESH

        private void device_handout_btn_refresh_Click(object sender, EventArgs e)
        {
            load_handedout_data();
            device_handedout_clear_view();
        }

        public void device_handedout_clear_view()
        {
            device_handout_lbl_req_id.Text = "--";
            device_handout_lbl_recipient.Text = "--";
            device_handout_lbl_registration_no.Text = "--";
            device_handout_lbl_disability.Text = "--";
            device_handout_lbl_id_no.Text = "--";
            device_handout_lbl_mobile_no.Text = "--";
            device_handout_lbl_tel_no.Text = "--";
            device_handout_date_requested.Text = "--";
            device_handout_desc.Text = "--";
            device_handout_requested_by.Text = "--";
            device_handout_date_in.Text = "--";
            device_handout_in_emp_id.Text = "--";
            device_handout_reference_no.Text = "--";
            device_handout_status.Text = "--";
            device_handout_status_date.Text = "--";
            device_handout_lbl_out_emp_id.Text = "--";
            device_handout_sponsor.Text = "--";
            device_handout_device_requested.Text = "--";

            sys_func.lbl_reset(device_handout_lbl_req_id);
            sys_func.lbl_reset(device_handout_lbl_recipient);
            sys_func.lbl_reset(device_handout_lbl_registration_no);
            sys_func.lbl_reset(device_handout_lbl_disability);
            sys_func.lbl_reset(device_handout_lbl_id_no);
            sys_func.lbl_reset(device_handout_lbl_mobile_no);
            sys_func.lbl_reset(device_handout_lbl_tel_no);
            sys_func.lbl_reset(device_handout_date_requested);
            sys_func.lbl_reset(device_handout_desc);
            sys_func.lbl_reset(device_handout_requested_by);
            sys_func.lbl_reset(device_handout_date_in);
            sys_func.lbl_reset(device_handout_in_emp_id);
            sys_func.lbl_reset(device_handout_reference_no);
            sys_func.lbl_reset(device_handout_status);
            sys_func.lbl_reset(device_handout_status_date);
            sys_func.lbl_reset(device_handout_lbl_out_emp_id);
            sys_func.lbl_reset(device_handout_sponsor);
            sys_func.lbl_reset(device_handout_device_requested);
        }

        public void load_handedout_data()
        {
            device_has_handedout = conn_devi.get_handedout_list(device_handed_out_grid);
            device_handedout_format();
            sys_func.btn_inactive(device_handout_archive);
        }

        public void device_handout_clear()
        {

            device_handout_request_desc_edit.Clear();
            device_handout_requested_by_edit.Text = "";
            device_handout_sponsor_edit.Text = "";
            device_handout_reference_no_edit.Clear();
            device_handout_received_by_edit.Text = device_handout_in_emp_id.Text;
            device_handout_status_edit.Text = "Handed Out";
            device_handout_out_emp_id_edit.Text = device_handout_lbl_out_emp_id.Text;

            device_handout_date_in_edit.MinDate = device_handout_date_req_edit.Value;
            device_handout_status_date_edit.MinDate = device_handout_date_in_edit.Value;
        }


        #endregion

        #region FORMAT

        public void device_handedout_format()
        {
            device_handed_out_grid.Columns["deviceLOG_id"].Visible = false;
            device_handed_out_grid.Columns["req_date"].Visible = false;
            device_handed_out_grid.Columns["req_desc"].Visible = false;
            device_handed_out_grid.Columns["user_req"].Visible = false;
            device_handed_out_grid.Columns["date_in"].Visible = false;
            device_handed_out_grid.Columns["user_in"].Visible = false;
            device_handed_out_grid.Columns["user_out"].Visible = false;
            device_handed_out_grid.Columns["status"].Visible = false;
            device_handed_out_grid.Columns["reference_no"].Visible = false;
            device_handed_out_grid.Columns["disability_type"].Visible = false;
            device_handed_out_grid.Columns["mobile_no"].Visible = false;
            device_handed_out_grid.Columns["tel_no"].Visible = false;
            device_handed_out_grid.Columns["id_no"].Visible = false;
            device_handed_out_grid.Columns["registration_no"].Visible = false;
            device_handed_out_grid.Columns["dev_name"].Visible = false;

            device_handed_out_grid.Columns["no"].Width = 35;
            device_handed_out_grid.Columns["no"].HeaderText = "No.";
            device_handed_out_grid.Columns["fullname"].HeaderText = "Full Name";
            device_handed_out_grid.Columns["dp_name"].HeaderText = "Sponsor";
            device_handed_out_grid.Columns["date_out"].HeaderText = "Date Handed Out";
            device_handed_out_grid.Columns["dev_name"].HeaderText = "Device";
            device_handed_out_grid.Columns["handed_out_text"].HeaderText = "List";

            if (device_has_handedout == false)
            {
                device_handed_out_grid.Columns["no"].Visible = false;
                device_handed_out_grid.Columns["fullname"].Visible = false;
                device_handed_out_grid.Columns["dp_name"].Visible = false;
                device_handed_out_grid.Columns["date_out"].Visible = false;
                device_handed_out_grid.Columns["handed_out_text"].Visible = true;
            }
            else
            {
                device_handed_out_grid.Columns["no"].Visible = true;
                device_handed_out_grid.Columns["fullname"].Visible = true;
                device_handed_out_grid.Columns["dp_name"].Visible = true;
                device_handed_out_grid.Columns["date_out"].Visible = true;
                device_handed_out_grid.Columns["handed_out_text"].Visible = false;
            }
        }
        #endregion

        #region SELECTION-CHANGED
        public void device_handedout_selection()
        {
            device_handout_lbl_req_id.Text = device_handed_out_grid.Rows[device_handout_index].Cells["deviceLOG_id"].Value.ToString();
            device_handout_lbl_recipient.Text = device_handed_out_grid.Rows[device_handout_index].Cells["fullname"].Value.ToString();
            device_handout_lbl_registration_no.Text = device_handed_out_grid.Rows[device_handout_index].Cells["registration_no"].Value.ToString();
            device_handout_lbl_disability.Text = device_handed_out_grid.Rows[device_handout_index].Cells["disability_type"].Value.ToString();
            device_handout_lbl_id_no.Text = device_handed_out_grid.Rows[device_handout_index].Cells["id_no"].Value.ToString();
            device_handout_lbl_mobile_no.Text = device_handed_out_grid.Rows[device_handout_index].Cells["mobile_no"].Value.ToString();
            device_handout_lbl_tel_no.Text = device_handed_out_grid.Rows[device_handout_index].Cells["tel_no"].Value.ToString();
            device_handout_date_requested.Text = device_handed_out_grid.Rows[device_handout_index].Cells["req_date"].Value.ToString();
            device_handout_desc.Text = device_handed_out_grid.Rows[device_handout_index].Cells["req_desc"].Value.ToString();
            device_handout_requested_by.Text = device_handed_out_grid.Rows[device_handout_index].Cells["user_req"].Value.ToString();
            device_handout_date_in.Text = device_handed_out_grid.Rows[device_handout_index].Cells["date_in"].Value.ToString();
            device_handout_in_emp_id.Text = device_handed_out_grid.Rows[device_handout_index].Cells["user_in"].Value.ToString();
            device_handout_reference_no.Text = device_handed_out_grid.Rows[device_handout_index].Cells["reference_no"].Value.ToString();
            device_handout_status.Text = "Handed out.";
            device_handout_status_date.Text = device_handed_out_grid.Rows[device_handout_index].Cells["date_out"].Value.ToString();
            device_handout_lbl_out_emp_id.Text = device_handed_out_grid.Rows[device_handout_index].Cells["user_out"].Value.ToString();
            device_handout_sponsor.Text = device_handed_out_grid.Rows[device_handout_index].Cells["dp_name"].Value.ToString();
            device_handout_device_requested.Text = device_handed_out_grid.Rows[device_handout_index].Cells["dev_name"].Value.ToString();

            sys_func.lbl_has_value(device_handout_lbl_req_id);
            sys_func.lbl_has_value(device_handout_lbl_recipient);
            sys_func.lbl_has_value(device_handout_lbl_registration_no);
            sys_func.lbl_has_value(device_handout_lbl_disability);
            sys_func.lbl_has_value(device_handout_lbl_id_no);
            sys_func.lbl_has_value(device_handout_lbl_mobile_no);
            sys_func.lbl_has_value(device_handout_lbl_tel_no);
            sys_func.lbl_has_value(device_handout_date_requested);
            sys_func.lbl_has_value(device_handout_desc);
            sys_func.lbl_has_value(device_handout_requested_by);
            sys_func.lbl_has_value(device_handout_date_in);
            sys_func.lbl_has_value(device_handout_in_emp_id);
            sys_func.lbl_has_value(device_handout_reference_no);
            sys_func.lbl_has_value(device_handout_status);
            sys_func.lbl_has_value(device_handout_status_date);
            sys_func.lbl_has_value(device_handout_lbl_out_emp_id);
            sys_func.lbl_has_value(device_handout_sponsor);
            sys_func.lbl_has_value(device_handout_device_requested);
        }

        private void device_handed_out_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (device_has_handedout == false)
            {
                device_handedout_clear_view();
            }
            else
            {
                if (e.RowIndex >= 0)
                {
                    device_handout_index = e.RowIndex;
                    device_handedout_selection();
                    sys_func.btn_active(device_handout_archive);
                }
                else
                {
                    device_handout_index = 0;
                    sys_func.btn_inactive(device_handout_archive);
                    device_handedout_clear_view();
                }
            }
        }

        private void device_handed_out_grid_SelectionChanged(object sender, EventArgs e)
        {
            if (device_has_handedout == false)
            {
                //do nothing
            }
            else
            {
                try
                {
                    device_handout_index = device_handed_out_grid.CurrentCell.RowIndex;
                    device_handedout_selection();
                    sys_func.btn_active(device_handout_archive);
                }
                catch (Exception ex)
                {
                    //why..
                    device_handout_index = 0;
                    sys_func.btn_inactive(device_handout_archive);
                }
            }
        }
        #endregion

        #region SELECTION-INDEX-CHANGED

        private void device_handout_requested_by_edit_SelectedIndexChanged(object sender, EventArgs e)
        {
            device_handout_check_required();
        }

        private void device_handout_date_req_edit_ValueChanged(object sender, EventArgs e)
        {
            device_handout_check_required();
            device_handout_mindate();
        }

        private void device_handout_device_requested_edit_SelectedIndexChanged(object sender, EventArgs e)
        {
            device_handout_check_required();
        }

        private void device_handout_sponsor_edit_SelectedIndexChanged(object sender, EventArgs e)
        {
            device_handout_check_required();
        }

        private void device_handout_reference_no_edit_TextChanged(object sender, EventArgs e)
        {
            device_handout_check_required();
        }

        private void device_handout_date_in_edit_ValueChanged(object sender, EventArgs e)
        {
            device_handout_check_required();
            device_handout_mindate();
        }

        private void device_handout_received_by_edit_SelectedIndexChanged(object sender, EventArgs e)
        {
            device_handout_check_required();
        }

        private void device_handout_status_edit_SelectedIndexChanged(object sender, EventArgs e)
        {
            device_handout_check_required();
        }

        private void device_handout_out_emp_id_edit_SelectedIndexChanged(object sender, EventArgs e)
        {
            device_handout_check_required();
        }

        public void device_handout_check_required()
        {
            if (device_handout_btn_edit.Text == "EDIT")
            {
                //nothing
            }
            else
            {
                if (device_handout_requested_by_edit.Text.Trim() == "" || device_handout_sponsor_edit.Text.Trim() == "" || device_handout_reference_no_edit.Text.Trim() == ""
                    || device_handout_received_by_edit.Text.Trim() == "" || device_handout_status_edit.Text.Trim() == "" || device_handout_out_emp_id_edit.Text.Trim() == "" || device_handout_device_requested_edit.Text.Trim() == "")
                {
                    sys_func.btn_inactive(device_handout_btn_edit);
                }
                else
                {
                    sys_func.btn_active(device_handout_btn_edit);
                }
            }
        }

        public void device_handout_mindate()
        {
            if (device_handout_btn_edit.Text == "EDIT")
            {

            }
            else
            {
                device_handout_date_in_edit.MinDate = device_handout_date_req_edit.Value;
                device_handout_status_date_edit.MinDate = device_handout_date_in_edit.Value;

                device_handout_date_in_edit.MaxDate = DateTime.Now;
                device_handout_status_date_edit.MaxDate = DateTime.Now;
            }
        }

        #endregion

        #region EDIT-MODE

        public void device_handout_edit()
        {
            string disability_id = conn_disa.get_disability_by_name(device_handout_lbl_disability.Text);
            conn_devi.get_device_list(device_handout_device_requested_edit, disability_id);
            conn_user.get_user_cbox(device_handout_requested_by_edit);
            conn_user.get_user_cbox(device_handout_received_by_edit);
            conn_user.get_user_cbox(device_handout_out_emp_id_edit);
            conn_devi.get_provider_list(device_handout_sponsor_edit);

            device_handout_request_desc_edit.Text = device_handout_desc.Text;
            device_handout_requested_by_edit.Text = device_handout_requested_by.Text;
            device_handout_date_req_edit.Value = Convert.ToDateTime(device_handout_date_requested.Text);
            device_handout_sponsor_edit.Text = device_handout_sponsor.Text;
            device_handout_device_requested_edit.Text = device_handout_device_requested.Text;
            device_handout_reference_no_edit.Text = device_handout_reference_no.Text;
            device_handout_date_in_edit.Value = Convert.ToDateTime(device_handout_date_in.Text);
            device_handout_received_by_edit.Text = device_handout_in_emp_id.Text;
            device_handout_status_edit.Text = "Handed Out";
            device_handout_status_date_edit.Value = Convert.ToDateTime(device_handout_status_date.Text);
            device_handout_out_emp_id_edit.Text = device_handout_lbl_out_emp_id.Text;


            device_handout_date_in_edit.MinDate = device_handout_date_in_edit.Value;
            device_handout_status_date_edit.MinDate = device_handout_date_in_edit.Value;
        }

        private void device_handout_btn_edit_Click(object sender, EventArgs e)
        {
            if (device_handout_btn_edit.Text == "EDIT")
            {
                device_handout_btn_cancel.Visible = true;
                device_handout_btn_edit.Text = "SAVE CHANGES";
                sys_func.btn_inactive(device_handout_btn_edit);
                sys_func.btn_inactive(device_handout_archive);
                device_handout_pnl_edit.Visible = true;
                device_handed_out_grid.Enabled = false;

                device_handed_out_grid.DefaultCellStyle.ForeColor = Color.Gray;

                device_handout_edit();
            }
            else
            {
                string req_id = device_handout_lbl_req_id.Text;
                string desc = device_handout_request_desc_edit.Text;
                string req_by = conn_user.get_user_id_by_name(device_handout_requested_by_edit.Text);
                string req_date = device_handout_date_req_edit.Value.ToString("yyyy-MM-dd");
                string sponsor = conn_devi.get_sponsor_by_name(device_handout_sponsor_edit.Text);
                string reference_no = device_handout_reference_no_edit.Text;
                string received_on = device_handout_date_in_edit.Value.ToString("yyyy-MM-dd");
                string received_by = conn_user.get_user_id_by_name(device_handout_received_by_edit.Text);
                string device_id = conn_devi.get_device_by_name(device_handout_device_requested_edit.Text);
                string out_emp_id = conn_user.get_user_id_by_name(device_handout_out_emp_id_edit.Text);
                string status;
                string status_date;
                string query;
                if (device_handout_status_edit.Text == "Handed Out")
                {
                    status = "3";
                    status_date = device_handout_status_date_edit.Value.ToString("yyyy-MM-dd");
                    query = "UPDATE device_log SET dp_id = " + sponsor + ", req_desc = '" + desc + "', req_emp_id = " + req_by + ", req_date = '" + req_date + "', date_out = '" + status_date
                        + "', out_emp_id = " + out_emp_id + ", status = 3, device_id = " + device_id + ", reference_no = '" + reference_no + "', "
                        + "cancel_emp_id = NULL, cancel_date = NULL WHERE deviceLOG_id =" + req_id;
                }
                else
                {
                    status = "4";
                    status_date = device_handout_status_date_edit.Value.ToString("yyyy-MM-dd");
                    query = "UPDATE device_log SET dp_id = " + sponsor + ", req_desc = '" + desc + "', req_emp_id = " + req_by + ", req_date = '" + req_date + "', cancel_date = '" + status_date
                        + "', cancel_emp_id = " + out_emp_id + ", status = 4, device_id = " + device_id + ", reference_no = '" + reference_no + "', "
                        + "out_emp_id = NULL, date_out = NULL WHERE deviceLOG_id =" + req_id;
                }

                bool success = conn_devi.handout_update(query);
                if (success == false)
                {
                    notification_ = "Unsuccessful in updating, please try again.";
                }
                else
                {
                    notification_ = "Successfully updated!";

                    device_handed_out_grid.Enabled = true;
                    device_handout_pnl_edit.Visible = false;
                    device_handout_btn_cancel.Visible = false;
                    device_handout_btn_edit.Text = "EDIT";
                    sys_func.btn_active(device_handout_btn_edit);
                    device_handed_out_grid.DefaultCellStyle.ForeColor = Color.FromArgb(41, 45, 56);

                    load_handedout_data();
                    device_handout_clear();
                }
                show_success_message();
            }
        }

        private void device_handout_btn_cancel_Click(object sender, EventArgs e)
        {
            device_handed_out_grid.Enabled = true;
            device_handout_pnl_edit.Visible = false;
            device_handout_btn_cancel.Visible = false;
            device_handed_out_grid.DefaultCellStyle.ForeColor = Color.FromArgb(41, 45, 56);
            device_handout_btn_edit.Text = "EDIT";
            sys_func.btn_active(device_handout_btn_edit);
        }

        #endregion

        #endregion

        private void projects_disability_Click(object sender, EventArgs e)
        {
            disability_form_ = true;
            disability_form = new disability();
            disability_form.reference_to_main = this;
            shadow_ = new shadow();
            shadow_.reference_to_main = this;
            shadow_.form_to_show = disability_form;
            shadow_.ShowDialog();
            load_handedout_data();
            disability_form_ = false;
        }

        private void projects_history_Click(object sender, EventArgs e)
        {
            device_pnl_request_new.Visible = false;
            load_handedout_data();
        }


        #endregion

        #region REPORTS

        public DateTime from, to, end, start_t, end_t, dateTime;
        public int format, district_num, date, function;
        public string district, dev_stat, project, place, proposal;

        public void load_reports()
        {
            conn_rep.report_Grid(report_grid);
            conn_rep.device_grid(reports_device_grid);
            conn_rep.project_grid(reports_projects_grid);

            report_grid.ClearSelection();
            reports_device_grid.ClearSelection();
            reports_projects_grid.ClearSelection();

            device_status.SelectedIndex = 1;
            district_format.SelectedIndex = 0;
            btn_projects_persons_attendance.Enabled = false;
            date_format.Enabled = false;
            date_from.Visible = date_to.Visible = btn_ok.Visible = false;
            lbl_from.Visible = lbl_to.Visible = false;
        }

        public void hide_date()
        {
            lbl_to.Visible = lbl_from.Visible = false;
            date_to.Visible = date_from.Visible = false;
            btn_ok.Visible = false;
            date = 0;
        }
        private void main_form_Deactivate(object sender, EventArgs e)
        {
            if (notification_data_ == true) 
                system_notify.TopMost = false;
        }

        private void reports_btn_pwd_Click(object sender, EventArgs e)
        {
            reports_pnl_visible();
            reports_pnl_pwd.Visible = true;

            hide_date(); load_reports();
            date_format.Enabled = true;
        
            date_format.Items.Clear();
            string[] pwd = { "", "Weekly", "Monthly", "Yearly", "Custom" };
            date_format.Items.AddRange(pwd);
            function = 0;
        }

        private void reports_btn_device_referral_Click(object sender, EventArgs e)
        {
            reports_pnl_visible();
            reports_pnl_device.Visible = true;

            hide_date(); load_reports();
            date_format.Enabled = true;
            date_format.Items.Clear();
            string[] pwd = { "", "Weekly", "Monthly", "Yearly", "Custom" };
            date_format.Items.AddRange(pwd);
            function = 0;

        }

        private void reports_btn_projects_Click(object sender, EventArgs e)
        {
            reports_pnl_visible();
            reports_pnl_projects.Visible = true;

            hide_date(); load_reports();
            date_format.Enabled = true;
            date_format.Items.Clear();
            string[] proj = { "", "Monthly", "Yearly", "Custom" };
            date_format.Items.AddRange(proj);
            function = 1;
        }

        private void date_format_SelectedIndexChanged(object sender, EventArgs e)
        {
            date = date_format.SelectedIndex;
            if (function == 0)
            {
                if (date == 0)
                {
                    date_from.Visible = false;
                    date_to.Visible = false;
                    lbl_from.Visible = lbl_to.Visible = btn_ok.Visible = false;
                    conn_rep.report_Grid(report_grid);
                }
                else if (date == 1)
                {
                    //Weekly
                    date_to.Visible = true;
                    date_to.Format = DateTimePickerFormat.Custom;
                    date_to.CustomFormat = "MMMM dd, yyyy";

                    lbl_to.Text = "Start:";
                    date_from.Visible = lbl_from.Visible = false;
                    lbl_to.Visible = btn_ok.Visible = true;
                }
                else if (date == 2)
                {
                    //Monthly
                    date_from.Visible = true;
                    date_from.Format = DateTimePickerFormat.Custom;
                    date_from.CustomFormat = "MMMM";
                    date_from.ShowUpDown = true;
                    lbl_from.Text = "Month:";

                    date_to.Visible = true;
                    date_to.Format = DateTimePickerFormat.Custom;
                    date_to.CustomFormat = "yyyy";
                    date_to.ShowUpDown = true;
                    lbl_to.Text = "Year:";

                    lbl_from.Visible = lbl_to.Visible = btn_ok.Visible = true;
                }
                else if (date == 3)
                {
                    //Yearly
                    date_to.Visible = true;
                    date_to.Format = DateTimePickerFormat.Custom;
                    date_to.CustomFormat = "yyyy";
                    date_to.ShowUpDown = true;

                    lbl_to.Text = "Year:";
                    date_from.Visible = lbl_from.Visible = false;
                    lbl_to.Visible = btn_ok.Visible = true;
                }
                else if (date == 4)
                {
                    //Custom Date
                    date_from.Visible = date_to.Visible = true;
                    date_to.Format = date_from.Format = DateTimePickerFormat.Custom;
                    date_to.CustomFormat = date_from.CustomFormat = "MMMM dd, yyyy";
                    lbl_from.Visible = lbl_to.Visible = btn_ok.Visible = true;
                    lbl_from.Text = "From:";
                    lbl_to.Text = "To:";
                }
            }
            else if (function == 1)
            {
                if (date == 1)
                {
                    //Monthly
                    date_from.Visible = true;
                    date_from.Format = DateTimePickerFormat.Custom;
                    date_from.CustomFormat = "MMMM";
                    date_from.ShowUpDown = true;
                    lbl_from.Text = "Month";

                    date_to.Visible = true;
                    date_to.Format = DateTimePickerFormat.Custom;
                    date_to.CustomFormat = "yyyy";
                    date_to.ShowUpDown = true;
                    lbl_to.Text = "Year";

                    lbl_from.Visible = lbl_to.Visible = btn_ok.Visible = true;
                }
                else if (date == 2)
                {
                    //Yearly
                    date_to.Visible = true;
                    date_to.Format = DateTimePickerFormat.Custom;
                    date_to.CustomFormat = "yyyy";
                    date_to.ShowUpDown = true;

                    lbl_to.Text = "Year";
                    date_from.Visible = lbl_from.Visible = false;
                    lbl_to.Visible = btn_ok.Visible = true;
                }
                else if (date == 3)
                {
                    //Custom Date
                    date_from.Visible = date_to.Visible = true;
                    date_to.Format = date_from.Format = DateTimePickerFormat.Custom;
                    date_to.CustomFormat = date_from.CustomFormat = "MMMM dd, yyyy";
                    lbl_from.Visible = lbl_to.Visible = btn_ok.Visible = true;
                    lbl_from.Text = "From";
                    lbl_to.Text = "To";
                }
            }
        }

        private void district_format_SelectedIndexChanged(object sender, EventArgs e)
        {
            district_num = district_format.SelectedIndex;
            district = district_format.SelectedItem.ToString();

            if (date != 0) conn_rep.getDateQuery(report_grid, date, from, to, end, district_num);
            else conn_rep.getDistrictQuery(report_grid, district_num);
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            from = date_from.Value.Date;
            to = date_to.Value.Date;
            end = DateTime.Now;

            if (date == 1) end = to.AddDays(6);

            if (reports_pnl_pwd.Visible == true && reports_pnl_projects.Visible == false && reports_pnl_device.Visible == false)
                conn_rep.getDateQuery(report_grid, date, from, to, end, district_num);
            else if (reports_pnl_projects.Visible == true)
                conn_rep.date_project_format(reports_projects_grid, date, from, to);
        }

        private void device_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (device_status.SelectedIndex == 1) conn_rep.device_status_grid(reports_device_grid, "requested", from, to, end, date);
            else if (device_status.SelectedIndex == 2) conn_rep.device_status_grid(reports_device_grid, "handed out", from, to, end, date);
        }
        #region <-- PWD -->
        private void btn_pwd_exportPDF_Click(object sender, EventArgs e)
        {
            string file = "";
            string district_pass, date = "";
            save_pdf.Filter = "PDF files |*.pdf";
            save_pdf.DefaultExt = "*.pdf";
            save_pdf.FilterIndex = 1;
            save_pdf.ShowDialog();
            save_pdf.Title = "Export as PDF";

            #region << District & Date Format [PDF] >>
            if (lbl_from.Text == "From" && lbl_to.Text == "To" && date_from.CustomFormat == "MMMM dd, yyyy") //custom
            {
                date = from.ToString("MMMM dd") + " - " + to.ToString("MMMM dd yyyy");
            }
            else if (lbl_from.Text == "Month" && lbl_to.Text == "Year" && date_from.CustomFormat == "MMMM") //monthly
            {
                date = from.ToString("MMMM") + " " + to.ToString("yyyy");
            }
            else if (lbl_from.Visible == false && date_from.Visible == false && date_to.CustomFormat == "yyyy") //yearly
            {
                date = to.ToString("yyyy");
            }
            else if (lbl_to.Text == "START")
            {
                date = to.ToString("MMMM dd") + " - " + end.ToString("dd YYYY");
            }

            if (district == null) district_pass = "OVERALL";
            else district_pass = district_format.SelectedItem.ToString();
            #endregion

            file = save_pdf.FileName;

            if (file == "") ; //pass
            else
            {
                conn_rep.pwd_PDFReport(file, report_grid, district_pass, date);
                System.Diagnostics.Process.Start(file);
            }
            save_pdf.FileName = "";
        }

        private void btn_pwd_exportExcel_Click(object sender, EventArgs e)
        {
            string sheet = "", date = "";
            save_Excel.Filter = "Excel files |*.xlsx";
            save_Excel.DefaultExt = "*.xlsx";
            save_Excel.FilterIndex = 1;
            save_Excel.ShowDialog();
            save_Excel.Title = "Export as Excel Worksheet";

            #region << District & Date Format [PDF] >>
            if (lbl_from.Text == "From" && lbl_to.Text == "To" && date_from.CustomFormat == "MMMM dd, yyyy") //custom
            {
                date = from.ToString("MMMM dd") + " - " + to.ToString("MMMM dd yyyy");
            }
            else if (lbl_from.Text == "Month" && lbl_to.Text == "Year" && date_from.CustomFormat == "MMMM") //monthly
            {
                date = from.ToString("MMMM") + " " + to.ToString("yyyy");
            }
            else if (lbl_from.Visible == false && date_from.Visible == false && date_to.CustomFormat == "yyyy") //yearly
            {
                date = to.ToString("yyyy");
            }
            else if (lbl_to.Text == "START")
            {
                date = to.ToString("MMMM dd") + " - " + end.ToString("dd YYYY");
            }

            dateTime = DateTime.Now;
            #endregion

            sheet = save_Excel.FileName;
            if (sheet == "") ; //pass
            else
            {
                conn_rep.pwd_ExcelReport(sheet, dateTime);
                System.Diagnostics.Process.Start(sheet);
            }
            save_Excel.FileName = "";
        }
        #endregion

        #region <-- DEVICE -->
        private void btn_device_exportPDF_Click(object sender, EventArgs e)
        {
            string file = "";
            string date = "";
            save_pdf.Filter = "PDF files |*.pdf";
            save_pdf.DefaultExt = "*.pdf";
            save_pdf.FilterIndex = 1;
            save_pdf.ShowDialog();
            save_pdf.Title = "Export as PDF";

            #region << Date Format [PDF] >>
            if (lbl_from.Text == "From" && lbl_to.Text == "To" && date_from.CustomFormat == "MMMM dd, yyyy") //custom
            {
                date = from.ToString("MMMM dd") + " - " + to.ToString("MMMM dd yyyy");
            }
            else if (lbl_from.Text == "Month" && lbl_to.Text == "Year" && date_from.CustomFormat == "MMMM") //monthly
            {
                date = from.ToString("MMMM") + " " + to.ToString("yyyy");
            }
            else if (lbl_from.Visible == false && date_from.Visible == false && date_to.CustomFormat == "yyyy") //yearly
            {
                date = to.ToString("yyyy");
            }
            else if (lbl_to.Text == "Start") // weekly
            {
                date = to.ToString("MMMM dd") + " - " + end.ToString("MMMM dd yyyy");
            }

            dev_stat = device_status.SelectedItem.ToString();
            #endregion

            file = save_pdf.FileName;

            if (file == "") ; //pass
            else
            {
                conn_rep.device_PDF(file, date, reports_device_grid, dev_stat);
                System.Diagnostics.Process.Start(file);
            }
            save_pdf.FileName = "";
        }
        #endregion

        #region <-- PROJECTS -->
        private void reports_btn_project_summary_Click(object sender, EventArgs e)
        {
            string file = "";
            string date = "";
            save_pdf.Filter = "PDF files |*.pdf";
            save_pdf.DefaultExt = "*.pdf";
            save_pdf.FilterIndex = 1;
            save_pdf.ShowDialog();
            save_pdf.Title = "Export as PDF";

            #region << Date & Time Format [PDF] >>
            if (lbl_from.Text == "From" && lbl_to.Text == "To" && date_from.CustomFormat == "MMMM dd, yyyy") //custom
            {
                date = from.ToString("MMMM dd") + " - " + to.ToString("MMMM dd yyyy");
            }
            else if (lbl_from.Text == "Month" && lbl_to.Text == "Year" && date_from.CustomFormat == "MMMM") //monthly
            {
                date = from.ToString("MMMM") + " " + to.ToString("yyyy");
            }
            else if (lbl_from.Visible == false && date_from.Visible == false && date_to.CustomFormat == "yyyy") //yearly
            {
                date = to.ToString("yyyy");
            }
            #endregion

            file = save_pdf.FileName;

            if (file == "") ; //pass
            else
            {
                conn_rep.project_reportPDF(file, date, reports_projects_grid);
                System.Diagnostics.Process.Start(file);
            }
            save_pdf.FileName = "";
        }
        private void reports_btn_project_participants_Click(object sender, EventArgs e)
        {
            string file = "";
            save_pdf.Filter = "PDF files |*.pdf";
            save_pdf.DefaultExt = "*.pdf";
            save_pdf.FilterIndex = 1;
            save_pdf.ShowDialog();
            save_pdf.Title = "Export as PDF";

            string time = start_t.ToString("hh:mm") + " - " + end_t.ToString("hh:mm");
            file = save_pdf.FileName;
            if (file == "") ; //pass
            else
            {
                conn_rep.project_attendance(file, project, proposal, place, time);
                System.Diagnostics.Process.Start(file);
            }

            save_pdf.FileName = "";
        }
        private void reports_projects_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_projects_persons_attendance.Enabled = true;

            DataGridViewRow row = this.reports_projects_grid.Rows[e.RowIndex];
            project = row.Cells["project_title"].Value.ToString();
            place = row.Cells["event_held"].Value.ToString();
            proposal = row.Cells["date_proposed"].Value.ToString();
            start_t = Convert.ToDateTime(row.Cells["start_time"].Value.ToString());
            end_t = Convert.ToDateTime(row.Cells["end_time"].Value.ToString());

            conn_rep.getProjectID(project);
        }
        #endregion

        #endregion


        #endregion

        #region ACCOUNTS
        //ACCOUNTS
        bool has_accounts = false;
        public void load_accounts()
        {
            has_accounts = conn_user.get_user_data(accounts_grid);
            accounts_clear_view();
            if (has_accounts == false)
            {
                accounts_grid.Columns["firstname"].Visible = false;
                accounts_grid.Columns["middlename"].Visible = false;
                accounts_grid.Columns["lastname"].Visible = false;
                accounts_grid.Columns["position"].Visible = false;
                accounts_grid.Columns["fullname"].Visible = false;
                accounts_grid.Columns["contact_no"].Visible = false;
                accounts_grid.Columns["status_id"].Visible = false;
                accounts_grid.Columns["password"].Visible = false;
                accounts_grid.Columns["username"].Visible = false;
                accounts_grid.Columns["user_id"].Visible = false;
                accounts_grid.Columns["display_text"].HeaderText = "Results";
            } else
            {
                accounts_grid.Columns["firstname"].Visible = false;
                accounts_grid.Columns["middlename"].Visible = false;
                accounts_grid.Columns["lastname"].Visible = false;
                accounts_grid.Columns["fullname"].HeaderText = "Fullname";
                accounts_grid.Columns["position"].HeaderText = "Position";
                accounts_grid.Columns["contact_no"].Visible = false;
                accounts_grid.Columns["status_id"].Visible = false;
                accounts_grid.Columns["password"].Visible = false;
                accounts_grid.Columns["username"].HeaderText = "Username";
                accounts_grid.Columns["user_id"].Visible = false;
                accounts_grid.Columns["display_text"].Visible = false;
            }

            accounts_cell_color();
        }
        int accounts_current_index = 0;

        private void accounts_grid_SelectionChanged(object sender, EventArgs e)
        {
            if  (accounts_grid.Rows.Count < 0 || has_accounts == false )
            {
                sys_func.btn_inactive(accounts_btn_edit);
                sys_func.btn_inactive(accounts_btn_save);
            } else
            {
                try
                {
                    accounts_current_index = accounts_grid.CurrentCell.RowIndex;
                } catch (Exception ex)
                {
                    Console.WriteLine(accounts_current_index);
                    accounts_current_index = 0;
                }
                accounts_selection();
            }
        }

        public void accounts_selection()
        {
            accounts_name.Text = accounts_grid.Rows[accounts_current_index].Cells["fullname"].Value.ToString();
            accounts_type.Text = accounts_grid.Rows[accounts_current_index].Cells["position"].Value.ToString();
            accounts_contact_no.Text = accounts_grid.Rows[accounts_current_index].Cells["contact_no"].Value.ToString();
            accounts_status.Text = accounts_grid.Rows[accounts_current_index].Cells["status_id"].Value.ToString();
            accounts_username.Text = accounts_grid.Rows[accounts_current_index].Cells["username"].Value.ToString();

            accounts_edit_firstname.Text = accounts_grid.Rows[accounts_current_index].Cells["firstname"].Value.ToString();
            accounts_edit_middlename.Text = accounts_grid.Rows[accounts_current_index].Cells["middlename"].Value.ToString();
            accounts_edit_lastname.Text = accounts_grid.Rows[accounts_current_index].Cells["lastname"].Value.ToString();
            accounts_edit_account_type.Text = accounts_grid.Rows[accounts_current_index].Cells["position"].Value.ToString();
            accounts_edit_contact_no.Text = accounts_grid.Rows[accounts_current_index].Cells["contact_no"].Value.ToString();
            accounts_edit_status.Text = accounts_grid.Rows[accounts_current_index].Cells["status_id"].Value.ToString();
            accounts_edit_password.Text = accounts_grid.Rows[accounts_current_index].Cells["password"].Value.ToString();
            accounts_edit_username.Text = accounts_grid.Rows[accounts_current_index].Cells["username"].Value.ToString();

        }

        public bool accounts_add_check_required()
        {
            bool all_required = false;
            if (accounts_add_firstname.Text.Trim() == "" || accounts_add_middlename.Text.Trim() == ""
                || accounts_add_lastname.Text.Trim() == "" || accounts_add_account_type.Text.Trim() == ""
                || accounts_add_status.Text.Trim() == "" || accounts_add_username.Text.Trim() == ""
                || accounts_add_password.Text.Trim() == "" || (accounts_add_username.Text.Length < 6 || accounts_add_username.Text.Length > 12) ||
                (accounts_add_password.Text.Length < 8 || accounts_add_password.Text.Length > 16) || accounts_add_lbl_username_error.Visible == true)
            {
                all_required = false;
                sys_func.btn_inactive(accounts_btn_add);
            } else
            {
                all_required = true;
                sys_func.btn_active(accounts_btn_add);
            }
            return all_required;
        }

        public bool accounts_edit_check_required()
        {
            bool all_required = false;
            if (accounts_edit_firstname.Text.Trim() == "" || accounts_edit_middlename.Text.Trim() == ""
                || accounts_edit_lastname.Text.Trim() == "" || accounts_edit_account_type.Text.Trim() == ""
                || accounts_edit_status.Text.Trim() == "" || accounts_edit_username.Text.Trim() == ""
                || accounts_edit_password.Text.Trim() == "" || (accounts_edit_username.Text.Length < 6 || accounts_edit_username.Text.Length > 12) ||
                (accounts_edit_password.Text.Length < 8 || accounts_edit_password.Text.Length > 16) 
                || accounts_username.Text == "--" || accounts_edit_lbl_user_error.Visible == true)
            {
                all_required = false;
                sys_func.btn_inactive(accounts_btn_save);
            }
            else
            {
                all_required = true;
                sys_func.btn_active(accounts_btn_save);
            }
            return all_required;
        }

        public void accounts_add_clear()
        {
            accounts_add_firstname.Clear();
            accounts_add_middlename.Clear();
            accounts_add_lastname.Clear();
            accounts_add_account_type.SelectedIndex = 0;
            accounts_add_contact_no.Clear();
            accounts_add_status.SelectedIndex = 0;
            accounts_add_username.Clear();
            accounts_add_password.Clear();
        }

        public void accounts_edit_clear()
        {
            accounts_edit_firstname.Clear();
            accounts_edit_middlename.Clear();
            accounts_edit_lastname.Clear();
            accounts_edit_account_type.SelectedIndex = 0;
            accounts_edit_contact_no.Clear();
            accounts_edit_status.SelectedIndex = 0;
            accounts_edit_username.Clear();
            accounts_edit_password.Clear();
        }

        private void accounts_add_firstname_TextChanged(object sender, EventArgs e)
        {
            accounts_add_check_required();
        }

        private void accounts_add_middlename_TextChanged(object sender, EventArgs e)
        {
            accounts_add_check_required();
        }

        private void accounts_add_lastname_TextChanged(object sender, EventArgs e)
        {
            accounts_add_check_required();
        }

        private void accounts_add_account_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            accounts_add_check_required();
        }

        private void accounts_add_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            accounts_add_check_required();
        }

        private void accounts_add_username_TextChanged(object sender, EventArgs e)
        {
            accounts_add_check_required();
            bool has_duplicate = conn_user.user_has_duplicate(accounts_add_username.Text, "");
            if (has_duplicate == true)
            {
                accounts_add_lbl_username_error.Visible = true;
            }
            else
            {
                accounts_add_lbl_username_error.Visible = false;
            }
        }

        private void accounts_add_password_TextChanged(object sender, EventArgs e)
        {
            accounts_add_check_required();
        }

        private void accounts_btn_edit_Click(object sender, EventArgs e)
        {
            accounts_pnl_edit.Visible = true;
            sys_func.btn_inactive(accounts_btn_save);
            accounts_grid.Enabled = false;
        }

        private void accounts_btn_save_Click(object sender, EventArgs e)
        {
            string firstname = accounts_edit_firstname.Text;
            string middlename = accounts_edit_middlename.Text;
            string lastname = accounts_edit_lastname.Text;
            string position = (accounts_edit_account_type.SelectedIndex).ToString();
            string contact_no = accounts_edit_contact_no.Text;
            string status_id = accounts_edit_status.SelectedIndex.ToString();
            string username = accounts_edit_username.Text;
            string password = accounts_edit_password.Text;
            string user_id = accounts_grid.Rows[accounts_current_index].Cells["user_id"].Value.ToString();
            bool success = conn_user.update_user(firstname, middlename, lastname, position, contact_no, status_id, username, password, user_id);

            if (success == false)
            {
                notification_ = "Invalid values, please try again.";
            } else
            {
                notification_ = "Updated user successfully!";
                accounts_edit_clear();
                accounts_grid.Enabled = true;
                load_accounts();
            }
            show_success_message();
        }

        private void accounts_btn_add_Click(object sender, EventArgs e)
        {
            string firstname = accounts_add_firstname.Text;
            string middlename = accounts_add_middlename.Text;
            string lastname = accounts_add_lastname.Text;
            string position = (accounts_add_account_type.SelectedIndex).ToString();
            string contact_no = accounts_add_contact_no.Text;
            string status_id = accounts_add_status.SelectedIndex.ToString();
            string username = accounts_add_username.Text;
            string password = accounts_add_password.Text;

            bool success = conn_user.add_user(firstname, middlename, lastname, position, contact_no, status_id, username, lastname);
            if (success == false)
            {
                notification_ = "Invalid values, please try again.";
            } else
            {
                notification_ = "Added user successfully!";
                accounts_add_clear();
                load_accounts();
            }
            show_success_message();

        }

        private void accounts_refresh_Click(object sender, EventArgs e)
        {
            accounts_clear_view();
            load_accounts();
        }

        public void accounts_clear_view()
        {
            accounts_name.Text = "--";
            accounts_type.Text = "--";
            accounts_contact_no.Text = "--";
            accounts_status.Text = "--";
            accounts_username.Text = "--";
        }

        private void accounts_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || has_accounts == false)
            {
                sys_func.btn_inactive(accounts_btn_edit);
                accounts_clear_view();
            } else
            {
                accounts_current_index = e.RowIndex;
                sys_func.btn_active(accounts_btn_edit);
                accounts_selection();
            }
        }

        private void accounts_btn_cancel_Click(object sender, EventArgs e)
        {
            accounts_pnl_edit.Visible = false;
            accounts_grid.Enabled = true;
        }

        private void accounts_edit_firstname_TextChanged(object sender, EventArgs e)
        {
            accounts_edit_check_required();
        }

        private void accounts_edit_middlename_TextChanged(object sender, EventArgs e)
        {
            accounts_edit_check_required();
        }

        private void accounts_edit_lastname_TextChanged(object sender, EventArgs e)
        {
            accounts_edit_check_required();
        }

        private void accounts_edit_account_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            accounts_edit_check_required();
        }

        private void accounts_edit_contact_no_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            accounts_edit_check_required();
        }

        private void accounts_edit_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            accounts_edit_check_required();
        }

        private void accounts_edit_username_TextChanged(object sender, EventArgs e)
        {
            accounts_edit_check_required();
            if (accounts_edit_username.Text == "admin" && accounts_username.Text == "admin")
            {
                accounts_edit_username.Enabled = false;
                accounts_lbl_admin.Visible = true;
            }
            else
            {
                accounts_edit_username.Enabled = true;
                accounts_lbl_admin.Visible = false;
                bool has_duplicate = conn_user.user_has_duplicate(accounts_edit_username.Text, accounts_username.Text);
                if (has_duplicate == true)
                {
                    accounts_edit_lbl_user_error.Visible = true;
                } else
                {
                    accounts_edit_lbl_user_error.Visible = false;
                }
            }
        }

        private void accounts_edit_password_TextChanged(object sender, EventArgs e)
        {
            accounts_edit_check_required();
        }
        public void accounts_cell_color()
        {
            int count = accounts_grid.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                if (accounts_grid.Rows[i].Cells["status_id"].Value.ToString() == "Inactive") 
                {
                    accounts_grid.Rows[i].DefaultCellStyle.BackColor = Color.Salmon;
                    accounts_grid.Rows[i].DefaultCellStyle.SelectionBackColor = Color.Tomato;
                }
                if (accounts_grid.Rows[i].Cells["status_id"].Value.ToString() == "Break")
                {
                    accounts_grid.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 128);
                    accounts_grid.Rows[i].DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 128, 0);
                } 
                if (accounts_grid.Rows[i].Cells["status_id"].Value.ToString() == "Active")
                {
                    accounts_grid.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(128, 255, 128);
                    accounts_grid.Rows[i].DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 255, 0);
                }

            }
        }
        #endregion

        #region NOTIFICATION
        private void notification_grid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            notification_grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
        }

        private void notification_grid_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (has_notification)
            {
                notification_grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.FromArgb(224, 224, 224);
            }
            else
            {
                notification_grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
            }
        }

        private void notification_grid_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            notification_grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
        }

        private void notification_grid_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            notification_grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
        }

        notifications_form notif_form;

        private void notification_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string type_notif = notification_grid.Rows[e.RowIndex].Cells["type_notif"].Value.ToString();
            if (type_notif == "0" )
            {
                notif_form = new notifications_form();
                notif_form.reference_to_main = this;
                shadow_ = new shadow();
                shadow_.reference_to_main = this;
                shadow_.form_to_show = notif_form;
                shadow_.ShowDialog();
                notification_grid.Rows[e.RowIndex].Cells["type_clicked"].Value = "1";
                conn_noti.initial_font();
                notification_grid.ClearSelection();
            }

            for (int i = 0; i < notification_grid.Rows.Count; i++)
            {
                string clicked = notification_grid.Rows[i].Cells["type_clicked"].Value.ToString();

                btn_notification.BackColor = Color.Transparent;
                if (clicked == "0")
                {
                    has_notification = true;
                    btn_notification.BackColor = Color.Red;
                    break;
                }
            }
        }

        #endregion

        private void projects_grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            project_add view_project = new project_add();
            view_project.view_mode = true;
            view_project.id_ = projects_grid.Rows[e.RowIndex].Cells["project_id"].Value.ToString();
            view_project.reference_to_main = this;
            shadow_ = new shadow();
            shadow_.reference_to_main = this;
            shadow_.form_to_show = view_project;
            shadow_.ShowDialog();
        }
    }
}
