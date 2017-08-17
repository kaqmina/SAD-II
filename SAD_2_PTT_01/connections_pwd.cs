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
    class connections_pwd
    {
        public MySqlConnection conn;
        public connections_pwd()
        {
            conn = new MySqlConnection("Server=localhost;Database=p_dao;Uid=root;Pwd=root");
        }

        public void pwd_grid_list(DataGridView pwd_grid)
        {
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("SELECT pwd_id, "
                                                          + "registration_no, "
                                                          + "CONCAT(lastname,', ', firstname, ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS fullname, "
                                                          + "(CASE WHEN sex = 0 THEN 'M' ELSE 'F' END) as sex, "
                                                          + "disability_type, "
                                                          + "(CASE WHEN blood_type = 1 THEN 'O' WHEN blood_type = 2 THEN 'A' WHEN blood_type = 3 THEN 'B' ELSE 'AB' END) AS blood_type, "
                                                          + "(CASE WHEN civil_status = 1 THEN 'Single' WHEN civil_status = 2 THEN 'Married' WHEN civil_status = 3 THEN 'Widow/er' WHEN civil_status = 4 THEN 'Separated' ELSE 'Co-Habitation' END) AS civil_status, "
                                                          + "application_date, "
                                                          + "added_date, "
                                                          + "status_pwd "
                                                          + "FROM pwd LEFT JOIN p_dao.disability ON (disability.disability_id = pwd.disability_id) WHERE isArchived = 0", conn);
                MySqlDataAdapter get = new MySqlDataAdapter(comm);
                DataTable set = new DataTable();
                get.Fill(set);


                pwd_grid.DataSource = set;
                if (set.Rows.Count == 0)
                {
                    MessageBox.Show("No PWD Profiles added.");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message); //error
            }
        }
    }
}
