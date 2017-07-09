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
            getDevice();
            getProvider();
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
            MySqlCommand com = new MySqlCommand("SELECT dev_name FROM device", con);
            MySqlDataReader dr;

            try
            {
                con.Open();
                dr = com.ExecuteReader();

                while (dr.Read())
                {
                    string device = dr.GetString("dev_name");
                    cmbox_dev.Items.Add(device);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in getDevice() : " + ex);
                con.Close();
            }
        }
        private void getProvider()
        {
            MySqlCommand com = new MySqlCommand("SELECT dp_name FROM device_provider", con);  // JOIN device_log ON device_provider.dp_id = device_log.dp_id", con);
            MySqlDataReader dr;

            try
            {
                con.Open();
                dr = com.ExecuteReader();

                while (dr.Read())
                {
                    string provider = dr.GetString("dp_name");
                    cmbox_dev.Items.Add(provider);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in getProvider() : " + ex);
                con.Close();
            }
        }
#endregion

        #region Declaration

        public main_form reference_to_main { get; set; }
        public MySqlConnection con;

        String dr_dev, dr_prov;
        int dev, prov;

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
