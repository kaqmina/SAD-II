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
        system_functions system_func = new system_functions();

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

        private void telno_KeyPress(object sender, KeyPressEventArgs e)
        {
            key_.key_number(sender, e);
        }

        private void email_KeyPress(object sender, KeyPressEventArgs e)
        {
            key_.key_letter(sender, e);
        }

        private void mobileno_KeyPress(object sender, KeyPressEventArgs e)
        {
            key_.key_number(sender, e);
        }

        private void orgtelno_KeyPress(object sender, KeyPressEventArgs e)
        {
            key_.key_number(sender, e);
        }

        private void sssno_KeyPress(object sender, KeyPressEventArgs e)
        {
            key_.key_number(sender, e);
        }

        private void gsisno_KeyPress(object sender, KeyPressEventArgs e)
        {
            key_.key_number(sender, e);
        }

        private void philhealthno_KeyPress(object sender, KeyPressEventArgs e)
        {
            key_.key_number(sender, e);
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
            panel_4_.Visible = false;
            panel_5_.Visible = false;
            panel_6_.Visible = false;
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

        private void pwd_next_Click(object sender, EventArgs e)
        {
            if (current_panel == 1)
            {
                panel_1_.Visible = false;
                panel_2_.Visible = true;
                pwd_next.Enabled = false;
                panel_2_next();
                current_panel = 2;
                btn_personal.Enabled = true;
            }
            else if (current_panel == 2)
            {
                panel_2_.Visible = false;
                panel_3_.Visible = true;
                pwd_next.Enabled = false;
                panel_3_next();
                current_panel = 3;
                btn_contact.Enabled = true;
            } else if (current_panel == 3)
            {
                panel_3_.Visible = false;
                panel_4_.Visible = true;
                pwd_next.Enabled = false;
                panel_4_next();
                current_panel = 4;
                btn_educational.Enabled = true;
            } else if (current_panel == 4)
            {
                panel_4_.Visible = false;
                panel_5_.Visible = true;
                pwd_next.Enabled = false;
                panel_5_next();
                current_panel = 5;
                btn_employment.Enabled = true;
            }
        }

        int current_panel = 1;

        public void panel_1_next ()
        {
            if(pwd_regisno.Text != "" && pwd_appdate.Value.ToString() != "" && disability_type.Text != "") 
            {
                pwd_next.Enabled = true;
            } else
            {
                pwd_next.Enabled = false;
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
                dateofbirth.Value.ToString() != "" &&
                gender.Text != "" &&
                nationality.Text != "" &&
                bloodtype.SelectedIndex != 0 &&
                civilstatus.SelectedIndex != 0
                )
            {
                pwd_next.Enabled = true;
            } else
            {
                pwd_next.Enabled = false;
            }
        }

        public void panel_3_next()
        {
            if (telno.Text != "" && mobileno.Text != "" && email.Text != "")
            {
                pwd_next.Enabled = true;
            } else
            {
                pwd_next.Enabled = false;
            }
        }

        public void panel_4_next()
        {
            if(empstatus.SelectedIndex != 0 && noemp.SelectedIndex != 0 && typeoemp.SelectedIndex != 0)
            {
                pwd_next.Enabled = true;
            } else
            {
                pwd_next.Enabled = false;
            }
        }

        public void panel_5_next()
        {
            if(orgaff.Text != "" &&
                contactper.Text != "" &&
                officeadd.Text != "" &&
                orgtelno.Text != "" &&
                sssno.Text != "" &&
                gsisno.Text != "" &&
                philhealthno.Text != "" &&
                philhealthstatus.SelectedIndex != 0)
            {
                pwd_next.Enabled = true;
            } else
            {
                pwd_next.Enabled = false;
            }
        }
        #endregion

        #region FIELDS

        //<---[ Panel 1 ]---> START
        private void pwd_appdate_ValueChanged(object sender, EventArgs e)
        {
            application_date = pwd_appdate.Value.ToString("yyyy-MM-dd"); //date
            panel_1_next();
        }

        private void disability_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            disability = disability_type.SelectedIndex;
            panel_1_next();
        }
        private void pwd_regisno_TextChanged(object sender, EventArgs e)
        {
            panel_1_next();
        }
        //<---[ Panel 1 ]---> END

        //<---[ Panel 2 ]---> START
        private void gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gender.Text == "Male")
                sex = 0;
            else if (gender.Text == "Female")
                sex = 1;
            panel_2_next();
        }

        private void bloodtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            blood_type = bloodtype.SelectedIndex;
            panel_2_next();
        }

        private void civilstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            civil_status = civilstatus.SelectedIndex;
            panel_2_next();
        }

        private void district_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            district_id = district_type.SelectedIndex;
            panel_2_next();
        }

        private void ln_txt_TextChanged(object sender, EventArgs e)
        {
            panel_2_next();
        }

        private void fn_txt_TextChanged(object sender, EventArgs e)
        {
            panel_2_next();
        }

        private void mn_txt_TextChanged(object sender, EventArgs e)
        {
            panel_2_next();
        }

        private void hs_txt_TextChanged(object sender, EventArgs e)
        {
            panel_2_next();
        }

        private void bar_txt_TextChanged(object sender, EventArgs e)
        {
            panel_2_next();
        }

        private void mun_txt_TextChanged(object sender, EventArgs e)
        {
            panel_2_next();
        }

        private void prov_txt_TextChanged(object sender, EventArgs e)
        {
            panel_2_next();
        }

        private void dateofbirth_ValueChanged(object sender, EventArgs e)
        {
            dob = dateofbirth.Value.ToString("yyyy-MM-dd"); //date
            panel_2_next();
        }

        private void nationality_TextChanged(object sender, EventArgs e)
        {
            panel_2_next();
        }

        //<---[ Panel 2 ]---> END

        private void philhealthstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            phil_health_status = philhealthstatus.SelectedIndex;
        }
        
        private void type_of_skill(string status, string num)
        {
            if (status == "add")
            {
                if (skill1.Checked)
                    to_skill = 1;
                else if (skill2.Checked)
                    to_skill = 2;
                else if (skill3.Checked)
                    to_skill = 3;
                else if (skill4.Checked)
                    to_skill = 4;
                else if (skill5.Checked)
                    to_skill = 5;
                else if (skill6.Checked)
                    to_skill = 6;
                else if (skill7.Checked)
                    to_skill = 7;
                else if (skill8.Checked)
                    to_skill = 8;
                else if (skill9.Checked)
                    to_skill = 9;
                else
                    all_required = false;
            }
            else
            {
                if (num == "1")
                    skill1.Checked = true;
                else if (num == "2")
                    skill2.Checked = true;
                else if (num == "3")
                    skill3.Checked = true;
                else if (num == "4")
                    skill4.Checked = true;
                else if (num == "5")
                    skill5.Checked = true;
                else if (num == "6")
                    skill6.Checked = true;
                else if (num == "7")
                    skill7.Checked = true;
                else if (num == "8")
                    skill8.Checked = true;
                else if (num == "9")
                    skill9.Checked = true;
            }
        }


        #endregion

        //<---[ Panel 3 ]---> START
        private void telno_TextChanged(object sender, EventArgs e)
        {
            panel_3_next();
        }

        private void email_TextChanged(object sender, EventArgs e)
        {
            panel_3_next();
        }

        private void mobileno_TextChanged(object sender, EventArgs e)
        {
            panel_3_next();
        }

        private void educ_attainment(string status, string num)
        {
            if (status == "add")
            {
                if (educ1.Checked)
                    educ_att = 1;
                else if (educ2.Checked)
                    educ_att = 2;
                else if (educ3.Checked)
                    educ_att = 3;
                else if (educ4.Checked)
                    educ_att = 4;
                else if (educ5.Checked)
                    educ_att = 5;
                else if (educ6.Checked)
                    educ_att = 6;
                else if (educ7.Checked)
                    educ_att = 7;
                else if (educ8.Checked)
                    educ_att = 8;
                else if (educ9.Checked)
                    educ_att = 9;
                else if (educ0.Checked)
                    educ_att = 0;
                else
                    all_required = false;
            }
            else
            {

                if (num == "1")
                    educ1.Checked = true;
                else if (num == "2")
                    educ2.Checked = true;
                else if (num == "3")
                    educ3.Checked = true;
                else if (num == "4")
                    educ4.Checked = true;
                else if (num == "5")
                    educ5.Checked = true;
                else if (num == "6")
                    educ6.Checked = true;
                else if (num == "7")
                    educ7.Checked = true;
                else if (num == "8")
                    educ8.Checked = true;
                else if (num == "9")
                    educ9.Checked = true;
                else if (num == "0")
                    educ0.Checked = true;
            }
        }
        //<---[ Panel 3 ]---> END

        //<---[ Panel 4 ]---> START
        private void empstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            emp_status = empstatus.SelectedIndex;
            panel_4_next();
        }

        private void noemp_SelectedIndexChanged(object sender, EventArgs e)
        {
            no_emp = noemp.SelectedIndex;
            panel_4_next();
        }

        private void typeoemp_SelectedIndexChanged(object sender, EventArgs e)
        {
            type_oemp = typeoemp.SelectedIndex;
            panel_4_next();
        }

        
        //<---[ Panel 4 ]---> END

        //<---[ Panel 5 ]---> START
    }
}
