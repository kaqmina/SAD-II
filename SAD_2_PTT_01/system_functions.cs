using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAD_2_PTT_01
{
    class system_functions
    {
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
            if (current_textbox.Text.Trim() == "")
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


    }
}
