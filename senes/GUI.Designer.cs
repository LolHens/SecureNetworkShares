namespace senes
{
    partial class GUI
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.unmount = new System.Windows.Forms.Button();
            this.mount = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.unmount);
            this.panel1.Controls.Add(this.mount);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 239);
            this.panel1.TabIndex = 0;
            // 
            // unmount
            // 
            this.unmount.Location = new System.Drawing.Point(12, 120);
            this.unmount.Name = "unmount";
            this.unmount.Size = new System.Drawing.Size(242, 102);
            this.unmount.TabIndex = 1;
            this.unmount.Text = "Unmount";
            this.unmount.UseVisualStyleBackColor = true;
            this.unmount.Click += new System.EventHandler(this.unmount_Click);
            // 
            // mount
            // 
            this.mount.Location = new System.Drawing.Point(12, 12);
            this.mount.Name = "mount";
            this.mount.Size = new System.Drawing.Size(242, 102);
            this.mount.TabIndex = 0;
            this.mount.Text = "Mount";
            this.mount.UseVisualStyleBackColor = true;
            this.mount.Click += new System.EventHandler(this.mount_Click);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 239);
            this.Controls.Add(this.panel1);
            this.Name = "GUI";
            this.Text = "Secure Network Shares GUI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button mount;
        private System.Windows.Forms.Button unmount;
    }
}

