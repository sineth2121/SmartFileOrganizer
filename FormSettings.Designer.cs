namespace SmartFileOrganizer
{
    partial class FormSettings
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelBanner = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.lblDestLabel = new System.Windows.Forms.Label();
            this.txtDestinationPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panelBanner.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBanner
            // 
            this.panelBanner.BackColor = System.Drawing.Color.LightCyan;
            this.panelBanner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBanner.Controls.Add(this.lblTitle);
            this.panelBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBanner.Location = new System.Drawing.Point(0, 0);
            this.panelBanner.Name = "panelBanner";
            this.panelBanner.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.panelBanner.Size = new System.Drawing.Size(960, 52);
            this.panelBanner.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(934, 34);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "⚙️ Application Settings";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.panelContent.Controls.Add(this.btnSave);
            this.panelContent.Controls.Add(this.btnBrowse);
            this.panelContent.Controls.Add(this.txtDestinationPath);
            this.panelContent.Controls.Add(this.lblDestLabel);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 52);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(30, 30, 30, 30);
            this.panelContent.Size = new System.Drawing.Size(960, 530);
            this.panelContent.TabIndex = 1;
            // 
            // lblDestLabel
            // 
            this.lblDestLabel.AutoSize = true;
            this.lblDestLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDestLabel.Location = new System.Drawing.Point(33, 33);
            this.lblDestLabel.Name = "lblDestLabel";
            this.lblDestLabel.Size = new System.Drawing.Size(199, 23);
            this.lblDestLabel.TabIndex = 0;
            this.lblDestLabel.Text = "Base Destination Folder:";
            // 
            // txtDestinationPath
            // 
            this.txtDestinationPath.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDestinationPath.Location = new System.Drawing.Point(37, 64);
            this.txtDestinationPath.Name = "txtDestinationPath";
            this.txtDestinationPath.ReadOnly = false;
            this.txtDestinationPath.Size = new System.Drawing.Size(700, 30);
            this.txtDestinationPath.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBrowse.Location = new System.Drawing.Point(752, 62);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(100, 35);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(37, 112);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(960, 582);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelBanner);
            this.Name = "FormSettings";
            this.Text = "Settings";
            this.panelBanner.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelBanner;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label lblDestLabel;
        private System.Windows.Forms.TextBox txtDestinationPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnSave;
    }
}
