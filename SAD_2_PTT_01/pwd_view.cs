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
    public partial class pwd_view : Form
    {
        public pwd_view()
        {
            InitializeComponent();
        }
        public main_form reference_to_main { get; set; }
        connections_pwd conn_pwd = new connections_pwd();
        public int current_pwd = 0;

        #region ON-LOAD
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
            this.Close();
        }

        #endregion

        #region PWD DATA Paste
        public void pwd_load_data(int current_pwd)
        {
            DataTable main_data = new DataTable();
            DataTable other_data = new DataTable();
            DataTable parental_data = new DataTable();
            conn_pwd.pwd_view_profile(current_pwd, main_data, other_data, parental_data);

            //<-----[MAIN DATA]----->
            pwd_view_fullname.Text = main_data.Rows[0]["fullname"].ToString();
            pwd_view_disability.Text = main_data.Rows[0]["disability_type"].ToString();
            pwd_view_regis_no.Text = main_data.Rows[0]["registration_no"].ToString();
            pwd_view_app_date.Text = main_data.Rows[0]["application_date"].ToString();
            //pwd_view_district.Text = main_data.Rows[0][""] FIX
            pwd_view_dob.Text = main_data.Rows[0]["birthdate"].ToString();
            pwd_view_nationality.Text = main_data.Rows[0]["nationality"].ToString();
            pwd_view_address.Text = main_data.Rows[0]["address"].ToString();
            pwd_view_civil_status.Text = main_data.Rows[0]["civil_status"].ToString();
            pwd_view_tel_no.Text = main_data.Rows[0]["tel_no"].ToString();
            pwd_view_mobile_no.Text = main_data.Rows[0]["mobile_no"].ToString();
            pwd_view_email.Text = main_data.Rows[0]["email_add"].ToString();
            pwd_view_educ_att.Text = main_data.Rows[0]["educ_attainment"].ToString();
            pwd_view_status.Text = main_data.Rows[0]["status_pwd"].ToString();

            if (pwd_view_status.Text == "Active")
                pwd_view_status.ForeColor = Color.FromArgb(0, 192, 0);
            else
                pwd_view_status.ForeColor = Color.FromArgb(192, 0, 0);

            pwd_view_emp_status.Text = main_data.Rows[0]["employment_status"].ToString();
            pwd_view_noemp.Text = main_data.Rows[0]["nature_of_employer"].ToString();
            pwd_view_toemp.Text = main_data.Rows[0]["type_of_employment"].ToString();
            pwd_view_toskill.Text = main_data.Rows[0]["type_of_skill"].ToString();
            pwd_view_accomplished_by.Text = main_data.Rows[0]["accomplished_by"].ToString();
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
            //<-----[PARENTAL INFO]----->
            pwd_view_father.Text = parental_data.Rows[0]["father"].ToString();
            pwd_view_mother.Text = parental_data.Rows[0]["mother"].ToString();
            pwd_view_guardian.Text = parental_data.Rows[0]["guardian"].ToString();
        }
        #endregion
    }
}
