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
    public partial class device_prompt : Form
    {
        public device_add dev_add { get; set; }
        public device_disability dev_dis { get; set; }
        public device_provider  dev_prov { get; set; }
        public device_view dev_view { get; set; }

        public device_prompt()
        {
            InitializeComponent();
        }

        private void btn_continue_Click(object sender, EventArgs e)
        {
            dev_add.cont = true;
            dev_dis.cont = true;
            dev_prov.cont = true;
            dev_view.cont = true;

            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // information for all prompts
    }
}
