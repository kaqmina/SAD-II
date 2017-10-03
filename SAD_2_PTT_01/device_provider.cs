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
    public partial class device_provider : Form
    {
        public device_provider()
        {
            InitializeComponent();
        }
        public main_form reference_to_main { get; set; }
        connections_devices conn_devi = new connections_devices();
        system_functions sys_func = new system_functions();
        bool has_provider_data = false;
        bool has_provided_devices = false;
        bool has_duplicate_edit = false;
        bool has_duplicate_add = false;
        string current_provider_name = "";
        int current_index = 0;

        #region LOAD-REFRESH-RESET

        private void device_provider_Load(object sender, EventArgs e)
        {
            this.Location = new Point(reference_to_main.Location.X + 71, reference_to_main.Location.Y + 28);
            this.Opacity = 0;
            startup_opacity.Start();
            //load
            load_provider_list();

            //reset
            reset_view();
        }

        public void load_provider_list()
        {
            has_provider_data = conn_devi.get_provider_list(provider_list);
            Console.WriteLine("has_provider_data : " + has_provider_data);
            provider_list_format();
            count_results.Text = conn_devi.count_rows_provider();
            Console.WriteLine("count : " + count_results.Text);
            if (has_provider_data == false)
            {
                provider_list.DefaultCellStyle.SelectionForeColor = Color.Gray;
                provider_list.DefaultCellStyle.SelectionBackColor = Color.White;
            }
            else
            {
                provider_list.DefaultCellStyle.SelectionForeColor = Color.FromArgb(41, 45, 56);
                provider_list.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 224, 224);
            }
        }

        public void reset_view()
        {
            pnl_edit.Visible = false;
            device_provided_list.DataSource = null;
            lbl_provider_name.Text = "--";
            lbl_provider_address.Text = "--";
            lbl_provider_mobile.Text = "--";
            lbl_provider_tel.Text = "--";
            lbl_provider_type.Text = "--";
            lbl_provider_email.Text = "--";

            sys_func.lbl_reset(lbl_provider_name);
            sys_func.lbl_reset(lbl_provider_address);
            sys_func.lbl_reset(lbl_provider_mobile);
            sys_func.lbl_reset(lbl_provider_tel);
            sys_func.lbl_reset(lbl_provider_type);
            sys_func.lbl_reset(lbl_provider_email);

            sys_func.btn_inactive(btn_edit);
            btn_edit.Text = "EDIT";
            btn_cancel.Visible = false;
            btn_archive.Visible = false;
            btn_edit.Enabled = false;

            lbl_error_edit.Visible = false;
        }

        public void reset_edit_values()
        {
            provider_name_edit.Clear();
            provider_address_edit.Clear();
            provider_type_edit.SelectedIndex = 0;
            provider_mobile_no_edit.Clear();
            provider_tel_no_edit.Clear();
            provider_email_edit.Clear();
        }

        public void reset_add_values()
        {
            btn_add.Enabled = false;
            btn_clear.Enabled = true;

            btn_add.Visible = true;
            btn_clear.Visible = true;

            btn_add.Text = "ADD";
            btn_clear.Text = "CLEAR";

            sys_func.btn_inactive(btn_add);
            sys_func.btn_active(btn_clear);

            provider_name_add.Clear();
            provider_address_add.Clear();
            provider_type_add.SelectedIndex = 0;
            provider_mobile_no_add.Clear();
            provider_tel_no_add.Clear();
            provider_email_add.Clear();
        }

        #endregion

        #region FORMAT

        public void provider_list_format()
        {
            provider_list.Columns["dp_id"].Visible = false;
            provider_list.Columns["dp_address"].Visible = false;
            provider_list.Columns["mobile_no"].Visible = false;
            provider_list.Columns["tel_no"].Visible = false;
            provider_list.Columns["email_add"].Visible = false;
            provider_list.Columns["dp_type_id"].Visible = false;

            provider_list.Columns["dp_name"].HeaderText = "Name";
            provider_list.Columns["dp_type_name"].HeaderText = "Type";
            provider_list.Columns["result"].HeaderText = "Total no.";

            provider_list.Columns["dp_name"].Width = 185;
            provider_list.Columns["dp_type_name"].Width = 70;
            provider_list.Columns["result"].Width = 60;
        }

        #endregion

        #region SELECTION-CELL_CLICK

        public void provider_selection()
        {
            current_provider_name = provider_list.Rows[current_index].Cells["dp_name"].Value.ToString();
            lbl_provider_name.Text = provider_list.Rows[current_index].Cells["dp_name"].Value.ToString();
            lbl_provider_address.Text = provider_list.Rows[current_index].Cells["dp_address"].Value.ToString();
            lbl_provider_type.Text = provider_list.Rows[current_index].Cells["dp_type_name"].Value.ToString();
            lbl_provider_mobile.Text = provider_list.Rows[current_index].Cells["mobile_no"].Value.ToString();
            lbl_provider_tel.Text = provider_list.Rows[current_index].Cells["tel_no"].Value.ToString();
            lbl_provider_email.Text = provider_list.Rows[current_index].Cells["email_add"].Value.ToString();

            sys_func.lbl_has_value(lbl_provider_name);
            sys_func.lbl_has_value(lbl_provider_address);
            sys_func.lbl_has_value(lbl_provider_type);
            sys_func.lbl_has_value(lbl_provider_mobile);
            sys_func.lbl_has_value(lbl_provider_tel);
            sys_func.lbl_has_value(lbl_provider_email);
            sys_func.btn_active(btn_edit);

            provider_name_edit.Text = provider_list.Rows[current_index].Cells["dp_name"].Value.ToString();
            provider_address_edit.Text = provider_list.Rows[current_index].Cells["dp_address"].Value.ToString();
            provider_type_edit.SelectedIndex = int.Parse(provider_list.Rows[current_index].Cells["dp_type_id"].Value.ToString()) + 1;
            provider_mobile_no_edit.Text = provider_list.Rows[current_index].Cells["mobile_no"].Value.ToString();
            provider_tel_no_edit.Text = provider_list.Rows[current_index].Cells["tel_no"].Value.ToString();
            provider_email_edit.Text = provider_list.Rows[current_index].Cells["email_add"].Value.ToString();

            string current_provider_id = provider_list.Rows[current_index].Cells["dp_id"].Value.ToString();

            has_provided_devices = conn_devi.provider_devices_provided(device_provided_list, current_provider_id);
            device_provided_list.Columns["dev_name"].HeaderText = "Device Name";
            device_provided_list.Columns["result"].HeaderText = "Total no.";

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

        private void provider_list_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (has_provider_data == false)
            {
                reset_view();
            }
            else
            {
                current_provider_name = "";
                if (e.RowIndex >= 0)
                {
                    current_index = e.RowIndex;
                    provider_selection();
                }
                else
                {
                    current_index = 0;
                    if (btn_edit.Text == "SAVE")
                    {
                        reset_edit_values();
                    }
                    btn_edit.Enabled = false;
                    sys_func.btn_inactive(btn_edit);
                    reset_view();
                    provider_list.ClearSelection();
                    Console.WriteLine("[CONNECTION_DEVICES] > CLEAR SELECTION DEVICE LIST");
                }
            }
        }

        private void provider_list_SelectionChanged(object sender, EventArgs e)
        {
            if (has_provider_data == false)
            {
                //do nothing
            }
            else
            {
                current_index = provider_list.CurrentCell.RowIndex;
                provider_selection();
            }
        }

        #endregion

        #region CHECK-REQUIRED-TEXT_INDEX_CHANGED

        #region ----> Methods
        public void check_required_edit(string current_text)
        {
            has_duplicate_edit = conn_devi.provider_check_duplicate(current_text, current_provider_name);
            if (has_duplicate_edit == true || provider_name_edit.Text.Trim() == "" || provider_type_edit.SelectedIndex <= 0 || provider_address_edit.Text.Trim() == "")
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
            has_duplicate_add = conn_devi.provider_check_duplicate(current_text, "-");
            if (has_duplicate_add == true || provider_name_add.Text.Trim() == "" || provider_type_add.SelectedIndex <= 0 || provider_address_add.Text.Trim() == "")
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

        private void provider_name_add_TextChanged(object sender, EventArgs e)
        {
            check_required_add(provider_name_add.Text);
        }

        private void provider_address_add_TextChanged(object sender, EventArgs e)
        {
            check_required_add(provider_name_add.Text);
        }

        private void provider_type_add_SelectedIndexChanged(object sender, EventArgs e)
        {
            check_required_add(provider_name_add.Text);
        }

        private void provider_name_edit_TextChanged(object sender, EventArgs e)
        {
            check_required_edit(provider_name_edit.Text);
        }

        private void provider_address_edit_TextChanged(object sender, EventArgs e)
        {
            check_required_edit(provider_name_edit.Text);
        }

        private void provider_type_edit_SelectedIndexChanged(object sender, EventArgs e)
        {
            check_required_edit(provider_name_edit.Text);
        }

        #endregion

        #endregion

        #region ADD-MODE

        private void btn_add_Click(object sender, EventArgs e)
        {
            bool success = false;
            success = conn_devi.provider_add(provider_name_add.Text, provider_address_add.Text, provider_type_add.SelectedIndex - 1, provider_mobile_no_add.Text, provider_tel_no_add.Text, provider_email_add.Text);
            if (success)
            {
                reference_to_main.notification_ = "Successfully Added!";
                reference_to_main.device_requests_btn_refresh();
            }
            else
            {
                reference_to_main.notification_ = "Add unsuccessfull!";
            }
            reference_to_main.show_success_message();

            reset_add_values();
            load_provider_list();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            reset_add_values();
        }

        #endregion

        #region EDIT-MODE

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (btn_edit.Text == "EDIT")
            {
                pnl_edit.Visible = true;
                btn_cancel.Visible = true;

                btn_edit.Text = "SAVE";
            }
            else
            {
                bool success = false;
                pnl_edit.Visible = false;
                string current_id = provider_list.Rows[current_index].Cells["dp_id"].Value.ToString();
                success = conn_devi.provider_update(provider_name_edit.Text, provider_address_edit.Text, provider_type_edit.SelectedIndex - 1, provider_mobile_no_edit.Text, provider_tel_no_edit.Text, provider_email_edit.Text, current_id);
                if (success)
                {
                    reference_to_main.notification_ = "Successfully Updated!";
                    reference_to_main.device_requests_btn_refresh();
                }
                else
                {
                    reference_to_main.notification_ = "Update unsuccessfull!";
                }
                reference_to_main.show_success_message();
                load_provider_list();
                reset_edit_values();
                reset_view();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            reset_edit_values();
            reset_view();
        }

        #endregion

        #region ARCHIVE-MODE

        private void btn_archive_Click(object sender, EventArgs e)
        {
            DialogResult ask;
            string current_data = provider_list.Rows[current_index].Cells["dp_name"].Value.ToString();
            string message = "Are you sure you want to archive '" + current_data + "'?";
            string caption = "Archive Sponsor Details";
            MessageBoxButtons btn = MessageBoxButtons.YesNo;
            ask = MessageBox.Show(message, caption, btn);

            bool success = false;
            if (ask == System.Windows.Forms.DialogResult.Yes)
            {
                int count = int.Parse(provider_list.Rows[current_index].Cells["result"].Value.ToString());
                if (count > 0)
                {
                    MessageBox.Show("Cannot archive provider because there are connections to other tables.", caption, MessageBoxButtons.OK);
                } else
                {
                    success = conn_devi.provider_archive(provider_list.Rows[current_index].Cells["dp_id"].Value.ToString());
                    if (success)
                        reference_to_main.notification_ = "Successfully Archived: " + current_data;
                    else
                        reference_to_main.notification_ = "Archived unsuccessfull!";
                    reference_to_main.show_success_message();
                    load_provider_list();
                    reset_edit_values();
                    reset_view();
                }
            }
            else
            {
                //nothing
            }
        }

        #endregion

        #region SYSTEM-DEFAULTS

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

        private void btn_exit_Click(object sender, EventArgs e)
        {
            exit_opacity.Start();
        }

        #endregion

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            load_provider_list();
        }
    }
}
