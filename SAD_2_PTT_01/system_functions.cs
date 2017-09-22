using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
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
        
        Font def = new Font("Segoe UI", 8.25F);

        public void btn_inactive(Button current_btn)
        {
            current_btn.Enabled = false;
            current_btn.Font = new Font(def, FontStyle.Italic);
        }

        public void btn_active(Button current_btn)
        {
            current_btn.Enabled = true;
            current_btn.Font = new Font(def, FontStyle.Regular);
        }

        public void lbl_reset(Label current_lbl)
        {
            current_lbl.Font = new Font(def, FontStyle.Italic);
            current_lbl.ForeColor = Color.Gray;
        }

        public void lbl_has_value(Label current_lbl)
        {
            current_lbl.Font = new Font(def, FontStyle.Regular);
            current_lbl.ForeColor = Color.Black;
        }

        public void lbl_required_error (Label current_lbl)
        {
            current_lbl.ForeColor = Color.Red;
        }

        public void lbl_required_success(Label current_lbl)
        {
            current_lbl.ForeColor = Color.FromArgb(41, 45, 56);
        }
    }
}
