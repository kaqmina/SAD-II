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
    public partial class notifications_form : Form
    {
        public notifications_form()
        {
            InitializeComponent();
        }
        connections_notifications conn_noti = new connections_notifications();

        public main_form reference_to_main { get; set; }

        #region OPACITY
        private void startup_opacity_Tick(object sender, EventArgs e)
        {

            if (this.Opacity < 1)
                this.Opacity += 0.1;
            else
                startup_opacity.Stop();
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
        #endregion


        private void notifications_form_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            startup_opacity.Start();
            conn_noti.get_7_days_data(project_grid);
        }

        //public 
    }
}
