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
        private Form activeForm = null;
        private FormFolderSelection folderSelectionForm = null;
        private FormConfigureRules configureRulesForm = null;
        private FormPreviewOrganize previewOrganizeForm = null;
        private FormOperationHistory operationHistoryForm = null;
        private FormDuplicateFinder duplicateFinderForm = null;
        private FormSettings settingsForm = null;
        private FormDashboardAnalytics dashboardAnalyticsForm = null;

        public FormDashboard()
        {
            InitializeComponent();
        }

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Hide();

            activeForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }
        private void FormDashboard_Load(object sender, EventArgs e)
        {
            DatabaseConfig.EnsureDatabase();
            ShowDashboard();
        }

        private void ShowDashboard()
        {
            if (dashboardAnalyticsForm == null)
            {
                dashboardAnalyticsForm = new FormDashboardAnalytics();
                dashboardAnalyticsForm.NavigateToFolderSelection += (s, args) => btnFolderSelection_Click(s, args);
                dashboardAnalyticsForm.NavigateToConfigureRules += (s, args) => btnConfigureRules_Click(s, args);
                dashboardAnalyticsForm.NavigateToDuplicateFinder += (s, args) => btnDuplicateCleaner_Click(s, args);
            }

            if (activeForm != null)
                activeForm.Hide();

            activeForm = dashboardAnalyticsForm;
            dashboardAnalyticsForm.TopLevel = false;
            dashboardAnalyticsForm.FormBorderStyle = FormBorderStyle.None;
            dashboardAnalyticsForm.Dock = DockStyle.Fill;

            if (!panelMain.Controls.Contains(dashboardAnalyticsForm))
                panelMain.Controls.Add(dashboardAnalyticsForm);

            panelMain.Tag = dashboardAnalyticsForm;
            dashboardAnalyticsForm.BringToFront();
            dashboardAnalyticsForm.Show();
            dashboardAnalyticsForm.RefreshData();
            label2.Text = "📊 Dashboard";
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
            if (folderSelectionForm == null)
            {
                folderSelectionForm = new FormFolderSelection();
                OpenChildForm(folderSelectionForm);
            }
            else
            {
                if (activeForm != null && activeForm != folderSelectionForm)
                    activeForm.Hide();

                activeForm = folderSelectionForm;
                panelMain.Tag = folderSelectionForm;
                folderSelectionForm.BringToFront();
                folderSelectionForm.Show();
            }
            label2.Text = "📥 Import Files";
        }

        private void btnDuplicateCleaner_Click(object sender, EventArgs e)
        {
            if (duplicateFinderForm == null)
            {
                duplicateFinderForm = new FormDuplicateFinder();
                OpenChildForm(duplicateFinderForm);
            }
            else
            {
                if (activeForm != null && activeForm != duplicateFinderForm)
                    activeForm.Hide();

                activeForm = duplicateFinderForm;
                panelMain.Tag = duplicateFinderForm;
                duplicateFinderForm.BringToFront();
                duplicateFinderForm.Show();
            }
            label2.Text = "🔍 Find Duplicates";
        }

        private void btnScanPreview_Click(object sender, EventArgs e)
        {
            if (previewOrganizeForm == null)
            {
                previewOrganizeForm = new FormPreviewOrganize();
                OpenChildForm(previewOrganizeForm);
            }
            else
            {
                if (activeForm != null && activeForm != previewOrganizeForm)
                    activeForm.Hide();

                activeForm = previewOrganizeForm;
                panelMain.Tag = previewOrganizeForm;
                previewOrganizeForm.BringToFront();
                previewOrganizeForm.Show();
            }
            label2.Text = "⚡ Preview & Organize";
        }

        private void btnOperationHistory_Click(object sender, EventArgs e)
        {
            if (operationHistoryForm == null)
            {
                operationHistoryForm = new FormOperationHistory();
                OpenChildForm(operationHistoryForm);
            }
            else
            {
                if (activeForm != null && activeForm != operationHistoryForm)
                    activeForm.Hide();

                activeForm = operationHistoryForm;
                panelMain.Tag = operationHistoryForm;
                operationHistoryForm.RefreshData();
                operationHistoryForm.BringToFront();
                operationHistoryForm.Show();
            }
            label2.Text = "🕒 Operation History";
        }

        private void btnConfigureRules_Click(object sender, EventArgs e)
        {
            if (configureRulesForm == null)
            {
                configureRulesForm = new FormConfigureRules();
                OpenChildForm(configureRulesForm);
            }
            else
            {
                if (activeForm != null && activeForm != configureRulesForm)
                    activeForm.Hide();

                activeForm = configureRulesForm;
                panelMain.Tag = configureRulesForm;
                configureRulesForm.BringToFront();
                configureRulesForm.Show();
            }
            label2.Text = "⚙️ Configure Rules";
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ShowDashboard();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (settingsForm == null)
            {
                settingsForm = new FormSettings();
                OpenChildForm(settingsForm);
            }
            else
            {
                if (activeForm != null && activeForm != settingsForm)
                    activeForm.Hide();

                activeForm = settingsForm;
                panelMain.Tag = settingsForm;
                settingsForm.BringToFront();
                settingsForm.Show();
            }
            label2.Text = "⚙️ Application Settings";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
