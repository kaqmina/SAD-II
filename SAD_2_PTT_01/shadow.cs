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
        public Form form_to_show;

        private void shadow_Load(object sender, EventArgs e)
        {
            this.Location = new Point(reference_to_main.Location.X, reference_to_main.Location.Y);
            startup_opacity.Start();
        }

        private void startup_opacity_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 0.6)
            {
                this.Opacity += 0.1;
            }
            else
            {
                startup_opacity.Stop();
                show_form();
            }
        }

        private void exit_opacity_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                this.Opacity -= 0.1;
            }
            else
            {
                exit_opacity.Stop();
            }
        }

        private void shadow_FormClosing(object sender, FormClosingEventArgs e)
        {
            exit_opacity.Start();
        }

        public void show_form()
        {
            form_to_show.ShowDialog();
            this.Close();
        }
    }
}
