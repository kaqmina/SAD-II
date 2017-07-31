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
    public partial class pwd_view : Form
    {
        public pwd_view()
        {
            InitializeComponent();

            //initialize color tab button 
            btn_tab1.BackColor = Color.White;
        }

        public main_form reference_to_main { get; set; }
        main_functions main_f = new main_functions();
        connections conn = new connections();
        public int current_pwd = 0;

        #region FormLoad/STARTUP ST - 00
        private void pwd_view_back_Click(object sender, EventArgs e)
        {
            reference_to_main.side_tab.Enabled = true;
            reference_to_main.dboard_head.Enabled = true;
            this.Close();
        }
        
        private void pwd_view_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            startup_opacity.Start();
            pwd_load_data(current_pwd);
        }

        private void startup_opacity_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.1;
        }
        #endregion

        #region View Information Panel Tab Buttons
        private void btn_tab1_Click(object sender, EventArgs e)
        {
            //Visibility
            pnl1.Visible = true;
            pnl2.Visible = false;
            pnl3.Visible = false;

            //Button Color
            btn_tab1.BackColor = Color.White;
            btn_tab2.BackColor = btn_tab3.BackColor = Color.LightGray;
        }

        private void btn_tab2_Click(object sender, EventArgs e)
        {
            //Visibility
            pnl2.Visible = true;
            pnl1.Visible = false;
            pnl3.Visible = false;

            //Button Color
            btn_tab2.BackColor = Color.White;
            btn_tab1.BackColor = btn_tab3.BackColor = Color.LightGray;
        }

        private void btn_tab3_Click(object sender, EventArgs e)
        {
            //Visibility
            pnl3.Visible = true;
            pnl1.Visible = false;
            pnl2.Visible = false;

            //Button Color
            btn_tab3.BackColor = Color.White;
            btn_tab1.BackColor = btn_tab2.BackColor = Color.LightGray;
        }
        #endregion

        #region PWD DATA Paste
        public void pwd_load_data(int current_pwd)
        {
            DataTable main_data = new DataTable();
            DataTable other_data = new DataTable();
            DataTable parental_data = new DataTable();
            conn.pwd_view_profile(current_pwd, main_data, other_data, parental_data);

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
