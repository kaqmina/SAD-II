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
    public partial class device_add : Form
    {
        #region Declaration
        public main_form reference_to_main { get; set; }
        public MySqlConnection con;

        String d_name, d_dis, d_desc;
        int d_id;

        #endregion

        #region Transition
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void device_add_FormClosing(object sender, FormClosingEventArgs e)
        {
            reference_to_main.side_tab.Enabled = true;
            reference_to_main.dboard_head.Enabled = true;
        }
        private void startup_opacity_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.1;
        }
        #endregion

        #region FormLoad
        public device_add()
        {
            InitializeComponent();
            con = new MySqlConnection("Server=localhost;Database=p_dao;Uid=root;Pwd=root;");
            getDisability();
        }
        private void device_add_Load(object sender, EventArgs e)
        {
            DataLoad();
            this.Opacity = 0;
            startup_opacity.Start();
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

        private void DataLoad()
        {
            try
            {
                con.Open();
                MySqlCommand com = new MySqlCommand("SELECT * FROM device", con);
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["device_id"].Visible = false;
                dataGridView1.Columns["disability_id"].Visible = false;
                dataGridView1.Columns["dev_desc"].Visible = false;
                dataGridView1.Columns["dev_name"].HeaderText = "Device Name";

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
        private void Add()
        {
            int d = cmbox_dis.SelectedIndex + 1; 

            d_name = txt_dname.Text;
            d_desc = txt_ddesc.Text;
            d_dis = d.ToString();

            try
            {
                con.Open();
                MySqlCommand com = new MySqlCommand("INSERT INTO device(disability_id,dev_name,dev_desc) VALUES('" + d_dis + "','" + d_name + "','" + d_desc + "')", con);
                com.ExecuteNonQuery();
                con.Close();
                DataLoad();

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
        private void button5_Click(object sender, EventArgs e)
        {
            cmbox_dis.Text = "";
            txt_dname.Clear();
            txt_ddesc.Clear();

            button1.Enabled = true;
            button1.BringToFront();
        }
        #endregion

        #region Edit
        private void button2_Click(object sender, EventArgs e)
        {
            Edit();
        }
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


                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                d_name = row.Cells["dev_name"].Value.ToString();
                d_desc = row.Cells["dev_desc"].Value.ToString();

                d_id = Convert.ToInt32(row.Cells["device_id"].Value);

                //disability id
                int d = 0;
                d = Convert.ToInt32(row.Cells["disability_id"].Value.ToString());
                int dd = d - 1;
                d_dis = cmbox_dis.Items[dd].ToString();


                txt_dname.Text = d_name;
                txt_ddesc.Text = d_desc;
                cmbox_dis.Text = d_dis;
                lbl_ddesc.Text = d_desc;
                lbl_dis.Text = d_dis;
            }
        }
        private void Edit()
        {
            d_name = txt_dname.Text;
            d_desc = txt_ddesc.Text;

            //disability id
            int d = 0;
            d = cmbox_dis.SelectedIndex + 1;
            d_dis = d.ToString();

            try
            {
                con.Open();

                MySqlCommand com = new MySqlCommand("UPDATE device SET disability_id = '" + d_dis + "', dev_name = '" + d_name + "', dev_desc = '" + d_desc + "' WHERE device_id = '" + d_id + "'; ", con);
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

        #endregion

    }
}
