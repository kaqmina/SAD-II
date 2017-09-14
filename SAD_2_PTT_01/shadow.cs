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
    public partial class shadow : Form
    {
        public shadow()
        {
            InitializeComponent();
        }
        public main_form reference_to_main { get; set; }

        private void shadow_Load(object sender, EventArgs e)
        {
            this.Location = new Point(reference_to_main.Location.X, reference_to_main.Location.Y);
        }
    }
}
