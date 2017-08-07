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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        connections conn = new connections();

        private void login_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            startup_opacity.Start();
        }

        private void startup_opacity_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
                this.Opacity += 0.1;
            else
                startup_opacity.Stop();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (conn.login_user(uname.Text, pword.Text))
            {
                this.Hide();
                main_form main_f = new main_form();
                main_f.Closed += (s, args) => this.Show();
                uname.Clear();
                pword.Clear();
                main_f.current_user = uname.Text;
                main_f.Show();
            } else
            {
                message.Visible = true;
            }
            
        }

        #region Text_Changed
        public void check_()
        {
            if (uname.Text.Trim() != "" && pword.Text.Trim() != "")
                btn_login.Enabled = true;
            else
                btn_login.Enabled = false;
        }

        private void uname_TextChanged(object sender, EventArgs e)
        {
            check_();
        }

        private void pword_TextChanged(object sender, EventArgs e)
        {
            check_();
        }
        #endregion
    }
}
