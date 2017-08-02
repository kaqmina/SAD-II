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
    public partial class shadow : Form
    {
        public shadow()
        {
            InitializeComponent();
            //archive_profile_prompt(current_id);
        }
        public main_form reference_to_main { get; set; }

       /* public void archive_profile_prompt(int current_id)
        {
            prompt archive = new prompt();
            archive.reference_to_main = this.reference_to_main;
            archive.Closed += (s, args) => this.Close();
            archive.current_id = current_id;
            archive.ShowDialog();
        }*/
    }
}
