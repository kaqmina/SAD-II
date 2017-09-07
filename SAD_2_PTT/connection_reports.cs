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
            conn = new MySqlConnection("Server=localhost;Database=academic;Uid=root;Pwd=root;");
        }

        public void report_gridView(DataGridView report)
        {
            try
            {
                
                string query = "SELECT STUDENTCODE, LASTNAME, FIRSTNAME, MIDDLENAME, GENDER, date_format(BIRTHDATE, '%d/%m/%Y') AS BIRTHDATE, ADDRESS FROM academic.students ";
                conn.Open();
                comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                report.DataSource = dt;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in report_gridView() : " + ex);
            }
        }

        public void report_customFormat(DataGridView report, DateTime from, DateTime to)
        {
            try
            {
                string query = "SELECT STUDENTCODE, LASTNAME, FIRSTNAME, MIDDLENAME, GENDER, date_format(BIRTHDATE, '%d/%m/%Y') AS BIRTHDATE, ADDRESS FROM academic.students WHERE BIRTHDATE BETWEEN '"+ from.ToString("yyyy-MM-dd") +"' AND '"+ to.ToString("yyyy-MM-dd") +"'";
                conn.Open();
                comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                report.DataSource = dt;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in report_customFormat() : " + ex);
            }
        }

        public void report_MonthlyFormat(DataGridView report, DateTime month, DateTime year)
        {
            try
            {
                string query = "SELECT * FROM academic.students WHERE month(BIRTHDATE) = '"+ month.ToString("MM") +"' AND year(BIRTHDATE) = '" + year.ToString("yyyy") + "'";
                conn.Open();
                comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                report.DataSource = dt;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in report_MonthlyFormat() : " + ex);
            }
        }

        public void report_YearlyFormat(DataGridView report, DateTime year)
        {
            try
            {
                string query = "SELECT * FROM academic.students WHERE year(BIRTHDATE) = '" + year.ToString("yyyy") + "'";
                conn.Open();
                comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                report.DataSource = dt;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in report_YearlyFormat() : " + ex);
            }
        }

        public void report_WeeklyFormat(DataGridView report, DateTime year)
        {
            try
            {
                string query = "SELECT * FROM academic.students WHERE year(BIRTHDATE) = '" + year.ToString("yyyy") + "'";
                conn.Open();
                comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                report.DataSource = dt;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in report_WeeklyFormat() : " + ex);
            }
        }
        #region [SAMPLE Module]
        public void pwd_PDFReport(string file, DataGridView report)
        {
          
            FileStream fs = new FileStream(file, FileMode.Create, FileAccess.ReadWrite);
            Document doc = new Document(PageSize.LETTER, 55, 55, 30, 40);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();

            //logo
            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(SAD_2_PTT.Properties.Resources.pwd, System.Drawing.Imaging.ImageFormat.Jpeg);
            logo.Alignment = Element.ALIGN_LEFT | Element.ALIGN_TOP;
            logo.ScalePercent(40);
            logo.SetAbsolutePosition(72, 72 * 10);
            doc.Add(logo);

            //title
            var titleFont = FontFactory.GetFont("Segoe UI", 14, BaseColor.BLACK);
            var subFont = FontFactory.GetFont("Segoe UI", 10, BaseColor.BLACK);
            Paragraph title = new Paragraph("Lorem Ipsum", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 1;
            doc.Add(title);

            //subtitles
            Paragraph title1 = new Paragraph("In tempus nisl eros, vitae ferm rayin falling from", subFont);
            title1.Alignment = Element.ALIGN_CENTER;
            title1.SpacingAfter = 1;
            doc.Add(title1);

            Paragraph title2 = new Paragraph("consectetur adipiscing elit to meeee", subFont);
            title2.Alignment = Element.ALIGN_CENTER;
            title2.SpacingAfter = 1;
            doc.Add(title2);

            Paragraph title3 = new Paragraph("Lorem Ipsum dolor sit amet", subFont);
            title3.Alignment = Element.ALIGN_CENTER;
            title3.SpacingAfter = 30;
            doc.Add(title3);

            //paragraph text
            var textFont = FontFactory.GetFont("Segoe UI", 12, BaseColor.BLACK);
            Paragraph text = new Paragraph("Lorem ipsum dolor sit amet, consectetur adipiscing elit. In tempus nisl eros, vitae fermentum augue rhoncus ac. Ut faucibus sem metus, et tempor massa ultrices ut. Praesent arcu nisl, tempor et imperdiet quis, venenatis ac arcu. Cras condimentum tincidunt felis a tincidunt. Quisque enim eros, auctor vel nibh non, consequat aliquam arcu. Proin id nibh elit. Pellentesque quis viverra mi. Nunc sed eros eu urna iaculis rhoncus at et magna. Morbi ut eros purus. Duis porttitor rutrum pulvinar.", textFont);
            text.FirstLineIndent = 60;
            text.SpacingAfter = 18;
            text.Alignment = Element.ALIGN_JUSTIFIED | Element.ALIGN_CENTER;
           // doc.Add(text);

            //table
            PdfPTable table = new PdfPTable(report.ColumnCount);
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            table.SetWidths(new int[] { 3, 5, 5, 5, 3, 4, 6 });
            table.WidthPercentage = 98;

            //table header
            var headerFont = FontFactory.GetFont("Segoe UI", 10, BaseColor.WHITE);
            var cellFont = FontFactory.GetFont("Segoe UI", 10);

            foreach (DataGridViewColumn col in report.Columns)
            {
                PdfPCell header = new PdfPCell(new Phrase(col.HeaderText, headerFont));
                header.BackgroundColor = new iTextSharp.text.BaseColor(40, 44, 55);
                header.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(header);
            }

            //table cells
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

            
            var otherInfo = FontFactory.GetFont("Segoe UI", 14);
            int tstudents = table.Rows.Count - 1;
            Paragraph stud = new Paragraph("Total Students: " + tstudents.ToString());
            stud.SpacingBefore = 15;
            doc.Add(stud);

            doc.Close();
            doc.Dispose();

        }
        #endregion
    }
}
