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
        connections_user conn_user = new connections_user();
        connections_disability conn_disa = new connections_disability();
        system_functions sys_func = new system_functions();
        public string current_pwd_id = "0", current_device_log_id = "0";

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (btn_ok.Text == "OK")
            {
                this.Close();
            }
            else
            {
                string user_id = conn_user.get_user_id_by_name(requested_by_edit.Text);
                string user_in_id = conn_user.get_user_id_by_name(received_by_edit.Text);
                string dev_req = conn_devi.get_device_by_name(device_req_edit.Text);
                string sponsor_id = conn_devi.get_sponsor_by_name(sponsor_edit.Text);
                bool success = conn_devi.received_update(request_desc_edit.Text, user_id, date_req_edit.Value.ToString("yyyy-MM-dd"), dev_req, sponsor_id, reference_no_edit.Text, current_device_log_id, user_in_id, date_in_edit.Value.ToString("yyyy-MM-dd"));
                if (success == true)
                {
                    reference_to_main.notification_ = "Successfully Updated!";
                    btn_ok.Text = "OK";
                    btn_edit.Text = "EDIT";
                    sys_func.btn_active(btn_ok);
                    get_data();
                    pnl_edit.Visible = false;
                }
                else
                {
                    reference_to_main.notification_ = "Unsuccessful in updating record.";
                    btn_ok.Text = "SAVE CHANGES";
                    btn_edit.Text = "DISCARD CHANGES";
                }
                reference_to_main.show_success_message();
            }
        }

        private void device_pending_rec_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            header_text.Text += " ReqID : " + current_device_log_id;
            get_data();

            startup_opacity.Start();
        }

        public void get_data()
        {
            DataTable info = new DataTable();
            conn_devi.get_pending_received_data(current_pwd_id, current_device_log_id, info);
            lbl_pwd_name.Text = info.Rows[0]["fullname"].ToString();
            lbl_pwd_regis_no.Text = info.Rows[0]["registration_no"].ToString();
            lbl_employee_referred.Text = info.Rows[0]["username"].ToString();
            string[] req_date = info.Rows[0]["req_date"].ToString().Split();
            lbl_date_requested.Text = req_date[0];
            lbl_device_requested.Text = info.Rows[0]["dev_name"].ToString();
            lbl_provider.Text = info.Rows[0]["dp_name"].ToString();
            lbl_desc.Text = info.Rows[0]["req_desc"].ToString();
            lbl_reference_no.Text = info.Rows[0]["reference_no"].ToString();
            lbl_id_no.Text = info.Rows[0]["id_no"].ToString();
            lbl_mobile_no.Text = info.Rows[0]["mobile_no"].ToString();
            lbl_tel_no.Text = info.Rows[0]["tel_no"].ToString();
            lbl_disability.Text = info.Rows[0]["disability_type"].ToString();
            string[] date_in = info.Rows[0]["date_in"].ToString().Split();
            lbl_date_in.Text = date_in[0];
            lbl_in_emp_id.Text = info.Rows[0]["username_in"].ToString();
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
            reference_to_main.load_handedout_data();
            reference_to_main.load_device_requests();
        }

        private void received_by_edit_SelectedIndexChanged(object sender, EventArgs e)
        {
            check_required();
        }

        public string date_out_;

        private void btn_hand_out_Click(object sender, EventArgs e)
        {
            device_rec_req_date date = new device_rec_req_date();
            date.reference_to_received = this;
            date.Text = "Mark as Handed Out.";
            date.caption.Text = "Select date handed out: ";
            date.state = 1;
            date.rec_date = Convert.ToDateTime(lbl_date_in.Text);
            string current_user_id = conn_user.get_user_id_by_name(reference_to_main.current_user);

            var result = date.ShowDialog();
            if (result == DialogResult.OK)
            {
                conn_devi.mark_as_handed_out(current_device_log_id, current_user_id, date_out_);
                this.Close();
            }
            else
            {
                //nothing
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult ask;
            string message = "This means that the device received is defected and will mark the request as cancelled. Continue?";
            string caption = "Mark as Cancelled?";
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

        private void requested_by_edit_SelectedIndexChanged(object sender, EventArgs e)
        {
            check_required();
        }

        private void device_req_edit_SelectedIndexChanged(object sender, EventArgs e)
        {
            check_required();
        }

        private void sponsor_edit_SelectedIndexChanged(object sender, EventArgs e)
        {
            check_required();
        }

        private void reference_no_edit_TextChanged(object sender, EventArgs e)
        {
            check_required();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (btn_edit.Text == "EDIT")
            {
                pnl_edit.Visible = true;
                conn_devi.get_provider_list(sponsor_edit);
                string disability_id = conn_disa.get_disability_by_name(lbl_disability.Text);
                conn_devi.get_device_list(device_req_edit, disability_id);
                conn_user.get_user_cbox(requested_by_edit);
                conn_user.get_user_cbox(received_by_edit);

                request_desc_edit.Text = lbl_desc.Text;
                requested_by_edit.Text = lbl_employee_referred.Text;
                date_req_edit.Value = Convert.ToDateTime(lbl_date_requested.Text);
                date_req_edit.MaxDate = DateTime.Now;
                device_req_edit.Text = lbl_device_requested.Text;
                sponsor_edit.Text = lbl_provider.Text;
                reference_no_edit.Text = lbl_reference_no.Text;
                received_by_edit.Text = lbl_in_emp_id.Text;
                date_in_edit.MinDate = date_req_edit.Value;
                date_in_edit.Value = Convert.ToDateTime(lbl_date_in.Text);
                date_in_edit.MaxDate = DateTime.Now;

                btn_edit.Text = "DISCARD CHANGES";
                btn_ok.Text = "SAVE CHANGES";
            }
            else
            {
                pnl_edit.Visible = false;
                btn_edit.Text = "EDIT";
                btn_ok.Text = "OK";
                sys_func.btn_active(btn_ok);
            }
        }

        private void date_req_edit_ValueChanged(object sender, EventArgs e)
        {
            date_in_edit.MinDate = date_req_edit.Value;
            check_required();
        }

        public void check_required()
        {
            if (requested_by_edit.Text == "" || sponsor_edit.Text == "" || device_req_edit.Text == "" || reference_no_edit.Text.Trim() == "" || received_by_edit.Text == "")
            {
                if (btn_ok.Text == "SAVE CHANGES")
                {
                    sys_func.btn_inactive(btn_ok);
                }
                else
                {
                    sys_func.btn_active(btn_ok);
                }
            }
            else
            {
                sys_func.btn_active(btn_ok);
            }
        }

    }
}
