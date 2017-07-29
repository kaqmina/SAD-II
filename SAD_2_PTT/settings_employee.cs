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
    public partial class settings_employee : Form
    {
        public settings_employee()
        {
            InitializeComponent();
        }
        public main_form reference_to_main { get; set; }
        main_functions main_f = new main_functions();
        connections conn = new connections();

        public void account_data()
        {
            conn.pwd_employee_list(pwd_settings_list);
        }

        public void employee_format()
        {
            pwd_settings_list.Columns["employee_id"].Visible = false;
            pwd_settings_list.Columns["address"].Visible = false;
            pwd_settings_list.Columns["position"].Visible = false;
            pwd_settings_list.Columns["contact_no"].Visible = false;
            pwd_settings_list.Columns["birthdate"].Visible = false;
            pwd_settings_list.Columns["status_id"].Visible = false;
            pwd_settings_list.Columns["username"].Visible = false;
            pwd_settings_list.Columns["password"].Visible = false;
        }
    }
}
