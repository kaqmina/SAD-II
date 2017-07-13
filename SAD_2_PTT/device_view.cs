using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SAD_2_PTT
{
    public partial class device_view : Form
    {
        #region Declaration
        public MySqlConnection con;
        public main_form reference_to_main { get; set; }
        #endregion

        #region Transition
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region FormLoad
        public device_view()
        {
            InitializeComponent();
            DataLoad();
        }

        public void DataLoad()
        {
            try
            {
                con.Open();
                MySqlCommand com = new MySqlCommand("SELECT deviceLOG_id, dp_name, dev_name, registration_no, req_date, req_desc, date_in, date_out, status FROM device_log" 
                                                    + "JOIN device_provider ON device_log.dp_id = device.dp_id" 
                                                    + "JOIN device ON device_log.device_id = device.device_id"
                                                    + "JOIN pwd ON device_log.pwd_id = pwd.pwd_id", con);
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["deviceLOG_id"].Visible = false;
                dataGridView1.Columns["registration_no"].HeaderText = "Reg. No.";
                dataGridView1.Columns["fullname"].HeaderText = "Full Name";
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in DataLoad() : " + ex);
            }
        }
        #endregion

        //SELECT deviceLOG_id, dp_id, device_id, pwd_id, req_date, req_desc, date_in, date_out, status FROM device_log 
    }
}
