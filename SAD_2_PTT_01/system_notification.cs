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
    public partial class system_notification : Form
    {
        public system_notification()
        {
            InitializeComponent();
        }
        bool close = false;
        int stay = 100;
        public string notification_message = "";

        private void notification_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1 && close == false)
            {
                this.Opacity += 0.1;
            }
            else
            {
                close = true;
            }
            if (close == true)
            {
                if (stay != 0)
                {
                    stay--;
                }
                else
                {
                    if (this.Opacity > 0)
                    {
                        this.Opacity -= 0.1;
                    }
                    else
                    {
                        this.Close();
                        notification.Stop();
                    }
                }
            }
        }

        private void system_notification_Load(object sender, EventArgs e)
        {
            message.Text = notification_message;
            notification.Start();
        }
    }
}
