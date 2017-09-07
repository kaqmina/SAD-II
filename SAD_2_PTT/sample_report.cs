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

        public sample_report()
        {
            InitializeComponent();
            rep.report_gridView(report_grid);
           // this.print_.Name = "Print Preview";

          //  this.doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);
        }

        private void save_Click(object sender, EventArgs e) // export PDF
        {
            string file = "";
            s.Filter = "PDF files |*.pdf";
            s.DefaultExt = "*.pdf";
            s.FilterIndex = 1;
            s.ShowDialog();
            s.Title = "Export as PDF";


            file = s.FileName;
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

            rep.report_customFormat(report_grid, from, to);
        }

        private void doc_PrintPage(object sender, PrintPageEventHandler e)
        {

        }
    }
}
