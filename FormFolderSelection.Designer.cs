namespace SmartFileOrganizer
{
    partial class FormFolderSelection
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
            this.panelCard = new System.Windows.Forms.Panel();
            this.destinationText = new System.Windows.Forms.TextBox();
            this.importText = new System.Windows.Forms.TextBox();
            this.lblDestination = new System.Windows.Forms.Label();
            this.lblImport = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnDestination = new System.Windows.Forms.Button();
            this.listViewDirectoryContent = new System.Windows.Forms.ListView();
            this.colItemName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDeepScanAction = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblValidationStatus = new System.Windows.Forms.Label();
            this.panelCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCard
            // 
            this.panelCard.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelCard.Controls.Add(this.destinationText);
            this.panelCard.Controls.Add(this.importText);
            this.panelCard.Controls.Add(this.lblDestination);
            this.panelCard.Controls.Add(this.lblImport);
            this.panelCard.Controls.Add(this.btnImport);
            this.panelCard.Controls.Add(this.btnDestination);
            this.panelCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCard.Location = new System.Drawing.Point(0, 0);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(800, 155);
            this.panelCard.TabIndex = 0;
            // 
            // destinationText
            // 
            this.destinationText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.destinationText.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.destinationText.Location = new System.Drawing.Point(88, 37);
            this.destinationText.Name = "destinationText";
            this.destinationText.Size = new System.Drawing.Size(432, 24);
            this.destinationText.TabIndex = 10;
            this.destinationText.Text = "Destination folder location appears here!";
            this.destinationText.TextChanged += new System.EventHandler(this.destinationText_TextChanged);
            // 
            // importText
            // 
            this.importText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.importText.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.importText.Location = new System.Drawing.Point(88, 106);
            this.importText.Name = "importText";
            this.importText.Size = new System.Drawing.Size(432, 24);
            this.importText.TabIndex = 9;
            this.importText.Text = "Imported folder location appears here!";
            this.importText.TextChanged += new System.EventHandler(this.importText_TextChanged);
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Font = new System.Drawing.Font("Malgun Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestination.Location = new System.Drawing.Point(83, 9);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(249, 25);
            this.lblDestination.TabIndex = 8;
            this.lblDestination.Text = "Select  Destination Location :";
            // 
            // lblImport
            // 
            this.lblImport.AutoSize = true;
            this.lblImport.Font = new System.Drawing.Font("Malgun Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImport.Location = new System.Drawing.Point(83, 78);
            this.lblImport.Name = "lblImport";
            this.lblImport.Size = new System.Drawing.Size(190, 25);
            this.lblImport.TabIndex = 7;
            this.lblImport.Text = "Import  Files/Folders :";
            // 
            // btnImport
            // 
            this.btnImport.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnImport.Font = new System.Drawing.Font("Malgun Gothic", 10F);
            this.btnImport.Location = new System.Drawing.Point(653, 94);
            this.btnImport.MaximumSize = new System.Drawing.Size(180, 40);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(106, 40);
            this.btnImport.TabIndex = 6;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnDestination
            // 
            this.btnDestination.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDestination.Font = new System.Drawing.Font("Malgun Gothic", 10F);
            this.btnDestination.Location = new System.Drawing.Point(653, 19);
            this.btnDestination.MaximumSize = new System.Drawing.Size(180, 40);
            this.btnDestination.Name = "btnDestination";
            this.btnDestination.Size = new System.Drawing.Size(106, 40);
            this.btnDestination.TabIndex = 5;
            this.btnDestination.Text = "Set";
            this.btnDestination.UseVisualStyleBackColor = true;
            this.btnDestination.Click += new System.EventHandler(this.btnDestination_Click);
            // 
            // listViewDirectoryContent
            // 
            this.listViewDirectoryContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewDirectoryContent.CheckBoxes = false;
            this.listViewDirectoryContent.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colItemName,
            this.colType,
            this.colDeepScanAction});
            this.listViewDirectoryContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewDirectoryContent.FullRowSelect = true;
            this.listViewDirectoryContent.HideSelection = false;
            this.listViewDirectoryContent.Location = new System.Drawing.Point(12, 161);
            this.listViewDirectoryContent.Name = "listViewDirectoryContent";
            this.listViewDirectoryContent.Size = new System.Drawing.Size(776, 240);
            this.listViewDirectoryContent.TabIndex = 11;
            this.listViewDirectoryContent.UseCompatibleStateImageBehavior = false;
            this.listViewDirectoryContent.View = System.Windows.Forms.View.Details;
            this.listViewDirectoryContent.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewDirectoryContent_MouseClick);
            // 
            // colItemName
            // 
            this.colItemName.Text = "Item Name";
            this.colItemName.Width = 250;
            // 
            // colType
            // 
            this.colType.Text = "Type";
            this.colType.Width = 100;
            // 
            // colDeepScanAction
            // 
            this.colDeepScanAction.Text = "Deep Scan Action";
            this.colDeepScanAction.Width = 200;
            // 
            // lblValidationStatus
            // 
            this.lblValidationStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblValidationStatus.AutoSize = true;
            this.lblValidationStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblValidationStatus.Location = new System.Drawing.Point(12, 416);
            this.lblValidationStatus.Name = "lblValidationStatus";
            this.lblValidationStatus.Size = new System.Drawing.Size(0, 23);
            this.lblValidationStatus.TabIndex = 12;
            // 
            // FormFolderSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblValidationStatus);
            this.Controls.Add(this.listViewDirectoryContent);
            this.Controls.Add(this.panelCard);
            this.Name = "FormFolderSelection";
            this.Text = "FormFolderSelection";
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Button btnDestination;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label lblImport;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.TextBox importText;
        private System.Windows.Forms.TextBox destinationText;
        private System.Windows.Forms.ListView listViewDirectoryContent;
        private System.Windows.Forms.ColumnHeader colItemName;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colDeepScanAction;
        private System.Windows.Forms.Label lblValidationStatus;
    }
}
