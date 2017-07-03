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

            //Visibility Load
            pnl_container.Visible = true;
            pnl1.Visible = true;
            pnl2.Visible = false;
            pnl3.Visible = false;
            pnl4.Visible = false;
            pnl5.Visible = false;

            //Style Text
            defaulttxt1();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion

        #region 1 General Information Panel
        private void btn_next1_Click(object sender, EventArgs e)
        {
            //Visibility
            pnl1.Visible = false;
            pnl2.Visible = true;
        }

        private void defaulttxt1(){
            //Guide text
            lntxt.Text = "Last Name";
            fntxt.Text = "First Name";
            mntxt.Text = "Middle Name";
            hstxt.Text = "House No. and Street";
            bartxt.Text = "Barangay";
            muntxt.Text = "Municipality";
            provtxt.Text = "Province";

            //Style
            lntxt.ForeColor = fntxt.ForeColor = mntxt.ForeColor = Color.Silver;
            hstxt.ForeColor = bartxt.ForeColor = bartxt.ForeColor = Color.Silver;
            provtxt.ForeColor = Color.Silver;
        }
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

        #endregion

        #region 7 8 Organization & Other Panel
        private void prev5_Click(object sender, EventArgs e)
        {
            //Visibility
            pnl5.Visible = false;
            pnl4.Visible = true;
        }


        #endregion

        private void next5_Click(object sender, EventArgs e)
        {
            //Visibility
            pnl5.Visible = false;
            //pnl6.Visible = true;
        }
    }
}
