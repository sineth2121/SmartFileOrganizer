using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SmartFileOrganizer
{
    public partial class FormConfigureRules : Form
    {
        private string baseDestinationPath = "";

        public FormConfigureRules()
        {
            InitializeComponent();
            SetInitialCheckboxStates();
        }

        private void SetInitialCheckboxStates()
        {
            cmbExtCategory.Enabled = false;
            cmbAgeGroup.Enabled = false;
            txtKeyword.Enabled = false;
        }

        private int CountRules(string whereClause)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM organization_rules";
                    if (!string.IsNullOrEmpty(whereClause))
                        sql += " WHERE " + whereClause;
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch
            {
                return 0;
            }
        }

        private void UpdateFormState()
        {
            int totalRules = CountRules("");
            int batchRules = CountRules("rule_source = 'batch'");
            int customRules = CountRules("rule_source = 'custom'");

            if (totalRules == 0)
            {
                btnBatchType.Enabled = true;
                btnBatchAge.Enabled = true;
                btnBatchAlphabet.Enabled = true;
                lblBatchStatus.Visible = false;

                txtRuleName.Enabled = true;
                chkUseExt.Enabled = true;
                chkUseAge.Enabled = true;
                chkUseKeyword.Enabled = true;
                txtRuleDestination.Enabled = true;
                btnBrowseRuleDest.Enabled = true;
                btnSaveRule.Enabled = true;

                SetInitialCheckboxStates();
                ResetFormFields();
                return;
            }

            btnBatchType.Enabled = false;
            btnBatchAge.Enabled = false;
            btnBatchAlphabet.Enabled = false;

            if (batchRules > 0)
            {
                lblBatchStatus.Text = "Batch rules exist. Custom rules are locked.";
                lblBatchStatus.Visible = true;

                txtRuleName.Enabled = false;
                chkUseExt.Enabled = false;
                cmbExtCategory.Enabled = false;
                chkUseAge.Enabled = false;
                cmbAgeGroup.Enabled = false;
                chkUseKeyword.Enabled = false;
                txtKeyword.Enabled = false;
                txtRuleDestination.Enabled = false;
                btnBrowseRuleDest.Enabled = false;
                btnSaveRule.Enabled = false;
            }
            else
            {
                if (customRules >= 10)
                {
                    lblBatchStatus.Text = "Maximum 10 custom rules reached. Delete some to add more.";
                    lblBatchStatus.Visible = true;

                    txtRuleName.Enabled = false;
                    chkUseExt.Enabled = false;
                    cmbExtCategory.Enabled = false;
                    chkUseAge.Enabled = false;
                    cmbAgeGroup.Enabled = false;
                    chkUseKeyword.Enabled = false;
                    txtKeyword.Enabled = false;
                    txtRuleDestination.Enabled = false;
                    btnBrowseRuleDest.Enabled = false;
                    btnSaveRule.Enabled = false;
                }
                else
                {
                    lblBatchStatus.Text = "Custom rules mode (" + customRules + "/10 used).";
                    lblBatchStatus.Visible = true;

                    txtRuleName.Enabled = true;
                    chkUseExt.Enabled = true;
                    chkUseAge.Enabled = true;
                    chkUseKeyword.Enabled = true;
                    txtRuleDestination.Enabled = true;
                    btnBrowseRuleDest.Enabled = true;
                    btnSaveRule.Enabled = true;

                    SetInitialCheckboxStates();
                }
            }
        }

        private void FormConfigureRules_Load(object sender, EventArgs e)
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
                        if (result != null)
                        {
                            baseDestinationPath = result.ToString();
                            lblFallbackNotifier.Text = "info Unmatched files are safely sent to: "
                                + baseDestinationPath + "\\Unorganized_Items";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading settings: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadRulesFromDatabase();
            UpdateFormState();
        }

        private void LoadRulesFromDatabase()
        {
            listViewRules.Items.Clear();

            try
            {
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT id, rule_name, ext_category, age_days, keyword_match, destination_subfolder, rule_source "
                                 + "FROM organization_rules WHERE is_active = 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["id"]);
                            string name = reader["rule_name"].ToString();
                            string conditions = BuildConditionsString(reader);
                            string target = reader["destination_subfolder"].ToString();
                            string sourceType = reader["rule_source"].ToString();

                            ListViewItem item = new ListViewItem(id.ToString());
                            item.SubItems.Add(name);
                            item.SubItems.Add(conditions);
                            item.SubItems.Add(target);
                            item.SubItems.Add(sourceType);
                            item.Tag = id;

                            listViewRules.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading rules: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string BuildConditionsString(MySqlDataReader reader)
        {
            string ext = reader["ext_category"] != DBNull.Value ? reader["ext_category"].ToString() : "";
            string age = reader["age_days"] != DBNull.Value ? reader["age_days"].ToString() : "";
            string keyword = reader["keyword_match"] != DBNull.Value ? reader["keyword_match"].ToString() : "";

            string result = "";
            if (!string.IsNullOrEmpty(ext))
                result += "Ext: " + ext;
            if (!string.IsNullOrEmpty(age))
                result += (result.Length > 0 ? ", " : "") + "Age: " + age;
            if (!string.IsNullOrEmpty(keyword))
                result += (result.Length > 0 ? ", " : "") + "Key: " + keyword;

            return result;
        }

        private void chkUseExt_CheckedChanged(object sender, EventArgs e)
        {
            cmbExtCategory.Enabled = chkUseExt.Checked;
            if (!chkUseExt.Checked)
                cmbExtCategory.SelectedIndex = -1;
        }

        private void chkUseAge_CheckedChanged(object sender, EventArgs e)
        {
            cmbAgeGroup.Enabled = chkUseAge.Checked;
            if (!chkUseAge.Checked)
                cmbAgeGroup.SelectedIndex = -1;
        }

        private void chkUseKeyword_CheckedChanged(object sender, EventArgs e)
        {
            txtKeyword.Enabled = chkUseKeyword.Checked;
            if (!chkUseKeyword.Checked)
                txtKeyword.Clear();
        }

        private void txtRuleName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(baseDestinationPath) && !string.IsNullOrWhiteSpace(txtRuleName.Text))
            {
                txtRuleDestination.Text = System.IO.Path.Combine(baseDestinationPath, txtRuleName.Text.Trim());
            }
            else
            {
                txtRuleDestination.Clear();
            }
        }

        private void btnBrowseRuleDest_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select the target subfolder for this rule";
                folderDialog.ShowNewFolderButton = true;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtRuleDestination.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void btnSaveRule_Click(object sender, EventArgs e)
        {
            string ruleName = txtRuleName.Text.Trim();

            if (string.IsNullOrWhiteSpace(ruleName))
            {
                MessageBox.Show("Please enter a rule name.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!chkUseExt.Checked && !chkUseAge.Checked && !chkUseKeyword.Checked)
            {
                MessageBox.Show("Please select at least one condition (Extension, Age, or Keyword).",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string destination = txtRuleDestination.Text.Trim();
            if (string.IsNullOrWhiteSpace(destination))
            {
                MessageBox.Show("Please specify a destination for this rule.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    string query = @"INSERT INTO organization_rules
                        (rule_name, ext_category, age_days, keyword_match, destination_subfolder, is_active, execution_id, rule_source)
                        VALUES (@name, @ext, @age, @keyword, @dest, 1, NULL, 'custom')";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", ruleName);
                        cmd.Parameters.AddWithValue("@ext", chkUseExt.Checked ? cmbExtCategory.SelectedItem.ToString() : (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@age", chkUseAge.Checked ? cmbAgeGroup.SelectedItem.ToString() : (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@keyword", chkUseKeyword.Checked ? txtKeyword.Text.Trim() : (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@dest", destination);
                        cmd.ExecuteNonQuery();
                    }
                }

                ResetFormFields();
                LoadRulesFromDatabase();
                UpdateFormState();

                MessageBox.Show("Rule saved successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save rule: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetFormFields()
        {
            txtRuleName.Clear();
            chkUseExt.Checked = false;
            chkUseAge.Checked = false;
            chkUseKeyword.Checked = false;
            cmbExtCategory.SelectedIndex = -1;
            cmbAgeGroup.SelectedIndex = -1;
            txtKeyword.Clear();
            txtRuleDestination.Clear();
        }

        private void btnDeleteRule_Click(object sender, EventArgs e)
        {
            if (listViewRules.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a rule to delete.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int ruleId = (int)listViewRules.SelectedItems[0].Tag;

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this rule?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM organization_rules WHERE id = @ruleId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ruleId", ruleId);
                        cmd.ExecuteNonQuery();
                    }
                }

                LoadRulesFromDatabase();
                UpdateFormState();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete rule: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to delete ALL rules?\n\nThis will re-enable batch processors and custom rule creation.",
                "Confirm Delete All", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM organization_rules", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                LoadRulesFromDatabase();
                UpdateFormState();

                MessageBox.Show("All rules deleted successfully.", "Deleted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete all rules: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBatchType_Click(object sender, EventArgs e)
        {
            if (CountRules("") > 0)
            {
                MessageBox.Show("Rules already exist. Delete all rules first to use batch processors.",
                    "Locked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Insert standard File Type sorting rules (Documents, Images, Videos)?",
                "Batch Processor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();

                    InsertBatchRule(conn, "Documents", "Documents (.pdf,.docx,.txt)", null, null,
                        System.IO.Path.Combine(baseDestinationPath, "Documents"));
                    InsertBatchRule(conn, "Images", "Images (.png,.jpg,.gif)", null, null,
                        System.IO.Path.Combine(baseDestinationPath, "Images"));
                    InsertBatchRule(conn, "Videos", "Videos (.mp4,.mkv)", null, null,
                        System.IO.Path.Combine(baseDestinationPath, "Videos"));
                }

                LoadRulesFromDatabase();
                UpdateFormState();
                MessageBox.Show("File Type batch rules created successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to create batch rules: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBatchAge_Click(object sender, EventArgs e)
        {
            if (CountRules("") > 0)
            {
                MessageBox.Show("Rules already exist. Delete all rules first to use batch processors.",
                    "Locked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Insert standard File Age sorting rules (Recent, Archive)?",
                "Batch Processor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();

                    InsertBatchRule(conn, "Recent Items", null, "New Files (< 30 Days)", null,
                        System.IO.Path.Combine(baseDestinationPath, "Recent"));
                    InsertBatchRule(conn, "Old Archives", null, "Archive (>= 180 Days)", null,
                        System.IO.Path.Combine(baseDestinationPath, "Archive"));
                }

                LoadRulesFromDatabase();
                UpdateFormState();
                MessageBox.Show("File Age batch rules created successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to create batch rules: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBatchAlphabet_Click(object sender, EventArgs e)
        {
            if (CountRules("") > 0)
            {
                MessageBox.Show("Rules already exist. Delete all rules first to use batch processors.",
                    "Locked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Insert alphabetical range rules (A-E, F-J, K-O, P-T, U-Z)?",
                "Batch Processor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                using (MySqlConnection conn = DatabaseConfig.GetConnection())
                {
                    conn.Open();

                    InsertBatchRule(conn, "A-E Range", null, null, null,
                        System.IO.Path.Combine(baseDestinationPath, "A-E"));
                    InsertBatchRule(conn, "F-J Range", null, null, null,
                        System.IO.Path.Combine(baseDestinationPath, "F-J"));
                    InsertBatchRule(conn, "K-O Range", null, null, null,
                        System.IO.Path.Combine(baseDestinationPath, "K-O"));
                    InsertBatchRule(conn, "P-T Range", null, null, null,
                        System.IO.Path.Combine(baseDestinationPath, "P-T"));
                    InsertBatchRule(conn, "U-Z Range", null, null, null,
                        System.IO.Path.Combine(baseDestinationPath, "U-Z"));
                }

                LoadRulesFromDatabase();
                UpdateFormState();
                MessageBox.Show("Alphabetical batch rules created successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to create batch rules: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertBatchRule(MySqlConnection conn, string ruleName, string extCategory,
            string ageDays, string keyword, string destination)
        {
            string query = @"INSERT INTO organization_rules
                (rule_name, ext_category, age_days, keyword_match, destination_subfolder, is_active, execution_id, rule_source)
                VALUES (@name, @ext, @age, @keyword, @dest, 1, NULL, 'batch')";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@name", ruleName);
                cmd.Parameters.AddWithValue("@ext", (object)extCategory ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@age", (object)ageDays ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@keyword", (object)keyword ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@dest", destination);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
