﻿namespace SAD_2_PTT_01
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
            this.btn_close = new System.Windows.Forms.Button();
            this.header_text = new System.Windows.Forms.Button();
            this.btn_mode_status = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.panel1.Location = new System.Drawing.Point(215, 238);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 128;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_close;
        public System.Windows.Forms.Button header_text;
        private System.Windows.Forms.Button btn_mode_status;
        private System.Windows.Forms.Panel panel1;
    }
}