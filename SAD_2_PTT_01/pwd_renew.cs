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
    public partial class pwd_renew : Form
    {
        public pwd_renew()
        {
            InitializeComponent();
        }

        public main_form reference_to_main { get; set; }
        public string current_pwd_id = "0";
        string renewPWD_id = "0";
        connections_pwd conn_pwd = new connections_pwd();
        system_functions sys_func = new system_functions();
        system_keypress key_ = new system_keypress();

        public void load_data ()
        {
            checkbox_value();
            DataTable renew_data = new DataTable();
            conn_pwd.load_renew_data(current_pwd_id, renew_data);

            lbl_id_no.Text = renew_data.Rows[0]["id_no"].ToString();
            lbl_pwd_name.Text = renew_data.Rows[0]["fullname"].ToString();
            string[] end_date = renew_data.Rows[0]["end_date"].ToString().Split();
            lbl_end_date.Text = end_date[0];

            date_renewed.MaxDate = DateTime.Today;
            renewPWD_id = renew_data.Rows[0]["renewPWD_id"].ToString();

        }

        public void checkbox_value()
        {
            if (dcertificate.Checked == false)
            {
                dc_reference_no.Enabled = false;
            }
            else
            {
                dc_reference_no.Enabled = true;
            }

            if (certificate_of_disability.Checked == false)
            {
                cod_reference_no.Enabled = false;
            }
            else
            {
                cod_reference_no.Enabled = true;
            }
        }

        public bool check_required()
        {
            bool all_required = false;

            if (dcertificate.Checked == false && certificate_of_disability.Checked == false)
            {
                sys_func.btn_inactive(btn_ok);
            } else
            {
                if (dcertificate.Checked == true && certificate_of_disability.Checked == true && dc_reference_no.Text.Trim() != "" && cod_reference_no.Text.Trim() != "" )
                {
                    sys_func.btn_active(btn_ok);
                } else
                {
                    sys_func.btn_inactive(btn_ok);
                }
            }

            return all_required;
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

        private void pwd_renew_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            startup_opacity.Start();
            load_data();
        }

        private void pwd_renew_FormClosing(object sender, FormClosingEventArgs e)
        {
            exit_opacity.Start();
        }

        private void dcertificate_CheckedChanged(object sender, EventArgs e)
        {
            checkbox_value();
            check_required();
        }

        private void certificate_of_disability_CheckedChanged(object sender, EventArgs e)
        {
            checkbox_value();
            check_required();
        }

        private void dc_reference_no_TextChanged(object sender, EventArgs e)
        {
            check_required();
        }

        private void cod_reference_no_TextChanged(object sender, EventArgs e)
        {
            check_required();
        }

        private void dc_reference_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            key_.key_number(sender, e);
        }

        private void cod_reference_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            key_.key_number(sender, e);
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            bool app_ = false;
            bool renew_ = false;
            bool new_app_ = false;
            string date_renewed_ = date_renewed.Value.ToString("yyyy-MM-dd");
            DateTime new_end = date_renewed.Value.AddYears(3);
            string new_end_ = new_end.ToString("yyyy-MM-dd");

            string dc = dc_reference_no.Text;
            string cod = cod_reference_no.Text;
            app_ = conn_pwd.update_application_date(current_pwd_id, date_renewed_);
            if (app_ == true)
            {
                renew_ = conn_pwd.update_renew_date(renewPWD_id, date_renewed_, dc, cod);
                if (renew_ == true)
                {
                    new_app_ = conn_pwd.insert_pwd_end_date(current_pwd_id, new_end_);
                }
            }

            if (app_ == false || renew_ == false || new_app_ == false)
            {
                reference_to_main.notification_ = "Please input valid values.";
                reference_to_main.show_success_message();
            } else
            {
                reference_to_main.notification_ = "Renewed Successfully!";
                reference_to_main.show_success_message();
                reference_to_main.load_pwd();
                this.Close();
            }
        }
    }
}
