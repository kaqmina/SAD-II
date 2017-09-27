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
    public partial class disability : Form
    {
        public disability()
        {
            InitializeComponent();
        }
        public main_form reference_to_main { get; set; }
        connections_disability conn_disa = new connections_disability();
        system_functions sys_func = new system_functions();
        bool has_disability_data = false;
        bool has_duplicate_edit = false;
        bool has_duplicate_add = false;
        string current_disability_name = "";
        int current_index = 0;

        #region LOAD-REFRESH-RESET
        private void disability_Load(object sender, EventArgs e)
        {
            load_disability_data();
            this.Opacity = 0;

            startup_opacity.Start();
            reset_view();
        }

        public void load_disability_data()
        {
            has_disability_data = conn_disa.get_disability_data(disability_list);
            format_disability_list();
            count_results.Text = conn_disa.count_rows_disability();
        }

        public void reset_view()
        {
            lbl_disability_name.Text = "--";
            lbl_desc.Text = "--";

            sys_func.lbl_reset(lbl_disability_name);
            sys_func.lbl_reset(lbl_desc);

            pnl_edit.Visible = false;
            sys_func.btn_inactive(btn_edit);
            btn_edit.Text = "EDIT";
            btn_cancel.Visible = false;
            btn_archive.Visible = false;
            btn_edit.Enabled = false;

            lbl_error_edit.Visible = false;
        }

        public void reset_edit_values()
        {
            disability_name_edit.Clear();
            disability_desc_edit.Clear();
        }

        public void reset_add_values()
        {
            disability_name_add.Clear();
            disability_desc_add.Clear();
            btn_add.Enabled = false;
            btn_clear.Enabled = true;

            btn_add.Visible = true;
            btn_clear.Visible = true;

            btn_add.Text = "ADD";
            btn_clear.Text = "CLEAR";

            sys_func.btn_inactive(btn_add);
            sys_func.btn_active(btn_clear);
        }

        #endregion

        #region FORMAT

        public void format_disability_list()
        {
            disability_list.Columns["disability_id"].Visible = false;
            disability_list.Columns["disability_desc"].Visible = false;

            disability_list.Columns["disability_type"].HeaderText = "Name";
            disability_list.Columns["result"].HeaderText = "Total no.";
        }

        #endregion

        #region SELECTION-CELL_CLICK

        private void disability_list_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (has_disability_data == false)
            {
                reset_view();
            }
            else
            {
                current_disability_name = "";
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
                }
            }
        }

        private void disability_list_SelectionChanged(object sender, EventArgs e)
        {
            if (has_disability_data == false)
            {
                //do nothing
            }
            else
            {
                current_index = disability_list.CurrentCell.RowIndex;
                provider_selection();
            }
        }

        public void provider_selection()
        {
            current_disability_name = disability_list.Rows[current_index].Cells["disability_type"].Value.ToString();
            lbl_disability_name.Text = disability_list.Rows[current_index].Cells["disability_type"].Value.ToString();
            lbl_desc.Text = disability_list.Rows[current_index].Cells["disability_desc"].Value.ToString();

            sys_func.lbl_has_value(lbl_disability_name);
            sys_func.lbl_has_value(lbl_desc);
            sys_func.btn_active(btn_edit);

            disability_name_edit.Text = disability_list.Rows[current_index].Cells["disability_type"].Value.ToString();
            disability_desc_edit.Text = disability_list.Rows[current_index].Cells["disability_desc"].Value.ToString();

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

        #region ADD-MODE

        private void btn_add_Click(object sender, EventArgs e)
        {
            bool success = false;
            success = conn_disa.disability_add(disability_name_add.Text, disability_desc_add.Text);
            if (success == true)
                reference_to_main.notification_ = "Successfully Added!";
            else
                reference_to_main.notification_ = "Add unsuccessfull!";
            reference_to_main.show_success_message();

            reset_add_values();
            load_disability_data();
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
                string current_id = disability_list.Rows[current_index].Cells["disability_id"].Value.ToString();
                success = conn_disa.disability_update(current_id, disability_name_edit.Text, disability_desc_edit.Text);
                if (success)
                    reference_to_main.notification_ = "Successfully Updated!";
                else
                    reference_to_main.notification_ = "Update unsuccessfull!";
                reference_to_main.show_success_message();

                load_disability_data();
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

        #region CHECK-REQUIRED

        #region ----> Methods
        public void check_required_edit(string current_text)
        {
            has_duplicate_edit = conn_disa.disability_check_duplicate(current_text, current_disability_name);
            if (has_duplicate_edit == true || disability_name_edit.Text.Trim() == "")
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
            has_duplicate_add = conn_disa.disability_check_duplicate(current_text, "-");
            if (has_duplicate_add == true || disability_name_add.Text.Trim() == "")
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

        private void disability_name_edit_TextChanged(object sender, EventArgs e)
        {
            check_required_edit(disability_name_edit.Text);
        }

        private void disability_name_add_TextChanged(object sender, EventArgs e)
        {
            check_required_add(disability_name_add.Text);
        }

        #endregion

        #endregion

        #region ARCHIVE-MODE
        private void btn_archive_Click(object sender, EventArgs e)
        {
            DialogResult ask;
            string current_data = disability_list.Rows[current_index].Cells["disability_type"].Value.ToString();
            string message = "Are you sure you want to archive '" + current_data + "'?";
            string caption = "Archive Disability Details";
            MessageBoxButtons btn = MessageBoxButtons.YesNo;
            ask = MessageBox.Show(message, caption, btn);

            bool success = false;
            if (ask == System.Windows.Forms.DialogResult.Yes)
            {
                success = conn_disa.disability_archive(disability_list.Rows[current_index].Cells["disability_id"].Value.ToString());
                if (success)
                    reference_to_main.notification_ = "Successfully Archived: " + current_data;
                else
                    reference_to_main.notification_ = "Archive unsuccessfull!";
                reference_to_main.show_success_message();
                load_disability_data();
                reset_edit_values();
                reset_view();
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

        private void btn_close_Click(object sender, EventArgs e)
        {
            exit_opacity.Start();
        }

        #endregion

        private void btn_pwd_refresh_Click(object sender, EventArgs e)
        {
            load_disability_data();
        }
    }
}
