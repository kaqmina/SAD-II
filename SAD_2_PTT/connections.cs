﻿using System;
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

        public void populate_cbox()
        {
            try
            {
                conn.Open();

                conn.Close();
            } catch (Exception e)
            {
                conn.Close();
                MessageBox.Show(e.Message);
            }
        }
    }
}