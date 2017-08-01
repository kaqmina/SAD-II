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
        connections conn = new connections();

        String p_name, req_desc, status, reg_no, d_dis, d_prov, dev, device;
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
            int d = cmbox_dis.SelectedIndex;
            conn.getDevice(d,cmbox_dev);
        }
        #endregion

        #region FormLoad
        public device_view()
        {
            con = new MySqlConnection("Server=localhost;Database=p_dao;Uid=root;Pwd=root;");
            InitializeComponent();
            conn.device_editreq_grid(dev_editreq);
            conn.getDisability(cmbox_dis);
            conn.getProvider(cmbox_prov);

            dev_editreq.BringToFront();

            this.Opacity = 0;
            startup_opacity.Start();
        }

      

        #region Methods
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
                dev_editreq.SendToBack();
                lbl_title.Text = "EDIT REQUEST";
                #endregion

                DataGridViewRow row = this.dev_editreq.Rows[e.RowIndex];

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

                //pass to edit panel [pnl_edit]

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

                //other string values
                txt_desc.Text = req_desc;
                cmbox_dis.Text = d_dis;
                cmbox_dev.Text = dev;
                cmbox_prov.Text = d_prov;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            req_desc = txt_desc.Text;
            d_dis = cmbox_dis.Text;
            d_prov = cmbox_prov.SelectedIndex.ToString();
            req_date = request_date.Value.Date;
            date_IN = date_in.Value.Date;
            date_OUT = date_out.Value.Date;
            
            //without status pa okay?
            string query = "UPDATE p_dao.device_log SET p_dao.device_log.dp_id = '" + d_prov + "', p_dao.device_log.device_id = '" + dev_id + "', p_dao.device_log.req_date = '" + req_date.ToString("yyyy-MM-dd") + "', p_dao.device_log.req_desc = '" + req_desc + "', p_dao.device_log.date_in = '" + date_IN.ToString("yyyy-MM-dd") + "', p_dao.device_log.date_out = '" + date_OUT.ToString("yyyy-MM-dd") + "' WHERE p_dao.device_log.deviceLOG_id = '" + id + "'";
            conn.Edit(query);
            conn.device_editreq_grid(dev_editreq);
        }
       #endregion

        #region Cancel
        private void button2_Click(object sender, EventArgs e)
        {
            dev_editreq.BringToFront();
            lbl_title.Text = "VIEW REQUESTS";
        }
        #endregion
    }
}
