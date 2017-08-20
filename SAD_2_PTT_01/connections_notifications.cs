using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace SAD_2_PTT_01
{
    class connections_notifications
    {
        public MySqlConnection conn;
        MySqlCommand comm;
        MySqlDataAdapter get;
        DataTable set;
        public connections_notifications()
        {
            conn = new MySqlConnection("Server=localhost;Database=p_dao;Uid=root;Pwd=root");
        }

        public void check_30_days_left(Button btn_pwd)
        {
            //select pwd_id FROM p_dao.pwd WHERE datediff(end_date, curdate()) <= 30;
            //select count(*) FROM p_dao.pwd WHERE datediff(end_date, curdate()) <= 30;
            try
            {
                conn.Open();

                comm = new MySqlCommand("SELECT COUNT(*) FROM p_dao.pwd WHERE DATEDIFF(end_date, CURDATE()) <= 30", conn);

                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show("[ERROR_PWD_NOTIFICATIONS_30_DAYS_LEFT]");
            }
        }
    }
}
