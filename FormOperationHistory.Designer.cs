namespace SmartFileOrganizer
{
    partial class FormOperationHistory
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
            this.btnBack = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelDetailView = new System.Windows.Forms.Panel();
            this.lblSelectedInfo = new System.Windows.Forms.Label();
            this.lvOperationFiles = new System.Windows.Forms.ListView();
            this.panelListView = new System.Windows.Forms.Panel();
            this.lvExecutions = new System.Windows.Forms.ListView();
            this.panelFooterStrip = new System.Windows.Forms.Panel();
            this.btnClearHistory = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.prgUndoProgress = new System.Windows.Forms.ProgressBar();
            this.lblUndoStatus = new System.Windows.Forms.Label();
            this.imageListFileIcons = new System.Windows.Forms.ImageList(this.components);
            this.panelTopBar.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelDetailView.SuspendLayout();
            this.panelListView.SuspendLayout();
            this.panelFooterStrip.SuspendLayout();
            this.SuspendLayout();

            // panelTopBar
            this.panelTopBar.BackColor = System.Drawing.Color.White;
            this.panelTopBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTopBar.Controls.Add(this.btnBack);
            this.panelTopBar.Controls.Add(this.lblTitle);
            this.panelTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopBar.Location = new System.Drawing.Point(0, 0);
            this.panelTopBar.Name = "panelTopBar";
            this.panelTopBar.Size = new System.Drawing.Size(960, 45);
            this.panelTopBar.TabIndex = 0;

            // btnBack
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.btnBack.Location = new System.Drawing.Point(8, 6);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(90, 30);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "← Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Visible = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // lblTitle
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(958, 43);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🕒 Operation History";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // panelMain
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.panelMain.Controls.Add(this.panelDetailView);
            this.panelMain.Controls.Add(this.panelListView);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 45);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(10);
            this.panelMain.Size = new System.Drawing.Size(960, 483);
            this.panelMain.TabIndex = 1;

            // panelDetailView
            this.panelDetailView.BackColor = System.Drawing.Color.White;
            this.panelDetailView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDetailView.Controls.Add(this.lblSelectedInfo);
            this.panelDetailView.Controls.Add(this.lvOperationFiles);
            this.panelDetailView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetailView.Location = new System.Drawing.Point(10, 10);
            this.panelDetailView.Name = "panelDetailView";
            this.panelDetailView.Padding = new System.Windows.Forms.Padding(8);
            this.panelDetailView.Size = new System.Drawing.Size(940, 463);
            this.panelDetailView.TabIndex = 1;
            this.panelDetailView.Visible = false;

            // lblSelectedInfo
            this.lblSelectedInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSelectedInfo.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblSelectedInfo.Location = new System.Drawing.Point(10, 8);
            this.lblSelectedInfo.Name = "lblSelectedInfo";
            this.lblSelectedInfo.Size = new System.Drawing.Size(910, 24);
            this.lblSelectedInfo.TabIndex = 1;
            this.lblSelectedInfo.Text = "";

            // lvOperationFiles
            this.lvOperationFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvOperationFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvOperationFiles.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lvOperationFiles.FullRowSelect = true;
            this.lvOperationFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvOperationFiles.HideSelection = false;
            this.lvOperationFiles.Location = new System.Drawing.Point(10, 38);
            this.lvOperationFiles.Name = "lvOperationFiles";
            this.lvOperationFiles.Size = new System.Drawing.Size(910, 410);
            this.lvOperationFiles.TabIndex = 0;
            this.lvOperationFiles.UseCompatibleStateImageBehavior = false;
            this.lvOperationFiles.View = System.Windows.Forms.View.Details;
            this.lvOperationFiles.Columns.Add("File Name", 220);
            this.lvOperationFiles.Columns.Add("Operation", 70);
            this.lvOperationFiles.Columns.Add("Size", 90);
            this.lvOperationFiles.Columns.Add("Status", 100);
            this.lvOperationFiles.Columns.Add("Source Path", 300);

            // panelListView
            this.panelListView.BackColor = System.Drawing.Color.White;
            this.panelListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelListView.Controls.Add(this.lvExecutions);
            this.panelListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelListView.Location = new System.Drawing.Point(10, 10);
            this.panelListView.Name = "panelListView";
            this.panelListView.Padding = new System.Windows.Forms.Padding(8);
            this.panelListView.Size = new System.Drawing.Size(940, 463);
            this.panelListView.TabIndex = 0;

            // lvExecutions
            this.lvExecutions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvExecutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvExecutions.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lvExecutions.FullRowSelect = true;
            this.lvExecutions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvExecutions.HideSelection = false;
            this.lvExecutions.Location = new System.Drawing.Point(8, 8);
            this.lvExecutions.Name = "lvExecutions";
            this.lvExecutions.Size = new System.Drawing.Size(922, 445);
            this.lvExecutions.TabIndex = 0;
            this.lvExecutions.UseCompatibleStateImageBehavior = false;
            this.lvExecutions.View = System.Windows.Forms.View.Details;
            this.lvExecutions.MultiSelect = false;
            this.lvExecutions.Columns.Add("Date & Time", 160);
            this.lvExecutions.Columns.Add("Operation", 80);
            this.lvExecutions.Columns.Add("Files", 60);
            this.lvExecutions.Columns.Add("Total Size", 100);
            this.lvExecutions.Columns.Add("Success", 70);
            this.lvExecutions.Columns.Add("Failed", 70);
            this.lvExecutions.Columns.Add("Execution ID", 120);
            this.lvExecutions.Click += new System.EventHandler(this.lvExecutions_Click);

            // panelFooterStrip
            this.panelFooterStrip.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.panelFooterStrip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFooterStrip.Controls.Add(this.lblUndoStatus);
            this.panelFooterStrip.Controls.Add(this.btnClearHistory);
            this.panelFooterStrip.Controls.Add(this.btnUndo);
            this.panelFooterStrip.Controls.Add(this.prgUndoProgress);
            this.panelFooterStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooterStrip.Location = new System.Drawing.Point(0, 528);
            this.panelFooterStrip.Name = "panelFooterStrip";
            this.panelFooterStrip.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.panelFooterStrip.Size = new System.Drawing.Size(960, 65);
            this.panelFooterStrip.TabIndex = 2;

            // btnClearHistory
            this.btnClearHistory.BackColor = System.Drawing.Color.FromArgb(140, 140, 140);
            this.btnClearHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearHistory.FlatAppearance.BorderSize = 0;
            this.btnClearHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearHistory.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnClearHistory.ForeColor = System.Drawing.Color.White;
            this.btnClearHistory.Location = new System.Drawing.Point(10, 10);
            this.btnClearHistory.Name = "btnClearHistory";
            this.btnClearHistory.Size = new System.Drawing.Size(150, 38);
            this.btnClearHistory.TabIndex = 0;
            this.btnClearHistory.Text = "🗑️ Clear History";
            this.btnClearHistory.UseVisualStyleBackColor = false;
            this.btnClearHistory.Click += new System.EventHandler(this.btnClearHistory_Click);

            // btnUndo
            this.btnUndo.BackColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.btnUndo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUndo.FlatAppearance.BorderSize = 0;
            this.btnUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUndo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnUndo.ForeColor = System.Drawing.Color.White;
            this.btnUndo.Location = new System.Drawing.Point(175, 10);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(150, 38);
            this.btnUndo.TabIndex = 1;
            this.btnUndo.Text = "↩ Undo Selected";
            this.btnUndo.UseVisualStyleBackColor = false;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);

            // prgUndoProgress
            this.prgUndoProgress.ForeColor = System.Drawing.Color.FromArgb(110, 110, 110);
            this.prgUndoProgress.Location = new System.Drawing.Point(340, 10);
            this.prgUndoProgress.Name = "prgUndoProgress";
            this.prgUndoProgress.Size = new System.Drawing.Size(400, 20);
            this.prgUndoProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prgUndoProgress.TabIndex = 2;

            // lblUndoStatus
            this.lblUndoStatus.AutoSize = true;
            this.lblUndoStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblUndoStatus.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblUndoStatus.Location = new System.Drawing.Point(340, 35);
            this.lblUndoStatus.Name = "lblUndoStatus";
            this.lblUndoStatus.Size = new System.Drawing.Size(86, 20);
            this.lblUndoStatus.TabIndex = 3;
            this.lblUndoStatus.Text = "Ready";

            // imageListFileIcons
            this.imageListFileIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListFileIcons.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListFileIcons.TransparentColor = System.Drawing.Color.Transparent;

            // FormOperationHistory
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.ClientSize = new System.Drawing.Size(960, 593);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelFooterStrip);
            this.Controls.Add(this.panelTopBar);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.MinimumSize = new System.Drawing.Size(760, 400);
            this.Name = "FormOperationHistory";
            this.Text = "Operation History";
            this.Load += new System.EventHandler(this.FormOperationHistory_Load);
            this.panelTopBar.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelDetailView.ResumeLayout(false);
            this.panelListView.ResumeLayout(false);
            this.panelFooterStrip.ResumeLayout(false);
            this.panelFooterStrip.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTopBar;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelDetailView;
        private System.Windows.Forms.Label lblSelectedInfo;
        private System.Windows.Forms.ListView lvOperationFiles;
        private System.Windows.Forms.Panel panelListView;
        private System.Windows.Forms.ListView lvExecutions;
        private System.Windows.Forms.Panel panelFooterStrip;
        private System.Windows.Forms.Button btnClearHistory;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.ProgressBar prgUndoProgress;
        private System.Windows.Forms.Label lblUndoStatus;
        private System.Windows.Forms.ImageList imageListFileIcons;
    }
}
