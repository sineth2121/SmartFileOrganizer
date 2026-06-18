using System;
using System.Windows.Forms;

namespace SmartFileOrganizer
{
    public partial class FormImportProgress : Form
    {
        public bool Cancelled { get; private set; } = false;
        private bool importingComplete = false;

        public FormImportProgress()
        {
            InitializeComponent();
        }

        public void SetStatus(string text)
        {
            lblStatus.Text = text;
        }

        public void SetTotal(int total)
        {
            progressBar.Maximum = total > 0 ? total : 1;
        }

        public void SetProgress(int current)
        {
            progressBar.Value = current;
            Application.DoEvents();
        }

        public void SetCompleted()
        {
            importingComplete = true;
            progressBar.Value = progressBar.Maximum;
            lblStatus.Text = "Import completed successfully.";
            btnCancel.Enabled = false;
            btnOk.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!importingComplete)
            {
                Cancelled = true;
                btnCancel.Enabled = false;
                lblStatus.Text = "Cancelling...";
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (importingComplete)
                Close();
        }

        private void FormImportProgress_Load(object sender, EventArgs e)
        {

        }
    }
}
