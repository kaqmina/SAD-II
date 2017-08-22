using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SAD_2_PTT
{
    public partial class device_provider : Form
    {
        #region Declaration
        public main_form reference_to_main { get; set; }
       // public MySqlConnection con;
        connections conn = new connections();
        device_prompt p = new device_prompt();

        String dp_name, dp_desc, tel_no, email, dp_type, search;
        int dp_id, mob_no, type, dpt;
        public bool cont = false;

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

        private void startup_opacity_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.1;
        }

        #endregion

        #region FormLoad
        public device_provider()
        {
            InitializeComponent();
            conn.device_prov_grid(dev_provgrid);
        }
        private void device_provider_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            startup_opacity.Start();
        }
     
        #endregion

        #region Add
        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_desc.Text == "") txt_desc.Text = "None";
            dp_name = txt_name.Text;
            dp_desc = txt_desc.Text;
            tel_no = txt_telno.Text;
            email = txt_email.Text;

            mob_no = Convert.ToInt32(txt_mobno.Text);

            string query = "INSERT INTO device_provider(dp_name,dp_desc,dp_type,mobile_no,tel_no,email_add)";
            string values = " VALUES('" + dp_name + "','" + dp_desc + "','" + type + "','" + mob_no + "','" + tel_no + "','" + email + "')";
            conn.Add(query, values);
            conn.device_prov_grid(dev_provgrid);
         }

        private void cmbox_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            type = cmbox_type.SelectedIndex;
        }
        #endregion

        #region Clear
        private void button5_Click(object sender, EventArgs e)
        {
            cmbox_type.Text = "";
            txt_name.Clear();
            txt_desc.Clear();
            txt_mobno.Clear();
            txt_telno.Clear();
            txt_email.Clear();

            button1.Enabled = true;
            button1.BringToFront();
        }

        #endregion

        #region Edit
        private void button2_Click(object sender, EventArgs e)
        {
            lbl_desc.Text = "";
            //to pass
            dp_name = txt_name.Text;
            dp_desc = txt_desc.Text;
            tel_no = txt_telno.Text;
            email = txt_email.Text;
            mob_no = Convert.ToInt32(txt_mobno.Text);
            type = cmbox_type.SelectedIndex - 1;

            //Prompt
            string func = "Edit Device Provider";
            p.prompt_title.Text = func;
            p.lbl_quest.Text = "Are you sure you want save this changes?";
            p.prompt_title.Location = new System.Drawing.Point(146, 4);
            p.lbl_quest.Location = new System.Drawing.Point(97, 8);
            p.lbl_out.Visible = p.date_out.Visible = false;

            p.dev_prov = this;
            p.ShowDialog();

            string query = "UPDATE device_provider SET dp_name = '" + dp_name + "', dp_desc = '" + dp_desc + "', dp_type = '" + type + "', mobile_no = '" + mob_no + "', tel_no = '" + tel_no + "', email_add = '" + email + "' WHERE dp_id = '" + dp_id + "'; ";
            conn.Edit(query, cont);
            conn.device_prov_grid(dev_provgrid);
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

                DataGridViewRow row = this.dev_provgrid.Rows[e.RowIndex];
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
        }
        #endregion

        #region Search
        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            search = txt_search.Text;

            string query = "SELECT * FROM device_provider WHERE dp_name LIKE '%" + search + "%'";
            conn.Search(query, dev_provgrid);
        }
        private void txt_search_Enter(object sender, EventArgs e)
        {
            txt_search.Clear();
            txt_search.ForeColor = Color.Black;
            txt_search.Font = new Font(txt_search.Font, FontStyle.Regular);

            conn.device_prov_grid(dev_provgrid);
        }
        #endregion

    }
}
