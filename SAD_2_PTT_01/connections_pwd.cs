using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;
using System.IO;

namespace SAD_2_PTT_01
{
    class connections_pwd
    {
        public MySqlConnection conn;
        MySqlCommand comm;
        MySqlDataAdapter get;
        DataTable set;
        public connections_pwd()
        {
            conn = new MySqlConnection("Server=localhost;Database=p_dao;Uid=root;Pwd=root;Allow User Variables=True");
        }

        #region GRID-MAIN_FORM

        public bool pwd_grid_list(DataGridView pwd_grid)
        {
            bool has_data = false;
            try
            {
                conn.Open();
                comm = new MySqlCommand("SELECT @row_number:=@row_number+1 AS no, "
                                             + "pwd_id, "
                                             + "id_no ,"
                                             + "fullname, "
                                             + "gender, "
                                             + "age, "
                                             + "disability_type, "
                                             + "educ_attainment_type, "
                                             + "application_date, "
                                             + "district_name, "
                                             + "status_pwd, "
                                             + "registration_no "
                                             + "FROM "
                                             + "( "
                                             + "SELECT id_no, "
                                             + "pwd.pwd_id, "
                                             + "(CONCAT(lastname, ', ', firstname)) AS fullname, "
                                             + "(CASE WHEN sex = 0 THEN 'M' ELSE 'F' END) AS gender, "
                                             + "DATE_FORMAT(NOW(), '%Y') - DATE_FORMAT(birthdate, '%Y') - (DATE_FORMAT(NOW(), '00-%m-%d') < DATE_FORMAT(birthdate, '00-%m-%d')) AS age, "
                                             + "disability_type, "
                                             + "(CASE WHEN educ_attainment = 1 THEN 'Elementary' "
                                             + "WHEN educ_attainment = 2 THEN 'Elementary Undergraduate' "
                                             + "WHEN educ_attainment = 3 THEN 'High School' "
                                             + "WHEN educ_attainment = 4 THEN 'High School Undergraduate' "
                                             + "WHEN educ_attainment = 5 THEN 'College' "
                                             + "WHEN educ_attainment = 6 THEN 'College Undergraduate' "
                                             + "WHEN educ_attainment = 7 THEN 'Graduate' "
                                             + "WHEN educ_attainment = 8 THEN 'Post Graduate' "
                                             + "WHEN educ_attainment = 9 THEN 'Vocational' ELSE 'None' END) AS educ_attainment_type, "
                                             + "application_date, "
                                             + "(SELECT district_name FROM pwd_district WHERE pwd.district_id = pwd_district.district_id) AS district_name, "
                                             + "pwd.district_id, "
                                             + "educ_attainment, "
                                             + "sex, "
                                             + "status_pwd, "
                                             + "registration_no "
                                             + "FROM pwd JOIN disability ON pwd.disability_id = disability.disability_id "
                                             + "JOIN pwd_district ON pwd.district_id = pwd_district.district_id "
                                             + "WHERE pwd.isArchived != 1 AND disability.isArchived != 1 ORDER BY pwd_id ASC "
                                             + ") t1, (SELECT @row_number:= 0) t2 ", conn);
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
                column.ColumnName = "no";
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
                column.ColumnName = "gender";
                pwd_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "age";
                pwd_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "disability_type";
                pwd_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "educ_attainment_type";
                pwd_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "application_date";
                pwd_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "district_name";
                pwd_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "status_pwd";
                pwd_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "registration_no";
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
                    row["no"] = none;
                    row["pwd_id"] = none;
                    row["id_no"] = none;
                    row["fullname"] = none;
                    row["gender"] = none;
                    row["age"] = none;
                    row["disability_type"] = none;
                    row["educ_attainment_type"] = none;
                    row["application_date"] = none;
                    row["district_name"] = none;
                    row["status_pwd"] = none;
                    row["registration_no"] = none;
                    row["display_text"] = "There are no PWD members added.";
                    pwd_data.Rows.Add(row);
                    has_data = false;
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        row = pwd_data.NewRow();
                        row["no"] = set.Rows[i]["no"].ToString();
                        row["pwd_id"] = set.Rows[i]["pwd_id"].ToString();
                        row["id_no"] = set.Rows[i]["id_no"].ToString();
                        row["fullname"] = set.Rows[i]["fullname"].ToString();
                        row["gender"] = set.Rows[i]["gender"].ToString();
                        row["age"] = set.Rows[i]["age"].ToString();
                        row["disability_type"] = set.Rows[i]["disability_type"].ToString();
                        row["educ_attainment_type"] = set.Rows[i]["educ_attainment_type"].ToString();
                        string[] app_date = set.Rows[i]["application_date"].ToString().Split();
                        row["application_date"] = app_date[0];
                        row["district_name"] = set.Rows[i]["district_name"].ToString();
                        row["status_pwd"] = set.Rows[i]["status_pwd"].ToString();
                        row["registration_no"] = set.Rows[i]["registration_no"].ToString();
                        row["display_text"] = "Please refresh the list.";
                        pwd_data.Rows.Add(row);
                    }
                    has_data = true;
                }

                view = new DataView(pwd_data);

                pwd_grid.DataSource = view;
                conn.Close();
                Console.WriteLine("[SUCCESS] - [CONNECTIONS_PWD] pwd_grid_list() ");
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("[ERROR] - [CONNECTIONS_PWD] pwd_grid_list() : " + e.Message);
                has_data = false;
            }

            return has_data;
        }

        #endregion

        #region VIEW-MODE

        public void pwd_view_picture(string pwd_id, PictureBox pic_box)
        {
            try
            {
                conn.Open();

                comm = new MySqlCommand("SELECT picture FROM pwd WHERE pwd_id = " + pwd_id + "", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("[ERROR] - [CONNECTIONS_PWD] pwd_view_picture() : " + e.Message);
            }
            try
            {
                byte[] image = (byte[])set.Rows[0]["picture"];
                MemoryStream ms = new MemoryStream(image);
                pic_box.Image = Image.FromStream(ms);
                pic_box.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch
            {
                pic_box.Image = SAD_2_PTT_01.Properties.Resources.pwd;
                pic_box.SizeMode = PictureBoxSizeMode.CenterImage;
            }
        }

        public void pwd_view_profile(string current_id, DataTable main, DataTable other_info, DataTable parental_info)
        {
            try
            {
                conn.Open();
                string type_of_skill = "(CASE WHEN type_of_skill = 1 THEN 'Officials of Government and Special Interest Organizations, Corporate Executives, Managers, Managing Proprietors and Supervisors' "
                                           + "WHEN type_of_skill = 2 THEN 'Professionals' "
                                           + "WHEN type_of_skill = 3 THEN 'Technicians and Associate Professionals' "
                                           + "WHEN type_of_skill = 4 THEN 'Farmers, Forestry Workers and Fishermen' "
                                           + "WHEN type_of_skill = 5 THEN 'Trades and Related Workers' "
                                           + "WHEN type_of_skill = 6 THEN 'Plant and Machine Operators and Assemblers' "
                                           + "WHEN type_of_skill = 7 THEN 'Laborers' "
                                           + "WHEN type_of_skill = 8 THEN 'Unskilled Workers' "
                                           + "ELSE 'Special Occupation' END) AS type_of_skill, ";
                comm = new MySqlCommand("SELECT pwd_id, "
                                                          + "registration_no, "
                                                          + "id_no, "
                                                          + "picture, "
                                                          + "CONCAT(UCASE(lastname), ', ', firstname, ' ', middlename) AS fullname, "
                                                          + "(CASE WHEN sex = 0 THEN 'Male' ELSE 'Female' END) as sex, "
                                                          + "disability_type, "
                                                          + "blood_type, "
                                                          + "(CASE WHEN civil_status = 1 THEN 'Single' WHEN civil_status = 2 THEN 'Married' WHEN civil_status = 3 THEN 'Widow/er' WHEN civil_status = 4 THEN 'Separated' ELSE 'Co-Habitation' END) AS civil_status, "
                                                          + "application_date, "
                                                          + "added_date, "
                                                          + "end_date, "
                                                          + "nationality, "
                                                          + "birthdate, "
                                                          + "tel_no, "
                                                          + "mobile_no, "
                                                          + "email_add, "
                                                          + "(CASE WHEN educ_attainment = 1 THEN 'Elementary' WHEN educ_attainment = 2 THEN 'Elementary Undergraduate' WHEN educ_attainment = 3 THEN 'High School' WHEN educ_attainment = 4 THEN 'High School Undergraduate' WHEN educ_attainment = 5 THEN 'College' WHEN educ_attainment = 6 THEN 'College Undergraduate' WHEN educ_attainment = 7 THEN 'Graduate' WHEN educ_attainment = 8 THEN 'Post Graduate' WHEN educ_attainment = 9 THEN 'Vocational' ELSE 'None' END) AS educ_attainment, "
                                                          + "(CASE WHEN employment_status = 1 THEN 'Employed' WHEN employment_status = 2 THEN 'Unemployed' WHEN employment_status = 3 THEN 'Displaced Worker' WHEN employment_status = 4 THEN 'Resigned' WHEN employment_status = 5 THEN 'Retired' ELSE 'Returning Overseas Filipino Worker' END) AS employment_status, "
                                                          + "(CASE WHEN nature_of_employer = 2 THEN 'Government' ELSE 'Private' END) AS nature_of_employer, "
                                                          + "(CASE WHEN type_of_employment = 1 THEN 'Contractual' WHEN type_of_employment = 2 THEN 'Permanent' WHEN type_of_employment = 3 THEN 'Self-Employed' ELSE 'Seasonal' END) AS type_of_employment, "
                                                          + type_of_skill
                                                          + "(CASE WHEN status_pwd = 0 THEN 'Expired' ELSE 'Active' END) as status_pwd, "
                                                          + "CONCAT(address_house_no_street, ', ', address_barangay, ', ', address_municipality, ', ', address_province) as address,"
                                                          + "district_name "
                                                          + "FROM p_dao.pwd LEFT JOIN p_dao.disability ON (disability.disability_id = pwd.disability_id) LEFT JOIN p_dao.pwd_district ON (pwd.district_id = pwd_district.district_id) WHERE pwd.isArchived = 0 AND pwd_id = " + current_id, conn);
                MySqlDataAdapter main_data = new MySqlDataAdapter(comm);
                main_data.Fill(main);
                Console.WriteLine("[PWD] - [CONNECTIONS_PWD]   > { PWD_VIEW_PROFILE_MAIN_DATA_LOADED }");
                comm = new MySqlCommand("SELECT sss_no, "
                                             + "gsis_no, "
                                             + "phealth_no, "
                                             + "(CASE WHEN phealth_status = 1 THEN 'PhilHealth Member' ELSE 'PhilHealth Member Dependent' END) AS phealth_status, "
                                             + "organization_aff, "
                                             + "contact_person, "
                                             + "office_address, "
                                             + "tel_no, "
                                             + "name_of_reporting_unit, "
                                             + "CONCAT(UCASE(accomplished_by_ln), ', ', UCASE(accomplished_by_fn), ' ', accomplished_by_mn) AS accomplished_by "
                                             + "FROM pwd_otherinfo WHERE pwd_id = " + current_id, conn);
                MySqlDataAdapter other_data = new MySqlDataAdapter(comm);
                other_data.Fill(other_info);
                Console.WriteLine("[PWD] - [CONNECTIONS_PWD]   > { PWD_VIEW_PROFILE_OTHER_DATA_LOADED }");
                comm = new MySqlCommand("SELECT CONCAT(UCASE(fatherln), ', ', UCASE(fatherfn), ' ', fathermn) AS father, "
                                             + "CONCAT(UCASE(motherln), ', ', UCASE(motherfn), ' ', mothermn) AS mother, "
                                             + "CONCAT(UCASE(guardianln), ', ', UCASE (guardianfn), ' ', guardianmn) AS guardian "
                                             + "FROM parental_info WHERE pwd_id = " + current_id, conn);
                MySqlDataAdapter parent_data = new MySqlDataAdapter(comm);
                parent_data.Fill(parental_info);
                Console.WriteLine("[PWD] - [CONNECTIONS_PWD]   > { PWD_VIEW_PROFILE_PARENTAL_DATA_LOADED }");

                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("--->>" + e.Message + "<<---");
                MessageBox.Show("[ERROR_MAIN_OTHER_PARENTAL_DATA_LOAD]"); //error
            }
        }

        #endregion

        #region ADD-MODE
        public bool pwd_check_registration_has_duplicate(string registration_no, string original_registration_no) 
        {
            bool has_duplicate = false;
            if (registration_no != "" )
            {
                Console.WriteLine("[EXECUTE] - [CONNECTIONS_PWD] pwd_check_registration_has_duplicate()");
                
                if (registration_no != original_registration_no)
                {
                    try
                    {
                        conn.Open();
                        MySqlCommand comm = new MySqlCommand("SELECT COUNT(*) FROM p_dao.pwd WHERE registration_no = '" + registration_no + "' AND isArchived != 1", conn);
                        MySqlDataAdapter get = new MySqlDataAdapter(comm);
                        DataTable set = new DataTable();
                        get.Fill(set);
                        int count = int.Parse(set.Rows[0]["COUNT(*)"].ToString());
                        if (count == 0)
                            has_duplicate = false;
                        else
                            has_duplicate = true;
                        conn.Close();
                        Console.WriteLine("[SUCCESS] - [CONNECTIONS_PWD] pwd_check_registration_has_duplicate()");
                    }
                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine("[ERROR] - [CONNECTIONS_PWD] pwd_check_registration_has_duplicate() : "+ e.Message);
                    }
                }
            }
            
            return has_duplicate;
        }

        public bool pwd_check_id_has_duplicate(string id_no, string original_id_no )
        {
            bool has_duplicate = false;
            if (id_no != "")
            {
                Console.WriteLine("[EXECUTE] - [CONNECTIONS_PWD] : pwd_check_id_has_duplicate() ");

                if (id_no != original_id_no)
                {
                    try
                    {
                        conn.Open();
                        MySqlCommand comm = new MySqlCommand("SELECT COUNT(*) FROM p_dao.pwd WHERE id_no = '" + id_no + "' AND isArchived != 1", conn);
                        MySqlDataAdapter get = new MySqlDataAdapter(comm);
                        DataTable set = new DataTable();
                        get.Fill(set);
                        int count = int.Parse(set.Rows[0]["COUNT(*)"].ToString());
                        if (count == 0)
                            has_duplicate = false;
                        else
                            has_duplicate = true;
                        conn.Close();
                        Console.WriteLine("[SUCCESS] - [CONNECTIONS_PWD] : pwd_check_id_has_duplicate() ");
                    }
                    catch (Exception e)
                    {
                        conn.Close();
                        Console.WriteLine("[ERROR] - [CONNECTIONS_PWD] : pwd_check_id_has_duplicate() : " + e.Message);
                    }
                }
            }

            return has_duplicate;
        }

        public void populate_cbox(ComboBox disability_type, ComboBox district_type)
        {
            Console.WriteLine("[PWD] - [CONNECTIONS_PWD]   > { DISABILITY_DISTRICT_COMBOBOX_LOAD }");
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("SELECT * FROM p_dao.disability WHERE isArchived != 1", conn);
                MySqlDataAdapter get = new MySqlDataAdapter(comm);
                DataTable set = new DataTable();
                get.Fill(set);

                int count = set.Rows.Count;
                if (count == 0)
                {
                    MessageBox.Show("No disabilities added.");
                }
                else
                {
                    foreach (DataRow data in set.Rows)
                    {
                        disability_type.Items.Add(data["disability_type"].ToString());
                    }
                }

                comm = new MySqlCommand("SELECT * FROM p_dao.pwd_district", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                count = set.Rows.Count;
                if(count == 0)
                {
                    MessageBox.Show("No regions added.");
                } else
                {
                    foreach (DataRow data in set.Rows)
                    {
                        district_type.Items.Add(data["district_name"].ToString());
                    }
                }

                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("--->>" + e.Message + "<<---");
                MessageBox.Show("[ERROR_DISABILITY_DISTRICT_COMBOBOX]"); //error
            }
        }

        public bool pwd_add_profile(string main_data, string other_data, string parental_data)
        {
            bool success = false;
            bool main_ = false;
            bool other_ = false;
            bool parent_ = false;
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand(main_data, conn);
                #region MAIN
                try
                {
                    comm.ExecuteNonQuery();
                    main_ = true;
                } catch (Exception e)
                {
                    main_ = false;
                    Console.WriteLine("pwd_add_profile() main_ : " + e.Message);
                }

                if (main_ == false)
                {
                    conn.Close();
                    return false;
                }
                #endregion
                comm = new MySqlCommand(other_data, conn);
                #region OTHER
                try
                {
                    comm.ExecuteNonQuery();
                    other_ = true;
                } catch (Exception e )
                {
                    other_ = false;
                    Console.WriteLine("pwd_add_profile() other_ : " + e.Message);
                }

                if (other_ == false)
                {
                    conn.Close();
                    return false;
                }
                #endregion
                comm = new MySqlCommand(parental_data, conn);
                #region PARENT
                try
                {
                    comm.ExecuteNonQuery();
                    parent_ = true;
                } catch (Exception e)
                {
                    parent_ = false;
                    Console.WriteLine("pwd_add_profile() parent_ : " + e.Message);
                }

                if (parent_ == false)
                {
                    conn.Close();
                    return false;
                }
                #endregion
                conn.Close();
                success = true;
                Console.WriteLine("[PWD] - [CONNECTIONS_PWD]   > { PWD_ADD_PROFILE_DATA }");
            }
            catch (Exception e)
            {
                success = false;
                conn.Close();
                Console.WriteLine("--->>" + e.Message + "<<---");
                MessageBox.Show("[ERROR_PWD_ADD]");
            }
            return success;
        }

        public bool pwd_add_profile(string main_data, string other_data, string parental_data, byte[] image)
        {
            bool success = false;
            bool main_ = false;
            bool other_ = false;
            bool parent_ = false;
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand(main_data, conn);
                var parameter = new MySqlParameter("@Image", MySqlDbType.MediumBlob, image.Length);

                parameter.Value = image;
                comm.Parameters.Add(parameter);

                #region MAIN
                try
                {
                    comm.ExecuteNonQuery();
                    main_ = true;
                }
                catch (Exception e)
                {
                    main_ = false;
                }

                if (main_ == false)
                {
                    conn.Close();
                    return false;
                }
                #endregion
                comm = new MySqlCommand(other_data, conn);
                #region OTHER
                try
                {
                    comm.ExecuteNonQuery();
                    other_ = true;
                }
                catch (Exception e)
                {
                    other_ = false;
                }

                if (other_ == false)
                {
                    conn.Close();
                    return false;
                }
                #endregion
                comm = new MySqlCommand(parental_data, conn);
                #region PARENT
                try
                {
                    comm.ExecuteNonQuery();
                    parent_ = true;
                }
                catch (Exception e)
                {
                    parent_ = false;
                }

                if (parent_ == false)
                {
                    conn.Close();
                    return false;
                }
                #endregion
                conn.Close();
                success = true;
                Console.WriteLine("[PWD] - [CONNECTIONS_PWD]   > { PWD_ADD_PROFILE_DATA }");
            }
            catch (Exception e)
            {
                success = false;
                conn.Close();
                Console.WriteLine("--->>" + e.Message + "<<---");
                MessageBox.Show("[ERROR_PWD_ADD]");
            }
            return success;
        }

        #endregion

        #region ARCHIVE-MODE
        public void archive_profile(string current_id)
        {
            Console.WriteLine("[PWD] - [CONNECTIONS_PWD]   > { ARCHIVE_PROFILE }");
            conn.Open();

            comm = new MySqlCommand("UPDATE p_dao.pwd SET isArchived = 1 WHERE pwd_id = " + current_id, conn);
            comm.ExecuteNonQuery();

            conn.Close();
        }
        #endregion

        #region EDIT-MODE

        public void pwd_update_profile_data(string current_id, DataTable main, DataTable other_info, DataTable parental_info)
        {
            Console.WriteLine("[PWD] - [CONNECTIONS_PWD]   > { PWD_UPDATE_PROFILE_DATA }");
            try
            {
                conn.Open();
                comm = new MySqlCommand("SELECT * FROM p_dao.pwd WHERE isArchived = 0 AND pwd.pwd_id = " + current_id, conn);
                MySqlDataAdapter main_data = new MySqlDataAdapter(comm);
                main_data.Fill(main);
                comm = new MySqlCommand("SELECT * FROM pwd_otherinfo WHERE pwd_id = " + current_id, conn);
                MySqlDataAdapter other_data = new MySqlDataAdapter(comm);
                other_data.Fill(other_info);
                comm = new MySqlCommand("SELECT * FROM parental_info WHERE pwd_id = " + current_id, conn);
                MySqlDataAdapter parent_data = new MySqlDataAdapter(comm);
                parent_data.Fill(parental_info);

                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("--->>" + e.Message + "<<---");
                MessageBox.Show("[ERROR_UPDATE_PROFILE_DATA]"); //error
            }
        }

        public bool pwd_update_profile(string main_data, string other_data, string parental_data)
        {
            Console.WriteLine("[PWD] - [CONNECTIONS_PWD]   > { PWD_UPDATE_PROFILE_ }");
            bool success = false;
            try
            {
                conn.Open();
                comm = new MySqlCommand(main_data, conn);
                Console.WriteLine("[PWD] - [CONNECTIONS_PWD]   > { PWD_UPDATE_PROFILE_MAIN_DATA }");
                comm.ExecuteNonQuery();
                comm = new MySqlCommand(other_data, conn);
                Console.WriteLine("[PWD] - [CONNECTIONS_PWD]   > { PWD_UPDATE_PROFILE_OTHER_DATA }");
                comm.ExecuteNonQuery();
                comm = new MySqlCommand(parental_data, conn);
                Console.WriteLine("[PWD] - [CONNECTIONS_PWD]   > { PWD_UPDATE_PROFILE_PARENTAL_DATA }");
                comm.ExecuteNonQuery();
                conn.Close();
                success = true;
            }
            catch (Exception e)
            {
                success = false;
                conn.Close();
                Console.WriteLine("--->>" + e.Message + "<<---");
                MessageBox.Show("[ERROR_PWD_UPDATE_PROFILE]");
            }

            return success;
        }

        public bool pwd_update_profile(string main_data, string other_data, string parental_data, byte[] image)
        {
            Console.WriteLine("[PWD] - [CONNECTIONS_PWD]   > { PWD_UPDATE_PROFILE_ }");
            bool success = false;
            bool main_ = false;
            bool other_ = false;
            bool parent_ = false;

            try
            {
                conn.Open();
                comm = new MySqlCommand(main_data, conn);
                Console.WriteLine("[PWD] - [CONNECTIONS_PWD]   > { PWD_UPDATE_PROFILE_MAIN_DATA }");
                var parameter = new MySqlParameter("@Image", MySqlDbType.MediumBlob, image.Length);

                parameter.Value = image;
                #region MAIN-DATA
                comm.Parameters.Add(parameter);
                try
                {
                    comm.ExecuteNonQuery();
                    main_ = true;
                } catch (Exception e)
                {
                    main_ = false;
                }

                if (main_ == false)
                {
                    conn.Close();
                    return false;
                }
                #endregion

                comm = new MySqlCommand(other_data, conn);
                Console.WriteLine("[PWD] - [CONNECTIONS_PWD]   > { PWD_UPDATE_PROFILE_OTHER_DATA }");
                #region OTHER-DATA
                try
                {
                    comm.ExecuteNonQuery();
                    other_ = true;
                } catch (Exception e)
                {
                    other_ = false;
                }

                if (other_ == false)
                {
                    conn.Close();
                    return false;

                }
                #endregion

                comm = new MySqlCommand(parental_data, conn);
                Console.WriteLine("[PWD] - [CONNECTIONS_PWD]   > { PWD_UPDATE_PROFILE_PARENTAL_DATA }");

                #region PARENTAL-DATA
                try
                {
                    comm.ExecuteNonQuery();
                    parent_ = true;
                } catch (Exception e)
                {
                    parent_ = false;
                }

                if (parent_ == false)
                {
                    conn.Close();
                    return false;
                }
                #endregion
                conn.Close();
                success = true;
            }
            catch (Exception e)
            {
                success = false;
                conn.Close();
                Console.WriteLine("--->>" + e.Message + "<<---");
                MessageBox.Show("[ERROR_PWD_UPDATE_PROFILE]");
            }

            return success;
        }

        #endregion

        #region FILTER-MODE

        #region OLD-LOGIC [# Hate it]
        public void pwd_search(DataGridView pwd_grid, TextBox pwd_searchbox)
        {
            conn.Open();
            string regis;
            string lastname;
            string firstname;
            string middlename;
            string app_date;
            //string 
            lastname = firstname = middlename = app_date = regis = " ";
            string[] separators = { " " };
            string value = pwd_searchbox.Text;
            string[] search = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string last = search.Last();
            foreach (string word in search)
            {
                if (word == last)
                {
                    regis += ("registration_no LIKE '%" + word + "%' ");
                    lastname += ("lastname LIKE '%" + word + "%' ");
                    firstname += ("firstname LIKE '%" + word + "%' ");
                    middlename += ("middlename LIKE '%" + word + "%' ");
                    app_date += ("application_date LIKE '%" + word + "%' ");
                }
                else
                {
                    regis += ("registration_no LIKE '%" + word + "%' OR ");
                    lastname += ("lastname LIKE '%" + word + "%' OR ");
                    firstname += ("firstname LIKE '%" + word + "%' OR ");
                    middlename += ("middlename LIKE '%" + word + "%' OR ");
                    app_date += ("application_date LIKE '%" + word + "%' OR ");
                }
            }
            /*
            string word = pwd_searchbox.Text;
            regis += ("registration_no LIKE '%" + word + "%' ");
            lastname += ("lastname LIKE '%" + word + "%' ");
            firstname += ("firstname LIKE '%" + word + "%' ");
            middlename += ("middlename LIKE '%" + word + "%' ");
            app_date += ("application_date LIKE '%" + word + "%' ");*/

            MySqlCommand comm = new MySqlCommand("SELECT pwd_id, "
                                                      + "registration_no, "
                                                      + "id_no, "
                                                      + "CONCAT(lastname,', ', firstname, ' ', UCASE(SUBSTRING(middlename,1,1)), SUBSTRING(middlename, 2)) AS fullname, "
                                                      + "firstname, "
                                                      + "middlename, "
                                                      + "lastname, "
                                                      + "(CASE WHEN sex = 0 THEN 'M' ELSE 'F' END) as sex, "
                                                      + "DATE_FORMAT(NOW(), '%Y') - DATE_FORMAT(birthdate, '%Y') - (DATE_FORMAT(NOW(), '00-%m-%d') < DATE_FORMAT(birthdate, '00-%m-%d')) AS age, "
                                                      + "disability_type, "
                                                      + "(CASE WHEN blood_type = 1 THEN 'O' WHEN blood_type = 2 THEN 'A' WHEN blood_type = 3 THEN 'B' ELSE 'AB' END) AS blood_type, "
                                                      + "(CASE WHEN civil_status = 1 THEN 'Single' WHEN civil_status = 2 THEN 'Married' WHEN civil_status = 3 THEN 'Widow/er' WHEN civil_status = 4 THEN 'Separated' ELSE 'Co-Habitation' END) AS civil_status, "
                                                      + "application_date, "
                                                      + "added_date, "
                                                      + "district_id, "
                                                      + "end_date, "
                                                      + "'No results' AS display_text, "
                                                      + "(SELECT district_name FROM pwd_district WHERE pwd.district_id = pwd_district.district_id) AS district_name, "
                                                      + "status_pwd "
                                                      + "FROM pwd LEFT JOIN disability ON pwd.disability_id = disability.disability_id WHERE "
                                                      + regis + " OR "
                                                      + lastname + " OR "
                                                      + firstname + " OR "
                                                      + middlename + " OR "
                                                      + app_date + " AND pwd.isArchived != 1", conn);

            MySqlDataAdapter getresult = new MySqlDataAdapter(comm);
            DataTable resulttable = new DataTable();
            getresult.Fill(resulttable);
            pwd_grid.DataSource = resulttable;

            conn.Close();
        }

        public bool two = false;

        public void filter_gender (string gender, DataGridView pwd_grid)
        {
            try
            {
                (pwd_grid.DataSource as DataView).RowFilter = string.Format("gender LIKE '{0}%' ", gender);
            } catch (Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + gender);
            }
        }

        public void filter_status (string status, DataGridView pwd_grid)
        {
            (pwd_grid.DataSource as DataView).RowFilter = string.Format("CONVERT(status_pwd, System.String) Like '%{0}%' ", status);

        }

        public void filter_status_gender (string status, string gender, DataGridView pwd_grid)
        {
            (pwd_grid.DataSource as DataView).RowFilter = string.Format("gender LIKE '{0}%' AND CONVERT(status_pwd, System.String) LIKE '{1}%' ", gender, status);
        }
        #endregion

        public bool pwd_search(string status, string gender, string field, string value, TextBox name, DataGridView pwd_grid)
        {
            bool has_data = false;
            pwd_grid.DataSource = null;

            #region QUERY BUILD UP
            string cond_status;
            string cond_gender;
            string cond_field;
            string lastname;
            string firstname;
            string firstlastname;
            string firstmidlastname;
            lastname = firstname = "";



            if (name.Text.Trim() == "" )
            {
                lastname = " lastname LIKE '%%' ";
                firstname = " firstname LIKE '%%' ";
                firstlastname = "firstlastname LIKE '%%' ";
                firstmidlastname = "firstmidlastname LIKE '%%' ";
            } else
            {
                string[] separators = { " " };
                string text = name.Text;
                //firstlastname = " firstlastname LIKE '" + text + "%' ";
                //firstmidlastname = " firstmidlastname LIKE '" + text + "%' ";
                string[] temp_name = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                string last = temp_name.Last();
                foreach (string word in temp_name)
                {
                    if (word == last)
                    {
                        lastname += ("lastname LIKE '" + word + "%' ");
                        firstname += ("firstname LIKE '" + word + "%' ");
                    }
                    else
                    {
                        lastname += ("lastname LIKE '" + word + "%' OR ");
                        firstname += ("firstname LIKE '" + word + "%' OR ");
                    }
                }
            }


            if (status == "")
                cond_status = " status_pwd = 0 OR status_pwd = 1 ";
            else
                cond_status = " status_pwd = " + status + " ";

            if (gender == "")
                cond_gender = " sex = 0 OR sex = 1 ";
            else
                cond_gender = " sex = " + gender + " ";

            if (field == "" || value == "ALL")
            {
                cond_field = " educ_attainment LIKE '%%' AND district_name LIKE '%%' AND disability_type LIKE '%%' ";
            }
            else //educ_attainment, district_name, disability_type
            {
                if (value == "")
                {
                    cond_field = field + " LIKE '%%' ";
                } else
                {
                    cond_field = field + " = '" + value + "' ";
                }
            }

            #endregion

            #region QUERY
            try
            {
                comm = new MySqlCommand("SELECT @row_number:=@row_number+1 AS no, "
                                            + "pwd_id, "
                                            + "id_no, "
                                            + "fullname, "
                                            + "gender, "
                                            + "age, "
                                            + "disability_type, "
                                            + "educ_attainment_type, "
                                            + "application_date, "
                                            + "district_name, "
                                            + "status_pwd, "
                                            + "registration_no "
                                            + "FROM "
                                            + "( "
                                            + "SELECT id_no, "
                                            + "pwd.pwd_id, "
                                            + "(CONCAT(lastname, ', ', firstname)) AS fullname, "
                                            + "(CONCAT(firstname, ' ', lastname)) AS firstlastname, "
                                            + "(CONCAT(firstname, ' ', middlename, ' ', lastname)) AS firstmidlastname, "
                                            + "firstname, "
                                            + "lastname, "
                                            + "middlename, "
                                            + "(CASE WHEN sex = 0 THEN 'M' ELSE 'F' END) AS gender, "
                                            + "DATE_FORMAT(NOW(), '%Y') - DATE_FORMAT(birthdate, '%Y') - (DATE_FORMAT(NOW(), '00-%m-%d') < DATE_FORMAT(birthdate, '00-%m-%d')) AS age, "
                                            + "disability_type, "
                                            + "(CASE WHEN educ_attainment = 1 THEN 'Elementary' "
                                            + "WHEN educ_attainment = 2 THEN 'Elementary Undergraduate' "
                                            + "WHEN educ_attainment = 3 THEN 'High School' "
                                            + "WHEN educ_attainment = 4 THEN 'High School Undergraduate' "
                                            + "WHEN educ_attainment = 5 THEN 'College' "
                                            + "WHEN educ_attainment = 6 THEN 'College Undergraduate' "
                                            + "WHEN educ_attainment = 7 THEN 'Graduate' "
                                            + "WHEN educ_attainment = 8 THEN 'Post Graduate' "
                                            + "WHEN educ_attainment = 9 THEN 'Vocational' ELSE 'None' END) AS educ_attainment_type, "
                                            + "application_date, "
                                            + "(SELECT district_name FROM pwd_district WHERE pwd.district_id = pwd_district.district_id) AS district_name, "
                                            + "pwd.district_id, "
                                            + "educ_attainment, "
                                            + "sex, "
                                            + "status_pwd, "
                                            + "registration_no "
                                            + "FROM pwd JOIN disability ON pwd.disability_id = disability.disability_id "
                                            + "JOIN pwd_district ON pwd.district_id = pwd_district.district_id "
                                            + "WHERE pwd.isArchived != 1 AND disability.isArchived != 1 AND "
                                            + "( "
                                            + "(" + cond_gender + ") AND "
                                            + "(" + cond_status + ") AND "
                                            + "(" + cond_field + ") AND "
                                            + "( "
                                            //+ "(" + firstmidlastname + ") OR "
                                            //+ "(" + firstlastname + ") OR "
                                            + "((" + firstname + ") OR "
                                            + "(" + lastname + ") "
                                            + ")) "
                                            + ") ORDER BY pwd_id ASC "
                                            + ") t1, (SELECT @row_number:= 0) t2", conn);
                get = new MySqlDataAdapter(comm);
                set = new DataTable();
                get.Fill(set);

                #endregion

                DataTable pwd_data = new DataTable();
                DataColumn column;
                DataRow row;
                DataView view;

                #region Columns
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "no";
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
                column.ColumnName = "gender";
                pwd_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "age";
                pwd_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "disability_type";
                pwd_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "educ_attainment_type";
                pwd_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "application_date";
                pwd_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "district_name";
                pwd_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "status_pwd";
                pwd_data.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "registration_no";
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
                    row["no"] = none;
                    row["pwd_id"] = none;
                    row["id_no"] = none;
                    row["fullname"] = none;
                    row["gender"] = none;
                    row["age"] = none;
                    row["disability_type"] = none;
                    row["educ_attainment_type"] = none;
                    row["application_date"] = none;
                    row["district_name"] = none;
                    row["status_pwd"] = none;
                    row["registration_no"] = none;
                    row["display_text"] = "No results match your search.";
                    pwd_data.Rows.Add(row);
                    has_data = false;
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        row = pwd_data.NewRow();
                        row["no"] = set.Rows[i]["no"].ToString();
                        row["pwd_id"] = set.Rows[i]["pwd_id"].ToString();
                        row["id_no"] = set.Rows[i]["id_no"].ToString();
                        row["fullname"] = set.Rows[i]["fullname"].ToString();
                        row["gender"] = set.Rows[i]["gender"].ToString();
                        row["age"] = set.Rows[i]["age"].ToString();
                        row["disability_type"] = set.Rows[i]["disability_type"].ToString();
                        row["educ_attainment_type"] = set.Rows[i]["educ_attainment_type"].ToString();
                        string[] app_date = set.Rows[i]["application_date"].ToString().Split();
                        row["application_date"] = app_date[0];
                        row["district_name"] = set.Rows[i]["district_name"].ToString();
                        row["status_pwd"] = set.Rows[i]["status_pwd"].ToString();
                        row["registration_no"] = set.Rows[i]["registration_no"].ToString();
                        row["display_text"] = "Please refresh the list.";
                        pwd_data.Rows.Add(row);
                    }
                    has_data = true;
                }

                view = new DataView(pwd_data);

                pwd_grid.DataSource = view;
                conn.Close();
                Console.WriteLine("[SUCCESS] - [CONNECTIONS_PWD] pwd_search() ");
            } catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("[ERROR] - [CONNECTIONS_PWD] pwd_search() : " + e.Message);
                has_data = false;
            }
            return has_data;
        }

        #endregion

        #region END-DATE

        public void insert_pwd_end_date(string pwd_id, string end_date)
        {
            try
            {
                conn.Open();

                comm = new MySqlCommand("INSERT INTO renew_pwd(pwd_id, end_date, is_resolved) VALUES ( " + pwd_id + ", '" + end_date + "', 0)", conn);
                comm.ExecuteNonQuery();

                conn.Close();
            } catch (Exception e)
            {
                Console.WriteLine("[ERROR] - [CONNECTIONS_PWD] insert_pwd_end_date() : " + e.Message);
                conn.Close();
            }
        }

        public void update_pwd_end_date(string pwd_id, string end_date)
        {
            try
            {
                conn.Open();

                comm = new MySqlCommand("UPDATE renew_pwd SET end_date = '"+ end_date +"' WHERE pwd_id = " + pwd_id + " AND renewPWD_id = (SELECT MAX(renewPWD_id) FROM renew_pwd WHERE pwd_id = "+ pwd_id +")", conn);
                comm.ExecuteNonQuery();

                Console.WriteLine("END DATE : " + end_date);
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("[ERROR] - [CONNECTIONS_PWD] update_pwd_end_date() : " + e.Message);
                conn.Close();
            }
        }
        
        public void if_not_existed(string pwd_id)
        {
            try
            {
                conn.Open();

                comm = new MySqlCommand("INSERT INTO renew_pwd(pwd_id, end_date, is_resolved) VALUES ( " + pwd_id + ", (SELECT DATE_ADD(application_date, INTERVAL 3 YEAR) AS end_date FROM pwd WHERE pwd_id = "+ pwd_id +"), 0)", conn);
                comm.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("[ERROR] - [CONNECTIONS_PWD] insert_pwd_end_date() : " + e.Message);
                conn.Close();
            }
        }

        #endregion

        #region EMP_LOG

        public string get_last_insert_id_pwd()
        {
            string user_id = "0";
            try
            {
                conn.Open();

                comm = new MySqlCommand("SELECT LAST_INSERT_ID() AS pwd_id", conn);
                MySqlDataAdapter get = new MySqlDataAdapter(comm);
                DataTable set = new DataTable();
                get.Fill(set);

                if(set.Rows.Count == 0)
                {
                    return "0";
                } else
                {
                    user_id = set.Rows[0]["pwd_id"].ToString();
                }

                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("[ERROR] - [CONNECTIONS_PWD] get_last_insert_id_pwd() : " + e.Message);
            }

            return user_id;
        }

        public void usr_log_update(string user_id, string pwd_id)
        {
            try
            {
                conn.Open();

                comm = new MySqlCommand("UPDATE p_dao.pwd_usr_log SET recent_emp_id = "+ user_id +", date_updated = CURDATE() WHERE pwd_id = "+ pwd_id , conn);
                comm.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                MessageBox.Show("[ERROR] - [CONNECTIONS_PWD] usr_log_update() : " + e.Message);
            }
        }

        public void usr_log_add(string user_id, string pwd_id)
        {
            try
            {
                conn.Open();

                comm = new MySqlCommand("INSERT INTO p_dao.pwd_usr_log(pwd_id, recent_emp_id, date_updated) VALUES (" + pwd_id + ", " + user_id + ", CURDATE())", conn);
                comm.ExecuteNonQuery();

                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("[ERROR] - [CONNECTIONS_PWD] usr_log_add() : " + e.Message);
            }
        }

        #endregion

        public void load_renew_data(string pwd_id, DataTable renew_data)
        {
            try
            {
                conn.Open();

                comm = new MySqlCommand("SELECT renewPWD_id, renew_pwd.pwd_id, renew_pwd.end_date, id_no FROM renew_pwd JOIN pwd ON renew_pwd.pwd_id = pwd.pwd_id WHERE renew_pwd.pwd_id = " + pwd_id +" AND renewPWD_id = (SELECT MAX(renewPWD_id) FROM renew_pwd WHERE renew_pwd.pwd_id = "+ pwd_id +")", conn);
                get = new MySqlDataAdapter(comm);
                get.Fill(renew_data);

                Console.WriteLine("[SUCCESS] - [CONNECTIONS_PWD] load_renew_data()");
                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
                Console.WriteLine("[ERROR] - [CONNECTIONS_PWD] load_renew_pwd() : " + e.Message);
            }
        }
        
        public void update_application_date(string pwd_id, string date_renewed)
        {
            try
            {
                conn.Open();

                comm = new MySqlCommand("UPDATE pwd SET application_date = '"+ date_renewed +"' WHERE pwd_id = " + pwd_id, conn);
                comm.ExecuteNonQuery();

                Console.WriteLine("APPLICATION DATE : " + date_renewed);
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("[ERROR] - [CONNECTIONS_PWD] update_application_date() : " + e.Message);
                conn.Close();
            }
        }
    }
}
