using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SmartFileOrganizer
{
    public partial class FormDuplicateFinder : Form
    {
        private class DupFile
        {
            public int Id { get; set; }
            public string FileName { get; set; }
            public string Extension { get; set; }
            public long FileSize { get; set; }
            public string DestPath { get; set; }
            public string Hash { get; set; }
        }

        private class DupSet
        {
            public List<DupFile> Files { get; set; }
            public string MatchKey { get; set; }
            public long WastedBytes { get; set; }
        }

        private List<DupSet> duplicateSets = new List<DupSet>();
        private int currentSetIndex = 0;
        private FlowLayoutPanel flpFileList;

        public FormDuplicateFinder()
        {
            InitializeComponent();
            InitFileListPanel();
        }

        private void InitFileListPanel()
        {
            flpFileList = new FlowLayoutPanel();
            flpFileList.FlowDirection = FlowDirection.TopDown;
            flpFileList.AutoScroll = true;
            flpFileList.WrapContents = false;
            flpFileList.BorderStyle = BorderStyle.None;
            flpFileList.Location = new System.Drawing.Point(12, 50);
            flpFileList.Width = panelRightCard.ClientSize.Width - 30;
            flpFileList.Height = panelRightCard.ClientSize.Height - 60;
            flpFileList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelRightCard.Controls.Add(flpFileList);
            flpFileList.BringToFront();
        }

        private void FormDuplicateFinder_Load(object sender, EventArgs e)
        {
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            btnScan.Enabled = false;
            btnDeleteSelected.Enabled = false;
            btnPrev.Enabled = false;
            btnNext.Enabled = false;

            duplicateSets.Clear();
            currentSetIndex = 0;
            flpFileList.Controls.Clear();

            try
            {
                string method = cboMethod.SelectedItem.ToString();

                if (method == "Hash (MD5)")
                    ScanByHash();
                else if (method == "Name + Size")
                    ScanByGrouping("name_size");
                else if (method == "Name Only")
                    ScanByGrouping("name");
                else if (method == "Size Only")
                    ScanByGrouping("size");

                UpdateSummary();

                if (duplicateSets.Count > 0)
                {
                    currentSetIndex = 0;
                    ShowSet(0);
                    btnPrev.Enabled = false;
                    btnNext.Enabled = duplicateSets.Count > 1;
                }
                else
                {
                    lblSetNav.Text = "No duplicates found";
                    lblStatus.Text = "Scan complete — no duplicates found.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during scan: " + ex.Message,
                    "Scan Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnScan.Enabled = true;
                btnDeleteSelected.Enabled = duplicateSets.Count > 0;
            }
        }

        private void ScanByGrouping(string groupType)
        {
            List<DupFile> allFiles = new List<DupFile>();

            using (MySqlConnection conn = DatabaseConfig.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(
                    "SELECT id, file_name, file_extension, file_size, destination_path FROM destination_file_data " +
                    "WHERE destination_path IS NOT NULL ORDER BY file_name", conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string destPath = reader["destination_path"].ToString();
                        if (!File.Exists(destPath))
                            continue;

                        allFiles.Add(new DupFile
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            FileName = reader["file_name"].ToString(),
                            Extension = reader["file_extension"] != DBNull.Value ? reader["file_extension"].ToString() : "",
                            FileSize = reader["file_size"] != DBNull.Value ? Convert.ToInt64(reader["file_size"]) : 0,
                            DestPath = destPath
                        });
                    }
                }
            }

            prgScanProgress.Maximum = allFiles.Count;
            prgScanProgress.Value = 0;
            lblStatus.Text = $"Scanning {allFiles.Count} files...";
            Application.DoEvents();

            var groups = new Dictionary<string, List<DupFile>>();
            foreach (DupFile file in allFiles)
            {
                string key;
                if (groupType == "name_size")
                    key = file.FileName.ToLower() + "|" + file.FileSize;
                else if (groupType == "name")
                    key = file.FileName.ToLower();
                else
                    key = file.FileSize.ToString();

                if (!groups.ContainsKey(key))
                    groups[key] = new List<DupFile>();
                groups[key].Add(file);

                prgScanProgress.Value = Math.Min(prgScanProgress.Value + 1, allFiles.Count);
                if (prgScanProgress.Value % 10 == 0)
                    Application.DoEvents();
            }

            foreach (var kvp in groups)
            {
                if (kvp.Value.Count > 1)
                {
                    long wasted = kvp.Value.Skip(1).Sum(f => f.FileSize);
                    duplicateSets.Add(new DupSet
                    {
                        Files = kvp.Value.OrderBy(f => f.Id).ToList(),
                        MatchKey = kvp.Key,
                        WastedBytes = wasted
                    });
                }
            }
        }

        private void ScanByHash()
        {
            List<DupFile> allFiles = new List<DupFile>();

            using (MySqlConnection conn = DatabaseConfig.GetConnection())
            {
                conn.Open();
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

                        allFiles.Add(new DupFile
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

            prgScanProgress.Maximum = allFiles.Count;
            prgScanProgress.Value = 0;

            var hashGroups = new Dictionary<string, List<DupFile>>();

            for (int i = 0; i < allFiles.Count; i++)
            {
                var file = allFiles[i];
                prgScanProgress.Value = i + 1;
                lblStatus.Text = $"Hashing [{i + 1}/{allFiles.Count}]: {file.FileName}";
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
                    hashGroups[hash] = new List<DupFile>();
                hashGroups[hash].Add(file);
            }

            foreach (var kvp in hashGroups)
            {
                if (kvp.Value.Count > 1)
                {
                    long wasted = kvp.Value.Skip(1).Sum(f => f.FileSize);
                    duplicateSets.Add(new DupSet
                    {
                        Files = kvp.Value.OrderBy(f => f.Id).ToList(),
                        MatchKey = "MD5: " + kvp.Key.Substring(0, 8) + "...",
                        WastedBytes = wasted
                    });
                }
            }
        }

        private string ComputeMD5(string filePath)
        {
            try
            {
                using (var md5 = MD5.Create())
                using (var stream = File.OpenRead(filePath))
                {
                    byte[] hashBytes = md5.ComputeHash(stream);
                    StringBuilder sb = new StringBuilder();
                    foreach (byte b in hashBytes)
                        sb.Append(b.ToString("x2"));
                    return sb.ToString();
                }
            }
            catch
            {
                return null;
            }
        }

        private void UpdateSummary()
        {
            int totalFiles = 0;
            int totalDupFiles = 0;
            long wastedSpace = 0;

            foreach (var set in duplicateSets)
            {
                totalFiles += set.Files.Count;
                totalDupFiles += set.Files.Count - 1;
                wastedSpace += set.WastedBytes;
            }

            int scanned = 0;
            using (MySqlConnection conn = DatabaseConfig.GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(
                    "SELECT COUNT(*) FROM destination_file_data WHERE destination_path IS NOT NULL", conn))
                {
                    scanned = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            lblTotalFiles.Text = "Total files scanned: " + scanned;
            lblDupSets.Text = "Duplicate sets: " + duplicateSets.Count;
            lblTotalDupFiles.Text = "Duplicate files: " + totalDupFiles;
            lblWastedSpace.Text = "Wasted space: " + FormatSize(wastedSpace);

            SaveDuplicateStatsToDb(duplicateSets.Count, totalDupFiles, wastedSpace);
        }

        private void SaveDuplicateStatsToDb(int setCount, int dupFileCount, long wastedBytes)
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

        private void ShowSet(int index)
        {
            flpFileList.Controls.Clear();

            if (index < 0 || index >= duplicateSets.Count)
                return;

            var set = duplicateSets[index];
            lblSetNav.Text = $"Set {index + 1} of {duplicateSets.Count}";

            for (int i = 0; i < set.Files.Count; i++)
            {
                var file = set.Files[i];
                string label = $"{file.FileName}  ({FormatSize(file.FileSize)})";
                if (i == 0)
                    label += "  [Original]";
                else
                    label += "  [Duplicate]";

                CheckBox chk = new CheckBox();
                chk.Text = label;
                chk.Tag = file;
                chk.AutoSize = true;
                chk.Font = new Font("Segoe UI", 9F);
                chk.Margin = new Padding(4, 3, 4, 3);
                chk.MaximumSize = new Size(flpFileList.Width - 20, 0);

                if (i > 0)
                    chk.Checked = true;

                flpFileList.Controls.Add(chk);
            }

            btnPrev.Enabled = index > 0;
            btnNext.Enabled = index < duplicateSets.Count - 1;
            btnDeleteSelected.Enabled = true;
            lblStatus.Text = $"Set {index + 1} of {duplicateSets.Count} — {set.Files.Count} files, {FormatSize(set.WastedBytes)} can be reclaimed";
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentSetIndex > 0)
            {
                currentSetIndex--;
                ShowSet(currentSetIndex);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentSetIndex < duplicateSets.Count - 1)
            {
                currentSetIndex++;
                ShowSet(currentSetIndex);
            }
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            if (duplicateSets.Count == 0)
                return;

            var checkedFiles = new List<DupFile>();
            foreach (Control ctrl in flpFileList.Controls)
            {
                if (ctrl is CheckBox chk && chk.Checked && chk.Tag is DupFile file)
                    checkedFiles.Add(file);
            }

            if (checkedFiles.Count == 0)
            {
                MessageBox.Show("No files selected. Check the boxes next to files you want to delete.",
                    "Nothing Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            long totalSize = checkedFiles.Sum(f => f.FileSize);
            DialogResult result = MessageBox.Show(
                $"Delete {checkedFiles.Count} file(s)?\nTotal space to free: {FormatSize(totalSize)}\n\n" +
                "This will permanently delete the selected files from disk.",
                "Confirm Deletion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            btnDeleteSelected.Enabled = false;
            btnScan.Enabled = false;

            int successCount = 0;
            int failCount = 0;

            prgScanProgress.Maximum = checkedFiles.Count;
            prgScanProgress.Value = 0;

            for (int i = 0; i < checkedFiles.Count; i++)
            {
                var file = checkedFiles[i];
                prgScanProgress.Value = i + 1;
                lblStatus.Text = $"Deleting [{i + 1}/{checkedFiles.Count}]: {file.FileName}";
                Application.DoEvents();

                try
                {
                    if (File.Exists(file.DestPath))
                        File.Delete(file.DestPath);

                    using (MySqlConnection conn = DatabaseConfig.GetConnection())
                    {
                        conn.Open();
                        using (MySqlCommand cmd = new MySqlCommand(
                            "DELETE FROM destination_file_data WHERE id = @id", conn))
                        {
                            cmd.Parameters.AddWithValue("@id", file.Id);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    successCount++;
                }
                catch (Exception ex)
                {
                    failCount++;
                    lblStatus.Text = $"Failed: {file.FileName} — {ex.Message}";
                    Application.DoEvents();
                }
            }

            // Remove deleted files from sets and rebuild
            RemoveDeletedFromSets();

            lblStatus.Text = $"Deleted {successCount} file(s), {failCount} failed.";
            MessageBox.Show(
                $"Deletion completed.\n\n✓ Deleted: {successCount}\n✗ Failed: {failCount}",
                "Deletion Complete",
                MessageBoxButtons.OK,
                failCount > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);

            if (duplicateSets.Count == 0)
            {
                lblSetNav.Text = "No duplicates remaining";
                flpFileList.Controls.Clear();
                UpdateSummary();
            }
            else
            {
                if (currentSetIndex >= duplicateSets.Count)
                    currentSetIndex = duplicateSets.Count - 1;
                ShowSet(currentSetIndex);
                UpdateSummary();
            }

            btnDeleteSelected.Enabled = duplicateSets.Count > 0;
            btnScan.Enabled = true;
            prgScanProgress.Value = 0;
        }

        private void RemoveDeletedFromSets()
        {
            var newSets = new List<DupSet>();
            foreach (var set in duplicateSets)
            {
                var remaining = set.Files.Where(f => File.Exists(f.DestPath)).ToList();
                if (remaining.Count > 1)
                {
                    long wasted = remaining.Skip(1).Sum(f => f.FileSize);
                    newSets.Add(new DupSet
                    {
                        Files = remaining,
                        MatchKey = set.MatchKey,
                        WastedBytes = wasted
                    });
                }
            }
            duplicateSets = newSets;
        }

        private void btnCleanAll_Click(object sender, EventArgs e)
        {
            if (duplicateSets.Count == 0)
            {
                MessageBox.Show("No duplicate sets to clean.", "Nothing to Clean",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var toDelete = new List<DupFile>();
            foreach (var set in duplicateSets)
            {
                for (int i = 1; i < set.Files.Count; i++)
                    toDelete.Add(set.Files[i]);
            }

            if (toDelete.Count == 0)
            {
                MessageBox.Show("No duplicate files found to clean.", "Nothing to Clean",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            long totalSize = toDelete.Sum(f => f.FileSize);
            DialogResult result = MessageBox.Show(
                $"Delete all {toDelete.Count} duplicate file(s) across {duplicateSets.Count} set(s)?\n" +
                $"Total space to free: {FormatSize(totalSize)}\n\n" +
                "This will permanently delete these files from disk.",
                "Confirm Clean All",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            btnCleanAll.Enabled = false;
            btnScan.Enabled = false;
            btnDeleteSelected.Enabled = false;

            int successCount = 0;
            int failCount = 0;

            prgScanProgress.Maximum = toDelete.Count;
            prgScanProgress.Value = 0;

            for (int i = 0; i < toDelete.Count; i++)
            {
                var file = toDelete[i];
                prgScanProgress.Value = i + 1;
                lblStatus.Text = $"Deleting [{i + 1}/{toDelete.Count}]: {file.FileName}";
                Application.DoEvents();

                try
                {
                    if (File.Exists(file.DestPath))
                        File.Delete(file.DestPath);

                    using (MySqlConnection conn = DatabaseConfig.GetConnection())
                    {
                        conn.Open();
                        using (MySqlCommand cmd = new MySqlCommand(
                            "DELETE FROM destination_file_data WHERE id = @id", conn))
                        {
                            cmd.Parameters.AddWithValue("@id", file.Id);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    successCount++;
                }
                catch (Exception ex)
                {
                    failCount++;
                    lblStatus.Text = $"Failed: {file.FileName} — {ex.Message}";
                    Application.DoEvents();
                }
            }

            RemoveDeletedFromSets();

            lblStatus.Text = $"Cleaned {successCount} file(s), {failCount} failed.";
            MessageBox.Show(
                $"Clean All completed.\n\n✓ Deleted: {successCount}\n✗ Failed: {failCount}",
                "Clean All Complete",
                MessageBoxButtons.OK,
                failCount > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);

            if (duplicateSets.Count == 0)
            {
                lblSetNav.Text = "No duplicates remaining";
                flpFileList.Controls.Clear();
            }
            else
            {
                if (currentSetIndex >= duplicateSets.Count)
                    currentSetIndex = duplicateSets.Count - 1;
                ShowSet(currentSetIndex);
            }

            UpdateSummary();
            btnCleanAll.Enabled = true;
            btnScan.Enabled = true;
            btnDeleteSelected.Enabled = duplicateSets.Count > 0;
            prgScanProgress.Value = 0;
        }

        private string FormatSize(long bytes)
        {
            if (bytes < 1024) return bytes + " B";
            if (bytes < 1024 * 1024) return (bytes / 1024.0).ToString("F1") + " KB";
            if (bytes < 1024L * 1024 * 1024) return (bytes / (1024.0 * 1024.0)).ToString("F1") + " MB";
            return (bytes / (1024.0 * 1024.0 * 1024.0)).ToString("F2") + " GB";
        }
    }
}
