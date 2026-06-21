using System;
using MySql.Data.MySqlClient;

namespace SmartFileOrganizer
{
    public static class DatabaseConfig
    {
        private static string connectionString = "Server=localhost;Port=3306;Database=smart_file_organizer;Uid=root;Pwd=;";
        private static string serverOnlyConnString = "Server=localhost;Port=3306;Uid=root;Pwd=;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public static void EnsureDatabase()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(serverOnlyConnString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("CREATE DATABASE IF NOT EXISTS smart_file_organizer CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();

                    string createAppSettings = @"CREATE TABLE IF NOT EXISTS app_settings (
                        id INT AUTO_INCREMENT PRIMARY KEY,
                        setting_key VARCHAR(100) NOT NULL UNIQUE,
                        setting_value TEXT,
                        updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;";

                    string createImportedFiles = @"CREATE TABLE IF NOT EXISTS imported_files (
                        id INT AUTO_INCREMENT PRIMARY KEY,
                        file_name VARCHAR(255) NOT NULL,
                        file_path TEXT NOT NULL,
                        file_extension VARCHAR(50) NULL,
                        file_size BIGINT NOT NULL DEFAULT 0,
                        file_modified_date DATETIME NULL,
                        file_type VARCHAR(20) NOT NULL DEFAULT 'File',
                        is_excluded TINYINT(1) NOT NULL DEFAULT 0,
                        operation_type VARCHAR(10) NOT NULL DEFAULT 'Copy',
                        source_path TEXT NULL,
                        destination_path TEXT NULL,
                        predicted_destination TEXT NULL,
                        imported_date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;";

                    string createOperationHistory = @"CREATE TABLE IF NOT EXISTS operation_history (
                        id INT AUTO_INCREMENT PRIMARY KEY,
                        execution_id VARCHAR(36) NULL,
                        operation_type VARCHAR(50) NOT NULL,
                        file_name VARCHAR(255) NULL,
                        source_path VARCHAR(500) NULL,
                        destination_path VARCHAR(500) NULL,
                        file_size BIGINT NULL,
                        status VARCHAR(20) NOT NULL DEFAULT 'SUCCESS',
                        performed_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;";

                    string createOrgRules = @"CREATE TABLE IF NOT EXISTS organization_rules (
                        id INT AUTO_INCREMENT PRIMARY KEY,
                        rule_name VARCHAR(255) NOT NULL,
                        ext_category VARCHAR(255) NULL,
                        age_days VARCHAR(50) NULL,
                        keyword_match VARCHAR(255) NULL,
                        destination_subfolder VARCHAR(255) NOT NULL,
                        is_active TINYINT(1) NOT NULL DEFAULT 1,
                        execution_id INT NULL,
                        rule_source VARCHAR(20) NOT NULL DEFAULT 'custom',
                        created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
                        FOREIGN KEY (execution_id) REFERENCES operation_history(id) ON DELETE SET NULL
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;";

                    string createDestFileData = @"CREATE TABLE IF NOT EXISTS destination_file_data (
                        id INT AUTO_INCREMENT PRIMARY KEY,
                        execution_id VARCHAR(36) NULL,
                        file_name VARCHAR(255) NOT NULL,
                        file_extension VARCHAR(50) NULL,
                        file_size BIGINT NOT NULL DEFAULT 0,
                        file_modified_date DATETIME NULL,
                        file_type VARCHAR(20) NOT NULL DEFAULT 'File',
                        is_excluded TINYINT(1) NOT NULL DEFAULT 0,
                        operation_type VARCHAR(10) NOT NULL DEFAULT 'Copy',
                        source_path TEXT NULL,
                        destination_path TEXT NULL,
                        file_hash VARCHAR(64) NULL,
                        imported_date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;";

                    using (MySqlCommand cmd = new MySqlCommand(createAppSettings, conn))
                        cmd.ExecuteNonQuery();
                    using (MySqlCommand cmd = new MySqlCommand(createImportedFiles, conn))
                        cmd.ExecuteNonQuery();
                    using (MySqlCommand cmd = new MySqlCommand(createOperationHistory, conn))
                        cmd.ExecuteNonQuery();
                    using (MySqlCommand cmd = new MySqlCommand(createOrgRules, conn))
                        cmd.ExecuteNonQuery();
                    using (MySqlCommand cmd = new MySqlCommand(createDestFileData, conn))
                        cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Database initialization error: " + ex.Message,
                    "Database Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
    }
}
