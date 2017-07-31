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
            conn.employee_list(settings_list);
        }

        public void employee_format()
        {
            settings_list.Columns["employee_id"].Visible = false;
            settings_list.Columns["address"].Visible = false;
            settings_list.Columns["position"].Visible = false;
            settings_list.Columns["contact_no"].Visible = false;
            settings_list.Columns["birthdate"].Visible = false;
            settings_list.Columns["status_id"].Visible = false;
            settings_list.Columns["username"].Visible = false;
            settings_list.Columns["password"].Visible = false;
        }
    }
}
