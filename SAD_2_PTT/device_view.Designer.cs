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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_close = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.pnl_edit = new System.Windows.Forms.Panel();
            this.lbl_reqdate = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_reg = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_status = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_desc = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_type = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnl_edit.SuspendLayout();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 30);
            this.label1.TabIndex = 15;
            this.label1.Text = "VIEW REQUESTS";
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(45)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Location = new System.Drawing.Point(19, 117);
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
            this.button1.Location = new System.Drawing.Point(285, 316);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 27);
            this.button1.TabIndex = 18;
            this.button1.Text = "Edit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnl_edit
            // 
            this.pnl_edit.BackColor = System.Drawing.SystemColors.Window;
            this.pnl_edit.Controls.Add(this.button2);
            this.pnl_edit.Controls.Add(this.txt_type);
            this.pnl_edit.Controls.Add(this.label16);
            this.pnl_edit.Controls.Add(this.lbl_reqdate);
            this.pnl_edit.Controls.Add(this.label10);
            this.pnl_edit.Controls.Add(this.lbl_reg);
            this.pnl_edit.Controls.Add(this.label8);
            this.pnl_edit.Controls.Add(this.lbl_status);
            this.pnl_edit.Controls.Add(this.button1);
            this.pnl_edit.Controls.Add(this.label6);
            this.pnl_edit.Controls.Add(this.lbl_desc);
            this.pnl_edit.Controls.Add(this.label4);
            this.pnl_edit.Controls.Add(this.lbl_name);
            this.pnl_edit.Controls.Add(this.label2);
            this.pnl_edit.Location = new System.Drawing.Point(19, 117);
            this.pnl_edit.Name = "pnl_edit";
            this.pnl_edit.Size = new System.Drawing.Size(824, 365);
            this.pnl_edit.TabIndex = 19;
            // 
            // lbl_reqdate
            // 
            this.lbl_reqdate.AutoSize = true;
            this.lbl_reqdate.Location = new System.Drawing.Point(139, 83);
            this.lbl_reqdate.Name = "lbl_reqdate";
            this.lbl_reqdate.Size = new System.Drawing.Size(38, 15);
            this.lbl_reqdate.TabIndex = 22;
            this.lbl_reqdate.Text = "label3";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 15);
            this.label10.TabIndex = 21;
            this.label10.Text = "Requested Date :";
            // 
            // lbl_reg
            // 
            this.lbl_reg.AutoSize = true;
            this.lbl_reg.Location = new System.Drawing.Point(91, 20);
            this.lbl_reg.Name = "lbl_reg";
            this.lbl_reg.Size = new System.Drawing.Size(38, 15);
            this.lbl_reg.TabIndex = 20;
            this.lbl_reg.Text = "label3";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(219, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 15);
            this.label8.TabIndex = 19;
            this.label8.Text = "Reg. No :";
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Location = new System.Drawing.Point(81, 296);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(38, 15);
            this.lbl_status.TabIndex = 5;
            this.lbl_status.Text = "label3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 296);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "Status :";
            // 
            // lbl_desc
            // 
            this.lbl_desc.AutoSize = true;
            this.lbl_desc.Location = new System.Drawing.Point(21, 225);
            this.lbl_desc.Name = "lbl_desc";
            this.lbl_desc.Size = new System.Drawing.Size(38, 15);
            this.lbl_desc.TabIndex = 3;
            this.lbl_desc.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Request Description :";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(91, 49);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(38, 15);
            this.lbl_name.TabIndex = 1;
            this.lbl_name.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name :";
            // 
            // txt_type
            // 
            this.txt_type.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_type.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_type.Location = new System.Drawing.Point(325, 29);
            this.txt_type.Multiline = true;
            this.txt_type.Name = "txt_type";
            this.txt_type.Size = new System.Drawing.Size(240, 21);
            this.txt_type.TabIndex = 29;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(323, 39);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(242, 15);
            this.label16.TabIndex = 30;
            this.label16.Text = "_______________________________________________";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Window;
            this.button2.FlatAppearance.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(406, 316);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 27);
            this.button2.TabIndex = 31;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // device_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 517);
            this.Controls.Add(this.bar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.pnl_edit);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "device_view";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "device_view";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.device_view_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnl_edit.ResumeLayout(false);
            this.pnl_edit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel bar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnl_edit;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_reqdate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_desc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_reg;
        private System.Windows.Forms.TextBox txt_type;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button2;
    }
}