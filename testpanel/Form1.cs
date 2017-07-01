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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int check = 1;

        private void Form1_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            button6.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(check == 1)
            {
                panel1.Visible = false;
                panel2.Visible = true;
                button6.Enabled = true;
                check++;
            } else if(check == 2)
            {
                panel2.Visible = false;
                panel3.Visible = true;
                check++;
            } else if(check == 3)
            {
                panel3.Visible = false;
                panel4.Visible = true;
                check++;
            } else if(check == 4)
            {
                panel4.Visible = false;
                panel5.Visible = true;
                button5.Enabled = false;
                check++;
            }
            
        } 

        private void button6_Click(object sender, EventArgs e)
        {
            if (check == 2)
            {
                button6.Enabled = false;
                panel1.Visible = true;
                panel2.Visible = false;
                check--;
            }
            else if (check == 3)
            {
                panel2.Visible = true;
                panel3.Visible = false;
                check--;
            }
            else if (check == 4)
            {
                panel3.Visible = true;//kgjkvjhjdfdf
                panel4.Visible = false;
                check--;
            }
            else if (check == 5)
            {
                panel4.Visible = true;
                panel5.Visible = false;
                button5.Enabled = true;
                check--;
            }
        }
    }
}
