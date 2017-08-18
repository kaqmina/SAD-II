﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAD_2_PTT
{
    public partial class device_prompt : Form
    {
        #region Declaration
        public device_add dev_add { get; set; }
        public device_disability dev_dis { get; set; }
        public device_provider  dev_prov { get; set; }
        public device_view dev_view { get; set; }

        connections conn = new connections();

        String function;
        #endregion

        public device_prompt()
        {
            InitializeComponent();
            startup_opacity.Start();

            if (function == "Status : Handed Out")
            {
                date_out.Visible = lbl_out.Visible = true;
                lbl_quest.Visible = false;
            }
            else
            {
                date_out.Visible = lbl_out.Visible = false;
                lbl_quest.Visible = true;
            }
        }

        private void btn_continue_Click(object sender, EventArgs e)
        {
            function = prompt_title.Text;
            checkContinue(function);
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region checkContinue()
        public void checkContinue(string function)
        {
            if (function == "Edit Device" || function == "Remove Device")
            {
                dev_add.cont = true;
            }
            else if (function == "Edit Disability")
            {
                dev_dis.cont = true;
            }
            else if (function == "Edit Device Provider")
            {
                dev_prov.cont = true;
            }
            else if (function == "Edit Request")
            {
                dev_view.cont = true;
            }
            else if(function == "Status : Handed Out")
            {
                dev_view.cont = true;
                DateTime date_OUT = date_out.Value.Date;
                int id = dev_view.id;

                string query = "UPDATE p_dao.device_log SET p_dao.device_log.date_out = '" + date_OUT.ToString("yyyy-MM-dd") + "', status = '2' WHERE p_dao.device_log.deviceLOG_id = '" + id + "'";
                conn.Edit(query, dev_view.cont);
            }
        }
        #endregion

        private void startup_opacity_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
                this.Opacity += 0.1;
            else
                startup_opacity.Stop();
        }
        

    }
}
