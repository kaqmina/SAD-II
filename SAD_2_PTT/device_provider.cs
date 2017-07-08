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
    public partial class device_provider : Form
    {
        #region FormLoad
        public device_provider()
        {
            InitializeComponent();
            con = new MySqlConnection("Server=localhost;Database=p_dao;Uid=root;Pwd=root;");
        }
        private void device_provider_Load(object sender, EventArgs e)
        {
            DataLoad();
        }
        private void DataLoad()
        {
            try
            {
                con.Open();
                MySqlCommand com = new MySqlCommand("SELECT * FROM device_provider", con);
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["dp_id"].Visible = false;
                dataGridView1.Columns["dp_desc"].Visible = false;
                dataGridView1.Columns["dp_type"].Visible = false;
                dataGridView1.Columns["mobile_no"].Visible = false;
                dataGridView1.Columns["tel_no"].Visible = false;
                dataGridView1.Columns["email_add"].Visible = false;
                dataGridView1.Columns["dp_name"].HeaderText = "Device Provider";

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in DataLoad() : " + ex);
                con.Close();
            }
        }
        #endregion

        #region Declaration
        public main_form reference_to_main { get; set; }
        public MySqlConnection con;

        String dp_name, dp_desc, tel_no, email,dp_type;
        int dp_id, mob_no, type, dpt;

        #endregion

        #region Transition
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void device_provider_FormClosing(object sender, FormClosingEventArgs e)
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

        private void cmbox_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbox_type.SelectedIndex == 1) type = 0;
            else if (cmbox_type.SelectedIndex == 2) type = 1;
        }

        private void Add()
        {
            dp_name = txt_name.Text;
            dp_desc = txt_desc.Text;
            tel_no = txt_telno.Text;
            email = txt_email.Text;

            mob_no = Convert.ToInt32(txt_mobno.Text);
            dp_type = type.ToString();
            
            try
            {
                con.Open();
                MySqlCommand com = new MySqlCommand("INSERT INTO device_provider(dp_name,dp_desc,dp_type,mobile_no,tel_no,email_add) VALUES('" + dp_name + "','" + dp_desc + "','" + dp_type + "','" + mob_no + "','" + tel_no + "','" + email + "')", con);
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
            txt_name.Clear();
            txt_desc.Clear();
            txt_mobno.Clear();
            txt_telno.Clear();
            txt_email.Clear();
            //dp_type

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
            dp_name = row.Cells["dp_name"].Value.ToString();
            dp_desc = row.Cells["dp_desc"].Value.ToString();
            tel_no = row.Cells["tel_no"].Value.ToString();
            email = row.Cells["email_add"].Value.ToString();
            dp_type = row.Cells["dp_type"].Value.ToString();

            dp_id = Convert.ToInt32(row.Cells["dp_id"].Value);
            mob_no = Convert.ToInt32(row.Cells["mobile_no"].Value);

            //dp_type
            dpt = Int32.Parse(dp_type);
            if (dpt == 0) cmbox_type.Text = "Government";
            else if (dpt == 1) cmbox_type.Text = "Sponsor";

            txt_name.Text = dp_name;
            txt_desc.Text = dp_desc;
            txt_telno.Text = tel_no;
            txt_email.Text = email;
            txt_mobno.Text = mob_no.ToString();
            lbl_desc.Text = dp_desc;
        }
        private void Edit()
        {
            dp_name = txt_name.Text;
            dp_desc = txt_desc.Text;
            tel_no = txt_telno.Text;
            email = txt_email.Text;
            mob_no = Convert.ToInt32(txt_mobno.Text);
            dp_type = type.ToString();

            try
            {
                con.Open();

                MySqlCommand com = new MySqlCommand("UPDATE device_provider SET dp_name = '" + dp_name + "', dp_desc = '" + dp_desc + "', dp_type = '" + dp_type + "', mobile_no = '" + mob_no + "', tel_no = '" + tel_no + "', email_add = '" + email + "' WHERE dp_id = '" + dp_id + "'; ", con);
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
