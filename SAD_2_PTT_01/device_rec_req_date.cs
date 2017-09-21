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
    public partial class device_rec_req_date : Form
    {
        public device_rec_req_date()
        {
            InitializeComponent();
        }
        public device_pending_req reference_to_main { get; set; }
        public DateTime req_date;

        private void btn_ok_Click(object sender, EventArgs e)
        {
            reference_to_main.date_rec_ = rec_date_value.Value.ToString("yyyy-MM-dd");
            btn_ok.DialogResult = DialogResult.OK;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            btn_cancel.DialogResult = DialogResult.Cancel;
        }

        private void device_rec_req_date_Load(object sender, EventArgs e)
        {
            rec_date_value.MinDate = req_date;
        }
    }
}
