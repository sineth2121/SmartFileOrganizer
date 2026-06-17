using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; // Added for future path and directory validations
using MySql.Data.MySqlClient;



namespace SmartFileOrganizer
{
    public partial class FormFolderSelection : Form
    {
        public FormFolderSelection()
        {
            InitializeComponent();
            // This assigns the text property so your dashboard header can read it if needed
            this.Text = "Folder Selection";
            try
            {
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    string query = "SELECT destination_folder_path FROM app_settings ORDER BY id DESC LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        conn.Open();

                        // ExecuteReader is used specifically for pulling data back from a query
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // Checks if a row was found
                            {
                                // Extract the string value from the database column name
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
        private void btnImport_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select the source folder to Import Files.";
                folderDialog.ShowNewFolderButton = false; // Source folder should already exist

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    // Assign the chosen path string to your import textbox
                    importText.Text = folderDialog.SelectedPath;
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

                            // 1. Check if a destination already exists
                            string checkQuery = "SELECT COUNT(*) FROM app_settings";
                            using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                            {
                                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                                if (count > 0)
                                {
                                    // 2. Warning before replacing
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

                                    // 3. Delete old record
                                    string deleteQuery = "DELETE FROM app_settings";
                                    using (MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, conn))
                                    {
                                        deleteCmd.ExecuteNonQuery();
                                    }
                                }
                            }

                            // 4. Insert new destination
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
            // Example layout: You could check if Directory.Exists(importText.Text) 
            // to turn the text border color green or red.
        }

        private void destinationText_TextChanged(object sender, EventArgs e)
        {
            // Example layout: Ensure the destination path isn't identical to the import path.
        }
    }
}