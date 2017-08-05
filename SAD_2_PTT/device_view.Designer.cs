namespace SAD_2_PTT
{
    partial class device_view
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bar = new System.Windows.Forms.Panel();
            this.lbl_title = new System.Windows.Forms.Label();
            this.btn_close = new System.Windows.Forms.Button();
            this.dev_editreq = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.pnl_edit = new System.Windows.Forms.Panel();
            this.edit_info = new System.Windows.Forms.Panel();
            this.txt_desc = new System.Windows.Forms.RichTextBox();
            this.cmbox_dis = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbox_prov = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbox_dev = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.date_out = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.date_in = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.request_date = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.edit_stat = new System.Windows.Forms.Panel();
            this.cmbox_stat = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pnl_regno = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pnl_name = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.startup_opacity = new System.Windows.Forms.Timer(this.components);
            this.pnl_search = new System.Windows.Forms.Panel();
            this.button45 = new System.Windows.Forms.Button();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.btn_req = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_rec = new System.Windows.Forms.Button();
            this.btn_ho = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btn_default = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dev_editreq)).BeginInit();
            this.pnl_edit.SuspendLayout();
            this.edit_info.SuspendLayout();
            this.edit_stat.SuspendLayout();
            this.pnl_regno.SuspendLayout();
            this.pnl_name.SuspendLayout();
            this.pnl_search.SuspendLayout();
            this.SuspendLayout();
            // 
            // bar
            // 
            this.bar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.bar.Location = new System.Drawing.Point(-1, 59);
            this.bar.Name = "bar";
            this.bar.Size = new System.Drawing.Size(864, 38);
            this.bar.TabIndex = 16;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.Location = new System.Drawing.Point(14, 10);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(167, 30);
            this.lbl_title.TabIndex = 15;
            this.lbl_title.Text = "VIEW REQUESTS";
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Image = global::SAD_2_PTT.Properties.Resources.close;
            this.btn_close.Location = new System.Drawing.Point(791, 1);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(70, 57);
            this.btn_close.TabIndex = 14;
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // dev_editreq
            // 
            this.dev_editreq.AllowUserToAddRows = false;
            this.dev_editreq.AllowUserToDeleteRows = false;
            this.dev_editreq.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dev_editreq.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dev_editreq.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dev_editreq.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dev_editreq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(45)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dev_editreq.DefaultCellStyle = dataGridViewCellStyle1;
            this.dev_editreq.Location = new System.Drawing.Point(22, 150);
            this.dev_editreq.MultiSelect = false;
            this.dev_editreq.Name = "dev_editreq";
            this.dev_editreq.ReadOnly = true;
            this.dev_editreq.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dev_editreq.RowHeadersVisible = false;
            this.dev_editreq.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dev_editreq.Size = new System.Drawing.Size(821, 332);
            this.dev_editreq.TabIndex = 17;
            this.dev_editreq.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Window;
            this.button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(310, 299);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 27);
            this.button1.TabIndex = 18;
            this.button1.Text = "Edit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnl_edit
            // 
            this.pnl_edit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnl_edit.Controls.Add(this.edit_info);
            this.pnl_edit.Controls.Add(this.edit_stat);
            this.pnl_edit.Controls.Add(this.pnl_regno);
            this.pnl_edit.Controls.Add(this.pnl_name);
            this.pnl_edit.Location = new System.Drawing.Point(22, 150);
            this.pnl_edit.Name = "pnl_edit";
            this.pnl_edit.Size = new System.Drawing.Size(821, 332);
            this.pnl_edit.TabIndex = 19;
            // 
            // edit_info
            // 
            this.edit_info.BackColor = System.Drawing.SystemColors.Window;
            this.edit_info.Controls.Add(this.txt_desc);
            this.edit_info.Controls.Add(this.cmbox_dis);
            this.edit_info.Controls.Add(this.label11);
            this.edit_info.Controls.Add(this.cmbox_prov);
            this.edit_info.Controls.Add(this.label5);
            this.edit_info.Controls.Add(this.button1);
            this.edit_info.Controls.Add(this.cmbox_dev);
            this.edit_info.Controls.Add(this.label4);
            this.edit_info.Controls.Add(this.date_out);
            this.edit_info.Controls.Add(this.button2);
            this.edit_info.Controls.Add(this.label2);
            this.edit_info.Controls.Add(this.date_in);
            this.edit_info.Controls.Add(this.label1);
            this.edit_info.Controls.Add(this.request_date);
            this.edit_info.Controls.Add(this.label9);
            this.edit_info.Controls.Add(this.label10);
            this.edit_info.Location = new System.Drawing.Point(319, 0);
            this.edit_info.Name = "edit_info";
            this.edit_info.Size = new System.Drawing.Size(502, 332);
            this.edit_info.TabIndex = 72;
            // 
            // txt_desc
            // 
            this.txt_desc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_desc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_desc.Location = new System.Drawing.Point(156, 158);
            this.txt_desc.Name = "txt_desc";
            this.txt_desc.Size = new System.Drawing.Size(326, 62);
            this.txt_desc.TabIndex = 64;
            this.txt_desc.Text = "";
            // 
            // cmbox_dis
            // 
            this.cmbox_dis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbox_dis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbox_dis.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbox_dis.FormattingEnabled = true;
            this.cmbox_dis.Items.AddRange(new object[] {
            ""});
            this.cmbox_dis.Location = new System.Drawing.Point(156, 12);
            this.cmbox_dis.Name = "cmbox_dis";
            this.cmbox_dis.Size = new System.Drawing.Size(188, 25);
            this.cmbox_dis.TabIndex = 71;
            this.cmbox_dis.SelectedIndexChanged += new System.EventHandler(this.cmbox_dis_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(25, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 15);
            this.label11.TabIndex = 70;
            this.label11.Text = "Disability :";
            // 
            // cmbox_prov
            // 
            this.cmbox_prov.BackColor = System.Drawing.SystemColors.Window;
            this.cmbox_prov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbox_prov.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbox_prov.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbox_prov.FormattingEnabled = true;
            this.cmbox_prov.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbox_prov.Items.AddRange(new object[] {
            ""});
            this.cmbox_prov.Location = new System.Drawing.Point(156, 82);
            this.cmbox_prov.Name = "cmbox_prov";
            this.cmbox_prov.Size = new System.Drawing.Size(188, 23);
            this.cmbox_prov.TabIndex = 69;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 15);
            this.label5.TabIndex = 60;
            this.label5.Text = "Requested Date :";
            // 
            // cmbox_dev
            // 
            this.cmbox_dev.BackColor = System.Drawing.SystemColors.Window;
            this.cmbox_dev.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbox_dev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbox_dev.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbox_dev.FormattingEnabled = true;
            this.cmbox_dev.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbox_dev.Items.AddRange(new object[] {
            ""});
            this.cmbox_dev.Location = new System.Drawing.Point(156, 49);
            this.cmbox_dev.Name = "cmbox_dev";
            this.cmbox_dev.Size = new System.Drawing.Size(188, 23);
            this.cmbox_dev.TabIndex = 68;
            this.cmbox_dev.SelectedIndexChanged += new System.EventHandler(this.cmbox_dev_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 15);
            this.label4.TabIndex = 59;
            this.label4.Text = "Device  Provider :";
            // 
            // date_out
            // 
            this.date_out.CustomFormat = "";
            this.date_out.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_out.Location = new System.Drawing.Point(156, 267);
            this.date_out.Name = "date_out";
            this.date_out.Size = new System.Drawing.Size(188, 23);
            this.date_out.TabIndex = 67;
            this.date_out.Value = new System.DateTime(2017, 7, 11, 0, 0, 0, 0);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Window;
            this.button2.FlatAppearance.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(403, 299);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 27);
            this.button2.TabIndex = 31;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 15);
            this.label2.TabIndex = 58;
            this.label2.Text = "Device Requested :";
            // 
            // date_in
            // 
            this.date_in.CustomFormat = "";
            this.date_in.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_in.Location = new System.Drawing.Point(156, 235);
            this.date_in.Name = "date_in";
            this.date_in.Size = new System.Drawing.Size(188, 23);
            this.date_in.TabIndex = 66;
            this.date_in.Value = new System.DateTime(2017, 7, 11, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 15);
            this.label1.TabIndex = 61;
            this.label1.Text = "Request Description :";
            // 
            // request_date
            // 
            this.request_date.CalendarTrailingForeColor = System.Drawing.SystemColors.Window;
            this.request_date.CustomFormat = "mm/dd/yyyy";
            this.request_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.request_date.Location = new System.Drawing.Point(156, 117);
            this.request_date.Name = "request_date";
            this.request_date.Size = new System.Drawing.Size(188, 23);
            this.request_date.TabIndex = 65;
            this.request_date.Value = new System.DateTime(2017, 7, 9, 0, 0, 0, 0);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(28, 273);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 15);
            this.label9.TabIndex = 62;
            this.label9.Text = "Date OUT :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(28, 236);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 15);
            this.label10.TabIndex = 63;
            this.label10.Text = "Date IN :";
            // 
            // edit_stat
            // 
            this.edit_stat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.edit_stat.Controls.Add(this.cmbox_stat);
            this.edit_stat.Controls.Add(this.label6);
            this.edit_stat.Location = new System.Drawing.Point(0, 280);
            this.edit_stat.Name = "edit_stat";
            this.edit_stat.Size = new System.Drawing.Size(300, 52);
            this.edit_stat.TabIndex = 73;
            // 
            // cmbox_stat
            // 
            this.cmbox_stat.BackColor = System.Drawing.SystemColors.Window;
            this.cmbox_stat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbox_stat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbox_stat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbox_stat.FormattingEnabled = true;
            this.cmbox_stat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbox_stat.Items.AddRange(new object[] {
            "Requested",
            "Received",
            "Handed Out"});
            this.cmbox_stat.Location = new System.Drawing.Point(90, 16);
            this.cmbox_stat.Name = "cmbox_stat";
            this.cmbox_stat.Size = new System.Drawing.Size(172, 23);
            this.cmbox_stat.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Window;
            this.label6.Location = new System.Drawing.Point(13, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "STATUS";
            // 
            // pnl_regno
            // 
            this.pnl_regno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.pnl_regno.Controls.Add(this.label3);
            this.pnl_regno.Location = new System.Drawing.Point(0, 0);
            this.pnl_regno.Name = "pnl_regno";
            this.pnl_regno.Size = new System.Drawing.Size(300, 52);
            this.pnl_regno.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(13, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "REG. NO.";
            // 
            // pnl_name
            // 
            this.pnl_name.BackColor = System.Drawing.SystemColors.Window;
            this.pnl_name.Controls.Add(this.label7);
            this.pnl_name.Location = new System.Drawing.Point(0, 72);
            this.pnl_name.Name = "pnl_name";
            this.pnl_name.Size = new System.Drawing.Size(300, 186);
            this.pnl_name.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(13, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "NAME";
            // 
            // startup_opacity
            // 
            this.startup_opacity.Interval = 1;
            this.startup_opacity.Tick += new System.EventHandler(this.startup_opacity_Tick);
            // 
            // pnl_search
            // 
            this.pnl_search.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_search.Controls.Add(this.button45);
            this.pnl_search.Controls.Add(this.txt_search);
            this.pnl_search.Location = new System.Drawing.Point(22, 113);
            this.pnl_search.Name = "pnl_search";
            this.pnl_search.Size = new System.Drawing.Size(377, 25);
            this.pnl_search.TabIndex = 44;
            // 
            // button45
            // 
            this.button45.Dock = System.Windows.Forms.DockStyle.Right;
            this.button45.FlatAppearance.BorderSize = 0;
            this.button45.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button45.Image = global::SAD_2_PTT.Properties.Resources.search;
            this.button45.Location = new System.Drawing.Point(343, 0);
            this.button45.Name = "button45";
            this.button45.Size = new System.Drawing.Size(32, 23);
            this.button45.TabIndex = 2;
            this.button45.UseVisualStyleBackColor = true;
            // 
            // txt_search
            // 
            this.txt_search.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_search.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_search.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_search.Location = new System.Drawing.Point(-1, -1);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(346, 25);
            this.txt_search.TabIndex = 0;
            this.txt_search.Text = "  Search here..";
            this.txt_search.TextChanged += new System.EventHandler(this.txt_search_TextChanged);
            this.txt_search.Enter += new System.EventHandler(this.txt_search_Enter);
            // 
            // btn_req
            // 
            this.btn_req.BackColor = System.Drawing.Color.White;
            this.btn_req.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_req.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btn_req.Location = new System.Drawing.Point(517, 114);
            this.btn_req.Name = "btn_req";
            this.btn_req.Size = new System.Drawing.Size(26, 24);
            this.btn_req.TabIndex = 45;
            this.btn_req.UseVisualStyleBackColor = false;
            this.btn_req.Click += new System.EventHandler(this.btn_req_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(549, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 15);
            this.label8.TabIndex = 46;
            this.label8.Text = "Requested";
            // 
            // btn_rec
            // 
            this.btn_rec.BackColor = System.Drawing.Color.White;
            this.btn_rec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_rec.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btn_rec.Location = new System.Drawing.Point(629, 114);
            this.btn_rec.Name = "btn_rec";
            this.btn_rec.Size = new System.Drawing.Size(26, 24);
            this.btn_rec.TabIndex = 47;
            this.btn_rec.UseVisualStyleBackColor = false;
            this.btn_rec.Click += new System.EventHandler(this.btn_rec_Click);
            // 
            // btn_ho
            // 
            this.btn_ho.BackColor = System.Drawing.Color.White;
            this.btn_ho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ho.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btn_ho.Location = new System.Drawing.Point(739, 115);
            this.btn_ho.Name = "btn_ho";
            this.btn_ho.Size = new System.Drawing.Size(26, 24);
            this.btn_ho.TabIndex = 48;
            this.btn_ho.UseVisualStyleBackColor = false;
            this.btn_ho.Click += new System.EventHandler(this.btn_ho_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(661, 119);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 15);
            this.label12.TabIndex = 49;
            this.label12.Text = "Received";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(771, 120);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 15);
            this.label13.TabIndex = 50;
            this.label13.Text = "Handed Out";
            // 
            // btn_default
            // 
            this.btn_default.BackColor = System.Drawing.Color.White;
            this.btn_default.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_default.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btn_default.Image = global::SAD_2_PTT.Properties.Resources.reload;
            this.btn_default.Location = new System.Drawing.Point(404, 114);
            this.btn_default.Name = "btn_default";
            this.btn_default.Size = new System.Drawing.Size(26, 24);
            this.btn_default.TabIndex = 51;
            this.btn_default.UseVisualStyleBackColor = false;
            this.btn_default.Click += new System.EventHandler(this.btn_default_Click);
            // 
            // device_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 506);
            this.Controls.Add(this.btn_default);
            this.Controls.Add(this.pnl_edit);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btn_ho);
            this.Controls.Add(this.btn_rec);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btn_req);
            this.Controls.Add(this.pnl_search);
            this.Controls.Add(this.bar);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.dev_editreq);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "device_view";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "device_view";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.device_view_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dev_editreq)).EndInit();
            this.pnl_edit.ResumeLayout(false);
            this.edit_info.ResumeLayout(false);
            this.edit_info.PerformLayout();
            this.edit_stat.ResumeLayout(false);
            this.edit_stat.PerformLayout();
            this.pnl_regno.ResumeLayout(false);
            this.pnl_regno.PerformLayout();
            this.pnl_name.ResumeLayout(false);
            this.pnl_name.PerformLayout();
            this.pnl_search.ResumeLayout(false);
            this.pnl_search.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel bar;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button btn_close;
        public System.Windows.Forms.DataGridView dev_editreq;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnl_edit;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel edit_info;
        private System.Windows.Forms.RichTextBox txt_desc;
        private System.Windows.Forms.ComboBox cmbox_dis;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbox_prov;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbox_dev;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker date_out;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker date_in;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker request_date;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel pnl_regno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnl_name;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer startup_opacity;
        private System.Windows.Forms.Panel pnl_search;
        private System.Windows.Forms.Button button45;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Button btn_req;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_rec;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel edit_stat;
        private System.Windows.Forms.ComboBox cmbox_stat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_ho;
        private System.Windows.Forms.Button btn_default;
    }
}