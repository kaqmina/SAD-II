using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAD_2_PTT
{
    class main_btn_active
    {
        public bool btn_dashboard = true;
        public bool btn_profilepic = false;
        public bool btn_pwd = false;
        public bool btn_device = false;
        public bool btn_project = false;
        public bool btn_report = false;
        public bool btn_settings = false;
        public bool btn_logout = false;
        public Button btn_temp;
        public Form main;
        public main_form reference_to_main { get; set; }

        public main_btn_active (Form main_f)
        {
            main = main_f;
        }

        #region MainButtonActivation MB - 00
        public void btn_method(Button btn_current, Button btn_toactivate)
        {
            btn_deactivate (btn_current);
            btn_active(btn_toactivate);
            pnl_active(btn_current.Name, btn_toactivate.Name);
        }

        public void btn_active(Button btn_toactivate)
        {
            btn_toactivate.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
        }

        public void btn_deactivate(Button btn_current)
        {
            btn_current.BackColor = System.Drawing.Color.Transparent; 
        }
        #endregion

        private void pnl_active(string deactivate, string toactivate)
        {
            pnl_deactivate(deactivate);
            if(toactivate == "btn_dashboard")
            {
                reference_to_main.pnl_dashboard.Visible = true;
            } else if (toactivate == "btn_pwd")
            {
                reference_to_main.pnl_pwd.Visible = true;
            } else if (toactivate == "btn_device")
            {

            } else if (toactivate == "btn_project")
            {
                
            } else if (toactivate == "btn_report")
            {

            } else if (toactivate == "btn_settings")
            {

            } else
            {

            }
        }

        private void pnl_deactivate(string deactivate)
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

    }
}
