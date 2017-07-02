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

        #region MainButtonActivation MB - 00
        public void btn_method(Button btn_current, Button btn_toactivate)
        {
            btn_deactivate (btn_current);
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
        #endregion

        #region Notification/ProfilePic

        public void pnl_notif_pp_hover(Panel pnl_n_pp, Button pp, Button notif)
        {

        }

        public void btn_notif_pp_active(Button btn)
        {
            btn.BackColor = System.Drawing.Color.FromArgb(49, 53, 65);
            
        }

        public void btn_notif_pp_deactivate(Button btn)
        {
            btn.BackColor = System.Drawing.Color.Transparent;
        }

        #endregion



    }
}
