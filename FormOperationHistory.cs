using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SmartFileOrganizer
{
    public partial class FormOperationHistory : Form
    {
        private string selectedExecutionId = null;

        public FormOperationHistory()
        {
            InitializeComponent();
        }

        public void RefreshData()
        {
            LoadExecutions();
        }

        private void FormOperationHistory_Load(object sender, EventArgs e)
        {
            LoadExecutions();
        }

        private void LoadExecutions()
        {
            lvExecutions.Items.Clear();

            try
            {
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(
                        "SELECT execution_id, operation_type, COUNT(*) as file_count, " +
                        "SUM(file_size) as total_size, " +
                        "SUM(CASE WHEN status LIKE 'SUCCESS%' THEN 1 ELSE 0 END) as success_count, " +
                        "SUM(CASE WHEN status LIKE 'FAILED%' THEN 1 ELSE 0 END) as fail_count, " +
                        "MIN(performed_at) as first_time " +
                        "FROM operation_history WHERE execution_id IS NOT NULL " +
                        "GROUP BY execution_id, operation_type " +
                        "ORDER BY first_time DESC", conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string execId = reader["execution_id"].ToString();
                            string opType = reader["operation_type"].ToString();
                            int fileCount = Convert.ToInt32(reader["file_count"]);
                            long totalSize = reader["total_size"] != DBNull.Value ? Convert.ToInt64(reader["total_size"]) : 0;
                            int successCount = Convert.ToInt32(reader["success_count"]);
                            int failCount = Convert.ToInt32(reader["fail_count"]);
                            DateTime firstTime = Convert.ToDateTime(reader["first_time"]);

                            ListViewItem item = new ListViewItem(firstTime.ToString("yyyy-MM-dd HH:mm:ss"));
                            item.SubItems.Add(opType);
                            item.SubItems.Add(fileCount.ToString());
                            item.SubItems.Add(FormatSize(totalSize));
                            item.SubItems.Add(successCount.ToString());
                            item.SubItems.Add(failCount.ToString());
                            item.SubItems.Add(execId);
                            item.Tag = execId;

                            lvExecutions.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading history: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (lvExecutions.Items.Count == 0)
            {
                lblTitle.Text = "🕒 Operation History — No records yet";
            }
        }

        private string FormatSize(long bytes)
        {
            if (bytes < 1024) return bytes + " B";
            if (bytes < 1024 * 1024) return (bytes / 1024.0).ToString("F1") + " KB";
            if (bytes < 1024 * 1024 * 1024) return (bytes / (1024.0 * 1024.0)).ToString("F1") + " MB";
            return (bytes / (1024.0 * 1024.0 * 1024.0)).ToString("F2") + " GB";
        }

        private void lvExecutions_Click(object sender, EventArgs e)
        {
            if (lvExecutions.SelectedItems.Count == 0)
                return;

            string execId = lvExecutions.SelectedItems[0].Tag?.ToString();
            if (string.IsNullOrEmpty(execId))
                return;

            selectedExecutionId = execId;
            ShowExecutionDetail(execId);
        }

        private void ShowExecutionDetail(string execId)
        {
            lvOperationFiles.Items.Clear();
            panelListView.Visible = false;
            panelDetailView.Visible = true;
            btnBack.Visible = true;

            int totalCount = 0;
            try
            {
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(
                        "SELECT file_name, operation_type, source_path, destination_path, file_size, status " +
                        "FROM operation_history WHERE execution_id = @execId ORDER BY id ASC", conn))
                    {
                        cmd.Parameters.AddWithValue("@execId", execId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string fileName = reader["file_name"].ToString();
                                string opType = reader["operation_type"].ToString();
                                string sourcePath = reader["source_path"].ToString();
                                string destPath = reader["destination_path"].ToString();
                                long fileSize = reader["file_size"] != DBNull.Value ? Convert.ToInt64(reader["file_size"]) : 0;
                                string status = reader["status"].ToString();

                                ListViewItem item = new ListViewItem(fileName);
                                item.SubItems.Add(opType);
                                item.SubItems.Add(FormatSize(fileSize));
                                item.SubItems.Add(status.StartsWith("SUCCESS") ? "✓ Success" : "✗ Failed");
                                item.SubItems.Add(sourcePath);
                                item.Tag = destPath;

                                lvOperationFiles.Items.Add(item);
                                totalCount++;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading details: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lblSelectedInfo.Text = $"Execution: {totalCount} files  |  {lvExecutions.SelectedItems[0].SubItems[0].Text}  |  {lvExecutions.SelectedItems[0].SubItems[1].Text}";
            lblTitle.Text = "🕒 Operation History — Execution Details";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            panelDetailView.Visible = false;
            panelListView.Visible = true;
            btnBack.Visible = false;
            selectedExecutionId = null;
            lblTitle.Text = "🕒 Operation History";
        }

        private void btnClearHistory_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "This will permanently delete ALL operation history records.\n\n" +
                "Files on disk will NOT be affected.\n\nContinue?",
                "Clear History",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            try
            {
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM operation_history", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                panelDetailView.Visible = false;
                panelListView.Visible = true;
                btnBack.Visible = false;
                selectedExecutionId = null;
                lblTitle.Text = "🕒 Operation History";
                LoadExecutions();

                MessageBox.Show("Operation history cleared.", "Done",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error clearing history: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedExecutionId))
            {
                MessageBox.Show("Select an execution from the list first, then click Undo.",
                    "Nothing Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                "This will undo the selected execution.\n\n" +
                "• Files that were Copied will be deleted from destination.\n" +
                "• Files that were Moved will be moved back to original location.\n\n" +
                "Continue?",
                "Confirm Undo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            btnUndo.Enabled = false;
            btnClearHistory.Enabled = false;

            List<(string fileName, string opType, string sourcePath, string destPath, long fileSize)> undoList =
                new List<(string, string, string, string, long)>();

            try
            {
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(
                        "SELECT file_name, operation_type, source_path, destination_path, file_size " +
                        "FROM operation_history WHERE execution_id = @execId AND status LIKE 'SUCCESS%' ORDER BY id DESC", conn))
                    {
                        cmd.Parameters.AddWithValue("@execId", selectedExecutionId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string fileName = reader["file_name"].ToString();
                                string opType = reader["operation_type"].ToString();
                                string sourcePath = reader["source_path"].ToString();
                                string destPath = reader["destination_path"].ToString();
                                long fileSize = reader["file_size"] != DBNull.Value ? Convert.ToInt64(reader["file_size"]) : 0;
                                undoList.Add((fileName, opType, sourcePath, destPath, fileSize));
                            }
                        }
                    }
                }

                if (undoList.Count == 0)
                {
                    MessageBox.Show("No successful operations to undo for this execution.",
                        "Nothing to Undo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int successCount = 0;
                int failCount = 0;
                prgUndoProgress.Maximum = undoList.Count;
                prgUndoProgress.Value = 0;

                for (int i = 0; i < undoList.Count; i++)
                {
                    var entry = undoList[i];
                    prgUndoProgress.Value = i + 1;
                    lblUndoStatus.Text = $"[{i + 1}/{undoList.Count}] Processing: {entry.fileName}";
                    Application.DoEvents();

                    try
                    {
                        if (entry.opType == "Copy")
                        {
                            if (File.Exists(entry.destPath))
                                File.Delete(entry.destPath);
                        }
                        else if (entry.opType == "Move")
                        {
                            if (File.Exists(entry.destPath))
                            {
                                string sourceDir = Path.GetDirectoryName(entry.sourcePath);
                                if (!string.IsNullOrEmpty(sourceDir) && !Directory.Exists(sourceDir))
                                    Directory.CreateDirectory(sourceDir);

                                if (File.Exists(entry.sourcePath))
                                    File.Delete(entry.sourcePath);

                                File.Move(entry.destPath, entry.sourcePath);
                            }
                        }

                        successCount++;
                    }
                    catch (Exception ex)
                    {
                        failCount++;
                        lblUndoStatus.Text = $"[{i + 1}/{undoList.Count}] Failed: {entry.fileName} — {ex.Message}";
                        Application.DoEvents();
                    }
                }

                lblUndoStatus.Text = $"Undo complete — {successCount} reverted, {failCount} failed.";
                MessageBox.Show(
                    $"Undo completed.\n\n✓ Reverted: {successCount}\n✗ Failed: {failCount}",
                    "Undo Complete",
                    MessageBoxButtons.OK,
                    failCount > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);

                ShowExecutionDetail(selectedExecutionId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during undo: " + ex.Message,
                    "Undo Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnUndo.Enabled = true;
                btnClearHistory.Enabled = true;
                prgUndoProgress.Value = 0;
                lblUndoStatus.Text = "Ready";
            }
        }
    }
}
