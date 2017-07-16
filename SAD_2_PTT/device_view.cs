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
        public device_add to_edit;
        String p_name, req_desc, status,req_date, reg_no;
        //DateTime req_date, date_in, date_out;
        int stat;
        public main_form reference_to_main { get; set; }
        public device_request dev_req { get; set; }
        #endregion

        #region Transition
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //edit button
            this.Close(); 
           // dev_req.Controls["button1"].SendToBack(); 
        }

        private void device_view_FormClosing(object sender, FormClosingEventArgs e)
        {      
                reference_to_main.side_tab.Enabled = true;
                reference_to_main.dboard_head.Enabled = true;
        }
        #endregion

        #region FormLoad
        public device_view()
        {
            con = new MySqlConnection("Server=localhost;Database=p_dao;Uid=root;Pwd=root;");
            InitializeComponent();
            DataLoad();
            button1.Enabled = false;
        }


        public void DataLoad()
        {
            try
            {
                con.Open();
                MySqlCommand com = new MySqlCommand("SELECT device_log.pwd_id, deviceLOG_id, registration_no, date_in, date_out, req_date, dev_name, dp_name, req_desc, status, CONCAT(lastname, ', ' , firstname, ' ', middlename) AS pwd_name FROM device_log"
                                                    + " JOIN device_provider ON device_log.dp_id = device_provider.dp_id" 
                                                    + " JOIN device ON device_log.device_id = device.device_id"
                                                    + " JOIN pwd ON device_log.pwd_id = pwd.pwd_id", con);
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["pwd_id"].Visible = false;
                dataGridView1.Columns["deviceLOG_id"].Visible = false;
                dataGridView1.Columns["req_desc"].Visible = false;
                dataGridView1.Columns["status"].Visible = false;
                dataGridView1.Columns["pwd_name"].Visible = false;
                dataGridView1.Columns["registration_no"].HeaderText = "Reg. No.";
                dataGridView1.Columns["date_in"].HeaderText = "Date IN";
                dataGridView1.Columns["date_out"].HeaderText = "Date OUT";
                dataGridView1.Columns["dev_name"].HeaderText = "Device";
                dataGridView1.Columns["dp_name"].HeaderText = "Device Provider";

                //DateTime Values
                dataGridView1.Columns["req_date"].HeaderText = "Requested Date";
                //dataGridView1.Columns[3].DefaultCellStyle.Format("MM/dd/YYYY");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in DataLoad() : " + ex);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                //pass
            }
            else
            {
                //btn edit true
                button1.Enabled = true;

                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                p_name = row.Cells["pwd_name"].Value.ToString();
                req_desc = row.Cells["req_desc"].Value.ToString();
                status = row.Cells["status"].Value.ToString();
                req_date = row.Cells["req_date"].Value.ToString();
                reg_no = row.Cells["registration_no"].Value.ToString();

                //status
                stat = Int32.Parse(status);
                if (stat == 0) lbl_status.Text = "yah";
                else if (stat == 1) lbl_status.Text = "yaah";
                else if (stat == 2) lbl_status.Text = "yahyaah";
                else lbl_status.Text = "null";

                lbl_name.Text = p_name;
                lbl_reqdate.Text = req_date;
                lbl_desc.Text = req_desc;
                lbl_reg.Text = reg_no;
            }

        }
        #endregion
    }
}
