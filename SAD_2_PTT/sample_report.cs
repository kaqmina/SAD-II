using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace SAD_2_PTT
{
    public partial class sample_report : Form
    {
        public main_form reference_to_main { get; set; }
        main_functions main_f = new main_functions();
        connections_settings conn = new connections_settings();
        connection_reports rep = new connection_reports();

        PrintPreviewDialog print_;
        private PrintDocument doc = new PrintDocument();

        DateTime from, to;
        public string func = "";

        public sample_report()
        {
            InitializeComponent();
            rep.report_gridView(report_grid);

            date_from.Visible = date_to.Visible = false;
            lbl_from.Visible = lbl_to.Visible = btn_custom.Visible = false;
           
           // this.print_.Name = "Print Preview";

          //  this.doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);
        }

        private void save_Click(object sender, EventArgs e) // export PDF
        {
            string file = "";
            save_pdf.Filter = "PDF files |*.pdf";
            save_pdf.DefaultExt = "*.pdf";
            save_pdf.FilterIndex = 1;
            save_pdf.ShowDialog();
            save_pdf.Title = "Export as PDF";


            file = save_pdf.FileName;
            if (file == "") ; //pass
            else rep.pwd_PDFReport(file,report_grid);

            System.Diagnostics.Process.Start(file); // to open document directly after creating PDF
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_custom_Click(object sender, EventArgs e)
        {
            from = date_from.Value.Date;
            to = date_to.Value.Date;

            if (func == "custom")
            {
                rep.report_customFormat(report_grid, from, to);
            }
            else if(func == "yearly")
            {
                rep.report_YearlyFormat(report_grid, to);
            }
            else if(func == "monthly")
            {
                rep.report_MonthlyFormat(report_grid, from, to);
            }
        }

        private void date_format_SelectedIndexChanged(object sender, EventArgs e)
        {
            date_from.Value = date_to.Value = DateTime.Now;
            if (date_format.SelectedIndex == 0)
            {
                date_from.Visible = false;
                date_to.Visible = false;
                lbl_from.Visible = lbl_to.Visible = btn_custom.Visible = false;
            }
            else if(date_format.SelectedIndex == 1)
            {
                //Weekly
            }
            else if(date_format.SelectedIndex == 2)
            {
                //Monthly
                func = "monthly";
                date_from.Visible = true;
                date_from.Format = DateTimePickerFormat.Custom;
                date_from.CustomFormat = "MMMM";
                date_from.ShowUpDown = true;
                lbl_from.Text = "Month";

                date_to.Visible = true;
                date_to.Format = DateTimePickerFormat.Custom;
                date_to.CustomFormat = "yyyy";
                date_to.ShowUpDown = true;
                lbl_to.Text = "Year";

                lbl_from.Visible = lbl_to.Visible = btn_custom.Visible = true;
            }
            else if(date_format.SelectedIndex == 3)
            {
                //Yearly
                func = "yearly";
                date_to.Visible = true;
                date_to.Format = DateTimePickerFormat.Custom;
                date_to.CustomFormat = "yyyy";
                date_to.ShowUpDown = true;

                lbl_to.Text = "Year";
                date_from.Visible = lbl_from.Visible = false;
                lbl_to.Visible = btn_custom.Visible = true;
            }
            else if(date_format.SelectedIndex == 4)
            {
                //Custom Date
                func = "custom";
                date_from.Visible = date_to.Visible = true;
                lbl_from.Visible = lbl_to.Visible = btn_custom.Visible = true;
                lbl_from.Text = "From";
                lbl_to.Text = "To";
            }
        }

     
        private void export_excel_Click(object sender, EventArgs e)
        {
            string sheet = "";
            save_Excel.Filter = "Excel files |*.xlsx";
            save_Excel.DefaultExt = "*.xlsx";
            save_Excel.FilterIndex = 1;
            save_Excel.ShowDialog();
            save_Excel.Title = "Export as Excel Worksheet";

            sheet = save_Excel.FileName;
            if (sheet == "") ; //pass
            else rep.pwd_ExcelReport(sheet);

            
        }

        private void print_prev_Click(object sender, EventArgs e)
        {
            rep.pwd_Agdao();
        }

        private void doc_PrintPage(object sender, PrintPageEventHandler e)
        {

        }
    }
}
