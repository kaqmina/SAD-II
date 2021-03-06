﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SAD_2_PTT_01
{
    public partial class pwd_view : Form
    {
        public pwd_view()
        {
            InitializeComponent();
        }
        public main_form reference_to_main { get; set; }
        connections_pwd conn_pwd = new connections_pwd();
        system_notification system_notify;
        public string current_pwd = "0";
        public bool success;

        #region ON-LOAD | ON-CLOSE
        private void startup_opacity_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
                this.Opacity += 0.1;
            else
                startup_opacity.Stop();
        }

        private void pwd_view_Load(object sender, EventArgs e)
        {
            startup_opacity.Start();
            pwd_load_data(current_pwd);
        }

        private void pwd_view_back_Click(object sender, EventArgs e)
        {
            exit_opacity.Start();
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
                this.Close();
            }
        }
        #endregion

        #region PWD DATA Paste

        public void pwd_load_data(string current_pwd)
        {
            DataTable main_data = new DataTable();
            DataTable other_data = new DataTable();
            DataTable parental_data = new DataTable();
            conn_pwd.pwd_view_profile(current_pwd, main_data, other_data, parental_data);

            //<-----[MAIN DATA]----->
            pwd_view_fullname.Text = main_data.Rows[0]["fullname"].ToString();
            pwd_view_disability.Text = main_data.Rows[0]["disability_type"].ToString();
            pwd_view_regis_no.Text = main_data.Rows[0]["registration_no"].ToString();
            string[] app_date = (main_data.Rows[0]["application_date"].ToString()).Split();
            pwd_view_app_date.Text = app_date[0];
            pwd_view_district.Text = main_data.Rows[0]["district_name"].ToString();
            string[] b_day = (main_data.Rows[0]["birthdate"].ToString()).Split();
            pwd_view_dob.Text = b_day[0];
            pwd_view_nationality.Text = main_data.Rows[0]["nationality"].ToString();
            pwd_view_address1.Text = main_data.Rows[0]["address"].ToString();
            pwd_view_civil_status.Text = main_data.Rows[0]["civil_status"].ToString();
            pwd_view_tel_no.Text = main_data.Rows[0]["tel_no"].ToString();
            pwd_view_mobile_no.Text = main_data.Rows[0]["mobile_no"].ToString();
            pwd_view_email.Text = main_data.Rows[0]["email_add"].ToString();
            pwd_view_educ_att.Text = main_data.Rows[0]["educ_attainment"].ToString();
            pwd_view_status.Text = main_data.Rows[0]["status_pwd"].ToString();
            try
            {
                byte[] image = (byte[])main_data.Rows[0]["picture"];
                MemoryStream ms = new MemoryStream(image);
                pwd_view_pp.Image = Image.FromStream(ms);
                pwd_view_pp.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch
            {
                pwd_view_pp.Image = SAD_2_PTT_01.Properties.Resources.PWD_1;
                pwd_view_pp.SizeMode = PictureBoxSizeMode.Zoom;
            }

            if (pwd_view_status.Text == "Active")
                pwd_view_status.ForeColor = Color.FromArgb(0, 192, 0);
            else
                pwd_view_status.ForeColor = Color.FromArgb(192, 0, 0);

            pwd_view_emp_status.Text = main_data.Rows[0]["employment_status"].ToString();
            pwd_view_noemp.Text = main_data.Rows[0]["nature_of_employer"].ToString();
            pwd_view_toemp.Text = main_data.Rows[0]["type_of_employment"].ToString();
            pwd_view_toskill.Text = main_data.Rows[0]["type_of_skill"].ToString();
            lbl_id_no.Text = main_data.Rows[0]["id_no"].ToString();
            //<-----[OTHER INFO]----->
            pwd_view_org_aff.Text = other_data.Rows[0]["organization_aff"].ToString();
            pwd_view_contact_person.Text = other_data.Rows[0]["contact_person"].ToString();
            pwd_view_office_address.Text = other_data.Rows[0]["office_address"].ToString();
            pwd_view_org_tel_no.Text = other_data.Rows[0]["tel_no"].ToString();
            pwd_view_sss_no.Text = other_data.Rows[0]["sss_no"].ToString();
            pwd_view_gsis_no.Text = other_data.Rows[0]["gsis_no"].ToString();
            pwd_view_phealth_no.Text = other_data.Rows[0]["phealth_no"].ToString();
            pwd_view_phealth_status.Text = other_data.Rows[0]["phealth_status"].ToString();
            pwd_view_reporting_unit.Text = other_data.Rows[0]["name_of_reporting_unit"].ToString();
            pwd_view_accomplished_by1.Text = other_data.Rows[0]["accomplished_by"].ToString();
            //<-----[PARENTAL INFO]----->
            pwd_view_father.Text = parental_data.Rows[0]["father"].ToString();
            pwd_view_mother.Text = parental_data.Rows[0]["mother"].ToString();
            pwd_view_guardian.Text = parental_data.Rows[0]["guardian"].ToString();
        }
        #endregion

        private void pwd_view_edit_Click(object sender, EventArgs e)
        {
            int loc_x = reference_to_main.Location.X + 71;
            int loc_y = reference_to_main.Location.Y + 28;

            pwd_add edit = new pwd_add();
            edit.reference_to_view = this;
            edit.reference_to_main = this.reference_to_main;
            edit.Location = new Point(loc_x, loc_y);
            edit.pwd_update_id = current_pwd;
            edit.from_view = true;
            edit.update_mode = true;
            edit.update_regis_no = pwd_view_regis_no.Text;
            edit.update_id_no = lbl_id_no.Text;
            Console.WriteLine("[PWD] ->> [EDIT-MODE]");
            edit.ShowDialog();
            if (success == true)
            {
                show_success_message();
            }
        }

        public string notification_;

        public void show_success_message()
        {
            //827, 531
            success = false;
            system_notify = new system_notification();
            system_notify.Location = new Point(reference_to_main.Location.X + 827, reference_to_main.Location.Y + 531);
            system_notify.notification_message = notification_;
            system_notify.Show();
            notification_ = "";
        }

    }
}
