using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testpanel
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cen.Size = new Size(229, 607);
            side.Size = new Size(77, 607);
            back.Size = new Size(77, 607);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int milli = 0;
            while(back.Width != 308)
            {
                back.Width++;
            }
            timer1.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
