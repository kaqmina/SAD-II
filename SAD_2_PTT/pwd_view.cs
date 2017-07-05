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
        }
        public main_form reference_to_main { get; set; }
        main_functions main_f = new main_functions();

        private void pwd_view_back_Click(object sender, EventArgs e)
        {
            reference_to_main.side_tab.Enabled = true;
            reference_to_main.dboard_head.Enabled = true;
            this.Close();
        }

        private void pwd_view_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            startup_opacity.Start();
        }

        private void startup_opacity_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.1;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
