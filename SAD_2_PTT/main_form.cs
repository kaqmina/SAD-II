using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SAD_2_PTT
{
    public partial class main_form : Form
    {
        public MySqlConnection conn;
        public main_form()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=p_dao;Uid=root;Pwd=root");
        }
        main_functions main_func = new main_functions();
        main_btn_active main_btn = new main_btn_active();

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
            //btn_profilepic.BackgroundImage = SAD_2_PTT.Properties.Resources.TWICE_KK_01;
            //btn_profilepic.BackColor = Color.FromArgb(235, 85, 34);
            //slide_in.Start();
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
            main_btn.btn_method(btn_current, btn_projects);
            pnl_deactivate(btn_current.Name);
            btn_current = btn_projects;
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
        }

        private void main_properties()
        {
            int x = 1069;
            int y = 589;

            //size
            sidenav.Size = new Size(212, 608);
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

            }
            else if (deactivate == "btn_report")
            {

            }
            else if (deactivate == "btn_settings")
            {

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
            if(pnl_n_pp == false)
            {
                pnl_notif_pp.Visible = true;
                btn_notification.Image = SAD_2_PTT.Properties.Resources.notification_bell_active;
                main_btn.btn_notif_pp_active(btn_notification);
                pnl_n_pp = true;
            } else
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

        private void btn_pwd_viewmore_Click_1(object sender, EventArgs e)
        {
            int loc_x = this.Location.X + 71;
            int loc_y = this.Location.Y + 50;

            pwd_view pwd_view_form = new pwd_view();
            side_tab.Enabled = false;
            dboard_head.Enabled = false;
            pwd_view_form.reference_to_main = this;
            pwd_view_form.Location = new Point(loc_x, loc_y);
            pwd_view_form.ShowDialog();
        }

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

        #region Connections
        public void pwd_data()
        {
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("SELECT * FROM pwd WHERE isArchived = 0", conn);
                MySqlDataAdapter get = new MySqlDataAdapter(comm);
                DataTable set = new DataTable();
                get.Fill(set);


                pwd_grid.DataSource = set;
                pwd_format();
                if (set.Rows.Count == 0)
                {
                    MessageBox.Show("No PWD Profiles added.");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Database is empty.");
            }
        }

        public void pwd_format()
        {
            pwd_grid.Columns["pwd_id"].Visible = false;
            pwd_grid.Columns["employee_id"].Visible = false;
            pwd_grid.Columns["end_date"].Visible = false;
            pwd_grid.Columns["nationality"].Visible = false;
            pwd_grid.Columns["birthdate"].Visible = false;
            pwd_grid.Columns["picture"].Visible = false;
            pwd_grid.Columns["tel_no"].Visible = false;
            pwd_grid.Columns["mobile_no"].Visible = false;
            pwd_grid.Columns["email_add"].Visible = false;
            pwd_grid.Columns["accomplished_by"].Visible = false;
            pwd_grid.Columns["educ_attainment"].Visible = false;
            pwd_grid.Columns["employment_status"].Visible = false;
            pwd_grid.Columns["nature_of_employer"].Visible = false;
            pwd_grid.Columns["type_of_skill"].Visible = false;
            pwd_grid.Columns["status_pwd"].Visible = false;
            pwd_grid.Columns["isArchived"].Visible = false;
            pwd_grid.Columns["address"].Visible = false;

            pwd_grid.Columns["registration_no"].HeaderText = "Registration #";
            pwd_grid.Columns["lastname"].HeaderText = "Last Name";
            pwd_grid.Columns["firstname"].HeaderText = "First Name";
            pwd_grid.Columns["middlename"].HeaderText = "Middle Name";
            pwd_grid.Columns["sex"].HeaderText = "Sex";
            pwd_grid.Columns["disability_id"].HeaderText = "Disability";
            pwd_grid.Columns["blood_type"].HeaderText = "Blood Type";
            pwd_grid.Columns["civil_status"].HeaderText = "Civil Status";
            pwd_grid.Columns["application_date"].HeaderText = "Date Applied";

        }



        #endregion

       
    }
}
