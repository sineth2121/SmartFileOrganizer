using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartFileOrganizer
{
    public partial class FormDashboard : Form
    {
        // Keeps track of the currently active form in the container
        private Form activeForm = null;
        public FormDashboard()
        {
            InitializeComponent();
        }
        private void OpenChildForm(Form childForm)
        {
            // If there's an active form, close it to free up memory
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;

            // Configure the form to behave like a control panel view
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Add it to the main dashboard container panel
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }
        private void FormDashboard_Load(object sender, EventArgs e)
        {

        }

        private void panelSidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnFolderSelection_Click(object sender, EventArgs e)
        {
            // This runs the  helper function and pushes FormFolderSelection into panelMain
            OpenChildForm(new FormFolderSelection());
        }

        private void btnDuplicateCleaner_Click(object sender, EventArgs e)
        {

        }

        private void btnScanPreview_Click(object sender, EventArgs e)
        {

        }

        private void btnOperationHistory_Click(object sender, EventArgs e)
        {

        }

        private void btnConfigureRules_Click(object sender, EventArgs e)
        {

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
