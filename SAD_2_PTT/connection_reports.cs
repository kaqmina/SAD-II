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
using System.Reflection;


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
            conn = new MySqlConnection("Server=localhost;Database=academic;Uid=root;Pwd=root;");
        }

        public void report_gridView(DataGridView report)
        {
            try
            {
                string query = "SELECT STUDENTCODE, LASTNAME, FIRSTNAME, MIDDLENAME, GENDER, date_format(BIRTHDATE, '%d/%m/%Y') AS BIRTHDATE, ADDRESS FROM academic.students ";
                conn.Open();
                MySqlCommand com = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                report.DataSource = dt;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in sample_report_grid() : " + ex);
            }
        }

        #region [SAMPLE Module]
        public void pwd_PDFReport(string file, DataGridView report)
        {

            FileStream fs = new FileStream(file, FileMode.Create, FileAccess.ReadWrite);
            Document doc = new Document(PageSize.LETTER, 1, 1, 1, 1);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();

            PdfPTable table = new PdfPTable(report.ColumnCount);
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            table.SetWidths(new int[] { 3, 5, 5, 5, 3, 4, 6 });

            #region PDAO header
            //   table.SpacingBefore = 20;
            //   table.SpacingAfter = 30;
            //   table.WidthPercentage = 100;

            // table.TableEvent.TableLayout() ;

            #endregion

            var headerFont = FontFactory.GetFont("Segoe UI", 13, BaseColor.WHITE);
            var cellFont = FontFactory.GetFont("Segoe UI", 13);

            foreach (DataGridViewColumn col in report.Columns)
            {
                PdfPCell header = new PdfPCell(new Phrase(col.HeaderText, headerFont));
                header.BackgroundColor = new iTextSharp.text.BaseColor(40, 44, 55);
                header.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(header);
            }

            foreach (DataGridViewRow row in report.Rows)
            {
                foreach (DataGridViewCell values in row.Cells)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(values.Value.ToString(), cellFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell);
                }
            }

            doc.Add(table);
            doc.Close();

        }
        #endregion
    }
}
