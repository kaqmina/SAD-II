using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAD_2_PTT_01
{
    class system_keypress
    {
        public void key_letter(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsLetter(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || e.KeyChar == (char)(Keys.Space)))
            {
                e.KeyChar = Convert.ToChar("\0");
            }
        }

        public void key_number(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar) || (e.KeyChar == (char)Keys.Back) ))
            {
                e.KeyChar = Convert.ToChar("\0");
            }
        }

        public void key_number_letter(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || Char.IsLetter(e.KeyChar)))
            {
                e.KeyChar = Convert.ToChar("\0");
            }
        }

        public void key_number_letter_space(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || Char.IsLetter(e.KeyChar) || e.KeyChar == (char)(Keys.Space)))
            {
                e.KeyChar = Convert.ToChar("\0");
            }
        }
    }
}
