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
        connections_user conn_user = new connections_user();
        connections_project conn_proj = new connections_project();
        public main_form reference_to_main { get; set; }
        public string update_id = "0";

        private void project_add_Load(object sender, EventArgs e)
        {
            btn_add_enable();
            this.Opacity = 0;
            startup_opacity.Start();

            sys_func.btn_inactive(btn_persons);
            start_date.MinDate = date_proposed.Value;
            btn_add_project.Text = "ADD PROJECT";
        }

        public void btn_add_enable()
        {
            sys_func.btn_inactive(btn_add_item);
            if (project_title.Text.Trim() == "" || project_venue.Text.Trim() == "" || 
                lbl_start_date.Text == "--" || lbl_end_date.Text == "--" 
                || lbl_date_error.Visible == true )
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
        public string id_;

        private void btn_add_project_Click(object sender, EventArgs e)
        {
            if (btn_add_project.Text == "ADD PROJECT")
            {
                string current_user_id = conn_user.get_user_id_by_name(reference_to_main.current_user);
                string title = project_title.Text;
                string desc = project_desc.Text;
                DateTime time = new DateTime();
                time = Convert.ToDateTime(lbl_start_date.Text);
                string start_time = time.ToString("yyyy-MM-dd HH:mm:ss");
                time = Convert.ToDateTime(lbl_end_date.Text);
                string end_time = time.ToString("yyyy-MM-dd HH:mm:ss");
                string date_proposed_ = date_proposed.Value.ToString("yyyy-MM-dd HH:mm:ss");
                string venue = project_venue.Text;
                string budget = lbl_items_total.Text;
                string fields = "INSERT INTO project(employee_id, project_title, project_desc, start_time, end_time, date_proposed, event_held, budget) VALUES ";
                string values = "(" + current_user_id + ", '" + title + "' , '" + desc + "', '" + start_time + "', '" + end_time + "', '" + date_proposed_ + "', '" + venue + "', " + budget + ")";
                string query = fields + values;

                bool try_ = conn_proj.project_add_data(query);
                bool items_ = false;
                bool progress_ = false;
                if (try_ == true)
                {
                    id_ = conn_proj.get_latest_project_id();
                    if (items_list.Rows.Count > 0)
                    {
                        items_ = items_add();
                    }
                    else
                    {
                        items_ = true;
                    }
                    progress_ = conn_proj.project_add_progress("INSERT INTO project_progress(project_id, progress_type, date_changed) VALUES (" + id_ + ", 1, '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')");

                    if (progress_ == true)
                    {
                        conn_proj.project_progress_update(id_);
                    }
                }
                else
                {

                }
                if (progress_ == false || items_ == false || try_ == false)
                {
                    reference_to_main.notification_ = "Project Unsuccessfully Added.";
                    reference_to_main.show_success_message();
                    sys_func.btn_inactive(btn_persons);
                    btn_persons.Location = new Point(-8, 99);
                    btn_view_info.Visible = false;
                }
                else
                {
                    reference_to_main.notification_ = "Project Successfully Added.";
                    reference_to_main.show_success_message();
                    btn_add_project.Text = "FINISH";
                    sys_func.btn_active(btn_persons);
                    btn_persons.Location = new Point(-8, 69);
                    btn_view_info.Visible = true;
                    view_paste();
                }
            } else
            {
                //do something
            }
            
        }


        public void view_paste()
        {
            DataTable project = new DataTable();
            conn_proj.projects_data(project, id_);

            view_title.Text = project.Rows[0]["project_title"].ToString();
            view_desc.Text = project.Rows[0]["project_desc"].ToString();
            view_date_proposed.Text = project.Rows[0]["date_proposed"].ToString();
            view_venue.Text = project.Rows[0]["event_held"].ToString();
            view_start_date.Text = project.Rows[0]["start_time"].ToString();
            view_end_date.Text = project.Rows[0]["end_time"].ToString();
            view_budget.Text = project.Rows[0]["budget"].ToString();

            bool has_view_items_ = false;
            view_items_list.DataSource = null;
            has_view_items_ = conn_proj.projects_items(view_items_list, id_);
            
            view_items_list.Columns["item_name"].HeaderText = "Name";
            view_items_list.Columns["cost"].HeaderText = "Cost";
            view_items_list.Columns["quantity"].HeaderText = "Quantity";
            view_items_list.Columns["subtotal"].HeaderText = "Subtotal";
            view_items_list.Columns["display_text"].HeaderText = "Results";

            if (has_view_items_ == false)
            {
                view_items_list.Columns["items_id"].Visible = false;
                view_items_list.Columns["project_id"].Visible = false;
                view_items_list.Columns["item_name"].Visible = false;
                view_items_list.Columns["cost"].Visible = false;
                view_items_list.Columns["quantity"].Visible = false;
                view_items_list.Columns["subtotal"].Visible = false;
                view_items_list.Columns["display_text"].Visible = true;
                Console.WriteLine(has_view_items_.ToString());
            } else
            {
                view_items_list.Columns["items_id"].Visible = false;
                view_items_list.Columns["project_id"].Visible = false;
                view_items_list.Columns["item_name"].Visible = true;
                view_items_list.Columns["cost"].Visible = true;
                view_items_list.Columns["quantity"].Visible = true;
                view_items_list.Columns["subtotal"].Visible = true;
                view_items_list.Columns["display_text"].Visible = false;
                Console.WriteLine(has_view_items_.ToString());
            }


        }

        public bool items_add()
        {
            bool success = true;
            string item_name_;
            string cost_;
            string quantity_;
            try
            {
                foreach (DataGridViewRow row in items_list.Rows)
                {
                    item_name_ = row.Cells["name"].Value.ToString();
                    cost_ = row.Cells["cost"].Value.ToString();
                    quantity_ = row.Cells["quantity"].Value.ToString();
                    string query = "INSERT INTO project_items(project_id, item_name, cost, quantity) VALUES (" + id_ + ", '" + item_name_ + "', " + cost_ + ", " + quantity_ + ")";
                    conn_proj.project_add_items(query);
                }
                success = true;
            } catch (Exception e)
            {
                success = false;
            }
            return success;
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

            pnl_basic_view.Visible = false;
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
        bool has_pwd = false;
        bool has_persons = false;

        private void btn_persons_Click(object sender, EventArgs e)
        {
            pnl_visible_false();
            pnl_persons_involved.Visible = true;
            load_pwd_to_be_involved();
            load_persons_involved();
        }

        public void load_persons_involved()
        {
            has_persons = conn_proj.get_pwd_persons_involved(persons_grid, id_);
            persons_format();
        }

        public void load_pwd_to_be_involved()
        {
            has_pwd = conn_proj.get_pwd_projects_list(pwd_grid, id_);
            pwd_format();
        }

        public void pwd_format()
        {
            pwd_grid.Columns["fullname"].HeaderText = "Full Name";
            pwd_grid.Columns["disability_type"].HeaderText = "Disability";
            pwd_grid.Columns["id_no"].HeaderText = "ID No.";
            pwd_grid.Columns["district_name"].HeaderText = "District";
            pwd_grid.Columns["registration_no"].HeaderText = "Registration No.";
            pwd_grid.Columns["display_text"].HeaderText = "Results";


            pwd_grid.Columns["fullname"].ReadOnly = true;
            pwd_grid.Columns["disability_type"].ReadOnly = true;
            pwd_grid.Columns["id_no"].ReadOnly = true;
            pwd_grid.Columns["district_name"].ReadOnly = true;
            pwd_grid.Columns["registration_no"].ReadOnly = true;
            pwd_grid.Columns["display_text"].ReadOnly = true;
            if (has_pwd == true)
            {
                pwd_grid.Columns["pwd_id"].Visible = false;
                pwd_grid.Columns["disability_id"].Visible = false;
                pwd_grid.Columns["district_id"].Visible = false;
                pwd_grid.Columns["display_text"].Visible = false;

                pwd_grid.Columns["fullname"].Visible = true;
                pwd_grid.Columns["disability_type"].Visible = true;
                pwd_grid.Columns["id_no"].Visible = true;
                pwd_grid.Columns["district_name"].Visible = true;
                pwd_grid.Columns["registration_no"].Visible = true;
            } else
            {
                pwd_grid.Columns["pwd_id"].Visible = false;
                pwd_grid.Columns["disability_id"].Visible = false;
                pwd_grid.Columns["district_id"].Visible = false;
                pwd_grid.Columns["display_text"].Visible = true;

                pwd_grid.Columns["fullname"].Visible = false;
                pwd_grid.Columns["disability_type"].Visible = false;
                pwd_grid.Columns["id_no"].Visible = false;
                pwd_grid.Columns["district_name"].Visible = false;
                pwd_grid.Columns["registration_no"].Visible = false;
            }

        }

        public void persons_format()
        {
            persons_grid.Columns["fullname"].HeaderText = "Full Name";
            persons_grid.Columns["disability_type"].HeaderText = "Disability";
            persons_grid.Columns["id_no"].HeaderText = "ID No.";
            persons_grid.Columns["district_name"].HeaderText = "District";
            persons_grid.Columns["registration_no"].HeaderText = "Registration No.";
            persons_grid.Columns["display_text"].HeaderText = "Results";
            if (has_persons == true)
            {
                persons_grid.Columns["pwd_id"].Visible = false;
                persons_grid.Columns["disability_id"].Visible = false;
                persons_grid.Columns["district_id"].Visible = false;
                persons_grid.Columns["display_text"].Visible = false;

                persons_grid.Columns["fullname"].Visible = true;
                persons_grid.Columns["disability_type"].Visible = true;
                persons_grid.Columns["id_no"].Visible = true;
                persons_grid.Columns["district_name"].Visible = true;
                persons_grid.Columns["registration_no"].Visible = true;
            }
            else
            {
                persons_grid.Columns["pwd_id"].Visible = false;
                persons_grid.Columns["disability_id"].Visible = false;
                persons_grid.Columns["district_id"].Visible = false;
                persons_grid.Columns["display_text"].Visible = true;

                persons_grid.Columns["fullname"].Visible = false;
                persons_grid.Columns["disability_type"].Visible = false;
                persons_grid.Columns["id_no"].Visible = false;
                persons_grid.Columns["district_name"].Visible = false;
                persons_grid.Columns["registration_no"].Visible = false;
            }
        }
        #region DATE-START_END

        DateTime start_date_time;
        DateTime end_date_time;

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
            end_date_time = end;
        }

        public void start_date_()
        {
            int start_hour_ = int.Parse(start_time_hour.Value.ToString());
            int start_minutes_ = int.Parse(start_time_minute.Value.ToString());
            var start = start_date.Value.Date + new TimeSpan(start_hour_, start_minutes_, 0);

            lbl_start_date.Text = start.ToString();
            start_date_time = start;
        }

        public void date_validity(DateTime start, DateTime end)
        {
            if (start >= end )
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
            string start = lbl_start_date.Text;
            string end = lbl_end_date.Text;
            if (start == end)
            {
                lbl_date_error.Visible = true;
            } else
            {
                lbl_date_error.Visible = false;
            }
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
            string start = lbl_start_date.Text;
            string end = lbl_end_date.Text;
            if (start == end)
            {
                lbl_date_error.Visible = true;
            } else
            {
                lbl_date_error.Visible = false;
            }
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
                        #region ALTERNATE
                        /*string temp = (items_list.Rows[i].Cells["quantity"].Value.ToString());
                        int actual = int.Parse(temp);
                        actual = int.Parse(temp) + int.Parse(quantity);
                        items_list.Rows[i].Cells["quantity"].Value = actual;

                        temp = (items_list.Rows[i].Cells["subtotal"].Value.ToString());
                        double new_subtotal = double.Parse(temp) + double.Parse(subtotal);
                        items_list.Rows[i].Cells["subtotal"].Value = new_subtotal;*/
                        #endregion
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
            if (items_name.Text.Trim() == "")
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
                lbl_items_total.Text = "0.00";
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
            items_quantity.Value = 0;
            lbl_subtotal.Text = "0.00";
            sys_func.btn_inactive(btn_add_item);
        }

        public void clear_items()
        {
            items_list.Rows.Clear();
            calculate_items_total();
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
                //nothing
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

        private void btn_back_to_persons_Click(object sender, EventArgs e)
        {
            pnl_pwd_list.Visible = false;
            pnl_persons_involved.Visible = true;
        }

        private void btn_pnl_to_pwd_Click(object sender, EventArgs e)
        {
            pnl_persons_involved.Visible = false;
            pnl_pwd_list.Visible = true;
        }

        private void btn_clear_items_Click(object sender, EventArgs e)
        {
            clear_items();
        }

        private void lbl_start_date_TextChanged(object sender, EventArgs e)
        {
            btn_add_enable();
        }

        private void lbl_end_date_TextChanged(object sender, EventArgs e)
        {
            btn_add_enable();
        }

        private void startup_opacity_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
                this.Opacity += 0.1;
            else
                startup_opacity.Stop();
        }

        private void btn_add_pwd_Click(object sender, EventArgs e)
        {
            if (has_pwd == true)
            {
                if (pwd_grid.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in pwd_grid.SelectedRows)
                    {
                        string pwd_id = row.Cells["pwd_id"].Value.ToString();
                        string query = "INSERT INTO project_persons(project_id, pwd_id) VALUES (" + id_ + " ," + pwd_id + ")";
                        conn_proj.persons_add(query);
                        Console.WriteLine(id_ + " - " + pwd_id);
                    }
                }
                load_pwd_to_be_involved();
                load_persons_involved();
            }
        }

        private void pwd_grid_SelectionChanged(object sender, EventArgs e)
        {
            if (has_pwd == true)
            {
                if (pwd_grid.SelectedRows.Count > 0)
                {
                    sys_func.btn_active(btn_add_pwd);
                }
                else
                {
                    sys_func.btn_inactive(btn_add_pwd);
                }
            }
        }

        private void btn_pwd_refresh_Click(object sender, EventArgs e)
        {
            load_pwd_to_be_involved();
        }

        private void btn_remove_persons_Click(object sender, EventArgs e)
        {
            if (has_persons == true)
            {
                if (persons_grid.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in persons_grid.SelectedRows)
                    {
                        string pwd_id = row.Cells["pwd_id"].Value.ToString();
                        conn_proj.persons_remove(pwd_id, id_);
                        Console.WriteLine(id_ + " - " + pwd_id);
                    }
                }
                load_pwd_to_be_involved();
                load_persons_involved();
            }
        }

        private void persons_grid_SelectionChanged(object sender, EventArgs e)
        {
            if (has_persons == true)
            {
                if (persons_grid.SelectedRows.Count > 0)
                {
                    sys_func.btn_active(btn_remove_persons);
                }
                else
                {
                    sys_func.btn_inactive(btn_remove_persons);
                }
            }
        }

        private void date_proposed_ValueChanged(object sender, EventArgs e)
        {
            start_date.MinDate = date_proposed.Value;
        }

        private void btn_refresh_persons_Click(object sender, EventArgs e)
        {
            load_persons_involved();
        }

        private void btn_view_info_Click(object sender, EventArgs e)
        {
            pnl_visible_false();
            pnl_basic_view.Visible = true;
        }
    }
}
