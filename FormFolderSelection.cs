using System;
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
    }
}
