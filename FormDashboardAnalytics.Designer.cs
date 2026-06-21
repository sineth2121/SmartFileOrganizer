namespace SmartFileOrganizer
{
    partial class FormDashboardAnalytics
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblProgressStatus = new System.Windows.Forms.Label();
            this.panelSummaryRow = new System.Windows.Forms.FlowLayoutPanel();
            this.cardTotalFiles = new System.Windows.Forms.Panel();
            this.lblTotalFilesIcon = new System.Windows.Forms.Label();
            this.lblTotalFilesValue = new System.Windows.Forms.Label();
            this.lblTotalFilesLabel = new System.Windows.Forms.Label();
            this.cardOrganized = new System.Windows.Forms.Panel();
            this.lblOrganizedIcon = new System.Windows.Forms.Label();
            this.lblOrganizedValue = new System.Windows.Forms.Label();
            this.lblOrganizedLabel = new System.Windows.Forms.Label();
            this.cardRules = new System.Windows.Forms.Panel();
            this.lblRulesIcon = new System.Windows.Forms.Label();
            this.lblRulesValue = new System.Windows.Forms.Label();
            this.lblRulesLabel = new System.Windows.Forms.Label();
            this.cardDups = new System.Windows.Forms.Panel();
            this.lblDupsIcon = new System.Windows.Forms.Label();
            this.lblDupsValue = new System.Windows.Forms.Label();
            this.lblDupsLabel = new System.Windows.Forms.Label();
            this.cardWaste = new System.Windows.Forms.Panel();
            this.lblWasteIcon = new System.Windows.Forms.Label();
            this.lblWasteValue = new System.Windows.Forms.Label();
            this.lblWasteLabel = new System.Windows.Forms.Label();
            this.panelDestination = new System.Windows.Forms.Panel();
            this.lblDestIcon = new System.Windows.Forms.Label();
            this.lblDestinationPath = new System.Windows.Forms.Label();
            this.lblDriveSpace = new System.Windows.Forms.Label();
            this.panelChartRow = new System.Windows.Forms.TableLayoutPanel();
            this.chartFilesByType = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartOpsLast7Days = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelActions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNavImport = new System.Windows.Forms.Button();
            this.btnNavRules = new System.Windows.Forms.Button();
            this.btnNavDuplicates = new System.Windows.Forms.Button();
            this.panelMainContainer = new System.Windows.Forms.Panel();
            this.cardTotalFiles.SuspendLayout();
            this.cardOrganized.SuspendLayout();
            this.cardRules.SuspendLayout();
            this.cardDups.SuspendLayout();
            this.cardWaste.SuspendLayout();
            this.panelDestination.SuspendLayout();
            this.panelChartRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartFilesByType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartOpsLast7Days)).BeginInit();
            this.panelActions.SuspendLayout();
            this.panelMainContainer.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.panelBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBottom.Controls.Add(this.lblProgressStatus);
            this.panelBottom.Controls.Add(this.progressBar);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 622);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
            this.panelBottom.Size = new System.Drawing.Size(960, 60);
            this.panelBottom.TabIndex = 5;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(12, 30);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(700, 22);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 0;
            // 
            // lblProgressStatus
            // 
            this.lblProgressStatus.AutoSize = true;
            this.lblProgressStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProgressStatus.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblProgressStatus.Location = new System.Drawing.Point(12, 4);
            this.lblProgressStatus.Name = "lblProgressStatus";
            this.lblProgressStatus.Size = new System.Drawing.Size(46, 20);
            this.lblProgressStatus.TabIndex = 1;
            this.lblProgressStatus.Text = "Ready";
            // 
            // panelSummaryRow
            // 
            this.panelSummaryRow.AutoSize = true;
            this.panelSummaryRow.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSummaryRow.Location = new System.Drawing.Point(0, 0);
            this.panelSummaryRow.Name = "panelSummaryRow";
            this.panelSummaryRow.Padding = new System.Windows.Forms.Padding(15, 15, 15, 5);
            this.panelSummaryRow.Size = new System.Drawing.Size(960, 0);
            this.panelSummaryRow.TabIndex = 0;
            // 
            // ============ CARD: Total Files ============
            // 
            this.cardTotalFiles.BackColor = System.Drawing.Color.White;
            this.cardTotalFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardTotalFiles.Controls.Add(this.lblTotalFilesIcon);
            this.cardTotalFiles.Controls.Add(this.lblTotalFilesValue);
            this.cardTotalFiles.Controls.Add(this.lblTotalFilesLabel);
            this.cardTotalFiles.Location = new System.Drawing.Point(18, 18);
            this.cardTotalFiles.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.cardTotalFiles.Name = "cardTotalFiles";
            this.cardTotalFiles.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.cardTotalFiles.Size = new System.Drawing.Size(170, 80);
            this.cardTotalFiles.TabIndex = 0;
            // 
            // lblTotalFilesIcon
            // 
            this.lblTotalFilesIcon.AutoSize = true;
            this.lblTotalFilesIcon.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotalFilesIcon.ForeColor = System.Drawing.Color.FromArgb(74, 144, 217);
            this.lblTotalFilesIcon.Location = new System.Drawing.Point(12, 8);
            this.lblTotalFilesIcon.Name = "lblTotalFilesIcon";
            this.lblTotalFilesIcon.Size = new System.Drawing.Size(34, 28);
            this.lblTotalFilesIcon.TabIndex = 0;
            this.lblTotalFilesIcon.Text = "\U0001f4c1";
            // 
            // lblTotalFilesValue
            // 
            this.lblTotalFilesValue.AutoSize = true;
            this.lblTotalFilesValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalFilesValue.ForeColor = System.Drawing.Color.FromArgb(74, 144, 217);
            this.lblTotalFilesValue.Location = new System.Drawing.Point(52, 5);
            this.lblTotalFilesValue.Name = "lblTotalFilesValue";
            this.lblTotalFilesValue.Size = new System.Drawing.Size(27, 32);
            this.lblTotalFilesValue.TabIndex = 1;
            this.lblTotalFilesValue.Text = "0";
            // 
            // lblTotalFilesLabel
            // 
            this.lblTotalFilesLabel.AutoSize = true;
            this.lblTotalFilesLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFilesLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalFilesLabel.Location = new System.Drawing.Point(13, 50);
            this.lblTotalFilesLabel.Name = "lblTotalFilesLabel";
            this.lblTotalFilesLabel.Size = new System.Drawing.Size(82, 20);
            this.lblTotalFilesLabel.TabIndex = 2;
            this.lblTotalFilesLabel.Text = "Total Imported";
            // 
            // ============ CARD: Organized ============
            // 
            this.cardOrganized.BackColor = System.Drawing.Color.White;
            this.cardOrganized.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardOrganized.Controls.Add(this.lblOrganizedIcon);
            this.cardOrganized.Controls.Add(this.lblOrganizedValue);
            this.cardOrganized.Controls.Add(this.lblOrganizedLabel);
            this.cardOrganized.Location = new System.Drawing.Point(196, 18);
            this.cardOrganized.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.cardOrganized.Name = "cardOrganized";
            this.cardOrganized.Size = new System.Drawing.Size(170, 80);
            this.cardOrganized.TabIndex = 1;
            // 
            // lblOrganizedIcon
            // 
            this.lblOrganizedIcon.AutoSize = true;
            this.lblOrganizedIcon.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblOrganizedIcon.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblOrganizedIcon.Location = new System.Drawing.Point(12, 8);
            this.lblOrganizedIcon.Name = "lblOrganizedIcon";
            this.lblOrganizedIcon.Size = new System.Drawing.Size(28, 28);
            this.lblOrganizedIcon.TabIndex = 0;
            this.lblOrganizedIcon.Text = "\u2705";
            // 
            // lblOrganizedValue
            // 
            this.lblOrganizedValue.AutoSize = true;
            this.lblOrganizedValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblOrganizedValue.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblOrganizedValue.Location = new System.Drawing.Point(46, 5);
            this.lblOrganizedValue.Name = "lblOrganizedValue";
            this.lblOrganizedValue.Size = new System.Drawing.Size(27, 32);
            this.lblOrganizedValue.TabIndex = 1;
            this.lblOrganizedValue.Text = "0";
            // 
            // lblOrganizedLabel
            // 
            this.lblOrganizedLabel.AutoSize = true;
            this.lblOrganizedLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOrganizedLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblOrganizedLabel.Location = new System.Drawing.Point(13, 50);
            this.lblOrganizedLabel.Name = "lblOrganizedLabel";
            this.lblOrganizedLabel.Size = new System.Drawing.Size(80, 20);
            this.lblOrganizedLabel.TabIndex = 2;
            this.lblOrganizedLabel.Text = "Organized ✓";
            // 
            // ============ CARD: Rules ============
            // 
            this.cardRules.BackColor = System.Drawing.Color.White;
            this.cardRules.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardRules.Controls.Add(this.lblRulesIcon);
            this.cardRules.Controls.Add(this.lblRulesValue);
            this.cardRules.Controls.Add(this.lblRulesLabel);
            this.cardRules.Location = new System.Drawing.Point(374, 18);
            this.cardRules.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.cardRules.Name = "cardRules";
            this.cardRules.Size = new System.Drawing.Size(170, 80);
            this.cardRules.TabIndex = 2;
            // 
            // lblRulesIcon
            // 
            this.lblRulesIcon.AutoSize = true;
            this.lblRulesIcon.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblRulesIcon.ForeColor = System.Drawing.Color.FromArgb(243, 156, 18);
            this.lblRulesIcon.Location = new System.Drawing.Point(12, 8);
            this.lblRulesIcon.Name = "lblRulesIcon";
            this.lblRulesIcon.Size = new System.Drawing.Size(34, 28);
            this.lblRulesIcon.TabIndex = 0;
            this.lblRulesIcon.Text = "\u2699\ufe0f";
            // 
            // lblRulesValue
            // 
            this.lblRulesValue.AutoSize = true;
            this.lblRulesValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblRulesValue.ForeColor = System.Drawing.Color.FromArgb(243, 156, 18);
            this.lblRulesValue.Location = new System.Drawing.Point(52, 5);
            this.lblRulesValue.Name = "lblRulesValue";
            this.lblRulesValue.Size = new System.Drawing.Size(27, 32);
            this.lblRulesValue.TabIndex = 1;
            this.lblRulesValue.Text = "0";
            // 
            // lblRulesLabel
            // 
            this.lblRulesLabel.AutoSize = true;
            this.lblRulesLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRulesLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblRulesLabel.Location = new System.Drawing.Point(13, 50);
            this.lblRulesLabel.Name = "lblRulesLabel";
            this.lblRulesLabel.Size = new System.Drawing.Size(90, 20);
            this.lblRulesLabel.TabIndex = 2;
            this.lblRulesLabel.Text = "Active Rules";
            // 
            // ============ CARD: Dups ============
            // 
            this.cardDups.BackColor = System.Drawing.Color.White;
            this.cardDups.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardDups.Controls.Add(this.lblDupsIcon);
            this.cardDups.Controls.Add(this.lblDupsValue);
            this.cardDups.Controls.Add(this.lblDupsLabel);
            this.cardDups.Location = new System.Drawing.Point(552, 18);
            this.cardDups.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.cardDups.Name = "cardDups";
            this.cardDups.Size = new System.Drawing.Size(170, 80);
            this.cardDups.TabIndex = 3;
            // 
            // lblDupsIcon
            // 
            this.lblDupsIcon.AutoSize = true;
            this.lblDupsIcon.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDupsIcon.ForeColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.lblDupsIcon.Location = new System.Drawing.Point(12, 8);
            this.lblDupsIcon.Name = "lblDupsIcon";
            this.lblDupsIcon.Size = new System.Drawing.Size(34, 28);
            this.lblDupsIcon.TabIndex = 0;
            this.lblDupsIcon.Text = "\U0001f5d1\ufe0f";
            // 
            // lblDupsValue
            // 
            this.lblDupsValue.AutoSize = true;
            this.lblDupsValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDupsValue.ForeColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.lblDupsValue.Location = new System.Drawing.Point(52, 5);
            this.lblDupsValue.Name = "lblDupsValue";
            this.lblDupsValue.Size = new System.Drawing.Size(27, 32);
            this.lblDupsValue.TabIndex = 1;
            this.lblDupsValue.Text = "0";
            // 
            // lblDupsLabel
            // 
            this.lblDupsLabel.AutoSize = true;
            this.lblDupsLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDupsLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblDupsLabel.Location = new System.Drawing.Point(13, 50);
            this.lblDupsLabel.Name = "lblDupsLabel";
            this.lblDupsLabel.Size = new System.Drawing.Size(103, 20);
            this.lblDupsLabel.TabIndex = 2;
            this.lblDupsLabel.Text = "Duplicate Sets";
            // 
            // ============ CARD: Waste ============
            // 
            this.cardWaste.BackColor = System.Drawing.Color.White;
            this.cardWaste.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardWaste.Controls.Add(this.lblWasteIcon);
            this.cardWaste.Controls.Add(this.lblWasteValue);
            this.cardWaste.Controls.Add(this.lblWasteLabel);
            this.cardWaste.Location = new System.Drawing.Point(730, 18);
            this.cardWaste.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.cardWaste.Name = "cardWaste";
            this.cardWaste.Size = new System.Drawing.Size(170, 80);
            this.cardWaste.TabIndex = 4;
            // 
            // lblWasteIcon
            // 
            this.lblWasteIcon.AutoSize = true;
            this.lblWasteIcon.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblWasteIcon.ForeColor = System.Drawing.Color.FromArgb(142, 68, 173);
            this.lblWasteIcon.Location = new System.Drawing.Point(12, 8);
            this.lblWasteIcon.Name = "lblWasteIcon";
            this.lblWasteIcon.Size = new System.Drawing.Size(34, 28);
            this.lblWasteIcon.TabIndex = 0;
            this.lblWasteIcon.Text = "\U0001f4be";
            // 
            // lblWasteValue
            // 
            this.lblWasteValue.AutoSize = true;
            this.lblWasteValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblWasteValue.ForeColor = System.Drawing.Color.FromArgb(142, 68, 173);
            this.lblWasteValue.Location = new System.Drawing.Point(52, 5);
            this.lblWasteValue.Name = "lblWasteValue";
            this.lblWasteValue.Size = new System.Drawing.Size(38, 32);
            this.lblWasteValue.TabIndex = 1;
            this.lblWasteValue.Text = "0 B";
            // 
            // lblWasteLabel
            // 
            this.lblWasteLabel.AutoSize = true;
            this.lblWasteLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblWasteLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblWasteLabel.Location = new System.Drawing.Point(13, 50);
            this.lblWasteLabel.Name = "lblWasteLabel";
            this.lblWasteLabel.Size = new System.Drawing.Size(95, 20);
            this.lblWasteLabel.TabIndex = 2;
            this.lblWasteLabel.Text = "Wasted Space";
            // 
            // panelDestination
            // 
            this.panelDestination.BackColor = System.Drawing.Color.White;
            this.panelDestination.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDestination.Controls.Add(this.lblDestIcon);
            this.panelDestination.Controls.Add(this.lblDestinationPath);
            this.panelDestination.Controls.Add(this.lblDriveSpace);
            this.panelDestination.Location = new System.Drawing.Point(18, 105);
            this.panelDestination.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.panelDestination.Name = "panelDestination";
            this.panelDestination.Size = new System.Drawing.Size(924, 55);
            this.panelDestination.TabIndex = 1;
            // 
            // lblDestIcon
            // 
            this.lblDestIcon.AutoSize = true;
            this.lblDestIcon.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDestIcon.Location = new System.Drawing.Point(12, 12);
            this.lblDestIcon.Name = "lblDestIcon";
            this.lblDestIcon.Size = new System.Drawing.Size(34, 28);
            this.lblDestIcon.TabIndex = 0;
            this.lblDestIcon.Text = "\U0001f3af";
            // 
            // lblDestinationPath
            // 
            this.lblDestinationPath.AutoEllipsis = true;
            this.lblDestinationPath.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestinationPath.Location = new System.Drawing.Point(52, 10);
            this.lblDestinationPath.Name = "lblDestinationPath";
            this.lblDestinationPath.Size = new System.Drawing.Size(640, 28);
            this.lblDestinationPath.TabIndex = 1;
            this.lblDestinationPath.Text = "Destination: Not configured";
            // 
            // lblDriveSpace
            // 
            this.lblDriveSpace.AutoSize = true;
            this.lblDriveSpace.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblDriveSpace.ForeColor = System.Drawing.Color.Gray;
            this.lblDriveSpace.Location = new System.Drawing.Point(700, 14);
            this.lblDriveSpace.Name = "lblDriveSpace";
            this.lblDriveSpace.Size = new System.Drawing.Size(81, 20);
            this.lblDriveSpace.TabIndex = 2;
            this.lblDriveSpace.Text = "Drive: —";
            // 
            // panelChartRow
            // 
            this.panelChartRow.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.panelChartRow.ColumnCount = 2;
            this.panelChartRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelChartRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelChartRow.Controls.Add(this.chartFilesByType, 0, 0);
            this.panelChartRow.Controls.Add(this.chartOpsLast7Days, 1, 0);
            this.panelChartRow.Location = new System.Drawing.Point(18, 168);
            this.panelChartRow.Name = "panelChartRow";
            this.panelChartRow.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.panelChartRow.RowCount = 1;
            this.panelChartRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelChartRow.Size = new System.Drawing.Size(924, 340);
            this.panelChartRow.TabIndex = 2;
            // 
            // chartFilesByType
            // 
            this.chartFilesByType.BackColor = System.Drawing.Color.White;
            this.chartFilesByType.BorderlineColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.chartFilesByType.BorderlineWidth = 1;
            chartArea1.Name = "Default";
            chartArea1.BackColor = System.Drawing.Color.White;
            this.chartFilesByType.ChartAreas.Add(chartArea1);
            this.chartFilesByType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartFilesByType.Location = new System.Drawing.Point(3, 3);
            this.chartFilesByType.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
            this.chartFilesByType.Name = "chartFilesByType";
            series1.ChartArea = "Default";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Name = "FilesByType";
            this.chartFilesByType.Series.Add(series1);
            this.chartFilesByType.Size = new System.Drawing.Size(453, 332);
            this.chartFilesByType.TabIndex = 0;
            this.chartFilesByType.Text = "Files by Type";
            // 
            // chartOpsLast7Days
            // 
            this.chartOpsLast7Days.BackColor = System.Drawing.Color.White;
            this.chartOpsLast7Days.BorderlineColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.chartOpsLast7Days.BorderlineWidth = 1;
            chartArea2.Name = "Default";
            chartArea2.BackColor = System.Drawing.Color.White;
            this.chartOpsLast7Days.ChartAreas.Add(chartArea2);
            this.chartOpsLast7Days.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartOpsLast7Days.Location = new System.Drawing.Point(465, 3);
            this.chartOpsLast7Days.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.chartOpsLast7Days.Name = "chartOpsLast7Days";
            series2.ChartArea = "Default";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            series2.Name = "Operations";
            this.chartOpsLast7Days.Series.Add(series2);
            this.chartOpsLast7Days.Size = new System.Drawing.Size(453, 332);
            this.chartOpsLast7Days.TabIndex = 1;
            this.chartOpsLast7Days.Text = "Operations (7 days)";
            // 
            // panelActions
            // 
            this.panelActions.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.panelActions.Controls.Add(this.btnNavImport);
            this.panelActions.Controls.Add(this.btnNavRules);
            this.panelActions.Controls.Add(this.btnNavDuplicates);
            this.panelActions.Location = new System.Drawing.Point(18, 516);
            this.panelActions.Name = "panelActions";
            this.panelActions.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panelActions.Size = new System.Drawing.Size(924, 52);
            this.panelActions.TabIndex = 3;
            // 
            // btnNavImport
            // 
            this.btnNavImport.BackColor = System.Drawing.Color.FromArgb(55, 55, 55);
            this.btnNavImport.FlatAppearance.BorderSize = 0;
            this.btnNavImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavImport.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.btnNavImport.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnNavImport.Location = new System.Drawing.Point(8, 8);
            this.btnNavImport.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnNavImport.Name = "btnNavImport";
            this.btnNavImport.Size = new System.Drawing.Size(180, 35);
            this.btnNavImport.TabIndex = 0;
            this.btnNavImport.Text = "\U0001f4e5 Import Files";
            this.btnNavImport.UseVisualStyleBackColor = false;
            this.btnNavImport.Click += new System.EventHandler(this.btnNavImport_Click);
            // 
            // btnNavRules
            // 
            this.btnNavRules.BackColor = System.Drawing.Color.FromArgb(55, 55, 55);
            this.btnNavRules.FlatAppearance.BorderSize = 0;
            this.btnNavRules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavRules.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.btnNavRules.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnNavRules.Location = new System.Drawing.Point(196, 8);
            this.btnNavRules.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnNavRules.Name = "btnNavRules";
            this.btnNavRules.Size = new System.Drawing.Size(180, 35);
            this.btnNavRules.TabIndex = 1;
            this.btnNavRules.Text = "\u2699\ufe0f Configure Rules";
            this.btnNavRules.UseVisualStyleBackColor = false;
            this.btnNavRules.Click += new System.EventHandler(this.btnNavRules_Click);
            // 
            // btnNavDuplicates
            // 
            this.btnNavDuplicates.BackColor = System.Drawing.Color.FromArgb(55, 55, 55);
            this.btnNavDuplicates.FlatAppearance.BorderSize = 0;
            this.btnNavDuplicates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavDuplicates.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.btnNavDuplicates.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnNavDuplicates.Location = new System.Drawing.Point(384, 8);
            this.btnNavDuplicates.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnNavDuplicates.Name = "btnNavDuplicates";
            this.btnNavDuplicates.Size = new System.Drawing.Size(180, 35);
            this.btnNavDuplicates.TabIndex = 2;
            this.btnNavDuplicates.Text = "\U0001f50d Find Duplicates";
            this.btnNavDuplicates.UseVisualStyleBackColor = false;
            this.btnNavDuplicates.Click += new System.EventHandler(this.btnNavDuplicates_Click);
            // 
            // panelMainContainer
            // 
            this.panelMainContainer.AutoScroll = true;
            this.panelMainContainer.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.panelMainContainer.Controls.Add(this.panelActions);
            this.panelMainContainer.Controls.Add(this.panelChartRow);
            this.panelMainContainer.Controls.Add(this.panelDestination);
            this.panelMainContainer.Controls.Add(this.cardWaste);
            this.panelMainContainer.Controls.Add(this.cardDups);
            this.panelMainContainer.Controls.Add(this.cardRules);
            this.panelMainContainer.Controls.Add(this.cardOrganized);
            this.panelMainContainer.Controls.Add(this.cardTotalFiles);
            this.panelMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainContainer.Location = new System.Drawing.Point(0, 0);
            this.panelMainContainer.Name = "panelMainContainer";
            this.panelMainContainer.Size = new System.Drawing.Size(960, 582);
            this.panelMainContainer.TabIndex = 4;
            // 
            // FormDashboardAnalytics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.ClientSize = new System.Drawing.Size(960, 630);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelMainContainer);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormDashboardAnalytics";
            this.Text = "Dashboard Analytics";
            this.Load += new System.EventHandler(this.FormDashboardAnalytics_Load);
            this.cardTotalFiles.ResumeLayout(false);
            this.cardTotalFiles.PerformLayout();
            this.cardOrganized.ResumeLayout(false);
            this.cardOrganized.PerformLayout();
            this.cardRules.ResumeLayout(false);
            this.cardRules.PerformLayout();
            this.cardDups.ResumeLayout(false);
            this.cardDups.PerformLayout();
            this.cardWaste.ResumeLayout(false);
            this.cardWaste.PerformLayout();
            this.panelDestination.ResumeLayout(false);
            this.panelDestination.PerformLayout();
            this.panelChartRow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartFilesByType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartOpsLast7Days)).EndInit();
            this.panelActions.ResumeLayout(false);
            this.panelMainContainer.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.FlowLayoutPanel panelSummaryRow;
        private System.Windows.Forms.Panel cardTotalFiles;
        private System.Windows.Forms.Label lblTotalFilesIcon;
        private System.Windows.Forms.Label lblTotalFilesValue;
        private System.Windows.Forms.Label lblTotalFilesLabel;
        private System.Windows.Forms.Panel cardOrganized;
        private System.Windows.Forms.Label lblOrganizedIcon;
        private System.Windows.Forms.Label lblOrganizedValue;
        private System.Windows.Forms.Label lblOrganizedLabel;
        private System.Windows.Forms.Panel cardRules;
        private System.Windows.Forms.Label lblRulesIcon;
        private System.Windows.Forms.Label lblRulesValue;
        private System.Windows.Forms.Label lblRulesLabel;
        private System.Windows.Forms.Panel cardDups;
        private System.Windows.Forms.Label lblDupsIcon;
        private System.Windows.Forms.Label lblDupsValue;
        private System.Windows.Forms.Label lblDupsLabel;
        private System.Windows.Forms.Panel cardWaste;
        private System.Windows.Forms.Label lblWasteIcon;
        private System.Windows.Forms.Label lblWasteValue;
        private System.Windows.Forms.Label lblWasteLabel;
        private System.Windows.Forms.Panel panelDestination;
        private System.Windows.Forms.Label lblDestIcon;
        private System.Windows.Forms.Label lblDestinationPath;
        private System.Windows.Forms.Label lblDriveSpace;
        private System.Windows.Forms.TableLayoutPanel panelChartRow;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartFilesByType;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartOpsLast7Days;
        private System.Windows.Forms.FlowLayoutPanel panelActions;
        private System.Windows.Forms.Button btnNavImport;
        private System.Windows.Forms.Button btnNavRules;
        private System.Windows.Forms.Button btnNavDuplicates;
        private System.Windows.Forms.Panel panelMainContainer;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblProgressStatus;
    }
}
