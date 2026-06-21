using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MySql.Data.MySqlClient;

namespace SmartFileOrganizer
{
    public partial class FormDashboardAnalytics : Form
    {
        public event EventHandler NavigateToFolderSelection;
        public event EventHandler NavigateToConfigureRules;
        public event EventHandler NavigateToDuplicateFinder;

        private bool _startupChecksDone = false;

        private static readonly Color[] CardColors = new[]
        {
            Color.FromArgb(74, 144, 217),   // Blue
            Color.FromArgb(39, 174, 96),    // Green
            Color.FromArgb(243, 156, 18),   // Orange
            Color.FromArgb(231, 76, 60),    // Red
            Color.FromArgb(142, 68, 173)    // Purple
        };

        private static readonly Dictionary<string, string> ExtensionCategories = new Dictionary<string, string>
        {
            { "pdf", "Documents" }, { "doc", "Documents" }, { "docx", "Documents" },
            { "xls", "Documents" }, { "xlsx", "Documents" }, { "ppt", "Documents" },
            { "pptx", "Documents" }, { "txt", "Documents" }, { "rtf", "Documents" },
            { "odt", "Documents" }, { "ods", "Documents" }, { "csv", "Documents" },
            { "jpg", "Images" }, { "jpeg", "Images" }, { "png", "Images" },
            { "gif", "Images" }, { "bmp", "Images" }, { "svg", "Images" },
            { "webp", "Images" }, { "ico", "Images" }, { "tiff", "Images" },
            { "mp4", "Video" }, { "avi", "Video" }, { "mkv", "Video" },
            { "mov", "Video" }, { "wmv", "Video" }, { "flv", "Video" },
            { "webm", "Video" }, { "mp3", "Audio" }, { "wav", "Audio" },
            { "flac", "Audio" }, { "aac", "Audio" }, { "ogg", "Audio" },
            { "wma", "Audio" }, { "m4a", "Audio" },
            { "zip", "Archives" }, { "rar", "Archives" }, { "7z", "Archives" },
            { "tar", "Archives" }, { "gz", "Archives" }, { "bz2", "Archives" }
        };

        public FormDashboardAnalytics()
        {
            InitializeComponent();
        }

        public void RefreshData()
        {
            RunStartupChecks();
            LoadSummaryCards();
            LoadDestinationInfo();
            LoadPieChart();
            LoadColumnChart();
        }

        private string GetSetting(string key, string defaultValue)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT setting_value FROM app_settings WHERE setting_key = @key LIMIT 1", conn))
                    {
                        cmd.Parameters.AddWithValue("@key", key);
                        object result = cmd.ExecuteScalar();
                        return result?.ToString() ?? defaultValue;
                    }
                }
            }
            catch
            {
                return defaultValue;
            }
        }

        private void LoadSummaryCards()
        {
            try
            {
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();

                    string totalFilesQuery = "SELECT setting_value FROM app_settings WHERE setting_key = 'total_files_imported' LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(totalFilesQuery, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        string val = result?.ToString() ?? "0";
                        lblTotalFilesValue.Text = int.TryParse(val, out int n) ? n.ToString("N0") : val;
                    }

                    string organizedQuery = "SELECT COUNT(*) FROM operation_history WHERE status = 'SUCCESS'";
                    using (MySqlCommand cmd = new MySqlCommand(organizedQuery, conn))
                    {
                        lblOrganizedValue.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString("N0");
                    }

                    string rulesQuery = "SELECT COUNT(*) FROM organization_rules WHERE is_active = 1";
                    using (MySqlCommand cmd = new MySqlCommand(rulesQuery, conn))
                    {
                        lblRulesValue.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString("N0");
                    }
                }

                string dupSets = GetSetting("last_dup_sets_count", "0");
                string wastedBytes = GetSetting("last_dup_wasted_bytes", "0");
                lblDupsValue.Text = int.TryParse(dupSets, out int ds) ? ds.ToString("N0") : dupSets;
                lblWasteValue.Text = FormatSize(long.TryParse(wastedBytes, out long wb) ? wb : 0);
            }
            catch
            {
                lblTotalFilesValue.Text = "—";
                lblOrganizedValue.Text = "—";
                lblRulesValue.Text = "—";
                lblDupsValue.Text = "—";
                lblWasteValue.Text = "—";
            }
        }

        private static string FormatSize(long bytes)
        {
            if (bytes < 1024) return $"{bytes} B";
            if (bytes < 1024 * 1024) return $"{bytes / 1024.0:F1} KB";
            if (bytes < 1024 * 1024 * 1024) return $"{bytes / (1024.0 * 1024):F1} MB";
            return $"{bytes / (1024.0 * 1024 * 1024):F2} GB";
        }

        private void RunStartupChecks()
        {
            if (_startupChecksDone)
                return;
            _startupChecksDone = true;

            string verifySetting = GetSetting("scan_verification_at_startup", "true");
            string dupSetting = GetSetting("scan_duplicates_at_startup", "false");

            bool verifyFiles = verifySetting == "true";
            bool scanDups = dupSetting == "true";

            lblProgressStatus.Text = "Ready";
            progressBar.Value = 0;

            if (!verifyFiles && !scanDups)
                return;

            progressBar.Style = ProgressBarStyle.Marquee;
            lblProgressStatus.Text = "Starting startup checks...";
            Application.DoEvents();

            if (verifyFiles)
            {
                lblProgressStatus.Text = "🔍 Performing file validity scan...";
                progressBar.Style = ProgressBarStyle.Blocks;
                Application.DoEvents();
                VerifyDestinationFiles();
            }

            if (scanDups)
            {
                lblProgressStatus.Text = "🔎 Performing automatic duplicate scan...";
                progressBar.Style = ProgressBarStyle.Marquee;
                Application.DoEvents();
                ScanDuplicatesAtStartup();
            }

            progressBar.Value = 0;

            string dupSets = GetSetting("last_dup_sets_count", "0");
            string wastedBytes = GetSetting("last_dup_wasted_bytes", "0");
            lblProgressStatus.Text = $"✓ Scan done. Duplicates: {dupSets} sets, {FormatSize(long.TryParse(wastedBytes, out long wb) ? wb : 0)} wasted.";
        }

        private void VerifyDestinationFiles()
        {
            try
            {
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    string countQuery = "SELECT COUNT(*) FROM destination_file_data WHERE destination_path IS NOT NULL";
                    int total;
                    using (MySqlCommand cmd = new MySqlCommand(countQuery, conn))
                    {
                        total = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    if (total == 0) return;

                    progressBar.Maximum = total;
                    progressBar.Value = 0;

                    List<int> idsToDelete = new List<int>();
                    int processed = 0;

                    using (MySqlCommand cmd = new MySqlCommand(
                        "SELECT id, destination_path FROM destination_file_data WHERE destination_path IS NOT NULL", conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["id"]);
                            string path = reader["destination_path"].ToString();
                            if (!File.Exists(path))
                                idsToDelete.Add(id);

                            processed++;
                            progressBar.Value = Math.Min(processed, total);
                            if (processed % 10 == 0)
                            {
                                lblProgressStatus.Text = $"Verifying {processed}/{total}...";
                                Application.DoEvents();
                            }
                        }
                    }

                    if (idsToDelete.Count > 0)
                    {
                        foreach (int id in idsToDelete)
                        {
                            using (MySqlCommand del = new MySqlCommand("DELETE FROM destination_file_data WHERE id = @id", conn))
                            {
                                del.Parameters.AddWithValue("@id", id);
                                del.ExecuteNonQuery();
                            }
                        }
                    }

                    lblProgressStatus.Text = $"Verified {total} files, removed {idsToDelete.Count} missing entries.";
                    Application.DoEvents();
                }
            }
            catch
            {
            }
        }

        private void ScanDuplicatesAtStartup()
        {
            try
            {
                var allFiles = new List<DupFileEntry>();

                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    string countQuery = "SELECT COUNT(*) FROM destination_file_data WHERE destination_path IS NOT NULL";
                    int total;
                    using (MySqlCommand cmd = new MySqlCommand(countQuery, conn))
                    {
                        total = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    if (total == 0) return;

                    progressBar.Style = ProgressBarStyle.Blocks;
                    progressBar.Maximum = total;
                    progressBar.Value = 0;

                    using (MySqlCommand cmd = new MySqlCommand(
                        "SELECT id, file_name, file_extension, file_size, destination_path, file_hash FROM destination_file_data " +
                        "WHERE destination_path IS NOT NULL ORDER BY file_name", conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string destPath = reader["destination_path"].ToString();
                            if (!File.Exists(destPath))
                                continue;

                            allFiles.Add(new DupFileEntry
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                FileName = reader["file_name"].ToString(),
                                Extension = reader["file_extension"] != DBNull.Value ? reader["file_extension"].ToString() : "",
                                FileSize = reader["file_size"] != DBNull.Value ? Convert.ToInt64(reader["file_size"]) : 0,
                                DestPath = destPath,
                                Hash = reader["file_hash"] != DBNull.Value ? reader["file_hash"].ToString() : null
                            });
                        }
                    }
                }

                if (allFiles.Count == 0) return;

                var hashGroups = new Dictionary<string, List<DupFileEntry>>();

                for (int i = 0; i < allFiles.Count; i++)
                {
                    var file = allFiles[i];
                    progressBar.Value = Math.Min(i + 1, allFiles.Count);
                    lblProgressStatus.Text = $"Hashing [{i + 1}/{allFiles.Count}]: {file.FileName}";
                    Application.DoEvents();

                    string hash = file.Hash;
                    if (string.IsNullOrEmpty(hash))
                    {
                        hash = ComputeMD5(file.DestPath);
                        if (hash == null) continue;

                        using (MySqlConnection conn = DatabaseConfig.GetConnection())
                        {
                            conn.Open();
                            using (MySqlCommand updateCmd = new MySqlCommand(
                                "UPDATE destination_file_data SET file_hash = @hash WHERE id = @id", conn))
                            {
                                updateCmd.Parameters.AddWithValue("@hash", hash);
                                updateCmd.Parameters.AddWithValue("@id", file.Id);
                                updateCmd.ExecuteNonQuery();
                            }
                        }
                        file.Hash = hash;
                    }

                    if (!hashGroups.ContainsKey(hash))
                        hashGroups[hash] = new List<DupFileEntry>();
                    hashGroups[hash].Add(file);
                }

                int setCount = 0;
                int dupFileCount = 0;
                long wastedBytes = 0;

                foreach (var kvp in hashGroups)
                {
                    if (kvp.Value.Count > 1)
                    {
                        setCount++;
                        dupFileCount += kvp.Value.Count - 1;
                        wastedBytes += kvp.Value.Skip(1).Sum(f => f.FileSize);
                    }
                }

                SaveDuplicateStats(setCount, dupFileCount, wastedBytes);

                lblProgressStatus.Text = $"Duplicate scan complete: {setCount} sets, {FormatSize(wastedBytes)} wasted.";
                progressBar.Value = 0;
                Application.DoEvents();
            }
            catch
            {
            }
        }

        private void SaveDuplicateStats(int setCount, int dupFileCount, long wastedBytes)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    string query = @"INSERT INTO app_settings (setting_key, setting_value, updated_at) VALUES (@key, @value, NOW())
                                     ON DUPLICATE KEY UPDATE setting_value = @value, updated_at = NOW()";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@key", "last_dup_sets_count");
                        cmd.Parameters.AddWithValue("@value", setCount.ToString());
                        cmd.ExecuteNonQuery();
                    }
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@key", "last_dup_files_count");
                        cmd.Parameters.AddWithValue("@value", dupFileCount.ToString());
                        cmd.ExecuteNonQuery();
                    }
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@key", "last_dup_wasted_bytes");
                        cmd.Parameters.AddWithValue("@value", wastedBytes.ToString());
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
            }
        }

        private static string ComputeMD5(string filePath)
        {
            try
            {
                using (var md5 = System.Security.Cryptography.MD5.Create())
                using (var stream = File.OpenRead(filePath))
                {
                    byte[] hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLower();
                }
            }
            catch
            {
                return null;
            }
        }

        private class DupFileEntry
        {
            public int Id { get; set; }
            public string FileName { get; set; }
            public string Extension { get; set; }
            public long FileSize { get; set; }
            public string DestPath { get; set; }
            public string Hash { get; set; }
        }

        private void LoadDestinationInfo()
        {
            try
            {
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT setting_value FROM app_settings WHERE setting_key = 'destination_folder_path' LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        string path = result?.ToString() ?? "";
                        lblDestinationPath.Text = string.IsNullOrEmpty(path) ? "Not configured" : path;

                        if (!string.IsNullOrEmpty(path) && Directory.Exists(path))
                        {
                            DriveInfo drive = new DriveInfo(Path.GetPathRoot(path));
                            if (drive.IsReady)
                            {
                                long freeBytes = drive.AvailableFreeSpace;
                                long totalBytes = drive.TotalSize;
                                double freeGB = freeBytes / (1024.0 * 1024.0 * 1024.0);
                                double totalGB = totalBytes / (1024.0 * 1024.0 * 1024.0);
                                lblDriveSpace.Text = $"Free: {freeGB:F1} GB of {totalGB:F1} GB";
                            }
                            else
                            {
                                lblDriveSpace.Text = "Drive not ready";
                            }
                        }
                        else
                        {
                            lblDriveSpace.Text = "Path unavailable";
                        }
                    }
                }
            }
            catch
            {
                lblDestinationPath.Text = "—";
                lblDriveSpace.Text = "—";
            }
        }

        private void LoadPieChart()
        {
            Dictionary<string, int> categoryCounts = new Dictionary<string, int>();
            int otherCount = 0;

            try
            {
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT LOWER(file_extension) as ext, COUNT(*) as cnt FROM destination_file_data WHERE file_extension IS NOT NULL AND file_extension != '' GROUP BY LOWER(file_extension) ORDER BY cnt DESC";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string ext = reader["ext"].ToString().TrimStart('.');
                                int count = Convert.ToInt32(reader["cnt"]);

                                if (ExtensionCategories.TryGetValue(ext, out string category))
                                {
                                    if (categoryCounts.ContainsKey(category))
                                        categoryCounts[category] += count;
                                    else
                                        categoryCounts[category] = count;
                                }
                                else
                                {
                                    otherCount += count;
                                }
                            }
                        }
                    }
                }
            }
            catch { }

            if (otherCount > 0)
                categoryCounts["Other"] = otherCount;

            chartFilesByType.Series.Clear();
            chartFilesByType.Legends.Clear();

            if (categoryCounts.Count == 0)
            {
                chartFilesByType.Titles.Clear();
                chartFilesByType.Titles.Add("No data available");
                return;
            }

            Series series = new Series("FilesByType");
            series.ChartType = SeriesChartType.Pie;
            series.IsValueShownAsLabel = true;
            series.LabelFormat = "#.#%";
            series.Font = new Font("Segoe UI", 8F);
            series.BorderColor = Color.White;
            series.BorderWidth = 2;

            double total = categoryCounts.Values.Sum();
            foreach (var kvp in categoryCounts)
            {
                int pointIndex = series.Points.AddXY(kvp.Key, kvp.Value);
                series.Points[pointIndex].LegendText = $"{kvp.Key} ({kvp.Value:N0})";
                series.Points[pointIndex].Label = $"{kvp.Value / total * 100:F1}%";
                series.Points[pointIndex].Color = GetCategoryColor(kvp.Key);
            }

            chartFilesByType.Series.Add(series);

            Legend legend = new Legend("Legend");
            legend.Docking = Docking.Right;
            legend.Font = new Font("Segoe UI", 9F);
            legend.BackColor = Color.Transparent;
            chartFilesByType.Legends.Add(legend);

            chartFilesByType.ChartAreas[0].Area3DStyle.Enable3D = false;
        }

        private void LoadColumnChart()
        {
            Dictionary<string, int> dailyCounts = new Dictionary<string, int>();

            try
            {
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT DATE(performed_at) as day, COUNT(*) as cnt
                                     FROM operation_history
                                     WHERE performed_at >= DATE_SUB(CURDATE(), INTERVAL 7 DAY)
                                     GROUP BY DATE(performed_at)
                                     ORDER BY day";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime day = Convert.ToDateTime(reader["day"]);
                                int count = Convert.ToInt32(reader["cnt"]);
                                string label = day.ToString("ddd");
                                dailyCounts[label] = count;
                            }
                        }
                    }
                }
            }
            catch { }

            string[] dayNames = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            for (int i = 6; i >= 0; i--)
            {
                string label = DateTime.Now.AddDays(-i).ToString("ddd");
                if (!dailyCounts.ContainsKey(label))
                    dailyCounts[label] = 0;
            }

            chartOpsLast7Days.Series.Clear();
            chartOpsLast7Days.Legends.Clear();

            Series series = new Series("Operations");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = false;
            series.Font = new Font("Segoe UI", 9F);
            series.Color = Color.FromArgb(74, 144, 217);
            series.BorderColor = Color.FromArgb(52, 73, 94);
            series.BorderWidth = 1;

            foreach (var day in dayNames)
            {
                if (dailyCounts.ContainsKey(day))
                {
                    int pointIndex = series.Points.AddXY(day, dailyCounts[day]);
                    series.Points[pointIndex].Label = dailyCounts[day].ToString();
                    series.Points[pointIndex].Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
            }

            chartOpsLast7Days.Series.Add(series);

            ChartArea area = chartOpsLast7Days.ChartAreas[0];
            area.AxisX.Interval = 1;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 9F);
            area.AxisY.MajorGrid.LineColor = Color.FromArgb(220, 220, 220);
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 9F);
            area.AxisY.Title = "Files";
            area.AxisY.TitleFont = new Font("Segoe UI", 9F);

            if (dailyCounts.Values.Max() > 0)
                area.AxisY.Maximum = dailyCounts.Values.Max() * 1.2;
        }

        private static Color GetCategoryColor(string category)
        {
            switch (category)
            {
                case "Documents": return Color.FromArgb(74, 144, 217);
                case "Images": return Color.FromArgb(39, 174, 96);
                case "Video": return Color.FromArgb(231, 76, 60);
                case "Audio": return Color.FromArgb(142, 68, 173);
                case "Archives": return Color.FromArgb(243, 156, 18);
                default: return Color.FromArgb(149, 165, 166);
            }
        }

        private void btnNavImport_Click(object sender, EventArgs e)
        {
            NavigateToFolderSelection?.Invoke(this, EventArgs.Empty);
        }

        private void btnNavRules_Click(object sender, EventArgs e)
        {
            NavigateToConfigureRules?.Invoke(this, EventArgs.Empty);
        }

        private void btnNavDuplicates_Click(object sender, EventArgs e)
        {
            NavigateToDuplicateFinder?.Invoke(this, EventArgs.Empty);
        }

        private void FormDashboardAnalytics_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
