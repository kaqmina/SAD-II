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
        public pwd_add()
        {
            InitializeComponent();

            //Visibility Load
            pnl_container.Visible = true;
            pnl1.Visible = true;
            pnl2.Visible = false;
            pnl3.Visible = false;
            pnl4.Visible = false;
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }


        #region 1 General Information Panel
        private void btn_next1_Click(object sender, EventArgs e)
        {
            //Visibility
            pnl1.Visible = false;
            pnl2.Visible = true;
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

     
    }
}
