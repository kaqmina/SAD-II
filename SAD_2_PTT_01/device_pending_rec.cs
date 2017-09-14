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
    public partial class device_pending_rec : Form
    {
        public device_pending_rec()
        {
            InitializeComponent();
        }
        public main_form reference_to_main { get; set; }
        connections_devices conn_devi = new connections_devices();
        public string current_pwd_id = "0", current_device_log_id = "0";

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void device_pending_rec_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            DataTable info = new DataTable();
            conn_devi.get_pending_received_data(current_pwd_id, current_device_log_id, info);
            lbl_pwd_name.Text = info.Rows[0]["fullname"].ToString();
            lbl_pwd_regis_no.Text = info.Rows[0]["registration_no"].ToString();
            lbl_employee_referred.Text = info.Rows[0]["username"].ToString();
            lbl_date_requested.Text = info.Rows[0]["req_date"].ToString();
            lbl_device_requested.Text = info.Rows[0]["dev_name"].ToString();
            lbl_provider.Text = info.Rows[0]["dp_name"].ToString();
            lbl_date_in.Text = info.Rows[0]["date_in"].ToString();
            lbl_in_emp_id.Text = info.Rows[0]["username_in"].ToString();

            startup_opacity.Start();
        }

        private void startup_opacity_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
                this.Opacity += 0.1;
            else
                startup_opacity.Stop();
        }

        private void exit_opacity_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                this.Opacity -= 0.1;
            }
            else
            {
                exit_opacity.Stop();
            }
        }

        private void device_pending_rec_FormClosing(object sender, FormClosingEventArgs e)
        {
            exit_opacity.Start();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
