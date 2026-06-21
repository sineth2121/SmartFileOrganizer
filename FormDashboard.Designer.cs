namespace SmartFileOrganizer
{
    partial class FormDashboard
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
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnDuplicateCleaner = new System.Windows.Forms.Button();
            this.btnConfigureRules = new System.Windows.Forms.Button();
            this.btnOperationHistory = new System.Windows.Forms.Button();
            this.btnScanPreview = new System.Windows.Forms.Button();
            this.btnFolderSelection = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelSidebar.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panelSidebar.Controls.Add(this.btnSettings);
            this.panelSidebar.Controls.Add(this.btnDuplicateCleaner);
            this.panelSidebar.Controls.Add(this.btnConfigureRules);
            this.panelSidebar.Controls.Add(this.btnOperationHistory);
            this.panelSidebar.Controls.Add(this.btnScanPreview);
            this.panelSidebar.Controls.Add(this.btnFolderSelection);
            this.panelSidebar.Controls.Add(this.btnDashboard);
            this.panelSidebar.Controls.Add(this.panelLogo);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(220, 709);
            this.panelSidebar.TabIndex = 0;
            this.panelSidebar.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSidebar_Paint);
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Malgun Gothic", 10F);
            this.btnSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnSettings.Location = new System.Drawing.Point(18, 657);
            this.btnSettings.MaximumSize = new System.Drawing.Size(180, 40);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(180, 40);
            this.btnSettings.TabIndex = 6;
            this.btnSettings.Text = "⚙️ App Settings";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnDuplicateCleaner
            // 
            this.btnDuplicateCleaner.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDuplicateCleaner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.btnDuplicateCleaner.FlatAppearance.BorderSize = 0;
            this.btnDuplicateCleaner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDuplicateCleaner.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.btnDuplicateCleaner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnDuplicateCleaner.Location = new System.Drawing.Point(18, 340);
            this.btnDuplicateCleaner.MaximumSize = new System.Drawing.Size(180, 40);
            this.btnDuplicateCleaner.Name = "btnDuplicateCleaner";
            this.btnDuplicateCleaner.Size = new System.Drawing.Size(180, 40);
            this.btnDuplicateCleaner.TabIndex = 5;
            this.btnDuplicateCleaner.Text = "🗑️ Duplicate Cleaner";
            this.btnDuplicateCleaner.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDuplicateCleaner.UseVisualStyleBackColor = false;
            this.btnDuplicateCleaner.Click += new System.EventHandler(this.btnDuplicateCleaner_Click);
            // 
            // btnConfigureRules
            // 
            this.btnConfigureRules.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnConfigureRules.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.btnConfigureRules.FlatAppearance.BorderSize = 0;
            this.btnConfigureRules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfigureRules.Font = new System.Drawing.Font("Malgun Gothic", 10F);
            this.btnConfigureRules.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnConfigureRules.Location = new System.Drawing.Point(18, 210);
            this.btnConfigureRules.MaximumSize = new System.Drawing.Size(180, 40);
            this.btnConfigureRules.Name = "btnConfigureRules";
            this.btnConfigureRules.Size = new System.Drawing.Size(180, 40);
            this.btnConfigureRules.TabIndex = 4;
            this.btnConfigureRules.Text = "⚙️ Configure Rules";
            this.btnConfigureRules.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfigureRules.UseVisualStyleBackColor = false;
            this.btnConfigureRules.Click += new System.EventHandler(this.btnConfigureRules_Click);
            // 
            // btnOperationHistory
            // 
            this.btnOperationHistory.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOperationHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.btnOperationHistory.FlatAppearance.BorderSize = 0;
            this.btnOperationHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOperationHistory.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.btnOperationHistory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnOperationHistory.Location = new System.Drawing.Point(18, 405);
            this.btnOperationHistory.MaximumSize = new System.Drawing.Size(180, 40);
            this.btnOperationHistory.Name = "btnOperationHistory";
            this.btnOperationHistory.Size = new System.Drawing.Size(180, 40);
            this.btnOperationHistory.TabIndex = 3;
            this.btnOperationHistory.Text = "🕒 Operation History";
            this.btnOperationHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOperationHistory.UseVisualStyleBackColor = false;
            this.btnOperationHistory.Click += new System.EventHandler(this.btnOperationHistory_Click);
            // 
            // btnScanPreview
            // 
            this.btnScanPreview.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnScanPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.btnScanPreview.FlatAppearance.BorderSize = 0;
            this.btnScanPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScanPreview.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.btnScanPreview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnScanPreview.Location = new System.Drawing.Point(18, 275);
            this.btnScanPreview.MaximumSize = new System.Drawing.Size(180, 40);
            this.btnScanPreview.Name = "btnScanPreview";
            this.btnScanPreview.Size = new System.Drawing.Size(180, 40);
            this.btnScanPreview.TabIndex = 2;
            this.btnScanPreview.Text = "🔍 Preview / Organize";
            this.btnScanPreview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnScanPreview.UseVisualStyleBackColor = false;
            this.btnScanPreview.Click += new System.EventHandler(this.btnScanPreview_Click);
            // 
            // btnFolderSelection
            // 
            this.btnFolderSelection.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnFolderSelection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.btnFolderSelection.FlatAppearance.BorderSize = 0;
            this.btnFolderSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFolderSelection.Font = new System.Drawing.Font("Malgun Gothic", 10F);
            this.btnFolderSelection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnFolderSelection.Location = new System.Drawing.Point(18, 145);
            this.btnFolderSelection.MaximumSize = new System.Drawing.Size(180, 40);
            this.btnFolderSelection.Name = "btnFolderSelection";
            this.btnFolderSelection.Size = new System.Drawing.Size(180, 40);
            this.btnFolderSelection.TabIndex = 1;
            this.btnFolderSelection.Text = "📁 Select Folders";
            this.btnFolderSelection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFolderSelection.UseVisualStyleBackColor = false;
            this.btnFolderSelection.Click += new System.EventHandler(this.btnFolderSelection_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Malgun Gothic", 10F);
            this.btnDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnDashboard.Location = new System.Drawing.Point(18, 80);
            this.btnDashboard.MaximumSize = new System.Drawing.Size(180, 40);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(180, 40);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "📊 Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.label1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 60);
            this.panelLogo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Malgun Gothic", 17F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "📁 SmartFØ";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.panelHeader.Controls.Add(this.label2);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.panelHeader.Location = new System.Drawing.Point(220, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(962, 71);
            this.panelHeader.TabIndex = 1;
            this.panelHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHeader_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Malgun Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(22, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(355, 46);
            this.label2.TabIndex = 0;
            this.label2.Text = "Dashboard Overview";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(220, 71);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(962, 638);
            this.panelMain.TabIndex = 2;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // FormDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1182, 709);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelSidebar);
            this.Name = "FormDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Smart File Organizer - Dashboard";
            this.Load += new System.EventHandler(this.FormDashboard_Load);
            this.panelSidebar.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnFolderSelection;
        private System.Windows.Forms.Button btnConfigureRules;
        private System.Windows.Forms.Button btnOperationHistory;
        private System.Windows.Forms.Button btnScanPreview;
        private System.Windows.Forms.Button btnDuplicateCleaner;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Label label2;
    }
}

