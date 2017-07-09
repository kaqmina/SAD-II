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
        string dob;
        string natio;
        string blood_type;
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
        int registration_no;
        int disability;
        int sex;
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
        bool all_required = false;
        connections conn = new connections();
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
            defaulttxt1();
            defaulttxt9();
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
        private void defaulttxt1(){
            //Guide text
            ln_txt.Text = "Last Name";
            fn_txt.Text = "First Name";
            mn_txt.Text = "Middle Name";
            hs_txt.Text = "House No. and Street";
            bar_txt.Text = "Barangay";
            mun_txt.Text = "Municipality";
            prov_txt.Text = "Province";
            region.Text = "Religion";

            //Style
            ln_txt.ForeColor = fn_txt.ForeColor = mn_txt.ForeColor = Color.Silver;
            hs_txt.ForeColor = bar_txt.ForeColor = bar_txt.ForeColor = Color.Silver;
            prov_txt.ForeColor = mun_txt.ForeColor = region.ForeColor = Color.Silver;
        }

        private void lntxt_Enter(object sender, EventArgs e)
        {
            ln_txt.Clear();
            ln_txt.ForeColor = Color.Black;
        }
        private void fntxt_Enter(object sender, EventArgs e)
        {
            fn_txt.Clear();
            fn_txt.ForeColor = Color.Black;
        }
        private void mntxt_Enter(object sender, EventArgs e)
        {
            mn_txt.Clear();
            mn_txt.ForeColor = Color.Black;
        }
        private void hstxt_Enter(object sender, EventArgs e)
        {
            hs_txt.Clear();
            hs_txt.ForeColor = Color.Black;
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
        }
        #endregion

        public main_form reference_to_main { get; set; }

        private void pwd_add_back_Click(object sender, EventArgs e)
        {
            this.Close();
            //update datagrid view in datagrid
        }

        //add
        private void btn_add_Click(object sender, EventArgs e)
        {
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
            organiaff = orgaff.Text;
            contact_person = contactper.Text;
            office_address = officeadd.Text;
            natio = nationality.Text;
            blood_type = bloodtype.Text;
            father_ln = fln_txt.Text;
            father_fn = ffn_txt.Text;
            father_mn = fmn_txt.Text;
            mother_ln = mln_txt.Text;
            mother_fn = mfn_txt.Text;
            mother_mn = mmn_txt.Text;
            guardian_ln = gln_txt.Text;
            guardian_fn = gfn_txt.Text;
            guardian_mn = gmn_txt.Text;
            registration_no = int.Parse(pwd_regisno.Text);
            //disability = 0;//change later
            //sex = gender.Text;
            //tel_no = telno.Text;
            //mobile_no = mobileno.Text;
            //e_mail = email.Text;
            //emp_status = empstatus.Text;
            //no_emp = noemp.Text;
            //org_telno = orgtelno.Text;
            //sss_no = sssno.Text;
            //gsis_no = gsisno.Text;
            //phil_health_status = philhealthstatus.Text;
            //phil_health_no = philhealthno.Text;
            //educ and typeskill
        }

        #region comboboxes/radiobuttons
        public void educ_attainment()
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
        }

        public void type_of_skill()
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

        }

        private void disability_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            disability = disability_type.SelectedIndex;
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
        }

        private void bloodtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            blood_type = bloodtype.Text;
        }

        private void civilstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            civil_status = civilstatus.SelectedIndex;
        }

        private void empstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            emp_status = empstatus.SelectedIndex;
        }

        private void noemp_SelectedIndexChanged(object sender, EventArgs e)
        {
            no_emp = noemp.SelectedIndex;
        }

        private void typeoemp_SelectedIndexChanged(object sender, EventArgs e)
        {
            type_oemp = typeoemp.SelectedIndex;
        }

        private void philhealthstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            phil_health_status = philhealthstatus.SelectedIndex;
        }
        #endregion

        public bool check_all()
        {
            if (application_date == "")
                all_required = false;
            if (firstname == "")
                all_required = false;

            
            return all_required;
        }
    }
}
