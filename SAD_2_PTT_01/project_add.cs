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

        private void project_add_Load(object sender, EventArgs e)
        {
            load_time_format();
            load_date_min_max();
            load_default_enabled();
            btn_add_enable();
        }

        private void load_date_min_max()
        {
            //start_date.MaxDate = DateTime.Now;
        }

        private void load_default_enabled()
        {
            end_date.Enabled = false;
            //end_time.Enabled = false;
        }

        public void load_time_format()
        {
            start_time.ShowUpDown = true;
            //end_time.ShowUpDown = true;
        }

        public void btn_add_enable()
        {
            Font disabled_state = new Font("Segoe UI", 8.25F);
            Font enabled_state = new Font("Segoe UI", 8.25F);
            if (project_title.Text.Trim() == "" || project_desc.Text.Trim() == "" || project_venue.Text.Trim() == "")
            {
                btn_add_project.Enabled = false;
                btn_add_project.Font = new Font(disabled_state, FontStyle.Italic);
            } else
            {
                btn_add_project.Enabled = true;
                btn_add_project.Font = new Font(enabled_state, FontStyle.Regular);
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
            var start_date_ = new DateTime(start_date.Value.Year, start_date.Value.Month, start_date.Value.Day, start_time.Value.Hour, start_time.Value.Minute, 00);
            var end_date_ = new DateTime(end_date.Value.Year, end_date.Value.Month, end_date.Value.Day, end_date.Value.Hour, end_date.Value.Minute, 00);


        }

        private void start_time_ValueChanged(object sender, EventArgs e)
        {
            //DateTime parse = DateTime.Parse(start_time.Value.ToString());
            //end_time.MinDate = DateTime.Parse(parse.ToString("hh:mm tt"));
            //end_time.Enabled = true;
        }

        private void start_date_ValueChanged(object sender, EventArgs e)
        {
            end_date.MinDate = start_date.Value;
            end_date.Enabled = true;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_cancel_Click(sender, e);
        }
    }
}
