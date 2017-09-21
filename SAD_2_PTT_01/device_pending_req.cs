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
    public partial class device_pending_req : Form
    {
        public device_pending_req()
        {
            InitializeComponent();
        }
        public main_form reference_to_main { get; set; }
        connections_devices conn_devi = new connections_devices();
        connections_user conn_user = new connections_user();
        public string current_pwd_id = "0", current_device_log_id = "0";

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void device_pending_req_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            DataTable info = new DataTable();
            conn_devi.get_pending_requests_data(current_pwd_id, current_device_log_id, info);
            lbl_pwd_name.Text = info.Rows[0]["fullname"].ToString();
            lbl_pwd_regis_no.Text = info.Rows[0]["registration_no"].ToString();
            lbl_employee_referred.Text = info.Rows[0]["username"].ToString();
            lbl_date_requested.Text = info.Rows[0]["req_date"].ToString();
            lbl_device_requested.Text = info.Rows[0]["dev_name"].ToString();
            lbl_provider.Text = info.Rows[0]["dp_name"].ToString();

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

        private void device_pending_req_FormClosing(object sender, FormClosingEventArgs e)
        {
            exit_opacity.Start();
        }

        public string date_rec_;

        private void btn_received_Click(object sender, EventArgs e)
        {
            device_rec_req_date date = new device_rec_req_date();
            date.reference_to_main = this;
            date.req_date = Convert.ToDateTime(lbl_date_requested.Text);
            string current_user_id = conn_user.get_user_id_by_name(reference_to_main.current_user);

            var result = date.ShowDialog();
            if (result == DialogResult.OK)
            {
                conn_devi.mark_as_received(current_device_log_id, current_user_id, date_rec_);
                reference_to_main.load_device_requests();
                this.Close();
            } else
            {
                //nothing
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult ask;
            string message = "This will mark the request as cancelled. Continue?";
            string caption = "Mark as Cancalled?";
            MessageBoxButtons btn = MessageBoxButtons.YesNo;
            ask = MessageBox.Show(message, caption, btn);
            string current_user_id = conn_user.get_user_id_by_name(reference_to_main.current_user);
            string can_date = DateTime.Now.ToString("yyyy-MM-dd");

            if (ask == System.Windows.Forms.DialogResult.Yes)
            {
                conn_devi.mark_as_cancelled(current_device_log_id, current_user_id, can_date);
                this.Close();
            }
            else
            {
                //nothing
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (btn_edit.Text == "EDIT")
            {
                pnl_edit.Visible = true;
                conn_devi.get_provider_list(sponsor_edit);
                conn_devi.get_device_list(device_req_edit, lbl_disability.Text);
                conn_user.get_user_cbox(requested_by_edit);

                request_desc_edit.Text = lbl_desc.Text;
                btn_edit.Text = "DISCARD CHANGES";
                btn_ok.Text = "SAVE CHANGES";
            } else
            {
                pnl_edit.Visible = false;
                btn_edit.Text = "EDIT";
            }
        }

        public void check_required()
        {
            if (requested_by_edit.SelectedIndex <= 0 || sponsor_edit.SelectedIndex <= 0 || )
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
