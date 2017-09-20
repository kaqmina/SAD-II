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
        public sample_report report { get; set; }

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
                string query = no + "SELECT CONCAT((@num:=@num + 1),'.') AS num, lastname, CONCAT(firstname, ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS firstname," + age + "AS age, (CASE WHEN sex = 0 THEN 'M' ELSE 'F' END) AS sex, date_format(birthdate, '%m/%d/%Y') AS birthdate, " + educ_at + "address, disability_type FROM p_dao.pwd JOIN p_dao.disability ON pwd.disability_id = disability.disability_id ORDER BY lastname ASC";
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
                string query = no + "SELECT CONCAT((@num:=@num + 1),'.') AS num, lastname, CONCAT(firstname,  ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS firstname," + age + "AS age, (CASE WHEN sex = 0 THEN 'M' ELSE 'F' END) AS sex, date_format(birthdate, '%m/%d/%Y') AS birthdate, " + educ_at + "address, disability_type FROM p_dao.pwd JOIN p_dao.disability ON pwd.disability_id = disability.disability_id WHERE application_date BETWEEN '" + from.ToString("yyyy-MM-dd") + "' AND '" + to.ToString("yyyy-MM-dd") + "' ORDER BY lastname ASC";
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
                string query = no + "SELECT CONCAT((@num:=@num + 1),'.') AS num, lastname, CONCAT(firstname,  ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS firstname " + age + "AS age, (CASE WHEN sex = 0 THEN 'M' ELSE 'F' END) AS sex, date_format(birthdate, '%m/%d/%Y') AS birthdate," + educ_at + " address, disability_type FROM p_dao.pwd JOIN p_dao.disability ON pwd.disability_id = disability.disability_id WHERE month(application_date) = '" + month.ToString("MM") + "' AND year(application_date) = '" + year.ToString("yyyy") + "' ORDER BY lastname ASC";
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
        public List<string> disability;
        public int disability_count;
        public void getDisability()
        {
            comm = new MySqlCommand("SELECT disability_type, COUNT(disability_type) FROM p_dao.disability", conn);
            string dis;
            disability = new List<string>();
            try
            {
                conn.Open();
                dr = comm.ExecuteReader();
                do
                {
                    while (dr.Read())
                    {
                        dis = dr.GetString("disability_type");
                        disability_count = dr.GetInt32("COUNT(disability_type)");
                        if (dis == "") MessageBox.Show("No disabilities added.");
                        else disability.Add(dr.GetString(dis));
                    }
                } while (dr.NextResult());
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in getDisability() : " + ex);
                conn.Close();
            }
        }
        #endregion

        #region <-- MASTERLIST --> [Print]
        public void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            System.Drawing.Font bodyFont = new System.Drawing.Font("Calibri", 12, System.Drawing.FontStyle.Regular);
            System.Drawing.Font titleFont = new System.Drawing.Font("Calibri", 14, System.Drawing.FontStyle.Bold);

            string title = "MASTERLIST OF PERSONS WITH DISABILITIES WHO AVAIL PWD ID";
            e.Graphics.DrawString(title, titleFont, System.Drawing.Brushes.Black, 10, 10);
            foreach (DataGridViewColumn column in report.report_grid.Columns)
            {

            }
        }
        #endregion

        #region  <-- MASTERLIST --> [Export PDF]
        public void pwd_PDFReport(string file, DataGridView report)
        {

            FileStream fs = new FileStream(file, FileMode.Create, FileAccess.ReadWrite);
            Document doc = new Document(PageSize.LETTER, 30, 30, 30, 30);
            doc.SetPageSize(PageSize.LETTER.Rotate());
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();

            //logo
            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(SAD_2_PTT.Properties.Resources.pwd, System.Drawing.Imaging.ImageFormat.Jpeg);
            logo.Alignment = Element.ALIGN_LEFT | Element.ALIGN_TOP;
            logo.ScalePercent(40);
            logo.SetAbsolutePosition(10, 1000);
            doc.Add(logo);

            //title
            var titleFont = FontFactory.GetFont("Segoe UI", 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
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
            int[] width = { 1, 4, 4, 2, 1, 4, 5, 5, 4 };
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
            string[] ageBracket = { "0-2 YRS. OLD", "3-4 YRS. OLD", "5-6 YRS. OLD", "7-12 YRS. OLD", "13-18 YRS. OLD", "19-24 YRS. OLD", "25-59 YRS. OLD", "60 YRS. OLD" };
            string[] district = { "AGDAO", "BAGUIO", "BUHANGIN", "BUNAWAN", "CALINAN", "CITY-A", "CITY-B", "MARILOG", "PAQUIBATO", "TALOMO-A", "TALOMO-B", "TORIL", "TUGBOK" };
            string[] gender = { "M", "F", "M", "F", "M", "F", "M", "F", "M", "F", "M", "F", "M", "F", "M", "F" };
        
            ExcelPackage exc = new ExcelPackage();
            ExcelWorksheet wsheet = exc.Workbook.Worksheets.Add("Sheet1");
            ExcelWorksheet wschild = exc.Workbook.Worksheets.Add("Sheet2");
            ExcelWorksheet wsadult = exc.Workbook.Worksheets.Add("Sheet3");

            #region Styles
            //Font
            wsheet.Cells.Style.Font.Size = wschild.Cells.Style.Font.Size = wsadult.Cells.Style.Font.Size = 12;
            wsheet.Cells.Style.Font.Name = wschild.Cells.Style.Font.Name = wsadult.Cells.Style.Font.Name = "Calibri";

            //Table [SCAM]
            wsheet.Cells[4, 1, 20, 17].Style.Border.BorderAround(ExcelBorderStyle.Thick);
            wschild.Cells[4, 1, 20, 17].Style.Border.BorderAround(ExcelBorderStyle.Thick);
            wsadult.Cells[4, 1, 20, 17].Style.Border.BorderAround(ExcelBorderStyle.Thick);

            getDisability();
            for (int j = 1; j < 17; j++) wsheet.Cells[4, j, 19, j++].Style.Border.BorderAround(ExcelBorderStyle.Thick);
           // for (int j = 1; j < 17; j++) wsadult.Cells[4, j, 19, j++].Style.Border.BorderAround(ExcelBorderStyle.Thick);
           // for (int j = 1; j < 17; j++) wschild.Cells[4, j, 19, j++].Style.Border.BorderAround(ExcelBorderStyle.Thick);
            for (int j = 16; j < disability_count; j++) // 26 - count of disability + 1
            {
                int k = j + 1;
                wsheet.Cells[4, j, 19, k].Style.Border.BorderAround(ExcelBorderStyle.Thick);
            }
            
            //Title
            var title = wsheet.Cells["A1:Q1"];
            title.Style.HorizontalAlignment = wschild.Cells["A1:Q1"].Style.HorizontalAlignment = wsadult.Cells["A1:Q1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            title.Style.Font.Bold = wschild.Cells["A1:Q1"].Style.Font.Bold = wsadult.Cells["A1:Q1"].Style.Font.Bold = true;
            title.Merge = wschild.Cells["A1:Q1"].Merge = wsadult.Cells["A1:Q1"].Merge = true;
            title.Style.Font.Size = wschild.Cells["A1:Q1"].Style.Font.Size = wsadult.Cells["A1:Q1"].Style.Font.Size = 14;

            //SubTitle
            var subDate = wsheet.Cells["A2:Q2"];
            subDate.Merge = wschild.Cells["A2:Q2"].Merge = wsadult.Cells["A2:Q2"].Merge = true;
            subDate.Style.Font.Bold = wschild.Cells["A2:Q2"].Style.Font.Bold = wsadult.Cells["A2:Q2"].Style.Font.Bold = true;
            subDate.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            subDate.Style.HorizontalAlignment = wschild.Cells["A2:Q2"].Style.HorizontalAlignment = wsadult.Cells["A2:Q2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            subDate.Style.Font.Size = 13;

            var subCat = wsheet.Cells["A3:Q3"];
            subCat.Merge = wschild.Cells["A3:Q3"].Merge = wsadult.Cells["A3:Q3"].Merge = true;
            subCat.Style.Font.Bold = wschild.Cells["A3:Q3"].Style.Font.Bold = wsadult.Cells["A3:Q3"].Style.Font.Bold = true;
            subCat.Style.HorizontalAlignment = wschild.Cells["A3:Q3"].Style.HorizontalAlignment = wsadult.Cells["A3:Q3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            subCat.Style.Font.Size = wschild.Cells["A3:Q3"].Style.Font.Size = wsadult.Cells["A3:Q3"].Style.Font.Size = subDate.Style.Font.Size;

            //District Row
            var disTitle = wsheet.Cells["A4:A5"];
            disTitle.Style.Border.BorderAround(ExcelBorderStyle.Thick);
            disTitle.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            disTitle.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            disTitle.Style.Font.Bold = true;
            wsheet.Row(4).Height = 28;

            var districts = wsheet.Cells["A6:A18"];
            districts.Style.Border.Left.Style = districts.Style.Border.Right.Style = ExcelBorderStyle.Thick;
            wsheet.Column(1).Width = 16;

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
            //for (int l = 16; i < disability_count; i++) wschild.Cells[4, l += 2].Merge = true;

            //SubHeaders
            wsheet.Cells["B5:Q5"].Style.Font.Bold = true;
            wsheet.Cells["B5:Q5"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            //va;ues
            wsheet.Cells[6, 2, 19, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            //Total
            wsheet.Cells["A19:Q20"].Style.Font.Bold = true;
            wsheet.Cells["A19"].Style.Border.Right.Style = ExcelBorderStyle.Thick;

            //GrandTotal
            wsheet.Cells["B20:Q20"].Merge = wschild.Cells["B20:Q20"].Merge = wsadult.Cells["B20:Q20"].Merge = true;
            wsheet.Cells["B20:Q20"].Style.Font.Bold = wschild.Cells["B20:Q20"].Style.Font.Bold = wsadult.Cells["B20:Q20"].Style.Font.Bold = true;
            wsheet.Cells["B20:Q20"].Style.Border.BorderAround(ExcelBorderStyle.Thick);
            wsheet.Cells["A20"].Style.Font.Bold = wschild.Cells["A20"].Style.Font.Bold = wsadult.Cells["A20"].Style.Font.Bold = true;
            wsheet.Cells["A20"].Style.Border.Right.Style = ExcelBorderStyle.Thick;
            wsheet.Cells["B20"].Style.HorizontalAlignment = wschild.Cells["B20"].Style.HorizontalAlignment = wsadult.Cells["B20"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            #endregion

            #region Sheet Format
            //Title
            wsheet.Cells["A1:Q1"].Value = "CONSOLIDATED REPORT ON PWD ISSUED WITH ID'S";
            wschild.Cells["A1:Q1"].Value = wsheet.Cells["A1:Q1"].Value;
            wsadult.Cells["A1:Q1"].Value = wsheet.Cells["A1:Q1"].Value;

            //SubTitle
            wsheet.Cells["A2:Q2"].Value = wschild.Cells["A2:Q2"].Value = wsadult.Cells["A2:Q2"].Value = "*INSERT DATE HERE*";
            wsheet.Cells["A3:Q3"].Value = "(CHILDREN & ADULT CATEGORY)";
            wschild.Cells["A3:Q3"].Value = "(CHILD CATEGORY)";
            wsadult.Cells["A3:Q3"].Value = "(ADULT CATEGORY)";

            //District Columns
            wsheet.Cells["A4:A5"].Merge = wschild.Cells["A4:A5"].Merge = wsadult.Cells["A4:A5"].Merge =  true;
            wsheet.Cells["A4:A5"].Value = wschild.Cells["A4:A5"].Value = wsadult.Cells["A4:A5"].Value = "DISTRICT";
            wsheet.Cells["A6"].LoadFromCollection(district);
            wschild.Cells["A6"].LoadFromCollection(district);
            wsadult.Cells["A6"].LoadFromCollection(district);
            wsadult.Cells["A6"].LoadFromDataReader(dr, false, "disability");

            //Headers
            getDisability();
            int i = 0;
            foreach (var age in ageBracket) wsheet.Cells[4, i = i + 2].Value = age;
            foreach (var type in disability) wschild.Cells[4, i += 2].Value = type;
           
            //SubHeaders [M,F]
            int a = 2;
            foreach (var sex in gender) wsheet.Cells[5, a++].Value = sex;
            a = 2;
            foreach(var sex in gender) wschild.Cells[5, a++].Value = sex;
            a = 2;
            foreach(var sex in gender) wsadult.Cells[5, a++].Value = sex;

            // Body
            #region << Values >>
            #region -- Sheet1 --
            pwd_Districts();
            int b = 2;
            foreach (var num in Agdao) wsheet.Cells[6, b++].Value = num;
            b = 2;
            foreach (var num in Baguio) wsheet.Cells[7, b++].Value = num;
            b = 2;
            foreach (var num in Buhangin) wsheet.Cells[8, b++].Value = num;
            b = 2;
            foreach (var num in Bunawan) wsheet.Cells[9, b++].Value = num;
            b = 2;
            foreach (var num in Calinan) wsheet.Cells[10, b++].Value = num;
            b = 2;
            foreach (var num in CityA) wsheet.Cells[11, b++].Value = num;
            b = 2;
            foreach (var num in CityB) wsheet.Cells[12, b++].Value = num;
            b = 2;
            foreach (var num in Marilog) wsheet.Cells[13, b++].Value = num;
            b = 2;
            foreach (var num in Paquibato) wsheet.Cells[14, b++].Value = num;
            b = 2;
            foreach (var num in TalomoA) wsheet.Cells[15, b++].Value = num;
            b = 2;
            foreach (var num in TalomoB) wsheet.Cells[16, b++].Value = num;
            b = 2;
            foreach (var num in Toril) wsheet.Cells[17, b++].Value = num;
            b = 2;
            foreach (var num in Tugbok) wsheet.Cells[18, b++].Value = num;

            Agdao.Clear(); Baguio.Clear(); Buhangin.Clear(); Bunawan.Clear(); Calinan.Clear(); CityA.Clear();
            CityB.Clear(); Marilog.Clear(); Paquibato.Clear(); TalomoA.Clear(); TalomoB.Clear(); Toril.Clear(); Tugbok.Clear();
            #endregion
            #region -- Sheet2 --
            #endregion
            #region -- Sheet3 -- 
            #endregion
            #endregion

            //Total
            #region  << Per *Column* Formula >>
            wsheet.Cells["B19"].Formula = wschild.Cells["B19"].Formula = wsadult.Cells["B19"].Formula = "=SUM(B6:B18)";
            wsheet.Cells["C19"].Formula = wschild.Cells["C19"].Formula = wsadult.Cells["C19"].Formula = "=SUM(C6:C18)";
            wsheet.Cells["D19"].Formula = wschild.Cells["D19"].Formula = wsadult.Cells["D19"].Formula = "=SUM(D6:D18)";
            wsheet.Cells["E19"].Formula = wschild.Cells["E19"].Formula = wsadult.Cells["E19"].Formula = "=SUM(E6:E18)";
            wsheet.Cells["F19"].Formula = wschild.Cells["F19"].Formula = wsadult.Cells["F19"].Formula = "=SUM(F6:F18)";
            wsheet.Cells["G19"].Formula = wschild.Cells["G19"].Formula = wsadult.Cells["G19"].Formula = "=SUM(G6:G18)";
            wsheet.Cells["H19"].Formula = wschild.Cells["H19"].Formula = wsadult.Cells["H19"].Formula = "=SUM(H6:H18)";
            wsheet.Cells["I19"].Formula = wschild.Cells["I19"].Formula = wsadult.Cells["I19"].Formula = "=SUM(I6:I18)";
            wsheet.Cells["J19"].Formula = wschild.Cells["J19"].Formula = wsadult.Cells["J19"].Formula = "=SUM(J6:J18)";
            wsheet.Cells["K19"].Formula = wschild.Cells["K19"].Formula = wsadult.Cells["K19"].Formula = "=SUM(K6:K18)";
            wsheet.Cells["L19"].Formula = wschild.Cells["L19"].Formula = wsadult.Cells["L19"].Formula = "=SUM(L6:L18)";
            wsheet.Cells["M19"].Formula = wschild.Cells["M19"].Formula = wsadult.Cells["M19"].Formula = "=SUM(M6:M18)";
            wsheet.Cells["N19"].Formula = wschild.Cells["N19"].Formula = wsadult.Cells["N19"].Formula = "=SUM(N6:N18)";
            wsheet.Cells["O19"].Formula = wschild.Cells["O19"].Formula = wsadult.Cells["O19"].Formula = "=SUM(O6:O18)";
            wsheet.Cells["P19"].Formula = wschild.Cells["P19"].Formula = wsadult.Cells["P19"].Formula = "=SUM(P6:P18)";
            wsheet.Cells["Q19"].Formula = wschild.Cells["Q19"].Formula = wsadult.Cells["Q19"].Formula = "=SUM(Q6:Q18)";
            #endregion

            wsheet.Cells["A19"].Value = wschild.Cells["A19"].Value = wsadult.Cells["A19"].Value = "TOTAL";

            //GrandTotal
            wsheet.Cells["B20"].Formula = wschild.Cells["B20"].Formula = wsadult.Cells["B20"].Formula = "=SUM(B19:Q19)";
            wsheet.Cells["A20"].Value = wschild.Cells["A20"].Value = wsadult.Cells["A20"].Value = "GRAND TOTAL";
            #endregion

            using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.ReadWrite))
            {
                exc.SaveAs(fs);
            }

            System.Diagnostics.Process.Start(file); // to open document directly after creating EXCEL
        }

        #region << Districts >>
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
        

        public string[] ageQuery = { " BETWEEN 0 AND 2 AND sex = 0", " BETWEEN 0 AND 2 AND sex = 1", " BETWEEN 3 AND 4 AND sex = 0", " BETWEEN 3 AND 4 AND sex = 1" ,
                                     " BETWEEN 5 AND 6 AND sex = 0", " BETWEEN 5 AND 6 AND sex = 1", " BETWEEN 7 AND 12 AND sex = 0", " BETWEEN 7 AND 12 AND sex = 1",
                                     " BETWEEN 13 AND 18 AND sex = 0", " BETWEEN 13 AND 18 AND sex = 1", " BETWEEN 19 AND 24 AND sex = 0", " BETWEEN 19 AND 24 AND sex = 1",
                                     " BETWEEN 25 AND 59 AND sex = 0", " BETWEEN 25 AND 59 AND sex = 1", " = 60 AND sex = 0", " = 60 AND sex = 1" };
        //public string[] distQuery = { " AND district_id = 1;", " AND district_id = 2;", " AND district_id = 3;", " AND district_id = 4;", " AND district_id = 5;", " AND district_id = 6;",
                                     // " AND district_id = 7;", " AND district_id = 8;", " AND district_id = 9;", " AND district_id = 10;", " AND district_id = 11;", " AND district_id = 12;",
                                    //  " AND district_id = 13;"};
        //my_Table data
        public string[] distQuery = { " AND district = 'Agdao';", " AND district = 'Baguio';", " AND district = 'Buhangin';", " AND district = 'Bunawan';", " AND district = 'Calinan';", " AND district = 'CityA';",
                                      " AND district = 'CityB';", " AND district = 'Marilog';", " AND district = 'Paquibato';", " AND district = 'TalomoA';", " AND district = 'TalomoB';", " AND district = 'Toril';",
                                      " AND district = 'Tugbok';"};
        public void pwd_Districts()
        {
            string select = "SELECT COUNT(" + age + ") AS c FROM p_dao.my_Table WHERE ";
            string cm1, cm2, cm3, cm4, cm5, cm6, cm7, cm8;
            string cf1, cf2, cf3, cf4, cf5, cf6, cf7, cf8;
            string query = "";
            int num = 0;

            // add district id paaa >.<
            for (num = 0; num < 13; num++)
            {
                cm1 = select + age + ageQuery[0] + distQuery[num];
                cf1 = select + age + ageQuery[1] + distQuery[num];
                cm2 = select + age + ageQuery[2] + distQuery[num];
                cf2 = select + age + ageQuery[3] + distQuery[num];
                cm3 = select + age + ageQuery[4] + distQuery[num];
                cf3 = select + age + ageQuery[5] + distQuery[num];
                cm4 = select + age + ageQuery[6] + distQuery[num];
                cf4 = select + age + ageQuery[7] + distQuery[num];
                cm5 = select + age + ageQuery[8] + distQuery[num];
                cf5 = select + age + ageQuery[9] + distQuery[num];
                cm6 = select + age + ageQuery[10] + distQuery[num];
                cf6 = select + age + ageQuery[11] + distQuery[num];
                cm7 = select + age + ageQuery[12] + distQuery[num];
                cf7 = select + age + ageQuery[13] + distQuery[num];
                cm8 = select + age + ageQuery[14] + distQuery[num];
                cf8 = select + age + ageQuery[15] + distQuery[num];

                query = cm1 + cf1 + cm2 + cf2 + cm3 + cf3 + cm4 + cf4 + cm5 + cf5 + cm6 + cf6 + cm7 + cf7 + cm8 + cf8;

                if (num == 0) pwd_Agdao(query);
                else if (num == 1) pwd_Baguio(query);
                else if (num == 2) pwd_Buhangin(query);
                else if (num == 3) pwd_Bunawan(query);
                else if (num == 4) pwd_Calinan(query);
                else if (num == 5) pwd_City_A(query);
                else if (num == 6) pwd_City_B(query);
                else if (num == 7) pwd_Marilog(query);
                else if (num == 8) pwd_Paquibato(query);
                else if (num == 9) pwd_Talomo_A(query);
                else if (num == 10) pwd_Talomo_B(query);
                else if (num == 11) pwd_Toril(query);
                else if (num == 12) pwd_Tugbok(query);
            }  
        }
       
        public void pwd_Agdao(string query)
        {
            Agdao = new List<int>();
            try
            {
                conn.Open();
                comm = new MySqlCommand(query, conn);
                dr = comm.ExecuteReader();
                do
                {
                    while (dr.Read()) Agdao.Add(dr.GetInt32(0));
                } while (dr.NextResult());
             
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in pwd_Agdao() : " + ex);
                conn.Close();
            }
        }
        public void pwd_Baguio(string query)
        {
            Baguio = new List<int>();
            try
            {
                conn.Open();
                comm = new MySqlCommand(query, conn);
                dr = comm.ExecuteReader();
                do
                {
                    while (dr.Read()) Baguio.Add(dr.GetInt32(0));
                } while (dr.NextResult());

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in pwd_Baguio() : " + ex);
                conn.Close();
            }
        }
        public void pwd_Buhangin(string query)
        {
            Buhangin = new List<int>();
            try
            {
                conn.Open();
                comm = new MySqlCommand(query, conn);
                dr = comm.ExecuteReader();
                do
                {
                    while (dr.Read()) Buhangin.Add(dr.GetInt32(0));
                } while (dr.NextResult());

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in pwd_Buhangin() : " + ex);
                conn.Close();
            }
        }
        public void pwd_Bunawan(string query)
        {
            Bunawan = new List<int>();
            try
            {
                conn.Open();
                comm = new MySqlCommand(query, conn);
                dr = comm.ExecuteReader();
                do
                {
                    while (dr.Read()) Bunawan.Add(dr.GetInt32(0));
                } while (dr.NextResult());

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in pwd_Bunawan() : " + ex);
                conn.Close();
            }
        }
        public void pwd_Calinan(string query)
        {
            Calinan = new List<int>();
            try
            {
                conn.Open();
                comm = new MySqlCommand(query, conn);
                dr = comm.ExecuteReader();
                do
                {
                    while (dr.Read()) Calinan.Add(dr.GetInt32(0));
                } while (dr.NextResult());

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in pwd_Calinan() : " + ex);
                conn.Close();
            }
        }
        public void pwd_City_A(string query)
        {
            CityA = new List<int>();
            try
            {
                conn.Open();
                comm = new MySqlCommand(query, conn);
                dr = comm.ExecuteReader();
                do
                {
                    while (dr.Read()) CityA.Add(dr.GetInt32(0));
                } while (dr.NextResult());

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in pwd_City_A() : " + ex);
                conn.Close();
            }
        }
        public void pwd_City_B(string query)
        {
            CityB = new List<int>();
            try
            {
                conn.Open();
                comm = new MySqlCommand(query, conn);
                dr = comm.ExecuteReader();
                do
                {
                    while (dr.Read()) CityB.Add(dr.GetInt32(0));
                } while (dr.NextResult());

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in pwd_City_B() : " + ex);
                conn.Close();
            }
        }
        public void pwd_Marilog(string query)
        {
            Marilog = new List<int>();
            try
            {
                conn.Open();
                comm = new MySqlCommand(query, conn);
                dr = comm.ExecuteReader();
                do
                {
                    while (dr.Read()) Marilog.Add(dr.GetInt32(0));
                } while (dr.NextResult());

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in pwd_Marilog() : " + ex);
                conn.Close();
            }
        }
        public void pwd_Paquibato(string query)
        {
            Paquibato = new List<int>();
            try
            {
                conn.Open();
                comm = new MySqlCommand(query, conn);
                dr = comm.ExecuteReader();
                do
                {
                    while (dr.Read()) Paquibato.Add(dr.GetInt32(0));
                } while (dr.NextResult());

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in pwd_Paquibato() : " + ex);
                conn.Close();
            }
        }
        public void pwd_Talomo_A(string query)
        {
            TalomoA = new List<int>();
            try
            {
                conn.Open();
                comm = new MySqlCommand(query, conn);
                dr = comm.ExecuteReader();
                do
                {
                    while (dr.Read()) TalomoA.Add(dr.GetInt32(0));
                } while (dr.NextResult());

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in pwd_Talomo_A() : " + ex);
                conn.Close();
            }
        }
        public void pwd_Talomo_B(string query)
        {
            TalomoB = new List<int>();
            try
            {
                conn.Open();
                comm = new MySqlCommand(query, conn);
                dr = comm.ExecuteReader();
                do
                {
                    while (dr.Read()) TalomoB.Add(dr.GetInt32(0));
                } while (dr.NextResult());

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in pwd_Talomo_B() : " + ex);
                conn.Close();
            }
        }
        public void pwd_Toril(string query)
        {
            Toril = new List<int>();
            try
            {
                conn.Open();
                comm = new MySqlCommand(query, conn);
                dr = comm.ExecuteReader();
                do
                {
                    while (dr.Read()) Toril.Add(dr.GetInt32(0));
                } while (dr.NextResult());

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in pwd_Toril() : " + ex);
                conn.Close();
            }
        }
        public void pwd_Tugbok(string query)
        {
            Tugbok = new List<int>();
            try
            {
                conn.Open();
                comm = new MySqlCommand(query, conn);
                dr = comm.ExecuteReader();
                do
                {
                    while (dr.Read()) Tugbok.Add(dr.GetInt32(0));
                } while (dr.NextResult());

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in pwd_Tugbok() : " + ex);
                conn.Close();
            }
        }
        #endregion

        #endregion




    }
}
