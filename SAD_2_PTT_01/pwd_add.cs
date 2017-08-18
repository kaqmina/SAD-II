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
    public partial class pwd_add : Form
    {
        public pwd_add()
        {
            InitializeComponent();
        }
        public main_form reference_to_main { get; set; }
        connections_pwd conn_pwd = new connections_pwd();
        shadow shadow_;
        system_keypress key_ = new system_keypress();

        #region VARIABLES

        string application_date = null;// date
        string firstname;
        string lastname;
        string middlename;
        string has;
        string mun;
        string bar;
        string prov;
        string reg;
        string dob = null;
        string natio;
        string e_mail;
        string organiaff;
        string contact_person;
        string office_address;
        string father_ln;
        string father_fn;
        string father_mn;
        string mother_ln;
        string mother_fn;
        string mother_mn;
        string guardian_ln;
        string guardian_fn;
        string guardian_mn;
        string accom;
        string end_date = "07/07/17";
        string added_date;
        string no_unit;
        int district_id;
        int registration_no;
        int disability;
        int sex;
        int blood_type;
        int tel_no;
        int mobile_no;
        int emp_status;
        int no_emp;
        int type_oemp;
        int org_telno;
        int sss_no;
        int gsis_no;
        int phil_health_status;
        int phil_health_no;
        int educ_att;
        int to_skill;
        int civil_status;
        int pwd_status;
        public int pwd_update_id = 0;
        bool all_required = false;
        Image picture = null;

        #endregion

        #region BTN-BACK|KEY-PRESS
        public bool continue_;

        private void pwd_add_back_Click(object sender, EventArgs e)
        {
            shadow_ = new shadow();
            shadow_.Location = new Point(this.Location.X, this.Location.Y);
            shadow_.Show();
            pwd_ask prompt = new pwd_ask();
            prompt.reference_to_main = this;
            prompt.ShowDialog();
            shadow_.Close();

            if (continue_)
            {
                //nothing
            } else
            {
                this.Close();
            }
        }

        private void pwd_regisno_KeyPress(object sender, KeyPressEventArgs e)
        {
            key_.key_number(sender, e);
        }

        private void ln_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            key_.key_letter(sender, e);
        }

        private void fn_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            key_.key_letter(sender, e);
        }

        private void mn_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            key_.key_letter(sender, e);
        }

        private void nationality_KeyPress(object sender, KeyPressEventArgs e)
        {
            key_.key_letter(sender, e);
        }
        #endregion

        #region ON_LOAD

        public void load_date_time_picker_max_date()
        {
            pwd_appdate.MaxDate = DateTime.Now;
            dateofbirth.MaxDate = DateTime.Now;
        }

        public void load_combobox()
        {
            conn_pwd.populate_cbox(disability_type, district_type);
        }

        public void load_panel_visibility()
        {
            panel_1_.Visible = true;
            panel_2_.Visible = false;
            panel_3_.Visible = false;
        }

        public void load_panel_quick_button_enabled()
        {
            btn_general.Enabled = true;
            btn_personal.Enabled = false;
            btn_contact.Enabled = false;
            btn_educational.Enabled = false;
            btn_employment.Enabled = false;
            btn_type_of_skill.Enabled = false;
            btn_organizational.Enabled = false;
            btn_other.Enabled = false;
            btn_parental.Enabled = false;
            pwd_next.Enabled = false;
        }

        private void pwd_add_Load(object sender, EventArgs e)
        {
            load_date_time_picker_max_date();
            load_combobox();
            load_panel_visibility();
            load_panel_quick_button_enabled();
        }

        #endregion

        #region BTN-NEXT

        int current_panel = 1;

        public void panel_1_next ()
        {
            if(pwd_regisno.Text != "" && pwd_appdate.Value.ToString() != "" && disability_type.Text != "") 
            {
                pwd_next.Enabled = true;
            }
        }

        public void panel_2_next()
        {
            if(fn_txt.Text != "" && 
                mn_txt.Text != "" &&
                ln_txt.Text != "" &&
                hs_txt.Text != "" &&
                bar_txt.Text != "" &&
                mun_txt.Text != "" &&
                prov_txt.Text != "" &&
                district_type.SelectedIndex != 0 &&
                dob != null &&
                gender.Text != "" &&
                nationality.Text != "" &&
                bloodtype.Text != "" &&
                civilstatus.Text != ""
                )
            {
                pwd_next.Enabled = true;
            }
        }

        public void panel_3_next()
        {

        }

        #endregion

        private void pwd_appdate_ValueChanged(object sender, EventArgs e)
        {
            application_date = pwd_appdate.Value.ToString("yyyy-MM-dd"); //date
            panel_1_next();
        }

        private void disability_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            disability = disability_type.SelectedIndex;
            panel_2_next();
        }
        private void pwd_regisno_TextChanged(object sender, EventArgs e)
        {
            panel_1_next();
        }


        private void pwd_next_Click(object sender, EventArgs e)
        {
            if(current_panel == 1)
            {
                panel_1_.Visible = false;
                panel_2_.Visible = true;
                pwd_next.Enabled = false;
                panel_2_next();
                current_panel = 2;
            } else if (current_panel == 2)
            {
                panel_2_.Visible = false;
                panel_3_.Visible = true;
                pwd_next.Enabled = false;
                panel_3_next();
                current_panel = 3;
            }
        }

        private void panel_2__TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        
    }
}
