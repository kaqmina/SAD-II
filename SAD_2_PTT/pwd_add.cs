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
    public partial class pwd_add : Form
    {
        #region Variables
        string application_date;// date
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
        connections conn = new connections();
        main_functions main_func = new main_functions();
        #endregion

        #region Formload
        public pwd_add()
        {
            InitializeComponent();

            this.Opacity = 0;
            startup_opacity.Start();
            //Visibility Load
            pnl_container.Visible = true;
            pnl1.Visible = true;
            pnl2.Visible = false;
            pnl3.Visible = false;
            pnl4.Visible = false;
            pnl5.Visible = false;

            populate_cboxes();
            //Style Text
            default_text();
            //defaulttxt9();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void startup_opacity_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.1;
        }
        #endregion

        #region 1 General Information Panel
        private void btn_next1_Click(object sender, EventArgs e)
        {
            //Visibility
            pnl1.Visible = false;
            pnl2.Visible = true;
        }

        #region Text Style

        private void default_text(){

            
        }

        private void lntxt_Enter(object sender, EventArgs e)
        {
            main_func.text_enter(ln_txt, "Last Name");
        }
        private void fntxt_Enter(object sender, EventArgs e)
        {
            //fn_txt.Clear();
            //fn_txt.ForeColor = Color.Black;
        }
        private void mntxt_Enter(object sender, EventArgs e)
        {
            //mn_txt.Clear();
            //mn_txt.ForeColor = Color.Black;
        }
        private void hstxt_Enter(object sender, EventArgs e)
        {
            //hs_txt.Clear();
            //hs_txt.ForeColor = Color.Black;
        }
        private void bartxt_Enter(object sender, EventArgs e)
        {
            bar_txt.Clear();
            bar_txt.ForeColor = Color.Black;
        }
        private void muntxt_Enter(object sender, EventArgs e)
        {
            mun_txt.Clear();
            mun_txt.ForeColor = Color.Black;
        }
        private void provtxt_Enter(object sender, EventArgs e)
        {
            prov_txt.Clear();
            prov_txt.ForeColor = Color.Black;
        }
        #endregion

        #endregion

        #region 2 Personal Information Panel
        private void btn_prev2_Click(object sender, EventArgs e)
        {
            //Visibility
            pnl2.Visible = false;
            pnl1.Visible = true;
        }

        private void btn_next2_Click(object sender, EventArgs e)
        {
            //Visibility
            pnl2.Visible = false;
            pnl3.Visible = true;
        }


        #endregion

        #region 3 4 Contact & Education Panel
        private void button3_Click(object sender, EventArgs e)
        {
            //Visibility - PREV
            pnl3.Visible = false;
            pnl2.Visible = true;
        }
        private void next3_Click(object sender, EventArgs e)
        {
            //Visibility
            pnl3.Visible = false;
            pnl4.Visible = true;
        }
        #endregion

        #region 5 6 Employee & Skill Panel
        private void prev4_Click(object sender, EventArgs e)
        {
            //Visibility
            pnl4.Visible = false;
            pnl3.Visible = true;
        }
        private void next4_Click(object sender, EventArgs e)
        {
            //Visibility
            pnl4.Visible = false;
            pnl5.Visible = true;
        }
        #endregion

        #region 7 8 Organization & Other Panel
        private void prev5_Click(object sender, EventArgs e)
        {
            //Visibility
            pnl5.Visible = false;
            pnl4.Visible = true;
        }
        private void next5_Click(object sender, EventArgs e)
        {
            //Visibility
            pnl5.Visible = false;
            pnl6.Visible = true;
        }
        #endregion

        #region 9 Parental Information Panel
        private void button4_Click(object sender, EventArgs e)
        {
            //Visibility - PREV
            pnl6.Visible = false;
            pnl5.Visible = true;
        }

        #region Text Style
        private void defaulttxt9()
        {
            //Guide text
            fln_txt.Text = mln_txt.Text = gln_txt.Text = aln_txt.Text = "Last Name";
            ffn_txt.Text = mfn_txt.Text = gfn_txt.Text = afn_txt.Text = "First Name";
            fmn_txt.Text = mmn_txt.Text = gmn_txt.Text = amn_txt.Text = "Middle Name";

            //Style
            fln_txt.ForeColor = mln_txt.ForeColor = gln_txt.ForeColor = aln_txt.ForeColor = Color.Silver;
            ffn_txt.ForeColor = mfn_txt.ForeColor = gfn_txt.ForeColor = afn_txt.ForeColor = Color.Silver;
            fmn_txt.ForeColor = mmn_txt.ForeColor = gmn_txt.ForeColor = amn_txt.ForeColor = Color.Silver;
        }
        private void fln_txt_Enter(object sender, EventArgs e)
        {
            fln_txt.Clear();
            fln_txt.ForeColor = Color.Black;
        }
        private void ffn_txt_Enter(object sender, EventArgs e)
        {
            ffn_txt.Clear();
            ffn_txt.ForeColor = Color.Black;
        }
        private void fmn_txt_Enter(object sender, EventArgs e)
        {
            fmn_txt.Clear();
            fmn_txt.ForeColor = Color.Black;
        }
        private void mln_txt_Enter(object sender, EventArgs e)
        {
            mln_txt.Clear();
            mln_txt.ForeColor = Color.Black;
        }
        private void mfn_txt_Enter(object sender, EventArgs e)
        {
            mfn_txt.Clear();
            mfn_txt.ForeColor = Color.Black;
        }

        private void mmn_txt_Enter(object sender, EventArgs e)
        {
            mmn_txt.Clear();
            mmn_txt.ForeColor = Color.Black;
        }
        private void gln_txt_Enter(object sender, EventArgs e)
        {
            gln_txt.Clear();
            gln_txt.ForeColor = Color.Black;
        }
        private void gfn_txt_Enter(object sender, EventArgs e)
        {
            gfn_txt.Clear();
            gfn_txt.ForeColor = Color.Black;
        }
        private void gmn_txt_Enter(object sender, EventArgs e)
        {
            gmn_txt.Clear();
            gmn_txt.ForeColor = Color.Black;
        }
        private void aln_txt_Enter(object sender, EventArgs e)
        {
            aln_txt.Clear();
            aln_txt.ForeColor = Color.Black;
        }
        private void afn_txt_Enter(object sender, EventArgs e)
        {
            afn_txt.Clear();
            afn_txt.ForeColor = Color.Black;
        }
        private void amn_txt_Enter(object sender, EventArgs e)
        {
            amn_txt.Clear();
            amn_txt.ForeColor = Color.Black;
        }



        #endregion

        #endregion

        #region FormClosing
        private void pwd_add_FormClosing(object sender, FormClosingEventArgs e)
        {
            reference_to_main.side_tab.Enabled = true;
            reference_to_main.dboard_head.Enabled = true;
            reference_to_main.pwd_data();
        }
        #endregion

        #region PWD Add Event PA - 11

        public main_form reference_to_main { get; set; }

        private void pwd_add_back_Click(object sender, EventArgs e)
        {
            this.Close();
            //update datagrid view in datagrid
        }

        //add
        private void btn_add_Click(object sender, EventArgs e)
        {
            set_data();
            if (btn_add_edit.Text.ToLower() == "add")
                pwd_add_data();
            else if (btn_add_edit.Text.ToLower() == "update")
                pwd_update(pwd_update_id);
        }

        public void pwd_add_data()
        {
            string main_data;
            string main_variables;
            string other_data;
            string other_variables;
            string parental_data;
            string parental_variables;
            #region main_data
            main_data = "INSERT INTO p_dao.pwd(lastname, "
                                            + "firstname, "
                                            + "middlename, "
                                            + "sex, "
                                            + "disability_id, "
                                            + "address, "
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
                                            + "accomplished_by, "
                                            + "educ_attainment, "
                                            + "employment_status, "
                                            + "nature_of_employer, "
                                            + "type_of_employment, "
                                            + "registration_no, "
                                            + "employment_status, "
                                            + "status_pwd, "
                                            + "type_of_skill) ";
            main_variables = "VALUES ('" + lastname
                                         + "', '"
                                         + firstname
                                         + "', '"
                                         + middlename
                                         + "', "
                                         + sex
                                         + ", "
                                         + disability
                                         + ", '"
                                         + (has + " |" + mun + " |" + bar + " |" + prov + " |" + reg + " ")
                                         + "', '"
                                         + blood_type
                                         + "', '"
                                         + dob
                                         + "', "
                                         + tel_no
                                         + ", "
                                         + mobile_no
                                         + ", '"
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
                                         + "', '"
                                         + accom
                                         + "', "
                                         + educ_att
                                         + ", "
                                         + emp_status
                                         + ", "
                                         + no_emp
                                         + ", "
                                         + type_oemp
                                         + ", "
                                         + registration_no
                                         + ", "
                                         + emp_status
                                         + ", "
                                         + pwd_status
                                         + ", "
                                         + to_skill
                                         + ")";
            #endregion
            #region other_data
            other_data = "INSERT INTO pdao.pwd_otherinfo(sss_no,"
                                                      + "gsis_no, "
                                                      + "phealth_no, "
                                                      + "phealth_status, "
                                                      + "organization_aff, "
                                                      + "contact_person, "
                                                      + "office_address, "
                                                      + "tel_no, "
                                                      + "name_of_reporting_unit, "
                                                      + "pwd_id) ";
            other_variables = "VALUES (" + sss_no
                                         + ", "
                                         + gsis_no
                                         + ", "
                                         + phil_health_no
                                         + ", "
                                         + phil_health_status
                                         + ", '"
                                         + organiaff
                                         + "', '"
                                         + contact_person
                                         + "', '"
                                         + office_address
                                         + "', "
                                         + org_telno
                                         + ", '"
                                         + no_unit
                                         + "', "
                                         + "(SELECT LAST_INSERT_ID()) )";
            #endregion
            #region parental_data
            parental_data = "INSERT INTO pdao.parental_info(fatherfn, "
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
            conn.pwd_add_profile((main_data + main_variables), (other_data + other_variables), (parental_data + parental_variables));
        }
        #endregion

        #region PWD Update Event PU - 12

        public void pwd_update(int current_id)
        {
            #region main_data
            string main_data = "UPDATE p_dao.pwd SET registration_no = "
                                                  + registration_no
                                                  + ", "
                                                  + "lastname = '"
                                                  + lastname
                                                  + "', "
                                                  + "firstname = '"
                                                  + firstname
                                                  + "', "
                                                  + "middlename = '"
                                                  + middlename
                                                  + "', "
                                                  + "sex = "
                                                  + sex
                                                  + ", "
                                                  + "disability_id = "
                                                  + disability
                                                  + ", "
                                                  + "address = '"
                                                  + (has + " " + mun + " " + bar + " " + prov + ", " + reg)
                                                  + "', "
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
                                                  + "accomplished_by = '"
                                                  + accom
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
                                                  + "type_of_employer = "
                                                  + type_oemp
                                                  + ", "
                                                  + "type_of_skill = "
                                                  + to_skill
                                                  + ", "
                                                  + "status_pwd = "
                                                  + pwd_status
                                                  + ", "
                                                  + "WHERE pwd_id = " + current_id;
            #endregion
            #region other_data
            string other_data = "UPDATE pwd_otherinfo SET sss_no = "
                                                        + sss_no
                                                        + ", "
                                                        + "gsis_no = "
                                                        + gsis_no
                                                        + ", "
                                                        + "phealth_no = "
                                                        + phil_health_no
                                                        + ", "
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
                                                        + "tel_no = "
                                                        + tel_no
                                                        + ", "
                                                        + "name_of_reporting_unit = '"
                                                        + no_unit
                                                        + "' "
                                                        + "WHERE pwd_id = " + current_id;
            #endregion
            #region parental_data
            string parental_data = "UPDATE p_dao.parental_info SET fatherfn = '"
                                                                + father_fn
                                                                + "', " 
                                                                + "fathermn = '"
                                                                + father_mn
                                                                +"', "
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
                                                                + "WHERE pwd_id = " + current_id;
            #endregion
            conn.pwd_update_profile(main_data, other_data, parental_data);
        }

        #endregion

        public void set_data()
        {
            #region <-----[MAIN DATA]----->

            application_date = pwd_appdate.Text;
            firstname = fn_txt.Text;
            lastname = ln_txt.Text;
            middlename = mn_txt.Text;
            has = hs_txt.Text;
            mun = mun_txt.Text;
            bar = bar_txt.Text;
            prov = prov_txt.Text;
            reg = region.Text;
            dob = dateofbirth.Text;
            natio = nationality.Text;
            accom = aln_txt.Text + " |" + afn_txt.Text + " |" + amn_txt.Text + " ";
            registration_no = int.Parse(pwd_regisno.Text);
            tel_no = int.Parse(telno.Text);
            mobile_no = int.Parse(mobileno.Text);
            e_mail = email.Text;
            status_pwd("add", "-");
            educ_attainment("add", "-");
            type_of_skill("add", "-");

            #endregion

            #region <-----[OTHER INFO]----->

            org_telno = int.Parse(orgtelno.Text);
            sss_no = int.Parse(sssno.Text);
            gsis_no = int.Parse(gsisno.Text);
            phil_health_no = int.Parse(philhealthno.Text);
            organiaff = orgaff.Text;
            contact_person = contactper.Text;
            office_address = officeadd.Text;
            no_unit = norunit.Text;

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

        public void paste_data()
        {
            DataTable main_data = new DataTable();
            DataTable other_data = new DataTable();
            DataTable parental_data = new DataTable();
            conn.pwd_update_profile_data(pwd_update_id, main_data, other_data, parental_data);

            #region <-----[MAIN DATA]----->

            pwd_regisno.Text = main_data.Rows[0]["registration_no"].ToString();
            ln_txt.Text = main_data.Rows[0]["lastname"].ToString();
            fn_txt.Text = main_data.Rows[0]["firstname"].ToString();
            mn_txt.Text = main_data.Rows[0]["middlename"].ToString();
            gender.SelectedIndex = int.Parse(main_data.Rows[0]["sex"].ToString()) + 1;
            disability_type.SelectedIndex = int.Parse(main_data.Rows[0]["disability_id"].ToString());
            bloodtype.SelectedIndex = int.Parse(main_data.Rows[0]["blood_type"].ToString());
            civilstatus.SelectedIndex = int.Parse(main_data.Rows[0]["civil_status"].ToString());
            pwd_appdate.Text = main_data.Rows[0]["application_date"].ToString();
            nationality.Text = main_data.Rows[0]["nationality"].ToString();
            dateofbirth.Text = main_data.Rows[0]["birthdate"].ToString();
            telno.Text = main_data.Rows[0]["tel_no"].ToString();
            mobileno.Text = main_data.Rows[0]["mobile_no"].ToString();
            email.Text = main_data.Rows[0]["email_add"].ToString();

            string[] separators = {" |"};
            string value = main_data.Rows[0]["accomplished_by"].ToString();
            string[] accom = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            aln_txt.Text = accom[0].ToString();
            afn_txt.Text = accom[1].ToString();
            amn_txt.Text = accom[2].ToString();

            educ_attainment("update", main_data.Rows[0]["educ_attainment"].ToString());
            empstatus.SelectedIndex = int.Parse(main_data.Rows[0]["employment_status"].ToString());
            noemp.SelectedIndex = int.Parse(main_data.Rows[0]["nature_of_employer"].ToString());
            typeoemp.SelectedIndex = int.Parse(main_data.Rows[0]["type_of_employment"].ToString());
            type_of_skill("update", main_data.Rows[0]["type_of_skill"].ToString());
            status_pwd("update", main_data.Rows[0]["status_pwd"].ToString());

            value = main_data.Rows[0]["address"].ToString();
            string[] address = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            hs_txt.Text = address[0].ToString();
            mun_txt.Text = address[1].ToString();
            bar_txt.Text = address[2].ToString();
            prov_txt.Text = address[3].ToString();
            region.SelectedItem = address[4].ToString();

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

        #region EDUC_ATT, TO_SKILL, STATUS_PWD, DISABILITY, SEX, B_TYPE, CIVIL/EMP/PHEALTH, TO_EMP, NO_EMP
        private void educ_attainment(string status, string num)
        {
            if(status == "add")
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
            } else
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

        private void type_of_skill(string status, string num)
        {
            if(status == "add")
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
            } else
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

        private void status_pwd(string status, string num)
        {
            if(status == "add")
            {
                if (status_active.Checked)
                    pwd_status = 1;
                else if (status_ex_inactive.Checked)
                    pwd_status = 0;
            } else
            {
                if (num == "1")
                    status_active.Checked = true;
                else if (num == "0")
                    status_ex_inactive.Checked = true;
            }
            
        }

        private void disability_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            disability = disability_type.SelectedIndex;
            if (disability == 0)
                all_required = false;
            else
                all_required = true;
        }

        public void populate_cboxes()
        {
            conn.populate_cbox(disability_type);
        }

        private void gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gender.Text == "Male")
                sex = 0;
            else if (gender.Text == "Female")
                sex = 1;

            if (gender.Text == "")
                all_required = false;
            else
                all_required = true;
        }

        private void bloodtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            blood_type = bloodtype.SelectedIndex;
            if (bloodtype.SelectedIndex == 0)
                all_required = false;
            else
                all_required = true;
        }

        private void civilstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            civil_status = civilstatus.SelectedIndex;
            if (civil_status == 0)
                all_required = false;
            else
                all_required = true;
        }

        private void empstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            emp_status = empstatus.SelectedIndex;
            if (type_oemp == 0)
                all_required = false;
            else
                all_required = true;
        }

        private void noemp_SelectedIndexChanged(object sender, EventArgs e)
        {
            no_emp = noemp.SelectedIndex;
            if (type_oemp == 0)
                all_required = false;
            else
                all_required = true;
        }

        private void typeoemp_SelectedIndexChanged(object sender, EventArgs e)
        {
            type_oemp = typeoemp.SelectedIndex;
            if (type_oemp == 0)
                all_required = false;
            else
                all_required = true;
        }

        private void philhealthstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            phil_health_status = philhealthstatus.SelectedIndex;
            if(phil_health_status == 0)
                all_required = false;
            else
                all_required = true;
        }
        #endregion

    }
}
