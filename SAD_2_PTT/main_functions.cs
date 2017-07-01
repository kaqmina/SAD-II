using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAD_2_PTT
{
    class main_functions
    {
        #region FormControlBox CB - 00
        public void btn_close(Form current_form)
        {
            current_form.Close();
        }

        public void btn_min(Form current_form)
        {
            current_form.WindowState = FormWindowState.Minimized;
        }

        public void btn_max(Form current_form)
        {
            if (current_form.WindowState != FormWindowState.Maximized)
                current_form.WindowState = FormWindowState.Maximized;
            else
                current_form.WindowState = FormWindowState.Normal;
        }
        #endregion


    }
}
