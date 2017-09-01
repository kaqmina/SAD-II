using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAD_2_PTT
{
    public partial class sample_report : Form
    {
        public sample_report()
        {
            InitializeComponent();
            rep.report_gridView(report_grid);
        }
            
        public main_form reference_to_main { get; set; }
        main_functions main_f = new main_functions();
        //connections conn = new connections();
        connections_settings conn = new connections_settings();
        connection_reports rep = new connection_reports();
    
    public void account_data()
        {
           // conn.employee_list(settings_list);
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
    }
}
