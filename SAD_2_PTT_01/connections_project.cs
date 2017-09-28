﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace SAD_2_PTT_01
{
    class connections_project
    {
        public MySqlConnection conn;
        MySqlCommand comm;
        MySqlDataAdapter get;
        DataTable set;
        public connections_project()
        {
            conn = new MySqlConnection("Server=localhost;Database=p_dao;Uid=root;Pwd=root");
        }

        #region GRID-MAINFORM

        public void project_grid_list(DataGridView projects_grid)
        {
            Console.WriteLine("[PJT] - [CONNECTIONS_PROJECT] > { [PROJECTS_GRID_LOADED] }");
            try
            {
                conn.Open();

                comm = new MySqlCommand("SELECT * FROM p_dao.project LEFT JOIN p_dao.project_progress ON project.project_id = project_progress.project_id WHERE project.isArchived = 0", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                projects_grid.DataSource = set;

                conn.Close();
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
                MessageBox.Show("[ERROR_PROJECT_GRID]");
            }
        }

        public void project_data_load (int project_id, DataTable main, DataTable item)
        {
            Console.WriteLine("[PJT] - [CONNECTIONS_PROJECT] > { [PROJECTS_DATA_LOAD] }");
            try
            {
                conn.Open();

                comm = new MySqlCommand("SELECT * FROM p_dao.project WHERE project_id = " + project_id, conn);
                MySqlDataAdapter main_data = new MySqlDataAdapter(comm);
                main_data = new MySqlDataAdapter(comm);
                main_data.Fill(main);

                comm = new MySqlCommand("SELECT * FROM p_dao.project_items WHERE project_id = " + project_id, conn);
                MySqlDataAdapter item_data = new MySqlDataAdapter(comm);
                item_data.Fill(item);

                conn.Close();
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
                MessageBox.Show("[ERROR_PROJECT_DATA_LOAD]");
            }
        }

        #endregion

        #region FILTER-MODE

        public void filter_status(string status, DataGridView projects_grid)
        {
            (projects_grid.DataSource as DataTable).DefaultView.RowFilter = string.Format("CONVERT(progress_type, System.String) Like '%{0}%' ", status);

        }

        #endregion

        public void persons_involved(int project_id, DataTable persons_grid)
        {
            try
            {
                conn.Open();

                comm = new MySqlCommand("SELECT registration_no, "
                                             + "personsIN_id, "
                                             + "CONCAT(UCASE(lastname), ', ', firstname, ' ', middlename) AS fullname, "
                                             + "disability_type, "
                                             + "(CASE WHEN attendance = 0 THEN 'Absent' WHEN attendance = 1 THEN 'Present' END) as attendance "
                                             + "FROM p_dao.project_persons LEFT JOIN p_dao.pwd ON (project_persons.pwd_id = pwd.pwd_id) "
                                             + "LEFT JOIN p_dao.disability ON (pwd.disability_id = disability.disability_id) WHERE project_id = " + project_id, conn);
                get = new MySqlDataAdapter(comm);
                get.Fill(persons_grid);

                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
                MessageBox.Show(e.Message);
            }
        }

        public void persons_involved_attendance (string attendance, string persons_id)
        {
            try
            {
                conn.Open();

                comm = new MySqlCommand("UPDATE p_dao.project_persons SET attendance = " + attendance + " WHERE personsIN_id = " + persons_id, conn);
                comm.ExecuteNonQuery();

                conn.Close();
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("[ERROR_PERSONS_INVOLVED_ATTENDANCE]");
                conn.Close();
            }
        }

        public void persons_involved_add_search(string regis_no, ComboBox add_persons_involved_search)
        {
            try
            {
                conn.Open();

                comm = new MySqlCommand("SELECT registration_no, "
                                             + "CONCAT(lastname,', ', firstname, ' ', UCASE(SUBSTRING(middlename,1,1)), SUBSTRING(middlename, 2)) AS fullname "
                                             + "FROM p_dao.pwd WHERE registration_no LIKE '%" + regis_no + "%' ", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                add_persons_involved_search.DataSource = set.DefaultView;

                conn.Close();
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("[ERROR_PERSONS_INVOLVED_ADD]");
                conn.Close();
            }
        }

        public bool project_add_data(string query)
        {
            bool success = false;
            try
            {
                conn.Open();

                comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                success = true;
                Console.WriteLine("[SUCCESS] project_add_data :" + query);
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("[ERROR_ADD_PROJECTS]" + e.Message);
                conn.Close();
                success = false;
            }
            return success;
        }

        public string get_latest_project_id()
        {
            string project_id = "0";
            try
            {
                conn.Open();
                comm = new MySqlCommand("SELECT LAST_INSERT_ID() AS X", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                project_id = set.Rows[0]["X"].ToString();
                MessageBox.Show(project_id);
                Console.WriteLine(project_id);

                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
            }
            return project_id;
        }

        public bool project_add_progress(string query)
        {
            bool success = false;
            try
            {
                conn.Open();

                comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("[ERROR_ADD_PROGRESS]");
                conn.Close();
                success = false;
            }
            return success;
        }

        public bool project_progress_update(string project_id) //for project table
        {
            bool success = false;
            try
            {
                conn.Open();
                comm = new MySqlCommand("UPDATE project SET project.progress_id = (SELECT progress_id FROM project_progress WHERE project.project_id = project_progress.project_id) WHERE project_id = " + project_id, conn);

                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
            }

            return success;
        }

        public bool project_add_items(string query)
        {
            bool success = false;
            try
            {
                conn.Open();

                comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                success = true;
                Console.WriteLine("Item Added.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("[ERROR_ADD_ITEMS]");
                conn.Close();
                success = false;
            }
            return success;
        }

        public bool get_pwd_persons_involved(DataGridView persons_grid, string project_id)
        {
            bool has_data = false;

            /*
                SELECT pwd.pwd_id, 
                CONCAT(lastname, ', ', firstname, ' ', UCASE(SUBSTRING(middlename, 1,1) ), '.' ) AS fullname, 
                pwd.disability_id, 
                disability.disability_type, 
                pwd.district_id, 
                district_name, 
                registration_no 
                FROM pwd JOIN disability ON pwd.disability_id = disability.disability_id 
                JOIN pwd_district ON pwd_district.district_id = pwd.district_id 
                WHERE pwd.isArchived != 1 AND NOT EXISTS (SELECT 1 FROM project_persons WHERE pwd.pwd_id = project_persons.pwd_id AND project_id = 2) ORDER BY fullname ASC
            */

            try
            {
                conn.Open();

                comm = new MySqlCommand("SELECT DISTINCT pwd.pwd_id, "
                                             + "registration_no, "
                                             + "id_no, "
                                             + "CONCAT(lastname, ', ', firstname, ' ', UCASE(SUBSTRING(middlename, 1, 1)), '.') AS fullname, "
                                             + "pwd.disability_id, "
                                             + "disability.disability_type, "
                                             + "pwd.district_id, "
                                             + "district_name "
                                             + "FROM p_dao.project_persons JOIN pwd ON project_persons.pwd_id = pwd.pwd_id "
                                             + "JOIN disability ON pwd.disability_id = disability.disability_id "
                                             + "JOIN pwd_district ON pwd.district_id = pwd_district.district_id "
                                             + "WHERE project_id = "+ project_id +" AND pwd.isArchived != 1 ORDER BY fullname ASC", conn);
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
                column.ColumnName = "pwd_id";
                pwd_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "registration_no";
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
                column.ColumnName = "disability_id";
                pwd_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "disability_type";
                pwd_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "district_id";
                pwd_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "district_name";
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
                    row["pwd_id"] = none;
                    row["fullname"] = none;
                    row["disability_id"] = none;
                    row["disability_type"] = none;
                    row["district_id"] = none;
                    row["district_name"] = none;
                    row["registration_no"] = none;
                    row["id_no"] = none;
                    row["display_text"] = "No PWDs added.";
                    pwd_data.Rows.Add(row);
                    has_data = false;
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        row = pwd_data.NewRow();
                        row["pwd_id"] = set.Rows[i]["pwd_id"].ToString();
                        row["fullname"] = set.Rows[i]["fullname"].ToString();
                        row["disability_id"] = set.Rows[i]["disability_id"].ToString();
                        row["disability_type"] = set.Rows[i]["disability_type"].ToString();
                        row["district_id"] = set.Rows[i]["district_id"].ToString();
                        row["district_name"] = set.Rows[i]["district_name"].ToString();
                        row["registration_no"] = set.Rows[i]["registration_no"].ToString();
                        row["id_no"] = set.Rows[i]["id_no"].ToString();
                        row["display_text"] = " ";

                        pwd_data.Rows.Add(row);
                    }
                    has_data = true;
                }

                view = new DataView(pwd_data);

                persons_grid.DataSource = view;
                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("[ERROR] - [CONNECTIONS_PROJECT] get_pwd_persons_involved() : " + e.Message);
            }

            return has_data; 
        }

        public void persons_remove(string pwd_id, string project_id)
        {
            try
            {
                conn.Open();

                comm = new MySqlCommand("DELETE FROM project_persons WHERE pwd_id = " + pwd_id + " AND project_id = " + project_id, conn);
                comm.ExecuteNonQuery();

                conn.Close();
            } catch (Exception e )
            {
                conn.Close();
                Console.WriteLine("[ERROR] - [CONNECTIONS_PROJECTS] remove_persons() : " + e.Message);
            }
        }

        public bool get_pwd_projects_list(DataGridView pwd_projects_grid, string project_id)
        {
            bool has_data = false;
            try
            {
                conn.Open();

                comm = new MySqlCommand("SELECT pwd.pwd_id, "
                                             + "registration_no, "
                                             + "id_no, "
                                             + "CONCAT(lastname, ', ', firstname, ' ', UCASE(SUBSTRING(middlename, 1, 1)), '.') AS fullname, "
                                             + "pwd.disability_id, "
                                             + "disability.disability_type, "
                                             + "pwd.district_id, "
                                             + "district_name "
                                             + "FROM pwd JOIN disability ON pwd.disability_id = disability.disability_id "
                                             + "JOIN pwd_district ON pwd_district.district_id = pwd.district_id "
                                             + "WHERE pwd.isArchived != 1 AND (SELECT EXISTS(SELECT pwd_id FROM project_persons WHERE pwd_id = pwd.pwd_id AND project_id = "+ project_id + ")) = 0 ORDER BY fullname ASC", conn);
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
                column.ColumnName = "pwd_id";
                pwd_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "registration_no";
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
                column.ColumnName = "disability_id";
                pwd_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "disability_type";
                pwd_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "district_id";
                pwd_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "district_name";
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
                    row["pwd_id"] = none;
                    row["fullname"] = none;
                    row["disability_id"] = none;
                    row["disability_type"] = none;
                    row["district_id"] = none;
                    row["district_name"] = none;
                    row["registration_no"] = none;
                    row["id_no"] = none;
                    row["display_text"] = "No PWDs to be added.";
                    pwd_data.Rows.Add(row);
                    has_data = false;
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        row = pwd_data.NewRow();
                        row["pwd_id"] = set.Rows[i]["pwd_id"].ToString();
                        row["fullname"] = set.Rows[i]["fullname"].ToString();
                        row["disability_id"] = set.Rows[i]["disability_id"].ToString();
                        row["disability_type"] = set.Rows[i]["disability_type"].ToString();
                        row["district_id"] = set.Rows[i]["district_id"].ToString();
                        row["district_name"] = set.Rows[i]["district_name"].ToString();
                        row["registration_no"] = set.Rows[i]["registration_no"].ToString();
                        row["id_no"] = set.Rows[i]["id_no"].ToString();
                        row["display_text"] = " ";

                        pwd_data.Rows.Add(row);
                    }
                    has_data = true;
                }

                view = new DataView(pwd_data);

                pwd_projects_grid.DataSource = view;
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("[ERROR] - [CONNECTIONS_PROJECT] get_pwd_persons_involved() : " + e.Message);
                has_data = false;
            }

            return has_data;
        }

        public void persons_add(string query)
        {
            try
            {
                conn.Open();

                comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();

                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("[ERROR] - [CONNECTIONS_PROJECT] persons_add() : " + e.Message);
            }
        } 
        
        public void projects_data(DataTable projects, string project_id)
        {
            try
            {
                conn.Open();

                comm = new MySqlCommand("SELECT * FROM project WHERE isArchived != 1 AND project_id = " + project_id, conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);
                
                DataColumn column;
                DataRow row;

                #region Columns
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "project_id";
                projects.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "project_title";
                projects.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "project_desc";
                projects.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "event_held";
                projects.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "date_proposed";
                projects.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "start_time";
                projects.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "end_time";
                projects.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "budget";
                projects.Columns.Add(column);
                #endregion

                int count = set.Rows.Count;
                if (count == 0)
                {
                    string none = "None";
                    row = projects.NewRow();
                    row["project_id"] = none;
                    row["project_title"] = none;
                    row["project_desc"] = none;
                    row["event_held"] = none;
                    row["date_proposed"] = none;
                    row["start_time"] = none;
                    row["end_time"] = none;
                    row["budget"] = none;
                    projects.Rows.Add(row);
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        row = projects.NewRow();
                        row["project_id"] = set.Rows[i]["project_id"].ToString();
                        row["project_title"] = set.Rows[i]["project_title"].ToString();
                        row["project_desc"] = set.Rows[i]["project_desc"].ToString();
                        row["event_held"] = set.Rows[i]["event_held"].ToString();
                        string[] date_proposed = set.Rows[i]["date_proposed"].ToString().Split();
                        row["date_proposed"] = date_proposed[0];
                        row["start_time"] = set.Rows[i]["start_time"].ToString();
                        row["end_time"] = set.Rows[i]["end_time"].ToString();
                        row["budget"] = set.Rows[i]["budget"].ToString();

                        projects.Rows.Add(row);
                    }
                }
                
                

                conn.Close();
            } catch (Exception e )
            {
                conn.Close();
                Console.WriteLine("[ERROR] - [CONNECTIONS_PROJECT] projects_data() : " + e.Message);
            }
        }

        public bool projects_items(DataGridView items_list, string project_id)
        {
            bool has_data = false;
            try
            {
                conn.Open();

                comm = new MySqlCommand("SELECT * FROM project_items WHERE project_id = " + project_id, conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                DataTable item_data = new DataTable();
                DataColumn column;
                DataRow row;
                DataView view;

                #region Columns
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "items_id";
                item_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "project_id";
                item_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "item_name";
                item_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "cost";
                item_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "quantity";
                item_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "subtotal";
                item_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "display_text";
                item_data.Columns.Add(column);
                #endregion

                int count = set.Rows.Count;
                if (count == 0)
                {
                    string none = "None";
                    row = item_data.NewRow();
                    row["items_id"] = none;
                    row["project_id"] = none;
                    row["item_name"] = none;
                    row["cost"] = none;
                    row["quantity"] = none;
                    row["subtotal"] = none;
                    row["display_text"] = "There are no items added.";
                    item_data.Rows.Add(row);
                    has_data = false;
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        row = item_data.NewRow();
                        row["items_id"] = set.Rows[i]["items_id"].ToString();
                        row["project_id"] = set.Rows[i]["project_id"].ToString();
                        row["item_name"] = set.Rows[i]["item_name"].ToString();
                        row["cost"] = set.Rows[i]["cost"].ToString();
                        row["quantity"] = set.Rows[i]["quantity"].ToString();
                        string cost_ = set.Rows[i]["cost"].ToString();
                        string quantity_ = set.Rows[i]["quantity"].ToString();
                        double cost = double.Parse(cost_);
                        double quantity = double.Parse(quantity_);
                        double subtotal = cost * quantity;
                        row["subtotal"] = string.Format("{0:n}", subtotal);
                        row["display_text"] = " ";

                        item_data.Rows.Add(row);

                        has_data = true;
                    }
                }
                view = new DataView(item_data);

                items_list.DataSource = view;

                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("[ERROR] - [CONNECTIONS_PROJECT] projects_items() : " + e.Message);
                has_data = false;
            }
            return has_data;
        }
    }
}
