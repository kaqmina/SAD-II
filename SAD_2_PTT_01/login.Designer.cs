namespace SAD_2_PTT_01
{
    partial class login
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
            this.startup_opacity = new System.Windows.Forms.Timer(this.components);
            this.btn_exit = new System.Windows.Forms.Button();
            this.uname = new System.Windows.Forms.TextBox();
            this.pword = new System.Windows.Forms.TextBox();
            this.message = new System.Windows.Forms.Label();
            this.btn_login = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.uname_line = new System.Windows.Forms.Label();
            this.pword_line = new System.Windows.Forms.Label();
            this.pword_label = new System.Windows.Forms.Label();
            this.uname_label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.back = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // startup_opacity
            // 
            this.startup_opacity.Interval = 1;
            this.startup_opacity.Tick += new System.EventHandler(this.startup_opacity_Tick);
            // 
            // btn_exit
            // 
            this.btn_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_exit.FlatAppearance.BorderSize = 0;
            this.btn_exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.ForeColor = System.Drawing.Color.Black;
            this.btn_exit.Location = new System.Drawing.Point(52, 297);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(103, 39);
            this.btn_exit.TabIndex = 43;
            this.btn_exit.Text = "EXIT";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // uname
            // 
            this.uname.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.uname.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uname.Location = new System.Drawing.Point(53, 194);
            this.uname.MaxLength = 16;
            this.uname.Name = "uname";
            this.uname.Size = new System.Drawing.Size(183, 16);
            this.uname.TabIndex = 41;
            this.uname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.uname.TextChanged += new System.EventHandler(this.uname_TextChanged);
            // 
            // pword
            // 
            this.pword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pword.Location = new System.Drawing.Point(52, 254);
            this.pword.MaxLength = 16;
            this.pword.Name = "pword";
            this.pword.PasswordChar = '●';
            this.pword.Size = new System.Drawing.Size(183, 16);
            this.pword.TabIndex = 42;
            this.pword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pword.TextChanged += new System.EventHandler(this.pword_TextChanged);
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.BackColor = System.Drawing.Color.Transparent;
            this.message.ForeColor = System.Drawing.Color.Tomato;
            this.message.Location = new System.Drawing.Point(50, 154);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(161, 13);
            this.message.TabIndex = 40;
            this.message.Text = "Incorrect username or password.";
            this.message.Visible = false;
            // 
            // btn_login
            // 
            this.btn_login.Enabled = false;
            this.btn_login.FlatAppearance.BorderSize = 0;
            this.btn_login.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btn_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_login.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_login.ForeColor = System.Drawing.Color.Black;
            this.btn_login.Location = new System.Drawing.Point(158, 297);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(103, 39);
            this.btn_login.TabIndex = 39;
            this.btn_login.Text = "LOGIN";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(243, 195);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 20);
            this.label9.TabIndex = 35;
            this.label9.Text = "  ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(242, 253);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 20);
            this.label10.TabIndex = 36;
            this.label10.Text = "  ";
            // 
            // uname_line
            // 
            this.uname_line.AutoSize = true;
            this.uname_line.BackColor = System.Drawing.Color.Transparent;
            this.uname_line.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uname_line.ForeColor = System.Drawing.Color.Black;
            this.uname_line.Location = new System.Drawing.Point(50, 205);
            this.uname_line.Name = "uname_line";
            this.uname_line.Size = new System.Drawing.Size(212, 15);
            this.uname_line.TabIndex = 38;
            this.uname_line.Text = "_________________________________________";
            // 
            // pword_line
            // 
            this.pword_line.AutoSize = true;
            this.pword_line.BackColor = System.Drawing.Color.Transparent;
            this.pword_line.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pword_line.ForeColor = System.Drawing.Color.Black;
            this.pword_line.Location = new System.Drawing.Point(49, 264);
            this.pword_line.Name = "pword_line";
            this.pword_line.Size = new System.Drawing.Size(212, 15);
            this.pword_line.TabIndex = 37;
            this.pword_line.Text = "_________________________________________";
            // 
            // pword_label
            // 
            this.pword_label.AutoSize = true;
            this.pword_label.BackColor = System.Drawing.Color.Transparent;
            this.pword_label.ForeColor = System.Drawing.Color.Black;
            this.pword_label.Location = new System.Drawing.Point(49, 237);
            this.pword_label.Name = "pword_label";
            this.pword_label.Size = new System.Drawing.Size(70, 13);
            this.pword_label.TabIndex = 34;
            this.pword_label.Text = "PASSWORD";
            // 
            // uname_label
            // 
            this.uname_label.AutoSize = true;
            this.uname_label.BackColor = System.Drawing.Color.Transparent;
            this.uname_label.ForeColor = System.Drawing.Color.Black;
            this.uname_label.Location = new System.Drawing.Point(50, 178);
            this.uname_label.Name = "uname_label";
            this.uname_label.Size = new System.Drawing.Size(68, 13);
            this.uname_label.TabIndex = 33;
            this.uname_label.Text = "USERNAME";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(45)))), ((int)(((byte)(56)))));
            this.label4.Location = new System.Drawing.Point(41, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(213, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "We make things better, easier, and happier.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(45)))), ((int)(((byte)(56)))));
            this.label1.Location = new System.Drawing.Point(47, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 40);
            this.label1.TabIndex = 30;
            this.label1.Text = "PDAO Software";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(45)))), ((int)(((byte)(56)))));
            this.label6.Location = new System.Drawing.Point(40, 416);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 26);
            this.label6.TabIndex = 32;
            this.label6.Text = "© 2017 Team Ababangay\r\nAll rights reserved.";
            // 
            // back
            // 
            this.back.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.back.Dock = System.Windows.Forms.DockStyle.Fill;
            this.back.Location = new System.Drawing.Point(0, 0);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(312, 475);
            this.back.TabIndex = 44;
            // 
            // login
            // 
            this.AcceptButton = this.btn_login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CancelButton = this.btn_exit;
            this.ClientSize = new System.Drawing.Size(312, 475);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.uname);
            this.Controls.Add(this.pword);
            this.Controls.Add(this.message);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.uname_line);
            this.Controls.Add(this.pword_line);
            this.Controls.Add(this.pword_label);
            this.Controls.Add(this.uname_label);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.back);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "login";
            this.Load += new System.EventHandler(this.login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer startup_opacity;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.TextBox uname;
        private System.Windows.Forms.TextBox pword;
        private System.Windows.Forms.Label message;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label uname_line;
        private System.Windows.Forms.Label pword_line;
        private System.Windows.Forms.Label pword_label;
        private System.Windows.Forms.Label uname_label;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel back;
    }
}