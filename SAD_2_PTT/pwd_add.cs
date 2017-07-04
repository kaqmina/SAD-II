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
            lntxt.Text = "Last Name";
            fntxt.Text = "First Name";
            mntxt.Text = "Middle Name";
            hstxt.Text = "House No. and Street";
            bartxt.Text = "Barangay";
            muntxt.Text = "Municipality";
            provtxt.Text = "Province";
            rel_cmbox.Text = "Religion";

            //Style
            lntxt.ForeColor = fntxt.ForeColor = mntxt.ForeColor = Color.Silver;
            hstxt.ForeColor = bartxt.ForeColor = bartxt.ForeColor = Color.Silver;
            provtxt.ForeColor = muntxt.ForeColor = rel_cmbox.ForeColor = Color.Silver;
        }

        private void lntxt_Enter(object sender, EventArgs e)
        {
            lntxt.Clear();
            lntxt.ForeColor = Color.Black;
        }
        private void fntxt_Enter(object sender, EventArgs e)
        {
            fntxt.Clear();
            fntxt.ForeColor = Color.Black;
        }
        private void mntxt_Enter(object sender, EventArgs e)
        {
            mntxt.Clear();
            mntxt.ForeColor = Color.Black;
        }
        private void hstxt_Enter(object sender, EventArgs e)
        {
            hstxt.Clear();
            hstxt.ForeColor = Color.Black;
        }
        private void bartxt_Enter(object sender, EventArgs e)
        {
            bartxt.Clear();
            bartxt.ForeColor = Color.Black;
        }
        private void muntxt_Enter(object sender, EventArgs e)
        {
            muntxt.Clear();
            muntxt.ForeColor = Color.Black;
        }
        private void provtxt_Enter(object sender, EventArgs e)
        {
            provtxt.Clear();
            provtxt.ForeColor = Color.Black;
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
    }
}
