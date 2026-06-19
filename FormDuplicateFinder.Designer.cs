namespace SmartFileOrganizer
{
    partial class FormDuplicateFinder
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
            this.components = new System.ComponentModel.Container();
            this.panelTopBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.splitContainerLayout = new System.Windows.Forms.SplitContainer();
            this.panelLeftCard = new System.Windows.Forms.Panel();
            this.lblWastedSpace = new System.Windows.Forms.Label();
            this.lblTotalDupFiles = new System.Windows.Forms.Label();
            this.lblDupSets = new System.Windows.Forms.Label();
            this.lblTotalFiles = new System.Windows.Forms.Label();
            this.cboMethod = new System.Windows.Forms.ComboBox();
            this.lblMethodLabel = new System.Windows.Forms.Label();
            this.lblSummaryTitle = new System.Windows.Forms.Label();
            this.panelRightCard = new System.Windows.Forms.Panel();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.lblSetNav = new System.Windows.Forms.Label();
            this.panelFooterStrip = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.prgScanProgress = new System.Windows.Forms.ProgressBar();
            this.panelTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLayout)).BeginInit();
            this.splitContainerLayout.Panel1.SuspendLayout();
            this.splitContainerLayout.Panel2.SuspendLayout();
            this.splitContainerLayout.SuspendLayout();
            this.panelLeftCard.SuspendLayout();
            this.panelRightCard.SuspendLayout();
            this.panelFooterStrip.SuspendLayout();
            this.SuspendLayout();

            // panelTopBar
            this.panelTopBar.BackColor = System.Drawing.Color.White;
            this.panelTopBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTopBar.Controls.Add(this.lblTitle);
            this.panelTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopBar.Location = new System.Drawing.Point(0, 0);
            this.panelTopBar.Name = "panelTopBar";
            this.panelTopBar.Size = new System.Drawing.Size(960, 45);
            this.panelTopBar.TabIndex = 0;

            // lblTitle
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(958, 43);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🔍 Duplicate Finder";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // splitContainerLayout
            this.splitContainerLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerLayout.Location = new System.Drawing.Point(0, 45);
            this.splitContainerLayout.Name = "splitContainerLayout";
            this.splitContainerLayout.Panel1.Controls.Add(this.panelLeftCard);
            this.splitContainerLayout.Panel1MinSize = 260;
            this.splitContainerLayout.Panel2.Controls.Add(this.panelRightCard);
            this.splitContainerLayout.Panel2MinSize = 350;
            this.splitContainerLayout.Size = new System.Drawing.Size(960, 483);
            this.splitContainerLayout.SplitterDistance = 300;
            this.splitContainerLayout.SplitterWidth = 2;
            this.splitContainerLayout.TabIndex = 1;

            // panelLeftCard
            this.panelLeftCard.BackColor = System.Drawing.Color.White;
            this.panelLeftCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLeftCard.Controls.Add(this.lblWastedSpace);
            this.panelLeftCard.Controls.Add(this.lblTotalDupFiles);
            this.panelLeftCard.Controls.Add(this.lblDupSets);
            this.panelLeftCard.Controls.Add(this.lblTotalFiles);
            this.panelLeftCard.Controls.Add(this.cboMethod);
            this.panelLeftCard.Controls.Add(this.lblMethodLabel);
            this.panelLeftCard.Controls.Add(this.lblSummaryTitle);
            this.panelLeftCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeftCard.Location = new System.Drawing.Point(0, 0);
            this.panelLeftCard.Name = "panelLeftCard";
            this.panelLeftCard.Padding = new System.Windows.Forms.Padding(10);
            this.panelLeftCard.Size = new System.Drawing.Size(300, 483);
            this.panelLeftCard.TabIndex = 0;

            // lblWastedSpace
            this.lblWastedSpace.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblWastedSpace.ForeColor = System.Drawing.Color.DimGray;
            this.lblWastedSpace.Location = new System.Drawing.Point(12, 190);
            this.lblWastedSpace.Name = "lblWastedSpace";
            this.lblWastedSpace.Size = new System.Drawing.Size(270, 24);
            this.lblWastedSpace.TabIndex = 6;
            this.lblWastedSpace.Text = "Wasted space: —";

            // lblTotalDupFiles
            this.lblTotalDupFiles.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalDupFiles.ForeColor = System.Drawing.Color.DimGray;
            this.lblTotalDupFiles.Location = new System.Drawing.Point(12, 166);
            this.lblTotalDupFiles.Name = "lblTotalDupFiles";
            this.lblTotalDupFiles.Size = new System.Drawing.Size(270, 24);
            this.lblTotalDupFiles.TabIndex = 5;
            this.lblTotalDupFiles.Text = "Duplicate files: —";

            // lblDupSets
            this.lblDupSets.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDupSets.ForeColor = System.Drawing.Color.DimGray;
            this.lblDupSets.Location = new System.Drawing.Point(12, 142);
            this.lblDupSets.Name = "lblDupSets";
            this.lblDupSets.Size = new System.Drawing.Size(270, 24);
            this.lblDupSets.TabIndex = 4;
            this.lblDupSets.Text = "Duplicate sets: —";

            // lblTotalFiles
            this.lblTotalFiles.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalFiles.ForeColor = System.Drawing.Color.DimGray;
            this.lblTotalFiles.Location = new System.Drawing.Point(12, 118);
            this.lblTotalFiles.Name = "lblTotalFiles";
            this.lblTotalFiles.Size = new System.Drawing.Size(270, 24);
            this.lblTotalFiles.TabIndex = 3;
            this.lblTotalFiles.Text = "Total files scanned: —";

            // cboMethod
            this.cboMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMethod.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboMethod.Items.AddRange(new object[] {
                "Name + Size",
                "Hash (MD5)",
                "Name Only",
                "Size Only"});
            this.cboMethod.Location = new System.Drawing.Point(15, 70);
            this.cboMethod.Name = "cboMethod";
            this.cboMethod.Size = new System.Drawing.Size(265, 29);
            this.cboMethod.TabIndex = 2;
            this.cboMethod.SelectedIndex = 0;

            // lblMethodLabel
            this.lblMethodLabel.AutoSize = true;
            this.lblMethodLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblMethodLabel.ForeColor = System.Drawing.Color.DimGray;
            this.lblMethodLabel.Location = new System.Drawing.Point(12, 48);
            this.lblMethodLabel.Name = "lblMethodLabel";
            this.lblMethodLabel.Size = new System.Drawing.Size(133, 20);
            this.lblMethodLabel.TabIndex = 1;
            this.lblMethodLabel.Text = "Detection method:";

            // lblSummaryTitle
            this.lblSummaryTitle.AutoSize = true;
            this.lblSummaryTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSummaryTitle.Location = new System.Drawing.Point(12, 12);
            this.lblSummaryTitle.Name = "lblSummaryTitle";
            this.lblSummaryTitle.Size = new System.Drawing.Size(117, 21);
            this.lblSummaryTitle.TabIndex = 0;
            this.lblSummaryTitle.Text = "Scan Summary";

            // panelRightCard
            this.panelRightCard.BackColor = System.Drawing.Color.White;
            this.panelRightCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRightCard.Controls.Add(this.btnNext);
            this.panelRightCard.Controls.Add(this.btnPrev);
            this.panelRightCard.Controls.Add(this.lblSetNav);
            this.panelRightCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRightCard.Location = new System.Drawing.Point(0, 0);
            this.panelRightCard.Name = "panelRightCard";
            this.panelRightCard.Padding = new System.Windows.Forms.Padding(10);
            this.panelRightCard.Size = new System.Drawing.Size(658, 483);
            this.panelRightCard.TabIndex = 0;

            // btnNext
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(174, 224, 232);
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNext.Location = new System.Drawing.Point(535, 10);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(105, 30);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Next ▶";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);

            // btnPrev
            this.btnPrev.BackColor = System.Drawing.Color.FromArgb(174, 224, 232);
            this.btnPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrev.FlatAppearance.BorderSize = 0;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnPrev.Location = new System.Drawing.Point(12, 10);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(105, 30);
            this.btnPrev.TabIndex = 1;
            this.btnPrev.Text = "◀ Previous";
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);

            // lblSetNav
            this.lblSetNav.AutoSize = true;
            this.lblSetNav.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSetNav.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblSetNav.Location = new System.Drawing.Point(260, 14);
            this.lblSetNav.Name = "lblSetNav";
            this.lblSetNav.Size = new System.Drawing.Size(79, 21);
            this.lblSetNav.TabIndex = 0;
            this.lblSetNav.Text = "Set 0 of 0";
            this.lblSetNav.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // panelFooterStrip
            this.panelFooterStrip.BackColor = System.Drawing.Color.FromArgb(230, 243, 254);
            this.panelFooterStrip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFooterStrip.Controls.Add(this.lblStatus);
            this.panelFooterStrip.Controls.Add(this.btnDeleteSelected);
            this.panelFooterStrip.Controls.Add(this.btnScan);
            this.panelFooterStrip.Controls.Add(this.prgScanProgress);
            this.panelFooterStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooterStrip.Location = new System.Drawing.Point(0, 528);
            this.panelFooterStrip.Name = "panelFooterStrip";
            this.panelFooterStrip.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.panelFooterStrip.Size = new System.Drawing.Size(960, 65);
            this.panelFooterStrip.TabIndex = 2;

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblStatus.ForeColor = System.Drawing.Color.DimGray;
            this.lblStatus.Location = new System.Drawing.Point(340, 35);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(88, 20);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Ready";

            // btnDeleteSelected
            this.btnDeleteSelected.BackColor = System.Drawing.Color.FromArgb(255, 200, 200);
            this.btnDeleteSelected.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteSelected.FlatAppearance.BorderSize = 0;
            this.btnDeleteSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteSelected.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnDeleteSelected.Location = new System.Drawing.Point(175, 8);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(150, 38);
            this.btnDeleteSelected.TabIndex = 2;
            this.btnDeleteSelected.Text = "🗑️ Delete Selected";
            this.btnDeleteSelected.UseVisualStyleBackColor = false;
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);

            // btnScan
            this.btnScan.BackColor = System.Drawing.Color.FromArgb(174, 224, 232);
            this.btnScan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnScan.FlatAppearance.BorderSize = 0;
            this.btnScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnScan.Location = new System.Drawing.Point(10, 8);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(150, 38);
            this.btnScan.TabIndex = 1;
            this.btnScan.Text = "🔍 Scan";
            this.btnScan.UseVisualStyleBackColor = false;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);

            // prgScanProgress
            this.prgScanProgress.Location = new System.Drawing.Point(340, 8);
            this.prgScanProgress.Name = "prgScanProgress";
            this.prgScanProgress.Size = new System.Drawing.Size(600, 20);
            this.prgScanProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prgScanProgress.TabIndex = 0;

            // FormDuplicateFinder
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.ClientSize = new System.Drawing.Size(960, 593);
            this.Controls.Add(this.splitContainerLayout);
            this.Controls.Add(this.panelFooterStrip);
            this.Controls.Add(this.panelTopBar);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.MinimumSize = new System.Drawing.Size(760, 400);
            this.Name = "FormDuplicateFinder";
            this.Text = "Duplicate Finder";
            this.Load += new System.EventHandler(this.FormDuplicateFinder_Load);
            this.panelTopBar.ResumeLayout(false);
            this.splitContainerLayout.Panel1.ResumeLayout(false);
            this.splitContainerLayout.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLayout)).EndInit();
            this.splitContainerLayout.ResumeLayout(false);
            this.panelLeftCard.ResumeLayout(false);
            this.panelLeftCard.PerformLayout();
            this.panelRightCard.ResumeLayout(false);
            this.panelRightCard.PerformLayout();
            this.panelFooterStrip.ResumeLayout(false);
            this.panelFooterStrip.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTopBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.SplitContainer splitContainerLayout;
        private System.Windows.Forms.Panel panelLeftCard;
        private System.Windows.Forms.Label lblTotalFiles;
        private System.Windows.Forms.ComboBox cboMethod;
        private System.Windows.Forms.Label lblMethodLabel;
        private System.Windows.Forms.Label lblSummaryTitle;
        private System.Windows.Forms.Label lblWastedSpace;
        private System.Windows.Forms.Label lblTotalDupFiles;
        private System.Windows.Forms.Label lblDupSets;
        private System.Windows.Forms.Panel panelRightCard;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Label lblSetNav;
        private System.Windows.Forms.Panel panelFooterStrip;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnDeleteSelected;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.ProgressBar prgScanProgress;
    }
}
