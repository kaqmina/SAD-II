using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;


namespace SAD_2_PTT
{
    class connection_reports
    {
        public MySqlConnection conn;
        public MySqlCommand comm;
        public MySqlDataReader dr;

        public main_form reference_to_main { get; set; }

        public connection_reports()
        {
            conn = new MySqlConnection("Server=localhost;Database=p_dao;Uid=root;Pwd=root;");
        }
        #region [PWD Module]
        public void pwd_PDFReport(string file)
        {
            
            FileStream fs = new FileStream(file, FileMode.Create,FileAccess.ReadWrite);
            Document doc = new Document(PageSize.LETTER, 36, 72, 108, 180);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();

         
            PdfPTable table = new PdfPTable(7);
            table.SpacingBefore = 20;
            table.SpacingAfter = 30;
            table.WidthPercentage = 100;
            table.SetWidths(new int[] { 5, 5, 2, 5, 6, 7, 5 });

           // table.AddCell("NO.");
            table.AddCell("LAST NAME");
            table.AddCell("FIRST NAME");
           // table.AddCell("AGE");
            table.AddCell("SEX");
            table.AddCell("BIRTHDATE");
            table.AddCell("EDUCATIONAL ATTAINMENT");
            table.AddCell("ADDRESS");
            table.AddCell("TYPE OF DISABILITY");

           
            try
            {
                conn.Open();
                string gender = "(CASE WHEN sex = 0 THEN 'Male' ELSE 'Female') as sex";
                string educ_attain = "(CASE WHEN educ_attainment = 0 THEN '')";
                string query = "SELECT lastname, firstname," + gender + " birthdate, educ_attainment, address, disability_type"
                           + " FROM p_dao.pwd JOIN p_dao.disability ON pwd.disability_id = disability.disability_id";
                comm = new MySqlCommand(query, conn);
                dr = comm.ExecuteReader();

              
                while (dr.Read())
                {
                   // table.AddCell();
                    table.AddCell(dr.GetString(0));
                    table.AddCell(dr.GetString(1));
                    table.AddCell(dr.GetString(2));
                    table.AddCell(dr.GetString(3));
                    table.AddCell(dr.GetString(4));
                    table.AddCell(dr.GetString(5));
                    table.AddCell(dr.GetString(6));

                }
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error in pwd_Report(): " + ex);
                conn.Close();
            }
            doc.Add(table);
            doc.Close();
          
        }
        #endregion
    }
}
