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
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace SAD_2_PTT_01
{
    class connections_reports
    {
        public MySqlConnection conn;
        public MySqlCommand comm;
        public MySqlDataReader dr;

        public string age = " DATE_FORMAT(NOW(), '%Y') - DATE_FORMAT(birthdate, '%Y') - (DATE_FORMAT(NOW(), '00-%m-%d') < DATE_FORMAT(birthdate, '00-%m-%d'))";
        public string educ_at = " (CASE WHEN educ_attainment = 1 THEN 'Elementary' WHEN educ_attainment = 2 THEN 'Elementary Undergraduate' WHEN educ_attainment = 3 THEN 'High School' WHEN educ_attainment = 4 THEN 'High School Undergraduate' WHEN educ_attainment = 5 THEN 'College' WHEN educ_attainment = 6 THEN 'College Undergraduate' WHEN educ_attainment = 7 THEN 'Graduate' WHEN educ_attainment = 8 THEN 'Post Graduate' WHEN educ_attainment = 9 THEN 'Vocational' ELSE 'None' END) AS educ_attainment, ";
        public string no = "SET @num = 0; ";
        public string district = " (CASE WHEN district_id = 1 THEN 'Agdao' WHEN district_id = 2 THEN 'Baguio' WHEN district_id = 3 THEN 'Buhangin' WHEN district_id = 4 THEN 'Bunawan' WHEN district_id = 5 THEN 'Calinan' WHEN district_id = 6 THEN 'City-A' WHEN district_id = 7 THEN 'City-B' WHEN district_id = 8 THEN 'Marilog' WHEN district_id = 9 THEN 'Paquibato' WHEN district_id = 10 THEN 'Talomo-A' WHEN district_id = 11 THEN 'Talomo-B' WHEN district_id = 12 THEN 'Toril' ELSE 'Tugbok' END) as district";
        public string addr = " CONCAT(address_house_no_street, ', ', address_barangay, ', ', address_municipality, ', ', address_province)";
        public List<string> disability;
        public int disability_count;

        public main_form main { get; set; }

        public connections_reports() //ano naaa
        {
            conn = new MySqlConnection("Server=localhost;Database=p_dao;Uid=root;Pwd=root;Allow User Variables=True");
        }

        #region << Methods >>

        #region << PWD >>
        public void report_format(DataGridView report)
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
            report.Columns["app"].HeaderText = "APPLIED DATE";

            //Column Size
            report.Columns["num"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            report.Columns["lastname"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            report.Columns["age"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            report.Columns["sex"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            report.Columns["birthdate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            report.Columns["num"].Width = report.Columns["age"].Width = report.Columns["sex"].Width = 35;
            report.Columns["birthdate"].Width = 80;
            report.Columns["lastname"].Width = 100;
        }

        public void getDateQuery(DataGridView rep, int format, DateTime from, DateTime to, DateTime end, int district)
        {
            string query = "";

            if (format == 0) report_Grid(rep);
            //Monthly
            else if (format == 2)
                if (format == 2 && district != 0) query = no + "SELECT CONCAT((@num:=@num + 1),'.') AS num, lastname, CONCAT(firstname,  ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS firstname, " + age + "AS age, (CASE WHEN sex = 0 THEN 'M' ELSE 'F' END) AS sex, date_format(birthdate, '%m/%d/%Y') AS birthdate," + educ_at + addr + "AS address, date_format(application_date, '%m/%d/%Y') AS app, disability_type FROM p_dao.pwd JOIN p_dao.disability ON pwd.disability_id = disability.disability_id WHERE month(application_date) = '" + from.ToString("MM") + "' AND year(application_date) = '" + to.ToString("yyyy") + "' AND district_id = " + district + "ORDER BY lastname ASC";
                else query = no + "SELECT CONCAT((@num:=@num + 1),'.') AS num, lastname, CONCAT(firstname,  ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS firstname, " + age + "AS age, (CASE WHEN sex = 0 THEN 'M' ELSE 'F' END) AS sex, date_format(birthdate, '%m/%d/%Y') AS birthdate," + educ_at + addr + "AS address, date_format(application_date, '%m/%d/%Y') AS app, disability_type FROM p_dao.pwd JOIN p_dao.disability ON pwd.disability_id = disability.disability_id WHERE month(application_date) = '" + from.ToString("MM") + "' AND year(application_date) = '" + to.ToString("yyyy") + "' ORDER BY lastname ASC";
            //Yearly
            else if (format == 3)
                if (format == 3 && district != 0) query = no + "SELECT CONCAT((@num:=@num + 1),'.') AS num, lastname, CONCAT(firstname,  ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS firstname, " + age + "AS age, (CASE WHEN sex = 0 THEN 'M' ELSE 'F' END) AS sex, date_format(birthdate, '%m/%d/%Y') AS birthdate," + educ_at + addr + "AS address, date_format(application_date, '%m/%d/%Y') AS app, disability_type FROM p_dao.pwd JOIN p_dao.disability ON pwd.disability_id = disability.disability_id WHERE year(application_date) = '" + to.ToString("yyyy") + "' AND district_id = " + district + " ORDER BY lastname ASC";
                else query = no + "SELECT CONCAT((@num:=@num + 1),'.') AS num, lastname, CONCAT(firstname,  ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS firstname, " + age + "AS age, (CASE WHEN sex = 0 THEN 'M' ELSE 'F' END) AS sex, date_format(birthdate, '%m/%d/%Y') AS birthdate," + educ_at + addr + "AS address, date_format(application_date, '%m/%d/%Y') AS app, disability_type FROM p_dao.pwd JOIN p_dao.disability ON pwd.disability_id = disability.disability_id WHERE year(application_date) = '" + to.ToString("yyyy") + "' ORDER BY lastname ASC";
            //Custom
            else if (format == 4)
                if (format == 4 && district != 0) query = no + "SELECT CONCAT((@num:=@num + 1),'.') AS num, lastname, CONCAT(firstname,  ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS firstname," + age + "AS age, (CASE WHEN sex = 0 THEN 'M' ELSE 'F' END) AS sex, date_format(birthdate, '%m/%d/%Y') AS birthdate, " + educ_at + addr + "AS address, date_format(application_date, '%m/%d/%Y') AS app, disability_type FROM p_dao.pwd JOIN p_dao.disability ON pwd.disability_id = disability.disability_id WHERE application_date BETWEEN '" + from.ToString("yyyy-MM-dd") + "' AND '" + to.ToString("yyyy-MM-dd") + "' AND district_id = " + district + " ORDER BY lastname ASC";
                else query = no + "SELECT CONCAT((@num:=@num + 1),'.') AS num, lastname, CONCAT(firstname,  ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS firstname," + age + "AS age, (CASE WHEN sex = 0 THEN 'M' ELSE 'F' END) AS sex, date_format(birthdate, '%m/%d/%Y') AS birthdate, " + educ_at + addr + "AS address, date_format(application_date, '%m/%d/%Y') AS app, disability_type FROM p_dao.pwd JOIN p_dao.disability ON pwd.disability_id = disability.disability_id WHERE application_date BETWEEN '" + from.ToString("yyyy-MM-dd") + "' AND '" + to.ToString("yyyy-MM-dd") + "' ORDER BY lastname ASC";
            //Weekly
            else if (format == 1)
                if (format == 1 && district != 0) query = no + "SELECT CONCAT((@num:=@num + 1),'.') AS num, lastname, CONCAT(firstname,  ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS firstname," + age + "AS age, (CASE WHEN sex = 0 THEN 'M' ELSE 'F' END) AS sex, date_format(birthdate, '%m/%d/%Y') AS birthdate, " + educ_at + addr + "AS address, date_format(application_date, '%m/%d/%Y') AS app,disability_type FROM p_dao.pwd JOIN p_dao.disability ON pwd.disability_id = disability.disability_id WHERE application_date BETWEEN '" + to.ToString("yyyy-MM-dd") + "' AND '" + end.ToString("yyyy-MM-dd") + "' AND district_id = " + district + " ORDER BY lastname ASC";
                else query = no + "SELECT CONCAT((@num:=@num + 1),'.') AS num, lastname, CONCAT(firstname,  ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS firstname," + age + "AS age, (CASE WHEN sex = 0 THEN 'M' ELSE 'F' END) AS sex, date_format(birthdate, '%m/%d/%Y') AS birthdate, " + educ_at + addr + "AS address, date_format(application_date, '%m/%d/%Y') AS app, disability_type FROM p_dao.pwd JOIN p_dao.disability ON pwd.disability_id = disability.disability_id WHERE application_date BETWEEN '" + to.ToString("yyyy-MM-dd") + "' AND '" + end.ToString("yyyy-MM-dd") + "' ORDER BY lastname ASC";
            try
            {
                conn.Open();
                comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                rep.DataSource = dt;
                report_format(rep);

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in getDateQuery() : " + ex);
                conn.Close();
            }
        }
        public void getDistrictQuery(DataGridView rep, int district)
        {

            string query = no + "SELECT CONCAT((@num:=@num + 1),'.') AS num, lastname, CONCAT(firstname, ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS firstname," + age + "AS age, (CASE WHEN sex = 0 THEN 'M' ELSE 'F' END) AS sex, date_format(birthdate, '%m/%d/%Y') AS birthdate, " + educ_at + addr + " AS address, date_format(application_date, '%m/%d/%Y') AS app,disability_type FROM p_dao.pwd JOIN p_dao.disability ON pwd.disability_id = disability.disability_id WHERE district_id = '" + district + "' ORDER BY lastname ASC";
            try
            {
                conn.Open();
                comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                rep.DataSource = dt;
                report_format(rep);

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in getDistrictQuery() : " + ex);
                conn.Close();
            }

        }

        public void report_Grid(DataGridView rep)
        {
            try
            {
                conn.Open();
                comm = new MySqlCommand(no + "SELECT CONCAT((@num:=@num + 1),'.') AS num, lastname, CONCAT(firstname, ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS firstname, " + age + "AS age, (CASE WHEN sex = 0 THEN 'M' ELSE 'F' END) AS sex, date_format(birthdate, '%m/%d/%Y') AS birthdate, " + educ_at + addr + " AS address, date_format(application_date,'%m/%d/%Y') AS app, disability_type FROM p_dao.pwd JOIN p_dao.disability ON pwd.disability_id = disability.disability_id ORDER BY lastname ASC", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                rep.DataSource = dt;
                report_format(rep);

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in report_grid() : " + ex);
                conn.Close();
            }
        }
        #endregion

        #region << DEVICE >>
        public void device_format(DataGridView device, string format)
        {
            if (format == "requested" || format == "default")
            {
                device.Columns["lastname"].HeaderText = "LAST NAME";
                device.Columns["firstname"].HeaderText = "FIRST NAME";
                device.Columns["dev_name"].HeaderText = "DEVICE";
                device.Columns["dp_name"].HeaderText = "PROVIDER";
                device.Columns["req_date"].HeaderText = "REQUESTED DATE";
                device.Columns["num"].HeaderText = "NO.";

                //Column Size
                device.Columns["num"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                device.Columns["lastname"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                device.Columns["num"].Width = 35;
                device.Columns["lastname"].Width = 100;
            }
            else if (format == "handed out")
            {
                device.Columns["lastname"].HeaderText = "LAST NAME";
                device.Columns["firstname"].HeaderText = "FIRST NAME";
                device.Columns["dev_name"].HeaderText = "DEVICE";
                device.Columns["dp_name"].HeaderText = "PROVIDER";
                device.Columns["date_out"].HeaderText = "HANDED OUT DATE";
                device.Columns["num"].HeaderText = "NO.";

                //Column Size
                device.Columns["num"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                device.Columns["lastname"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                device.Columns["num"].Width = 35;
                device.Columns["lastname"].Width = 100;
            }
        }

        public void device_grid(DataGridView rep)
        {
            try
            {
                conn.Open();
                comm = new MySqlCommand(no + "SELECT CONCAT((@num:=@num + 1),'.') AS num, lastname, CONCAT(firstname, ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS firstname, dev_name, dp_name, date_format(req_date, '%m/%d/%Y') AS req_date FROM p_dao.device_log JOIN p_dao.pwd ON device_log.pwd_id = pwd.pwd_id JOIN p_dao.device ON device_log.device_id = device.device_id JOIN p_dao.device_provider ON device_log.dp_id = device_provider.dp_id WHERE status = 1 ORDER BY lastname ASC", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                rep.DataSource = dt;
                device_format(rep, "default");

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in device_grid() : " + ex);
                conn.Close();
            }
        }

        public void device_status_grid(DataGridView rep, string format, DateTime from, DateTime to, DateTime end, int dformat)
        {

            try
            {
                string query = "";
                //Monthly
                if (format == "requested" || format == "default")
                    if (format == "requested" && dformat == 2) query = no + "SELECT CONCAT((@num:=@num + 1),'.') AS num, lastname, CONCAT(firstname, ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS firstname, dev_name, dp_name, date_format(req_date, '%m/%d/%Y') AS req_date FROM p_dao.device_log JOIN p_dao.pwd ON device_log.pwd_id = pwd.pwd_id JOIN p_dao.device ON device_log.device_id = device.device_id JOIN p_dao.device_provider ON device_log.dp_id = device_provider.dp_id WHERE status = 1 AND month(date_out) = '" + from.ToString("MM") + "' AND year(date_out) = '" + to.ToString("yyyy") + "'  ORDER BY lastname ASC";
                    else if (format == "requested" && dformat == 1) query = no + "SELECT CONCAT((@num:=@num + 1),'.') AS num, lastname, CONCAT(firstname, ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS firstname, dev_name, dp_name, date_format(req_date, '%m/&d/&Y') AS req_date FROM p_dao.device_log JOIN p_dao.pwd ON device_log.pwd_id = pwd.pwd_id JOIN p_dao.device ON device_log.device_id = device.device_id JOIN p_dao.device_provider ON device_log.dp_id = device_provider.dp_id WHERE status = 1 AND req_date BETWEEN '" + to.ToString("yyyy-MM-dd") + "' AND '" + end.ToString("yyyy-MM-dd") + "' ORDER BY lastname ASC";
                    else if (format == "requested" && dformat == 3) query = no + "SELECT CONCAT((@num:=@num + 1),'.') AS num, lastname, CONCAT(firstname, ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS firstname, dev_name, dp_name, date_format(date_out, '%m/%d/%Y') AS date_out FROM p_dao.device_log JOIN p_dao.pwd ON device_log.pwd_id = pwd.pwd_id JOIN p_dao.device ON device_log.device_id = device.device_id JOIN p_dao.device_provider ON device_log.dp_id = device_provider.dp_id WHERE status = 1 AND year(date_out) = '" + to.ToString("yyyy") + "'  ORDER BY lastname ASC";
                    else query = "SELECT CONCAT((@num:=@num + 1),'.') AS num, lastname, CONCAT(firstname, ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS firstname, dev_name, dp_name, date_format(req_date, '%m/%d/%Y') AS req_date FROM p_dao.device_log JOIN p_dao.pwd ON device_log.pwd_id = pwd.pwd_id JOIN p_dao.device ON device_log.device_id = device.device_id JOIN p_dao.device_provider ON device_log.dp_id = device_provider.dp_id WHERE status = 1 ORDER BY lastname ASC";
                //Yearly
                else if (format == "handed out")
                    if (format == "handed out" && dformat == 3) query = no + "SELECT CONCAT((@num:=@num + 1),'.') AS num, lastname, CONCAT(firstname, ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS firstname, dev_name, dp_name, date_format(date_out, '%m/%d/%Y') AS date_out FROM p_dao.device_log JOIN p_dao.pwd ON device_log.pwd_id = pwd.pwd_id JOIN p_dao.device ON device_log.device_id = device.device_id JOIN p_dao.device_provider ON device_log.dp_id = device_provider.dp_id WHERE status = 3 AND year(date_out) = '" + to.ToString("yyyy") + "'  ORDER BY lastname ASC";
                    else if (format == "handed out" && dformat == 2) query = no + "SELECT CONCAT((@num:=@num + 1),'.') AS num, SELECT lastname, CONCAT(firstname, ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS firstname, dev_name, dp_name, date_format(req_date, '%m/%d/%Y') AS req_date FROM p_dao.device_log JOIN p_dao.pwd ON device_log.pwd_id = pwd.pwd_id JOIN p_dao.device ON device_log.device_id = device.device_id JOIN p_dao.device_provider ON device_log.dp_id = device_provider.dp_id WHERE status = 3 AND month(date_out) = '" + from.ToString("MM") + "' AND year(date_out) = '" + to.ToString("yyyy") + "'  ORDER BY lastname ASC";
                    else if (format == "handed out" && dformat == 1) query = no + "SELECT CONCAT((@num:=@num + 1),'.') AS num, lastname, CONCAT(firstname, ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS firstname, dev_name, dp_name, date_format(req_date, '%m/&d/&Y') AS req_date FROM p_dao.device_log JOIN p_dao.pwd ON device_log.pwd_id = pwd.pwd_id JOIN p_dao.device ON device_log.device_id = device.device_id JOIN p_dao.device_provider ON device_log.dp_id = device_provider.dp_id WHERE status = 3 AND req_date BETWEEN '" + to.ToString("yyyy-MM-dd") + "' AND '" + end.ToString("yyyy-MM-dd") + "' ORDER BY lastname ASC";
                    else query = no + "SELECT CONCAT((@num:=@num + 1),'.') AS num, lastname, CONCAT(firstname, ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS firstname, dev_name, dp_name, date_format(date_out, '%m/%d/%Y') AS date_out FROM p_dao.device_log JOIN p_dao.pwd ON device_log.pwd_id = pwd.pwd_id JOIN p_dao.device ON device_log.device_id = device.device_id JOIN p_dao.device_provider ON device_log.dp_id = device_provider.dp_id WHERE status = 3 ORDER BY lastname ASC";


                conn.Open();
                comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                rep.DataSource = dt;
                if (format == "requested" || format == "default") device_format(rep, "requested");
                else if (format == "handed out") device_format(rep, "handed out");

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in device_status_grid() : " + ex);
                conn.Close();
            }
        }
        #endregion

        #region << PROJECTS >>
        public void project_format(DataGridView project)
        {
            project.Columns["project_title"].HeaderText = "PROJECT";
            project.Columns["event_held"].HeaderText = "EVENT HELD";
            project.Columns["start_time"].HeaderText = "START TIME";
            project.Columns["end_time"].HeaderText = "END TIME";
            project.Columns["date_proposed"].HeaderText = "DATE PROPOSED";
            project.Columns["num"].HeaderText = "NO.";
            project.Columns["budget"].HeaderText = "BUDGET";

            //Column Size
            project.Columns["num"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            project.Columns["start_time"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            project.Columns["end_time"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            project.Columns["date_proposed"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            project.Columns["num"].Width = 35;
            project.Columns["start_time"].Width = project.Columns["end_time"].Width = project.Columns["date_proposed"].Width = 80;
        }

        public void project_grid(DataGridView rep)
        {
            try
            {
                conn.Open();
                comm = new MySqlCommand(no + "SELECT CONCAT((@num := @num + 1), '.') AS num, project_title, event_held, date_format(date_proposed,'%m/%d/%Y') AS date_proposed, date_format(start_time, '%h:%i') AS start_time, date_format(end_time, '%h:%i') AS end_time, CONCAT(budget, '.00') AS budget FROM p_dao.project", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                rep.DataSource = dt;
                project_format(rep);

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in project_grid() : " + ex);
                conn.Close();
            }
        }

        public void date_project_format(DataGridView rep, int format, DateTime from, DateTime to)
        {
            string query = "";
            //(
            if (format == 0) project_grid(rep);
            //Monthly
            else if (format == 1) query = no + "SELECT CONCAT((@num := @num + 1), '.') AS num, project_title, event_held, date_format(date_proposed,'%m/%d/%Y') AS date_proposed, date_format(start_time, '%h:%i') AS start_time, date_format(end_time, '%h:%i') AS end_time, CONCAT(budget, '.00') AS budget FROM p_dao.project WHERE month(date_proposed) = '" + from.ToString("MM") + "' AND year(date_proposed) = '" + to.ToString("yyyy") + "'";
            //Yearly
            else if (format == 2) query = no + "SELECT CONCAT((@num := @num + 1), '.') AS num, project_title, event_held, date_format(date_proposed,'%m/%d/%Y') AS date_proposed, date_format(start_time, '%h:%i') AS start_time, date_format(end_time, '%h:%i') AS end_time, CONCAT(budget, '.00') AS budget FROM p_dao.project WHERE year(date_proposed) = '" + to.ToString("yyyy") + "'";
            //Custom
            else if (format == 3) query = no + "SELECT CONCAT((@num := @num + 1), '.') AS num, project_title, event_held, date_format(date_proposed,'%m/%d/%Y') AS date_proposed, date_format(start_time, '%h:%i') AS start_time, date_format(end_time, '%h:%i') AS end_time, CONCAT(budget, '.00') AS budget FROM p_dao.project WHERE date_proposed  BETWEEN '" + from.ToString("yyyy-MM-dd") + "' AND '" + to.ToString("yyyy-MM-dd") + "'";


            try
            {
                conn.Open();
                comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                rep.DataSource = dt;
                project_format(rep);

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in date_project_format() : " + ex);
                conn.Close();
            }
        }
        #endregion

        public void getDisability()
        {
            comm = new MySqlCommand("SELECT upper(disability_type) FROM p_dao.disability", conn);
            disability = new List<string>();
            try
            {
                conn.Open();
                dr = comm.ExecuteReader();
                do
                {
                    while (dr.Read())
                    {
                        disability.Add(dr.GetString("upper(disability_type)"));
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
        public void getDisabilityCount()
        {
            comm = new MySqlCommand("SELECT COUNT(disability_type) FROM p_dao.disability", conn);
            try
            {
                conn.Open();
                dr = comm.ExecuteReader();
                while (dr.Read()) disability_count = dr.GetInt32("COUNT(disability_type)");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in getDisabilityCount() : " + ex);
                conn.Close();
            }
        }
        public int proj_id;

        public void getProjectID(string project)
        {
            comm = new MySqlCommand("SELECT project_id FROM p_dao.project WHERE project_title = '" + project + "'", conn);
            try
            {
                conn.Open();
                dr = comm.ExecuteReader();
                while (dr.Read()) proj_id = dr.GetInt32(0);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in getProjectID() : " + ex);
                conn.Close();
            }
        }

        public List<string> pwd;
        public void getAttendance()
        {
            pwd = new List<string>();
            comm = new MySqlCommand("SELECT CONCAT(lastname, ', ', firstname, ' ', UCASE(SUBSTRING(middlename,1,1)), '.') AS pwd_name FROM p_dao.pwd JOIN p_dao.project_persons ON pwd.pwd_id = project_persons.pwd_id WHERE project_id = " + proj_id, conn);

            try
            {
                conn.Open();
                dr = comm.ExecuteReader();
                do
                {
                    while (dr.Read())
                    {
                        pwd.Add(dr.GetString("pwd_name"));
                    }
                } while (dr.NextResult());
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in getAttendance() : " + ex);
                conn.Close();
            }
        }

        public void getQuery(string query, int num)
        {
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

        #endregion

        #region  <-- PWD: MASTERLIST --> [PDF] 
        public void pwd_PDFReport(string file, DataGridView report, string district, string date)
        {

            FileStream fs = new FileStream(file, FileMode.Create, FileAccess.ReadWrite);
            Document doc = new Document(PageSize.LETTER, 30, 30, 30, 30);
            doc.SetPageSize(PageSize.LETTER.Rotate());
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();

            //logo
            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(SAD_2_PTT_01.Properties.Resources.pdao_logo, System.Drawing.Imaging.ImageFormat.Jpeg);
            logo.Alignment = Element.ALIGN_TOP | Element.ALIGN_CENTER;
            logo.ScalePercent(40);
            doc.Add(logo);

            //title
            var titleFont = FontFactory.GetFont("Calibri", 13, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            var subFont = FontFactory.GetFont("Calibri", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            Paragraph title = new Paragraph("MASTERLIST OF PWD MEMBERS", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);

            //date
            if (date == "") date = DateTime.Now.ToString("MMMM dd, yyyy");
            Paragraph title2 = new Paragraph(date, subFont);
            title2.Alignment = Element.ALIGN_CENTER;
            title2.SpacingAfter = 15;
            doc.Add(title2);

            //district
            Paragraph title1 = new Paragraph(district.ToUpper() + " DISTRICT", subFont);
            title1.Alignment = Element.ALIGN_LEFT | Element.ALIGN_TOP;
            title1.SpacingAfter = 20;
            doc.Add(title1);

            //table
            float[] width = { 1, 4, 4, 1.5f, 1, 3.5f, 5, 5, 4 };
            PdfPTable table = new PdfPTable(report.ColumnCount - 1);
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            table.WidthPercentage = 100;
            table.SetWidths(width);

            //table header
            var headerFont = FontFactory.GetFont("Calibri", 10, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
            var cellFont = FontFactory.GetFont("Calibri", 10);

            foreach (DataGridViewColumn col in report.Columns)
            {
                if (col.Name == "app") continue;
                PdfPCell header = new PdfPCell(new Phrase(col.HeaderText, headerFont));
                header.BackgroundColor = new iTextSharp.text.BaseColor(40, 44, 55);
                header.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(header);
            }

            table.HeaderRows = 1;

            //table cells
            for (int i = 0; i < report.Rows.Count; i++)
            {
                for (int k = 0; k < report.Columns.Count; k++)
                {
                    if (report.Columns[k].Name == "app")
                    {
                        continue;
                    }
                    if (report[k, i].Value != null)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(report[k, i].Value.ToString(), cellFont));
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        table.AddCell(cell);
                    }
                }
            }


            doc.Add(table);

            //other information
            var otherInfo = FontFactory.GetFont("Calibri", 14);
            int t_pwd = table.Rows.Count - 1;
            Paragraph pwd = new Paragraph("Total PWD Members: " + t_pwd.ToString());
            pwd.SpacingBefore = 15;
            //doc.Add(pwd);

            doc.Close();
            doc.Dispose();
            doc = null;
        }
        #endregion

        #region <-- DEVICE: HANDED OUT & REQUESTED --> [PDF]
        public void device_PDF(string file, string date, DataGridView report, string status)
        {
            FileStream fs = new FileStream(file, FileMode.Create, FileAccess.ReadWrite);
            Document doc = new Document(PageSize.LETTER, 40, 40, 35, 35);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();

            //logo
            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(SAD_2_PTT_01.Properties.Resources.pdao_logo, System.Drawing.Imaging.ImageFormat.Jpeg);
            logo.Alignment = Element.ALIGN_CENTER | Element.ALIGN_TOP;
            logo.ScalePercent(40);
            doc.Add(logo);

            //title
            var titleFont = FontFactory.GetFont("Calibri", 13, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            var subFont = FontFactory.GetFont("Calibri", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            Paragraph title = new Paragraph("MASTERLIST OF AVAIL ASSISTIVE DEVICES", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            //title.SpacingAfter = 1;
            doc.Add(title);

            //subtitle
            Paragraph title1 = new Paragraph("(" + status.ToUpper() + " ASSISTIVE DEVICES)", subFont);
            title1.Alignment = Element.ALIGN_CENTER;
            doc.Add(title1);

            //date
            if (date == "") date = DateTime.Now.ToString("MMMM dd, yyyy");
            Paragraph title2 = new Paragraph(date.ToUpper(), subFont);
            title2.Alignment = Element.ALIGN_CENTER;
            title2.SpacingAfter = 20;
            doc.Add(title2);

            //table
            PdfPTable table = new PdfPTable(report.ColumnCount);
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            table.WidthPercentage = 100;

            //table header
            var headerFont = FontFactory.GetFont("Calibri", 10, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
            var cellFont = FontFactory.GetFont("Calibri", 10);

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

        #region <-- PROJECTS: MASTERLIST --> [PDF]
        public void project_reportPDF(string file, string date, DataGridView report)
        {
            FileStream fs = new FileStream(file, FileMode.Create, FileAccess.ReadWrite);
            Document doc = new Document(PageSize.LETTER, 30, 30, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();

            //logo
            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(SAD_2_PTT_01.Properties.Resources.pdao_logo, System.Drawing.Imaging.ImageFormat.Jpeg);
            logo.Alignment = Element.ALIGN_CENTER | Element.ALIGN_TOP;
            logo.SpacingAfter = 5;
            logo.ScalePercent(40);
            doc.Add(logo);

            //title
            var titleFont = FontFactory.GetFont("Calibri", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            var subFont = FontFactory.GetFont("Calibri", 10, BaseColor.BLACK);
            Paragraph title = new Paragraph("MASTERLIST OF PROJECTS", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 1;
            doc.Add(title);

            //date
            Paragraph title2 = new Paragraph(date, titleFont);
            title2.Alignment = Element.ALIGN_CENTER;
            title2.SpacingAfter = 20;
            doc.Add(title2);

            //table
            PdfPTable table = new PdfPTable(report.ColumnCount);
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            table.WidthPercentage = 100;
            int[] width = { 1, 5, 5, 3, 2, 2, 4 };
            table.SetWidths(width);

            //table header
            var headerFont = FontFactory.GetFont("Calibri", 10, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
            var cellFont = FontFactory.GetFont("Calibri", 10);

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

        #region <-- PROJECTS: ATTENDANCE --> [PDF]
        public void project_attendance(string file, string project, string date, string place, string time)
        {
            FileStream fs = new FileStream(file, FileMode.Create, FileAccess.ReadWrite);
            Document doc = new Document(PageSize.LETTER, 50, 50, 40, 40);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();

            //logo
            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(SAD_2_PTT_01.Properties.Resources.pdao_logo, System.Drawing.Imaging.ImageFormat.Jpeg);
            logo.Alignment = Element.ALIGN_CENTER | Element.ALIGN_TOP;
            logo.ScalePercent(40);
            logo.SpacingAfter = 15;
            doc.Add(logo);

            //title
            var titleFont = FontFactory.GetFont("Calibri", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            var subFont = FontFactory.GetFont("Calibri", 10, BaseColor.BLACK);
            Paragraph title = new Paragraph("EVENT: " + project.ToUpper(), titleFont);
            Paragraph title3 = new Paragraph("PLACE: " + place.ToUpper(), titleFont);
            Paragraph title4 = new Paragraph("TIME: " + time, titleFont);
            Paragraph title1 = new Paragraph("LIST OF PARTICIPANTS", titleFont);
            title3.Alignment = title4.Alignment = title.Alignment = Element.ALIGN_LEFT;
            title1.Alignment = Element.ALIGN_CENTER;
            title1.SpacingAfter = 8;
            doc.Add(title1); doc.Add(title); doc.Add(title3); doc.Add(title4);

            //date
            Paragraph title2 = new Paragraph("DATE: " + date, titleFont);
            title2.Alignment = Element.ALIGN_LEFT;
            title2.SpacingAfter = 20;
            doc.Add(title2);

            //list
            getAttendance();
            iTextSharp.text.List list = new List(iTextSharp.text.List.ORDERED);
            list.Numbered = true;
            foreach (string person in pwd)
            {
                list.Add(new ListItem(person));

            }
            doc.Add(list);

            //other information
            var otherInfo = FontFactory.GetFont("Calibri", 12);
            int t_pwd = list.Items.Count;
            Paragraph p = new Paragraph("Total Participants: " + t_pwd.ToString());
            p.SpacingBefore = 15;
            doc.Add(p);

            doc.Close();
            doc.Dispose();
            doc = null;
        }
        #endregion

        #region <-- PWD: CONSOLIDATED REPORTS --> [Excel]
        public void pwd_ExcelReport(string file, DateTime date)
        {
            string[] ageBracket = { "0-2 YRS. OLD", "3-4 YRS. OLD", "5-6 YRS. OLD", "7-12 YRS. OLD", "13-18 YRS. OLD", "19-24 YRS. OLD", "25-59 YRS. OLD", "60 YRS. OLD" };
            string[] district = { "AGDAO", "BAGUIO", "BUHANGIN", "BUNAWAN", "CALINAN", "CITY-A", "CITY-B", "MARILOG", "PAQUIBATO", "TALOMO-A", "TALOMO-B", "TORIL", "TUGBOK" };
            string[] gender = { "M", "F", "M", "F", "M", "F", "M", "F", "M", "F", "M", "F", "M", "F", "M", "F" };
            string format_date = "";
            getDisability(); getDisabilityCount();

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
            wschild.Cells[4, 1, 20, disability_count * 2 + 1].Style.Border.BorderAround(ExcelBorderStyle.Thick);
            wsadult.Cells[4, 1, 20, disability_count * 2 + 1].Style.Border.BorderAround(ExcelBorderStyle.Thick);

            for (int j = 1; j < 17; j++) wsheet.Cells[4, j, 19, j++].Style.Border.BorderAround(ExcelBorderStyle.Thick);
            for (int j = 1; j < disability_count * 2 + 1; j++)
            {
                int k = j + 1;
                wsadult.Cells[4, j, 19, k].Style.Border.BorderAround(ExcelBorderStyle.Thick);
            }
            for (int j = 1; j < disability_count * 2 + 1; j++)
            {
                int k = j + 1;
                wschild.Cells[4, j, 19, k].Style.Border.BorderAround(ExcelBorderStyle.Thick);
            }

            //Title
            var title = wsheet.Cells["A1:Q1"];
            title.Style.HorizontalAlignment = wschild.Cells[1, 1, 1, disability_count * 2 + 1].Style.HorizontalAlignment = wsadult.Cells[1, 1, 1, disability_count * 2 + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            title.Style.Font.Bold = wschild.Cells[1, 1, 1, disability_count * 2 + 1].Style.Font.Bold = wsadult.Cells[1, 1, 1, disability_count * 2 + 1].Style.Font.Bold = true;
            title.Merge = wschild.Cells[1, 1, 1, disability_count * 2 + 1].Merge = wsadult.Cells[1, 1, 1, disability_count * 2 + 1].Merge = true;
            title.Style.Font.Size = wschild.Cells["A1:Q1"].Style.Font.Size = wsadult.Cells["A1:Q1"].Style.Font.Size = 14;

            //SubTitle
            var subDate = wsheet.Cells["A2:Q2"];
            subDate.Merge = wschild.Cells[2, 1, 2, disability_count * 2 + 1].Merge = wsadult.Cells[2, 1, 2, disability_count * 2 + 1].Merge = true;
            subDate.Style.Font.Bold = wschild.Cells["A2:Q2"].Style.Font.Bold = wsadult.Cells["A2:Q2"].Style.Font.Bold = true;
            subDate.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            subDate.Style.HorizontalAlignment = wschild.Cells[2, 1, 2, disability_count * 2 + 1].Style.HorizontalAlignment = wsadult.Cells[2, 1, 2, disability_count * 2 + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            subDate.Style.Font.Size = wschild.Cells[2, 1, 2, disability_count * 2 + 1].Style.Font.Size = wsadult.Cells[2, 1, 2, disability_count * 2 + 1].Style.Font.Size = 13;

            var subCat = wsheet.Cells["A3:Q3"];
            subCat.Merge = wschild.Cells[3, 1, 3, disability_count * 2 + 1].Merge = wsadult.Cells[3, 1, 3, disability_count * 2 + 1].Merge = true;
            subCat.Style.Font.Bold = wschild.Cells[3, 1, 3, disability_count * 2 + 1].Style.Font.Bold = wsadult.Cells[3, 1, 3, disability_count * 2 + 1].Style.Font.Bold = true;
            subCat.Style.HorizontalAlignment = wschild.Cells[3, 1, 3, disability_count * 2 + 1].Style.HorizontalAlignment = wsadult.Cells[3, 1, 3, disability_count * 2 + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            subCat.Style.Font.Size = wschild.Cells[3, 1, 3, disability_count * 2 + 1].Style.Font.Size = wsadult.Cells[3, 1, 3, disability_count * 2 + 1].Style.Font.Size = subDate.Style.Font.Size;

            //District Row
            var disTitle = wsheet.Cells["A4:A5"];
            disTitle.Style.Border.BorderAround(ExcelBorderStyle.Thick);
            wschild.Cells["A4:A5"].Style.Border.BorderAround(ExcelBorderStyle.Thick);
            wsadult.Cells["A4:A5"].Style.Border.BorderAround(ExcelBorderStyle.Thick);
            disTitle.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            disTitle.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            wschild.Cells[4, 1, 4, disability_count * 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            wschild.Cells[4, 1, 4, disability_count * 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            wsadult.Cells[4, 1, 4, disability_count * 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            wsadult.Cells[4, 1, 4, disability_count * 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            wschild.Cells[4, 1, 4, disability_count * 2].Style.Font.Bold = wsadult.Cells[4, 1, 4, disability_count * 2].Style.Font.Bold = true;
            disTitle.Style.Font.Bold = true;
            wsheet.Row(4).Height = 28;

            var districts = wsheet.Cells["A6:A18"];
            districts.Style.Border.Left.Style = districts.Style.Border.Right.Style = ExcelBorderStyle.Thick;
            wsadult.Column(1).Width = wschild.Column(1).Width = wsheet.Column(1).Width = 16;

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
            for (int l = 1; l < disability_count * 2; l++)
            {
                int m;
                wschild.Cells[4, l = l + 1, 4, m = l + 1].Merge = true;
            }
            for (int l = 1; l < disability_count * 2; l++)
            {
                int m;
                wschild.Cells[4, l = l + 1, 4, m = l + 1].Style.Border.BorderAround(ExcelBorderStyle.Thick);
            }
            for (int l = 1; l < disability_count * 2; l++)
            {
                int m;
                wsadult.Cells[4, l = l + 1, 4, m = l + 1].Merge = true;
            }
            for (int l = 1; l < disability_count * 2; l++)
            {
                int m;
                wsadult.Cells[4, l = l + 1, 4, m = l + 1].Style.Border.BorderAround(ExcelBorderStyle.Thick);
            }

            //SubHeaders
            wsheet.Cells["B5:Q5"].Style.Font.Bold = wschild.Cells[5, 2, 5, disability_count * 2].Style.Font.Bold = wsadult.Cells[5, 2, 5, disability_count * 2].Style.Font.Bold = wsadult.Cells[5, disability_count * 2 + 1].Style.Font.Bold = wschild.Cells[5, disability_count * 2 + 1].Style.Font.Bold = true;
            wsheet.Cells["B5:Q5"].Style.HorizontalAlignment = wschild.Cells[5, 2, 5, disability_count * 2].Style.HorizontalAlignment = wsadult.Cells[5, 2, 5, disability_count * 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            wsadult.Cells[5, disability_count * 2 + 1].Style.HorizontalAlignment = wschild.Cells[5, disability_count * 2 + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //values
            wsheet.Cells[6, 2, 19, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            //Total
            wsadult.Cells[19, 2, 19, disability_count * 2 + 1].Style.Font.Bold = wschild.Cells[19, 2, 19, disability_count * 2 + 1].Style.Font.Bold = wsheet.Cells["A19:Q20"].Style.Font.Bold = true;

            //GrandTotal
            wsheet.Cells["B20:Q20"].Merge = wschild.Cells[20, 2, 20, disability_count * 2].Merge = wsadult.Cells[20, 2, 20, disability_count * 2].Merge = true;
            wsheet.Cells["B20:Q20"].Style.Font.Bold = wschild.Cells["B20:Q20"].Style.Font.Bold = wsadult.Cells["B20:Q20"].Style.Font.Bold = true;
            wsheet.Cells["B20:Q20"].Style.Border.BorderAround(ExcelBorderStyle.Thick);
            wsheet.Cells["A20"].Style.Font.Bold = wschild.Cells["A20"].Style.Font.Bold = wsadult.Cells["A20"].Style.Font.Bold = true;
            wsheet.Cells["A20"].Style.Border.Right.Style = wschild.Cells["A20"].Style.Border.Right.Style = wsadult.Cells["A20"].Style.Border.Right.Style = ExcelBorderStyle.Thick;
            wsheet.Cells["B20"].Style.HorizontalAlignment = wschild.Cells["B20"].Style.HorizontalAlignment = wsadult.Cells["B20"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            #endregion

            #region Sheet Format
            //Title
            wsheet.Cells["A1:Q1"].Value = "CONSOLIDATED REPORT ON PWD ISSUED WITH ID'S";
            wschild.Cells[1, 1, 1, disability_count * 2 + 1].Value = wsheet.Cells["A1:Q1"].Value;
            wsadult.Cells[1, 1, 1, disability_count * 2 + 1].Value = wsheet.Cells["A1:Q1"].Value;

            //SubTitle
            if (date.ToString("MMMM") == "January") format_date = "JANUARY " + DateTime.Now.ToString("yyyy");
            else format_date = "JANUARY - " + DateTime.Now.ToString("MMMM yyyy").ToUpper();
            wsheet.Cells["A2:Q2"].Value = wschild.Cells[2, 1, 2, disability_count * 2 + 1].Value = wsadult.Cells[2, 1, 2, disability_count * 2 + 1].Value = format_date;
            wsheet.Cells["A3:Q3"].Value = "(CHILDREN & ADULT CATEGORY)";
            wschild.Cells[3, 1, 3, disability_count * 2 + 1].Value = "(CHILD CATEGORY)";
            wsadult.Cells[3, 1, 3, disability_count * 2 + 1].Value = "(ADULT CATEGORY)";

            //District Columns
            wsheet.Cells["A4:A5"].Merge = wschild.Cells["A4:A5"].Merge = wsadult.Cells["A4:A5"].Merge = true;
            wsheet.Cells["A4:A5"].Value = wschild.Cells["A4:A5"].Value = wsadult.Cells["A4:A5"].Value = "DISTRICT";
            wsheet.Cells["A6"].LoadFromCollection(district);
            wschild.Cells["A6"].LoadFromCollection(district);
            wsadult.Cells["A6"].LoadFromCollection(district);

            //Headers
            int i = 0;
            foreach (var age in ageBracket) wsheet.Cells[4, i = i + 2].Value = age;
            i = 0;
            foreach (var type in disability) wschild.Cells[4, i += 2].Value = type;
            i = 0;
            foreach (var type in disability) wsadult.Cells[4, i += 2].Value = type;

            //SubHeaders [M,F]
            int a = 2;
            foreach (var sex in gender) wsheet.Cells[5, a++].Value = sex;
            for (int m = 1; m < disability_count * 2 + 1; m++)
            {
                int f = m++;
                wschild.Cells[5, m].Value = "M";
                wschild.Cells[5, f++].Value = "F";
                wschild.Cells[5, disability_count * 2 + 1].Value = "F";
            }
            for (int m = 1; m < disability_count * 2 + 1; m++)
            {
                int f = m++;
                wsadult.Cells[5, m].Value = "M";
                wsadult.Cells[5, f++].Value = "F";
                wsadult.Cells[5, disability_count * 2 + 1].Value = "F";
            }

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
            pwd_Children();

            b = 2;
            foreach (var num in Agdao) wschild.Cells[6, b++, 18, disability_count * 2 + 1].Value = num;
            b = 2;
            foreach (var num in Baguio) wschild.Cells[7, b++, 18, disability_count * 2 + 1].Value = num;
            b = 2;
            foreach (var num in Buhangin) wschild.Cells[8, b++, 18, disability_count * 2 + 1].Value = num;
            b = 2;
            foreach (var num in Bunawan) wschild.Cells[9, b++, 18, disability_count * 2 + 1].Value = num;
            b = 2;
            foreach (var num in Calinan) wschild.Cells[10, b++, 18, disability_count * 2 + 1].Value = num;
            b = 2;
            foreach (var num in CityA) wschild.Cells[11, b++, 18, disability_count * 2 + 1].Value = num;
            b = 2;
            foreach (var num in CityB) wschild.Cells[12, b++, 18, disability_count * 2 + 1].Value = num;
            b = 2;
            foreach (var num in Marilog) wschild.Cells[13, b++, 18, disability_count * 2 + 1].Value = num;
            b = 2;
            foreach (var num in Paquibato) wschild.Cells[14, b++, 18, disability_count * 2 + 1].Value = num;
            b = 2;
            foreach (var num in TalomoA) wschild.Cells[15, b++, 18, disability_count * 2 + 1].Value = num;
            b = 2;
            foreach (var num in TalomoB) wschild.Cells[16, b++, 18, disability_count * 2 + 1].Value = num;
            b = 2;
            foreach (var num in Toril) wschild.Cells[17, b++, 18, disability_count * 2 + 1].Value = num;
            b = 2;
            foreach (var num in Tugbok) wschild.Cells[18, b++, 18, disability_count * 2 + 1].Value = num;

            Agdao.Clear(); Baguio.Clear(); Buhangin.Clear(); Bunawan.Clear(); Calinan.Clear(); CityA.Clear();
            CityB.Clear(); Marilog.Clear(); Paquibato.Clear(); TalomoA.Clear(); TalomoB.Clear(); Toril.Clear(); Tugbok.Clear();

            #endregion
            #region -- Sheet3 -- 
            pwd_Adults();
            b = 2;
            foreach (var num in Agdao) wsadult.Cells[6, b++].Value = num;
            b = 2;
            foreach (var num in Baguio) wsadult.Cells[7, b++].Value = num;
            b = 2;
            foreach (var num in Buhangin) wsadult.Cells[8, b++].Value = num;
            b = 2;
            foreach (var num in Bunawan) wsadult.Cells[9, b++].Value = num;
            b = 2;
            foreach (var num in Calinan) wsadult.Cells[10, b++].Value = num;
            b = 2;
            foreach (var num in CityA) wsadult.Cells[11, b++].Value = num;
            b = 2;
            foreach (var num in CityB) wsadult.Cells[12, b++].Value = num;
            b = 2;
            foreach (var num in Marilog) wsadult.Cells[13, b++].Value = num;
            b = 2;
            foreach (var num in Paquibato) wsadult.Cells[14, b++].Value = num;
            b = 2;
            foreach (var num in TalomoA) wsadult.Cells[15, b++].Value = num;
            b = 2;
            foreach (var num in TalomoB) wsadult.Cells[16, b++].Value = num;
            b = 2;
            foreach (var num in Toril) wsadult.Cells[17, b++].Value = num;
            b = 2;
            foreach (var num in Tugbok) wsadult.Cells[18, b++].Value = num;

            Agdao.Clear(); Baguio.Clear(); Buhangin.Clear(); Bunawan.Clear(); Calinan.Clear(); CityA.Clear();
            CityB.Clear(); Marilog.Clear(); Paquibato.Clear(); TalomoA.Clear(); TalomoB.Clear(); Toril.Clear(); Tugbok.Clear();
            #endregion

            #endregion

            //Total
            #region  << Per *Column* Formula >>
            wsheet.Cells["B19"].Formula = "SUM(B6:B18)";
            wsheet.Cells["C19"].Formula = "SUM(C6:C18)";
            wsheet.Cells["D19"].Formula = "SUM(D6:D18)";
            wsheet.Cells["E19"].Formula = "SUM(E6:E18)";
            wsheet.Cells["F19"].Formula = "SUM(F6:F18)";
            wsheet.Cells["G19"].Formula = "SUM(G6:G18)";
            wsheet.Cells["H19"].Formula = "SUM(H6:H18)";
            wsheet.Cells["I19"].Formula = "SUM(I6:I18)";
            wsheet.Cells["J19"].Formula = "SUM(J6:J18)";
            wsheet.Cells["K19"].Formula = "SUM(K6:K18)";
            wsheet.Cells["L19"].Formula = "SUM(L6:L18)";
            wsheet.Cells["M19"].Formula = "SUM(M6:M18)";
            wsheet.Cells["N19"].Formula = "SUM(N6:N18)";
            wsheet.Cells["O19"].Formula = "SUM(O6:O18)";
            wsheet.Cells["P19"].Formula = "SUM(P6:P18)";
            wsheet.Cells["Q19"].Formula = "SUM(Q6:Q18)";

            int d = 2;
            for (int s = 2; s < disability_count * 2 + 2; s++)
            {
                int q = 6;
                wschild.Cells[19, s].FormulaR1C1 += "=R" + q++ + "C" + d + " + R" + q++ + "C" + d + " + R" + q++ + "C" + d + "+ R" + q++ + "C" + d + "" +
                                                     "+ R" + q++ + "C" + d + " + R" + q++ + "C" + d + " + R" + q++ + "C" + d + " + R" + q++ + "C" + d +
                                                     "+ R" + q++ + "C" + d + "+ R" + q++ + "C" + d + "+ R" + q++ + "C" + d + "+ R" + q++ + "C" + d + " + R" + q++ + "C" + d + "";
                d++;
            }
            d = 2;
            for (int s = 2; s < disability_count * 2 + 2; s++)
            {
                int q = 6;
                wsadult.Cells[19, s].FormulaR1C1 += "=R" + q++ + "C" + d + " + R" + q++ + "C" + d + " + R" + q++ + "C" + d + "+ R" + q++ + "C" + d + "" +
                                                     "+ R" + q++ + "C" + d + " + R" + q++ + "C" + d + " + R" + q++ + "C" + d + " + R" + q++ + "C" + d +
                                                     "+ R" + q++ + "C" + d + "+ R" + q++ + "C" + d + "+ R" + q++ + "C" + d + "+ R" + q++ + "C" + d + " + R" + q++ + "C" + d + "";
                d++;
            }
            #endregion

            wsheet.Cells["A19"].Value = wschild.Cells["A19"].Value = wsadult.Cells["A19"].Value = "TOTAL";

            //GrandTotal
            ExcelRange range = wschild.Cells[19, 2, 19, disability_count * 2 + 1];
            ExcelRange range1 = wsadult.Cells[19, 2, 19, disability_count * 2 + 1];
            wsheet.Cells["B20"].Formula = "SUM(B19:Q19)";
            wschild.Cells["B20"].FormulaR1C1 = "SUM(R19C2:R19C[" + range.Count() + "])";
            wsadult.Cells["B20"].FormulaR1C1 = "SUM(R19C2:R19C[" + range1.Count() + "])";

            wschild.Cells[20, 2, 20, disability_count * 2 + 1].Merge = wsadult.Cells[20, 2, 20, disability_count * 2 + 1].Merge = true;
            wsheet.Cells["A20"].Value = wschild.Cells["A20"].Value = wsadult.Cells["A20"].Value = "GRAND TOTAL";
            #endregion

            using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.ReadWrite))
            {
                exc.SaveAs(fs);
            }

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
        public string[] distQuery = { " AND district_id = 1;", " AND district_id = 2;", " AND district_id = 3;", " AND district_id = 4;", " AND district_id = 5;", " AND district_id = 6;",
                                      " AND district_id = 7;", " AND district_id = 8;", " AND district_id = 9;", " AND district_id = 10;", " AND district_id = 11;", " AND district_id = 12;",
                                      " AND district_id = 13;"};
        public string year = " AND year(application_date) = " + DateTime.Now.ToString("yyyy") + "";

        public void pwd_Districts()
        {
            string select = "SELECT COUNT(" + age + ") AS c FROM p_dao.pwd WHERE ";
            string cm1, cm2, cm3, cm4, cm5, cm6, cm7, cm8;
            string cf1, cf2, cf3, cf4, cf5, cf6, cf7, cf8;
            string query = "";
            int num = 0;

            // add district id paaa >.<
            for (num = 0; num < 13; num++)
            {
                cm1 = select + age + ageQuery[0] + year + distQuery[num];
                cf1 = select + age + ageQuery[1] + year + distQuery[num];
                cm2 = select + age + ageQuery[2] + year + distQuery[num];
                cf2 = select + age + ageQuery[3] + year + distQuery[num];
                cm3 = select + age + ageQuery[4] + year + distQuery[num];
                cf3 = select + age + ageQuery[5] + year + distQuery[num];
                cm4 = select + age + ageQuery[6] + year + distQuery[num];
                cf4 = select + age + ageQuery[7] + year + distQuery[num];
                cm5 = select + age + ageQuery[8] + year + distQuery[num];
                cf5 = select + age + ageQuery[9] + year + distQuery[num];
                cm6 = select + age + ageQuery[10] + year + distQuery[num];
                cf6 = select + age + ageQuery[11] + year + distQuery[num];
                cm7 = select + age + ageQuery[12] + year + distQuery[num];
                cf7 = select + age + ageQuery[13] + year + distQuery[num];
                cm8 = select + age + ageQuery[14] + year + distQuery[num];
                cf8 = select + age + ageQuery[15] + year + distQuery[num];

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

        #region << Child >>
        public void pwd_Children()
        {

            string select = "SELECT COUNT(lastname) AS c FROM p_dao.pwd WHERE ";
            string ageQuery = " AND " + age + " BETWEEN 0 AND 18";
            string male = " AND sex = 0";
            string female = " AND sex = 1";
            string disability = "disability_id = ";
            string query = "", query1 = "", query2 = "", query3 = "", query4 = "";
            string query5 = "", query6 = "", query7 = "", query8 = "", query9 = "";
            string query10 = "", query11 = "", query12 = "";
            int i;

            for (i = 1; i < disability_count + 1; i++)
            {
                query += select + disability + i + ageQuery + male + year + distQuery[0] + select + disability + i + ageQuery + female + year + distQuery[0];
                getQuery(query, 0);

                query1 += select + disability + i + ageQuery + male + year + distQuery[1] + select + disability + i + ageQuery + female + year + distQuery[1];
                getQuery(query1, 1);

                query2 += select + disability + i + ageQuery + male + year + distQuery[2] + select + disability + i + ageQuery + female + year + distQuery[2];
                getQuery(query2, 2);

                query3 += select + disability + i + ageQuery + male + year + distQuery[3] + select + disability + i + ageQuery + female + year + distQuery[3];
                getQuery(query3, 3);

                query4 += select + disability + i + ageQuery + male + year + distQuery[4] + select + disability + i + ageQuery + female + year + distQuery[4];
                getQuery(query4, 4);

                query5 += select + disability + i + ageQuery + male + year + distQuery[5] + select + disability + i + ageQuery + female + year + distQuery[5];
                getQuery(query5, 5);

                query6 += select + disability + i + ageQuery + male + year + distQuery[6] + select + disability + i + ageQuery + female + year + distQuery[6];
                getQuery(query6, 6);

                query7 += select + disability + i + ageQuery + male + year + distQuery[7] + select + disability + i + ageQuery + female + year + distQuery[7];
                getQuery(query7, 7);

                query8 += select + disability + i + ageQuery + male + year + distQuery[8] + select + disability + i + ageQuery + female + year + distQuery[8];
                getQuery(query8, 8);

                query9 += select + disability + i + ageQuery + male + year + distQuery[9] + select + disability + i + ageQuery + female + year + distQuery[9];
                getQuery(query9, 9);

                query10 += select + disability + i + ageQuery + male + year + distQuery[10] + select + disability + i + ageQuery + female + year + distQuery[10];
                getQuery(query10, 10);

                query11 += select + disability + i + ageQuery + male + year + distQuery[11] + select + disability + i + ageQuery + female + year + distQuery[11];
                getQuery(query11, 11);

                query12 += select + disability + i + ageQuery + male + year + distQuery[12] + select + disability + i + ageQuery + female + year + distQuery[12];
                getQuery(query12, 12);
            }

        }

        #endregion

        #region << Adult >>
        public void pwd_Adults()
        {

            string select = "SELECT COUNT(lastname) AS c FROM p_dao.pwd WHERE ";
            string ageQuery = " AND " + age + " BETWEEN 19 AND 60";
            string male = " AND sex = 0";
            string female = " AND sex = 1";
            string disability = "disability_id = ";
            string query = "", query1 = "", query2 = "", query3 = "", query4 = "";
            string query5 = "", query6 = "", query7 = "", query8 = "", query9 = "";
            string query10 = "", query11 = "", query12 = "";
            int i;

            for (i = 1; i < disability_count + 1; i++)
            {
                query += select + disability + i + ageQuery + male + year + distQuery[0] + select + disability + i + ageQuery + female + year + distQuery[0];
                getQuery(query, 0);

                query1 += select + disability + i + ageQuery + male + year + distQuery[1] + select + disability + i + ageQuery + female + year + distQuery[1];
                getQuery(query1, 1);

                query2 += select + disability + i + ageQuery + male + year + distQuery[2] + select + disability + i + ageQuery + female + year + distQuery[2];
                getQuery(query2, 2);

                query3 += select + disability + i + ageQuery + male + year + distQuery[3] + select + disability + i + ageQuery + female + year + distQuery[3];
                getQuery(query3, 3);

                query4 += select + disability + i + ageQuery + male + year + distQuery[4] + select + disability + i + ageQuery + female + year + distQuery[4];
                getQuery(query4, 4);

                query5 += select + disability + i + ageQuery + male + year + distQuery[5] + select + disability + i + ageQuery + female + year + distQuery[5];
                getQuery(query5, 5);

                query6 += select + disability + i + ageQuery + male + year + distQuery[6] + select + disability + i + ageQuery + female + year + distQuery[6];
                getQuery(query6, 6);

                query7 += select + disability + i + ageQuery + male + year + distQuery[7] + select + disability + i + ageQuery + female + year + distQuery[7];
                getQuery(query7, 7);

                query8 += select + disability + i + ageQuery + male + year + distQuery[8] + select + disability + i + ageQuery + female + year + distQuery[8];
                getQuery(query8, 8);

                query9 += select + disability + i + ageQuery + male + year + distQuery[9] + select + disability + i + ageQuery + female + year + distQuery[9];
                getQuery(query9, 9);

                query10 += select + disability + i + ageQuery + male + year + distQuery[10] + select + disability + i + ageQuery + female + year + distQuery[10];
                getQuery(query10, 10);

                query11 += select + disability + i + ageQuery + male + year + distQuery[11] + select + disability + i + ageQuery + female + year + distQuery[11];
                getQuery(query11, 11);

                query12 += select + disability + i + ageQuery + male + year + distQuery[12] + select + disability + i + ageQuery + female + year + distQuery[12];
                getQuery(query12, 12);
            }
        }
        #endregion


        #endregion
    }
}
