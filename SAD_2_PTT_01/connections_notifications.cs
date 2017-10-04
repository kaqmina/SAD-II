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
        public int project_;
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
                //MessageBox.Show("[ERROR_PWD_NOTIFICATIONS_30_DAYS_LEFT]");
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
                //MessageBox.Show("[ERROR_PWD_NOTIFICATIONS_EXPIRED]");
                number = "0";
            }
            return number;
        }

        public string check_project_upcoming()
        {
            //SELECT pwd_id FROM p_dao.pwd WHERE datediff(end_date, curdate()) <= 30;
            //SELECT count(*) FROM p_dao.pwd WHERE datediff(end_date, curdate()) <= 30;
            string number = "0";
            try
            {
                conn.Open();

                comm = new MySqlCommand("SELECT COUNT(*) AS number FROM project WHERE (DATEDIFF(start_time, CURDATE()) BETWEEN 0 AND 7) AND seen = 0 AND project.isArchived != 1", conn);
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
                //MessageBox.Show("[ERROR_PJT_NOTIFICATIONS_PROJECT_UPCOMING]");
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

                string upcoming_project = check_project_upcoming();
                project_ = int.Parse(upcoming_project);
                if (project_ > 0)
                {
                    add_7_days();
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
            int rows_count = reference_to_main.notification_grid.Rows.Count;
            reference_to_main.notification_grid.Sort(reference_to_main.notification_grid.Columns["type_clicked"], System.ComponentModel.ListSortDirection.Ascending);

            for (int i = 0; i < rows_count; i++)
            {
                string click = reference_to_main.notification_grid.Rows[i].Cells["type_clicked"].Value.ToString();
                if (click == "1")
                {
                    reference_to_main.notification_grid.Rows[i].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular);
                    reference_to_main.notification_grid.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.Gray;
                } else
                {
                    reference_to_main.notification_grid.Rows[i].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
                    reference_to_main.notification_grid.Rows[i].DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb( 41,45,56);
                    reference_to_main.btn_notification.BackColor = System.Drawing.Color.Red;
                }
            }
        }

        public void update_font()
        {
            int rows_count = reference_to_main.notification_grid.Rows.Count;

            if (rows_count == 0)
            {
                initial_font();
                return;
            }

            reference_to_main.notification_grid.Sort(reference_to_main.notification_grid.Columns["type_clicked"], System.ComponentModel.ListSortDirection.Ascending);
            int old_pwd_30_days = pwd_30_days;
            int new_pwd_30_days = int.Parse(check_30_days_left());

            if (old_pwd_30_days == new_pwd_30_days)
                return;
            else
                pwd_30_days = new_pwd_30_days;

            for (int i = 0; i < rows_count; i++)
            {
                string type_notif = reference_to_main.notification_grid.Rows[i].Cells["type_notif"].Value.ToString();
                string type_trigger = reference_to_main.notification_grid.Rows[i].Cells["type_trigger"].Value.ToString();
                if (type_notif == "0" && type_trigger == "0")
                {
                    if (new_pwd_30_days == 1)
                        reference_to_main.notification_grid.Rows[i].Cells["display_text"].Value = "There is 1 PWD Membership that has less than 30 Days left of validity." + Environment.NewLine + "Click for more details.";
                    else
                        reference_to_main.notification_grid.Rows[i].Cells["display_text"].Value = "There are " + pwd_30_days + " PWD Memberships that has less than 30 Days left of validity." + Environment.NewLine + "Click for more details.";

                    reference_to_main.notification_grid.Rows[i].Cells["type_clicked"].Value = "0";
                }

            }
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
                row["display_text"] = "There are " + pwd_30_days + " PWD Memberships that has less than 30 Days left of validity." + Environment.NewLine + "Click for more details.";
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
                row["display_text"] = "There are " + pwd_expired + " PWD Memberships that has expired." + Environment.NewLine + "Click for more details.";
            list_of_notifications.Rows.Add(row);
        }

        public void add_7_days()
        {
            DataRow row;
            row = list_of_notifications.NewRow();
            row["type_time_added"] = "3";
            row["type_notif"] = "1";
            row["type_id"] = "-";
            row["type_trigger"] = "start"; //end
            row["type_trigger_date"] = "-";
            row["type_clicked"] = "0";
            if (pwd_expired == 1)
                row["display_text"] = "There is 1 upcoming project." + Environment.NewLine + "Click for more details.";
            else
                row["display_text"] = "There are " + project_ + " upcoming projects." + Environment.NewLine + "Click for more details.";
            list_of_notifications.Rows.Add(row);
        }

        public bool get_7_days_data(DataGridView project_grid)
        {
            bool has_data = false;
            try
            {
                conn.Open();

                comm = new MySqlCommand("SELECT project_id, project_title, DATEDIFF(start_time, CURDATE()) AS check_7_days FROM project WHERE (DATEDIFF(start_time, CURDATE()) BETWEEN 0 AND 7) AND project.isArchived != 1", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                DataTable project_data = new DataTable();

                DataColumn column;
                DataRow row;
                DataView view;

                #region Columns
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "project_id";
                project_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "project_title";
                project_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "days_left";
                project_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "display_text";
                project_data.Columns.Add(column);
                #endregion

                int count = set.Rows.Count;
                if (count == 0)
                {
                    string none = "None";
                    row = project_data.NewRow();
                    row["project_id"] = none;
                    row["project_title"] = none;
                    row["days_left"] = none;
                    row["display_text"] = "No upcoming projects.";
                    project_data.Rows.Add(row);
                    has_data = false;
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        row = project_data.NewRow();
                        row["project_id"] = set.Rows[i]["project_id"].ToString();
                        row["project_title"] = set.Rows[i]["project_title"].ToString();
                        row["days_left"] = set.Rows[i]["check_7_days"].ToString();
                        row["display_text"] = "";
                        project_data.Rows.Add(row);
                    }
                    has_data = true;
                }

                view = new DataView(project_data);

                project_grid.DataSource = view;

                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("[ERROR] - [CONNECTIONS_NOTIFICATIONS] get_7_days_project() : " + e.Message);
            }
            return has_data;
        }

        public bool get_pwd_data(DataGridView pwd_grid )
        {
            bool has_data = false;
            try
            {
                conn.Open();

                comm = new MySqlCommand("SELECT renewPWD_id, "
                                             + "renew_pwd.pwd_id, "
                                             + "id_no, (CONCAT(lastname, ', ', firstname)) AS fullname, "
                                             + "(DATEDIFF(renew_pwd.end_date, CURDATE())) AS days_left "
                                             + "FROM p_dao.renew_pwd JOIN pwd WHERE((DATEDIFF(renew_pwd.end_date, CURDATE()) BETWEEN 0 AND 30)) "
                                             + "AND renewPWD_id = (SELECT MAX(renewPWD_id) FROM renew_pwd WHERE renew_pwd.pwd_id = pwd.pwd_id) AND is_resolved = 0 ", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                DataTable pwd_data = new DataTable();

                DataColumn column;
                DataRow row;
                DataView view;

                #region Columns
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "renewPWD_id";
                pwd_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "pwd_id";
                pwd_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "id_no";
                pwd_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "fullname";
                pwd_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "days_left";
                pwd_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "display_text";
                pwd_data.Columns.Add(column);
                #endregion

                int count = set.Rows.Count;
                if (count == 0)
                {
                    string none = "None";
                    row = pwd_data.NewRow();
                    row["renewPWD_id"] = none;
                    row["pwd_id"] = none;
                    row["id_no"] = none;
                    row["fullname"] = none;
                    row["days_left"] = none;
                    row["display_text"] = "No memberships that is about to expire.";
                    pwd_data.Rows.Add(row);
                    has_data = false;
                    Console.WriteLine(has_data);
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        row = pwd_data.NewRow();
                        row["renewPWD_id"] = set.Rows[i]["renewPWD_id"].ToString();
                        row["pwd_id"] = set.Rows[i]["pwd_id"].ToString();
                        row["id_no"] = set.Rows[i]["id_no"].ToString();
                        row["fullname"] = set.Rows[i]["fullname"].ToString();
                        row["days_left"] = set.Rows[i]["days_left"].ToString();
                        row["display_text"] = "";
                        pwd_data.Rows.Add(row);
                    }
                    has_data = true;
                    Console.WriteLine(has_data);
                }

                view = new DataView(pwd_data);

                pwd_grid.DataSource = view;

                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("[ERROR] - [CONNECTIONS_NOTIFICATION] get_pwd_data() : " + e.Message);
            }
            return has_data;
        }
        
        public void update_seen()
        {
            try
            {
                conn.Open();

                comm = new MySqlCommand("SET SQL_SAFE_UPDATES=0;UPDATE project SET seen = 1 WHERE project.isArchived != 1 AND ((DATEDIFF(start_time, CURDATE()) BETWEEN 0 AND 7));SET SQL_SAFE_UPDATES=1;", conn);
                comm.ExecuteNonQuery();

                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
            }
        }

        public void update_resolved(string renew_pwd_id)
        {
            try
            {
                conn.Open();

                comm = new MySqlCommand("UPDATE renew_pwd SET is_resolved = 1 WHERE renewPWD_id = " + renew_pwd_id, conn);
                comm.ExecuteNonQuery();

                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("[ERROR] - [CONNECTIONS_NOTIFICATIONS] update_resolved() : " + e.Message);
            }
        }

    }
}