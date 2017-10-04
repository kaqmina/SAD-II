namespace SAD_2_PTT_01
{
    partial class notifications_form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_close = new System.Windows.Forms.Button();
            this.header_text = new System.Windows.Forms.Button();
            this.btn_mode_status = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_resolve = new System.Windows.Forms.Button();
            this.btn_project_refresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.project_grid = new System.Windows.Forms.DataGridView();
            this.btn_pwd_refresh = new System.Windows.Forms.Button();
            this.pwd_grid = new System.Windows.Forms.DataGridView();
            this.startup_opacity = new System.Windows.Forms.Timer(this.components);
            this.exit_opacity = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.project_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pwd_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.btn_close.BackgroundImage = global::SAD_2_PTT_01.Properties.Resources.control_close;
            this.btn_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(74)))), ((int)(((byte)(85)))));
            this.btn_close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(45)))), ((int)(((byte)(56)))));
            this.btn_close.Location = new System.Drawing.Point(656, 0);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(24, 24);
            this.btn_close.TabIndex = 127;
            this.btn_close.UseVisualStyleBackColor = false;
            // 
            // header_text
            // 
            this.header_text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.header_text.Dock = System.Windows.Forms.DockStyle.Top;
            this.header_text.FlatAppearance.BorderSize = 0;
            this.header_text.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.header_text.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.header_text.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.header_text.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header_text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.header_text.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.header_text.Location = new System.Drawing.Point(0, 28);
            this.header_text.Name = "header_text";
            this.header_text.Size = new System.Drawing.Size(680, 23);
            this.header_text.TabIndex = 126;
            this.header_text.UseVisualStyleBackColor = false;
            // 
            // btn_mode_status
            // 
            this.btn_mode_status.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(45)))), ((int)(((byte)(56)))));
            this.btn_mode_status.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_mode_status.FlatAppearance.BorderSize = 0;
            this.btn_mode_status.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.btn_mode_status.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.btn_mode_status.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_mode_status.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_mode_status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btn_mode_status.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_mode_status.Location = new System.Drawing.Point(0, 0);
            this.btn_mode_status.Name = "btn_mode_status";
            this.btn_mode_status.Size = new System.Drawing.Size(680, 28);
            this.btn_mode_status.TabIndex = 125;
            this.btn_mode_status.Text = "NOTIFICATIONS";
            this.btn_mode_status.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.btn_resolve);
            this.panel1.Controls.Add(this.btn_project_refresh);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.project_grid);
            this.panel1.Controls.Add(this.btn_pwd_refresh);
            this.panel1.Controls.Add(this.pwd_grid);
            this.panel1.Location = new System.Drawing.Point(3, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(674, 364);
            this.panel1.TabIndex = 128;
            // 
            // btn_resolve
            // 
            this.btn_resolve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_resolve.BackColor = System.Drawing.Color.White;
            this.btn_resolve.FlatAppearance.BorderSize = 0;
            this.btn_resolve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_resolve.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_resolve.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(45)))), ((int)(((byte)(56)))));
            this.btn_resolve.Location = new System.Drawing.Point(196, 338);
            this.btn_resolve.Name = "btn_resolve";
            this.btn_resolve.Size = new System.Drawing.Size(132, 20);
            this.btn_resolve.TabIndex = 152;
            this.btn_resolve.Text = "RESOLVE";
            this.btn_resolve.UseVisualStyleBackColor = false;
            this.btn_resolve.Click += new System.EventHandler(this.btn_resolve_Click);
            // 
            // btn_project_refresh
            // 
            this.btn_project_refresh.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_project_refresh.BackgroundImage = global::SAD_2_PTT_01.Properties.Resources.reload;
            this.btn_project_refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_project_refresh.FlatAppearance.BorderSize = 0;
            this.btn_project_refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_project_refresh.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_project_refresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(45)))), ((int)(((byte)(56)))));
            this.btn_project_refresh.Location = new System.Drawing.Point(643, 3);
            this.btn_project_refresh.Name = "btn_project_refresh";
            this.btn_project_refresh.Size = new System.Drawing.Size(22, 25);
            this.btn_project_refresh.TabIndex = 151;
            this.btn_project_refresh.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(45)))), ((int)(((byte)(56)))));
            this.label1.Location = new System.Drawing.Point(335, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 150;
            this.label1.Text = "PROJECTS";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(45)))), ((int)(((byte)(56)))));
            this.label12.Location = new System.Drawing.Point(9, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 17);
            this.label12.TabIndex = 149;
            this.label12.Text = "PWD";
            // 
            // project_grid
            // 
            this.project_grid.AllowUserToAddRows = false;
            this.project_grid.AllowUserToDeleteRows = false;
            this.project_grid.AllowUserToResizeColumns = false;
            this.project_grid.AllowUserToResizeRows = false;
            this.project_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.project_grid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.project_grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.project_grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.project_grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.project_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.project_grid.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.project_grid.Location = new System.Drawing.Point(335, 30);
            this.project_grid.MultiSelect = false;
            this.project_grid.Name = "project_grid";
            this.project_grid.ReadOnly = true;
            this.project_grid.RowHeadersVisible = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.project_grid.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.project_grid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.project_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.project_grid.Size = new System.Drawing.Size(330, 302);
            this.project_grid.TabIndex = 148;
            // 
            // btn_pwd_refresh
            // 
            this.btn_pwd_refresh.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_pwd_refresh.BackgroundImage = global::SAD_2_PTT_01.Properties.Resources.reload;
            this.btn_pwd_refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_pwd_refresh.FlatAppearance.BorderSize = 0;
            this.btn_pwd_refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pwd_refresh.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pwd_refresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(45)))), ((int)(((byte)(56)))));
            this.btn_pwd_refresh.Location = new System.Drawing.Point(304, 3);
            this.btn_pwd_refresh.Name = "btn_pwd_refresh";
            this.btn_pwd_refresh.Size = new System.Drawing.Size(22, 25);
            this.btn_pwd_refresh.TabIndex = 147;
            this.btn_pwd_refresh.UseVisualStyleBackColor = false;
            // 
            // pwd_grid
            // 
            this.pwd_grid.AllowUserToAddRows = false;
            this.pwd_grid.AllowUserToDeleteRows = false;
            this.pwd_grid.AllowUserToResizeColumns = false;
            this.pwd_grid.AllowUserToResizeRows = false;
            this.pwd_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.pwd_grid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pwd_grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pwd_grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.pwd_grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.pwd_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.pwd_grid.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pwd_grid.Location = new System.Drawing.Point(9, 30);
            this.pwd_grid.MultiSelect = false;
            this.pwd_grid.Name = "pwd_grid";
            this.pwd_grid.ReadOnly = true;
            this.pwd_grid.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwd_grid.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.pwd_grid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.pwd_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.pwd_grid.Size = new System.Drawing.Size(320, 302);
            this.pwd_grid.TabIndex = 146;
            this.pwd_grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.pwd_grid_CellClick);
            this.pwd_grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.pwd_grid_CellDoubleClick);
            // 
            // startup_opacity
            // 
            this.startup_opacity.Interval = 1;
            this.startup_opacity.Tick += new System.EventHandler(this.startup_opacity_Tick);
            // 
            // exit_opacity
            // 
            this.exit_opacity.Interval = 1;
            this.exit_opacity.Tick += new System.EventHandler(this.exit_opacity_Tick);
            // 
            // notifications_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 421);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.header_text);
            this.Controls.Add(this.btn_mode_status);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(45)))), ((int)(((byte)(56)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "notifications_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Notification";
            this.Load += new System.EventHandler(this.notifications_form_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.project_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pwd_grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_close;
        public System.Windows.Forms.Button header_text;
        private System.Windows.Forms.Button btn_mode_status;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer startup_opacity;
        private System.Windows.Forms.Timer exit_opacity;
        public System.Windows.Forms.DataGridView pwd_grid;
        private System.Windows.Forms.Button btn_pwd_refresh;
        public System.Windows.Forms.DataGridView project_grid;
        private System.Windows.Forms.Button btn_project_refresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btn_resolve;
    }
}