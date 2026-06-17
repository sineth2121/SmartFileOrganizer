namespace SmartFileOrganizer
{
    partial class FormFolderSelection
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
            this.panelCard = new System.Windows.Forms.Panel();
            this.btnDestination = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.lblImport = new System.Windows.Forms.Label();
            this.lblDestination = new System.Windows.Forms.Label();
            this.importText = new System.Windows.Forms.TextBox();
            this.destinationText = new System.Windows.Forms.TextBox();
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
            this.panelCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCard.Location = new System.Drawing.Point(0, 0);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(800, 450);
            this.panelCard.TabIndex = 0;
            // 
            // btnDestination
            // 
            this.btnDestination.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDestination.Font = new System.Drawing.Font("Malgun Gothic", 10F);
            this.btnDestination.Location = new System.Drawing.Point(666, 144);
            this.btnDestination.MaximumSize = new System.Drawing.Size(180, 40);
            this.btnDestination.Name = "btnDestination";
            this.btnDestination.Size = new System.Drawing.Size(106, 40);
            this.btnDestination.TabIndex = 5;
            this.btnDestination.Text = "Set";
            this.btnDestination.UseVisualStyleBackColor = true;
            this.btnDestination.Click += new System.EventHandler(this.btnDestination_Click);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnImport.Font = new System.Drawing.Font("Malgun Gothic", 10F);
            this.btnImport.Location = new System.Drawing.Point(666, 55);
            this.btnImport.MaximumSize = new System.Drawing.Size(180, 40);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(106, 40);
            this.btnImport.TabIndex = 6;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // lblImport
            // 
            this.lblImport.AutoSize = true;
            this.lblImport.Font = new System.Drawing.Font("Malgun Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImport.Location = new System.Drawing.Point(96, 39);
            this.lblImport.Name = "lblImport";
            this.lblImport.Size = new System.Drawing.Size(190, 25);
            this.lblImport.TabIndex = 7;
            this.lblImport.Text = "Import  Files/Folders :";
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Font = new System.Drawing.Font("Malgun Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestination.Location = new System.Drawing.Point(96, 134);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(249, 25);
            this.lblDestination.TabIndex = 8;
            this.lblDestination.Text = "Select  Destination Location :";
            // 
            // importText
            // 
            this.importText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.importText.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.importText.Location = new System.Drawing.Point(101, 67);
            this.importText.Name = "importText";
            this.importText.Size = new System.Drawing.Size(432, 24);
            this.importText.TabIndex = 9;
            this.importText.Text = "Imported folder location appears here!";
            this.importText.TextChanged += new System.EventHandler(this.importText_TextChanged);
            // 
            // destinationText
            // 
            this.destinationText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.destinationText.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.destinationText.Location = new System.Drawing.Point(101, 162);
            this.destinationText.Name = "destinationText";
            this.destinationText.Size = new System.Drawing.Size(432, 24);
            this.destinationText.TabIndex = 10;
            this.destinationText.Text = "Destination folder location appears here!";
            this.destinationText.TextChanged += new System.EventHandler(this.destinationText_TextChanged);
            // 
            // FormFolderSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelCard);
            this.Name = "FormFolderSelection";
            this.Text = "FormFolderSelection";
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Button btnDestination;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label lblImport;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.TextBox importText;
        private System.Windows.Forms.TextBox destinationText;
    }
}