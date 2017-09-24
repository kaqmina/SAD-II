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
using System.Drawing.Text;

namespace SAD_2_PTT
{
    public partial class sample_report : Form
    {
        public main_form reference_to_main { get; set; }
        main_functions main_f = new main_functions();
        connections_settings conn = new connections_settings();
        connection_reports rep = new connection_reports();

        public DateTime from, to, end;
        public string func = "";
        public string district, dev_stat;
        public int format, district_num;

        private System.Drawing.Printing.PrintDocument doc =  new System.Drawing.Printing.PrintDocument();

        public sample_report()
        {
            InitializeComponent();
            rep.report_Grid(report_grid);
            rep.device_grid(device_grid);

            date_from.Visible = date_to.Visible = false;
            lbl_from.Visible = lbl_to.Visible = btn_custom.Visible = false;

            //Temporary
            pnl_device.Visible = false;
            this.doc.PrintPage += new PrintPageEventHandler(rep.printDocument_PrintPage);
        }

        private void save_Click(object sender, EventArgs e) // export PDF
        {
            string file = "";
            string district_pass, date = "";
            save_pdf.Filter = "PDF files |*.pdf";
            save_pdf.DefaultExt = "*.pdf";
            save_pdf.FilterIndex = 1;
            save_pdf.ShowDialog();
            save_pdf.Title = "Export as PDF";

            #region << District & Date Format [PDF] >>
            if (lbl_from.Text == "From" && lbl_to.Text == "To" && date_from.CustomFormat == "MMMM dd, yyyy") //custom
            {
                date = from.ToString("MMMM dd") + " - " + to.ToString("MMMM dd yyyy");
            }
            else if(lbl_from.Text == "Month" && lbl_to.Text == "Year" && date_from.CustomFormat == "MMMM") //monthly
            {
                date = from.ToString("MMMM") + " " + to.ToString("yyyy");
            }
            else if(lbl_from.Visible == false && date_from.Visible == false && date_to.CustomFormat == "yyyy") //yearly
            {
                date = to.ToString("yyyy");
            }

            if (district == null) district_pass = "ALL";
            else district_pass = district_format.SelectedItem.ToString();
            #endregion
            file = save_pdf.FileName;

            if (file == "") ; //pass
            else
            {
                rep.pwd_PDFReport(file, report_grid, district_pass, date);
                System.Diagnostics.Process.Start(file); // to open document directly after creating PDF
            }
            save_pdf.FileName = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_custom_Click(object sender, EventArgs e)
        {
            from = date_from.Value.Date;
            to = date_to.Value.Date;
            end = DateTime.Now;

            if (format == 1) end = to.AddDays(6);

            if(pnl_pwd.Visible == true)
            rep.getDateQuery(report_grid, format, from, to, end, district_num);
        }

        
        private void date_format_SelectedIndexChanged(object sender, EventArgs e)
        {
            date_from.Value = date_to.Value = DateTime.Now;
            format = date_format.SelectedIndex;

                if (date_format.SelectedIndex == 0)
                {
                    date_from.Visible = false;
                    date_to.Visible = false;
                    lbl_from.Visible = lbl_to.Visible = btn_custom.Visible = false;
                    rep.report_Grid(report_grid);
                }
                else if (date_format.SelectedIndex == 1)
                {
                    //Weekly
                    func = "weekly";
                    date_to.Visible = true;
                    date_to.Format = DateTimePickerFormat.Custom;
                    date_to.CustomFormat = "MMMM dd, yyyy";

                    lbl_to.Text = "Start";
                    date_from.Visible = lbl_from.Visible = false;
                    lbl_to.Visible = btn_custom.Visible = true;
                }
                else if (date_format.SelectedIndex == 2)
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
                else if (date_format.SelectedIndex == 3)
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
                else if (date_format.SelectedIndex == 4)
                {
                    //Custom Date
                    func = "custom";
                    date_from.Visible = date_to.Visible = true;
                    date_to.Format = date_from.Format = DateTimePickerFormat.Custom;
                    date_to.CustomFormat = date_from.CustomFormat = "MMMM dd, yyyy";
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
            else
            {
                rep.pwd_ExcelReport(sheet);
                System.Diagnostics.Process.Start(sheet); // to open document directly after creating EXCEL
            }
            save_Excel.FileName = "";
        }

        private void export_device_Click(object sender, EventArgs e)
        {
            string file = "";
            string date = "";
            save_pdf.Filter = "PDF files |*.pdf";
            save_pdf.DefaultExt = "*.pdf";
            save_pdf.FilterIndex = 1;
            save_pdf.ShowDialog();
            save_pdf.Title = "Export as PDF";

            #region << Date Format [PDF] >>
            if (lbl_from.Text == "From" && lbl_to.Text == "To" && date_from.CustomFormat == "MMMM dd, yyyy") //custom
            {
                date = from.ToString("MMMM dd") + " - " + to.ToString("MMMM dd yyyy");
            }
            else if (lbl_from.Text == "Month" && lbl_to.Text == "Year" && date_from.CustomFormat == "MMMM") //monthly
            {
                date = from.ToString("MMMM") + " " + to.ToString("yyyy");
            }
            else if (lbl_from.Visible == false && date_from.Visible == false && date_to.CustomFormat == "yyyy") //yearly
            {
                date = to.ToString("yyyy");
            }
            else if(lbl_to.Text == "Start") // weekly
            {
                date = to.ToString("MMMM dd") + " - " + end.ToString("MMMM dd yyyy");
            }

            if (dev_stat == "" || dev_status.SelectedIndex == -1) dev_stat = "requested";
            else dev_stat = dev_status.SelectedItem.ToString();
            #endregion


            file = save_pdf.FileName;

            if (file == "") ; //pass
            else
            {
                rep.device_PDF(file, date, device_grid, dev_stat);
                System.Diagnostics.Process.Start(file); // to open document directly after creating PDF
            }
            save_pdf.FileName = "";
        }

        #region Temporary
        private void btn_pwd_Click(object sender, EventArgs e)
        {
            pnl_pwd.Visible = true;
            pnl_device.Visible = false;
        }
        #endregion

        private void btn_device_Click(object sender, EventArgs e)
        {
            pnl_pwd.Visible = false;
            pnl_device.Visible = true;
            string[] dformat = { "", "Monthly", "Yearly" }; 

            date_format.Items.Clear();
            date_format.Items.AddRange(dformat);
        }

        private void dev_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dev_status.SelectedIndex == 0) rep.device_status_grid(device_grid, "default", from, to, format);
            else if (dev_status.SelectedIndex == 1) rep.device_status_grid(device_grid, "requested", from, to, format);
            else if(dev_status.SelectedIndex == 2) rep.device_status_grid(device_grid, "handed out", from, to, format);
        }

        private void district_format_SelectedIndexChanged(object sender, EventArgs e)
        {
            district_num = district_format.SelectedIndex;
            district = district_format.SelectedItem.ToString();
           
            if (format != 0)
            {
               rep.getDateQuery(report_grid, format, from, to, end, district_num);
            }
            else
            {
                 rep.getDistrictQuery(report_grid, district_num); 
            }
        }

        private void print_prev_Click(object sender, EventArgs e)
        {

            // to_print.ShowDialog();
            // to_print.Document = doc;
          
        }

       
    }
}
