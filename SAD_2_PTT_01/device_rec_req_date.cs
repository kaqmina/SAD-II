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
        public device_pending_req reference_to_requests { get; set; }
        public device_pending_rec reference_to_received { get; set; }
        public DateTime req_date;
        public DateTime rec_date;
        public int state = 0;

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (state == 0)
                reference_to_requests.date_rec_ = rec_date_value.Value.ToString("yyyy-MM-dd");
            else 
                reference_to_received.date_out_ = rec_date_value.Value.ToString("yyyy-MM-dd");
            btn_ok.DialogResult = DialogResult.OK;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            btn_cancel.DialogResult = DialogResult.Cancel;
        }

        private void device_rec_req_date_Load(object sender, EventArgs e)
        {
            rec_date_value.MaxDate = DateTime.Now;
            if (state == 0)
                rec_date_value.MinDate = req_date;
            else
                rec_date_value.MinDate = rec_date;
        }
    }
}
