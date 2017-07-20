using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace SAD_2_PTT
{
    class connections
    {
        public MySqlConnection conn;
        public connections()
        {
            conn = new MySqlConnection("Server=localhost;Database=p_dao;Uid=root;Pwd=root");
        }

        public void pwd_grid_list(DataGridView pwd_grid)
        {
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("SELECT * FROM pwd WHERE isArchived = 0", conn);
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

        public void populate_cbox(ComboBox disability_type)
        {
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("SELECT * FROM disability", conn);
                MySqlDataAdapter get = new MySqlDataAdapter(comm);
                DataTable set = new DataTable();
                get.Fill(set);

                int count = set.Rows.Count;
                if (count == 0)
                {
                    MessageBox.Show("No disabilities added.");
                } else
                {
                    foreach (DataRow data in set.Rows)
                    {
                        disability_type.Items.Add(data["disability_type"].ToString());
                    }
                }
                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
                MessageBox.Show(e.Message);
            }
        }

        #region PWD ADD PA - 11
        public void pwd_add_profile(string query, string variable)
        {
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand((query + variable), conn);
                comm.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                MessageBox.Show(e.Message);
            }
        }
        #endregion
        
        public DataTable pwd_view_profile (int current_id)
        {
            try
            {
                conn.Open();
                MySqlCommand comm = new MySqlCommand("SELECT * FROM pwd where pwd_id = " + current_id);
                MySqlDataAdapter get = new MySqlDataAdapter(comm);
                DataTable set = new DataTable();
                get.Fill(set);
                
                conn.Close();
                return set;
            } catch (Exception e)
            {
                conn.Close();
                return set;
                MessageBox.Show(e.Message);
            }

            
        }
    }
}
