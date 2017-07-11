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
        #region FormLoad
        public device_request()
        {
            InitializeComponent();
            con = new MySqlConnection("Server=localhost;Database=p_dao;Uid=root;Pwd=root;");
            getDisability();
            getProvider();
            DataLoad();

            request_date.MaxDate = DateTime.Now;
            //date_in.MinDate = DateTime.Now;
            //date_out.MinDate = DateTime.Now;
        }
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
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in getProvider() : " + ex);
                con.Close();
            }
        }
        private void cmbox_dis_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDevice();
        }

        private void DataLoad()
        {
            try
            {
                con.Open();
                MySqlCommand com = new MySqlCommand("SELECT pwd_id,registration_no, (lastname + ', ' + firstname + ' ' + middlename ) AS fullname FROM pwd", con);
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

        private void txt_search_Enter(object sender, EventArgs e)
        {
            txt_search.Clear();
        }
        #endregion

        #region Declaration

        public main_form reference_to_main { get; set; }
        public MySqlConnection con;

        String dr_dev, dr_prov, req_desc, d_dis;

        private void device_request_FormClosing(object sender, FormClosingEventArgs e)
        {
            reference_to_main.side_tab.Enabled = true;
            reference_to_main.dboard_head.Enabled = true;
        }

        #endregion

        #region Transition
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Buttons

        #region Add
        private void Add() {
            int d = cmbox_dis.SelectedIndex + 1;
            int dreq = cmbox_dev.SelectedIndex + 1;
            int dprov = cmbox_prov.SelectedIndex + 1;

            dr_dev = dreq.ToString();
            dr_prov = dprov.ToString();
            d_dis = d.ToString();
            req_desc = txt_desc.Text;

            try
            {
                con.Open();
                MySqlCommand com = new MySqlCommand("INSERT INTO device_log(disability_id,device_id,dp_id,req_desc) VALUES('" + d_dis + "','" + req_desc + "','" + dr_prov + "','" + req_desc + "')", con);
                com.ExecuteNonQuery();
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
