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
        #region Form_Control_Box CB - 00
        public void btn_close(Form current_form)
        {
            current_form.Close();
        }
        public main_form reference_to_main { get; set; }

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

        #region Text_Style

        public void text_enter(TextBox current_textbox, string text_fill)
        {
            string first = "First Name";
            string middle = "Middle Name";
            string last = "Last Name";

            if (text_fill == first || text_fill == middle || text_fill == last)
            {
                current_textbox.Clear();
                current_textbox.ForeColor = System.Drawing.Color.Black;
               
            }
        }

        public void text_leave(TextBox current_textbox, string text_to_fill)
        {
            if (current_textbox.Text.Trim() == "" )
            {
                current_textbox.Text = text_to_fill;
                current_textbox.ForeColor = System.Drawing.Color.Silver;
            }
            else
            {
                current_textbox.ForeColor = System.Drawing.Color.Black;
            }
        }
        #endregion

        #region Panel_Activation

        public void panel_activate(Panel to_activate, Panel to_deactivate) {
            to_deactivate.Visible = false;
            to_activate.Visible = true;
            to_deactivate = to_activate;
        }

        #endregion
    }
}
