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

        //connections conn = new connections();
        String function;
        #endregion

        public device_prompt()
        {
            InitializeComponent();
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
            if (function == "Edit Device" || function == "Delete Device")
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
        }
        #endregion

        // information for all prompts

    }
}
