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
                Color.FromArgb(255, 200, 80), "F", Color.Brown, imgList.ImageSize.Width));
            imgList.Images.Add("Document", CreatePlaceholderIcon(
                Color.FromArgb(100, 160, 230), "D", Color.White, imgList.ImageSize.Width));
            imgList.Images.Add("Image", CreatePlaceholderIcon(
                Color.FromArgb(100, 200, 120), "I", Color.White, imgList.ImageSize.Width));
            imgList.Images.Add("Video", CreatePlaceholderIcon(
                Color.FromArgb(200, 100, 160), "V", Color.White, imgList.ImageSize.Width));
            imgList.Images.Add("GenericFile", CreatePlaceholderIcon(
                Color.FromArgb(180, 180, 180), "F", Color.White, imgList.ImageSize.Width));
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
                using (Brush brush = new SolidBrush(Color.FromArgb(255, 200, 80)))
                {
                    g.FillRectangle(brush, 1, 3, 14, 12);
                }
                g.DrawRectangle(Pens.Brown, 1, 3, 14, 12);
            }
            imgList.Images.Add(folderIcon);

            Bitmap fileIcon = new Bitmap(imgList.ImageSize.Width, imgList.ImageSize.Height);
            using (Graphics g = Graphics.FromImage(fileIcon))
            {
                g.Clear(Color.Transparent);
                using (Brush brush = new SolidBrush(Color.FromArgb(100, 160, 230)))
                {
                    g.FillRectangle(brush, 2, 2, 12, 12);
                }
                g.DrawRectangle(Pens.DarkBlue, 2, 2, 12, 12);
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
                        "SELECT COUNT(*) FROM imported_files WHERE file_type = 'File'", conn))
                    {
                        totalFiles = Convert.ToInt32(countCmd.ExecuteScalar());
                    }

                    if (totalFiles == 0)
                    {
                        lblProgressStatus.Text = "No files to process. Import files first.";
                        return;
                    }

                    prgOrganizeProgress.Maximum = totalFiles;
                    prgOrganizeProgress.Value = 0;

                    matchedCount = 0;
                    unmatchedCount = 0;
                    UpdateStats();

                    using (MySqlCommand readCmd = new MySqlCommand(
                        "SELECT id, file_name, file_extension, file_modified_date FROM imported_files WHERE file_type = 'File' ORDER BY id ASC", conn))
                    using (MySqlDataReader reader = readCmd.ExecuteReader())
                    {
                        List<(int id, string predicted, bool matched)> updates = new List<(int, string, bool)>();
                        int index = 0;

                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["id"]);
                            string fileName = reader["file_name"].ToString();
                            string extension = reader["file_extension"] != DBNull.Value ? reader["file_extension"].ToString() : "";
                            DateTime? modifiedDate = reader["file_modified_date"] != DBNull.Value
                                ? Convert.ToDateTime(reader["file_modified_date"]) : (DateTime?)null;

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
                        "SELECT destination_folder_path FROM app_settings ORDER BY id DESC LIMIT 1", conn))
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

        }

        private void lblProgressStatus_Click(object sender, EventArgs e)
        {

        }
    }
}
