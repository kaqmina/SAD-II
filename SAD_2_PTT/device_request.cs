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
    public partial class device_request : Form
    {
        #region Declaration
        public main_form reference_to_main { get; set; }
        public MySqlConnection con;
        connections conn = new connections();

        String dr_prov, req_desc, search, reg_no, device;
        DateTime req_dev, req_in, req_out;
        int pwd_id, dev_id;
        #endregion

        #region Transition
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void startup_opacity_Tick_1(object sender, EventArgs e)
        {
            this.Opacity += 0.1;
        }

        private void device_request_FormClosing(object sender, FormClosingEventArgs e)
        {
            reference_to_main.side_tab.Enabled = true;
            reference_to_main.dboard_head.Enabled = true;
        }

        private void txt_search_Enter(object sender, EventArgs e)
        {
            txt_search.Clear();
            txt_search.ForeColor = Color.Black;
        }

        private void cmbox_dev_SelectedIndexChanged(object sender, EventArgs e)
        {
            device = cmbox_dev.SelectedItem.ToString();
            getDeviceID(device);
        }
        #endregion

        #region FormLoad
        public device_request()
        {
            InitializeComponent();
            con = new MySqlConnection("Server=localhost;Database=p_dao;Uid=root;Pwd=root;");
            getDisability();
            conn.getProvider(cmbox_prov);
            conn.device_addreq_grid(dev_addreq);

            request_date.Value = DateTime.Now;
            date_in.Value = DateTime.Now;
            date_out.Value = DateTime.Now;

            this.Opacity = 0;
            startup_opacity.Start();
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
                if(cmbox_dis.Items.Count == 0)
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

                MySqlCommand com = new MySqlCommand("SELECT dev_name FROM p_dao.device WHERE disability_id = " + d, con);
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

        private void Search(string query)
        {
            search = txt_search.Text;

            try
            {
                con.Open();
                MySqlCommand com = new MySqlCommand(query, con);
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                DataTable dt = new DataTable();

                adp.Fill(dt);
                dev_addreq.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Search(): " + ex);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                //pass
            }
            else
            {
                DataGridViewRow row = this.dev_addreq.Rows[e.RowIndex];
                reg_no = row.Cells["registration_no"].Value.ToString();

                //pwd id
                int id = 0;
                id = Convert.ToInt32(row.Cells["pwd_id"].Value.ToString());
                pwd_id = id;

                lbl_reg.Text = reg_no;

               
            }
        }

        private void cmbox_dis_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDevice();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT pwd_id,registration_no, CONCAT(lastname, ', ' , firstname, ' ', middlename) AS fullname FROM pwd WHERE CONCAT(lastname, ', ' , firstname, ' ', middlename) LIKE '%" + search + "%' OR lastname  LIKE '%" + search + "%' OR firstname  LIKE '%" + search + "%' OR middlename  LIKE '%" + search + "%' OR registration_no LIKE '%" + search + "%'";
            Search(query);
        }

        #endregion

        #region Buttons

        #region Add
        public void button1_Click(object sender, EventArgs e)
        {
            Add();
        }
        private void Add() {
            int dprov = cmbox_prov.SelectedIndex;

            dr_prov = dprov.ToString();
            req_desc = txt_desc.Text;
            req_dev = request_date.Value.Date;
            req_in = date_in.Value.Date;
            req_out = date_out.Value.Date;

            try
            {
                con.Open();
                if (cmbox_dis.Text == "")
                {
                    MessageBox.Show("No status selected.", "", MessageBoxButtons.OK);
                }
                else
                {
                    MySqlCommand com = new MySqlCommand("INSERT INTO p_dao.device_log(dp_id,device_log.pwd_id,device_id,req_date,req_desc,date_in,date_out) VALUES('" + dr_prov + "','" + pwd_id + "','" + dev_id + "','" + req_dev.ToString("yyyy-MM-dd") + "','" + req_desc + "','" + req_in.ToString("yyyy-MM-dd") + "','" + req_out.ToString("yyyy-MM-dd") + "')", con);
                    com.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Added Successfully!", "", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Add() : " + ex);
                con.Close();
            }
        }
        #endregion

        #region Clear
        private void button2_Click(object sender, EventArgs e)
        {
            cmbox_dis.Text = "";
            cmbox_dev.Text = "";
            cmbox_prov.Text = "";
            txt_desc.Clear();
            request_date.Value = DateTime.Now;
            date_in.Value = DateTime.Now;
            date_out.Value = DateTime.Now;
        }
        #endregion

        #endregion
    }
}
