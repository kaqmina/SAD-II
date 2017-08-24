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
        connections_pwd conn_pwd = new connections_pwd();
        connections_project conn_proj = new connections_project();
        shadow shadow_;
        pwd_archive show_prompt;
        system_notification system_notify;
        public string current_user;

        #region FORM-LOAD

        private void main_form_Load(object sender, EventArgs e)
        {
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
            conn_pwd.populate_cbox(pwd_combobox_disability, pwd_combobox_district);

            load_projects();
            projects_default_data();

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
            pwd_grid.ClearSelection();
            pwd_format();

            pwd_load_row_count();
        }

        public void pwd_load_row_count()
        {
            pwd_grid_row_count.Text = pwd_grid.Rows.Count.ToString();
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
            pwd_grid.Columns["age"].HeaderText = "Age";

            pwd_grid.Columns["registration_no"].Width = 90;
            pwd_grid.Columns["sex"].Width = 40;
            pwd_grid.Columns["age"].Width = 40;
            pwd_cell_color();
        }

        #endregion

        #region FORM-ACTIVATED
        bool pwd_archive = false;

        private void main_form_Activated(object sender, EventArgs e)
        {
            if (pwd_archive == true)
            {
                this.BringToFront();
                show_prompt.BringToFront();
            }
        }

        #endregion

        #region PWD-GRID
        int current_pwd_id = 0;
        int current_pwd_grid_index = 0;

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
                current_pwd_grid_index = e.RowIndex;
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
            shadow_.Location = new Point(this.Location.X, this.Location.Y);
            show_prompt.current_id = current_pwd_id;
            show_prompt.reference_to_main = this;
            show_prompt.regis_no.Text = "Registration#: " + pwd_grid.Rows[current_pwd_grid_index].Cells["registration_no"].Value.ToString();
            show_prompt.name.Text = "Name: " + pwd_grid.Rows[current_pwd_grid_index].Cells["fullname"].Value.ToString();
            show_prompt.app_date.Text = "Application_date: " + pwd_grid.Rows[current_pwd_grid_index].Cells["application_date"].Value.ToString();
            show_prompt.prompt_title.Text = "Archive";
            show_prompt.action.Text = "The following profile will be archived:";
            shadow_.Show();
            Console.WriteLine("[PWD] ->> [ARCHIVE-MODE]");
            show_prompt.ShowDialog();
            shadow_.Close();
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
            if (pwd_searchbox.Text.Trim() != "")
            {
                conn_pwd.pwd_search(pwd_grid, pwd_searchbox);
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
            pwd_grid_filter_multiple();
            if(pwd_filter_ == true)
            {
                Console.WriteLine("PWD_FILTER_MULTIPLE " + pwd_gender_ + " " + pwd_status_);
                conn_pwd.filter_status_gender(pwd_status_, pwd_gender_, pwd_grid);
            } else
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
        #endregion

        #region NOTIFICATIONS

        public string notification_;

        public void show_success_message()
        {
            //827, 531
            success = false;
            system_notify = new system_notification();
            system_notify.Location = new Point(this.Location.X + 827, this.Location.Y + 531);
            system_notify.notification_message = notification_;
            system_notify.Show();
            notification_ = "";
        }

        public void load_notifications()
        {
            pnl_notif_pp.Visible = false;
            pnl_notif_pp.BringToFront();
            pnl_notif_pp.Size = new Size(299, 233);
            pnl_notif_pp.Location = new Point(838, 28);
        }

        bool show_notif = false;

        private void btn_notification_Click(object sender, EventArgs e)
        {
            if (show_notif == false)
            {
                show_notif = true;
                pnl_notif_pp.Visible = true;
                btn_notification.BackColor = btn_notification.FlatAppearance.MouseDownBackColor;
            }
            else
            {
                show_notif = false;
                pnl_notif_pp.Visible = false;
                btn_notification.BackColor = Color.Transparent;
            }
        }

        #endregion

        public void load_projects()
        {
            conn_proj.project_grid_list(projects_grid);
            projects_format();

            project_load_row_count();
        }

        public void projects_format()
        {
            projects_grid.Columns["project_title"].HeaderText = "Title";
            projects_grid.Columns["start_time"].HeaderText = "Start Time";
            projects_grid.Columns["end_time"].HeaderText = "End Time";
            projects_grid.Columns["date_proposed"].HeaderText = "Date Proposed";

            projects_grid.Columns["project_desc"].Visible = false;
            projects_grid.Columns["items_id"].Visible = false;
            projects_grid.Columns["progress_id"].Visible = false;
            projects_grid.Columns["approved_by"].Visible = false;
            projects_grid.Columns["event_held"].Visible = false;
            projects_grid.Columns["budget"].Visible = false;
            projects_grid.Columns["budget_desc"].Visible = false;
            projects_grid.Columns["isArchived"].Visible = false;
            projects_grid.Columns["project_id"].Visible = false;
            projects_grid.Columns["employee_id"].Visible = false;
        }

        public int current_project_id = 0;
        int current_project_grid_index = 0;

        public void projects_paste_data()
        {
            DataTable main_data = new DataTable();
            DataTable item_data = new DataTable();
            conn_proj.project_data_load(current_project_id, main_data, item_data);

            project_title.ForeColor = Color.Black;
            project_description.ForeColor = Color.Black;
            project_start_time.ForeColor = Color.Black;
            project_end_time.ForeColor = Color.Black;
            project_date_proposed.ForeColor = Color.Black;
            project_approved_by.ForeColor = Color.Black;
            project_event_held.ForeColor = Color.Black;
            project_budget.ForeColor = Color.Black;
            project_budget_description.ForeColor = Color.Black;

            Font def = new Font("Segoe UI", 9);

            project_title.Font = new Font(def, FontStyle.Bold);
            project_description.Font = new Font(def, FontStyle.Bold);
            project_start_time.Font = new Font(def, FontStyle.Bold);
            project_end_time.Font = new Font(def, FontStyle.Bold);
            project_date_proposed.Font = new Font(def, FontStyle.Bold);
            project_approved_by.Font = new Font(def, FontStyle.Bold);
            project_event_held.Font = new Font(def, FontStyle.Bold);
            project_budget.Font = new Font(def, FontStyle.Bold); ;
            project_budget_description.Font = new Font(def, FontStyle.Bold);

            project_title.Text = main_data.Rows[0]["project_title"].ToString();
            project_description.Text = main_data.Rows[0]["project_desc"].ToString();
            project_start_time.Text = main_data.Rows[0]["start_time"].ToString();
            project_end_time.Text = main_data.Rows[0]["end_time"].ToString();
            project_date_proposed.Text = main_data.Rows[0]["date_proposed"].ToString();
            project_approved_by.Text = main_data.Rows[0]["approved_by"].ToString();
            project_event_held.Text = main_data.Rows[0]["event_held"].ToString();
            project_budget.Text = main_data.Rows[0]["budget"].ToString();
            project_budget_description.Text = main_data.Rows[0]["budget_desc"].ToString();

            project_items_grid.DataSource = item_data;
            project_load_item_row_count();

            project_items_grid.Columns["item_name"].HeaderText = "Name";
            project_items_grid.Columns["item_desc"].HeaderText = "Description";
            project_items_grid.Columns["cost"].HeaderText = "Price";
            project_items_grid.Columns["quantity"].HeaderText = "Quantity";

            project_items_grid.Columns["items_id"].Visible = false;
            project_items_grid.Columns["project_id"].Visible = false;

            
        }


        public void projects_default_data()
        {
            string default_text = "No item selected.";

            project_title.ForeColor = Color.Silver;
            project_description.ForeColor = Color.Silver;
            project_start_time.ForeColor = Color.Silver;
            project_end_time.ForeColor = Color.Silver;
            project_date_proposed.ForeColor = Color.Silver;
            project_approved_by.ForeColor = Color.Silver;
            project_event_held.ForeColor = Color.Silver;
            project_budget.ForeColor = Color.Silver;
            project_budget_description.ForeColor = Color.Silver;

            Font def = new Font("Segoe UI", 9);

            project_title.Font = new Font(def, FontStyle.Italic);
            project_description.Font = new Font(def, FontStyle.Italic);
            project_start_time.Font = new Font(def, FontStyle.Italic);
            project_end_time.Font = new Font(def, FontStyle.Italic);
            project_date_proposed.Font = new Font(def, FontStyle.Italic);
            project_approved_by.Font = new Font(def, FontStyle.Italic);
            project_event_held.Font = new Font(def, FontStyle.Italic);
            project_budget.Font = new Font(def, FontStyle.Italic); ;
            project_budget_description.Font = new Font(def, FontStyle.Italic);

            project_title.Text = default_text;
            project_description.Text = default_text;
            project_start_time.Text = default_text;
            project_end_time.Text = default_text;
            project_date_proposed.Text = default_text;
            project_approved_by.Text = default_text;
            project_event_held.Text = default_text;
            project_budget.Text = default_text;
            project_budget_description.Text = default_text;
        }

        private void projects_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            current_project_id = int.Parse(projects_grid.Rows[e.RowIndex].Cells["project_id"].Value.ToString());
            current_project_grid_index = e.RowIndex;

            if (e.RowIndex < 0)
            {
                //nothing
            }
            else
            {
                projects_paste_data();
            }
        }

        public void project_load_row_count()
        {
            project_grid_row_count.Text = projects_grid.Rows.Count.ToString();
        }

        public void project_load_item_row_count()
        { 
            project_item_grid_row_count.Text = "Results : " + project_items_grid.Rows.Count.ToString();
        }
    }
}
