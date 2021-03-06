﻿using System;
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
        connections_disability conn_disa = new connections_disability();
        system_functions sys_func = new system_functions();
        bool has_device_data = false;
        bool has_duplicate_edit = false;
        bool has_duplicate_add = false;
        string device_current_name = "";
        int current_index = 0;

        #region LOAD-REFRESH-RESET

        #region ----> LOAD
        private void device_device_add_Load(object sender, EventArgs e)
        {
            load_cboxes();
            refresh_device_grid();
            device_list_format();
            reset_values_edit();
            reset_values_add();
            reset_view();

            startup_opacity.Start();
        }

        public void load_cboxes()
        {
            conn_devi.get_disability_list(device_disability_edit);
            conn_devi.get_disability_list(device_disability_add);
        }
        #endregion

        #region ----> REFRESH-RESET

        public void refresh_device_grid()
        {
            has_device_data = conn_devi.get_device_list(device_list);
            string results = conn_devi.count_rows();
            count_results.Text = results;
            device_list.ClearSelection();
        }

        public void reset_values_edit()
        {
            btn_edit.Visible = true;
            btn_edit_cancel.Visible = false;

            btn_edit.Text = "EDIT";
            btn_edit_cancel.Text = "CANCEL";

            sys_func.btn_inactive(btn_edit);
            sys_func.btn_active(btn_edit_cancel);

            device_name_edit.Clear();
            device_disability_edit.SelectedIndex = 0;
            device_desc_edit.Clear();

            pnl_edit.Visible = false;
            device_desc_edit.Visible = false;

            btn_edit.Enabled = false;
            btn_edit_cancel.Enabled = true;
        }

        public void reset_values_add()
        {
            btn_add.Enabled = false;
            btn_add_clear.Enabled = true;

            btn_add.Visible = true;
            btn_add_clear.Visible = true;

            btn_add.Text = "ADD";
            btn_add_clear.Text = "CLEAR";

            sys_func.btn_inactive(btn_add);
            sys_func.btn_active(btn_add_clear);

            device_name_add.Clear();
            device_disability_add.SelectedIndex = 0;
            device_desc_add.Clear();
        }

        public void reset_view()
        {
            btn_archive.Visible = false;
            lbl_device_name.Text = "--";
            lbl_device_disability.Text = "--";
            lbl_provider.Text = "--";

            sys_func.lbl_reset(lbl_device_name);
            sys_func.lbl_reset(lbl_device_disability);
            sys_func.lbl_reset(lbl_provider);
        }

        #endregion

        #endregion

        #region FORMATS-DEFAULTS

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

        #endregion

        #region CHECK-REQUIRED - TextChanged/SelectedIndexChanged

        #region ----> Methods

        public void check_required_edit(string current_text)
        {
            has_duplicate_edit = conn_devi.device_check_duplicate(current_text, device_current_name);
            if (has_duplicate_edit == true || device_name_edit.Text.Trim() == "" || device_disability_edit.SelectedIndex <= 0)
            {
                btn_edit.Enabled = false;
                sys_func.btn_inactive(btn_edit);
            }
            else
            {
                btn_edit.Enabled = true;
                sys_func.btn_active(btn_edit);
            }

            if (has_duplicate_edit)
                lbl_error_edit.Visible = true;
            else
                lbl_error_edit.Visible = false;
        }

        public void check_required_add(string current_text)
        {
            has_duplicate_add = conn_devi.device_check_duplicate(current_text, "-");
            if (has_duplicate_add == true || device_name_add.Text.Trim() == "" || device_disability_add.SelectedIndex <= 0)
            {
                btn_add.Enabled = false;
                sys_func.btn_inactive(btn_add);
            }
            else
            {
                btn_add.Enabled = true;
                sys_func.btn_active(btn_add);
            }

            if (has_duplicate_add)
                lbl_error_add.Visible = true;
            else
                lbl_error_add.Visible = false;
        }
        #endregion

        #region ----> References

        private void device_name_edit_TextChanged(object sender, EventArgs e)
        {
            check_required_edit(device_name_edit.Text);
        }

        private void device_disability_edit_SelectedIndexChanged(object sender, EventArgs e)
        {
            check_required_edit(device_name_edit.Text);
        }

        private void device_name_add_TextChanged(object sender, EventArgs e)
        {
            check_required_add(device_name_add.Text);
        }

        private void device_disability_add_SelectedIndexChanged(object sender, EventArgs e)
        {
            check_required_add(device_name_add.Text);
        }

        #endregion

        #endregion

        #region SELECTION-CHANGED [DATAGRID_VIEW]

        private void device_list_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (has_device_data == false)
            {
                //nothing
            }
            else
            {
                device_current_name = "";
                if (e.RowIndex >= 0)
                {
                    current_index = e.RowIndex;
                    device_list_selection();
                }
                else
                {
                    current_index = 0;
                    if (btn_edit.Text == "SAVE")
                    {
                        device_name_edit.Clear();
                        device_desc_edit.Clear();
                        device_disability_edit.SelectedIndex = 0;
                    }
                    btn_edit.Enabled = false;
                    sys_func.btn_inactive(btn_edit);
                    reset_view();
                    device_list.ClearSelection();
                    Console.WriteLine("[CONNECTION_DEVICES] > CLEAR SELECTION DEVICE LIST");
                }
            }

        }

        private void device_list_SelectionChanged(object sender, EventArgs e)
        {
            if (has_device_data == false)
            {
                //do nothing
            }
            else
            {
                current_index = device_list.CurrentCell.RowIndex;
                device_list_selection();
            }
        }

        public void device_list_selection()
        {

            device_current_name = device_list.Rows[current_index].Cells["dev_name"].Value.ToString();
            lbl_device_name.Text = device_list.Rows[current_index].Cells["dev_name"].Value.ToString();
            lbl_device_disability.Text = device_list.Rows[current_index].Cells["disability_type"].Value.ToString();
            lbl_provider.Text = device_list.Rows[current_index].Cells["dev_desc"].Value.ToString();

            sys_func.lbl_has_value(lbl_device_name);
            sys_func.lbl_has_value(lbl_device_disability);
            sys_func.lbl_has_value(lbl_provider);
            sys_func.btn_active(btn_edit);

            device_name_edit.Text = device_list.Rows[current_index].Cells["dev_name"].Value.ToString();
            device_disability_edit.SelectedIndex = int.Parse(device_list.Rows[current_index].Cells["disability_id"].Value.ToString());
            device_desc_edit.Text = device_list.Rows[current_index].Cells["dev_desc"].Value.ToString();

            if (btn_edit.Text == "EDIT")
            {
                btn_edit.Enabled = true;
                btn_archive.Visible = true;
            }
            else
            {
                btn_archive.Visible = false;
            }
        }

        #endregion

        #region EDIT-MODE

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (btn_edit.Text == "EDIT")
            {
                pnl_edit.Visible = true;
                device_desc_edit.Visible = true;
                btn_edit_cancel.Visible = true;

                btn_edit.Text = "SAVE";
            }
            else
            {
                pnl_edit.Visible = false;
                device_desc_edit.Visible = false;
                string current_id = device_list.Rows[current_index].Cells["device_id"].Value.ToString();
                string disability_id = conn_disa.get_disability_by_name(device_disability_edit.Text);
                conn_devi.device_update(device_name_edit.Text, device_desc_edit.Text, disability_id, current_id);
                reference_to_main.device_requests_btn_refresh();
                refresh_device_grid();
                reset_values_edit();
                reset_view();
            }
        }

        private void btn_edit_cancel_Click(object sender, EventArgs e)
        {
            reset_values_edit();
            reset_view();
        }

        #endregion

        #region ADD-MODE

        private void btn_add_Click(object sender, EventArgs e)
        {
            string disability_id = conn_disa.get_disability_by_name(device_disability_add.Text);
            conn_devi.device_add(device_name_add.Text, device_desc_add.Text, disability_id);
            reference_to_main.device_requests_btn_refresh();
            reset_values_add();
            refresh_device_grid();
            device_list.Rows[device_list.CurrentCell.RowIndex].Selected = false;
        }

        private void btn_add_clear_Click(object sender, EventArgs e)
        {
            device_name_add.Clear();
            device_disability_add.SelectedIndex = 0;
            device_desc_add.Clear();
        }

        #endregion

        #region ARCHIVE-MODE

        private void btn_archive_Click(object sender, EventArgs e)
        {
            DialogResult ask;
            string message = "Are you sure you want to archive '" + device_list.Rows[current_index].Cells["dev_name"].Value.ToString() + "'?";
            string caption = "Archive Device Details";
            MessageBoxButtons btn = MessageBoxButtons.YesNo;
            ask = MessageBox.Show(message, caption, btn);

            if (ask == System.Windows.Forms.DialogResult.Yes)
            {
                string device_id = device_list.Rows[current_index].Cells["device_id"].Value.ToString();
                bool check_connections = conn_devi.device_has_data(device_id);
                if (check_connections == true )
                {
                    MessageBox.Show("Cannot archive device because there are connections to other tables.", caption, MessageBoxButtons.OK);
                } else
                {
                    conn_devi.device_archive(device_id);
                    refresh_device_grid();
                    reset_values_edit();
                    reset_view();
                }
            }
            else
            {
                //nothing
            }
        }

        #endregion

        #region FORM-DEFAULTS-TRANSITIONS

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

        #endregion

    }
}
