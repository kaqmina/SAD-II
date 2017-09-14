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
            reset_values();

            conn_devi.get_disability_list(device_disability);

            startup_opacity.Start();
        }

        public void device_list_format()
        {
            device_list.Columns["device_id"].Visible = false;
            device_list.Columns["disability_id"].Visible = false;
            device_list.Columns["dev_desc"].Visible = false;
            device_list.Columns["disability_desc"].Visible = false;
            device_list.Columns["disability_id1"].Visible = false;
            device_list.Columns["isArchived"].Visible = false;

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
        Font def = new Font("Segoe UI", 8.25F);

        private void btn_add_Click(object sender, EventArgs e)
        {

            if (btn_add.Text == "NEW")
            {
                pnl_add.Visible = true;
                device_desc.Visible = true;
                lbl_provider.Visible = false;
            } else if (btn_add.Text == "ADD")
            {
                //do query
                pnl_add.Visible = false;
                device_desc.Visible = false;
                lbl_provider.Visible = true;
                reset_values();
            }

            if (btn_add.Text == "NEW")
            {
                btn_add.Text = "ADD";
                btn_edit.Text = "CANCEL";
                btn_add.Enabled = false;
                btn_edit.Enabled = true;
                btn_add.Font = new Font(def, FontStyle.Italic);
                btn_edit.Font = new Font(def, FontStyle.Regular);
            } else if (btn_add.Text == "ADD")
            {
                btn_add.Text = "NEW";
                btn_edit.Text = "EDIT";
                btn_add.Enabled = true;
                btn_edit.Enabled = false;
                btn_edit.Font = new Font(def, FontStyle.Italic);
                btn_add.Font = new Font(def, FontStyle.Regular);
            } else
            {
                //do query
            }

        }

        public void check_required()
        {
            if (device_name.Text.Trim() == "" || device_disability.SelectedIndex <= 0)
            {
                btn_add.Enabled = false;
                btn_add.Font = new Font(def, FontStyle.Italic);

            } else
            {
                btn_add.Enabled = true;
                btn_add.Font = new Font(def, FontStyle.Regular);
            }
        }

        private void device_name_TextChanged(object sender, EventArgs e)
        {
            check_required();
        }

        private void device_disability_SelectedIndexChanged(object sender, EventArgs e)
        {
            check_required();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (btn_edit.Text == "EDIT")
            {
                pnl_add.Visible = true;
                btn_add.Enabled = false;
                device_desc.Visible = true;
            } else if (btn_edit.Text == "CANCEL")
            {
                pnl_add.Visible = false;
                btn_add.Enabled = false;
                device_desc.Visible = false;
            }

            if (btn_edit.Text == "EDIT")
            {
                btn_edit.Text = "CANCEL";
                btn_add.Text = "SAVE";
                btn_edit.Enabled = true;
                btn_add.Enabled = false;
                btn_edit.Font = new Font(def, FontStyle.Regular);
                btn_add.Font = new Font(def, FontStyle.Italic);
            } else if (btn_edit.Text == "CANCEL")
            {
                device_name.Clear();
                device_disability.SelectedIndex = 0;
                device_desc.Clear();
                reset_values();
            }
        }

        public void reset_values()
        {
            lbl_device_name.Text = "--";
            lbl_device_disability.Text = "--";
            lbl_provider.Text = "--";

            lbl_device_name.Font = new Font(def, FontStyle.Regular);
            lbl_device_disability.Font = new Font(def, FontStyle.Regular);
            lbl_provider.Font = new Font(def, FontStyle.Regular);

            lbl_device_name.ForeColor = Color.Gray;
            lbl_device_disability.ForeColor = Color.Gray;
            lbl_provider.ForeColor = Color.Gray;
            btn_add.Enabled = true;
            btn_edit.Enabled = false;
        }
    }
}
