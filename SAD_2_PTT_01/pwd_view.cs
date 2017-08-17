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
    public partial class pwd_view : Form
    {
        public pwd_view()
        {
            InitializeComponent();
        }
        public main_form reference_to_main { get; set; }
        public int current_pwd = 0;

        private void startup_opacity_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
                this.Opacity += 0.1;
            else
                startup_opacity.Stop();
        }

        private void pwd_view_Load(object sender, EventArgs e)
        {
            startup_opacity.Start();
        }

        private void pwd_view_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
