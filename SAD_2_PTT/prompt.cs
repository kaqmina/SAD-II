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
    public partial class prompt : Form
    {
        public prompt()
        {
            InitializeComponent();
        }
        public main_form reference_to_main { get; set; }
        public int current_id = 0;

        private void prompt_Load(object sender, EventArgs e)
        {
            startup_opacity.Start();
        }

        private void startup_opacity_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
                this.Opacity += 0.1;
            else
                startup_opacity.Stop();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            btn_close_Click(sender, e);
        }

        private void prompt_FormClosing(object sender, FormClosingEventArgs e)
        {
            reference_to_main.pwd_data();
        }

        private void btn_continue_Click(object sender, EventArgs e)
        {
            connections conn = new connections();
            conn.archive_profile(current_id);
            this.Close();
        }
    }
}
