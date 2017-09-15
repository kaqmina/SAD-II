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
            refresh_device_grid();
            device_list_format();
            reset_values();

            conn_devi.get_disability_list(device_disability);

            startup_opacity.Start();
        }

        public void refresh_device_grid()
        {
            conn_devi.get_device_list(device_list);
        }

        public void device_list_format()
        {
            device_list.Columns["device_id"].Visible = false;
            device_list.Columns["disability_id"].Visible = false;
            device_list.Columns["dev_desc"].Visible = false;
            device_list.Columns["disability_desc"].Visible = false;
            device_list.Columns["disability_id1"].Visible = false;
            device_list.Columns["isArchived"].Visible = false;
            device_list.Columns["isArchived1"].Visible = false;

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
                conn_devi.device_add(device_name.Text, device_desc.Text, device_disability.SelectedIndex);
                pnl_add.Visible = false;
                device_desc.Visible = false;
                lbl_provider.Visible = true;
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
                reset_values();
            } else
            {
                //do query SAVE
            }

        }

        public void check_required()
        {
            if ((device_name.Text.Trim() == "" || device_disability.SelectedIndex <= 0) && btn_add.Text == "ADD")
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
                lbl_provider.Visible = false;
            } else if (btn_edit.Text == "CANCEL")
            {
                pnl_add.Visible = false;
                btn_add.Enabled = false;
                device_desc.Visible = false;
                lbl_provider.Visible = true;
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
                reset_values();
            }
        }

        public void reset_values()
        {
            reset_view();

            btn_add.Enabled = true;
            btn_edit.Enabled = false;
            btn_add.Text = "NEW";
            btn_edit.Text = "EDIT";
            btn_add.Font = new Font(def, FontStyle.Regular);
            btn_edit.Font = new Font(def, FontStyle.Italic);

            device_name.Clear();
            device_disability.SelectedIndex = 0;
            device_desc.Clear();

            refresh_device_grid();
        }

        public void reset_view()
        {

            lbl_device_name.Text = "--";
            lbl_device_disability.Text = "--";
            lbl_provider.Text = "rter";

            lbl_device_name.Font = new Font(def, FontStyle.Regular);
            lbl_device_disability.Font = new Font(def, FontStyle.Regular);
            lbl_provider.Font = new Font(def, FontStyle.Regular);

            lbl_device_name.ForeColor = Color.Gray;
            lbl_device_disability.ForeColor = Color.Gray;
            lbl_provider.ForeColor = Color.Gray;

        }

        private void device_list_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                lbl_device_name.Text = device_list.Rows[e.RowIndex].Cells["dev_name"].Value.ToString();
                lbl_device_disability.Text = device_list.Rows[e.RowIndex].Cells["disability_type"].Value.ToString();
                lbl_provider.Text = device_list.Rows[e.RowIndex].Cells["dev_desc"].Value.ToString();

                lbl_device_name.ForeColor = Color.Black;
                lbl_device_disability.ForeColor = Color.Black;
                lbl_provider.ForeColor = Color.Black;
                btn_edit.Enabled = true;
            } else
            {
                btn_edit.Enabled = false;
                reset_view();
                device_list.ClearSelection();
                Console.WriteLine("[CONNECTION_DEVICES] > CLEAR SELECTION DEVICE LIST");
            }
        }
    }
}
