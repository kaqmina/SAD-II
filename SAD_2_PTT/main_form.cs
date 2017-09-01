using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;

using System.IO;
namespace SAD_2_PTT
{
    public partial class main_form : Form
    {

        public main_form()
        {
            InitializeComponent();

        }
        main_functions main_func = new main_functions();
        main_btn_active main_btn = new main_btn_active();
        connections conn = new connections();
        connections_settings setting = new connections_settings();
       
        //project proj = new project();
        public string current_user;

        #region FormControlBox CB - 00

        private void btn_close_Click(object sender, EventArgs e)
        {
            main_func.btn_close(this);
        }

        #endregion

        #region MainButtonActivation MB - 00 --> PP DB PWD DR PM RP ST
        public Button btn_current;

        private void btn_profilepic_Click(object sender, EventArgs e) //fix
        {
            //main_btn.btn_method(btn_current, btn_profilepic);
            //btn_current = btn_profilepic;
            //main_btn.btn_profilepic = true;
            //slide_out.Start();
        }

        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            main_btn.btn_method(btn_current, btn_dashboard);
            pnl_deactivate(btn_current.Name);
            btn_current = btn_dashboard;
            lbl_current_text("dashboard");
            main_btn.btn_dashboard = true;
        }

        private void btn_pwd_Click(object sender, EventArgs e)
        {
            main_btn.btn_method(btn_current, btn_pwd);
            pnl_deactivate(btn_current.Name);
            btn_current = btn_pwd;
            lbl_current_text("pwd");
            main_btn.btn_pwd = true;

            //btn_profilepic.BackgroundImage = SAD_2_PTT.Properties.Resources.TWICE_SG_01;
            // btn_profilepic.BackColor = Color.FromArgb(10, 32, 81);
            //slide_out.Start();
        }

        private void btn_device_Click(object sender, EventArgs e)
        {
            main_btn.btn_method(btn_current, btn_device);
            pnl_deactivate(btn_current.Name);
            btn_current = btn_device;
            lbl_current_text("devices");
            main_btn.btn_device = true;
            //  btn_profilepic.BackgroundImage = SAD_2_PTT.Properties.Resources.BLACKPINK_01;
            // btn_profilepic.BackColor = Color.FromArgb(0, 0, 0);
            //slide_out.Start();
        }

        private void btn_projects_Click(object sender, EventArgs e)
        {
            main_btn.btn_method(btn_current, btn_project);
            pnl_deactivate(btn_current.Name);
            btn_current = btn_project;
            lbl_current_text("projects");
            main_btn.btn_project = true;
            //slide_out.Start();
        }

        private void btn_reports_Click(object sender, EventArgs e)
        {
            main_btn.btn_method(btn_current, btn_reports);
            pnl_deactivate(btn_current.Name);
            btn_current = btn_reports;
            lbl_current_text("reports");
            main_btn.btn_report = true;
            //slide_out.Start();
        }

        private void btn_settings_Click(object sender, EventArgs e)
        {
            main_btn.btn_method(btn_current, btn_settings);
            pnl_deactivate(btn_current.Name);
            btn_current = btn_settings;
            lbl_current_text("settings");
            main_btn.btn_settings = true;
            //slide_out.Start();
        }
        #endregion

        #region FormLoad
        private void main_form_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            btn_current = btn_dashboard;
            btn_dashboard_Click(sender, e);
            main_properties();
            string date = DateTime.Now.ToString("MMMM dd, yyyy");
            date_today.Text = date.ToUpper();
            lbl_current_text("dashboard");
            startup_opacity.Start();
            pwd_data();
            pnl_notif_pp.BringToFront();
            lbl_name.Text = "Hi, " + current_user.ToUpper() + ".";

            //<-----[ PROJECT ] ----->
            //proj.project_grid(projects_grid_list);

            //<-----[ SETTINGS ] ----->
            setting.employee_list(settings_list_full);
            user_prompt.Visible = pass_prompt.Visible = false;
            pnl_manage.Visible = info_grid.Visible = false;
            pnl_form.Visible = pnl_form2.Visible = false;
            pnl_main.Visible = settings_list_full.Visible = true;
            btn_to_update.Visible = btn_arch.Visible = btn_back.Visible = false;
            bdate.Value = DateTime.Now;

            settings_list_full.ClearSelection();

            //<-----[ DEVICE ] ----->
            conn.device_out_grid(device_grid);
            device_grid.ClearSelection();
            device_edit.Enabled = false;
          
        }

        private void main_properties()
        {
            int x = 1069;
            int y = 589;

            //size
            main_tab.Size = new Size(71, 608); //283, 608 <-- main_tab Size
            side_tab.Size = new Size(71, 608); //1069, 589 <-- panels
            pnl_dashboard.Size = new Size(x, y);
            pnl_pwd.Size = new Size(x, y);
            pnl_notif_pp.Size = new Size(302, 233);
            pnl_devices.Size = new Size(x, y);
            pnl_projects.Size = new Size(x, y);
            pnl_reports.Size = new Size(x, y);
            pnl_profile.Size = new Size(x, y);
            pnl_settings.Size = new Size(x, y);

            bool status = false;
            //visibility
            pnl_pwd.Visible = status;
            pnl_notif_pp.Visible = status;
            pnl_devices.Visible = status;
            pnl_reports.Visible = status;
            pnl_projects.Visible = status;
            pnl_profile.Visible = status;
            pnl_settings.Visible = status;

            x = 0;
            y = 50;
            //location
            pnl_dashboard.Location = new Point(x, y);
            pnl_pwd.Location = new Point(x, y);
            pnl_notif_pp.Location = new Point(767, 50);
            pnl_devices.Location = new Point(x, y);
            pnl_reports.Location = new Point(x, y);
            pnl_projects.Location = new Point(x, y);
            pnl_profile.Location = new Point(x, y);
            pnl_settings.Location = new Point(x, y);

        }

        private void startup_opacity_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
                this.Opacity += 0.1;
            else
                startup_opacity.Stop();
        }
        #endregion

        #region Timers - Slide_in and Slide_out TM - 00

        private void slide_out_Tick(object sender, EventArgs e)
        {
            while (main_tab.Width <= 283)
            {
                main_tab.Width = main_tab.Width + 3;
            }

            slide_out.Stop();
        }

        private void slide_in_Tick(object sender, EventArgs e)
        {
            while (main_tab.Width >= 71)
            {
                main_tab.Width = main_tab.Width - 3;
            }

            slide_in.Stop();
        }


        #endregion

        #region FormDrag FD - 00
        public Point mouseLocation;

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

        #region CurrentPanel - 00
        public void lbl_current_text(string activate)
        {
            if (activate == "dashboard")
            {
                lbl_current.Text = "PDAO Software";
                pnl_dashboard.Visible = true;
            }
            else if (activate == "pwd")
            {
                lbl_current.Text = "MEMBERSHIP";
                pnl_pwd.Visible = true;
            }
            else if (activate == "devices")
            {
                lbl_current.Text = "ASSISTIVE DEVICE";
                pnl_devices.Visible = true;
            }
            else if (activate == "projects")
            {
                lbl_current.Text = "PROJECTS";
                pnl_projects.Visible = true;
            }
            else if (activate == "reports")
            {
                lbl_current.Text = "REPORTS";
                pnl_reports.Visible = true;
            }
            else if (activate == "settings")
            {
                lbl_current.Text = "SETTINGS";
                pnl_settings.Visible = true;
            }
            else
            {
                lbl_current.Text = " ";
            }
        }

        private void pnl_deactivate(string deactivate)
        {
            if (deactivate == "btn_dashboard")
            {
                pnl_dashboard.Visible = false;
            }
            else if (deactivate == "btn_pwd")
            {
                pnl_pwd.Visible = false;
            }
            else if (deactivate == "btn_device")
            {
                pnl_devices.Visible = false;
            }
            else if (deactivate == "btn_project")
            {
                pnl_projects.Visible = false;
            }
            else if (deactivate == "btn_report")
            {
                pnl_reports.Visible = false;
            }
            else if (deactivate == "btn_settings")
            {
                pnl_settings.Visible = false;
            }
            else
            {

            }
        }

        #endregion

        #region NotificationProfie NP - 123 //FIX PROFILE

        public bool pnl_n_pp = false;

        private void btn_notification_Click(object sender, EventArgs e)
        {
            if (pnl_n_pp == false)
            {
                pnl_notif_pp.Visible = true;
                btn_notification.Image = SAD_2_PTT.Properties.Resources.notification_bell_active;
                main_btn.btn_notif_pp_active(btn_notification);
                pnl_n_pp = true;
            }
            else
            {
                pnl_notif_pp.Visible = false;
                btn_notification.Image = SAD_2_PTT.Properties.Resources.notification_deactivated;
                main_btn.btn_notif_pp_deactivate(btn_notification);
                pnl_n_pp = false;
            }
        }

        private void btn_notification_MouseHover(object sender, EventArgs e)
        {
            btn_notification_Click(sender, e);
        }

        private void pnl_notif_pp_MouseLeave(object sender, EventArgs e)
        {
            //main_btn.btn_notif_pp_deactivate(btn_notification);
            //btn_notification.Image = SAD_2_PTT.Properties.Resources.notification_deactivated;
            //pnl_notif_pp.Visible = false;
            //pnl_n_pp = false;
        }

        private void btn_profile_Click(object sender, EventArgs e) //FIX
        {
            /*if (pnl_n_pp == false)
            {
                pnl_notif_pp.Visible = true;
                main_btn.btn_notif_pp_active(btn_profile);
                pnl_n_pp = true;
            }
            else
            {
                pnl_notif_pp.Visible = false;
                main_btn.btn_notif_pp_deactivate(btn_profile);
                pnl_n_pp = false;
            }*/
        }




        #endregion

        #region OpenAdd

        private void btn_pwd_add_Click(object sender, EventArgs e)
        {
            int loc_x = this.Location.X + 71;
            int loc_y = this.Location.Y + 50;

            pwd_add pwd_fill_up_form = new pwd_add();
            side_tab.Enabled = false;
            dboard_head.Enabled = false;
            pwd_fill_up_form.reference_to_main = this;
            pwd_fill_up_form.Location = new Point(loc_x, loc_y);
            pwd_fill_up_form.ShowDialog();
        }
        #endregion

        #region OpenViewPWD
        int current_pwd_id = 0;
        int current_grid_index = 1;

        private void btn_pwd_viewmore_Click_1(object sender, EventArgs e)
        {
            int loc_x = this.Location.X + 71;
            int loc_y = this.Location.Y + 50;

            pwd_view pwd_view_form = new pwd_view();
            side_tab.Enabled = false;
            dboard_head.Enabled = false;
            pwd_view_form.reference_to_main = this;
            pwd_view_form.Location = new Point(loc_x, loc_y);
            pwd_view_form.current_pwd = current_pwd_id;
            pwd_view_form.ShowDialog();
        }

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
        private void pwd_grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            pwd_grid_CellClick(sender, e);
        }
        #endregion

        #region OpenDevice
        private void button33_Click(object sender, EventArgs e)
        {

            int loc_x = this.Location.X + 71;
            int loc_y = this.Location.Y + 50;

            device_add device = new device_add();
            side_tab.Enabled = false;
            dboard_head.Enabled = false;
            device.reference_to_main = this;
            device.Location = new Point(loc_x, loc_y);
            device.ShowDialog();
        }
        #endregion

        #region OpenDeviceProvider
        private void btn_providers_Click(object sender, EventArgs e)
        {
            int loc_x = this.Location.X + 71;
            int loc_y = this.Location.Y + 50;

            device_provider provider = new device_provider();
            side_tab.Enabled = false;
            dboard_head.Enabled = false;
            provider.reference_to_main = this;
            provider.Location = new Point(loc_x, loc_y);
            provider.ShowDialog();
        }
        #endregion

        #region OpenDisability
        private void btn_disability_Click(object sender, EventArgs e)
        {
            int loc_x = this.Location.X + 71;
            int loc_y = this.Location.Y + 50;

            device_disability disability = new device_disability();
            side_tab.Enabled = false;
            dboard_head.Enabled = false;
            disability.reference_to_main = this;
            disability.Location = new Point(loc_x, loc_y);
            disability.ShowDialog();
        }
        #endregion

        #region OpenRequestDevice
        private void btn_request_Click(object sender, EventArgs e)
        {
            //arrange location laterz haha
            int loc_x = this.Location.X + 210;
            int loc_y = this.Location.Y + 86;

            device_request req = new device_request();
            side_tab.Enabled = false;
            dboard_head.Enabled = false;
            req.reference_to_main = this;
            req.Location = new Point(loc_x, loc_y);
            req.ShowDialog();
        }

        #endregion

        #region OpenViewRequests
        private void link_view_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //arrange location laterz haha
            int loc_x = this.Location.X + 210;
            int loc_y = this.Location.Y + 86;

            device_view view = new device_view();
            side_tab.Enabled = false;
            dboard_head.Enabled = false;
            view.reference_to_main = this;
            view.Location = new Point(loc_x, loc_y);
            view.ShowDialog();
        }
        #endregion

        #region PWD Data
        public void pwd_data()
        {
            conn.pwd_grid_list(pwd_grid);
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

        #region SETTINGS
        string uname, pass, ln, fn, mn, address, contact, post, stat;
        int stat_emp, emp_id;
        DateTime birthdate;
        public bool cont = false;

        private void btn_acct_Click(object sender, EventArgs e) // manage accounts
        {
            pnl_main.Visible = settings_list_full.Visible = false; // main
            pnl_form.Visible = pnl_form2.Visible = false; // employee form
            pnl_manage.Visible = info_grid.Visible = true; // manage accounts
            lbl_title.Text = btn_acct.Text;
          
            btn_arch.Visible = btn_to_update.Visible = btn_back.Visible = true;
            btn_to_update.Enabled = btn_arch.Enabled = false;
            btn_to_update.Text = btn_arch.Text = "";

            setting.settings_user_grid(user_grid);
            setting.settings_info_grid(info_grid);
            info_grid.ClearSelection();
            user_grid.ClearSelection();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            if (info_grid.Visible == true && pnl_manage.Visible == true)
            {
                pnl_main.Visible = settings_list_full.Visible = true;
                pnl_manage.Visible = info_grid.Visible = false;
                btn_arch.Visible = btn_to_update.Visible = btn_back.Visible = false;
            }
            else if(pnl_form.Visible == true && pnl_form2.Visible == true)
            {
                pnl_form.Visible = pnl_form2.Visible = false;
                pnl_manage.Visible = info_grid.Visible = true;
                btn_to_update.Visible = btn_arch.Visible = true;
                txt_user.Clear();
                txt_pass.Clear();
                txt_lname.Clear();
                txt_mname.Clear();
                txt_fname.Clear();
                txt_add.Clear();
                txt_cont.Clear();
                txt_position.Clear();
                emp_status.Text = "";
                bdate.Value = DateTime.Now;

            }

            setting.settings_user_grid(user_grid);
            setting.settings_info_grid(info_grid);
            setting.employee_list(settings_list_full);
            user_grid.ClearSelection();
            info_grid.ClearSelection();
        }
        public string user;
        private void user_grid_CellClick(object sender, DataGridViewCellEventArgs e) //user grid
        {
            DataGridViewRow row = this.user_grid.Rows[e.RowIndex];
            user = row.Cells["username"].Value.ToString();
        }
        private void btn_addemp_Click(object sender, EventArgs e) // to open employee form details
        {
            pnl_form.Visible = pnl_form2.Visible = true;
            info_grid.Visible = settings_list_full.Visible = false;
            pnl_manage.Visible = pnl_main.Visible =  false; //menu bar
            btn_to_update.Visible = btn_arch.Visible = false;
            txt_user.MaxLength = 12;
            txt_pass.MaxLength = 16;
        }
        private void add_emp_Click(object sender, EventArgs e)
        {
            device_prompt p = new device_prompt();

            if (add_edit_emp.Text == "EDIT")
            {
                uname = txt_user.Text;
                pass = txt_pass.Text;
                ln = txt_lname.Text;
                fn = txt_fname.Text;
                mn = txt_mname.Text;
                address = txt_add.Text;
                contact = txt_cont.Text;
                post = txt_position.Text;
                birthdate = bdate.Value.Date;
                stat_emp = emp_status.SelectedIndex - 1;

                string func = "Edit Employee Details";
                p.prompt_title.Text = func;
                p.lbl_quest.Text = "Are you sure to save this changes?";
                p.prompt_title.Location = new Point(142, 3);
                p.lbl_quest.Location = new Point(97, 8);
                p.lbl_quest.Visible = true;

                p.reference_to_main = this;
                p.ShowDialog();

                string query = "UPDATE p_dao.employee SET lastname = '"+ ln + "', firstname = '" + fn + "', middlename = '" + mn + "', address = '" + address + "', contact_no = '" + contact + "', position = '" + post + "', birthdate = '" + birthdate.ToString("yyyy-MM-dd") + "', status_id = '" + stat_emp + "' WHERE employee_id = '"+ emp_id + "'";
                setting.Edit(query, cont);
                setting.settings_info_grid(info_grid);
                setting.settings_user_grid(user_grid);
                setting.employee_list(settings_list_full);
            }
            else
            {
                uname = txt_user.Text;
                pass = txt_pass.Text;
                ln = txt_lname.Text;
                fn = txt_fname.Text;
                mn = txt_mname.Text;
                address = txt_add.Text;
                contact = txt_cont.Text;
                post = txt_position.Text;
                birthdate = bdate.Value.Date;
                stat_emp = emp_status.SelectedIndex - 1;

                string values = "VALUES('" + ln + "','" + fn + "','" + mn + "','" + address + "','" + post + "','" + contact + "','" + birthdate.ToString("yyyy-MM-dd") + "','" + stat_emp + "','" + uname + "','" + pass + "')";
                setting.Add(values);
            }
        }

        private void btn_to_update_Click(object sender, EventArgs e)
        {
            pnl_form.Visible = pnl_form2.Visible = true;
            info_grid.Visible = settings_list_full.Visible = false;
            pnl_manage.Visible = pnl_main.Visible = false; //menu bar
            btn_to_update.Visible = btn_arch.Visible = false;

            //values
            if (stat_emp == 0) emp_status.SelectedIndex = 1;
            else if (stat_emp == 1) emp_status.SelectedIndex = 2;
            else if (stat_emp == 2) emp_status.SelectedIndex = 3;
            txt_user.Text = uname;
            txt_pass.Text = pass;
            txt_lname.Text = ln;
            txt_mname.Text = mn;
            txt_fname.Text = fn;
            txt_add.Text = address;
            txt_cont.Text = contact;
            txt_position.Text = post;
            bdate.Format.ToString("d");
            bdate.Value = birthdate;

            add_edit_emp.Text = "EDIT";
        }

        private void info_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.info_grid.Rows[e.RowIndex];

            ln = row.Cells["lastname"].Value.ToString();
            fn = row.Cells["firstname"].Value.ToString();
            mn = row.Cells["middlename"].Value.ToString();
            address = row.Cells["address"].Value.ToString();
            birthdate = Convert.ToDateTime(row.Cells["birthdate"].Value);
            contact = row.Cells["contact_no"].Value.ToString();
            post = row.Cells["position"].Value.ToString();
            uname = row.Cells["username"].Value.ToString();
            pass = row.Cells["password"].Value.ToString();
            stat = row.Cells["status"].Value.ToString();
            int emp = Convert.ToInt32(row.Cells["employee_id"].Value.ToString());
            emp_id = emp;

            btn_to_update.Enabled = btn_arch.Enabled = true;
            btn_to_update.Text = "EDIT";
            btn_arch.Text = "ARCHIVE";
        }

        #region Username & Password Event
        private void txt_user_Leave(object sender, EventArgs e)
        {
            int u = txt_user.TextLength;
            if(setting.checkUserLength(u) == false) user_prompt.Visible = true;
            else user_prompt.Visible = false;
        }
        private void txt_pass_Leave(object sender, EventArgs e)
        {
            int p = txt_pass.TextLength;
            if (setting.checkUserLength(p) == false) pass_prompt.Visible = true;
            else pass_prompt.Visible = false;
        }
        private void txt_user_TextChanged(object sender, EventArgs e)
        {
            int u = txt_user.TextLength;
            if (u >= 6) user_prompt.Visible = false;
        }

        private void txt_pass_TextChanged(object sender, EventArgs e)
        {
            int p = txt_pass.TextLength;
            if (p >= 8) pass_prompt.Visible = false;
        }

        #endregion

        #endregion

        #region PWD - Needs Relocation

        private void btn_pwd_edit_Click(object sender, EventArgs e)
        {
            int loc_x = this.Location.X + 71;
            int loc_y = this.Location.Y + 50;

            pwd_add edit = new pwd_add();
            edit.reference_to_main = this;
            edit.Location = new Point(loc_x, loc_y);
            edit.pwd_update_id = current_pwd_id;
            edit.paste_data();
            edit.btn_add_edit.Text = "UPDATE";
            edit.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            int loc_x = this.Location.X + 71;
            int loc_y = this.Location.Y + 50;

            sample_report sample = new sample_report();
            sample.reference_to_main = this;
            sample.Location = new Point(loc_x,loc_y);
            sample.ShowDialog();
           
        }

        private void pwd_searchbox_TextChanged(object sender, EventArgs e)
        {
            if (pwd_searchbox.Text.Trim() != "")
            {
                conn.pwd_search(pwd_grid, pwd_searchbox);
                pwd_grid.Columns["lastname"].Visible = false;
                pwd_grid.Columns["firstname"].Visible = false;
                pwd_grid.Columns["middlename"].Visible = false;
                pwd_format();
            }
            else
            {
                pwd_data();
            }
        }

        private void btn_archive_Click(object sender, EventArgs e)
        {
            int loc_x = 434;
            int loc_y = 148;
            pwd_archive show_prompt = new pwd_archive();
            show_prompt.Location = new Point(loc_x, loc_y);
            show_prompt.current_id = current_pwd_id;
            show_prompt.reference_to_main = this;
            show_prompt.regis_no.Text = "Registration#: " + pwd_grid.Rows[current_grid_index].Cells["registration_no"].Value.ToString();
            show_prompt.name.Text = "Name: " + pwd_grid.Rows[current_grid_index].Cells["fullname"].Value.ToString();
            show_prompt.app_date.Text = "Application_date: " + pwd_grid.Rows[current_grid_index].Cells["application_date"].Value.ToString();
            show_prompt.prompt_title.Text = "Archive";
            show_prompt.action.Text = "The following profile will be archived:";
            show_prompt.ShowDialog();
            btn_renew.Enabled = false;
            btn_archive.Enabled = false;
        }

        private void btn_pwd_refresh_Click(object sender, EventArgs e)
        {
            pwd_data();
            pwd_searchbox.Clear();
        }

        private void btn_renew_Click(object sender, EventArgs e)
        {

        }


        #endregion

        #region DEVICE
        int log_id;
        string pwd_name, req_desc, status, reg_no, device, disability, provider;
        DateTime req_date, date_IN, date_OUT;
        private void device_grid_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            device_view v = new device_view();
            if (e.RowIndex < 0)
            {
                //pass
            }
            else
            {
                device_edit.Enabled = true;
                DataGridViewRow row = this.device_grid.Rows[e.RowIndex];

                //device_logID
                log_id = 0;
                log_id = Convert.ToInt32(row.Cells["deviceLOG_id"].Value);

                pwd_name = row.Cells["pwd_name"].Value.ToString();
                req_desc = row.Cells["req_desc"].Value.ToString();
                status = row.Cells["status"].Value.ToString();
                reg_no = row.Cells["registration_no"].Value.ToString();
                device = row.Cells["dev_name"].Value.ToString();

                //DateTime Values
                req_date = Convert.ToDateTime(row.Cells["req_date"].Value.ToString());
                date_IN = Convert.ToDateTime(row.Cells["date_in"].Value.ToString());
                date_OUT = Convert.ToDateTime(row.Cells["date_out"].Value.ToString());

                //pass to edit panel [pnl_edit]

                //disability id [cmbox_dis]
                int d = 0;
                d = Convert.ToInt32(row.Cells["disability_id"].Value);
                ComboBox cb = v.cmbox_dis;
                conn.getDisability(cb);
                disability = cb.Items[d].ToString();

                //device [cmbox_dev]
                ComboBox cmb = v.cmbox_dev;
                conn.getDevice(d, cmb);
                v.cmbox_dev.SelectedValue = device;

                //device provider [cmbox_prov]
                int d2 = 0;
                conn.getProvider(v.cmbox_prov);
                d2 = Convert.ToInt32(row.Cells["dp_id"].Value);
                provider = v.cmbox_prov.Items[d2].ToString();

                v.lbl_desc.Text = reg_no;
            }
        }
        private void button15_Click(object sender, EventArgs e) // edit button FOR device_grid [handed out grid]
        {
            device_view v = new device_view();
  
            #region form setting
            v.reference_to_main = this;
            v.pnl_edit.BringToFront();
            v.lbl_title.Text = "EDIT REQUEST";
            #endregion

            #region to pass values
            v.request_date.Format.ToString("d");
            v.date_in.Format.ToString("d");
            v.dateOut.Format.ToString("d");

            v.txt_desc.Text = req_desc;
            v.lbl_desc.Text = reg_no;
            v.request_date.Value = req_date;
            v.date_in.Value = date_IN;
            v.dateOut.Value = date_OUT;
            v.cmbox_dis.Text = disability;
            v.cmbox_dev.Text = device;
            v.cmbox_prov.Text = provider;
            v.id = log_id;
            v.fstatus = 2; // handed out
            #endregion

            #region controls setting
            v.pnl_search.Visible = false;
            v.btn_req.Visible = v.btn_rec.Visible = v.btn_default.Visible = false; // filter: status button
            v.label12.Visible = v.label8.Visible = false; // status name
            v.btn_out.Visible = false; //handed out [devreq_grid]
            v.button2.Visible = false; //cancel button
            v.label9.Visible = v.dateOut.Visible = true;
            v.stat_req.Visible = false; // requested status

            //button status color
            v.stat_req.BackColor = Color.DimGray;
            v.stat_out.ForeColor = v.btn_out.BackColor; // usual dark color UI
            v.stat_req.ForeColor = v.stat_out.BackColor = Color.White;

            //status >> handed out
            v.stat_out.Visible = true;
            v.stat_out.PerformClick();
            
            #endregion

            v.ShowDialog();
            conn.device_out_grid(device_grid);
        }
        #endregion


    }
}