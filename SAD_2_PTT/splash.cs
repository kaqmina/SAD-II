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
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
        }
        int seconds = 8;

        private void splash_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            startup_opacity.Start();
            splasht.Start();
        }

        private void splasht_Tick(object sender, EventArgs e)
        {
            if(seconds > 0 )
            {
                seconds--;
            } else
            {
                this.Hide();
                login log = new login();
                log.Closed += (s, args) => this.Close();
                log.Show();
                splasht.Stop();
            }
        }

        private void startup_opacity_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
                this.Opacity += 0.1;
            else
                startup_opacity.Stop();
        }
    }
}
