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

        private void btn_max_Click(object sender, EventArgs e)
        {
            main_func.btn_max(this);
        }

        private void btn_min_Click(object sender, EventArgs e)
        {
            main_func.btn_min(this);
        }
        #endregion

        #region MainButtonActivation MB - 00 --> PP DB PWD DR PM RP ST
        public Button btn_current;

        private void btn_profilepic_Click(object sender, EventArgs e)
        {
            main_btn.btn_method(btn_current, btn_profilepic);
            btn_current = btn_profilepic;
        }

        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            main_btn.btn_method(btn_current, btn_dashboard);
            btn_current = btn_dashboard;
        }

        private void btn_pwd_Click(object sender, EventArgs e)
        {
            main_btn.btn_method(btn_current, btn_pwd);
            btn_current = btn_pwd;
        }

        private void btn_device_Click(object sender, EventArgs e)
        {
            main_btn.btn_method(btn_current, btn_device);
            btn_current = btn_device;
        }

        private void btn_projects_Click(object sender, EventArgs e)
        {
            main_btn.btn_method(btn_current, btn_projects);
            btn_current = btn_projects;
        }

        private void btn_reports_Click(object sender, EventArgs e)
        {
            main_btn.btn_method(btn_current, btn_reports);
            btn_current = btn_reports;
        }

        private void btn_settings_Click(object sender, EventArgs e)
        {
            main_btn.btn_method(btn_current, btn_settings);
            btn_current = btn_settings;
        }
        #endregion

        #region FormLoad
        private void main_form_Load(object sender, EventArgs e)
        {
            btn_current = btn_dashboard;
        }
        #endregion


    }
}
