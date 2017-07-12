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

        String dr_dev, dr_prov, req_desc, d_dis,search;
        DateTime req_dev, req_in, req_out;
        #endregion

        #region Transition
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void device_request_FormClosing(object sender, FormClosingEventArgs e)
        {
            reference_to_main.side_tab.Enabled = true;
            reference_to_main.dboard_head.Enabled = true;
        }
        // -- opacity
        private void txt_search_Enter(object sender, EventArgs e)
        {
            txt_search.Clear();
            txt_search.ForeColor = Color.Black;
        }
        #endregion

        #region FormLoad
        public device_request()
        {
            InitializeComponent();
            con = new MySqlConnection("Server=localhost;Database=p_dao;Uid=root;Pwd=root;");
            getDisability();
            getProvider();
            DataLoad();

            request_date.Value = DateTime.Now;
            date_in.Value = DateTime.Now;
            date_out.Value = DateTime.Now;
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
                if(cmbox_prov.Items.Count == 0)
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
        private void Search()
        {
            search = txt_search.Text;

            try
            {
                con.Open();
                MySqlCommand com = new MySqlCommand("SELECT pwd_id,registration_no, CONCAT(lastname, ', ' , firstname, ' ', middlename) AS fullname FROM pwd WHERE CONCAT(lastname, ', ' , firstname, ' ', middlename) LIKE '%" + search + "%' OR lastname  LIKE '%" + search + "%' OR firstname  LIKE '%" + search + "%' OR middlename  LIKE '%" + search + "%' OR registration_no LIKE '%" + search + "%'", con);
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                DataTable dt = new DataTable();

                adp.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in txt_search(): " + ex);
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
                //btn add false
                button1.Enabled = false;
                button2.BringToFront();

                #region nothing 
                /* DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                // req_desc = row.Cells["req_desc"].Value.ToString();

                 int  dl_id = Convert.ToInt32(row.Cells["deviceLOG_id"].Value);

                 //disability id
                 int d = 0;
                 d = Convert.ToInt32(row.Cells["disability_id"].Value.ToString());
                 int dd = d - 1;
                 d_dis = cmbox_dis.Items[dd].ToString();

                 //device requested
                 int dr = 0;
                 dr = Convert.ToInt32(row.Cells["dev_name"].Value.ToString());
                 int dd1 = dr - 1;
                 dr_dev = cmbox_dis.Items[dd1].ToString();

                 //device provider
                 int dp = 0;
                 dp = Convert.ToInt32(row.Cells["dp_name"].Value.ToString());
                 int dd2 = dp - 1;
                 dr_prov = cmbox_dis.Items[dd2].ToString();

                 txt_desc.Text = req_desc;
                 cmbox_dis.Text = d_dis;
                 cmbox_dev.Text = dr_dev;
                 cmbox_prov.Text = dr_prov;*/
                #endregion
            }
        }

        private void cmbox_dis_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDevice();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void DataLoad()
        {
            try
            {
                con.Open();
                MySqlCommand com = new MySqlCommand("SELECT pwd_id,registration_no, CONCAT(lastname, ', ' , firstname, ' ', middlename) AS fullname FROM pwd", con);
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["pwd_id"].Visible = false;              
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

        #region Buttons

        #region Add
        private void button1_Click(object sender, EventArgs e)
        {
            Add();
        }
        private void Add() {
            int d = cmbox_dis.SelectedIndex + 1;
            int dreq = cmbox_dev.SelectedIndex + 1;
            int dprov = cmbox_prov.SelectedIndex + 1;


            dr_dev = dreq.ToString();
            dr_prov = dprov.ToString();
            d_dis = d.ToString();
            req_desc = txt_desc.Text;
            req_dev = request_date.Value.Date;
            req_in = date_in.Value.Date;
            req_out = date_out.Value.Date;

            try
            {
                con.Open();
                //MySqlCommand com = new MySqlCommand("INSERT INTO device_log(dp_id,pwd_id,device_id,req_date,req_desc,date_in,date_out) VALUES('" + dr_prov + "','" + [pwd_id] + "','" + dr_dev + "','" + req_dev.ToString("yyyy-MM-dd") + "','" + req_desc + "','" + req_in.ToString("yyyy-MM-dd") + "','" + req_out.ToString("yyyy-MM-dd") + "')", con);
                //com.ExecuteNonQuery();
                con.Close();
                //DataLoad();

                MessageBox.Show("Added Successfully!", "", MessageBoxButtons.OK);

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

        #region Edit
        #endregion

        #endregion
    }
}
