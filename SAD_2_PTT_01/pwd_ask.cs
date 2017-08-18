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
    public partial class pwd_ask : Form
    {
        public pwd_ask()
        {
            InitializeComponent();
        }
        public pwd_add reference_to_main { get; set; }

        private void btn_continue_Click(object sender, EventArgs e)
        {
            reference_to_main.continue_ = true;
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            reference_to_main.continue_ = false;
            this.Close();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
