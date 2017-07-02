using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            //slide_in.Start();
        }

        private void btn_pwd_Click(object sender, EventArgs e)
        {
            main_btn.btn_method(btn_current, btn_pwd);
            pnl_deactivate(btn_current.Name);
            btn_current = btn_pwd;
            lbl_current_text("pwd");
            main_btn.btn_pwd = true;
            //slide_out.Start();
        }

        private void btn_device_Click(object sender, EventArgs e)
        {
            main_btn.btn_method(btn_current, btn_device);
            pnl_deactivate(btn_current.Name);
            btn_current = btn_device;
            lbl_current_text("devices");
            main_btn.btn_device = true;
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
            btn_current = btn_dashboard;
            btn_dashboard_Click(sender, e);
            main_properties();
            string date = DateTime.Now.ToString("MMMM dd, yyyy");
            date_today.Text = date.ToUpper();
            lbl_current_text("dashboard");
            
            
        }

        private void main_properties()
        {
            //size
            sidenav.Size = new Size(212, 608);
            main_tab.Size = new Size(71, 608); //283, 608 <-- main_tab Size
            side_tab.Size = new Size(71, 608); //1069, 589 <-- panels
            pnl_dashboard.Size = new Size(1069, 589);
            pnl_pwd.Size = new Size(1069, 589);
            pnl_notif_pp.Size = new Size(302, 233);

            //visibility
            pnl_pwd.Visible = false;
            pnl_notif_pp.Visible = false;

            //location
            pnl_dashboard.Location = new Point(0, 50);
            pnl_pwd.Location = new Point(0, 50);
            pnl_notif_pp.Location = new Point(767, 50);
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
            }
            else if (activate == "projects")
            {
                lbl_current.Text = "PROJECTS";
            }
            else if (activate == "reports")
            {
                lbl_current.Text = "REPORTS";
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




    }
}
