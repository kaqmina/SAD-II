using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAD_2_PTT_01
{
    public partial class pwd_archive : Form
    {
        public pwd_archive()
        {
            InitializeComponent();
        }

        public main_form reference_to_main { get; set; }
        public string current_id = "0";

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
            reference_to_main.load_pwd();
        }

        private void btn_continue_Click(object sender, EventArgs e)
        {
            connections_pwd conn_pwd = new connections_pwd();
            conn_pwd.archive_profile(current_id);
            this.Close();
        }

        public Point mouseLocation;

        public void dragdown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        public void dragmove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePos;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            dragdown(sender, e);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            dragmove(sender, e);
        }
    }
}
