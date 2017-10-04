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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_close = new System.Windows.Forms.Button();
            this.header_text = new System.Windows.Forms.Button();
            this.btn_mode_status = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_projects_refresh = new System.Windows.Forms.Button();
            this.projects_grid_persons_involved = new System.Windows.Forms.DataGridView();
            this.startup_opacity = new System.Windows.Forms.Timer(this.components);
            this.exit_opacity = new System.Windows.Forms.Timer(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_toggle = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projects_grid_persons_involved)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.panel1.Controls.Add(this.btn_toggle);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.btn_projects_refresh);
            this.panel1.Controls.Add(this.projects_grid_persons_involved);
            this.panel1.Location = new System.Drawing.Point(3, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(674, 364);
            this.panel1.TabIndex = 128;
            // 
            // btn_projects_refresh
            // 
            this.btn_projects_refresh.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_projects_refresh.BackgroundImage = global::SAD_2_PTT_01.Properties.Resources.reload;
            this.btn_projects_refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_projects_refresh.FlatAppearance.BorderSize = 0;
            this.btn_projects_refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_projects_refresh.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_projects_refresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(45)))), ((int)(((byte)(56)))));
            this.btn_projects_refresh.Location = new System.Drawing.Point(304, 3);
            this.btn_projects_refresh.Name = "btn_projects_refresh";
            this.btn_projects_refresh.Size = new System.Drawing.Size(22, 25);
            this.btn_projects_refresh.TabIndex = 147;
            this.btn_projects_refresh.UseVisualStyleBackColor = false;
            // 
            // projects_grid_persons_involved
            // 
            this.projects_grid_persons_involved.AllowUserToAddRows = false;
            this.projects_grid_persons_involved.AllowUserToDeleteRows = false;
            this.projects_grid_persons_involved.AllowUserToResizeColumns = false;
            this.projects_grid_persons_involved.AllowUserToResizeRows = false;
            this.projects_grid_persons_involved.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.projects_grid_persons_involved.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.projects_grid_persons_involved.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.projects_grid_persons_involved.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.projects_grid_persons_involved.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.projects_grid_persons_involved.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.projects_grid_persons_involved.Location = new System.Drawing.Point(9, 30);
            this.projects_grid_persons_involved.MultiSelect = false;
            this.projects_grid_persons_involved.Name = "projects_grid_persons_involved";
            this.projects_grid_persons_involved.ReadOnly = true;
            this.projects_grid_persons_involved.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projects_grid_persons_involved.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.projects_grid_persons_involved.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.projects_grid_persons_involved.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.projects_grid_persons_involved.Size = new System.Drawing.Size(320, 302);
            this.projects_grid_persons_involved.TabIndex = 146;
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.Location = new System.Drawing.Point(335, 30);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(330, 302);
            this.dataGridView1.TabIndex = 148;
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
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.BackgroundImage = global::SAD_2_PTT_01.Properties.Resources.reload;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(45)))), ((int)(((byte)(56)))));
            this.button1.Location = new System.Drawing.Point(643, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(22, 25);
            this.button1.TabIndex = 151;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btn_toggle
            // 
            this.btn_toggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_toggle.BackColor = System.Drawing.Color.White;
            this.btn_toggle.FlatAppearance.BorderSize = 0;
            this.btn_toggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_toggle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_toggle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(45)))), ((int)(((byte)(56)))));
            this.btn_toggle.Location = new System.Drawing.Point(271, 172);
            this.btn_toggle.Name = "btn_toggle";
            this.btn_toggle.Size = new System.Drawing.Size(132, 20);
            this.btn_toggle.TabIndex = 152;
            this.btn_toggle.Text = "MARK AS PRESENT";
            this.btn_toggle.UseVisualStyleBackColor = false;
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
            ((System.ComponentModel.ISupportInitialize)(this.projects_grid_persons_involved)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_close;
        public System.Windows.Forms.Button header_text;
        private System.Windows.Forms.Button btn_mode_status;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer startup_opacity;
        private System.Windows.Forms.Timer exit_opacity;
        public System.Windows.Forms.DataGridView projects_grid_persons_involved;
        private System.Windows.Forms.Button btn_projects_refresh;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btn_toggle;
    }
}