using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAD_2_PTT_01
{
    class system_sidenav_active
    {
        public main_form reference_to_main { get; set; }

        public void btn_method(Button btn_current, Button btn_toactivate)
        {
            btn_deactivate(btn_current);
            btn_active(btn_toactivate);
        }

        public void btn_active(Button btn_toactivate)
        {
            btn_toactivate.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
        }

        public void btn_deactivate(Button btn_current)
        {
            btn_current.BackColor = System.Drawing.Color.Transparent;
        }

        public void lbl_current_text(string activate)
        {
            if (activate == "dashboard")
            {
                reference_to_main.lbl_current.Text = " ";
                reference_to_main.pnl_dashboard.Visible = true;
            }
            else if (activate == "pwd")
            {
                reference_to_main.lbl_current.Text = "MEMBERSHIP";
                reference_to_main.pnl_pwd.Visible = true;
            }
            else if (activate == "devices")
            {
                reference_to_main.lbl_current.Text = "ASSISTIVE DEVICE";
                reference_to_main.pnl_devices.Visible = true;
            }
            else if (activate == "projects")
            {
                reference_to_main.lbl_current.Text = "PROJECTS";
                reference_to_main.pnl_projects.Visible = true;
            }
            else if (activate == "reports")
            {
                reference_to_main.lbl_current.Text = "REPORTS";
                reference_to_main.pnl_reports.Visible = true;
            }
            else if (activate == "settings")
            {
                reference_to_main.lbl_current.Text = "SETTINGS";
                reference_to_main.pnl_settings.Visible = true;
            }
            else
            {
                reference_to_main.lbl_current.Text = " ";
            }
        }

        public void pnl_deactivate(string deactivate)
        {
            if (deactivate == "btn_dashboard")
            {
                reference_to_main.pnl_dashboard.Visible = false;
            }
            else if (deactivate == "btn_pwd")
            {
                reference_to_main.pnl_pwd.Visible = false;
            }
            else if (deactivate == "btn_device")
            {
                reference_to_main.pnl_devices.Visible = false;
            }
            else if (deactivate == "btn_project")
            {
                reference_to_main.pnl_projects.Visible = false;
            }
            else if (deactivate == "btn_report")
            {
                reference_to_main.pnl_reports.Visible = false;
            }
            else if (deactivate == "btn_settings")
            {
                reference_to_main.pnl_settings.Visible = false;
            }
            else
            {
                //none
            }
        }
    }
}
