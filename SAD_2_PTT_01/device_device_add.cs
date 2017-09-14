using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAD_2_PTT_01
{
    public partial class device_device_add : Form
    {
        public device_device_add()
        {
            InitializeComponent();
        }
        public main_form reference_to_main { get; set; }
        connections_devices conn_devi = new connections_devices();

        private void device_device_add_Load(object sender, EventArgs e)
        {
            conn_devi.get_device_list(device_list);
            device_list_format();
            startup_opacity.Start();
        }

        public void device_list_format()
        {
            device_list.Columns["device_id"].Visible = false;
            device_list.Columns["disability_id"].Visible = false;
            device_list.Columns["dev_desc"].Visible = false;
            device_list.Columns["disability_desc"].Visible = false;
            device_list.Columns["disability_id1"].Visible = false;

            device_list.Columns["dev_name"].HeaderText = "Device";
            device_list.Columns["disability_type"].HeaderText = "Disability";
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            exit_opacity.Start();
        }

        private void startup_opacity_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
                this.Opacity += 0.1;
            else
                startup_opacity.Stop();
        }

        private void exit_opacity_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                this.Opacity -= 0.1;
            }
            else
            {
                exit_opacity.Stop();
                this.Close();
            }
        }


    }
}
