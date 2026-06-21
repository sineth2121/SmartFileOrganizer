using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SmartFileOrganizer
{
    public partial class FormPreviewOrganize : Form
    {
        private class Rule
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string ExtCategory { get; set; }
            public string AgeDays { get; set; }
            public string KeywordMatch { get; set; }
            public string DestinationSubfolder { get; set; }
        }

        private string baseDestinationPath = "";
        private int totalFiles = 0;
        private int matchedCount = 0;
        private int unmatchedCount = 0;

        public FormPreviewOrganize()
        {
            InitializeComponent();
            PopulatePlaceholderIcons();
            PopulateTreeIcons();
        }

        private void PopulatePlaceholderIcons()
        {
            ImageList imgList = lvFolderContents.LargeImageList;
            if (imgList == null) return;

            imgList.Images.Clear();

            imgList.Images.Add("Folder", CreatePlaceholderIcon(
                Color.FromArgb(210, 185, 130), "F", Color.FromArgb(50, 45, 30), imgList.ImageSize.Width));
            imgList.Images.Add("Document", CreatePlaceholderIcon(
                Color.FromArgb(140, 155, 185), "D", Color.White, imgList.ImageSize.Width));
            imgList.Images.Add("Image", CreatePlaceholderIcon(
                Color.FromArgb(140, 175, 145), "I", Color.White, imgList.ImageSize.Width));
            imgList.Images.Add("Video", CreatePlaceholderIcon(
                Color.FromArgb(175, 130, 155), "V", Color.White, imgList.ImageSize.Width));
            imgList.Images.Add("GenericFile", CreatePlaceholderIcon(
                Color.FromArgb(160, 160, 160), "F", Color.White, imgList.ImageSize.Width));
        }

        private void PopulateTreeIcons()
        {
            ImageList imgList = tvDestinationPreview.ImageList;
            if (imgList == null) return;

            imgList.Images.Clear();

            Bitmap folderIcon = new Bitmap(imgList.ImageSize.Width, imgList.ImageSize.Height);
            using (Graphics g = Graphics.FromImage(folderIcon))
            {
                g.Clear(Color.Transparent);
                using (Brush brush = new SolidBrush(Color.FromArgb(210, 185, 130)))
                {
                    g.FillRectangle(brush, 1, 3, 14, 12);
                }
                g.DrawRectangle(new Pen(Color.FromArgb(80, 75, 55)), 1, 3, 14, 12);
            }
            imgList.Images.Add(folderIcon);

            Bitmap fileIcon = new Bitmap(imgList.ImageSize.Width, imgList.ImageSize.Height);
            using (Graphics g = Graphics.FromImage(fileIcon))
            {
                g.Clear(Color.Transparent);
                using (Brush brush = new SolidBrush(Color.FromArgb(140, 155, 185)))
                {
                    g.FillRectangle(brush, 2, 2, 12, 12);
                }
                g.DrawRectangle(new Pen(Color.FromArgb(60, 65, 80)), 2, 2, 12, 12);
            }
            imgList.Images.Add(fileIcon);
        }

        private Bitmap CreatePlaceholderIcon(Color backColor, string letter, Color letterColor, int size)
        {
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                using (Brush brush = new SolidBrush(backColor))
                {
                    g.FillRectangle(brush, 2, 2, size - 4, size - 4);
                }
                using (Pen pen = new Pen(Color.FromArgb(60, 60, 60), 1))
                {
                    g.DrawRectangle(pen, 2, 2, size - 4, size - 4);
                }
                using (Font font = new Font("Segoe UI", size * 0.4f, FontStyle.Bold))
                {
                    SizeF textSize = g.MeasureString(letter, font);
                    float x = (size - textSize.Width) / 2f;
                    float y = (size - textSize.Height) / 2f;
                    using (Brush textBrush = new SolidBrush(letterColor))
                    {
                        g.DrawString(letter, font, textBrush, x, y);
                    }
                }
            }
            return bmp;
        }

        private void FormPreviewOrganize_Load(object sender, EventArgs e)
        {

        }

        private void btnPreparePreview_Click(object sender, EventArgs e)
        {
            if (!LoadBaseDestinationPath())
            {
                MessageBox.Show("No destination folder configured. Please set one in Select Folders first.",
                    "Configuration Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnPreparePreview.Enabled = false;
            btnExecuteOrganize.Enabled = false;

            try
            {
                List<Rule> rules = LoadRules();

                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();

                    using (MySqlCommand clearCmd = new MySqlCommand(
                        "UPDATE imported_files SET predicted_destination = NULL", conn))
                    {
                        clearCmd.ExecuteNonQuery();
                    }

                    using (MySqlCommand countCmd = new MySqlCommand(
                        "SELECT COUNT(*) FROM imported_files WHERE file_type = 'File' OR (file_type = 'Folder' AND is_excluded = 1)", conn))
                    {
                        totalFiles = Convert.ToInt32(countCmd.ExecuteScalar());
                    }

                    if (totalFiles == 0)
                    {
                        lblProgressStatus.Text = "No items to process. Import files first.";
                        return;
                    }

                    prgOrganizeProgress.Maximum = totalFiles;
                    prgOrganizeProgress.Value = 0;

                    matchedCount = 0;
                    unmatchedCount = 0;
                    UpdateStats();

                    using (MySqlCommand readCmd = new MySqlCommand(
                        "SELECT id, file_name, file_extension, file_modified_date, file_type, file_path FROM imported_files WHERE file_type = 'File' OR (file_type = 'Folder' AND is_excluded = 1) ORDER BY id ASC", conn))
                    using (MySqlDataReader reader = readCmd.ExecuteReader())
                    {
                        List<(int id, string predicted, bool matched)> updates = new List<(int, string, bool)>();
                        int index = 0;

                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["id"]);
                            string fileName = reader["file_name"].ToString();
                            string rawExtension = reader["file_extension"] != DBNull.Value ? reader["file_extension"].ToString() : "";
                            string fileType = reader["file_type"].ToString();
                            DateTime? modifiedDate = reader["file_modified_date"] != DBNull.Value
                                ? Convert.ToDateTime(reader["file_modified_date"]) : (DateTime?)null;

                            string extension = fileType == "Folder" ? "folder" : rawExtension;

                            string predictedDest = null;
                            bool matched = false;
                            string ruleName = "";

                            foreach (Rule rule in rules)
                            {
                                if (FileMatchesRule(fileName, extension, modifiedDate, rule))
                                {
                                    predictedDest = Path.Combine(rule.DestinationSubfolder, fileName);
                                    matched = true;
                                    ruleName = rule.Name;
                                    break;
                                }
                            }

                            if (!matched)
                            {
                                predictedDest = Path.Combine(baseDestinationPath, "Unorganized_Items", fileName);
                            }

                            updates.Add((id, predictedDest, matched));

                            if (matched)
                                matchedCount++;
                            else
                                unmatchedCount++;

                            index++;
                            prgOrganizeProgress.Value = Math.Min(index, totalFiles);
                            lblProgressStatus.Text = $"Processing {index} of {totalFiles}: {fileName}";
                            UpdateStats();
                            Application.DoEvents();
                        }

                        reader.Close();

                        foreach (var update in updates)
                        {
                            using (MySqlCommand updateCmd = new MySqlCommand(
                                "UPDATE imported_files SET predicted_destination = @dest WHERE id = @id", conn))
                            {
                                updateCmd.Parameters.AddWithValue("@dest", update.predicted);
                                updateCmd.Parameters.AddWithValue("@id", update.id);
                                updateCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }

                lblProgressStatus.Text = $"Preview ready — {totalFiles} files processed.";
                PopulatePreviewTree();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during preview preparation: " + ex.Message,
                    "Preview Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnPreparePreview.Enabled = true;
                btnExecuteOrganize.Enabled = true;
            }
        }

        private bool LoadBaseDestinationPath()
        {
            try
            {
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(
                        "SELECT setting_value FROM app_settings WHERE setting_key = 'destination_folder_path' LIMIT 1", conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            baseDestinationPath = result.ToString();
                            return !string.IsNullOrWhiteSpace(baseDestinationPath);
                        }
                    }
                }
            }
            catch { }
            return false;
        }

        private List<Rule> LoadRules()
        {
            List<Rule> rules = new List<Rule>();
            try
            {
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(
                        "SELECT id, rule_name, ext_category, age_days, keyword_match, destination_subfolder " +
                        "FROM organization_rules WHERE is_active = 1 ORDER BY id ASC", conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Rule rule = new Rule
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Name = reader["rule_name"].ToString(),
                                ExtCategory = reader["ext_category"] != DBNull.Value ? reader["ext_category"].ToString() : null,
                                AgeDays = reader["age_days"] != DBNull.Value ? reader["age_days"].ToString() : null,
                                KeywordMatch = reader["keyword_match"] != DBNull.Value ? reader["keyword_match"].ToString() : null,
                                DestinationSubfolder = reader["destination_subfolder"].ToString()
                            };
                            rules.Add(rule);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading rules: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return rules;
        }

        private bool FileMatchesRule(string fileName, string extension, DateTime? modifiedDate, Rule rule)
        {
            bool extMatch = true;
            bool ageMatch = true;
            bool keywordMatch = true;

            if (!string.IsNullOrEmpty(rule.ExtCategory))
            {
                extMatch = false;
                List<string> exts = ParseExtensions(rule.ExtCategory);
                string extClean = extension.StartsWith(".") ? extension.Substring(1) : extension;
                foreach (string ext in exts)
                {
                    if (string.Equals(extClean, ext, StringComparison.OrdinalIgnoreCase))
                    {
                        extMatch = true;
                        break;
                    }
                }
            }

            if (!string.IsNullOrEmpty(rule.AgeDays))
            {
                ageMatch = false;
                if (modifiedDate.HasValue)
                {
                    var (minDays, maxDays) = ParseAgeDays(rule.AgeDays);
                    int ageInDays = (int)(DateTime.Now - modifiedDate.Value).TotalDays;

                    if (minDays.HasValue && ageInDays >= minDays.Value)
                        ageMatch = true;
                    if (maxDays.HasValue && ageInDays < maxDays.Value)
                        ageMatch = true;
                }
            }

            if (!string.IsNullOrEmpty(rule.KeywordMatch))
            {
                keywordMatch = fileName.IndexOf(rule.KeywordMatch, StringComparison.OrdinalIgnoreCase) >= 0;
            }

            return extMatch && ageMatch && keywordMatch;
        }

        private List<string> ParseExtensions(string extCategory)
        {
            List<string> exts = new List<string>();
            Match match = Regex.Match(extCategory, @"\(([^)]+)\)");
            if (match.Success)
            {
                string inner = match.Groups[1].Value;
                foreach (string item in inner.Split(','))
                {
                    exts.Add(item.Trim().TrimStart('.'));
                }
            }
            return exts;
        }

        private (int? minDays, int? maxDays) ParseAgeDays(string ageDays)
        {
            Match ltMatch = Regex.Match(ageDays, @"<\s*(\d+)");
            if (ltMatch.Success)
            {
                int days = int.Parse(ltMatch.Groups[1].Value);
                return (null, days);
            }

            Match gteMatch = Regex.Match(ageDays, ">=\\s*(\\d+)");
            if (gteMatch.Success)
            {
                int days = int.Parse(gteMatch.Groups[1].Value);
                return (days, null);
            }

            return (null, null);
        }

        private void PopulatePreviewTree()
        {
            tvDestinationPreview.Nodes.Clear();

            try
            {
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(
                        "SELECT DISTINCT predicted_destination FROM imported_files " +
                        "WHERE predicted_destination IS NOT NULL ORDER BY predicted_destination", conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        Dictionary<string, TreeNode> folderNodes = new Dictionary<string, TreeNode>();

                        while (reader.Read())
                        {
                            string fullPath = reader["predicted_destination"].ToString();
                            string relativePath = GetRelativePreviewPath(fullPath);
                            string[] parts = relativePath.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);

                            TreeNode parentNode = null;
                            string currentPath = "";

                            for (int i = 0; i < parts.Length - 1; i++)
                            {
                                currentPath = string.IsNullOrEmpty(currentPath) ? parts[i] : currentPath + "\\" + parts[i];
                                if (!folderNodes.ContainsKey(currentPath))
                                {
                                    TreeNode newNode = new TreeNode(parts[i]);
                                    newNode.Tag = Path.Combine(baseDestinationPath, currentPath);
                                    if (parentNode == null)
                                        tvDestinationPreview.Nodes.Add(newNode);
                                    else
                                        parentNode.Nodes.Add(newNode);
                                    folderNodes[currentPath] = newNode;
                                }
                                parentNode = folderNodes[currentPath];
                            }
                        }
                    }
                }

                if (tvDestinationPreview.Nodes.Count > 0)
                {
                    tvDestinationPreview.ExpandAll();
                    tvDestinationPreview.SelectedNode = tvDestinationPreview.Nodes[0];
                    PopulateContentsList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error building preview tree: " + ex.Message,
                    "Tree Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetRelativePreviewPath(string fullPath)
        {
            if (fullPath.StartsWith(baseDestinationPath, StringComparison.OrdinalIgnoreCase))
            {
                string rel = fullPath.Substring(baseDestinationPath.Length);
                return rel.TrimStart('\\');
            }
            return fullPath;
        }

        private void tvDestinationPreview_AfterSelect(object sender, TreeViewEventArgs e)
        {
            PopulateContentsList();
        }

        private void PopulateContentsList()
        {
            lvFolderContents.Items.Clear();

            if (tvDestinationPreview.SelectedNode == null)
                return;

            string selectedPath = tvDestinationPreview.SelectedNode.Tag?.ToString();
            if (string.IsNullOrEmpty(selectedPath))
                return;

            try
            {
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(
                        "SELECT file_name, file_extension, file_type FROM imported_files " +
                        "WHERE predicted_destination LIKE CONCAT(@path, '%') ESCAPE '|' ORDER BY file_name", conn))
                    {
                        cmd.Parameters.AddWithValue("@path", selectedPath);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string fileName = reader["file_name"].ToString();
                                string ext = reader["file_extension"] != DBNull.Value ? reader["file_extension"].ToString() : "";
                                string fileType = reader["file_type"].ToString();

                                ListViewItem item = new ListViewItem(fileName);

                                string imageKey = "GenericFile";
                                if (fileType == "Folder")
                                    imageKey = "Folder";
                                else if (!string.IsNullOrEmpty(ext))
                                {
                                    string extLower = ext.TrimStart('.').ToLower();
                                    if (extLower == "png" || extLower == "jpg" || extLower == "gif" || extLower == "jpeg" || extLower == "bmp")
                                        imageKey = "Image";
                                    else if (extLower == "mp4" || extLower == "mkv" || extLower == "avi" || extLower == "mov")
                                        imageKey = "Video";
                                    else if (extLower == "pdf" || extLower == "docx" || extLower == "txt" || extLower == "doc" || extLower == "xlsx")
                                        imageKey = "Document";
                                }

                                item.ImageKey = imageKey;
                                lvFolderContents.Items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading contents: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStats()
        {
            lblStatTotal.Text = $"📁 {totalFiles}";
            lblStatMatched.Text = $"✅ {matchedCount}";
            lblStatUnmatched.Text = $"⚠️ {unmatchedCount}";
        }

        private void btnExecuteOrganize_Click(object sender, EventArgs e)
        {
            if (!LoadBaseDestinationPath())
            {
                MessageBox.Show("No destination folder configured.", "Configuration Missing",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "This will " + (UseMoveOperation() ? "move" : "copy") +
                " all imported files to their predicted destinations.\n\n" +
                "• Matched files → rule-based subfolders\n" +
                "• Unmatched files → Unorganized_Items\n\n" +
                "Continue?",
                "Confirm Organization",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            btnExecuteOrganize.Enabled = false;
            btnPreparePreview.Enabled = false;

            int successCount = 0;
            int failCount = 0;

            try
            {
                List<(int id, string fileName, string sourcePath, string operationType, string predictedDest, long fileSize, string fileType)> fileList = new List<(int, string, string, string, string, long, string)>();

                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();

                    using (MySqlCommand countCmd = new MySqlCommand(
                        "SELECT COUNT(*) FROM imported_files WHERE predicted_destination IS NOT NULL AND (file_type = 'File' OR (file_type = 'Folder' AND is_excluded = 1))", conn))
                    {
                        int total = Convert.ToInt32(countCmd.ExecuteScalar());
                        if (total == 0)
                        {
                            MessageBox.Show("No files to organize. Run Prepare Preview first.",
                                "Nothing to Do", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        prgOrganizeProgress.Maximum = total;
                        prgOrganizeProgress.Value = 0;

                        using (MySqlCommand readCmd = new MySqlCommand(
                            "SELECT id, file_name, file_path, source_path, file_size, operation_type, predicted_destination, file_type " +
                            "FROM imported_files WHERE predicted_destination IS NOT NULL AND (file_type = 'File' OR (file_type = 'Folder' AND is_excluded = 1)) ORDER BY id", conn))
                        using (MySqlDataReader reader = readCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["id"]);
                                string fileName = reader["file_name"].ToString();
                                string filePath = reader["file_path"].ToString();
                                string sourcePath = reader["source_path"] != DBNull.Value ? reader["source_path"].ToString() : filePath;
                                string opType = reader["operation_type"].ToString();
                                string predDest = reader["predicted_destination"].ToString();
                                long size = reader["file_size"] != DBNull.Value ? Convert.ToInt64(reader["file_size"]) : 0;
                                string fileType = reader["file_type"].ToString();
                                fileList.Add((id, fileName, sourcePath, opType, predDest, size, fileType));
                            }
                        }
                    }
                }

                int index = 0;
                bool isMove = UseMoveOperation();
                string executionId = GenerateExecutionId();

                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();

                    foreach (var file in fileList)
                    {
                        index++;
                        bool isFolder = file.fileType == "Folder";
                        lblProgressStatus.Text = $"[{index}/{fileList.Count}] {(isMove ? "Moving" : "Copying")}: {file.fileName}";
                        prgOrganizeProgress.Value = Math.Min(index, fileList.Count);
                        Application.DoEvents();

                        string status = "SUCCESS";
                        string errorMsg = null;

                        try
                        {
                            if (isFolder)
                            {
                                if (!Directory.Exists(file.sourcePath))
                                    throw new DirectoryNotFoundException($"Source folder not found: {file.sourcePath}");

                                if (isMove)
                                {
                                    if (Directory.Exists(file.predictedDest))
                                        Directory.Delete(file.predictedDest, recursive: true);
                                    Directory.Move(file.sourcePath, file.predictedDest);
                                }
                                else
                                {
                                    CopyDirectoryRecursive(file.sourcePath, file.predictedDest);
                                }
                            }
                            else
                            {
                                string destDir = Path.GetDirectoryName(file.predictedDest);
                                if (!string.IsNullOrEmpty(destDir) && !Directory.Exists(destDir))
                                    Directory.CreateDirectory(destDir);

                                if (!File.Exists(file.sourcePath))
                                    throw new FileNotFoundException($"Source file not found: {file.sourcePath}");

                                if (isMove)
                                {
                                    if (File.Exists(file.predictedDest))
                                        File.Delete(file.predictedDest);
                                    File.Move(file.sourcePath, file.predictedDest);
                                }
                                else
                                {
                                    File.Copy(file.sourcePath, file.predictedDest, overwrite: true);
                                }
                            }

                            successCount++;
                        }
                        catch (Exception ex)
                        {
                            status = "FAILED";
                            errorMsg = ex.Message;
                            failCount++;
                        }

                        using (MySqlCommand logCmd = new MySqlCommand(
                            "INSERT INTO operation_history (execution_id, operation_type, file_name, source_path, destination_path, file_size, status) " +
                            "VALUES (@execId, @opType, @name, @source, @dest, @size, @status)", conn))
                        {
                            logCmd.Parameters.AddWithValue("@execId", executionId);
                            logCmd.Parameters.AddWithValue("@opType", isMove ? "Move" : "Copy");
                            logCmd.Parameters.AddWithValue("@name", file.fileName);
                            logCmd.Parameters.AddWithValue("@source", TruncatePath(file.sourcePath, 500));
                            logCmd.Parameters.AddWithValue("@dest", TruncatePath(file.predictedDest, 500));
                            logCmd.Parameters.AddWithValue("@size", file.fileSize);
                            logCmd.Parameters.AddWithValue("@status", status + (errorMsg != null ? ": " + errorMsg : ""));
                            logCmd.ExecuteNonQuery();
                        }

                        using (MySqlCommand updateCmd = new MySqlCommand(
                            "UPDATE imported_files SET destination_path = @dest WHERE id = @id", conn))
                        {
                            updateCmd.Parameters.AddWithValue("@dest", file.predictedDest);
                            updateCmd.Parameters.AddWithValue("@id", file.id);
                            updateCmd.ExecuteNonQuery();
                        }
                    }

                    using (MySqlCommand archiveCmd = new MySqlCommand(
                        "INSERT INTO destination_file_data (execution_id, file_name, file_extension, file_size, file_modified_date, file_type, is_excluded, operation_type, source_path, destination_path) " +
                        "SELECT @execId, file_name, file_extension, file_size, file_modified_date, file_type, is_excluded, operation_type, source_path, destination_path " +
                        "FROM imported_files WHERE predicted_destination IS NOT NULL", conn))
                    {
                        archiveCmd.Parameters.AddWithValue("@execId", executionId);
                        archiveCmd.ExecuteNonQuery();
                    }

                    using (MySqlCommand clearCmd = new MySqlCommand(
                        "DELETE FROM imported_files WHERE predicted_destination IS NOT NULL", conn))
                    {
                        clearCmd.ExecuteNonQuery();
                    }
                }

                lblProgressStatus.Text = $"Organization complete — {successCount} succeeded, {failCount} failed.";
                MessageBox.Show(
                    $"Organization {(isMove ? "move" : "copy")} completed.\n\n" +
                    $"✓ Successful: {successCount}\n" +
                    $"✗ Failed: {failCount}",
                    "Organization Complete",
                    MessageBoxButtons.OK,
                    failCount > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during organization: " + ex.Message,
                    "Organization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnExecuteOrganize.Enabled = true;
                btnPreparePreview.Enabled = true;
            }
        }

        private bool UseMoveOperation()
        {
            try
            {
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(
                        "SELECT operation_type FROM imported_files WHERE operation_type IS NOT NULL LIMIT 1", conn))
                    {
                        object result = cmd.ExecuteScalar();
                        return result != null && result.ToString().Equals("Move", StringComparison.OrdinalIgnoreCase);
                    }
                }
            }
            catch { }
            return false;
        }

        private string TruncatePath(string path, int maxLen)
        {
            if (string.IsNullOrEmpty(path) || path.Length <= maxLen)
                return path;
            return path.Substring(0, maxLen);
        }

        private static void CopyDirectoryRecursive(string sourceDir, string destDir)
        {
            Directory.CreateDirectory(destDir);
            foreach (string file in Directory.GetFiles(sourceDir))
            {
                string dest = Path.Combine(destDir, Path.GetFileName(file));
                File.Copy(file, dest, overwrite: true);
            }
            foreach (string dir in Directory.GetDirectories(sourceDir))
            {
                string dest = Path.Combine(destDir, Path.GetFileName(dir));
                CopyDirectoryRecursive(dir, dest);
            }
        }

        private string GenerateExecutionId()
        {
            try
            {
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(
                        "SELECT COALESCE(MAX(CAST(SUBSTRING(execution_id, 4) AS UNSIGNED)), 0) + 1 " +
                        "FROM operation_history WHERE execution_id LIKE 'exe%'", conn))
                    {
                        object result = cmd.ExecuteScalar();
                        int num = result != null ? Convert.ToInt32(result) : 1;
                        return "exe" + num;
                    }
                }
            }
            catch
            {
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT COALESCE(MAX(id), 0) + 1 FROM operation_history", conn))
                    {
                        return "exe" + Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
        }

        private void lblProgressStatus_Click(object sender, EventArgs e)
        {

        }
    }
}
