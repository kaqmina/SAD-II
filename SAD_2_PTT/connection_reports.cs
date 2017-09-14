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
        public string age = " DATE_FORMAT(NOW(), '%Y') - DATE_FORMAT(birthdate, '%Y') - (DATE_FORMAT(NOW(), '00-%m-%d') < DATE_FORMAT(birthdate, '00-%m-%d')) AS age,";
        public string educ_at = " (CASE WHEN educ_attainment = 1 THEN 'Elementary' WHEN educ_attainment = 2 THEN 'Elementary Undergraduate' WHEN educ_attainment = 3 THEN 'High School' WHEN educ_attainment = 4 THEN 'High School Undergraduate' WHEN educ_attainment = 5 THEN 'College' WHEN educ_attainment = 6 THEN 'College Undergraduate' WHEN educ_attainment = 7 THEN 'Graduate' WHEN educ_attainment = 8 THEN 'Post Graduate' WHEN educ_attainment = 9 THEN 'Vocational' ELSE 'None' END) AS educ_attainment, ";

        public main_form reference_to_main { get; set; }

        public connection_reports()
        {
            conn = new MySqlConnection("Server=localhost;Database=p_dao;Uid=root;Pwd=root;Allow User Variables=True");
        }

        public void reportFormat(DataGridView report)
        {
            report.Columns["lastname"].HeaderText = "LAST NAME";
            report.Columns["firstname"].HeaderText = "FIRST NAME";
            report.Columns["birthdate"].HeaderText = "BIRTH DATE";
            report.Columns["address"].HeaderText = "ADDRESS";
            report.Columns["disability_type"].HeaderText = "TYPE OF DISABILITY";
            report.Columns["sex"].HeaderText = "SEX";
            //report.Columns["application_date"].Visible = false;
            report.Columns["age"].HeaderText = "AGE";
            report.Columns["educ_attainment"].HeaderText = "EDUC. ATTAINMENT";
        }
        public void report_gridView(DataGridView report)
        {
            try
            {
               
                string query = "SELECT lastname, firstname," + age + " (CASE WHEN sex = 0 THEN 'M' ELSE 'F' END) AS sex, date_format(birthdate, '%m/%d/%Y') AS birthdate, " +educ_at+ "address, disability_type FROM p_dao.pwd JOIN p_dao.disability ON pwd.disability_id = disability.disability_id ";
                conn.Open();
                comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                report.DataSource = dt;
                reportFormat(report);

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
                string query = "SELECT application_date, lastname, firstname," + age + " (CASE WHEN sex = 0 THEN 'M' ELSE 'F' END) AS sex, date_format(birthdate, '%m/%d/%Y') AS birthdate, " +educ_at+ "address, disability_type FROM p_dao.pwd JOIN p_dao.disability ON pwd.disability_id = disability.disability_id WHERE application_date BETWEEN '" + from.ToString("yyyy-MM-dd") + "' AND '" + to.ToString("yyyy-MM-dd") + "' (SELECT @n := 0) AS n ";
                //string query = "SELECT (@n:=@n+1) NO., STUDENTCODE, LASTNAME, FIRSTNAME, MIDDLENAME, GENDER, date_format(BIRTHDATE, '%d/%m /%Y') AS BIRTHDATE, ADDRESS FROM academic.students WHERE BIRTHDATE BETWEEN '" + from.ToString("yyyy-MM-dd") +"' AND '"+ to.ToString("yyyy-MM-dd") + "' (SELECT @n := 0) AS n";
                conn.Open();
                comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                report.DataSource = dt;
                reportFormat(report);
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
                //string query = "SELECT (@n:=@n+1) NO., STUDENTCODE, LASTNAME, FIRSTNAME, MIDDLENAME, GENDER, date_format(BIRTHDATE, '%d/%m /%Y') AS BIRTHDATE, ADDRESS FROM academic.students WHERE month(BIRTHDATE) = '" + month.ToString("MM") +"' AND year(BIRTHDATE) = '" + year.ToString("yyyy") + "' (SELECT @n := 0) AS n";
                string query = "SELECT application_date, lastname, firstname," + age + " (CASE WHEN sex = 0 THEN 'M' ELSE 'F' END) AS sex, date_format(birthdate, '%m/%d/%Y') AS birthdate,"+ educ_at +" address, disability_type FROM p_dao.pwd JOIN p_dao.disability ON pwd.disability_id = disability.disability_id WHERE month(application_date) = '" + month.ToString("MM") + "' AND year(application_date) = '" + year.ToString("yyyy") + "'";
                conn.Open();
                comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                report.DataSource = dt;
                reportFormat(report);
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
                //string query = "SELECT (@n:=@n+1) NO., STUDENTCODE, LASTNAME, FIRSTNAME, MIDDLENAME, GENDER, date_format(BIRTHDATE, '%d/%m /%Y') AS BIRTHDATE, ADDRESS  FROM academic.students WHERE year(BIRTHDATE) = '" + year.ToString("yyyy") + "' (SELECT @n := 0) AS n";
                string query = "SELECT application_date, lastname, firstname," + age + " (CASE WHEN sex = 0 THEN 'M' ELSE 'F' END) AS sex, date_format(birthdate, '%m/%d/%Y') AS birthdate," + educ_at + " address, disability_type FROM p_dao.pwd JOIN p_dao.disability ON pwd.disability_id = disability.disability_id WHERE year(application_date) = '" + year.ToString("yyyy") + "'";

                conn.Open();
                comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                report.DataSource = dt;
                reportFormat(report);
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
                string query = "SELECT STUDENTCODE, LASTNAME, FIRSTNAME, MIDDLENAME, GENDER, date_format(BIRTHDATE, '%d/%m/%Y') AS BIRTHDATE, ADDRESS  FROM academic.students WHERE year(BIRTHDATE) = '" + year.ToString("yyyy") + "'";
                conn.Open();
                comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                report.DataSource = dt;
                reportFormat(report);
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
            Document doc = new Document(PageSize.LETTER);
            doc.SetPageSize(PageSize.LETTER.Rotate());
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();

            //logo
            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(SAD_2_PTT.Properties.Resources.pwd, System.Drawing.Imaging.ImageFormat.Jpeg);
            logo.Alignment = Element.ALIGN_LEFT | Element.ALIGN_TOP;
            logo.ScalePercent(40);
            logo.SetAbsolutePosition(72, 72 * 10);
            doc.Add(logo);

            //title
            var titleFont = FontFactory.GetFont("Segoe UI", 14, iTextSharp.text.Font.BOLD ,BaseColor.BLACK);
            var subFont = FontFactory.GetFont("Segoe UI", 10, BaseColor.BLACK);
            Paragraph title = new Paragraph("MASTERLIST OF PERSONS WITH DISABILITIES WHO AVAIL PWD ID", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 1;
            doc.Add(title);

            //subtitles
            Paragraph title1 = new Paragraph("In tempus nisl eros, vitae ferm rayin falling from", subFont);
            title1.Alignment = Element.ALIGN_LEFT;
            title1.SpacingAfter = 1;
            //doc.Add(title1);

            Paragraph title2 = new Paragraph("consectetur adipiscing elit to meeee", subFont);
            title2.Alignment = Element.ALIGN_CENTER;
            title2.SpacingAfter = 1;
            //doc.Add(title2);

            Paragraph title3 = new Paragraph("Lorem Ipsum dolor sit amet", subFont);
            title3.Alignment = Element.ALIGN_CENTER;
            title3.SpacingAfter = 30;
            //doc.Add(title3);

            //district
            Paragraph title4 = new Paragraph("Lorem Ipsum dolor sit amet", subFont);
            title4.Alignment = Element.ALIGN_LEFT | Element.ALIGN_TOP;
            title4.SpacingAfter = 30;
            doc.Add(title4);

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

            //other information
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
