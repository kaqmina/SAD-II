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

        #endregion

        #region FormLoad
        public device_request()
        {
            InitializeComponent();
            con = new MySqlConnection("Server=localhost;Database=p_dao;Uid=root;Pwd=root;");

            //Methods
            conn.getDisability(cmbox_dis);
            conn.getProvider(cmbox_prov);
            conn.device_addreq_grid(dev_addreq);

            //Initialization
            request_date.Value = DateTime.Now;
            cmbox_stat.Text = "Requested";
            cmbox_stat.Enabled = false;
        

            //Form Transition
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

        #region ComboBox
        private void cmbox_dis_SelectedIndexChanged(object sender, EventArgs e)
        {
            int d = cmbox_dis.SelectedIndex;
            conn.getDevice(d,cmbox_dev);
        }
        private void cmbox_dev_SelectedIndexChanged(object sender, EventArgs e)
        {
            device = cmbox_dev.SelectedItem.ToString();
            getDeviceID(device);
        }
        #endregion

        #endregion

        #region Add
        public void button1_Click(object sender, EventArgs e)
        {
            int dprov = cmbox_prov.SelectedIndex;

            dr_prov = dprov.ToString();
            req_desc = txt_desc.Text;
            req_dev = request_date.Value.Date;

            
            string query = "INSERT INTO p_dao.device_log(dp_id,device_log.pwd_id,device_log.device_id,req_date,req_desc,status,req_emp_id, out_emp_id)";
            string values = " VALUES('" + dr_prov + "', '" + pwd_id + "', '" + dev_id + "', '" + req_dev.ToString("yyyy-MM-dd") + "', '" + req_desc + "' ,'0', "  
                            + "(SELECT employee_id FROM employee WHERE username = '" + reference_to_main.current_user + "'), " 
                            + "(SELECT employee_id FROM employee WHERE username = '" + reference_to_main.current_user + "'))";
            conn.Add(query,values);
           
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

        #region Search

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            search = txt_search.Text;

            string query = "SELECT pwd_id,registration_no, CONCAT(lastname, ', ' , firstname, ' ', middlename) AS fullname FROM pwd WHERE CONCAT(lastname, ', ' , firstname, ' ', middlename) LIKE '%" + search + "%' OR lastname  LIKE '%" + search + "%' OR firstname  LIKE '%" + search + "%' OR middlename  LIKE '%" + search + "%' OR registration_no LIKE '%" + search + "%'";
            conn.Search(query, dev_addreq);
        }

        private void txt_search_Enter(object sender, EventArgs e)
        {
            txt_search.Clear();
            txt_search.ForeColor = Color.Black;
            txt_search.Font = new Font(txt_search.Font, FontStyle.Regular);

            conn.device_addreq_grid(dev_addreq);
        }
        #endregion

    }
}
