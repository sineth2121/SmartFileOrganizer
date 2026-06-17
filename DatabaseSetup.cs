using System;
using MySql.Data.MySqlClient;

namespace SmartFileOrganizer
{
    public static class DatabaseSetup
    {
        private static readonly string[] CreateTableQueries =
        {
            @"
                CREATE TABLE IF NOT EXISTS app_settings (
                    id INT AUTO_INCREMENT PRIMARY KEY,
                    destination_folder_path VARCHAR(500) NOT NULL,
                    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                )
            ",
            @"
                CREATE TABLE IF NOT EXISTS source_folders (
                    id INT AUTO_INCREMENT PRIMARY KEY,
                    folder_path VARCHAR(500) NOT NULL,
                    is_imported TINYINT(1) DEFAULT 0,
                    added_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                )
            ",
            @"
                CREATE TABLE IF NOT EXISTS organization_rules (
                    id INT AUTO_INCREMENT PRIMARY KEY,
                    rule_name VARCHAR(255) NOT NULL,
                    source_pattern VARCHAR(255) NOT NULL,
                    destination_subfolder VARCHAR(255) NOT NULL,
                    is_active TINYINT(1) DEFAULT 1,
                    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                )
            ",
            @"
                CREATE TABLE IF NOT EXISTS scanned_files (
                    id INT AUTO_INCREMENT PRIMARY KEY,
                    source_folder_id INT,
                    file_name VARCHAR(255) NOT NULL,
                    file_path VARCHAR(500) NOT NULL,
                    file_extension VARCHAR(50),
                    file_size BIGINT,
                    file_hash VARCHAR(64),
                    scanned_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    FOREIGN KEY (source_folder_id) REFERENCES source_folders(id) ON DELETE CASCADE
                )
            ",
            @"
                CREATE TABLE IF NOT EXISTS operation_history (
                    id INT AUTO_INCREMENT PRIMARY KEY,
                    operation_type VARCHAR(50) NOT NULL,
                    file_name VARCHAR(255),
                    source_path VARCHAR(500),
                    destination_path VARCHAR(500),
                    file_size BIGINT,
                    status VARCHAR(20) DEFAULT 'SUCCESS',
                    performed_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                )
            ",
            @"
                CREATE TABLE IF NOT EXISTS duplicate_groups (
                    id INT AUTO_INCREMENT PRIMARY KEY,
                    file_hash VARCHAR(64) NOT NULL,
                    file_size BIGINT,
                    detected_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                )
            ",
            @"
                CREATE TABLE IF NOT EXISTS duplicate_files (
                    id INT AUTO_INCREMENT PRIMARY KEY,
                    group_id INT NOT NULL,
                    file_name VARCHAR(255),
                    file_path VARCHAR(500) NOT NULL,
                    is_original TINYINT(1) DEFAULT 0,
                    FOREIGN KEY (group_id) REFERENCES duplicate_groups(id) ON DELETE CASCADE
                )
            "
        };

        public static void Initialize()
        {
            try
            {
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();

                    foreach (string query in CreateTableQueries)
                    {
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                    "Database setup failed: " + ex.Message,
                    "Error",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error
                );
            }
        }
    }
}
