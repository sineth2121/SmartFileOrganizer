namespace SmartFileOrganizer
{
    partial class FormPreviewOrganize
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelTopBar = new System.Windows.Forms.Panel();
            this.lblSimulationHint = new System.Windows.Forms.Label();
            this.splitContainerLayout = new System.Windows.Forms.SplitContainer();
            this.panelLeftCard = new System.Windows.Forms.Panel();
            this.lblTreeTitle = new System.Windows.Forms.Label();
            this.tvDestinationPreview = new System.Windows.Forms.TreeView();
            this.imageListTreeIcons = new System.Windows.Forms.ImageList(this.components);
            this.panelRightCard = new System.Windows.Forms.Panel();
            this.lblContentsTitle = new System.Windows.Forms.Label();
            this.lvFolderContents = new System.Windows.Forms.ListView();
            this.imageListFileIcons = new System.Windows.Forms.ImageList(this.components);
            this.panelFooterStrip = new System.Windows.Forms.Panel();
            this.lblProgressStatus = new System.Windows.Forms.Label();
            this.btnPreparePreview = new System.Windows.Forms.Button();
            this.prgOrganizeProgress = new System.Windows.Forms.ProgressBar();
            this.panelStats = new System.Windows.Forms.FlowLayoutPanel();
            this.lblStatTotal = new System.Windows.Forms.Label();
            this.lblStatMatched = new System.Windows.Forms.Label();
            this.lblStatUnmatched = new System.Windows.Forms.Label();
            this.btnExecuteOrganize = new System.Windows.Forms.Button();
            this.panelTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLayout)).BeginInit();
            this.splitContainerLayout.Panel1.SuspendLayout();
            this.splitContainerLayout.Panel2.SuspendLayout();
            this.splitContainerLayout.SuspendLayout();
            this.panelLeftCard.SuspendLayout();
            this.panelRightCard.SuspendLayout();
            this.panelFooterStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTopBar
            // 
            this.panelTopBar.BackColor = System.Drawing.Color.White;
            this.panelTopBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTopBar.Controls.Add(this.lblSimulationHint);
            this.panelTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopBar.Location = new System.Drawing.Point(0, 0);
            this.panelTopBar.Name = "panelTopBar";
            this.panelTopBar.Size = new System.Drawing.Size(960, 45);
            this.panelTopBar.TabIndex = 0;
            // 
            // lblSimulationHint
            // 
            this.lblSimulationHint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSimulationHint.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblSimulationHint.ForeColor = System.Drawing.Color.DimGray;
            this.lblSimulationHint.Location = new System.Drawing.Point(0, 0);
            this.lblSimulationHint.Name = "lblSimulationHint";
            this.lblSimulationHint.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.lblSimulationHint.Size = new System.Drawing.Size(958, 43);
            this.lblSimulationHint.TabIndex = 0;
            this.lblSimulationHint.Text = "🔍 Virtual Simulation: Review the projected destination file structure below befo" +
    "re executing.";
            this.lblSimulationHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainerLayout
            // 
            this.splitContainerLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerLayout.Location = new System.Drawing.Point(0, 45);
            this.splitContainerLayout.Name = "splitContainerLayout";
            // 
            // splitContainerLayout.Panel1
            // 
            this.splitContainerLayout.Panel1.Controls.Add(this.panelLeftCard);
            this.splitContainerLayout.Panel1MinSize = 280;
            // 
            // splitContainerLayout.Panel2
            // 
            this.splitContainerLayout.Panel2.Controls.Add(this.panelRightCard);
            this.splitContainerLayout.Panel2MinSize = 400;
            this.splitContainerLayout.Size = new System.Drawing.Size(960, 483);
            this.splitContainerLayout.SplitterDistance = 336;
            this.splitContainerLayout.SplitterWidth = 2;
            this.splitContainerLayout.TabIndex = 1;
            // 
            // panelLeftCard
            // 
            this.panelLeftCard.BackColor = System.Drawing.Color.White;
            this.panelLeftCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLeftCard.Controls.Add(this.lblTreeTitle);
            this.panelLeftCard.Controls.Add(this.tvDestinationPreview);
            this.panelLeftCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeftCard.Location = new System.Drawing.Point(0, 0);
            this.panelLeftCard.Name = "panelLeftCard";
            this.panelLeftCard.Padding = new System.Windows.Forms.Padding(8);
            this.panelLeftCard.Size = new System.Drawing.Size(336, 483);
            this.panelLeftCard.TabIndex = 0;
            // 
            // lblTreeTitle
            // 
            this.lblTreeTitle.AutoSize = true;
            this.lblTreeTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTreeTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTreeTitle.Name = "lblTreeTitle";
            this.lblTreeTitle.Size = new System.Drawing.Size(302, 23);
            this.lblTreeTitle.TabIndex = 1;
            this.lblTreeTitle.Text = "Proposed Destination Directory Tree";
            // 
            // tvDestinationPreview
            // 
            this.tvDestinationPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvDestinationPreview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvDestinationPreview.ImageIndex = 0;
            this.tvDestinationPreview.ImageList = this.imageListTreeIcons;
            this.tvDestinationPreview.Location = new System.Drawing.Point(10, 40);
            this.tvDestinationPreview.Name = "tvDestinationPreview";
            this.tvDestinationPreview.SelectedImageIndex = 0;
            this.tvDestinationPreview.Size = new System.Drawing.Size(314, 431);
            this.tvDestinationPreview.TabIndex = 0;
            this.tvDestinationPreview.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDestinationPreview_AfterSelect);
            // 
            // imageListTreeIcons
            // 
            this.imageListTreeIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListTreeIcons.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListTreeIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panelRightCard
            // 
            this.panelRightCard.BackColor = System.Drawing.Color.White;
            this.panelRightCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRightCard.Controls.Add(this.lblContentsTitle);
            this.panelRightCard.Controls.Add(this.lvFolderContents);
            this.panelRightCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRightCard.Location = new System.Drawing.Point(0, 0);
            this.panelRightCard.Name = "panelRightCard";
            this.panelRightCard.Padding = new System.Windows.Forms.Padding(8);
            this.panelRightCard.Size = new System.Drawing.Size(622, 483);
            this.panelRightCard.TabIndex = 0;
            // 
            // lblContentsTitle
            // 
            this.lblContentsTitle.AutoSize = true;
            this.lblContentsTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblContentsTitle.Location = new System.Drawing.Point(10, 10);
            this.lblContentsTitle.Name = "lblContentsTitle";
            this.lblContentsTitle.Size = new System.Drawing.Size(205, 23);
            this.lblContentsTitle.TabIndex = 1;
            this.lblContentsTitle.Text = "Folder Contents Preview";
            // 
            // lvFolderContents
            // 
            this.lvFolderContents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvFolderContents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvFolderContents.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvFolderContents.HideSelection = false;
            this.lvFolderContents.LargeImageList = this.imageListFileIcons;
            this.lvFolderContents.Location = new System.Drawing.Point(10, 40);
            this.lvFolderContents.Name = "lvFolderContents";
            this.lvFolderContents.Size = new System.Drawing.Size(600, 431);
            this.lvFolderContents.TabIndex = 0;
            this.lvFolderContents.UseCompatibleStateImageBehavior = false;
            // 
            // imageListFileIcons
            // 
            this.imageListFileIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListFileIcons.ImageSize = new System.Drawing.Size(48, 48);
            this.imageListFileIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panelFooterStrip
            // 
            this.panelFooterStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(243)))), ((int)(((byte)(254)))));
            this.panelFooterStrip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFooterStrip.Controls.Add(this.lblStatUnmatched);
            this.panelFooterStrip.Controls.Add(this.lblStatMatched);
            this.panelFooterStrip.Controls.Add(this.lblStatTotal);
            this.panelFooterStrip.Controls.Add(this.lblProgressStatus);
            this.panelFooterStrip.Controls.Add(this.btnPreparePreview);
            this.panelFooterStrip.Controls.Add(this.prgOrganizeProgress);
            this.panelFooterStrip.Controls.Add(this.panelStats);
            this.panelFooterStrip.Controls.Add(this.btnExecuteOrganize);
            this.panelFooterStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooterStrip.Location = new System.Drawing.Point(0, 528);
            this.panelFooterStrip.Name = "panelFooterStrip";
            this.panelFooterStrip.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.panelFooterStrip.Size = new System.Drawing.Size(960, 89);
            this.panelFooterStrip.TabIndex = 2;
            // 
            // lblProgressStatus
            // 
            this.lblProgressStatus.AutoSize = true;
            this.lblProgressStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblProgressStatus.ForeColor = System.Drawing.Color.DimGray;
            this.lblProgressStatus.Location = new System.Drawing.Point(12, 59);
            this.lblProgressStatus.Name = "lblProgressStatus";
            this.lblProgressStatus.Size = new System.Drawing.Size(231, 20);
            this.lblProgressStatus.TabIndex = 0;
            this.lblProgressStatus.Text = "Ready to process imported items.";
            this.lblProgressStatus.Click += new System.EventHandler(this.lblProgressStatus_Click);
            // 
            // btnPreparePreview
            // 
            this.btnPreparePreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(224)))), ((int)(((byte)(232)))));
            this.btnPreparePreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreparePreview.FlatAppearance.BorderSize = 0;
            this.btnPreparePreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreparePreview.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPreparePreview.Location = new System.Drawing.Point(10, 7);
            this.btnPreparePreview.Name = "btnPreparePreview";
            this.btnPreparePreview.Size = new System.Drawing.Size(230, 38);
            this.btnPreparePreview.TabIndex = 3;
            this.btnPreparePreview.Text = "🔍 Prepare Preview";
            this.btnPreparePreview.UseVisualStyleBackColor = false;
            this.btnPreparePreview.Click += new System.EventHandler(this.btnPreparePreview_Click);
            // 
            // prgOrganizeProgress
            // 
            this.prgOrganizeProgress.Location = new System.Drawing.Point(249, 8);
            this.prgOrganizeProgress.Name = "prgOrganizeProgress";
            this.prgOrganizeProgress.Size = new System.Drawing.Size(542, 38);
            this.prgOrganizeProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prgOrganizeProgress.TabIndex = 1;
            // 
            // panelStats
            // 
            this.panelStats.AutoSize = true;
            this.panelStats.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelStats.Location = new System.Drawing.Point(464, 13);
            this.panelStats.Name = "panelStats";
            this.panelStats.Size = new System.Drawing.Size(0, 0);
            this.panelStats.TabIndex = 4;
            // 
            // lblStatTotal
            // 
            this.lblStatTotal.AutoSize = true;
            this.lblStatTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.lblStatTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatTotal.ForeColor = System.Drawing.Color.Navy;
            this.lblStatTotal.Location = new System.Drawing.Point(249, 51);
            this.lblStatTotal.Name = "lblStatTotal";
            this.lblStatTotal.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblStatTotal.Size = new System.Drawing.Size(58, 28);
            this.lblStatTotal.TabIndex = 0;
            this.lblStatTotal.Text = "📁 0";
            // 
            // lblStatMatched
            // 
            this.lblStatMatched.AutoSize = true;
            this.lblStatMatched.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(245)))), ((int)(((byte)(220)))));
            this.lblStatMatched.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatMatched.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatMatched.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblStatMatched.Location = new System.Drawing.Point(313, 51);
            this.lblStatMatched.Name = "lblStatMatched";
            this.lblStatMatched.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblStatMatched.Size = new System.Drawing.Size(58, 28);
            this.lblStatMatched.TabIndex = 1;
            this.lblStatMatched.Text = "✅ 0";
            // 
            // lblStatUnmatched
            // 
            this.lblStatUnmatched.AutoSize = true;
            this.lblStatUnmatched.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblStatUnmatched.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatUnmatched.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatUnmatched.ForeColor = System.Drawing.Color.DarkRed;
            this.lblStatUnmatched.Location = new System.Drawing.Point(377, 51);
            this.lblStatUnmatched.Name = "lblStatUnmatched";
            this.lblStatUnmatched.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblStatUnmatched.Size = new System.Drawing.Size(58, 28);
            this.lblStatUnmatched.TabIndex = 2;
            this.lblStatUnmatched.Text = "⚠️ 0";
            // 
            // btnExecuteOrganize
            // 
            this.btnExecuteOrganize.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnExecuteOrganize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(224)))), ((int)(((byte)(232)))));
            this.btnExecuteOrganize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExecuteOrganize.FlatAppearance.BorderSize = 0;
            this.btnExecuteOrganize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExecuteOrganize.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnExecuteOrganize.Location = new System.Drawing.Point(797, 9);
            this.btnExecuteOrganize.Name = "btnExecuteOrganize";
            this.btnExecuteOrganize.Size = new System.Drawing.Size(150, 40);
            this.btnExecuteOrganize.TabIndex = 2;
            this.btnExecuteOrganize.Text = "⚡ Organize Files";
            this.btnExecuteOrganize.UseVisualStyleBackColor = false;
            this.btnExecuteOrganize.Click += new System.EventHandler(this.btnExecuteOrganize_Click);
            // 
            // FormPreviewOrganize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(960, 617);
            this.Controls.Add(this.splitContainerLayout);
            this.Controls.Add(this.panelFooterStrip);
            this.Controls.Add(this.panelTopBar);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.MinimumSize = new System.Drawing.Size(760, 400);
            this.Name = "FormPreviewOrganize";
            this.Text = "Preview & Organize";
            this.Load += new System.EventHandler(this.FormPreviewOrganize_Load);
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

        #endregion

        private System.Windows.Forms.Panel panelTopBar;
        private System.Windows.Forms.Label lblSimulationHint;
        private System.Windows.Forms.SplitContainer splitContainerLayout;
        private System.Windows.Forms.Panel panelLeftCard;
        private System.Windows.Forms.Label lblTreeTitle;
        private System.Windows.Forms.TreeView tvDestinationPreview;
        private System.Windows.Forms.Panel panelRightCard;
        private System.Windows.Forms.Label lblContentsTitle;
        private System.Windows.Forms.ListView lvFolderContents;
        private System.Windows.Forms.Panel panelFooterStrip;
        private System.Windows.Forms.Label lblProgressStatus;
        private System.Windows.Forms.ProgressBar prgOrganizeProgress;
        private System.Windows.Forms.Button btnExecuteOrganize;
        private System.Windows.Forms.ImageList imageListFileIcons;
        private System.Windows.Forms.ImageList imageListTreeIcons;
        private System.Windows.Forms.Button btnPreparePreview;
        private System.Windows.Forms.FlowLayoutPanel panelStats;
        private System.Windows.Forms.Label lblStatTotal;
        private System.Windows.Forms.Label lblStatMatched;
        private System.Windows.Forms.Label lblStatUnmatched;
    }
}
