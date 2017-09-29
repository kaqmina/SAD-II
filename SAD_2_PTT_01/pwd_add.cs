using System;
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
    public partial class pwd_add : Form
    {
        public pwd_add()
        {
            InitializeComponent();
        }
        public main_form reference_to_main { get; set; }
        public pwd_view reference_to_view { get; set; }
        connections_pwd conn_pwd = new connections_pwd();
        connections_disability conn_disa = new connections_disability();
        connections_user conn_user = new connections_user();
        shadow shadow_;
        pwd_ask prompt;
        system_keypress key_ = new system_keypress();
        system_functions system_func = new system_functions();
        public bool from_view = false;

        #region VARIABLES

        string application_date = null;// date
        string end_date;
        string added_date = DateTime.Now.ToString("yyyy-MM-dd");
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
        string accom_ln;
        string accom_fn;
        string accom_mn;
        string no_unit;
        string id_no_;
        int district_id;
        string registration_no;
        int disability;
        int sex;
        int blood_type;
        string tel_no;
        string mobile_no;
        int emp_status;
        int no_emp;
        int type_oemp;
        string org_telno;
        string sss_no;
        string gsis_no;
        int phil_health_status;
        string phil_health_no;
        int educ_att;
        int to_skill;
        int civil_status;
        int pwd_status;
        public string pwd_update_id = "0";
        bool all_required = false;
        public bool update_mode = false;
        public string update_regis_no = "";
        public string update_id_no = "";
        Image picture = null;

        #endregion

        #region BTN-BACK|KEY-PRESS
        public bool continue_;
        bool confirmation = false;

        private void pwd_add_back_Click(object sender, EventArgs e)
        {
            confirmation = true;
            shadow_ = new shadow();
            shadow_.reference_to_main = this.reference_to_main;
            prompt = new pwd_ask();
            prompt.reference_to_main = this;
            shadow_.form_to_show = prompt;
            shadow_.ShowDialog();
            //confirmation = false;

            if (continue_)
            {
                //nothing
            } else
            {
                exit_opacity.Start();
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

        private void fln_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            key_.key_letter(sender, e);
        }

        private void ffn_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            key_.key_letter(sender, e);
        }

        private void fmn_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            key_.key_letter(sender, e);
        }

        private void mln_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            key_.key_letter(sender, e);
        }

        private void mfn_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            key_.key_letter(sender, e);
        }

        private void mmn_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            key_.key_letter(sender, e);
        }

        private void gln_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            key_.key_letter(sender, e);
        }

        private void gfn_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            key_.key_letter(sender, e);
        }

        private void gmn_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            key_.key_letter(sender, e);
        }

        private void aln_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            key_.key_letter(sender, e);
        }

        private void afn_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            key_.key_letter(sender, e);
        }

        private void amn_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            key_.key_letter(sender, e);
        }

        private void id_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            key_.key_number_letter(sender, e);
        }
        #endregion

        #region ON_LOAD - ON_CLOSE

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
                //found
                exit_opacity.Stop();
                if (update_mode)
                {
                    if(from_view)
                    {
                        reference_to_view.notification_ = "Updated PWD Profile! Registration #:" + "\n" + registration_no;
                    } else
                    {
                        reference_to_main.notification_ = "Updated PWD Profile! Registration #:" + "\n" + registration_no;
                    }
                }
                else
                {
                    reference_to_main.notification_ = "Added PWD Profile! Registration #:" + "\n" + registration_no;
                }
                this.Close();
            }
        }

        public void load_date_time_picker_max_date()
        {
            pwd_appdate.MaxDate = DateTime.Now;
            dateofbirth.MaxDate = pwd_appdate.Value;
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
            if (update_mode == false)
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
        }

        public void load_combobox_initial_selected_index()
        {
            disability_type.SelectedIndex = 0;
            district_type.SelectedIndex = 0;
            gender.SelectedIndex = 0;
            bloodtype.SelectedIndex = 0;
            civilstatus.SelectedIndex = 0;
            empstatus.SelectedIndex = 0;
            noemp.SelectedIndex = 0;
            typeoemp.SelectedIndex = 0;
            philhealthstatus.SelectedIndex = 0;
        }

        private void pwd_add_Load(object sender, EventArgs e)
        {
            load_date_time_picker_max_date();
            load_combobox();
            load_panel_visibility();
            load_panel_quick_button_enabled();
            load_combobox_initial_selected_index();

            btn_revert.Visible = false;

            startup_opacity.Start();

            current_panel_active = panel_1_;
            if (update_mode)
            {
                paste_data();
                btn_revert.Visible = true;
                btn_mode_status.Text = "UPDATE PWD PROFILE";
            }
                
        }

        private void pwd_add_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
        #endregion

        #region BTN-NEXT

        public void btn_side_active()
        {
            btn_general.BackColor = Color.FromArgb(255, 255, 255);
            btn_personal.BackColor = Color.FromArgb(255, 255, 255);
            btn_contact.BackColor = Color.FromArgb(255, 255, 255);
            btn_educational.BackColor = Color.FromArgb(255, 255, 255);
            btn_type_of_skill.BackColor = Color.FromArgb(255, 255, 255);
            btn_employment.BackColor = Color.FromArgb(255, 255, 255);
            btn_organizational.BackColor = Color.FromArgb(255, 255, 255);
            btn_other.BackColor = Color.FromArgb(255, 255, 255);
            btn_parental.BackColor = Color.FromArgb(255, 255, 255);

            if (current_panel == 1)
            {
                btn_general.BackColor = Color.FromArgb(240, 240, 240);
            } else if (current_panel == 2)
            {
                btn_personal.BackColor = Color.FromArgb(240, 240, 240);
            } else if (current_panel == 3)
            {
                btn_contact.BackColor = Color.FromArgb(240, 240, 240);
                btn_educational.BackColor = Color.FromArgb(240, 240, 240);
            } else if (current_panel == 4)
            {
                btn_employment.BackColor = Color.FromArgb(240, 240, 240);
                btn_type_of_skill.BackColor = Color.FromArgb(240, 240, 240);
            } else if (current_panel == 5)
            {
                btn_organizational.BackColor = Color.FromArgb(240, 240, 240);
                btn_other.BackColor = Color.FromArgb(240, 240, 240);
            } else
            {
                btn_parental.BackColor = Color.FromArgb(240, 240, 240);
            }
        }

        private void pwd_next_Click(object sender, EventArgs e)
        {
            if (current_panel == 1) //PANEL 2
            {
                pwd_next.Text = "NEXT";
                panel_1_.Visible = false;
                panel_2_.Visible = true;
                pwd_next.Enabled = false;
                panel_2_next();
                current_panel = 2;
                btn_personal.Enabled = true;
                current_panel_active = panel_2_;
            }
            else if (current_panel == 2) //PANEL 3
            {
                pwd_next.Text = "NEXT";
                panel_2_.Visible = false;
                panel_3_.Visible = true;
                pwd_next.Enabled = false;
                panel_3_next();
                current_panel = 3;
                btn_contact.Enabled = true;
                btn_educational.Enabled = true;
                current_panel_active = panel_3_;

            } else if (current_panel == 3) //PANEL 4
            {
                pwd_next.Text = "NEXT";
                panel_3_.Visible = false;
                panel_4_.Visible = true;
                pwd_next.Enabled = false;
                panel_4_next();
                current_panel = 4;
                btn_employment.Enabled = true;
                btn_type_of_skill.Enabled = true;
                current_panel_active = panel_4_;
            } else if (current_panel == 4) //PANEL 5
            {
                pwd_next.Text = "NEXT";
                panel_4_.Visible = false;
                panel_5_.Visible = true;
                pwd_next.Enabled = false;
                panel_5_next();
                current_panel = 5;
                btn_organizational.Enabled = true;
                btn_other.Enabled = true;
                current_panel_active = panel_5_;
            } else if (current_panel == 5) //PANEL 6
            {
                panel_5_.Visible = false;
                panel_6_.Visible = true;
                pwd_next.Enabled = false;
                panel_6_next();
                current_panel = 6;
                btn_parental.Enabled = true;
                current_panel_active = panel_6_;
                if(update_mode)
                {
                    pwd_next.Text = "UPDATE";
                } else
                {
                    pwd_next.Text = "ADD";
                }
            } else if (current_panel == 6)
            {
                pwd_add_update_profile();
            }
            btn_side_active();
        }

        int current_panel = 1;
        Panel current_panel_active;

        public void panel_1_next ()
        {
            if(pwd_regisno.Text != "" && pwd_appdate.Value.ToString() != "" && disability_type.Text != "" && lbl_regis_no_error.Visible == false && lbl_id_no_error.Visible == false) 
            {
                pwd_next.Enabled = true;
                btn_general.ForeColor = Color.FromArgb(41, 45, 56);
            } else
            {
                pwd_next.Enabled = false;
                btn_general.ForeColor = Color.Red;
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
                btn_personal.ForeColor = Color.FromArgb(41, 45, 56);
            } else
            {
                pwd_next.Enabled = false;
                btn_personal.ForeColor = Color.Red;
            }
        }

        public void panel_3_next()
        {
            if (telno.Text != "" && mobileno.Text != "" && email.Text != "")
            {
                pwd_next.Enabled = true;
                btn_contact.ForeColor = Color.FromArgb(41, 45, 56);
            } else
            {
                pwd_next.Enabled = false;
                btn_contact.ForeColor = Color.Red;
            }
        }

        public void panel_4_next()
        {
            if(empstatus.SelectedIndex == 1 && noemp.SelectedIndex != 0 && typeoemp.SelectedIndex != 0)
            {
                pwd_next.Enabled = true;
                btn_employment.ForeColor = Color.FromArgb(41, 45, 56);
            } else if (empstatus.SelectedIndex > 1 && noemp.SelectedIndex == 0 && typeoemp.SelectedIndex == 0)
            {
                pwd_next.Enabled = true;
                btn_employment.ForeColor = Color.FromArgb(41, 45, 56);
            }
            else
            {
                pwd_next.Enabled = false;
                btn_employment.ForeColor = Color.Red;
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
                if (orgaff.Text != "" && contactper.Text != "" && officeadd.Text != "" && orgtelno.Text != "")
                {
                    btn_organizational.ForeColor = Color.FromArgb(41, 45, 56);
                }
                if (sssno.Text != "" && gsisno.Text != "" && philhealthno.Text != "" && philhealthstatus.SelectedIndex != 0)
                {
                    btn_other.ForeColor = Color.FromArgb(41, 45, 56);
                }
            } else
            {
                pwd_next.Enabled = false;
                if (orgaff.Text == "" || contactper.Text == "" || officeadd.Text == "" || orgtelno.Text == "")
                {
                    btn_organizational.ForeColor = Color.Red;
                }
                if (sssno.Text == "" || gsisno.Text == "" || philhealthno.Text == "" || philhealthstatus.SelectedIndex == 0)
                {
                    btn_other.ForeColor = Color.Red;
                }
            }
        }

        public void panel_6_next()
        {
            if(fln_txt.Text != "" &&
                ffn_txt.Text != "" &&
                fmn_txt.Text != "" &&
                mln_txt.Text != "" &&
                mfn_txt.Text != "" &&
                mmn_txt.Text != "" &&
                gln_txt.Text != "" &&
                gfn_txt.Text != "" &&
                gmn_txt.Text != "" &&
                aln_txt.Text != "" &&
                afn_txt.Text != "" &&
                amn_txt.Text != "" &&
                norunit.Text != "" &&
                lbl_regis_no_error.Visible == false)
            {
                pwd_next.Enabled = true;
                btn_parental.ForeColor = Color.FromArgb(41, 45, 56);
            } else
            {
                pwd_next.Enabled = false;
                btn_parental.ForeColor = Color.Red;
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
            disability = int.Parse(conn_disa.get_disability_by_name(disability_type.Text));
            panel_1_next();
        }
        private void pwd_regisno_TextChanged(object sender, EventArgs e)
        {
            if (conn_pwd.pwd_check_registration_has_duplicate(pwd_regisno.Text, update_regis_no) == true)
            {
                lbl_regis_no_error.Visible = true;
                panel_1_next();
            }
            else
            {
                lbl_regis_no_error.Visible = false;
                panel_1_next();
            }
            
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
            panel_2_next();
        }

        private void nationality_TextChanged(object sender, EventArgs e)
        {
            panel_2_next();
        }

        //<---[ Panel 2 ]---> END

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
            if (emp_status == 1)
            {
                noemp.Enabled = true;
                typeoemp.Enabled = true;
            } else
            {
                noemp.SelectedIndex = 0;
                typeoemp.SelectedIndex = 0;
                noemp.Enabled = false;
                typeoemp.Enabled = false;
            }
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


        //<---[ Panel 4 ]---> END

        //<---[ Panel 5 ]---> START

        private void orgaff_TextChanged(object sender, EventArgs e)
        {
            panel_5_next();
        }

        private void officeadd_TextChanged(object sender, EventArgs e)
        {
            panel_5_next();
        }

        private void contactper_TextChanged(object sender, EventArgs e)
        {
            panel_5_next();
        }

        private void orgtelno_TextChanged(object sender, EventArgs e)
        {
            panel_5_next();
        }

        private void sssno_TextChanged(object sender, EventArgs e)
        {
            panel_5_next();
        }

        private void gsisno_TextChanged(object sender, EventArgs e)
        {
            panel_5_next();
        }

        private void philhealthno_TextChanged(object sender, EventArgs e)
        {
            panel_5_next();
        }

        private void philhealthstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            phil_health_status = philhealthstatus.SelectedIndex;
            panel_5_next();
        }


        //<---[ Panel 5 ]---> END

        //<---[ Panel 6 ]---> START

        private void fln_txt_TextChanged(object sender, EventArgs e)
        {
            panel_6_next();
        }

        private void ffn_txt_TextChanged(object sender, EventArgs e)
        {
            panel_6_next();
        }

        private void fmn_txt_TextChanged(object sender, EventArgs e)
        {
            panel_6_next();
        }

        private void mln_txt_TextChanged(object sender, EventArgs e)
        {
            panel_6_next();
        }

        private void mfn_txt_TextChanged(object sender, EventArgs e)
        {
            panel_6_next();
        }

        private void mmn_txt_TextChanged(object sender, EventArgs e)
        {
            panel_6_next();
        }

        private void gln_txt_TextChanged(object sender, EventArgs e)
        {
            panel_6_next();
        }

        private void gfn_txt_TextChanged(object sender, EventArgs e)
        {
            panel_6_next();
        }

        private void gmn_txt_TextChanged(object sender, EventArgs e)
        {
            panel_6_next();
        }

        private void aln_txt_TextChanged(object sender, EventArgs e)
        {
            panel_6_next();
        }

        private void afn_txt_TextChanged(object sender, EventArgs e)
        {
            panel_6_next();
        }

        private void amn_txt_TextChanged(object sender, EventArgs e)
        {
            panel_6_next();
        }

        private void norunit_TextChanged(object sender, EventArgs e)
        {
            panel_6_next();
        }

        private void status_pwd(string status, string num)
        {
            if (status == "add")
            {
                if (status_active.Checked)
                    pwd_status = 1;
                else if (status_ex_inactive.Checked)
                    pwd_status = 0;
            }
            else
            {
                if (num == "1")
                    status_active.Checked = true;
                else if (num == "0")
                    status_ex_inactive.Checked = true;
            }
        }

        //<---[ Panel 6 ]---> END

        #endregion

        #region MODIFY-DATABASE
        public void pwd_add_update_profile()
        {
            set_data();
            if (pwd_next.Text.ToLower() == "add")
            {
                pwd_add_profile();
            }
            else if (pwd_next.Text.ToLower() == "update")
            {
                pwd_update_profile(pwd_update_id);
            }
        }

        public void set_data()
        {
            #region <---[ MAIN DATA ]--->

            id_no_ = id_no.Text;
            application_date = pwd_appdate.Value.ToString("yyyy-MM-dd"); //date
            end_date = pwd_appdate.Value.AddYears(3).ToString("yyyy-MM-dd"); //date
            firstname = fn_txt.Text;
            lastname = ln_txt.Text;
            middlename = mn_txt.Text;
            has = hs_txt.Text;
            mun = mun_txt.Text;
            bar = bar_txt.Text;
            prov = prov_txt.Text;
            district_id = district_type.SelectedIndex;
            dob = dateofbirth.Value.ToString("yyyy-MM-dd"); //date
            natio = nationality.Text;
            registration_no = pwd_regisno.Text;
            tel_no = telno.Text;
            mobile_no = mobileno.Text;
            e_mail = email.Text;
            status_pwd("add", "-");
            educ_attainment("add", "-");
            type_of_skill("add", "-");

            #endregion

            #region <-----[OTHER INFO]----->

            org_telno = orgtelno.Text;
            sss_no = sssno.Text;
            gsis_no = gsisno.Text;
            phil_health_no = philhealthno.Text;
            organiaff = orgaff.Text;
            contact_person = contactper.Text;
            office_address = officeadd.Text;
            no_unit = norunit.Text;
            accom_ln = aln_txt.Text;
            accom_fn = afn_txt.Text;
            accom_mn = amn_txt.Text;

            #endregion

            #region <-----[PARENTAL INFO]----->

            father_ln = fln_txt.Text;
            father_fn = ffn_txt.Text;
            father_mn = fmn_txt.Text;
            mother_ln = mln_txt.Text;
            mother_fn = mfn_txt.Text;
            mother_mn = mmn_txt.Text;
            guardian_ln = gln_txt.Text;
            guardian_fn = gfn_txt.Text;
            guardian_mn = gmn_txt.Text;

            #endregion

        }

        public void pwd_add_profile()
        {
            string main_data;
            string main_variables;
            string other_data;
            string other_variables;
            string parental_data;
            string parental_variables;
            bool success;
            string new_id = "0";
            bool has_pic = false;
            var pic_file = picturetoDB(pwd_pic_box.Image);

            #region main_data
            if (pwd_pic_box.Image == null)
            {
                has_pic = false;
                #region MAIN-FIELDS
                main_data = "INSERT INTO p_dao.pwd(lastname, "
                                            + "firstname, "
                                            + "middlename, "
                                            + "id_no, "
                                            + "sex, "
                                            + "disability_id, "
                                            + "address_house_no_street, "
                                            + "address_barangay, "
                                            + "address_municipality, "
                                            + "address_province, "
                                            + "district_id, "
                                            + "blood_type, "
                                            + "birthdate, "
                                            + "tel_no, "
                                            + "mobile_no, "
                                            + "email_add, "
                                            + "civil_status, "
                                            + "nationality, "
                                            + "end_date, "
                                            + "added_date, "
                                            + "application_date, "
                                            + "educ_attainment, "
                                            + "employment_status, "
                                            + "nature_of_employer, "
                                            + "type_of_employment, "
                                            + "registration_no, "
                                            + "status_pwd, "
                                            + "type_of_skill, "
                                            + "user_id) ";
                #endregion
                #region MAIN-VARIABLES
                main_variables = "VALUES ('" + lastname
                                             + "', '"
                                             + firstname
                                             + "', '"
                                             + middlename
                                             + "', '"
                                             + id_no_
                                             + "', "
                                             + sex
                                             + ", "
                                             + disability
                                             + ", '"
                                             + has
                                             + "', '"
                                             + bar
                                             + "', '"
                                             + mun
                                             + "', '"
                                             + prov
                                             + "', "
                                             + district_id
                                             + ", '"
                                             + blood_type
                                             + "', '"
                                             + dob
                                             + "', '"
                                             + tel_no
                                             + "', '"
                                             + mobile_no
                                             + "', '"
                                             + e_mail
                                             + "', "
                                             + civil_status
                                             + ", '"
                                             + natio
                                             + "', '"
                                             + end_date
                                             + "', '"
                                             + (DateTime.Now.ToString("yyyy-MM-dd"))
                                             + "', '"
                                             + application_date
                                             + "', "
                                             + educ_att
                                             + ", "
                                             + emp_status
                                             + ", "
                                             + no_emp
                                             + ", "
                                             + type_oemp
                                             + ", '"
                                             + registration_no
                                             + "', "
                                             + pwd_status
                                             + ", "
                                             + to_skill
                                             + ", "
                                             + "(SELECT user_id FROM p_dao.user WHERE username = '" + reference_to_main.current_user + "')"
                                             + ")";
                #endregion
            }
            else
            {
                has_pic = true;
                #region MAIN-FIELDS-PIC
                main_data = "INSERT INTO p_dao.pwd(lastname, "
                                            + "firstname, "
                                            + "middlename, "
                                            + "id_no, "
                                            + "sex, "
                                            + "disability_id, "
                                            + "address_house_no_street, "
                                            + "address_barangay, "
                                            + "address_municipality, "
                                            + "address_province, "
                                            + "district_id, "
                                            + "blood_type, "
                                            + "birthdate, "
                                            + "tel_no, "
                                            + "mobile_no, "
                                            + "email_add, "
                                            + "civil_status, "
                                            + "nationality, "
                                            + "end_date, "
                                            + "added_date, "
                                            + "application_date, "
                                            + "educ_attainment, "
                                            + "employment_status, "
                                            + "nature_of_employer, "
                                            + "type_of_employment, "
                                            + "registration_no, "
                                            + "status_pwd, "
                                            + "type_of_skill, "
                                            + "user_id, "
                                            + "picture) ";
                #endregion
                #region MAIN-VARIABLES-PIC

                main_variables = "VALUES ('" + lastname
                                         + "', '"
                                         + firstname
                                         + "', '"
                                         + middlename
                                         + "', '"
                                         + id_no_
                                         + "', "
                                         + sex
                                         + ", "
                                         + disability
                                         + ", '"
                                         + has
                                         + "', '"
                                         + bar
                                         + "', '"
                                         + mun
                                         + "', '"
                                         + prov
                                         + "', "
                                         + district_id
                                         + ", '"
                                         + blood_type
                                         + "', '"
                                         + dob
                                         + "', '"
                                         + tel_no
                                         + "', '"
                                         + mobile_no
                                         + "', '"
                                         + e_mail
                                         + "', "
                                         + civil_status
                                         + ", '"
                                         + natio
                                         + "', '"
                                         + end_date
                                         + "', '"
                                         + (DateTime.Now.ToString("yyyy-MM-dd"))
                                         + "', '"
                                         + application_date
                                         + "', "
                                         + educ_att
                                         + ", "
                                         + emp_status
                                         + ", "
                                         + no_emp
                                         + ", "
                                         + type_oemp
                                         + ", '"
                                         + registration_no
                                         + "', "
                                         + pwd_status
                                         + ", "
                                         + to_skill
                                         + ", "
                                         + "(SELECT user_id FROM p_dao.user WHERE username = '" + reference_to_main.current_user + "'), "
                                         + "@Image "
                                         + ")";

                #endregion
            }
            #endregion

            #region other_data
            other_data = "INSERT INTO p_dao.pwd_otherinfo(sss_no,"
                                                      + "gsis_no, "
                                                      + "phealth_no, "
                                                      + "phealth_status, "
                                                      + "organization_aff, "
                                                      + "contact_person, "
                                                      + "office_address, "
                                                      + "tel_no, "
                                                      + "name_of_reporting_unit, "
                                                      + "accomplished_by_fn, "
                                                      + "accomplished_by_mn, "
                                                      + "accomplished_by_ln, "
                                                      + "pwd_id) ";
            other_variables = "VALUES ('" + sss_no
                                         + "', '"
                                         + gsis_no
                                         + "', '"
                                         + phil_health_no
                                         + "', '"
                                         + phil_health_status
                                         + "', '"
                                         + organiaff
                                         + "', '"
                                         + contact_person
                                         + "', '"
                                         + office_address
                                         + "', '"
                                         + org_telno
                                         + "', '"
                                         + no_unit
                                         + "', '"
                                         + accom_fn
                                         + "', '"
                                         + accom_mn
                                         + "', '"
                                         + accom_ln
                                         + "', "
                                         + "(SELECT LAST_INSERT_ID()) )";
            #endregion

            #region parental_data
            parental_data = "INSERT INTO p_dao.parental_info(fatherfn, "
                                                         + "fathermn, "
                                                         + "fatherln, "
                                                         + "motherfn, "
                                                         + "mothermn, "
                                                         + "motherln, "
                                                         + "guardianfn, "
                                                         + "guardianmn, "
                                                         + "guardianln, "
                                                         + "pwd_id) ";
            parental_variables = "VALUES ('" + father_fn
                                             + "', '"
                                             + father_mn
                                             + "', '"
                                             + father_ln
                                             + "', '"
                                             + mother_fn
                                             + "', '"
                                             + mother_mn
                                             + "', '"
                                             + mother_ln
                                             + "', '"
                                             + guardian_fn
                                             + "', '"
                                             + guardian_mn
                                             + "', '"
                                             + guardian_mn
                                             + "', (SELECT LAST_INSERT_ID()) )";
            #endregion

            if (has_pic == false)
            {
                success = conn_pwd.pwd_add_profile((main_data + main_variables), (other_data + other_variables), (parental_data + parental_variables));
            } else
            {
                success = conn_pwd.pwd_add_profile((main_data + main_variables), (other_data + other_variables), (parental_data + parental_variables), pic_file);
            }

            if (success == true)
            {
                string user_id = conn_user.get_user_id_by_name(reference_to_main.current_user);
                new_id = conn_pwd.get_last_insert_id_pwd();
                conn_pwd.usr_log_add(user_id, new_id);
                reference_to_main.success = true;
                reference_to_main.load_pwd();
                exit_opacity.Start();
            }
            else
            {
                reference_to_main.success = false;
                MessageBox.Show("Invalid Information."); //messagebox
            }
        }

        public void pwd_update_profile(string pwd_update_id)
        {
            string main_data;
            string other_data;
            string parental_data;
            bool success;
            bool has_pic = false;
            var pic_file = picturetoDB(pwd_pic_box.Image);

            if (pwd_pic_box.Image == null)
            {
                has_pic = false;
                #region main_data
                main_data = "UPDATE p_dao.pwd SET registration_no = '"
                                                      + registration_no
                                                      + "', "
                                                      + "lastname = '"
                                                      + lastname
                                                      + "', "
                                                      + "firstname = '"
                                                      + firstname
                                                      + "', "
                                                      + "middlename = '"
                                                      + middlename
                                                      + "', "
                                                      + "id_no = '"
                                                      + id_no_
                                                      + "', "
                                                      + "sex = "
                                                      + sex
                                                      + ", "
                                                      + "disability_id = "
                                                      + disability
                                                      + ", "
                                                      + "address_house_no_street = '"
                                                      + has
                                                      + "', "
                                                      + "address_municipality = '"
                                                      + mun
                                                      + "', "
                                                      + "address_barangay = '"
                                                      + bar
                                                      + "', "
                                                      + "address_province = '"
                                                      + prov
                                                      + "', "
                                                      + "district_id = "
                                                      + district_id
                                                      + ", "
                                                      + "blood_type = '"
                                                      + blood_type
                                                      + "', "
                                                      + "birthdate = '"
                                                      + dob
                                                      + "', "
                                                      + "tel_no = "
                                                      + tel_no
                                                      + ", "
                                                      + "mobile_no = "
                                                      + mobile_no
                                                      + ", "
                                                      + "email_add = '"
                                                      + e_mail
                                                      + "', "
                                                      + "civil_status = "
                                                      + civil_status
                                                      + ", "
                                                      + "nationality = '"
                                                      + natio
                                                      + "', "
                                                      + "end_date = '"
                                                      + end_date
                                                      + "', "
                                                      + "added_date = '"
                                                      + added_date
                                                      + "', "
                                                      + "application_date = '"
                                                      + application_date
                                                      + "', "
                                                      + "educ_attainment = "
                                                      + educ_att
                                                      + ", "
                                                      + "employment_status = "
                                                      + emp_status
                                                      + ", "
                                                      + "nature_of_employer = "
                                                      + no_emp
                                                      + ", "
                                                      + "type_of_employment = "
                                                      + type_oemp
                                                      + ", "
                                                      + "type_of_skill = "
                                                      + to_skill
                                                      + ", "
                                                      + "status_pwd = "
                                                      + pwd_status
                                                      + " "
                                                      + "WHERE pwd_id = " + pwd_update_id;
                #endregion
            }
            else
            {
                has_pic = true;
                main_data = "UPDATE p_dao.pwd SET registration_no = '"
                                                      + registration_no
                                                      + "', "
                                                      + "lastname = '"
                                                      + lastname
                                                      + "', "
                                                      + "firstname = '"
                                                      + firstname
                                                      + "', "
                                                      + "middlename = '"
                                                      + middlename
                                                      + "', "
                                                      + "id_no = '"
                                                      + id_no_
                                                      + "', "
                                                      + "sex = "
                                                      + sex
                                                      + ", "
                                                      + "disability_id = "
                                                      + disability
                                                      + ", "
                                                      + "address_house_no_street = '"
                                                      + has
                                                      + "', "
                                                      + "address_municipality = '"
                                                      + mun
                                                      + "', "
                                                      + "address_barangay = '"
                                                      + bar
                                                      + "', "
                                                      + "address_province = '"
                                                      + prov
                                                      + "', "
                                                      + "district_id = "
                                                      + district_id
                                                      + ", "
                                                      + "blood_type = '"
                                                      + blood_type
                                                      + "', "
                                                      + "birthdate = '"
                                                      + dob
                                                      + "', "
                                                      + "tel_no = "
                                                      + tel_no
                                                      + ", "
                                                      + "mobile_no = "
                                                      + mobile_no
                                                      + ", "
                                                      + "email_add = '"
                                                      + e_mail
                                                      + "', "
                                                      + "civil_status = "
                                                      + civil_status
                                                      + ", "
                                                      + "nationality = '"
                                                      + natio
                                                      + "', "
                                                      + "end_date = '"
                                                      + end_date
                                                      + "', "
                                                      + "added_date = '"
                                                      + added_date
                                                      + "', "
                                                      + "application_date = '"
                                                      + application_date
                                                      + "', "
                                                      + "educ_attainment = "
                                                      + educ_att
                                                      + ", "
                                                      + "employment_status = "
                                                      + emp_status
                                                      + ", "
                                                      + "nature_of_employer = "
                                                      + no_emp
                                                      + ", "
                                                      + "type_of_employment = "
                                                      + type_oemp
                                                      + ", "
                                                      + "type_of_skill = "
                                                      + to_skill
                                                      + ", "
                                                      + "status_pwd = "
                                                      + pwd_status
                                                      + ", "
                                                      + "picture = "
                                                      + "@Image "
                                                      + "WHERE pwd_id = " + pwd_update_id;

            }

            
            #region other_data
            other_data = "UPDATE pwd_otherinfo SET sss_no = '"
                                                        + sss_no
                                                        + "', "
                                                        + "gsis_no = "
                                                        + gsis_no
                                                        + ", "
                                                        + "phealth_no = '"
                                                        + phil_health_no
                                                        + "', "
                                                        + "phealth_status = "
                                                        + phil_health_status
                                                        + ", "
                                                        + "organization_aff = '"
                                                        + organiaff
                                                        + "', "
                                                        + "contact_person = '"
                                                        + contact_person
                                                        + "', "
                                                        + "office_address = '"
                                                        + office_address
                                                        + "', "
                                                        + "tel_no = '"
                                                        + tel_no
                                                        + "', "
                                                        + "name_of_reporting_unit = '"
                                                        + no_unit
                                                        + "', "
                                                        + "accomplished_by_ln = '"
                                                        + accom_ln
                                                        + "', "
                                                        + "accomplished_by_fn = '"
                                                        + accom_fn
                                                        + "', "
                                                        + "accomplished_by_mn = '"
                                                        + accom_mn
                                                        + "' "
                                                        + "WHERE pwd_id = " + pwd_update_id;
            #endregion
            #region parental_data
            parental_data = "UPDATE p_dao.parental_info SET fatherfn = '"
                                                                + father_fn
                                                                + "', "
                                                                + "fathermn = '"
                                                                + father_mn
                                                                + "', "
                                                                + "fatherln = '"
                                                                + father_ln
                                                                + "', "
                                                                + "motherfn = '"
                                                                + mother_fn
                                                                + "', "
                                                                + "mothermn = '"
                                                                + mother_mn
                                                                + "', "
                                                                + "motherln = '"
                                                                + mother_ln
                                                                + "', "
                                                                + "guardianfn = '"
                                                                + guardian_fn
                                                                + "', "
                                                                + "guardianmn = '"
                                                                + guardian_mn
                                                                + "', "
                                                                + "guardianln = '"
                                                                + guardian_ln
                                                                + "' "
                                                                + "WHERE pwd_id = " + pwd_update_id;
            #endregion

            if (has_pic == false)
            {
                success = conn_pwd.pwd_update_profile(main_data, other_data, parental_data);
            } else
            {
                success = conn_pwd.pwd_update_profile(main_data, other_data, parental_data, pic_file);
            }


            if (success == true)
            {
                if(from_view)
                {
                    string user_id = conn_user.get_user_id_by_name(reference_to_main.current_user);
                    conn_pwd.usr_log_update(user_id, pwd_update_id);
                    reference_to_view.success = true;
                    reference_to_view.pwd_load_data(pwd_update_id);
                    exit_opacity.Start();
                } else
                {
                    string user_id = conn_user.get_user_id_by_name(reference_to_main.current_user);
                    conn_pwd.usr_log_update(user_id, pwd_update_id);
                    reference_to_main.success = true;
                    reference_to_main.load_pwd();
                    exit_opacity.Start();
                }
            } else
            {
                MessageBox.Show("Invalid Information."); //messagebox
            }
        }
        #endregion

        #region QUICK-PANEL
        public void panel_activate()
        {
            current_panel_active.Visible = false;
            pwd_next.Text = "NEXT";
            if (current_panel == 1)
            {
                panel_1_.Visible = true;
                current_panel_active = panel_1_;
            } else if (current_panel == 2)
            {
                panel_2_.Visible = true;
                current_panel_active = panel_2_;
            } else if (current_panel == 3)
            {
                panel_3_.Visible = true;
                current_panel_active = panel_3_;
            } else if (current_panel == 4)
            {
                panel_4_.Visible = true;
                current_panel_active = panel_4_;
            } else if (current_panel == 5)
            {
                panel_5_.Visible = true;
                current_panel_active = panel_5_;
            } else if (current_panel == 6)
            {
                panel_6_.Visible = true;
                current_panel_active = panel_6_;
                if(update_mode)
                {
                    pwd_next.Text = "UPDATE";
                } else
                {
                    pwd_next.Text = "ADD";
                }

            }
            btn_side_active();
        }

        private void btn_general_Click(object sender, EventArgs e)
        {
            current_panel = 1;
            panel_activate();
        }

        private void btn_personal_Click(object sender, EventArgs e)
        {
            current_panel = 2;
            panel_activate();
        }

        private void btn_contact_Click(object sender, EventArgs e)
        {
            current_panel = 3;
            panel_activate();
        }

        private void btn_educational_Click(object sender, EventArgs e)
        {
            current_panel = 3;
            panel_activate();
        }

        private void btn_employment_Click(object sender, EventArgs e)
        {
            current_panel = 4;
            panel_activate();
        }

        private void btn_type_of_skill_Click(object sender, EventArgs e)
        {
            current_panel = 4;
            panel_activate();
        }

        private void btn_organizational_Click(object sender, EventArgs e)
        {
            current_panel = 5;
            panel_activate();
        }

        private void btn_other_Click(object sender, EventArgs e)
        {
            current_panel = 5;
            panel_activate();
        }

        private void btn_parental_Click(object sender, EventArgs e)
        {
            current_panel = 6;
            panel_activate();
        }

        #endregion

        #region BTN-QUICK-INDICATOR

        public void quick_indicator_back_color(Label indicator, Button btn_indicator)
        {
            indicator.BackColor = btn_indicator.BackColor;
        }

        public void quick_indicator_mouse_over(Label indicator, Button btn_indicator)
        {
            indicator.BackColor = btn_indicator.FlatAppearance.MouseOverBackColor;
        }

        public void quick_indicator_mouse_down(Label indicator, Button btn_indicator)
        {
            indicator.BackColor = btn_indicator.FlatAppearance.MouseDownBackColor;
        }

        //<---[ --- ]--->

        #endregion
            
        #region UPDATE-MODE

        public void paste_data()
        {
            DataTable main_data = new DataTable();
            DataTable other_data = new DataTable();
            DataTable parental_data = new DataTable();
            conn_pwd.pwd_update_profile_data(pwd_update_id, main_data, other_data, parental_data);

            #region <-----[MAIN DATA]----->

            pwd_regisno.Text = main_data.Rows[0]["registration_no"].ToString();
            id_no.Text = main_data.Rows[0]["id_no"].ToString();
            ln_txt.Text = main_data.Rows[0]["lastname"].ToString();
            fn_txt.Text = main_data.Rows[0]["firstname"].ToString();
            mn_txt.Text = main_data.Rows[0]["middlename"].ToString();
            gender.SelectedIndex = int.Parse(main_data.Rows[0]["sex"].ToString()) + 1;
            disability_type.SelectedIndex = int.Parse(main_data.Rows[0]["disability_id"].ToString());
            bloodtype.SelectedIndex = int.Parse(main_data.Rows[0]["blood_type"].ToString());
            civilstatus.SelectedIndex = int.Parse(main_data.Rows[0]["civil_status"].ToString());
            pwd_appdate.Value = Convert.ToDateTime(main_data.Rows[0]["application_date"].ToString());
            nationality.Text = main_data.Rows[0]["nationality"].ToString();
            dateofbirth.Value = Convert.ToDateTime(main_data.Rows[0]["birthdate"].ToString());
            telno.Text = main_data.Rows[0]["tel_no"].ToString();
            mobileno.Text = main_data.Rows[0]["mobile_no"].ToString();
            email.Text = main_data.Rows[0]["email_add"].ToString();
            /*
            pwd_pic_box.BackgroundImage = null;
            try
            {
                byte[] image = (byte[])main_data.Rows[0]["picture"];
                MemoryStream ms = new MemoryStream(image);
                pwd_pic_box.Image = Image.FromStream(ms);
                pwd_pic_box.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch
            {
                pwd_pic_box.Image = SAD_2_PTT_01.Properties.Resources.pwd;
                pwd_pic_box.SizeMode = PictureBoxSizeMode.CenterImage;
            }*/

            educ_attainment("update", main_data.Rows[0]["educ_attainment"].ToString());
            empstatus.SelectedIndex = int.Parse(main_data.Rows[0]["employment_status"].ToString());
            noemp.SelectedIndex = int.Parse(main_data.Rows[0]["nature_of_employer"].ToString());
            typeoemp.SelectedIndex = int.Parse(main_data.Rows[0]["type_of_employment"].ToString());
            type_of_skill("update", main_data.Rows[0]["type_of_skill"].ToString());
            status_pwd("update", main_data.Rows[0]["status_pwd"].ToString());
            
            hs_txt.Text = main_data.Rows[0]["address_house_no_street"].ToString();
            mun_txt.Text = main_data.Rows[0]["address_municipality"].ToString();
            bar_txt.Text = main_data.Rows[0]["address_barangay"].ToString();
            prov_txt.Text = main_data.Rows[0]["address_province"].ToString();
            district_type.SelectedIndex = int.Parse(main_data.Rows[0]["district_id"].ToString());

            #endregion

            #region <-----[OTHER DATA]----->

            sssno.Text = other_data.Rows[0]["sss_no"].ToString();
            gsisno.Text = other_data.Rows[0]["gsis_no"].ToString();
            philhealthno.Text = other_data.Rows[0]["phealth_no"].ToString();
            philhealthstatus.SelectedIndex = int.Parse(other_data.Rows[0]["phealth_status"].ToString());
            orgaff.Text = other_data.Rows[0]["organization_aff"].ToString();
            contactper.Text = other_data.Rows[0]["contact_person"].ToString();
            officeadd.Text = other_data.Rows[0]["office_address"].ToString();
            orgtelno.Text = other_data.Rows[0]["tel_no"].ToString();
            norunit.Text = other_data.Rows[0]["name_of_reporting_unit"].ToString();
            aln_txt.Text = other_data.Rows[0]["accomplished_by_ln"].ToString();
            afn_txt.Text = other_data.Rows[0]["accomplished_by_fn"].ToString();
            amn_txt.Text = other_data.Rows[0]["accomplished_by_mn"].ToString();

            #endregion

            #region <-----[PARENTAL INFO]----->

            ffn_txt.Text = parental_data.Rows[0]["fatherfn"].ToString();
            fmn_txt.Text = parental_data.Rows[0]["fathermn"].ToString();
            fln_txt.Text = parental_data.Rows[0]["fatherln"].ToString();
            mfn_txt.Text = parental_data.Rows[0]["motherfn"].ToString();
            mmn_txt.Text = parental_data.Rows[0]["mothermn"].ToString();
            mln_txt.Text = parental_data.Rows[0]["motherln"].ToString();
            gfn_txt.Text = parental_data.Rows[0]["guardianfn"].ToString();
            gmn_txt.Text = parental_data.Rows[0]["guardianmn"].ToString();
            gln_txt.Text = parental_data.Rows[0]["guardianln"].ToString();

            #endregion
        }

        private void btn_revert_Click(object sender, EventArgs e)
        {
            paste_data();
        }


        #endregion

        private void pwd_add_Activated(object sender, EventArgs e)
        {
            if(confirmation == true)
            {
                reference_to_main.BringToFront();
                this.BringToFront();
                prompt.BringToFront();
            }
            
        }

        private void id_no_TextChanged(object sender, EventArgs e)
        {
            if (conn_pwd.pwd_check_registration_has_duplicate(id_no.Text, update_id_no) == true)
            {
                lbl_id_no_error.Visible = true;
                panel_1_next();
            }
            else
            {
                lbl_id_no_error.Visible = false;
                panel_1_next();
            }
        }

        private void btn_add_picture_Click(object sender, EventArgs e)
        {
            DialogResult check_file = pwd_picture.ShowDialog();
            if (check_file == DialogResult.OK)
            {
                string pic_location = pwd_picture.FileName.ToString();
                pwd_pic_box.ImageLocation = pic_location;
                pwd_pic_box.Image = Image.FromFile(pic_location);
                pwd_pic_box.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        public byte[] picturetoDB(Image img)
        {
            using (var ms = new MemoryStream())
            {
                img.Save(ms, img.RawFormat);
                return ms.ToArray();
            }
        }
    }
}
