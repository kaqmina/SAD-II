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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnl_edit.SuspendLayout();
            this.edit_info.SuspendLayout();
            this.edit_stat.SuspendLayout();
            this.pnl_regno.SuspendLayout();
            this.pnl_name.SuspendLayout();
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(45)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(22, 117);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(821, 365);
            this.dataGridView1.TabIndex = 17;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Window;
            this.button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(144, 322);
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
            this.pnl_edit.Location = new System.Drawing.Point(22, 117);
            this.pnl_edit.Name = "pnl_edit";
            this.pnl_edit.Size = new System.Drawing.Size(821, 365);
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
            this.edit_info.Size = new System.Drawing.Size(502, 365);
            this.edit_info.TabIndex = 72;
            // 
            // txt_desc
            // 
            this.txt_desc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_desc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_desc.Location = new System.Drawing.Point(164, 165);
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
            this.cmbox_dis.Location = new System.Drawing.Point(164, 19);
            this.cmbox_dis.Name = "cmbox_dis";
            this.cmbox_dis.Size = new System.Drawing.Size(188, 25);
            this.cmbox_dis.TabIndex = 71;
            this.cmbox_dis.SelectedIndexChanged += new System.EventHandler(this.cmbox_dis_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(33, 22);
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
            this.cmbox_prov.Location = new System.Drawing.Point(164, 89);
            this.cmbox_prov.Name = "cmbox_prov";
            this.cmbox_prov.Size = new System.Drawing.Size(188, 23);
            this.cmbox_prov.TabIndex = 69;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(33, 124);
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
            this.cmbox_dev.Location = new System.Drawing.Point(164, 56);
            this.cmbox_dev.Name = "cmbox_dev";
            this.cmbox_dev.Size = new System.Drawing.Size(188, 23);
            this.cmbox_dev.TabIndex = 68;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(33, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 15);
            this.label4.TabIndex = 59;
            this.label4.Text = "Device  Provider :";
            // 
            // date_out
            // 
            this.date_out.CustomFormat = "";
            this.date_out.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_out.Location = new System.Drawing.Point(164, 274);
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
            this.button2.Location = new System.Drawing.Point(265, 322);
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
            this.label2.Location = new System.Drawing.Point(33, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 15);
            this.label2.TabIndex = 58;
            this.label2.Text = "Device Requested :";
            // 
            // date_in
            // 
            this.date_in.CustomFormat = "";
            this.date_in.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_in.Location = new System.Drawing.Point(164, 242);
            this.date_in.Name = "date_in";
            this.date_in.Size = new System.Drawing.Size(188, 23);
            this.date_in.TabIndex = 66;
            this.date_in.Value = new System.DateTime(2017, 7, 11, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 165);
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
            this.request_date.Location = new System.Drawing.Point(164, 124);
            this.request_date.Name = "request_date";
            this.request_date.Size = new System.Drawing.Size(188, 23);
            this.request_date.TabIndex = 65;
            this.request_date.Value = new System.DateTime(2017, 7, 9, 0, 0, 0, 0);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(36, 280);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 15);
            this.label9.TabIndex = 62;
            this.label9.Text = "Date OUT :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(36, 243);
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
            this.edit_stat.Location = new System.Drawing.Point(0, 313);
            this.edit_stat.Name = "edit_stat";
            this.edit_stat.Size = new System.Drawing.Size(300, 52);
            this.edit_stat.TabIndex = 1;
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
            this.pnl_name.Size = new System.Drawing.Size(300, 223);
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
            // device_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 506);
            this.Controls.Add(this.pnl_edit);
            this.Controls.Add(this.bar);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "device_view";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "device_view";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.device_view_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnl_edit.ResumeLayout(false);
            this.edit_info.ResumeLayout(false);
            this.edit_info.PerformLayout();
            this.edit_stat.ResumeLayout(false);
            this.edit_stat.PerformLayout();
            this.pnl_regno.ResumeLayout(false);
            this.pnl_regno.PerformLayout();
            this.pnl_name.ResumeLayout(false);
            this.pnl_name.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel bar;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.DataGridView dataGridView1;
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
        private System.Windows.Forms.Panel edit_stat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnl_regno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnl_name;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer startup_opacity;
        private System.Windows.Forms.ComboBox cmbox_stat;
    }
}