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
    public partial class device_pending : Form
    {
        public device_pending()
        {
            InitializeComponent();
        }
        public main_form reference_to_main { get; set; }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
