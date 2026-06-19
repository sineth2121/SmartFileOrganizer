using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SmartFileOrganizer
{
    public partial class FormFolderSelection : Form
    {
        private bool hasSubfolders = false;

        public FormFolderSelection()
        {
            InitializeComponent();
            this.Text = "Folder Selection";

            SetupCheckboxImageList();

            try
            {
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    string query = "SELECT destination_folder_path FROM app_settings ORDER BY id DESC LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        conn.Open();

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                destinationText.Text = reader["destination_folder_path"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupCheckboxImageList()
        {
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(16, 16);
            imageList.ColorDepth = ColorDepth.Depth32Bit;

            Bitmap uncheckedImg = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(uncheckedImg))
            {
                g.Clear(Color.Transparent);
                using (Pen pen = new Pen(Color.DimGray, 2f))
                {
                    g.DrawRectangle(pen, 1, 1, 13, 13);
                }
            }
            imageList.Images.Add(uncheckedImg);

            Bitmap checkedImg = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(checkedImg))
            {
                g.Clear(Color.Transparent);
                using (Pen pen = new Pen(Color.DimGray, 2f))
                {
                    g.DrawRectangle(pen, 1, 1, 13, 13);
                }
                using (Font font = new Font("Segoe UI", 10f, FontStyle.Bold))
                {
                    g.DrawString("✓", font, Brushes.ForestGreen, 0, -1);
                }
            }
            imageList.Images.Add(checkedImg);

            listViewDirectoryContent.StateImageList = imageList;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();

                    string createAppSettings = @"CREATE TABLE IF NOT EXISTS app_settings (
                        id INT AUTO_INCREMENT PRIMARY KEY,
                        destination_folder_path TEXT,
                        created_at DATETIME DEFAULT CURRENT_TIMESTAMP
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

                    using (MySqlCommand cmd = new MySqlCommand(createAppSettings, conn))
                        cmd.ExecuteNonQuery();
                    using (MySqlCommand cmd = new MySqlCommand(createImportedFiles, conn))
                        cmd.ExecuteNonQuery();
                    using (MySqlCommand cmd = new MySqlCommand(createOperationHistory, conn))
                        cmd.ExecuteNonQuery();
                    using (MySqlCommand cmd = new MySqlCommand(createOrgRules, conn))
                        cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB connection or table error: " + ex.Message, "DB Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select the source folder to Import Files.";
                folderDialog.ShowNewFolderButton = false;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    importText.Text = folderDialog.SelectedPath;

                    PopulateDirectoryViewer(folderDialog.SelectedPath);
                }
            }
        }

        private void PopulateDirectoryViewer(string folderPath)
        {
            listViewDirectoryContent.Items.Clear();
            hasSubfolders = false;

            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(folderPath);

                if (!dirInfo.Exists)
                {
                    return;
                }

                foreach (DirectoryInfo subDir in dirInfo.GetDirectories())
                {
                    hasSubfolders = true;

                    ListViewItem item = new ListViewItem(subDir.Name);
                    item.SubItems.Add("Folder");
                    item.SubItems.Add("Scan Subfolders");
                    item.Tag = subDir.FullName;
                    item.StateImageIndex = 0;

                    listViewDirectoryContent.Items.Add(item);
                }

                foreach (FileInfo file in dirInfo.GetFiles())
                {
                    ListViewItem item = new ListViewItem(file.Name);
                    item.SubItems.Add("File");
                    item.SubItems.Add("Process Directly");
                    item.Tag = file.FullName;
                    item.StateImageIndex = -1;

                    listViewDirectoryContent.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to read directory contents: " + ex.Message,
                    "Directory Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            EvaluateValidationRules();
        }

        private void listViewDirectoryContent_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo hit = listViewDirectoryContent.HitTest(e.Location);

            if (hit.Item == null)
                return;

            string itemType = hit.Item.SubItems[1].Text;

            if (itemType != "Folder")
                return;

            if (hit.Item.StateImageIndex == 0)
            {
                hit.Item.StateImageIndex = 1;
                hit.Item.SubItems[2].Text = "EXCLUDED (Move folder whole, skip inside)";
                hit.Item.BackColor = Color.LavenderBlush;
            }
            else
            {
                hit.Item.StateImageIndex = 0;
                hit.Item.SubItems[2].Text = "Scan Subfolders";
                hit.Item.BackColor = Color.White;
            }

            EvaluateValidationRules();
        }

        private void EvaluateValidationRules()
        {
            if (!hasSubfolders)
            {
                lblValidationStatus.Text = "Ready: No subfolders detected. Direct files will be organized.";
                lblValidationStatus.ForeColor = Color.ForestGreen;
            }
            else
            {
                int checkedCount = 0;
                int totalFoldersCount = 0;

                foreach (ListViewItem item in listViewDirectoryContent.Items)
                {
                    if (item.SubItems[1].Text == "Folder")
                    {
                        totalFoldersCount++;

                        if (item.StateImageIndex == 1)
                        {
                            checkedCount++;
                        }
                    }
                }

                if (checkedCount == 0)
                {
                    lblValidationStatus.Text = "Subfolders detected. Tick folders to exclude from deep scanning.";
                    lblValidationStatus.ForeColor = Color.Firebrick;
                }
                else
                {
                    lblValidationStatus.Text = "✓ Success: exclude rules are set (" +
                        checkedCount + " of " + totalFoldersCount +
                        " folders custom restricted).";
                    lblValidationStatus.ForeColor = Color.ForestGreen;
                }
            }
        }

        private void btnDestination_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select the base destination folder for organized files";
                folderDialog.ShowNewFolderButton = true;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string newPath = folderDialog.SelectedPath;

                    try
                    {
                        using (MySqlConnection conn = DatabaseConfig.GetConnection())
                        {
                            conn.Open();

                            string checkQuery = "SELECT COUNT(*) FROM app_settings";
                            using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                            {
                                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                                if (count > 0)
                                {
                                    DialogResult result = MessageBox.Show(
                                        "A destination folder already exists.\n\nChanging it will reset the whole database and history.\n\nDo you want to continue?",
                                        "Warning",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Warning
                                    );

                                    if (result == DialogResult.No)
                                    {
                                        return;
                                    }

                                    string deleteQuery = "DELETE FROM app_settings";
                                    using (MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, conn))
                                    {
                                        deleteCmd.ExecuteNonQuery();
                                    }
                                }
                            }

                            string insertQuery = "INSERT INTO app_settings (destination_folder_path) VALUES (@path)";
                            using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@path", newPath);
                                insertCmd.ExecuteNonQuery();
                            }
                        }

                        destinationText.Text = newPath;

                        MessageBox.Show(
                            "Destination folder updated successfully!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "Failed to store path: " + ex.Message,
                            "Database Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
        }

        private void importText_TextChanged(object sender, EventArgs e)
        {

        }

        private void destinationText_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnStartImport_Click(object sender, EventArgs e)
        {
            string sourcePath = importText.Text;
            string destPath = destinationText.Text;

            if (string.IsNullOrWhiteSpace(sourcePath) || sourcePath == "Imported folder location appears here!" || !Directory.Exists(sourcePath))
            {
                MessageBox.Show("Please select a valid source folder.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(destPath) || destPath == "Destination folder location appears here!")
            {
                MessageBox.Show("Please select a valid destination folder.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string operationType = rbCopy.Checked ? "Copy" : "Cut";

            HashSet<string> excludedFolders = new HashSet<string>();
            foreach (ListViewItem item in listViewDirectoryContent.Items)
            {
                if (item.SubItems[1].Text == "Folder" && item.StateImageIndex == 1)
                    excludedFolders.Add(item.Tag.ToString());
            }

            btnStartImport.Enabled = false;

            using (MySqlConnection conn = DatabaseConfig.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM imported_files", conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            FormImportProgress progressForm = new FormImportProgress();
            progressForm.Show(this);

            int totalFiles = CountFiles(sourcePath, excludedFolders);

            if (totalFiles == 0)
            {
                progressForm.Close();
                btnStartImport.Enabled = true;
                MessageBox.Show("No files found to import.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            progressForm.SetTotal(totalFiles);
            progressForm.SetStatus("Importing files...");

            int processed = 0;
            ImportDirectory(sourcePath, sourcePath, destPath, operationType, excludedFolders, progressForm, ref processed);

            if (progressForm.Cancelled)
            {
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM imported_files", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                progressForm.Close();
                btnStartImport.Enabled = true;
            }
            else
            {
                progressForm.SetCompleted();
                btnStartImport.Enabled = true;
            }
        }

        private int CountFiles(string path, HashSet<string> excludedFolders)
        {
            int count = 0;
            try
            {
                count += Directory.GetFiles(path).Length;

                foreach (string dir in Directory.GetDirectories(path))
                {
                    if (excludedFolders.Contains(dir))
                    {
                        count++;
                        continue;
                    }
                    count += CountFiles(dir, excludedFolders);
                }
            }
            catch
            {
            }
            return count;
        }

        private void ImportDirectory(string rootPath, string currentPath, string destPath,
            string operationType, HashSet<string> excludedFolders,
            FormImportProgress progressForm, ref int processed)
        {
            try
            {
                foreach (string file in Directory.GetFiles(currentPath))
                {
                    if (progressForm.Cancelled)
                        return;

                    FileInfo fi = new FileInfo(file);
                    string relativePath = GetRelativePath(rootPath, file);
                    string destFullPath = Path.Combine(destPath, relativePath);

                    InsertFileRecord(fi.Name, file, fi.Extension, fi.Length, fi.LastWriteTime,
                        "File", 0, operationType, file, destFullPath);

                    processed++;
                    progressForm.SetProgress(processed);
                }

                foreach (string dir in Directory.GetDirectories(currentPath))
                {
                    if (progressForm.Cancelled)
                        return;

                    DirectoryInfo di = new DirectoryInfo(dir);
                    bool isExcluded = excludedFolders.Contains(dir);
                    string relativePath = GetRelativePath(rootPath, dir);
                    string destFullPath = Path.Combine(destPath, relativePath);

                    if (isExcluded)
                    {
                        InsertFileRecord(di.Name, dir, "", 0, di.LastWriteTime,
                            "Folder", 1, operationType, dir, destFullPath);

                        processed++;
                        progressForm.SetProgress(processed);
                    }
                    else
                    {
                        ImportDirectory(rootPath, dir, destPath,
                            operationType, excludedFolders, progressForm, ref processed);
                    }
                }
            }
            catch
            {
            }
        }

        private string GetRelativePath(string rootPath, string fullPath)
        {
            if (!rootPath.EndsWith("\\"))
                rootPath += "\\";
            return fullPath.Substring(rootPath.Length);
        }

        private void InsertFileRecord(string fileName, string filePath, string extension,
            long size, DateTime fileModifiedDate, string fileType, int isExcluded,
            string operationType, string sourcePath, string destPath)
        {
            using (MySqlConnection conn = DatabaseConfig.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO imported_files
                    (file_name, file_path, file_extension, file_size, file_modified_date,
                     file_type, is_excluded, operation_type, source_path, destination_path)
                    VALUES (@name, @path, @ext, @size, @modified,
                            @type, @excluded, @operation, @source, @dest)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", fileName);
                    cmd.Parameters.AddWithValue("@path", filePath);
                    cmd.Parameters.AddWithValue("@ext", string.IsNullOrEmpty(extension) ? (object)DBNull.Value : extension);
                    cmd.Parameters.AddWithValue("@size", size);
                    cmd.Parameters.AddWithValue("@modified", fileModifiedDate);
                    cmd.Parameters.AddWithValue("@type", fileType);
                    cmd.Parameters.AddWithValue("@excluded", isExcluded);
                    cmd.Parameters.AddWithValue("@operation", operationType);
                    cmd.Parameters.AddWithValue("@source", sourcePath);
                    cmd.Parameters.AddWithValue("@dest", destPath);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
