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
    public partial class device_view : Form 
    {
        #region Declaration
        public main_form reference_to_main { get; set; }
        public MySqlConnection con;
        connections conn = new connections();
        device_prompt p = new device_prompt();

        String p_name, req_desc, status, reg_no, d_dis, d_prov, dev, device, search;
        String clicked = "default";
        DateTime req_date, date_IN, date_OUT;
        int dev_id, dp;
        public bool valid = false;
        public bool cont = false; // continue for edit [device_prompt]
        public int id; //to be used in [device_prompt]
        public int fstatus; //final status
        #endregion

        #region Transition
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void startup_opacity_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.1;
        }

        private void device_view_FormClosing(object sender, FormClosingEventArgs e)
        {      
            reference_to_main.side_tab.Enabled = true;
            reference_to_main.dboard_head.Enabled = true;
        }

        private void cmbox_dev_SelectedIndexChanged(object sender, EventArgs e)
        {
            device = cmbox_dev.SelectedItem.ToString();
            getDeviceID(device);
        }

        private void cmbox_dis_SelectedIndexChanged(object sender, EventArgs e)
        {
            int d = cmbox_dis.SelectedIndex;
            conn.getDevice(d,cmbox_dev);
        }

        #endregion

        #region FormLoad
        public device_view()
        {
            con = new MySqlConnection("Server=localhost;Database=p_dao;Uid=root;Pwd=root;");
            InitializeComponent();
            
            //Methods
            conn.device_editreq_grid(dev_editreq, clicked);
            conn.getDisability(cmbox_dis);
            conn.getProvider(cmbox_prov);

            dev_editreq.BringToFront(); //grid
            dateOut.Visible = label9.Visible = stat_out.Visible = false; //dateOut & handed out status details
            btn_out.Enabled = false;
            btn_out.Text = "";

            //timer
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

        #endregion

        #region Edit

        private void dev_editreq_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                //pass
            }
            else
            {

                #region Transition
                button1.Enabled = true;
                dev_editreq.SendToBack(); //grid to back
                lbl_title.Text = "EDIT REQUEST"; //header
                date_in.Visible = label10.Visible = false; // date_in

                //search & filter grid status
                pnl_search.Visible = false;
                btn_req.Visible = btn_rec.Visible = btn_default.Visible = false;
                label12.Visible = label8.Visible = btn_out.Visible = false;
                #endregion

                DataGridViewRow row = this.dev_editreq.Rows[e.RowIndex];

                //device_logID
                int log_id = 0;
                log_id = Convert.ToInt32(row.Cells["deviceLOG_id"].Value);
                id = log_id;

                p_name = row.Cells["pwd_name"].Value.ToString();
                req_desc = row.Cells["req_desc"].Value.ToString();
                status = row.Cells["status"].Value.ToString();
                reg_no = row.Cells["registration_no"].Value.ToString();
                dev = row.Cells["dev_name"].Value.ToString();

                //DateTime Values
                req_date = Convert.ToDateTime(row.Cells["req_date"].Value.ToString());
                foreach (DataGridViewRow rows in dev_editreq.Rows)
                {  
                    if (rows.Cells["date_in"].Value == null) continue;
                    if (rows.Cells["date_out"].Value == null) continue;
                }           

                //status
                if (status == "Requested") stat_req.PerformClick();
                else if (status == "Received") stat_rec.PerformClick();

                //pass to edit panel [pnl_edit]

                //disability id [cmbox_dis]
                int d = 0;
                d = Convert.ToInt32(row.Cells["disability_id"].Value);
                d_dis = cmbox_dis.Items[d].ToString();

                //device [cmbox_dev]
                cmbox_dev.SelectedValue = dev;


                //device provider [cmbox_prov]
                int d2 = 0;
                d2 = Convert.ToInt32(row.Cells["dp_id"].Value);
                d_prov = cmbox_prov.Items[d2].ToString();

                //DateTime Values
                request_date.Format.ToString("d");
                request_date.Value = req_date;
                date_in.Format.ToString("d");
                dateOut.Format.ToString("d");

                //other string values
                txt_desc.Text = req_desc;
                cmbox_dis.Text = d_dis;
                cmbox_dev.Text = dev;
                cmbox_prov.Text = d_prov;
                lbl_desc.Text = reg_no;

            }

        }
        private void button1_Click(object sender, EventArgs e) // edit request FROM dev_editreq grid
        {
    
            req_desc = txt_desc.Text;
            d_dis = cmbox_dis.Text;
            dp = cmbox_prov.SelectedIndex;
            req_date = request_date.Value.Date;
            date_IN = date_in.Value.Date;
            date_OUT = dateOut.Value.Date;          
            
            //Prompt
            string func = "Edit Request";
            p.prompt_title.Text = func;
            p.lbl_quest.Text = "Are you sure to save this changes?";
            p.prompt_title.Location = new Point(168, 4);
            p.lbl_quest.Location = new Point(97, 8);
            p.lbl_quest.Visible = true;
            p.lbl_out.Visible = p.date_out.Visible = false;

            p.dev_view = this;
            p.ShowDialog();

            checkStatus_emp(fstatus);
            
            conn.device_editreq_grid(dev_editreq, clicked);
            conn.device_out_grid(reference_to_main.device_grid);
            button2.Text = "Close";
        }
       #endregion

        #region Cancel / Close
        private void button2_Click(object sender, EventArgs e)
        {
            dev_editreq.BringToFront(); //grid to front
            lbl_title.Text = "VIEW REQUESTS"; //header

            pnl_search.Visible = true;   
            btn_req.Visible = btn_rec.Visible = btn_default.Visible = true;
            label12.Visible = label8.Visible =  btn_out.Visible = true;
            btn_out.Enabled = false;
            btn_out.Text = "";
        }
        #endregion

        #region Filter [Status]
        private void btn_req_Click(object sender, EventArgs e)
        {
            clicked = "Requested";
            conn.device_editreq_grid(dev_editreq,clicked);
        }
        private void btn_rec_Click(object sender, EventArgs e)
        {
            clicked = "Received";
            conn.device_editreq_grid(dev_editreq, clicked);
        }
        private void btn_default_Click(object sender, EventArgs e)
        {
            clicked = "default";
            conn.device_editreq_grid(dev_editreq, clicked);
        }
        #endregion

        #region Search
        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            search = txt_search.Text;

            string current = "(CASE WHEN status = 0 THEN 'Requested' WHEN status = 1 THEN 'Received' ELSE 'Handed Out' END)";
            string query = "SELECT device_log.pwd_id, device_log.dp_id, device_log.device_id, device.disability_id, deviceLOG_id, registration_no, CONCAT(lastname, ', ' , firstname, ' ', middlename) AS pwd_name, date_in, date_out, req_date, dev_name, dp_name, req_desc, "
                           + current + " AS Status FROM device_log"
                           + " JOIN p_dao.device_provider ON device_log.dp_id = device_provider.dp_id"
                           + " JOIN p_dao.device ON device_log.device_id = device.device_id"
                           + " JOIN pwd ON device_log.pwd_id = pwd.pwd_id"
                           + " WHERE registration_no LIKE '%" + search + "%' OR dev_name LIKE '%" + search + "%' OR dp_name LIKE '%" + search + "%'"
                           + " OR CONCAT(lastname, ', ' , firstname, ' ', middlename) LIKE '%" + search + "%' OR firstname LIKE '%" + search + "%' OR middlename LIKE '%" + search + "%'";
            conn.Search(query, dev_editreq);
        }

        private void txt_search_Enter(object sender, EventArgs e)
        {
            txt_search.Clear();
            txt_search.ForeColor = Color.Black;
            txt_search.Font = new Font(txt_search.Font,FontStyle.Regular); // italic -> regular
        }

        #endregion

        #region Select Status
        private void btn_toRec_Click(object sender, EventArgs e) //stat_rec button [status: received]
        {
            fstatus = 1;
            stat_req.BackColor = Color.DimGray;
            stat_req.ForeColor = Color.White;

            stat_out.BackColor = Color.DimGray;
            stat_out.ForeColor = Color.White;

            stat_rec.BackColor = Color.White;
            stat_rec.ForeColor = bar.BackColor;

            date_in.Visible = label10.Visible = true;
        }

        private void stat_req_Click(object sender, EventArgs e) // [status: requested]
        {
            fstatus = 0;

            stat_rec.BackColor = Color.DimGray;
            stat_rec.ForeColor = Color.White;

            stat_out.BackColor = Color.DimGray;
            stat_out.ForeColor = Color.White;

            stat_req.BackColor = Color.White;
            stat_req.ForeColor = bar.BackColor;

            date_in.Visible = label10.Visible = false;
        }

        private void stat_out_Click(object sender, EventArgs e)
        {
            fstatus = 2;

            stat_out.BackColor = Color.White;
            stat_out.ForeColor = bar.BackColor;

            stat_rec.BackColor = Color.DimGray;
            stat_rec.ForeColor = Color.White;

            stat_req.BackColor = Color.DimGray;
            stat_req.ForeColor = Color.White;
        }
        #endregion

        #region Status : Handed Out
        private void btn_out_Click(object sender, EventArgs e)
        {  
            string func = "Status : Handed Out";
            p.prompt_title.Text = func;
            p.lbl_quest.Visible = false;
            p.prompt_title.Location = new Point(142, 3);
            p.date_out.Visible = p.lbl_out.Visible = true;

            p.dev_view = this;
            p.ShowDialog();

            // string query_emp = "INSERT INTO device_log(out_emp_id) ";
            //string value_emp = "VALUES((SELECT employee_id FROM employee WHERE username = '" + reference_to_main.current_user + "'))";
            // conn.Add(query_emp, value_emp);
            conn.device_editreq_grid(dev_editreq, clicked);
            conn.device_out_grid(reference_to_main.device_grid);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) //for handed out
        {
            if (e.RowIndex < 0)
            {
                //pass
            }
            else
            {

                DataGridViewRow row = this.dev_editreq.Rows[e.RowIndex];

                //device_logID
                int log_id = 0;
                log_id = Convert.ToInt32(row.Cells["deviceLOG_id"].Value);
                id = log_id;

                status = row.Cells["status"].Value.ToString();
                if (status == "Requested")
                {
                    btn_out.Enabled = false;
                    btn_out.Text = "";
                }
                else if (status == "Received")
                {
                    btn_out.Enabled = true;
                    btn_out.ForeColor = Color.White;
                    btn_out.Text = "HAND OUT";
                }
            }
        }
        #endregion

        #region checkStatus()
        public void checkStatus_emp(int status)
        {
            string query, values;

            if (status == 0)
            {
                query = "UPDATE p_dao.device_log SET p_dao.device_log.dp_id = '" + dp + "', p_dao.device_log.device_id = '" + dev_id + "', p_dao.device_log.req_date = '" + req_date.ToString("yyyy-MM-dd") + "', p_dao.device_log.req_desc = '" + req_desc + "', p_dao.device_log.date_in = '" + date_IN.ToString("yyyy-MM-dd") + "', p_dao.device_log.date_out = '" + date_OUT.ToString("yyyy-MM-dd") + "', status = '" + fstatus + "',"
                          + " req_emp_id = (SELECT employee_id FROM employee WHERE username = '" + reference_to_main.current_user + "') WHERE device_log.deviceLOG_id = '" + id + "'";

                conn.Edit(query, cont);
            }
            else if(status == 1)
            {
                if (conn.checkStatus("in") == true)
                {
                    query = "INSERT INTO device_log(in_emp_id) ";
                    values = "VALUES((SELECT employee_id FROM employee WHERE username = '" + reference_to_main.current_user + "'))WHERE deviceLOG_id = '" + id + "'";
                    conn.Add(query, values);
                }
                else
                {
                    query = "UPDATE p_dao.device_log SET p_dao.device_log.dp_id = '" + dp + "', p_dao.device_log.device_id = '" + dev_id + "', p_dao.device_log.req_date = '" + req_date.ToString("yyyy-MM-dd") + "', p_dao.device_log.req_desc = '" + req_desc + "', p_dao.device_log.date_in = '" + date_IN.ToString("yyyy-MM-dd") + "', p_dao.device_log.date_out = '" + date_OUT.ToString("yyyy-MM-dd") + "', status = '" + fstatus + "',"
                         + " in_emp_id = (SELECT employee_id FROM employee WHERE username = '" + reference_to_main.current_user + "') WHERE device_log.deviceLOG_id = '" + id + "'";

                    conn.Edit(query, cont);
                }
                
            }
            else if(status == 2)
            {
                if (conn.checkStatus("out") == true)
                {
                    query = "INSERT INTO device_log(out_emp_id) ";
                    values = "VALUES((SELECT employee_id FROM employee WHERE username = '" + reference_to_main.current_user + "'))WHERE deviceLOG_id = '" + id + "'";
                    conn.Add(query, values);
                }
                else
                {
                    query = "UPDATE p_dao.device_log SET p_dao.device_log.dp_id = '" + dp + "', p_dao.device_log.device_id = '" + dev_id + "', p_dao.device_log.req_date = '" + req_date.ToString("yyyy-MM-dd") + "', p_dao.device_log.req_desc = '" + req_desc + "', p_dao.device_log.date_in = '" + date_IN.ToString("yyyy-MM-dd") + "', p_dao.device_log.date_out = '" + date_OUT.ToString("yyyy-MM-dd") + "', status = '" + fstatus + "',"
                        + " out_emp_id = (SELECT employee_id FROM employee WHERE username = '" + reference_to_main.current_user + "') WHERE device_log.deviceLOG_id = '" + id + "'";

                    conn.Edit(query, cont);
                }
            }
        }
        #endregion
    }
}
