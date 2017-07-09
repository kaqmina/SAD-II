namespace SAD_2_PTT
{
    partial class device_request
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
            this.bar = new System.Windows.Forms.Panel();
            this.btn_close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txt_desc = new System.Windows.Forms.RichTextBox();
            this.request_date = new System.Windows.Forms.DateTimePicker();
            this.date_in = new System.Windows.Forms.DateTimePicker();
            this.date_out = new System.Windows.Forms.DateTimePicker();
            this.cmbox_dev = new System.Windows.Forms.ComboBox();
            this.cmbox_prov = new System.Windows.Forms.ComboBox();
            this.cmbox_dis = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // bar
            // 
            this.bar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.bar.Location = new System.Drawing.Point(0, 48);
            this.bar.Name = "bar";
            this.bar.Size = new System.Drawing.Size(587, 33);
            this.bar.TabIndex = 0;
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Image = global::SAD_2_PTT.Properties.Resources.close;
            this.btn_close.Location = new System.Drawing.Point(525, -1);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(60, 49);
            this.btn_close.TabIndex = 1;
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "REQUEST DEVICE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Device Requested :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "REG NO :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Device  Provider :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Requested Date :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(21, 92);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(329, 45);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.cmbox_dis);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.cmbox_prov);
            this.panel2.Controls.Add(this.cmbox_dev);
            this.panel2.Controls.Add(this.date_out);
            this.panel2.Controls.Add(this.date_in);
            this.panel2.Controls.Add(this.request_date);
            this.panel2.Controls.Add(this.txt_desc);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(21, 156);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(545, 309);
            this.panel2.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(45)))));
            this.panel3.Controls.Add(this.comboBox1);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(367, 92);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(199, 45);
            this.panel3.TabIndex = 9;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBox1.Items.AddRange(new object[] {
            "Requested",
            "Received",
            "Handed Out"});
            this.comboBox1.Location = new System.Drawing.Point(76, 11);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(111, 23);
            this.comboBox1.TabIndex = 39;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Window;
            this.label6.Location = new System.Drawing.Point(9, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 20);
            this.label6.TabIndex = 38;
            this.label6.Text = "STATUS :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(80, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "111111111";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(21, 161);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "Request Description :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(20, 277);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "Date OUT :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(20, 238);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 15);
            this.label10.TabIndex = 9;
            this.label10.Text = "Date IN :";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Window;
            this.button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(203, 471);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Window;
            this.button2.FlatAppearance.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(307, 471);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // txt_desc
            // 
            this.txt_desc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_desc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_desc.Location = new System.Drawing.Point(152, 161);
            this.txt_desc.Name = "txt_desc";
            this.txt_desc.Size = new System.Drawing.Size(353, 62);
            this.txt_desc.TabIndex = 17;
            this.txt_desc.Text = "";
            // 
            // request_date
            // 
            this.request_date.CalendarTrailingForeColor = System.Drawing.SystemColors.Window;
            this.request_date.CustomFormat = "mm/d/y";
            this.request_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.request_date.Location = new System.Drawing.Point(152, 127);
            this.request_date.Name = "request_date";
            this.request_date.Size = new System.Drawing.Size(200, 22);
            this.request_date.TabIndex = 18;
            this.request_date.Value = new System.DateTime(2017, 7, 9, 0, 0, 0, 0);
            // 
            // date_in
            // 
            this.date_in.CustomFormat = "";
            this.date_in.Location = new System.Drawing.Point(152, 238);
            this.date_in.Name = "date_in";
            this.date_in.Size = new System.Drawing.Size(200, 22);
            this.date_in.TabIndex = 19;
            // 
            // date_out
            // 
            this.date_out.CustomFormat = "";
            this.date_out.Location = new System.Drawing.Point(152, 270);
            this.date_out.Name = "date_out";
            this.date_out.Size = new System.Drawing.Size(200, 22);
            this.date_out.TabIndex = 20;
            // 
            // cmbox_dev
            // 
            this.cmbox_dev.BackColor = System.Drawing.SystemColors.Window;
            this.cmbox_dev.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbox_dev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbox_dev.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbox_dev.FormattingEnabled = true;
            this.cmbox_dev.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbox_dev.Location = new System.Drawing.Point(152, 59);
            this.cmbox_dev.Name = "cmbox_dev";
            this.cmbox_dev.Size = new System.Drawing.Size(200, 23);
            this.cmbox_dev.TabIndex = 40;
            // 
            // cmbox_prov
            // 
            this.cmbox_prov.BackColor = System.Drawing.SystemColors.Window;
            this.cmbox_prov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbox_prov.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbox_prov.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbox_prov.FormattingEnabled = true;
            this.cmbox_prov.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbox_prov.Location = new System.Drawing.Point(152, 92);
            this.cmbox_prov.Name = "cmbox_prov";
            this.cmbox_prov.Size = new System.Drawing.Size(200, 23);
            this.cmbox_prov.TabIndex = 41;
            // 
            // cmbox_dis
            // 
            this.cmbox_dis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbox_dis.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbox_dis.FormattingEnabled = true;
            this.cmbox_dis.Location = new System.Drawing.Point(144, 22);
            this.cmbox_dis.Name = "cmbox_dis";
            this.cmbox_dis.Size = new System.Drawing.Size(208, 25);
            this.cmbox_dis.TabIndex = 43;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(21, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 17);
            this.label11.TabIndex = 42;
            this.label11.Text = "Disability :";
            // 
            // device_request
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(587, 506);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.bar);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "device_request";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "device_request";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.device_request_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel bar;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cmbox_prov;
        private System.Windows.Forms.ComboBox cmbox_dev;
        private System.Windows.Forms.DateTimePicker date_out;
        private System.Windows.Forms.DateTimePicker date_in;
        private System.Windows.Forms.DateTimePicker request_date;
        private System.Windows.Forms.RichTextBox txt_desc;
        private System.Windows.Forms.ComboBox cmbox_dis;
        private System.Windows.Forms.Label label11;
    }
}