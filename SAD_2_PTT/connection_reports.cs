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
using OfficeOpenXml.Drawing;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using OfficeOpenXml.Style;



namespace SAD_2_PTT
{
    class connection_reports
    {
        public MySqlConnection conn;
        public MySqlCommand comm;
        public MySqlDataReader dr;

        public string age = " DATE_FORMAT(NOW(), '%Y') - DATE_FORMAT(birthdate, '%Y') - (DATE_FORMAT(NOW(), '00-%m-%d') < DATE_FORMAT(birthdate, '00-%m-%d'))";
        public string educ_at = " (CASE WHEN educ_attainment = 1 THEN 'Elementary' WHEN educ_attainment = 2 THEN 'Elementary Undergraduate' WHEN educ_attainment = 3 THEN 'High School' WHEN educ_attainment = 4 THEN 'High School Undergraduate' WHEN educ_attainment = 5 THEN 'College' WHEN educ_attainment = 6 THEN 'College Undergraduate' WHEN educ_attainment = 7 THEN 'Graduate' WHEN educ_attainment = 8 THEN 'Post Graduate' WHEN educ_attainment = 9 THEN 'Vocational' ELSE 'None' END) AS educ_attainment, ";
        public string no = "SET @num = 0; ";
        
        public main_form reference_to_main { get; set; }

        public connection_reports()
        {
            conn = new MySqlConnection("Server=localhost;Database=p_dao;Uid=root;Pwd=root;Allow User Variables=True");
        }

        #region << Methods >>
        public void reportFormat(DataGridView report)
        {
            report.Columns["lastname"].HeaderText = "LAST NAME";
            report.Columns["firstname"].HeaderText = "FIRST NAME";
            report.Columns["birthdate"].HeaderText = "BIRTH DATE";
            report.Columns["address"].HeaderText = "ADDRESS";
            report.Columns["disability_type"].HeaderText = "TYPE OF DISABILITY";
            report.Columns["sex"].HeaderText = "SEX";
            report.Columns["age"].HeaderText = "AGE";
            report.Columns["educ_attainment"].HeaderText = "EDUC. ATTAINMENT";
            report.Columns["num"].HeaderText = "NO.";

            //Column Size
            report.Columns["num"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            report.Columns["age"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            report.Columns["sex"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            report.Columns["birthdate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            report.Columns["num"].Width = report.Columns["age"].Width = report.Columns["sex"].Width = 35;
            report.Columns["birthdate"].Width = 80;
        }
        public void report_gridView(DataGridView report)
        {
            try
            {
                string query = no + "SELECT CONCAT((@num:=@num + 1),'.') AS num, lastname, CONCAT(firstname, ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS firstname," + age + "AS age, (CASE WHEN sex = 0 THEN 'M' ELSE 'F' END) AS sex, date_format(birthdate, '%m/%d/%Y') AS birthdate, " + educ_at+ "address, disability_type FROM p_dao.pwd JOIN p_dao.disability ON pwd.disability_id = disability.disability_id ORDER BY lastname ASC";
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
                conn.Close();
            }
        }

        public void report_customFormat(DataGridView report, DateTime from, DateTime to)
        {
            try
            {
                string query = no + "SELECT CONCAT((@num:=@num + 1),'.') AS num, lastname, CONCAT(firstname,  ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS firstname," + age + "AS age, (CASE WHEN sex = 0 THEN 'M' ELSE 'F' END) AS sex, date_format(birthdate, '%m/%d/%Y') AS birthdate, " +educ_at+ "address, disability_type FROM p_dao.pwd JOIN p_dao.disability ON pwd.disability_id = disability.disability_id WHERE application_date BETWEEN '" + from.ToString("yyyy-MM-dd") + "' AND '" + to.ToString("yyyy-MM-dd") + "' ORDER BY lastname ASC";
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
                conn.Close();
            }
        }

        public void report_MonthlyFormat(DataGridView report, DateTime month, DateTime year)
        {
            try
            {
                string query = no + "SELECT CONCAT((@num:=@num + 1),'.') AS num, lastname, CONCAT(firstname,  ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS firstname " + age + "AS age, (CASE WHEN sex = 0 THEN 'M' ELSE 'F' END) AS sex, date_format(birthdate, '%m/%d/%Y') AS birthdate," + educ_at +" address, disability_type FROM p_dao.pwd JOIN p_dao.disability ON pwd.disability_id = disability.disability_id WHERE month(application_date) = '" + month.ToString("MM") + "' AND year(application_date) = '" + year.ToString("yyyy") + "' ORDER BY lastname ASC";
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
                conn.Close();
            }
        }

        public void report_YearlyFormat(DataGridView report, DateTime year)
        {
            try
            { 
                string query = no + "SELECT CONCAT((@num:=@num + 1),'.') AS num, lastname, CONCAT(firstname,  ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS firstname, " + age + "AS age, (CASE WHEN sex = 0 THEN 'M' ELSE 'F' END) AS sex, date_format(birthdate, '%m/%d/%Y') AS birthdate," + educ_at + " address, disability_type FROM p_dao.pwd JOIN p_dao.disability ON pwd.disability_id = disability.disability_id WHERE year(application_date) = '" + year.ToString("yyyy") + "' ORDER BY lastname ASC";
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
                conn.Close();
            }
        }

        public void report_WeeklyFormat(DataGridView report, DateTime year)
        {
            try
            {
                string query = "";
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
                conn.Close();
            }
        }
        #endregion

        #region <-- MASTERLIST --> [Print]

        #endregion

        #region  <-- MASTERLIST --> [Export PDF]
        public void pwd_PDFReport(string file, DataGridView report)
        {
          
            FileStream fs = new FileStream(file, FileMode.Create, FileAccess.ReadWrite);
            Document doc = new Document(PageSize.LETTER,30,30,30,30);
            doc.SetPageSize(PageSize.LETTER.Rotate());
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();

            //logo
            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(SAD_2_PTT.Properties.Resources.pwd, System.Drawing.Imaging.ImageFormat.Jpeg);
            logo.Alignment = Element.ALIGN_LEFT | Element.ALIGN_TOP;
            logo.ScalePercent(40);
            logo.SetAbsolutePosition(10,1000);
            doc.Add(logo);

            //title
            var titleFont = FontFactory.GetFont("Segoe UI", 14, iTextSharp.text.Font.BOLD ,BaseColor.BLACK);
            var subFont = FontFactory.GetFont("Segoe UI", 10, BaseColor.BLACK);
            Paragraph title = new Paragraph("MASTERLIST OF PERSONS WITH DISABILITIES WHO AVAIL PWD ID", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 1;
            doc.Add(title);

            //district
            Paragraph title4 = new Paragraph("SAMPLE DISTRICT", subFont);
            title4.Alignment = Element.ALIGN_LEFT | Element.ALIGN_TOP;
            title4.SpacingAfter = 20;
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
            table.WidthPercentage = 100;
            int[] width = {1, 4, 4, 2, 1, 4, 5, 5, 4};
            table.SetWidths(width);
            

            //table header
            var headerFont = FontFactory.GetFont("Segoe UI", 10, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
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
                    cell.VerticalAlignment = Element.ALIGN_JUSTIFIED;
                    table.AddCell(cell);
                }
            }

            doc.Add(table);

            //other information
            var otherInfo = FontFactory.GetFont("Segoe UI", 14);
            int t_pwd = table.Rows.Count - 1;
            Paragraph pwd = new Paragraph("Total PWD Members: " + t_pwd.ToString());
            pwd.SpacingBefore = 15;
            //doc.Add(pwd);

            doc.Close();
            doc.Dispose();
            doc = null;

        }

        #endregion

        #region <-- CONSOLIDATED REPORTS --> [Export Excel]
        public void pwd_ExcelReport(string file)
        {
            string[] district = { "AGDAO", "BAGUIO", "BUHANGIN", "BUNAWAN", "CALINAN", "CITY-A", "CITY-B", "MARILOG", "PAQUIBATO", "TALOMO-A", "TALOMO-B", "TORIL", "TUGBOK" };
            ExcelPackage exc = new ExcelPackage();
            ExcelWorksheet wsheet = exc.Workbook.Worksheets.Add("Sheet1");

            #region Styles
            //Font
            wsheet.Cells.Style.Font.Size = 12;
            wsheet.Cells.Style.Font.Name = "Calibri";

            //Table [SCAM]
            wsheet.Cells[4, 1, 20, 17].Style.Border.BorderAround(ExcelBorderStyle.Thick);
            wsheet.Cells[4, 2, 19, 3].Style.Border.BorderAround(ExcelBorderStyle.Thick);
            wsheet.Cells[4, 4, 19, 5].Style.Border.BorderAround(ExcelBorderStyle.Thick);
            wsheet.Cells[4, 6, 19, 7].Style.Border.BorderAround(ExcelBorderStyle.Thick);
            wsheet.Cells[4, 8, 19, 9].Style.Border.BorderAround(ExcelBorderStyle.Thick);
            wsheet.Cells[4, 10, 19, 11].Style.Border.BorderAround(ExcelBorderStyle.Thick);
            wsheet.Cells[4, 12, 19, 13].Style.Border.BorderAround(ExcelBorderStyle.Thick);
            wsheet.Cells[4, 14, 19, 15].Style.Border.BorderAround(ExcelBorderStyle.Thick);
            wsheet.Cells[4, 16, 19, 17].Style.Border.BorderAround(ExcelBorderStyle.Thick);

            //Title
            var title = wsheet.Cells["A1:Q1"];
            title.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            title.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            title.Style.Font.Bold = true;
            title.Merge = true;
            title.Style.Font.Size = 14;

            //SubTitle
            var subDate = wsheet.Cells["A2:Q2"];
            subDate.Merge = true;
            subDate.Style.Font.Bold = true;
            subDate.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            subDate.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            subDate.Style.Font.Size = 13;

            var subCat = wsheet.Cells["A3:Q3"];
            subCat.Merge = true;
            subCat.Style.Font.Bold = true;
            subCat.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            subCat.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            subCat.Style.Font.Size = 13;
          
            //District Row
            var disTitle = wsheet.Cells["A4:A5"];
            disTitle.Style.Border.BorderAround(ExcelBorderStyle.Thick);
            disTitle.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            disTitle.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            disTitle.Style.Font.Bold = true;
            wsheet.Row(4).Height = 28;

            var districts = wsheet.Cells["A6:A18"];
            districts.Style.Border.Left.Style = districts.Style.Border.Right.Style = ExcelBorderStyle.Thick;
            wsheet.Column(1).Width = 14;
            
            //Headers
            wsheet.Cells["B4:C4"].Merge = true;
            wsheet.Cells["D4:E4"].Merge = true;
            wsheet.Cells["F4:G4"].Merge = true;
            wsheet.Cells["H4:I4"].Merge = true;
            wsheet.Cells["J4:K4"].Merge = true;
            wsheet.Cells["L4:M4"].Merge = true;
            wsheet.Cells["N4:O4"].Merge = true;
            wsheet.Cells["P4:Q4"].Merge = true;
            var header = wsheet.Cells["B4:Q4"];
            header.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            header.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            header.Style.Border.BorderAround(ExcelBorderStyle.Thick);
            header.Style.Font.Bold = true;

            //SubHeaders
            wsheet.Cells["B5:Q5"].Style.Font.Bold = true;

            //Total
            wsheet.Cells["A19:Q20"].Style.Font.Bold = true;
            wsheet.Cells["A19"].Style.Border.Right.Style = ExcelBorderStyle.Thick;

            //GrandTotal
            wsheet.Cells["B20:Q20"].Merge = true;
            wsheet.Cells["B20:Q20"].Style.Font.Bold = true;
            wsheet.Cells["B20:Q20"].Style.Border.BorderAround(ExcelBorderStyle.Thick);
            wsheet.Cells["A20"].Style.Font.Bold = true;
            wsheet.Cells["A20"].Style.Border.Right.Style = ExcelBorderStyle.Thick;
            #endregion

            //Title
            wsheet.Cells["A1:Q1"].Value = "CONSOLIDATED REPORT ON PWD ISSUED WITH ID'S";

            //SubTitle
            wsheet.Cells["A3:Q3"].Value = "(CHILDREN & ADULT CATEGORY)";

            //District Columns
            wsheet.Cells["A4:A5"].Merge = true;
            wsheet.Cells["A4:A5"].Value = "DISTRICT";
            wsheet.Cells["A6"].LoadFromCollection(district);

            //Headers
            wsheet.Cells["B4:C4"].Value = "0-2 YRS. OLD";
            wsheet.Cells["D4:E4"].Value = "3-4 YRS. OLD";
            wsheet.Cells["F4:G4"].Value = "5-6 YRS. OLD";
            wsheet.Cells["H4:I4"].Value = "7-12 YRS. OLD";
            wsheet.Cells["J4:K4"].Value = "13-18 YRS. OLD";
            wsheet.Cells["L4:M4"].Value = "19-24 YRS. OLD";
            wsheet.Cells["N4:O4"].Value = "25-59 YRS. OLD";
            wsheet.Cells["P4:Q4"].Value = "60 YRS. OLD";

            //SubHeaders [M,F]
            

            //Total
            wsheet.Cells["A19"].Value = "TOTAL";
            //GrandTotal
            wsheet.Cells["A20"].Value = "GRAND TOTAL";

            using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.ReadWrite))
            {
                exc.SaveAs(fs);
            }

            System.Diagnostics.Process.Start(file); // to open document directly after creating PDF
        }

        public List<int> Agdao;
        public List<int> Baguio;
        public List<int> Buhangin;
        public List<int> Bunawan;
        public List<int> Calinan;
        public List<int> CityA;
        public List<int> CityB;
        public List<int> Marilog;
        public List<int> Paquibato;
        public List<int> TalomoA;
        public List<int> TalomoB;
        public List<int> Toril;
        public List<int> Tugbok;

        public void pwd_Agdao()
        {
            int result;
            string cm1, cm2, cm3, cm4, cm5, cm6, cm7, cm8;
            string cf1, cf2, cf3, cf4, cf5, cf6, cf7, cf8;
            string select = "SELECT COUNT(" + age + ") AS c FROM p_dao.pwd WHERE ";

            cm1 = select + age + " BETWEEN '0' AND '2' AND sex = '0';";
            cf1 = select + age + " BETWEEN '0' AND '2' AND sex = '1';";
            cm2 = select + age + " BETWEEN '3' AND '4' AND sex = '0';";
            cf2 = select + age + " BETWEEN '3' AND '4' AND sex = '1';";
            cm3 = select + age + " BETWEEN '5' AND '6' AND sex = '0';";
            cf3 = select + age + " BETWEEN '5' AND '6' AND sex = '1';";
            cm4 = select + age + " BETWEEN '7' AND '12' AND sex = '0';";
            cf4 = select + age + " BETWEEN '7' AND '12' AND sex = '1';";
            cm5 = select + age + " BETWEEN '13' AND '18' AND sex = '0';";
            cf5 = select + age + " BETWEEN '13' AND '18' AND sex = '1';";
            cm6 = select + age + " BETWEEN '19' AND '24' AND sex = '0';";
            cf6 = select + age + " BETWEEN '19' AND '24' AND sex = '1';";
            cm7 = select + age + " BETWEEN '25' AND '59' AND sex = '0';";
            cf7 = select + age + " BETWEEN '25' AND '59' AND sex = '1';";
            cm8 = select + age + " = '60' AND sex = '0';";
            cf8 = select + age + " = '60' AND sex = '1'";
            try
            {
                
                conn.Open();
                comm = new MySqlCommand(cm1+cf1+cm2+cf2+cm3+cf3+cm4+cf4+cm5+cf5+cm6+cf6+cm7+cf7+cm8+cf8, conn);
                dr = comm.ExecuteReader();
                do
                {
                    while (dr.Read())
                    {
                        result = dr.GetInt32(0);
                        MessageBox.Show(result.ToString());

                        Agdao = new List<int>();
                        Agdao.Add(result);
                        Agdao.ForEach(Console.WriteLine);
                    }
                } while (dr.NextResult());


                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in pwd_Agdao() : " + ex);
                conn.Close();
            }
        }

        public void pwd_Baguio()
        {

        }

        public void pwd_Buhangin()
        {

        }
        public void pwd_Calinan()
        {

        }
        public void pwd_City_A()
        {

        }

        public void pwd_City_B()
        {

        }

        public void pwd_Marilog()
        {

        }

        public void pwd_Paquibato()
        {

        }

        public void pwd_Talomo_A()
        {

        }

        public void pwd_Talomo_B()
        {

        }

        public void pwd_Toril()
        {

        }

        public void pwd_Tugbok()
        {

        }
        #endregion

        
        

    }
}
