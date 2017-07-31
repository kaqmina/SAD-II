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

        String p_name, req_desc, status, reg_no, d_dis, d_dev, d_prov, dev, device;
        DateTime req_date, date_IN, date_OUT;
        int stat, id, dev_id;

        public main_form reference_to_main { get; set; }
        public device_request dev_req { get; set; }
        #endregion

        #region Transition
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void startup_opacity_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.1;
        }

        private void device_view_FormClosing(object sender, FormClosingEventArgs e)
        {      
                reference_to_main.side_tab.Enabled = true;
                reference_to_main.dboard_head.Enabled = true;
        }

        private void cmbox_dev_SelectedIndexChanged(object sender, EventArgs e)
        {
            device = cmbox_dev.SelectedItem.ToString();
            MessageBox.Show(device);
            getDeviceID(device);
            
        }

        private void cmbox_dis_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDevice();
        }
        #endregion

        #region FormLoad
        public device_view()
        {
            con = new MySqlConnection("Server=localhost;Database=p_dao;Uid=root;Pwd=root;");
            InitializeComponent();
            DataLoad();
            getDisability();
            getProvider();

            dataGridView1.BringToFront();

            this.Opacity = 0;
            startup_opacity.Start();
        }

        public void DataLoad()
        {
            try
            {
                con.Open();
                MySqlCommand com = new MySqlCommand("SELECT device_log.pwd_id, device_log.dp_id, device_log.device_id, device.disability_id, deviceLOG_id, registration_no, CONCAT(lastname, ', ' , firstname, ' ', middlename) AS pwd_name, date_in, date_out, req_date, dev_name, dp_name, req_desc, status FROM device_log"
                                                    + " JOIN device_provider ON device_log.dp_id = device_provider.dp_id" 
                                                    + " JOIN device ON device_log.device_id = device.device_id"
                                                    + " JOIN pwd ON device_log.pwd_id = pwd.pwd_id", con);
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["pwd_id"].Visible = false;
                dataGridView1.Columns["dp_id"].Visible = false;
                dataGridView1.Columns["device_id"].Visible = false;
                dataGridView1.Columns["disability_id"].Visible = false;
                dataGridView1.Columns["deviceLOG_id"].Visible = false;
                dataGridView1.Columns["req_desc"].Visible = false;
                dataGridView1.Columns["status"].Visible = false;
                dataGridView1.Columns["registration_no"].HeaderText = "Reg. No.";
                dataGridView1.Columns["pwd_name"].HeaderText = "Name";
                dataGridView1.Columns["date_in"].HeaderText = "Date IN";
                dataGridView1.Columns["date_out"].HeaderText = "Date OUT";
                dataGridView1.Columns["dev_name"].HeaderText = "Device";
                dataGridView1.Columns["dp_name"].HeaderText = "Device Provider";
                dataGridView1.Columns["req_date"].HeaderText = "Requested Date";
          
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in DataLoad() : " + ex);
            }
        }

        #region Methods
        private void getDisability()
        {
            MySqlCommand com = new MySqlCommand("SELECT disability_type FROM disability", con);
            MySqlDataReader dr;

            try
            {
                con.Open();
                dr = com.ExecuteReader();

                while (dr.Read())
                {
                    string dis = dr.GetString("disability_type");
                    cmbox_dis.Items.Add(dis);
                }
                if (cmbox_dis.Items.Count == 0)
                {
                    MessageBox.Show("No disabilities added.");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in getDisability() : " + ex);
                con.Close();
            }
        }


        private void getDevice()
        {
            try
            {
                con.Open();

                cmbox_dev.Items.Clear();
                cmbox_dev.Items.Add("");
                int d = cmbox_dis.SelectedIndex;

                MySqlCommand com = new MySqlCommand("SELECT dev_name FROM device WHERE disability_id = " + d, con);
                MySqlDataAdapter get = new MySqlDataAdapter(com);
                DataTable set = new DataTable();
                get.Fill(set);

                int count = set.Rows.Count;
                if (count == 0)
                {
                    MessageBox.Show("No devices added for this disability.");
                }
                else
                {
                    foreach (DataRow data in set.Rows)
                    {
                        cmbox_dev.Items.Add(data["dev_name"].ToString());
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in getting data from cmbox_dis : " + ex);
                con.Close();
            }
        }
        private void getProvider()
        {
            MySqlCommand com = new MySqlCommand("SELECT dp_name FROM device_provider", con);
            MySqlDataReader dr;

            try
            {
                con.Open();
                dr = com.ExecuteReader();

                while (dr.Read())
                {
                    string provider = dr.GetString("dp_name");
                    cmbox_prov.Items.Add(provider);
                }
                if (cmbox_prov.Items.Count == 0)
                {
                    MessageBox.Show("No device provider added.");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in getProvider() : " + ex);
                con.Close();
            }
        }

        private void getDeviceID(string device)
        {
            try
            {
                con.Open();
                MySqlCommand com = new MySqlCommand("SELECT p_dao.device.device_id FROM p_dao.device WHERE p_dao.device.dev_name = '" + device + "'", con);
                using (MySqlDataReader dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        dev_id = dr.GetInt32("device_id");
                    }
                    con.Close();
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in getDeviceID() : " + ex);
                con.Close();
            }
        }

        #endregion

        #endregion

        #region Edit
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                //pass
            }
            else
            {

                #region Transition
                button1.Enabled = true;
                dataGridView1.SendToBack();
                lbl_title.Text = "EDIT REQUEST";
                #endregion

                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                //device_logID
                int log_id = 0;
                log_id = Convert.ToInt32(row.Cells["deviceLOG_id"].Value);
                id = log_id;
                
                p_name = row.Cells["pwd_name"].Value.ToString();
                req_desc = row.Cells["req_desc"].Value.ToString();
                status = row.Cells["status"].Value.ToString();
                reg_no = row.Cells["registration_no"].Value.ToString();
                dev = row.Cells["dev_name"].Value.ToString();

                //DateTime Values
                req_date = Convert.ToDateTime(row.Cells["req_date"].Value.ToString());
                date_IN = Convert.ToDateTime(row.Cells["date_in"].Value.ToString());
                date_OUT = Convert.ToDateTime(row.Cells["date_out"].Value.ToString());

                //status
                stat = Int32.Parse(status);
                if (stat == 0) cmbox_stat.Text = "Requested"; // what stat
                else if (stat == 1) cmbox_stat.Text = "Received";
                else if (stat == 2) cmbox_stat.Text = "Handed Out";
                else MessageBox.Show("No status selected.","",MessageBoxButtons.OK);

                //pass to pnl_edit

                //disability id [cmbox_dis]
                int d = 0;
                d = Convert.ToInt32(row.Cells["disability_id"].Value);
                d_dis = cmbox_dis.Items[d].ToString();

                //device [cmbox_dev]
                cmbox_dev.SelectedValue = dev;
               

                //device provider [cmbox_prov]
                int d2 = 0;
                d2 = Convert.ToInt32(row.Cells["dp_id"].Value);
                d_prov = cmbox_prov.Items[d2].ToString();

                //DateTime Values
                request_date.Format.ToString("d");
                request_date.Value = req_date;
                date_in.Format.ToString("d");
                date_in.Value = date_IN;
                date_out.Format.ToString("d");
                date_out.Value = date_OUT;

                //other values
                txt_desc.Text = req_desc;
                cmbox_dis.Text = d_dis;
                cmbox_dev.Text = dev;
                cmbox_prov.Text = d_prov;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void Edit()
        {
            req_desc = txt_desc.Text;
            d_dis = cmbox_dis.Text;
            d_dev = dev_id.ToString();
            d_prov = cmbox_prov.SelectedIndex.ToString();
            req_date = request_date.Value.Date;
            date_IN = date_in.Value.Date;
            date_OUT = date_out.Value.Date;
            try
            {
                con.Open();

                MySqlCommand com = new MySqlCommand("UPDATE p_dao.device_log SET p_dao.device_log.dp_id = '" + d_prov + "', p_dao.device_log.device_id = '" + dev_id + "', p_dao.device_log.req_date = '" + req_date.ToString("yyyy-MM-dd") + "', p_dao.device_log.req_desc = '" + req_desc + "', p_dao.device_log.date_in = '" + date_IN.ToString("yyyy-MM-dd") + "', p_dao.device_log.date_out = '" + date_OUT.ToString("yyyy-MM-dd")+ "' WHERE p_dao.device_log.deviceLOG_id = '" + id + "'", con);
                com.ExecuteNonQuery();
                con.Close();
                DataLoad();

                MessageBox.Show("Updated Successfully!", "", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Update() : " + ex);
                con.Close();
            }
           
        }
       #endregion

        #region Cancel
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.BringToFront();
            lbl_title.Text = "VIEW REQUESTS";
        }
        #endregion
    }
}
