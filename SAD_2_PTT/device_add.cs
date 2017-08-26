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
        connections conn = new connections();
        device_prompt p = new device_prompt();

        String device, disability, desc, search;
        int d_id;
        public bool cont = false;

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
            conn.getDisability(cmbox_dis);
            conn.device_add_grid(dev_addgrid);
        }
        private void device_add_Load(object sender, EventArgs e)
        {
            button5.Visible = false;
            btn_del.Visible = false;
            this.Opacity = 0;
            startup_opacity.Start();
        }
        
        #endregion

        #region Add & Edit
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Edit")
            {
                //remove permanent info
                lbl_ddesc.Text = "";
                lbl_dis.Text = "";

                device = txt_dname.Text;
                desc = txt_ddesc.Text;

                //disability id
                int d = 0;
                d = cmbox_dis.SelectedIndex + 1;

                //Prompt
                string func = "Edit Device";
                p.prompt_title.Text = func;
                p.lbl_quest.Text = "Are you sure to save this changes?";
                p.prompt_title.Location = new Point(171, 4);
                p.lbl_quest.Location = new Point(97, 8);

                p.dev_add = this;
                p.ShowDialog();

                string query = "UPDATE p_dao.device SET device.disability_id = '" + d + "', dev_name = '" + device + "', dev_desc = '" + desc + "' WHERE device.device_id = '" + d_id + "'; ";
                conn.Edit(query, cont);
                conn.device_add_grid(dev_addgrid);
            }
            else
            {
                //if no description to add
                if (txt_ddesc.Text == "") txt_ddesc.Text = "None";

                int d = cmbox_dis.SelectedIndex + 1;

                device = txt_dname.Text;
                desc = txt_ddesc.Text;


                string query = "INSERT INTO p_dao.device(disability_id,dev_name,dev_desc)";
                string values = " VALUES('" + d + "','" + device + "','" + desc + "')";
                conn.Add(query, values);
                conn.device_add_grid(dev_addgrid);
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
                btn_del.Visible = true; // remove button
                button5.Visible = true; // clear button

                DataGridViewRow row = this.dev_addgrid.Rows[e.RowIndex];
                device = row.Cells["dev_name"].Value.ToString();
                desc = row.Cells["dev_desc"].Value.ToString();

                d_id = Convert.ToInt32(row.Cells["device_id"].Value);

                //disability id
                int d = 0;
                d = Convert.ToInt32(row.Cells["disability_id"].Value);
                int dd = d - 1; // comboBox index starts at 0
                disability = cmbox_dis.Items[dd].ToString();


                txt_dname.Text = device;
                txt_ddesc.Text = desc;
                cmbox_dis.Text = disability;
                lbl_ddesc.Text = desc;
                lbl_dis.Text = disability;

                button1.Text = "Edit";
            }
        }

        #endregion

        #region Clear
        private void button5_Click(object sender, EventArgs e)
        {
            cmbox_dis.Text = "";
            txt_dname.Clear();
            txt_ddesc.Clear();

            button1.Text = "Add";
            btn_del.Visible = false;
        }

        #endregion

        #region Search
        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            search = txt_search.Text;

            string query = "SELECT * FROM p_dao.device WHERE dev_name LIKE '%" + search + "%'";
            conn.Search(query, dev_addgrid);
        }
        private void txt_search_Enter(object sender, EventArgs e)
        {
            txt_search.Clear();
            txt_search.ForeColor = Color.Black;
            txt_search.Font = new Font(txt_search.Font, FontStyle.Regular);

            conn.device_add_grid(dev_addgrid);
        }
        #endregion

        #region Remove
        private void btn_del_Click(object sender, EventArgs e)
        {
            //Prompt
            string func = "Remove Device";
            p.prompt_title.Text = func;
            p.lbl_quest.Text = "Are you sure to remove this device?";
            p.prompt_title.Location = new Point(161, 4);
            p.lbl_quest.Location = new Point(92, 8);

            p.dev_add = this;
            p.ShowDialog();

            //cascade.
            string query = "DELETE FROM p_dao.device WHERE dev_name = '" + device + "'";
            conn.Delete(query, cont);
            conn.device_add_grid(dev_addgrid);

            //return to add
            button1.BringToFront();
            button1.Enabled = true;
            button5.Visible = false;
            btn_del.Visible = false;

            //clear
            cmbox_dis.Text = "";
            txt_dname.Clear();
            txt_ddesc.Clear();
        }
        #endregion
    }
}
