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
    public partial class device_disability : Form
    {
        #region FormLoad
        public device_disability()
        {
            InitializeComponent();
            con = new MySqlConnection("Server=localhost;Database=p_dao;Uid=root;Pwd=root;");

        }
        private void device_disability_Load(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void DataLoad()
        {
            try
            {
                con.Open();
                MySqlCommand com = new MySqlCommand("SELECT * FROM disability", con);
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["disability_id"].Visible = false;
                dataGridView1.Columns["disability_desc"].Visible = false;
                dataGridView1.Columns["disability_type"].HeaderText = "Disability Type";

                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error in DataLoad() : " + ex);
            }
        }
        #endregion

        #region Declaration
        public main_form reference_to_main { get; set; }
        public MySqlConnection con;

        String dis_type, dis_desc;
        int dis_id;
        #endregion

        #region Transition
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void device_disability_FormClosing(object sender, FormClosingEventArgs e)
        {
            reference_to_main.side_tab.Enabled = true;
            reference_to_main.dboard_head.Enabled = true;
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
            dis_type = txt_type.Text;
            dis_desc = txt_desc.Text;

            try
            {
                con.Open();
                MySqlCommand com = new MySqlCommand("INSERT INTO disability(disability_type, disability_desc) VALUES('" + dis_type + "','" + dis_desc +"')", con);
                com.ExecuteNonQuery();
                con.Close();
                DataLoad();

                MessageBox.Show("Added Successfully!", "", MessageBoxButtons.OK);

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error in Add() : " + ex);
                con.Close();
            }
        }
        #endregion

        #region Clear
        private void button4_Click(object sender, EventArgs e)
        {
            txt_type.Clear();
            txt_desc.Clear();

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
            //btn add false
            button1.Enabled = false;
            button2.BringToFront();

            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            dis_type = row.Cells["disability_type"].Value.ToString();
            dis_desc = row.Cells["disability_desc"].Value.ToString();

            dis_id = Convert.ToInt32(row.Cells["disability_id"].Value);
            txt_type.Text = dis_type;
            txt_desc.Text = dis_desc;
        }

        private void Edit()
        {
            dis_type = txt_type.Text;
            dis_desc = txt_desc.Text;
            try
            {
                con.Open();

                MySqlCommand com = new MySqlCommand("UPDATE disability SET disability_type = '" + dis_type + "', disability_desc = '" + dis_desc + "' WHERE disability_id = '" + dis_id + "'; ",con);
                com.ExecuteNonQuery();
                con.Close();
                DataLoad();

                MessageBox.Show("Updated Successfully!","",MessageBoxButtons.OK);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error in Update() : " + ex);
                con.Close();
            }
        }
        #endregion

        #endregion
    }
}
