namespace SAD_2_PTT_01
{
    partial class shadow
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
            this.exit_opacity = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
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
            // shadow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1137, 639);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "shadow";
            this.Opacity = 0.5D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "shadow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.shadow_FormClosing);
            this.Load += new System.EventHandler(this.shadow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer startup_opacity;
        private System.Windows.Forms.Timer exit_opacity;
    }
}