using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SmartFileOrganizer
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            try
            {
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();

                    string createTable = @"CREATE TABLE IF NOT EXISTS app_settings (
                        id INT AUTO_INCREMENT PRIMARY KEY,
                        destination_folder_path TEXT,
                        created_at DATETIME DEFAULT CURRENT_TIMESTAMP
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;";

                    using (MySqlCommand cmd = new MySqlCommand(createTable, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    string query = "SELECT destination_folder_path FROM app_settings ORDER BY id DESC LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        txtDestinationPath.Text = result?.ToString() ?? "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading settings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtDestinationPath.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDestinationPath.Text))
            {
                MessageBox.Show("Please select a valid destination folder.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();

                    string deleteQuery = "DELETE FROM app_settings";
                    using (MySqlCommand cmd = new MySqlCommand(deleteQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    string insertQuery = "INSERT INTO app_settings (destination_folder_path) VALUES (@path)";
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@path", txtDestinationPath.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Settings saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving settings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
