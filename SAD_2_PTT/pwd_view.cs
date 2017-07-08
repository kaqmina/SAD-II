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

        private void pwd_view_back_Click(object sender, EventArgs e)
        {
            reference_to_main.side_tab.Enabled = true;
            reference_to_main.dboard_head.Enabled = true;
            this.Close();
        }

        #region FormLoad
        private void pwd_view_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            startup_opacity.Start();
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
    }
}
