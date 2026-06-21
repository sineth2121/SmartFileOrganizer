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
            this.grpDatabase = new System.Windows.Forms.GroupBox();
            this.btnCleanHistory = new System.Windows.Forms.Button();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.txtDbPassword = new System.Windows.Forms.TextBox();
            this.lblDbPass = new System.Windows.Forms.Label();
            this.txtDbUser = new System.Windows.Forms.TextBox();
            this.lblDbUser = new System.Windows.Forms.Label();
            this.txtDbName = new System.Windows.Forms.TextBox();
            this.lblDbName = new System.Windows.Forms.Label();
            this.nudDbPort = new System.Windows.Forms.NumericUpDown();
            this.lblDbPort = new System.Windows.Forms.Label();
            this.txtDbServer = new System.Windows.Forms.TextBox();
            this.lblDbServer = new System.Windows.Forms.Label();
            this.grpFileProcessing = new System.Windows.Forms.GroupBox();
            this.lblMaxFileSizeNote = new System.Windows.Forms.Label();
            this.nudMaxFileSize = new System.Windows.Forms.NumericUpDown();
            this.lblMaxFileSize = new System.Windows.Forms.Label();
            this.txtExcludedFolders = new System.Windows.Forms.TextBox();
            this.lblExcludedFolders = new System.Windows.Forms.Label();
            this.txtExcludedExtensions = new System.Windows.Forms.TextBox();
            this.lblExcludedExt = new System.Windows.Forms.Label();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.chkScanDups = new System.Windows.Forms.CheckBox();
            this.chkVerifyFiles = new System.Windows.Forms.CheckBox();
            this.chkConfirmActions = new System.Windows.Forms.CheckBox();
            this.cboDefaultOperation = new System.Windows.Forms.ComboBox();
            this.lblDefaultOp = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtDestinationPath = new System.Windows.Forms.TextBox();
            this.lblDestLabel = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.panelBanner.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.grpDatabase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDbPort)).BeginInit();
            this.grpFileProcessing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxFileSize)).BeginInit();
            this.grpGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBanner
            // 
            this.panelBanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
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
            this.panelContent.AutoScroll = true;
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.panelContent.Controls.Add(this.grpDatabase);
            this.panelContent.Controls.Add(this.grpFileProcessing);
            this.panelContent.Controls.Add(this.grpGeneral);
            this.panelContent.Controls.Add(this.btnSave);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 52);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(30, 20, 30, 30);
            this.panelContent.Size = new System.Drawing.Size(960, 568);
            this.panelContent.TabIndex = 1;
            // 
            // grpDatabase
            // 
            this.grpDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDatabase.BackColor = System.Drawing.Color.White;
            this.grpDatabase.Controls.Add(this.btnCleanHistory);
            this.grpDatabase.Controls.Add(this.btnTestConnection);
            this.grpDatabase.Controls.Add(this.txtDbPassword);
            this.grpDatabase.Controls.Add(this.lblDbPass);
            this.grpDatabase.Controls.Add(this.txtDbUser);
            this.grpDatabase.Controls.Add(this.lblDbUser);
            this.grpDatabase.Controls.Add(this.txtDbName);
            this.grpDatabase.Controls.Add(this.lblDbName);
            this.grpDatabase.Controls.Add(this.nudDbPort);
            this.grpDatabase.Controls.Add(this.lblDbPort);
            this.grpDatabase.Controls.Add(this.txtDbServer);
            this.grpDatabase.Controls.Add(this.lblDbServer);
            this.grpDatabase.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpDatabase.Location = new System.Drawing.Point(12, 340);
            this.grpDatabase.Name = "grpDatabase";
            this.grpDatabase.Size = new System.Drawing.Size(936, 162);
            this.grpDatabase.TabIndex = 6;
            this.grpDatabase.TabStop = false;
            this.grpDatabase.Text = " Database Connection ";
            // 
            // btnCleanHistory
            // 
            this.btnCleanHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnCleanHistory.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCleanHistory.Location = new System.Drawing.Point(180, 110);
            this.btnCleanHistory.Name = "btnCleanHistory";
            this.btnCleanHistory.Size = new System.Drawing.Size(170, 35);
            this.btnCleanHistory.TabIndex = 11;
            this.btnCleanHistory.Text = "Clean Up History";
            this.btnCleanHistory.UseVisualStyleBackColor = false;
            this.btnCleanHistory.Click += new System.EventHandler(this.btnCleanHistory_Click);
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnTestConnection.Location = new System.Drawing.Point(18, 110);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(150, 35);
            this.btnTestConnection.TabIndex = 10;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // txtDbPassword
            // 
            this.txtDbPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDbPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDbPassword.Location = new System.Drawing.Point(383, 64);
            this.txtDbPassword.Name = "txtDbPassword";
            this.txtDbPassword.Size = new System.Drawing.Size(216, 29);
            this.txtDbPassword.TabIndex = 9;
            this.txtDbPassword.UseSystemPasswordChar = true;
            // 
            // lblDbPass
            // 
            this.lblDbPass.AutoSize = true;
            this.lblDbPass.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDbPass.Location = new System.Drawing.Point(305, 67);
            this.lblDbPass.Name = "lblDbPass";
            this.lblDbPass.Size = new System.Drawing.Size(79, 21);
            this.lblDbPass.TabIndex = 8;
            this.lblDbPass.Text = "Password:";
            // 
            // txtDbUser
            // 
            this.txtDbUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDbUser.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDbUser.Location = new System.Drawing.Point(100, 64);
            this.txtDbUser.Name = "txtDbUser";
            this.txtDbUser.Size = new System.Drawing.Size(216, 29);
            this.txtDbUser.TabIndex = 7;
            this.txtDbUser.Text = "root";
            // 
            // lblDbUser
            // 
            this.lblDbUser.AutoSize = true;
            this.lblDbUser.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDbUser.Location = new System.Drawing.Point(15, 67);
            this.lblDbUser.Name = "lblDbUser";
            this.lblDbUser.Size = new System.Drawing.Size(84, 21);
            this.lblDbUser.TabIndex = 6;
            this.lblDbUser.Text = "Username:";
            // 
            // txtDbName
            // 
            this.txtDbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDbName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDbName.Location = new System.Drawing.Point(549, 24);
            this.txtDbName.Name = "txtDbName";
            this.txtDbName.Size = new System.Drawing.Size(256, 29);
            this.txtDbName.TabIndex = 5;
            this.txtDbName.Text = "smart_file_organizer";
            // 
            // lblDbName
            // 
            this.lblDbName.AutoSize = true;
            this.lblDbName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDbName.Location = new System.Drawing.Point(470, 27);
            this.lblDbName.Name = "lblDbName";
            this.lblDbName.Size = new System.Drawing.Size(77, 21);
            this.lblDbName.TabIndex = 4;
            this.lblDbName.Text = "Database:";
            // 
            // nudDbPort
            // 
            this.nudDbPort.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.nudDbPort.Location = new System.Drawing.Point(364, 25);
            this.nudDbPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudDbPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDbPort.Name = "nudDbPort";
            this.nudDbPort.Size = new System.Drawing.Size(80, 29);
            this.nudDbPort.TabIndex = 3;
            this.nudDbPort.Value = new decimal(new int[] {
            3306,
            0,
            0,
            0});
            this.nudDbPort.ValueChanged += new System.EventHandler(this.nudDbPort_ValueChanged);
            // 
            // lblDbPort
            // 
            this.lblDbPort.AutoSize = true;
            this.lblDbPort.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDbPort.Location = new System.Drawing.Point(320, 27);
            this.lblDbPort.Name = "lblDbPort";
            this.lblDbPort.Size = new System.Drawing.Size(41, 21);
            this.lblDbPort.TabIndex = 2;
            this.lblDbPort.Text = "Port:";
            // 
            // txtDbServer
            // 
            this.txtDbServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDbServer.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDbServer.Location = new System.Drawing.Point(74, 24);
            this.txtDbServer.Name = "txtDbServer";
            this.txtDbServer.Size = new System.Drawing.Size(256, 29);
            this.txtDbServer.TabIndex = 1;
            this.txtDbServer.Text = "localhost";
            // 
            // lblDbServer
            // 
            this.lblDbServer.AutoSize = true;
            this.lblDbServer.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDbServer.Location = new System.Drawing.Point(15, 27);
            this.lblDbServer.Name = "lblDbServer";
            this.lblDbServer.Size = new System.Drawing.Size(58, 21);
            this.lblDbServer.TabIndex = 0;
            this.lblDbServer.Text = "Server:";
            // 
            // grpFileProcessing
            // 
            this.grpFileProcessing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFileProcessing.BackColor = System.Drawing.Color.White;
            this.grpFileProcessing.Controls.Add(this.lblMaxFileSizeNote);
            this.grpFileProcessing.Controls.Add(this.nudMaxFileSize);
            this.grpFileProcessing.Controls.Add(this.lblMaxFileSize);
            this.grpFileProcessing.Controls.Add(this.txtExcludedFolders);
            this.grpFileProcessing.Controls.Add(this.lblExcludedFolders);
            this.grpFileProcessing.Controls.Add(this.txtExcludedExtensions);
            this.grpFileProcessing.Controls.Add(this.lblExcludedExt);
            this.grpFileProcessing.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpFileProcessing.Location = new System.Drawing.Point(12, 195);
            this.grpFileProcessing.Name = "grpFileProcessing";
            this.grpFileProcessing.Size = new System.Drawing.Size(935, 135);
            this.grpFileProcessing.TabIndex = 5;
            this.grpFileProcessing.TabStop = false;
            this.grpFileProcessing.Text = " File Processing ";
            // 
            // lblMaxFileSizeNote
            // 
            this.lblMaxFileSizeNote.AutoSize = true;
            this.lblMaxFileSizeNote.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblMaxFileSizeNote.ForeColor = System.Drawing.Color.Gray;
            this.lblMaxFileSizeNote.Location = new System.Drawing.Point(241, 90);
            this.lblMaxFileSizeNote.Name = "lblMaxFileSizeNote";
            this.lblMaxFileSizeNote.Size = new System.Drawing.Size(92, 19);
            this.lblMaxFileSizeNote.TabIndex = 6;
            this.lblMaxFileSizeNote.Text = "(0 = no limit)";
            // 
            // nudMaxFileSize
            // 
            this.nudMaxFileSize.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.nudMaxFileSize.Location = new System.Drawing.Point(135, 86);
            this.nudMaxFileSize.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudMaxFileSize.Name = "nudMaxFileSize";
            this.nudMaxFileSize.Size = new System.Drawing.Size(100, 29);
            this.nudMaxFileSize.TabIndex = 5;
            this.nudMaxFileSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudMaxFileSize.ValueChanged += new System.EventHandler(this.nudMaxFileSize_ValueChanged);
            // 
            // lblMaxFileSize
            // 
            this.lblMaxFileSize.AutoSize = true;
            this.lblMaxFileSize.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblMaxFileSize.Location = new System.Drawing.Point(15, 88);
            this.lblMaxFileSize.Name = "lblMaxFileSize";
            this.lblMaxFileSize.Size = new System.Drawing.Size(139, 21);
            this.lblMaxFileSize.TabIndex = 4;
            this.lblMaxFileSize.Text = "Max File Size (MB):";
            // 
            // txtExcludedFolders
            // 
            this.txtExcludedFolders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExcludedFolders.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtExcludedFolders.Location = new System.Drawing.Point(664, 50);
            this.txtExcludedFolders.Name = "txtExcludedFolders";
            this.txtExcludedFolders.Size = new System.Drawing.Size(255, 29);
            this.txtExcludedFolders.TabIndex = 3;
            this.txtExcludedFolders.Text = "System Volume Information,$Recycle.Bin,.git,.svn";
            // 
            // lblExcludedFolders
            // 
            this.lblExcludedFolders.AutoSize = true;
            this.lblExcludedFolders.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblExcludedFolders.Location = new System.Drawing.Point(660, 27);
            this.lblExcludedFolders.Name = "lblExcludedFolders";
            this.lblExcludedFolders.Size = new System.Drawing.Size(175, 21);
            this.lblExcludedFolders.TabIndex = 2;
            this.lblExcludedFolders.Text = "Excluded Folder Names:";
            // 
            // txtExcludedExtensions
            // 
            this.txtExcludedExtensions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExcludedExtensions.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtExcludedExtensions.Location = new System.Drawing.Point(18, 50);
            this.txtExcludedExtensions.Name = "txtExcludedExtensions";
            this.txtExcludedExtensions.Size = new System.Drawing.Size(665, 29);
            this.txtExcludedExtensions.TabIndex = 1;
            this.txtExcludedExtensions.Text = ".tmp,.log,.bak";
            // 
            // lblExcludedExt
            // 
            this.lblExcludedExt.AutoSize = true;
            this.lblExcludedExt.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblExcludedExt.Location = new System.Drawing.Point(15, 27);
            this.lblExcludedExt.Name = "lblExcludedExt";
            this.lblExcludedExt.Size = new System.Drawing.Size(179, 21);
            this.lblExcludedExt.TabIndex = 0;
            this.lblExcludedExt.Text = "Excluded File Extensions:";
            // 
            // grpGeneral
            // 
            this.grpGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpGeneral.BackColor = System.Drawing.Color.White;
            this.grpGeneral.Controls.Add(this.chkScanDups);
            this.grpGeneral.Controls.Add(this.chkVerifyFiles);
            this.grpGeneral.Controls.Add(this.chkConfirmActions);
            this.grpGeneral.Controls.Add(this.cboDefaultOperation);
            this.grpGeneral.Controls.Add(this.lblDefaultOp);
            this.grpGeneral.Controls.Add(this.btnBrowse);
            this.grpGeneral.Controls.Add(this.txtDestinationPath);
            this.grpGeneral.Controls.Add(this.lblDestLabel);
            this.grpGeneral.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpGeneral.Location = new System.Drawing.Point(12, 23);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(935, 162);
            this.grpGeneral.TabIndex = 4;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = " General ";
            // 
            // chkScanDups
            // 
            this.chkScanDups.AutoSize = true;
            this.chkScanDups.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkScanDups.Location = new System.Drawing.Point(320, 122);
            this.chkScanDups.Name = "chkScanDups";
            this.chkScanDups.Size = new System.Drawing.Size(238, 25);
            this.chkScanDups.TabIndex = 7;
            this.chkScanDups.Text = "Scan for duplicates on startup";
            this.chkScanDups.UseVisualStyleBackColor = true;
            // 
            // chkVerifyFiles
            // 
            this.chkVerifyFiles.AutoSize = true;
            this.chkVerifyFiles.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkVerifyFiles.Location = new System.Drawing.Point(18, 122);
            this.chkVerifyFiles.Name = "chkVerifyFiles";
            this.chkVerifyFiles.Size = new System.Drawing.Size(239, 25);
            this.chkVerifyFiles.TabIndex = 6;
            this.chkVerifyFiles.Text = "Verify file existence on startup";
            this.chkVerifyFiles.UseVisualStyleBackColor = true;
            // 
            // chkConfirmActions
            // 
            this.chkConfirmActions.AutoSize = true;
            this.chkConfirmActions.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkConfirmActions.Location = new System.Drawing.Point(400, 87);
            this.chkConfirmActions.Name = "chkConfirmActions";
            this.chkConfirmActions.Size = new System.Drawing.Size(237, 25);
            this.chkConfirmActions.TabIndex = 5;
            this.chkConfirmActions.Text = "Confirm before import/delete";
            this.chkConfirmActions.UseVisualStyleBackColor = true;
            // 
            // cboDefaultOperation
            // 
            this.cboDefaultOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDefaultOperation.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboDefaultOperation.Items.AddRange(new object[] {
            "Copy (keep originals)",
            "Cut (move files)"});
            this.cboDefaultOperation.Location = new System.Drawing.Point(149, 85);
            this.cboDefaultOperation.Name = "cboDefaultOperation";
            this.cboDefaultOperation.Size = new System.Drawing.Size(220, 29);
            this.cboDefaultOperation.TabIndex = 4;
            // 
            // lblDefaultOp
            // 
            this.lblDefaultOp.AutoSize = true;
            this.lblDefaultOp.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDefaultOp.Location = new System.Drawing.Point(15, 88);
            this.lblDefaultOp.Name = "lblDefaultOp";
            this.lblDefaultOp.Size = new System.Drawing.Size(137, 21);
            this.lblDefaultOp.TabIndex = 3;
            this.lblDefaultOp.Text = "Default Operation:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnBrowse.Location = new System.Drawing.Point(739, 48);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(100, 32);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Brouse";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtDestinationPath
            // 
            this.txtDestinationPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestinationPath.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDestinationPath.Location = new System.Drawing.Point(18, 50);
            this.txtDestinationPath.Name = "txtDestinationPath";
            this.txtDestinationPath.Size = new System.Drawing.Size(715, 29);
            this.txtDestinationPath.TabIndex = 1;
            // 
            // lblDestLabel
            // 
            this.lblDestLabel.AutoSize = true;
            this.lblDestLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDestLabel.Location = new System.Drawing.Point(15, 27);
            this.lblDestLabel.Name = "lblDestLabel";
            this.lblDestLabel.Size = new System.Drawing.Size(176, 21);
            this.lblDestLabel.TabIndex = 0;
            this.lblDestLabel.Text = "Base Destination Folder:";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(30, 512);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 42);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save Settings";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(960, 620);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelBanner);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "FormSettings";
            this.Text = "Settings";
            this.panelBanner.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.grpDatabase.ResumeLayout(false);
            this.grpDatabase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDbPort)).EndInit();
            this.grpFileProcessing.ResumeLayout(false);
            this.grpFileProcessing.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxFileSize)).EndInit();
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelBanner;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.Label lblDestLabel;
        private System.Windows.Forms.TextBox txtDestinationPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblDefaultOp;
        private System.Windows.Forms.ComboBox cboDefaultOperation;
        private System.Windows.Forms.CheckBox chkConfirmActions;
        private System.Windows.Forms.GroupBox grpFileProcessing;
        private System.Windows.Forms.Label lblExcludedExt;
        private System.Windows.Forms.TextBox txtExcludedExtensions;
        private System.Windows.Forms.Label lblExcludedFolders;
        private System.Windows.Forms.TextBox txtExcludedFolders;
        private System.Windows.Forms.Label lblMaxFileSize;
        private System.Windows.Forms.NumericUpDown nudMaxFileSize;
        private System.Windows.Forms.Label lblMaxFileSizeNote;
        private System.Windows.Forms.GroupBox grpDatabase;
        private System.Windows.Forms.Label lblDbServer;
        private System.Windows.Forms.TextBox txtDbServer;
        private System.Windows.Forms.Label lblDbPort;
        private System.Windows.Forms.NumericUpDown nudDbPort;
        private System.Windows.Forms.Label lblDbName;
        private System.Windows.Forms.TextBox txtDbName;
        private System.Windows.Forms.Label lblDbUser;
        private System.Windows.Forms.TextBox txtDbUser;
        private System.Windows.Forms.Label lblDbPass;
        private System.Windows.Forms.TextBox txtDbPassword;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Button btnCleanHistory;
        private System.Windows.Forms.CheckBox chkVerifyFiles;
        private System.Windows.Forms.CheckBox chkScanDups;
    }
}
