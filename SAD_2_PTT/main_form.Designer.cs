namespace SAD_2_PTT
{
    partial class main_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.controlbox = new System.Windows.Forms.Panel();
            this.btn_min = new System.Windows.Forms.Button();
            this.btn_max = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.curren_name = new System.Windows.Forms.Label();
            this.main_name = new System.Windows.Forms.Label();
            this.main_tab = new System.Windows.Forms.Panel();
            this.sidenav = new System.Windows.Forms.Panel();
            this.side_tab = new System.Windows.Forms.Panel();
            this.btn_settings = new System.Windows.Forms.Button();
            this.btn_logout = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.btn_reports = new System.Windows.Forms.Button();
            this.btn_projects = new System.Windows.Forms.Button();
            this.btn_device = new System.Windows.Forms.Button();
            this.btn_pwd = new System.Windows.Forms.Button();
            this.btn_dashboard = new System.Windows.Forms.Button();
            this.btn_profilepic = new System.Windows.Forms.Button();
            this.controlbox.SuspendLayout();
            this.main_tab.SuspendLayout();
            this.side_tab.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlbox
            // 
            this.controlbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.controlbox.Controls.Add(this.btn_min);
            this.controlbox.Controls.Add(this.btn_max);
            this.controlbox.Controls.Add(this.btn_close);
            this.controlbox.Controls.Add(this.curren_name);
            this.controlbox.Controls.Add(this.main_name);
            this.controlbox.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlbox.Location = new System.Drawing.Point(0, 0);
            this.controlbox.Name = "controlbox";
            this.controlbox.Size = new System.Drawing.Size(1102, 31);
            this.controlbox.TabIndex = 1;
            // 
            // btn_min
            // 
            this.btn_min.BackColor = System.Drawing.Color.Transparent;
            this.btn_min.BackgroundImage = global::SAD_2_PTT.Properties.Resources.control_min;
            this.btn_min.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_min.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_min.FlatAppearance.BorderSize = 0;
            this.btn_min.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btn_min.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.btn_min.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_min.Location = new System.Drawing.Point(1000, 0);
            this.btn_min.Name = "btn_min";
            this.btn_min.Size = new System.Drawing.Size(34, 31);
            this.btn_min.TabIndex = 2;
            this.btn_min.UseVisualStyleBackColor = false;
            this.btn_min.Click += new System.EventHandler(this.btn_min_Click);
            // 
            // btn_max
            // 
            this.btn_max.BackColor = System.Drawing.Color.Transparent;
            this.btn_max.BackgroundImage = global::SAD_2_PTT.Properties.Resources.control_max;
            this.btn_max.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_max.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_max.FlatAppearance.BorderSize = 0;
            this.btn_max.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btn_max.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.btn_max.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_max.Location = new System.Drawing.Point(1034, 0);
            this.btn_max.Name = "btn_max";
            this.btn_max.Size = new System.Drawing.Size(34, 31);
            this.btn_max.TabIndex = 1;
            this.btn_max.UseVisualStyleBackColor = false;
            this.btn_max.Click += new System.EventHandler(this.btn_max_Click);
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.Transparent;
            this.btn_close.BackgroundImage = global::SAD_2_PTT.Properties.Resources.control_close;
            this.btn_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btn_close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Location = new System.Drawing.Point(1068, 0);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(34, 31);
            this.btn_close.TabIndex = 0;
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // curren_name
            // 
            this.curren_name.AutoSize = true;
            this.curren_name.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.curren_name.ForeColor = System.Drawing.Color.Silver;
            this.curren_name.Location = new System.Drawing.Point(83, 6);
            this.curren_name.Name = "curren_name";
            this.curren_name.Size = new System.Drawing.Size(42, 18);
            this.curren_name.TabIndex = 0;
            this.curren_name.Text = "Home";
            // 
            // main_name
            // 
            this.main_name.AutoSize = true;
            this.main_name.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main_name.ForeColor = System.Drawing.Color.Silver;
            this.main_name.Location = new System.Drawing.Point(37, 6);
            this.main_name.Name = "main_name";
            this.main_name.Size = new System.Drawing.Size(49, 18);
            this.main_name.TabIndex = 0;
            this.main_name.Text = "PDAO -";
            // 
            // main_tab
            // 
            this.main_tab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.main_tab.Controls.Add(this.sidenav);
            this.main_tab.Controls.Add(this.side_tab);
            this.main_tab.Dock = System.Windows.Forms.DockStyle.Left;
            this.main_tab.Location = new System.Drawing.Point(0, 31);
            this.main_tab.Name = "main_tab";
            this.main_tab.Size = new System.Drawing.Size(283, 608);
            this.main_tab.TabIndex = 2;
            // 
            // sidenav
            // 
            this.sidenav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.sidenav.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidenav.Location = new System.Drawing.Point(71, 0);
            this.sidenav.Name = "sidenav";
            this.sidenav.Size = new System.Drawing.Size(194, 608);
            this.sidenav.TabIndex = 3;
            // 
            // side_tab
            // 
            this.side_tab.Controls.Add(this.btn_settings);
            this.side_tab.Controls.Add(this.btn_logout);
            this.side_tab.Controls.Add(this.button7);
            this.side_tab.Controls.Add(this.btn_reports);
            this.side_tab.Controls.Add(this.btn_projects);
            this.side_tab.Controls.Add(this.btn_device);
            this.side_tab.Controls.Add(this.btn_pwd);
            this.side_tab.Controls.Add(this.btn_dashboard);
            this.side_tab.Controls.Add(this.btn_profilepic);
            this.side_tab.Dock = System.Windows.Forms.DockStyle.Left;
            this.side_tab.Location = new System.Drawing.Point(0, 0);
            this.side_tab.Name = "side_tab";
            this.side_tab.Size = new System.Drawing.Size(71, 608);
            this.side_tab.TabIndex = 0;
            // 
            // btn_settings
            // 
            this.btn_settings.BackColor = System.Drawing.Color.Transparent;
            this.btn_settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_settings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_settings.FlatAppearance.BorderSize = 0;
            this.btn_settings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(16)))));
            this.btn_settings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.btn_settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_settings.ForeColor = System.Drawing.Color.White;
            this.btn_settings.Location = new System.Drawing.Point(0, 508);
            this.btn_settings.Name = "btn_settings";
            this.btn_settings.Size = new System.Drawing.Size(71, 50);
            this.btn_settings.TabIndex = 14;
            this.btn_settings.Text = "ST";
            this.btn_settings.UseVisualStyleBackColor = false;
            this.btn_settings.Click += new System.EventHandler(this.btn_settings_Click);
            // 
            // btn_logout
            // 
            this.btn_logout.BackColor = System.Drawing.Color.Transparent;
            this.btn_logout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_logout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_logout.FlatAppearance.BorderSize = 0;
            this.btn_logout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(16)))));
            this.btn_logout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.btn_logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_logout.ForeColor = System.Drawing.Color.White;
            this.btn_logout.Location = new System.Drawing.Point(0, 558);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(71, 50);
            this.btn_logout.TabIndex = 13;
            this.btn_logout.Text = "LO";
            this.btn_logout.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button7.Dock = System.Windows.Forms.DockStyle.Top;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(16)))));
            this.button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(0, 438);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(71, 73);
            this.button7.TabIndex = 10;
            this.button7.Text = "-";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // btn_reports
            // 
            this.btn_reports.BackColor = System.Drawing.Color.Transparent;
            this.btn_reports.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_reports.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_reports.FlatAppearance.BorderSize = 0;
            this.btn_reports.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(16)))));
            this.btn_reports.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.btn_reports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reports.ForeColor = System.Drawing.Color.White;
            this.btn_reports.Location = new System.Drawing.Point(0, 365);
            this.btn_reports.Name = "btn_reports";
            this.btn_reports.Size = new System.Drawing.Size(71, 73);
            this.btn_reports.TabIndex = 9;
            this.btn_reports.Text = "RP";
            this.btn_reports.UseVisualStyleBackColor = false;
            this.btn_reports.Click += new System.EventHandler(this.btn_reports_Click);
            // 
            // btn_projects
            // 
            this.btn_projects.BackColor = System.Drawing.Color.Transparent;
            this.btn_projects.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_projects.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_projects.FlatAppearance.BorderSize = 0;
            this.btn_projects.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(16)))));
            this.btn_projects.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.btn_projects.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_projects.ForeColor = System.Drawing.Color.White;
            this.btn_projects.Location = new System.Drawing.Point(0, 292);
            this.btn_projects.Name = "btn_projects";
            this.btn_projects.Size = new System.Drawing.Size(71, 73);
            this.btn_projects.TabIndex = 8;
            this.btn_projects.Text = "PM";
            this.btn_projects.UseVisualStyleBackColor = false;
            this.btn_projects.Click += new System.EventHandler(this.btn_projects_Click);
            // 
            // btn_device
            // 
            this.btn_device.BackColor = System.Drawing.Color.Transparent;
            this.btn_device.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_device.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_device.FlatAppearance.BorderSize = 0;
            this.btn_device.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(16)))));
            this.btn_device.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.btn_device.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_device.ForeColor = System.Drawing.Color.White;
            this.btn_device.Location = new System.Drawing.Point(0, 219);
            this.btn_device.Name = "btn_device";
            this.btn_device.Size = new System.Drawing.Size(71, 73);
            this.btn_device.TabIndex = 7;
            this.btn_device.Text = "DR";
            this.btn_device.UseVisualStyleBackColor = false;
            this.btn_device.Click += new System.EventHandler(this.btn_device_Click);
            // 
            // btn_pwd
            // 
            this.btn_pwd.BackColor = System.Drawing.Color.Transparent;
            this.btn_pwd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_pwd.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_pwd.FlatAppearance.BorderSize = 0;
            this.btn_pwd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(16)))));
            this.btn_pwd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.btn_pwd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pwd.ForeColor = System.Drawing.Color.White;
            this.btn_pwd.Location = new System.Drawing.Point(0, 146);
            this.btn_pwd.Name = "btn_pwd";
            this.btn_pwd.Size = new System.Drawing.Size(71, 73);
            this.btn_pwd.TabIndex = 6;
            this.btn_pwd.Text = "PWD";
            this.btn_pwd.UseVisualStyleBackColor = false;
            this.btn_pwd.Click += new System.EventHandler(this.btn_pwd_Click);
            // 
            // btn_dashboard
            // 
            this.btn_dashboard.BackColor = System.Drawing.Color.Transparent;
            this.btn_dashboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_dashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_dashboard.FlatAppearance.BorderSize = 0;
            this.btn_dashboard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(16)))));
            this.btn_dashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.btn_dashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dashboard.ForeColor = System.Drawing.Color.White;
            this.btn_dashboard.Location = new System.Drawing.Point(0, 73);
            this.btn_dashboard.Name = "btn_dashboard";
            this.btn_dashboard.Size = new System.Drawing.Size(71, 73);
            this.btn_dashboard.TabIndex = 5;
            this.btn_dashboard.Text = "DB";
            this.btn_dashboard.UseVisualStyleBackColor = false;
            this.btn_dashboard.Click += new System.EventHandler(this.btn_dashboard_Click);
            // 
            // btn_profilepic
            // 
            this.btn_profilepic.BackColor = System.Drawing.Color.Transparent;
            this.btn_profilepic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_profilepic.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_profilepic.FlatAppearance.BorderSize = 0;
            this.btn_profilepic.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(16)))));
            this.btn_profilepic.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.btn_profilepic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_profilepic.Location = new System.Drawing.Point(0, 0);
            this.btn_profilepic.Name = "btn_profilepic";
            this.btn_profilepic.Size = new System.Drawing.Size(71, 73);
            this.btn_profilepic.TabIndex = 4;
            this.btn_profilepic.Text = "PP";
            this.btn_profilepic.UseVisualStyleBackColor = false;
            this.btn_profilepic.Click += new System.EventHandler(this.btn_profilepic_Click);
            // 
            // main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 639);
            this.Controls.Add(this.main_tab);
            this.Controls.Add(this.controlbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "main_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.main_form_Load);
            this.controlbox.ResumeLayout(false);
            this.controlbox.PerformLayout();
            this.main_tab.ResumeLayout(false);
            this.side_tab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel controlbox;
        private System.Windows.Forms.Button btn_min;
        private System.Windows.Forms.Button btn_max;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label curren_name;
        private System.Windows.Forms.Label main_name;
        private System.Windows.Forms.Panel main_tab;
        private System.Windows.Forms.Panel sidenav;
        private System.Windows.Forms.Panel side_tab;
        public System.Windows.Forms.Button btn_settings;
        private System.Windows.Forms.Button btn_logout;
        private System.Windows.Forms.Button button7;
        public System.Windows.Forms.Button btn_reports;
        public System.Windows.Forms.Button btn_projects;
        public System.Windows.Forms.Button btn_device;
        public System.Windows.Forms.Button btn_pwd;
        public System.Windows.Forms.Button btn_dashboard;
        public System.Windows.Forms.Button btn_profilepic;
    }
}

