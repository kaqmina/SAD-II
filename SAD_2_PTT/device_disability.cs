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
        #region Declaration
        public main_form reference_to_main { get; set; }
        public MySqlConnection con;
        connections conn = new connections();

        String dis_type, dis_desc, search;
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
        private void startup_opacity_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.1;
        }
        #endregion

        #region FormLoad
        public device_disability()
        {
            InitializeComponent();
            con = new MySqlConnection("Server=localhost;Database=p_dao;Uid=root;Pwd=root;");

        }
        private void device_disability_Load(object sender, EventArgs e)
        {
            conn.device_dis_grid(dev_disgrid);
            this.Opacity = 0;
            startup_opacity.Start();
        }
        #endregion

        #region Add

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_desc.Text == "") txt_desc.Text = "None";

            dis_type = txt_type.Text;
            dis_desc = txt_desc.Text;

            string query = "INSERT INTO disability(disability_type, disability_desc)";
            string values = " VALUES('" + dis_type + "','" + dis_desc + "')";
            conn.Add(query, values);
            conn.device_dis_grid(dev_disgrid);
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
            dis_type = txt_type.Text;
            dis_desc = txt_desc.Text;

            string query = "UPDATE disability SET disability_type = '" + dis_type + "', disability_desc = '" + dis_desc + "' WHERE disability_id = '" + dis_id + "'; ";
            conn.Edit(query);
            conn.device_dis_grid(dev_disgrid);
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

                DataGridViewRow row = this.dev_disgrid.Rows[e.RowIndex];
                dis_type = row.Cells["disability_type"].Value.ToString();
                dis_desc = row.Cells["disability_desc"].Value.ToString();

                dis_id = Convert.ToInt32(row.Cells["disability_id"].Value);
                txt_type.Text = dis_type;
                txt_desc.Text = dis_desc;
                lbl_desc.Text = dis_desc;
            }
        }
        #endregion

        #region Search
        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            search = txt_search.Text;

            string query = "SELECT * FROM p_dao.disability WHERE disability_type LIKE '%" + search + "%'";
            conn.Search(query, dev_disgrid);
        }

        private void txt_search_Enter(object sender, EventArgs e)
        {
            txt_search.Clear();
            txt_search.ForeColor = Color.Black;
            // txt_search.Font = DefaultFont;

            conn.device_dis_grid(dev_disgrid);
        }
        #endregion

    }
}
