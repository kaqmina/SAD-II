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
    public partial class device_disability : Form
    {
        public device_disability()
        {
            InitializeComponent();
        }
        public main_form reference_to_main { get; set; }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void device_disability_FormClosing(object sender, FormClosingEventArgs e)
        {
            reference_to_main.side_tab.Enabled = true;
            reference_to_main.dboard_head.Enabled = true;
        }
    }
}
