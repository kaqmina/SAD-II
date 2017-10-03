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
    public partial class pwd_renew : Form
    {
        public pwd_renew()
        {
            InitializeComponent();
        }

        public main_form reference_to_main { get; set; }
        public string current_pwd_id = "0";
        connections_pwd conn_pwd = new connections_pwd();

        public void load_data ()
        {
            DataTable renew_data = new DataTable();
            conn_pwd.load_renew_data(current_pwd_id, renew_data);

           // lbl_id_no
        }
    }
}
