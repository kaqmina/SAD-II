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
    public partial class project_add : Form
    {
        public project_add()
        {
            InitializeComponent();
        }
        system_functions sys_func = new system_functions();

        private void project_add_Load(object sender, EventArgs e)
        {
            load_time_format();
            load_date_min_max();
            load_default_enabled();
            btn_add_enable();
        }

        private void load_date_min_max()
        {

        }

        private void load_default_enabled()
        {

        }

        public void load_time_format()
        {

        }

        public void btn_add_enable()
        {
            sys_func.btn_inactive(btn_add_item);
            if (project_title.Text.Trim() == "" || project_venue.Text.Trim() == "")
            {
                sys_func.btn_inactive(btn_add_project);
            } else
            {
                sys_func.btn_active(btn_add_project);
            }
        }

        private void project_title_TextChanged(object sender, EventArgs e)
        {
            btn_add_enable();
        }

        private void project_desc_TextChanged(object sender, EventArgs e)
        {
            btn_add_enable();
        }

        private void project_venue_TextChanged(object sender, EventArgs e)
        {
            btn_add_enable();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_add_project_Click(object sender, EventArgs e)
        {

        }

        private void start_time_ValueChanged(object sender, EventArgs e)
        { 
        }

        private void start_date_ValueChanged(object sender, EventArgs e)
        {
            start_date_();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_cancel_Click(sender, e);
        }

        public void pnl_visible_false()
        {
            pnl_basic.Visible = false;
            pnl_budget_items.Visible = false;
            pnl_persons_involved.Visible = false;
        }

        private void btn_basic_Click(object sender, EventArgs e)
        {
            pnl_visible_false();
            pnl_basic.Visible = true;
        }

        private void btn_budget_items_Click(object sender, EventArgs e)
        {
            pnl_visible_false();
            pnl_budget_items.Visible = true;
        }

        private void btn_persons_Click(object sender, EventArgs e)
        {
            pnl_visible_false();
            pnl_persons_involved.Visible = true;
        }

        #region DATE-START_END

        public void end_date_()
        {

            int start_hour_ = int.Parse(start_time_hour.Value.ToString());
            int start_minutes_ = int.Parse(start_time_minute.Value.ToString());
            var start = start_date.Value.Date + new TimeSpan(start_hour_, start_minutes_, 0);
            
            var end = start;
            end = end.AddDays(int.Parse(lasts_for_day.Value.ToString()));
            end = end.AddHours(int.Parse(lasts_for_hour.Value.ToString()));
            end = end.AddMinutes(int.Parse(lasts_for_minute.Value.ToString()));

            lbl_end_date.Text = end.ToString();
            date_validity(start, end);
        }

        public void start_date_()
        {
            int start_hour_ = int.Parse(start_time_hour.Value.ToString());
            int start_minutes_ = int.Parse(start_time_minute.Value.ToString());
            var start = start_date.Value.Date + new TimeSpan(start_hour_, start_minutes_, 0);

            lbl_start_date.Text = start.ToString();
        }

        public void date_validity(DateTime start, DateTime end)
        {
            if (start == end)
            {
                lbl_date_error.Visible = true;
            } else
            {
                lbl_date_error.Visible = false;
            }
        }

        private void start_time_hour_ValueChanged(object sender, EventArgs e)
        {
            start_date_();
        }

        private void start_time_minute_ValueChanged(object sender, EventArgs e)
        {
            if (start_time_minute.Value == 60 && start_time_hour.Value == 23)
            {
                start_time_minute.Value = 50;
            } else if (start_time_minute.Value == 60)
            {
                start_time_hour.Value = start_time_hour.Value + 1;
                start_time_minute.Value = 0;
            }
            start_date_();
        }

        private void start_time_tt_SelectedItemChanged(object sender, EventArgs e)
        {
            start_date_();
        }

        private void start_time_tt_ValueChanged(object sender, EventArgs e)
        {
            start_date_();
        }

        private void lasts_for_day_ValueChanged(object sender, EventArgs e)
        {
            end_date_();
        }

        private void lasts_for_hour_ValueChanged(object sender, EventArgs e)
        {
            if (lasts_for_hour.Value == 24 )
            {
                lasts_for_hour.Value = 0;
                lasts_for_day.Value = lasts_for_day.Value + 1;
            }
            end_date_();
        }

        private void lasts_for_minute_ValueChanged(object sender, EventArgs e)
        {
            if(lasts_for_minute.Value == 60)
            {
                lasts_for_hour.Value = lasts_for_hour.Value + 1;
                lasts_for_minute.Value = 0;
            }
            end_date_();
        }
        #endregion

        private void btn_add_item_Click(object sender, EventArgs e)
        {
            string name = items_name.Text;
            string cost_before = items_cost_before.Value.ToString();
            string cost_after = items_cost_after.Value.ToString();
            string cost = cost_before.Trim() + "." + cost_after.Trim();
            string quantity = items_quantity.Value.ToString();
            string subtotal = lbl_subtotal.Text;
            int count = items_list.Rows.Count;
            bool duplicate = false;

            if (count == 0)
            {
                items_insert(name, cost, quantity, subtotal);
            } else
            {
                for (int i = 0; i < count; i++)
                {
                    if (items_list.Rows[i].Cells["name"].Value.Equals(name))
                    {
                        /*string temp = (items_list.Rows[i].Cells["quantity"].Value.ToString());
                        int actual = int.Parse(temp);
                        actual = int.Parse(temp) + int.Parse(quantity);
                        items_list.Rows[i].Cells["quantity"].Value = actual;

                        temp = (items_list.Rows[i].Cells["subtotal"].Value.ToString());
                        double new_subtotal = double.Parse(temp) + double.Parse(subtotal);
                        items_list.Rows[i].Cells["subtotal"].Value = new_subtotal;*/
                        duplicate = true;
                        MessageBox.Show("Item already added.", "Add Item");
                    }
                }
                if (duplicate == false)
                {
                    items_insert(name, cost, quantity, subtotal);
                }
            }
            calculate_items_total();
            clear_items_field();
        }

        public void items_insert(string name, string cost, string quantity, string subtotal)
        {
            var index = items_list.Rows.Add();
            items_list.Rows[index].Cells["name"].Value = name;
            items_list.Rows[index].Cells["cost"].Value = cost;
            items_list.Rows[index].Cells["quantity"].Value = quantity;
            items_list.Rows[index].Cells["subtotal"].Value = subtotal;
        }

        private void items_name_TextChanged(object sender, EventArgs e)
        {
            items_check_required();
        }

        private void items_cost_before_ValueChanged(object sender, EventArgs e)
        {
            items_check_required();
            calculate_items_subtotal();
        }

        private void items_quantity_ValueChanged(object sender, EventArgs e)
        {
            items_check_required();
            calculate_items_subtotal();
        }

        private void items_cost_after_ValueChanged(object sender, EventArgs e)
        {
            items_check_required();
            calculate_items_subtotal();
        }

        public bool items_check_required()
        {
            bool all_required = false;
            if (items_name.Text.Trim() == "" || items_quantity.Value <= 0)
            {
                all_required = false;
                sys_func.btn_inactive(btn_add_item);
            } else
            {
                all_required = true;
                sys_func.btn_active(btn_add_item);
            }
            return all_required;
        }

        public void calculate_items_subtotal()
        {
            string cost_before = items_cost_before.Value.ToString();
            string cost_after = items_cost_after.Value.ToString();
            string cost = cost_before + "." + cost_after;
            string quantity = items_quantity.Value.ToString();
            double total_cost = double.Parse(cost) * double.Parse(quantity);

            lbl_subtotal.Text = string.Format("{0:n}", total_cost);


        }

        public void calculate_items_total()
        {
            if (items_list.Rows.Count == 0)
            {

            } else
            {
                double subtotal = 0.0;
                for (int i = 0; i < items_list.Rows.Count; i++)
                {
                    subtotal = subtotal + double.Parse(items_list.Rows[i].Cells["subtotal"].Value.ToString());
                }
                lbl_items_total.Text = string.Format("{0:n}", subtotal);
            }
        }

        public void clear_items_field()
        {
            items_name.Text = "";
            items_cost_before.Value = 0;
            items_cost_after.Value = 0;
            items_quantity.Value = 1;
            lbl_subtotal.Text = "0.00";
            sys_func.btn_inactive(btn_add_item);
        }

        public void clear_items()
        {
            items_list.Rows.Clear();
        }

        private void btn_clear_all_Click(object sender, EventArgs e)
        {
            clear_items_field();
            clear_items();
        }

        private void btn_remove_item_Click(object sender, EventArgs e)
        {
            if (items_list.Rows.Count == 0)
            {

            }
            else
            {
                foreach (DataGridViewRow item in this.items_list.SelectedRows)
                {
                    items_list.Rows.RemoveAt(item.Index);
                }
                calculate_items_total();
            }
        }
    }
}
