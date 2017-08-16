using System;
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

        String function;
        #endregion

        public device_prompt()
        {
            InitializeComponent();
            startup_opacity.Start();
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
            else if (function == "Edit Request" || function == "Requested Device: Received")
            {
                dev_view.cont = true;
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
