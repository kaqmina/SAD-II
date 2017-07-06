﻿using System;
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

        public main_form reference_to_main { get; set; }

        private void pwd_add_back_Click(object sender, EventArgs e)
        {
            this.Close();
            //update database
        }

        private void pwd_add_FormClosing(object sender, FormClosingEventArgs e)
        {
            reference_to_main.side_tab.Enabled = true;
            reference_to_main.dboard_head.Enabled = true;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            string registration_no = pwd_regisno.Text;
            string application_date = pwd_appdate.Text;
            int disability = 0;//change later
            string firstname = fn_txt.Text;
            string lastname = ln_txt.Text;
            string middlename = mn_txt.Text;
            string has = hs_txt.Text;
            string mun = mun_txt.Text;
            string bar = bar_txt.Text;
            string prov = prov_txt.Text;
            string reg = region.Text;
            string dob = dateofbirth.Text;
            string sex = gender.Text;
            string natio = nationality.Text;
            string blood_type = bloodtype.Text;
            string civil_status = civilstatus.Text;
            string tel_no = telno.Text;
            string mobile_no = mobileno.Text;
            string e_mail = email.Text;
            string emp_status = empstatus.Text;
            string no_emp = noemp.Text;
            string organiaff = orgaff.Text;
            string contact_person = contactper.Text;
            string office_address = officeadd.Text;
            string org_telno = orgtelno.Text;
            string sss_no = sssno.Text;
            string gsis_no = gsisno.Text;
            string phil_health_status = philhealthstatus.Text;
            string phil_health_no = philhealthno.Text;
            string father_ln = fln_txt.Text;
            string father_fn = ffn_txt.Text;
            string father_mn = fmn_txt.Text;
            string mother_ln = mln_txt.Text;
            string mother_fn = mfn_txt.Text;
            string mother_mn = mmn_txt.Text;
            string guardian_ln = gln_txt.Text;
            string guardian_fn = gfn_txt.Text;
            string guardian_mn = gmn_txt.Text;
            //educ and typeskill
        }

        public void educ_attainment()
        {

        }
    }
}
