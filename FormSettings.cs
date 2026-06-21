using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SmartFileOrganizer
{
    public partial class FormSettings : Form
    {
        private const string KEY_DEST_PATH = "destination_folder_path";
        private const string KEY_DEFAULT_OP = "default_operation";
        private const string KEY_CONFIRM_ACTIONS = "confirm_before_actions";
        private const string KEY_EXCLUDED_EXT = "excluded_extensions";
        private const string KEY_EXCLUDED_FOLDERS = "excluded_folder_names";
        private const string KEY_MAX_FILE_SIZE = "max_file_size_mb";
        private const string KEY_DB_SERVER = "db_server";
        private const string KEY_DB_PORT = "db_port";
        private const string KEY_DB_NAME = "db_database";
        private const string KEY_DB_USER = "db_username";
        private const string KEY_DB_PASS = "db_password";
        private const string KEY_VERIFY_FILES = "scan_verification_at_startup";
        private const string KEY_SCAN_DUPS = "scan_duplicates_at_startup";

        public FormSettings()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void EnsureSettingsTable()
        {
            using (MySqlConnection conn = DatabaseConfig.GetConnection())
            {
                conn.Open();

                // Check if old schema exists
                string checkOld = "SELECT COUNT(*) FROM information_schema.COLUMNS WHERE TABLE_NAME = 'app_settings' AND COLUMN_NAME = 'destination_folder_path' AND TABLE_SCHEMA = (SELECT DATABASE())";
                bool isOldSchema = false;
                using (MySqlCommand cmd = new MySqlCommand(checkOld, conn))
                {
                    object result = cmd.ExecuteScalar();
                    isOldSchema = Convert.ToInt32(result) > 0;
                }

                if (isOldSchema)
                {
                    string migrate = @"
                        CREATE TABLE IF NOT EXISTS app_settings_new (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            setting_key VARCHAR(100) NOT NULL UNIQUE,
                            setting_value TEXT,
                            updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

                        INSERT IGNORE INTO app_settings_new (setting_key, setting_value, updated_at)
                        SELECT 'destination_folder_path', destination_folder_path, COALESCE(created_at, NOW())
                        FROM app_settings
                        WHERE destination_folder_path IS NOT NULL AND destination_folder_path != '';

                        DROP TABLE IF EXISTS app_settings_old;
                        ALTER TABLE app_settings RENAME TO app_settings_old;
                        ALTER TABLE app_settings_new RENAME TO app_settings;
                        DROP TABLE IF EXISTS app_settings_old;";

                    using (MySqlCommand cmd = new MySqlCommand(migrate, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    string create = @"CREATE TABLE IF NOT EXISTS app_settings (
                        id INT AUTO_INCREMENT PRIMARY KEY,
                        setting_key VARCHAR(100) NOT NULL UNIQUE,
                        setting_value TEXT,
                        updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;";

                    using (MySqlCommand cmd = new MySqlCommand(create, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private string GetSetting(string key, string defaultValue)
        {
            string query = "SELECT setting_value FROM app_settings WHERE setting_key = @key LIMIT 1";
            using (MySqlConnection conn = DatabaseConfig.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@key", key);
                    object result = cmd.ExecuteScalar();
                    return result?.ToString() ?? defaultValue;
                }
            }
        }

        private void SetSetting(string key, string value)
        {
            string query = @"INSERT INTO app_settings (setting_key, setting_value, updated_at) VALUES (@key, @value, NOW())
                             ON DUPLICATE KEY UPDATE setting_value = @value, updated_at = NOW()";
            using (MySqlConnection conn = DatabaseConfig.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@key", key);
                    cmd.Parameters.AddWithValue("@value", value ?? "");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void LoadSettings()
        {
            try
            {
                EnsureSettingsTable();

                txtDestinationPath.Text = GetSetting(KEY_DEST_PATH, "");
                cboDefaultOperation.SelectedItem = GetSetting(KEY_DEFAULT_OP, "Copy (keep originals)");
                chkConfirmActions.Checked = GetSetting(KEY_CONFIRM_ACTIONS, "true") == "true";
                txtExcludedExtensions.Text = GetSetting(KEY_EXCLUDED_EXT, ".tmp,.log,.bak");
                txtExcludedFolders.Text = GetSetting(KEY_EXCLUDED_FOLDERS, "System Volume Information,$Recycle.Bin,.git,.svn");
                nudMaxFileSize.Value = Math.Min(Math.Max(0, int.Parse(GetSetting(KEY_MAX_FILE_SIZE, "100"))), 99999);
                txtDbServer.Text = GetSetting(KEY_DB_SERVER, "localhost");
                nudDbPort.Value = Math.Min(Math.Max(1, int.Parse(GetSetting(KEY_DB_PORT, "3306"))), 65535);
                txtDbName.Text = GetSetting(KEY_DB_NAME, "smart_file_organizer");
                txtDbUser.Text = GetSetting(KEY_DB_USER, "root");
                txtDbPassword.Text = GetSetting(KEY_DB_PASS, "");
                chkVerifyFiles.Checked = GetSetting(KEY_VERIFY_FILES, "true") == "true";
                chkScanDups.Checked = GetSetting(KEY_SCAN_DUPS, "false") == "true";
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
                    txtDestinationPath.Text = fbd.SelectedPath;
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
                EnsureSettingsTable();

                SetSetting(KEY_DEST_PATH, txtDestinationPath.Text.Trim());
                SetSetting(KEY_DEFAULT_OP, cboDefaultOperation.SelectedItem?.ToString() ?? "Copy (keep originals)");
                SetSetting(KEY_CONFIRM_ACTIONS, chkConfirmActions.Checked ? "true" : "false");
                SetSetting(KEY_EXCLUDED_EXT, txtExcludedExtensions.Text.Trim());
                SetSetting(KEY_EXCLUDED_FOLDERS, txtExcludedFolders.Text.Trim());
                SetSetting(KEY_MAX_FILE_SIZE, ((int)nudMaxFileSize.Value).ToString());
                SetSetting(KEY_DB_SERVER, txtDbServer.Text.Trim());
                SetSetting(KEY_DB_PORT, ((int)nudDbPort.Value).ToString());
                SetSetting(KEY_DB_NAME, txtDbName.Text.Trim());
                SetSetting(KEY_DB_USER, txtDbUser.Text.Trim());
                SetSetting(KEY_DB_PASS, txtDbPassword.Text);
                SetSetting(KEY_VERIFY_FILES, chkVerifyFiles.Checked ? "true" : "false");
                SetSetting(KEY_SCAN_DUPS, chkScanDups.Checked ? "true" : "false");

                MessageBox.Show("Settings saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving settings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            string server = txtDbServer.Text.Trim();
            string port = ((int)nudDbPort.Value).ToString();
            string db = txtDbName.Text.Trim();
            string user = txtDbUser.Text.Trim();
            string pass = txtDbPassword.Text;

            string connStr = $"Server={server};Port={port};Database={db};Uid={user};Pwd={pass};";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    MessageBox.Show("Connection successful!", "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed: " + ex.Message, "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCleanHistory_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete all operation history?\n\nThis action cannot be undone.",
                "Clean Operation History",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            try
            {
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM operation_history";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        int deleted = cmd.ExecuteNonQuery();
                        MessageBox.Show($"Deleted {deleted} history record(s).", "Clean Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cleaning history: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nudMaxFileSize_ValueChanged(object sender, EventArgs e) { }
        private void nudDbPort_ValueChanged(object sender, EventArgs e) { }

        private void btnBrowse_Click_1(object sender, EventArgs e)
        {

        }
    }
}
