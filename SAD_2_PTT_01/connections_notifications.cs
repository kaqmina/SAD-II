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

        public DataTable list_of_notifications = new DataTable();
        public int pwd_30_days;
        public int pwd_expired;
        public main_form reference_to_main { get; set; }

        public connections_notifications()
        {
            conn = new MySqlConnection("Server=localhost;Database=p_dao;Uid=root;Pwd=root");
            
            DataColumn column;

            #region Columns
            /* <type_time_added>        ::= DateTime.Now
             * <type_notif>             ::= pwd := 0 | project := 1
             * <type_id>                ::= pwd := pwd_id | project := project_id
             * <type_trigger>           ::= start := 0 | end := 1
             * <type_trigger_date>      ::= start_date | end_date
             * <type_clicked>           ::= not yet clicked := 0 | clicked := 1
             * <display_text>           ::= still creating....
             * 
             * October 1, 2017 11:20 AM
             * */

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "type_time_added";
            list_of_notifications.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "type_notif";
            list_of_notifications.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "type_id";
            list_of_notifications.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "type_trigger";
            list_of_notifications.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "type_trigger_date";
            list_of_notifications.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "type_clicked";
            list_of_notifications.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "display_text";
            list_of_notifications.Columns.Add(column);
            #endregion
        }

        public string check_30_days_left()
        {
            //SELECT pwd_id FROM p_dao.pwd WHERE datediff(end_date, curdate()) <= 30;
            //SELECT count(*) FROM p_dao.pwd WHERE datediff(end_date, curdate()) <= 30;
            string number = "0";
            try
            {
                conn.Open();

                comm = new MySqlCommand("SELECT COUNT(*) AS number FROM p_dao.renew_pwd WHERE (DATEDIFF(end_date, CURDATE()) BETWEEN 0 AND 30 ) AND end_date != CURDATE() AND is_resolved = 0", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                number = set.Rows[0]["number"].ToString();

                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show("[ERROR_PWD_NOTIFICATIONS_30_DAYS_LEFT]");
                number = "0";
            }
            return number;
        }
        public string check_pwd_expired()
        {
            //SELECT pwd_id FROM p_dao.pwd WHERE datediff(end_date, curdate()) <= 30;
            //SELECT count(*) FROM p_dao.pwd WHERE datediff(end_date, curdate()) <= 30;
            string number = "0";
            try
            {
                conn.Open();

                comm = new MySqlCommand("SELECT COUNT(*) AS number FROM p_dao.renew_pwd WHERE end_date = CURDATE() AND is_resolved = 0", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                number = set.Rows[0]["number"].ToString();

                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show("[ERROR_PWD_NOTIFICATIONS_30_DAYS_LEFT]");
                number = "0";
            }
            return number;
        }

        public void initial_rows_to_datatable()
        {
            try
            {
                reference_to_main.btn_notification.BackColor = System.Drawing.Color.FromArgb(41, 45, 56);
                string expire_30_days = check_30_days_left();
                pwd_30_days = int.Parse(expire_30_days);
                if (pwd_30_days > 0)
                {
                    add_30_days();
                    reference_to_main.btn_notification.BackColor = System.Drawing.Color.Red;
                }

                string expire_now = check_pwd_expired();
                pwd_expired = int.Parse(expire_now);
                if(pwd_expired > 0)
                {
                    add_expired();
                    reference_to_main.btn_notification.BackColor = System.Drawing.Color.Red;
                }
                //if(list_no)

            } catch (Exception e)
            {

            }
            DataView view = new DataView(list_of_notifications);

            reference_to_main.notification_grid.DataSource = view;
            notification_format();
        }

        public void notification_format()
        {
            reference_to_main.notification_grid.Columns["type_notif"].Visible = false;
            reference_to_main.notification_grid.Columns["type_id"].Visible = false;
            reference_to_main.notification_grid.Columns["type_trigger"].Visible = false;
            reference_to_main.notification_grid.Columns["type_trigger_date"].Visible = false;
            reference_to_main.notification_grid.Columns["type_time_added"].Visible = false;
            reference_to_main.notification_grid.Columns["type_clicked"].Visible = false;
            reference_to_main.notification_grid.ColumnHeadersVisible = false;
        }

        public void initial_font()
        {

        }

        public void add_30_days()
        {
            DataRow row;
            row = list_of_notifications.NewRow();
            row["type_time_added"] = "1";
            row["type_notif"] = "0";
            row["type_id"] = "-";
            row["type_trigger"] = "0"; //start
            row["type_trigger_date"] = "-";
            row["type_clicked"] = "0";
            if (pwd_30_days == 1)
                row["display_text"] = "There is 1 PWD Membership that has less than 30 Days left of validity." + Environment.NewLine + "Click for more details.";
            else
                row["display_text"] = "There are " + pwd_30_days + "PWD Memberships that has " + Environment.NewLine + "less than 30 Days left of validity." + Environment.NewLine + "Click for more details.";
            list_of_notifications.Rows.Add(row);
        }
        public void add_expired()
        {
            DataRow row;
            row = list_of_notifications.NewRow();
            row["type_time_added"] = "2";
            row["type_notif"] = "0";
            row["type_id"] = "-";
            row["type_trigger"] = "1"; //end
            row["type_trigger_date"] = "-";
            row["type_clicked"] = "0";
            if (pwd_expired == 1)
                row["display_text"] = "There is 1 PWD Membership that has expired." + Environment.NewLine + "Click for more details.";
            else
                row["display_text"] = "There are " + pwd_expired + "PWD Memberships that has expired." + Environment.NewLine + "Click for more details.";
            list_of_notifications.Rows.Add(row);
        }

        public void get_30_days_data()
        {
            try
            {
                conn.Open();

                //comm = new MySqlCommand("SELECT")

                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
            }
        }

    }
}