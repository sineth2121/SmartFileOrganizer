namespace SmartFileOrganizer
{
    partial class FormConfigureRules
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
            this.panelInfoBanner = new System.Windows.Forms.Panel();
            this.lblFallbackNotifier = new System.Windows.Forms.Label();
            this.panelBatchProcessors = new System.Windows.Forms.Panel();
            this.lblBatchTitle = new System.Windows.Forms.Label();
            this.btnBatchType = new System.Windows.Forms.Button();
            this.btnBatchAge = new System.Windows.Forms.Button();
            this.btnBatchAlphabet = new System.Windows.Forms.Button();
            this.btnBatchSize = new System.Windows.Forms.Button();
            this.btnBatchDate = new System.Windows.Forms.Button();
            this.lblBatchStatus = new System.Windows.Forms.Label();
            this.chkUseSize = new System.Windows.Forms.CheckBox();
            this.nudSizeMin = new System.Windows.Forms.NumericUpDown();
            this.lblSizeTo = new System.Windows.Forms.Label();
            this.nudSizeMax = new System.Windows.Forms.NumericUpDown();
            this.panelCreateRule = new System.Windows.Forms.Panel();
            this.btnSaveRule = new System.Windows.Forms.Button();
            this.btnBrowseRuleDest = new System.Windows.Forms.Button();
            this.txtRuleDestination = new System.Windows.Forms.TextBox();
            this.lblDest = new System.Windows.Forms.Label();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.chkUseKeyword = new System.Windows.Forms.CheckBox();
            this.cmbAgeGroup = new System.Windows.Forms.ComboBox();
            this.chkUseAge = new System.Windows.Forms.CheckBox();
            this.cmbExtCategory = new System.Windows.Forms.ComboBox();
            this.chkUseExt = new System.Windows.Forms.CheckBox();
            this.txtRuleName = new System.Windows.Forms.TextBox();
            this.lblRuleName = new System.Windows.Forms.Label();
            this.lblCreateRuleTitle = new System.Windows.Forms.Label();
            this.panelActiveRules = new System.Windows.Forms.Panel();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.btnDeleteRule = new System.Windows.Forms.Button();
            this.listViewRules = new System.Windows.Forms.ListView();
            this.colId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRuleName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colConditions = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTarget = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSource = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblActiveRulesTitle = new System.Windows.Forms.Label();
            this.panelInfoBanner.SuspendLayout();
            this.panelBatchProcessors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSizeMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSizeMax)).BeginInit();
            this.panelCreateRule.SuspendLayout();
            this.panelActiveRules.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelInfoBanner
            // 
            this.panelInfoBanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.panelInfoBanner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInfoBanner.Controls.Add(this.lblFallbackNotifier);
            this.panelInfoBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfoBanner.Location = new System.Drawing.Point(0, 0);
            this.panelInfoBanner.Name = "panelInfoBanner";
            this.panelInfoBanner.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.panelInfoBanner.Size = new System.Drawing.Size(960, 52);
            this.panelInfoBanner.TabIndex = 0;
            // 
            // lblFallbackNotifier
            // 
            this.lblFallbackNotifier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFallbackNotifier.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblFallbackNotifier.Location = new System.Drawing.Point(12, 8);
            this.lblFallbackNotifier.Name = "lblFallbackNotifier";
            this.lblFallbackNotifier.Size = new System.Drawing.Size(934, 34);
            this.lblFallbackNotifier.TabIndex = 0;
            this.lblFallbackNotifier.Text = "info Unmatched files are safely sent to: [Base Destination Path]\\Unorganized_Item" +
    "s (This path is updated dynamically at runtime).";
            this.lblFallbackNotifier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFallbackNotifier.UseMnemonic = false;
            // 
            // panelBatchProcessors
            // 
            this.panelBatchProcessors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBatchProcessors.BackColor = System.Drawing.Color.White;
            this.panelBatchProcessors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBatchProcessors.Controls.Add(this.lblBatchTitle);
            this.panelBatchProcessors.Controls.Add(this.btnBatchType);
            this.panelBatchProcessors.Controls.Add(this.btnBatchAge);
            this.panelBatchProcessors.Controls.Add(this.btnBatchAlphabet);
            this.panelBatchProcessors.Controls.Add(this.btnBatchSize);
            this.panelBatchProcessors.Controls.Add(this.btnBatchDate);
            this.panelBatchProcessors.Controls.Add(this.lblBatchStatus);
            this.panelBatchProcessors.Location = new System.Drawing.Point(12, 60);
            this.panelBatchProcessors.Name = "panelBatchProcessors";
            this.panelBatchProcessors.Size = new System.Drawing.Size(936, 155);
            this.panelBatchProcessors.TabIndex = 1;
            // 
            // lblBatchTitle
            // 
            this.lblBatchTitle.AutoSize = true;
            this.lblBatchTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBatchTitle.Location = new System.Drawing.Point(12, 10);
            this.lblBatchTitle.Name = "lblBatchTitle";
            this.lblBatchTitle.Size = new System.Drawing.Size(352, 23);
            this.lblBatchTitle.TabIndex = 0;
            this.lblBatchTitle.Text = "Quick Batch Processors (1-Click Templates)";
            // 
            // btnBatchType
            // 
            this.btnBatchType.BackColor = System.Drawing.Color.White;
            this.btnBatchType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatchType.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnBatchType.Location = new System.Drawing.Point(16, 36);
            this.btnBatchType.Name = "btnBatchType";
            this.btnBatchType.Size = new System.Drawing.Size(290, 40);
            this.btnBatchType.TabIndex = 1;
            this.btnBatchType.Text = "Sort by File Type";
            this.btnBatchType.UseVisualStyleBackColor = false;
            this.btnBatchType.Click += new System.EventHandler(this.btnBatchType_Click);
            // 
            // btnBatchAge
            // 
            this.btnBatchAge.BackColor = System.Drawing.Color.White;
            this.btnBatchAge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatchAge.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnBatchAge.Location = new System.Drawing.Point(322, 36);
            this.btnBatchAge.Name = "btnBatchAge";
            this.btnBatchAge.Size = new System.Drawing.Size(290, 40);
            this.btnBatchAge.TabIndex = 2;
            this.btnBatchAge.Text = "Sort by File Age";
            this.btnBatchAge.UseVisualStyleBackColor = false;
            this.btnBatchAge.Click += new System.EventHandler(this.btnBatchAge_Click);
            // 
            // btnBatchAlphabet
            // 
            this.btnBatchAlphabet.BackColor = System.Drawing.Color.White;
            this.btnBatchAlphabet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatchAlphabet.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnBatchAlphabet.Location = new System.Drawing.Point(628, 36);
            this.btnBatchAlphabet.Name = "btnBatchAlphabet";
            this.btnBatchAlphabet.Size = new System.Drawing.Size(290, 40);
            this.btnBatchAlphabet.TabIndex = 3;
            this.btnBatchAlphabet.Text = "Sort by Alphabetical Range";
            this.btnBatchAlphabet.UseVisualStyleBackColor = false;
            this.btnBatchAlphabet.Click += new System.EventHandler(this.btnBatchAlphabet_Click);
            // 
            // btnBatchSize
            // 
            this.btnBatchSize.BackColor = System.Drawing.Color.White;
            this.btnBatchSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatchSize.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnBatchSize.Location = new System.Drawing.Point(16, 82);
            this.btnBatchSize.Name = "btnBatchSize";
            this.btnBatchSize.Size = new System.Drawing.Size(290, 40);
            this.btnBatchSize.TabIndex = 5;
            this.btnBatchSize.Text = "📦 Sort by File Size";
            this.btnBatchSize.UseVisualStyleBackColor = false;
            this.btnBatchSize.Click += new System.EventHandler(this.btnBatchSize_Click);
            // 
            // btnBatchDate
            // 
            this.btnBatchDate.BackColor = System.Drawing.Color.White;
            this.btnBatchDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatchDate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnBatchDate.Location = new System.Drawing.Point(322, 82);
            this.btnBatchDate.Name = "btnBatchDate";
            this.btnBatchDate.Size = new System.Drawing.Size(290, 40);
            this.btnBatchDate.TabIndex = 6;
            this.btnBatchDate.Text = "📅 Sort by Date Modified";
            this.btnBatchDate.UseVisualStyleBackColor = false;
            this.btnBatchDate.Click += new System.EventHandler(this.btnBatchDate_Click);
            // 
            // lblBatchStatus
            // 
            this.lblBatchStatus.AutoSize = true;
            this.lblBatchStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblBatchStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblBatchStatus.Location = new System.Drawing.Point(16, 128);
            this.lblBatchStatus.Name = "lblBatchStatus";
            this.lblBatchStatus.Size = new System.Drawing.Size(330, 20);
            this.lblBatchStatus.TabIndex = 4;
            this.lblBatchStatus.Text = "Batch rules created. Execute via Preview/Organize.";
            this.lblBatchStatus.Visible = false;
            // 
            // chkUseSize
            // 
            this.chkUseSize.AutoSize = true;
            this.chkUseSize.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkUseSize.Location = new System.Drawing.Point(19, 220);
            this.chkUseSize.Name = "chkUseSize";
            this.chkUseSize.Size = new System.Drawing.Size(128, 25);
            this.chkUseSize.TabIndex = 13;
            this.chkUseSize.Text = "File Size (MB):";
            this.chkUseSize.UseVisualStyleBackColor = true;
            this.chkUseSize.CheckedChanged += new System.EventHandler(this.chkUseSize_CheckedChanged);
            // 
            // nudSizeMin
            // 
            this.nudSizeMin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudSizeMin.Location = new System.Drawing.Point(177, 219);
            this.nudSizeMin.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudSizeMin.Name = "nudSizeMin";
            this.nudSizeMin.Size = new System.Drawing.Size(65, 27);
            this.nudSizeMin.TabIndex = 14;
            // 
            // lblSizeTo
            // 
            this.lblSizeTo.AutoSize = true;
            this.lblSizeTo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSizeTo.Location = new System.Drawing.Point(246, 220);
            this.lblSizeTo.Name = "lblSizeTo";
            this.lblSizeTo.Size = new System.Drawing.Size(24, 21);
            this.lblSizeTo.TabIndex = 15;
            this.lblSizeTo.Text = "to";
            // 
            // nudSizeMax
            // 
            this.nudSizeMax.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudSizeMax.Location = new System.Drawing.Point(278, 219);
            this.nudSizeMax.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudSizeMax.Name = "nudSizeMax";
            this.nudSizeMax.Size = new System.Drawing.Size(65, 27);
            this.nudSizeMax.TabIndex = 16;
            // 
            // panelCreateRule
            // 
            this.panelCreateRule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelCreateRule.BackColor = System.Drawing.Color.White;
            this.panelCreateRule.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCreateRule.Controls.Add(this.btnSaveRule);
            this.panelCreateRule.Controls.Add(this.btnBrowseRuleDest);
            this.panelCreateRule.Controls.Add(this.txtRuleDestination);
            this.panelCreateRule.Controls.Add(this.lblDest);
            this.panelCreateRule.Controls.Add(this.nudSizeMax);
            this.panelCreateRule.Controls.Add(this.lblSizeTo);
            this.panelCreateRule.Controls.Add(this.nudSizeMin);
            this.panelCreateRule.Controls.Add(this.chkUseSize);
            this.panelCreateRule.Controls.Add(this.txtKeyword);
            this.panelCreateRule.Controls.Add(this.chkUseKeyword);
            this.panelCreateRule.Controls.Add(this.cmbAgeGroup);
            this.panelCreateRule.Controls.Add(this.chkUseAge);
            this.panelCreateRule.Controls.Add(this.cmbExtCategory);
            this.panelCreateRule.Controls.Add(this.chkUseExt);
            this.panelCreateRule.Controls.Add(this.txtRuleName);
            this.panelCreateRule.Controls.Add(this.lblRuleName);
            this.panelCreateRule.Controls.Add(this.lblCreateRuleTitle);
            this.panelCreateRule.Location = new System.Drawing.Point(12, 221);
            this.panelCreateRule.Name = "panelCreateRule";
            this.panelCreateRule.Size = new System.Drawing.Size(418, 454);
            this.panelCreateRule.TabIndex = 2;
            // 
            // btnSaveRule
            // 
            this.btnSaveRule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnSaveRule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveRule.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaveRule.ForeColor = System.Drawing.Color.White;
            this.btnSaveRule.Location = new System.Drawing.Point(19, 321);
            this.btnSaveRule.Name = "btnSaveRule";
            this.btnSaveRule.Size = new System.Drawing.Size(345, 39);
            this.btnSaveRule.TabIndex = 12;
            this.btnSaveRule.Text = "Save Rule";
            this.btnSaveRule.UseVisualStyleBackColor = false;
            this.btnSaveRule.Click += new System.EventHandler(this.btnSaveRule_Click);
            // 
            // btnBrowseRuleDest
            // 
            this.btnBrowseRuleDest.BackColor = System.Drawing.Color.White;
            this.btnBrowseRuleDest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseRuleDest.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnBrowseRuleDest.Location = new System.Drawing.Point(268, 276);
            this.btnBrowseRuleDest.Name = "btnBrowseRuleDest";
            this.btnBrowseRuleDest.Size = new System.Drawing.Size(96, 30);
            this.btnBrowseRuleDest.TabIndex = 11;
            this.btnBrowseRuleDest.Text = "Browse";
            this.btnBrowseRuleDest.UseVisualStyleBackColor = false;
            this.btnBrowseRuleDest.Click += new System.EventHandler(this.btnBrowseRuleDest_Click);
            // 
            // txtRuleDestination
            // 
            this.txtRuleDestination.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRuleDestination.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRuleDestination.Location = new System.Drawing.Point(19, 279);
            this.txtRuleDestination.Name = "txtRuleDestination";
            this.txtRuleDestination.ReadOnly = true;
            this.txtRuleDestination.Size = new System.Drawing.Size(243, 27);
            this.txtRuleDestination.TabIndex = 10;
            // 
            // lblDest
            // 
            this.lblDest.AutoSize = true;
            this.lblDest.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDest.Location = new System.Drawing.Point(15, 255);
            this.lblDest.Name = "lblDest";
            this.lblDest.Size = new System.Drawing.Size(210, 21);
            this.lblDest.TabIndex = 9;
            this.lblDest.Text = "Target Subfolder Destination:";
            // 
            // txtKeyword
            // 
            this.txtKeyword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKeyword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtKeyword.Location = new System.Drawing.Point(177, 181);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(187, 27);
            this.txtKeyword.TabIndex = 8;
            // 
            // chkUseKeyword
            // 
            this.chkUseKeyword.AutoSize = true;
            this.chkUseKeyword.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkUseKeyword.Location = new System.Drawing.Point(19, 181);
            this.chkUseKeyword.Name = "chkUseKeyword";
            this.chkUseKeyword.Size = new System.Drawing.Size(96, 25);
            this.chkUseKeyword.TabIndex = 7;
            this.chkUseKeyword.Text = "Keyword:";
            this.chkUseKeyword.UseVisualStyleBackColor = true;
            this.chkUseKeyword.CheckedChanged += new System.EventHandler(this.chkUseKeyword_CheckedChanged);
            // 
            // cmbAgeGroup
            // 
            this.cmbAgeGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAgeGroup.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbAgeGroup.Items.AddRange(new object[] {
            "Today (< 1 Day)",
            "This Week (< 7 Days)",
            "This Month (< 30 Days)",
            "Last Month (30–60 Days)",
            "Recent (60–180 Days)",
            "Archive (>= 180 Days)"});
            this.cmbAgeGroup.Location = new System.Drawing.Point(177, 146);
            this.cmbAgeGroup.Name = "cmbAgeGroup";
            this.cmbAgeGroup.Size = new System.Drawing.Size(187, 28);
            this.cmbAgeGroup.TabIndex = 6;
            // 
            // chkUseAge
            // 
            this.chkUseAge.AutoSize = true;
            this.chkUseAge.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkUseAge.Location = new System.Drawing.Point(19, 146);
            this.chkUseAge.Name = "chkUseAge";
            this.chkUseAge.Size = new System.Drawing.Size(90, 25);
            this.chkUseAge.TabIndex = 5;
            this.chkUseAge.Text = "File Age:";
            this.chkUseAge.UseVisualStyleBackColor = true;
            this.chkUseAge.CheckedChanged += new System.EventHandler(this.chkUseAge_CheckedChanged);
            // 
            // cmbExtCategory
            // 
            this.cmbExtCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExtCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbExtCategory.Items.AddRange(new object[] {
            "Documents (.pdf,.docx,.txt,.doc,.xls,.xlsx,.ppt,.pptx,.odt,.ods,.odp,.rtf,.csv,.x" +
                "ml,.json,.md,.html)",
            "Images (.png,.jpg,.jpeg,.gif,.bmp,.tiff,.tif,.webp,.svg,.ico,.heic,.raw)",
            "Videos (.mp4,.mkv,.avi,.mov,.wmv,.flv,.webm,.m4v,.3gp,.mpeg,.mpg)",
            "Audio (.mp3,.wav,.flac,.aac,.ogg,.wma,.m4a)",
            "Archives (.zip,.rar,.7z,.tar,.gz,.bz2,.xz,.iso)",
            "Code/Scripts (.cs,.py,.js,.ts,.css,.yaml,.yml,.sh,.bat,.ps1,.cpp,.h,.java,.go,.rb" +
                ",.php)",
            "Fonts (.ttf,.otf,.woff,.woff2,.eot)",
            "Executables (.exe,.msi,.dll)"});
            this.cmbExtCategory.Location = new System.Drawing.Point(177, 111);
            this.cmbExtCategory.Name = "cmbExtCategory";
            this.cmbExtCategory.Size = new System.Drawing.Size(187, 28);
            this.cmbExtCategory.TabIndex = 4;
            // 
            // chkUseExt
            // 
            this.chkUseExt.AutoSize = true;
            this.chkUseExt.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkUseExt.Location = new System.Drawing.Point(19, 111);
            this.chkUseExt.Name = "chkUseExt";
            this.chkUseExt.Size = new System.Drawing.Size(137, 25);
            this.chkUseExt.TabIndex = 3;
            this.chkUseExt.Text = "Extension Type:";
            this.chkUseExt.UseVisualStyleBackColor = true;
            this.chkUseExt.CheckedChanged += new System.EventHandler(this.chkUseExt_CheckedChanged);
            // 
            // txtRuleName
            // 
            this.txtRuleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRuleName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRuleName.Location = new System.Drawing.Point(19, 71);
            this.txtRuleName.Name = "txtRuleName";
            this.txtRuleName.Size = new System.Drawing.Size(345, 27);
            this.txtRuleName.TabIndex = 2;
            this.txtRuleName.TextChanged += new System.EventHandler(this.txtRuleName_TextChanged);
            // 
            // lblRuleName
            // 
            this.lblRuleName.AutoSize = true;
            this.lblRuleName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblRuleName.Location = new System.Drawing.Point(15, 47);
            this.lblRuleName.Name = "lblRuleName";
            this.lblRuleName.Size = new System.Drawing.Size(90, 21);
            this.lblRuleName.TabIndex = 1;
            this.lblRuleName.Text = "Rule Name:";
            // 
            // lblCreateRuleTitle
            // 
            this.lblCreateRuleTitle.AutoSize = true;
            this.lblCreateRuleTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCreateRuleTitle.Location = new System.Drawing.Point(12, 12);
            this.lblCreateRuleTitle.Name = "lblCreateRuleTitle";
            this.lblCreateRuleTitle.Size = new System.Drawing.Size(286, 25);
            this.lblCreateRuleTitle.TabIndex = 0;
            this.lblCreateRuleTitle.Text = "Advanced Custom Rule Builder";
            // 
            // panelActiveRules
            // 
            this.panelActiveRules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelActiveRules.BackColor = System.Drawing.Color.White;
            this.panelActiveRules.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelActiveRules.Controls.Add(this.btnDeleteAll);
            this.panelActiveRules.Controls.Add(this.btnDeleteRule);
            this.panelActiveRules.Controls.Add(this.listViewRules);
            this.panelActiveRules.Controls.Add(this.lblActiveRulesTitle);
            this.panelActiveRules.Location = new System.Drawing.Point(436, 221);
            this.panelActiveRules.Name = "panelActiveRules";
            this.panelActiveRules.Size = new System.Drawing.Size(512, 454);
            this.panelActiveRules.TabIndex = 3;
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteAll.BackColor = System.Drawing.Color.White;
            this.btnDeleteAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteAll.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnDeleteAll.Location = new System.Drawing.Point(343, 362);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(145, 39);
            this.btnDeleteAll.TabIndex = 3;
            this.btnDeleteAll.Text = "Delete All Rules";
            this.btnDeleteAll.UseVisualStyleBackColor = false;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // btnDeleteRule
            // 
            this.btnDeleteRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteRule.BackColor = System.Drawing.Color.White;
            this.btnDeleteRule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteRule.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnDeleteRule.Location = new System.Drawing.Point(198, 362);
            this.btnDeleteRule.Name = "btnDeleteRule";
            this.btnDeleteRule.Size = new System.Drawing.Size(145, 39);
            this.btnDeleteRule.TabIndex = 2;
            this.btnDeleteRule.Text = "Delete Selected";
            this.btnDeleteRule.UseVisualStyleBackColor = false;
            this.btnDeleteRule.Click += new System.EventHandler(this.btnDeleteRule_Click);
            // 
            // listViewRules
            // 
            this.listViewRules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewRules.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colId,
            this.colRuleName,
            this.colConditions,
            this.colTarget,
            this.colSource});
            this.listViewRules.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.listViewRules.FullRowSelect = true;
            this.listViewRules.GridLines = true;
            this.listViewRules.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewRules.HideSelection = false;
            this.listViewRules.Location = new System.Drawing.Point(16, 48);
            this.listViewRules.MultiSelect = false;
            this.listViewRules.Name = "listViewRules";
            this.listViewRules.Size = new System.Drawing.Size(478, 308);
            this.listViewRules.TabIndex = 1;
            this.listViewRules.UseCompatibleStateImageBehavior = false;
            this.listViewRules.View = System.Windows.Forms.View.Details;
            // 
            // colId
            // 
            this.colId.Text = "ID";
            this.colId.Width = 40;
            // 
            // colRuleName
            // 
            this.colRuleName.Text = "Rule Name";
            this.colRuleName.Width = 120;
            // 
            // colConditions
            // 
            this.colConditions.Text = "Active Conditions";
            this.colConditions.Width = 160;
            // 
            // colTarget
            // 
            this.colTarget.Text = "Target Destination";
            this.colTarget.Width = 180;
            // 
            // colSource
            // 
            this.colSource.Text = "Source";
            this.colSource.Width = 80;
            // 
            // lblActiveRulesTitle
            // 
            this.lblActiveRulesTitle.AutoSize = true;
            this.lblActiveRulesTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblActiveRulesTitle.Location = new System.Drawing.Point(12, 12);
            this.lblActiveRulesTitle.Name = "lblActiveRulesTitle";
            this.lblActiveRulesTitle.Size = new System.Drawing.Size(230, 25);
            this.lblActiveRulesTitle.TabIndex = 0;
            this.lblActiveRulesTitle.Text = "Active Automation Rules";
            // 
            // FormConfigureRules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(960, 647);
            this.Controls.Add(this.panelActiveRules);
            this.Controls.Add(this.panelCreateRule);
            this.Controls.Add(this.panelBatchProcessors);
            this.Controls.Add(this.panelInfoBanner);
            this.MinimumSize = new System.Drawing.Size(960, 540);
            this.Name = "FormConfigureRules";
            this.Text = "Configure Rules";
            this.Load += new System.EventHandler(this.FormConfigureRules_Load);
            this.panelInfoBanner.ResumeLayout(false);
            this.panelBatchProcessors.ResumeLayout(false);
            this.panelBatchProcessors.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSizeMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSizeMax)).EndInit();
            this.panelCreateRule.ResumeLayout(false);
            this.panelCreateRule.PerformLayout();
            this.panelActiveRules.ResumeLayout(false);
            this.panelActiveRules.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelInfoBanner;
        private System.Windows.Forms.Label lblFallbackNotifier;
        private System.Windows.Forms.Panel panelBatchProcessors;
        private System.Windows.Forms.Label lblBatchTitle;
        private System.Windows.Forms.Button btnBatchType;
        private System.Windows.Forms.Button btnBatchAge;
        private System.Windows.Forms.Button btnBatchAlphabet;
        private System.Windows.Forms.Panel panelCreateRule;
        private System.Windows.Forms.Label lblCreateRuleTitle;
        private System.Windows.Forms.Label lblRuleName;
        private System.Windows.Forms.TextBox txtRuleName;
        private System.Windows.Forms.CheckBox chkUseExt;
        private System.Windows.Forms.ComboBox cmbExtCategory;
        private System.Windows.Forms.CheckBox chkUseAge;
        private System.Windows.Forms.ComboBox cmbAgeGroup;
        private System.Windows.Forms.CheckBox chkUseKeyword;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Label lblDest;
        private System.Windows.Forms.TextBox txtRuleDestination;
        private System.Windows.Forms.Button btnBrowseRuleDest;
        private System.Windows.Forms.Button btnSaveRule;
        private System.Windows.Forms.Panel panelActiveRules;
        private System.Windows.Forms.Label lblActiveRulesTitle;
        private System.Windows.Forms.ListView listViewRules;
        private System.Windows.Forms.ColumnHeader colId;
        private System.Windows.Forms.ColumnHeader colRuleName;
        private System.Windows.Forms.ColumnHeader colConditions;
        private System.Windows.Forms.ColumnHeader colTarget;
        private System.Windows.Forms.ColumnHeader colSource;
        private System.Windows.Forms.Button btnDeleteRule;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.Label lblBatchStatus;
        private System.Windows.Forms.Button btnBatchSize;
        private System.Windows.Forms.Button btnBatchDate;
        private System.Windows.Forms.CheckBox chkUseSize;
        private System.Windows.Forms.NumericUpDown nudSizeMin;
        private System.Windows.Forms.Label lblSizeTo;
        private System.Windows.Forms.NumericUpDown nudSizeMax;
    }
}
