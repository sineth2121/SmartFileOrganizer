# SmartFileOrganizer — Current Implementation Status

## Tech Stack
- **.NET Framework 4.7.2** — Windows Forms desktop application
- **MySQL 9.7.0** (`MySql.Data` via NuGet) — local database
- **Language**: C#

## Architecture Overview

```
Program.cs
  └─ FormDashboard (main shell)
       ├─ FormFolderSelection ✅ (wired up)
       ├─ FormConfigureRules ✅ (wired up)
       ├─ Operation History ❌
       ├─ Preview / Organize ❌
       ├─ Duplicate Cleaner ❌
       └─ App Settings ❌
DatabaseConfig.cs ── static MySQL connection helper
```

## Database

### Connection (`DatabaseConfig.cs`)
- Hardcoded connection string: `Server=localhost;Port=3306;Database=smart_file_organizer;Uid=root;Pwd=;`
- Static method `GetConnection()` returns a new `MySqlConnection`.

### Schema (`Database\migration_001.sql`)
**`app_settings`** — stores application-level config:
| Column | Type | Notes |
|--------|------|-------|
| `id` | INT (PK, AUTO_INCREMENT) | |
| `destination_folder_path` | TEXT | last-used destination folder |
| `created_at` | DATETIME | defaults to `CURRENT_TIMESTAMP` |

**`organization_rules`** — stores automation rules for file routing:
| Column | Type | Notes |
|--------|------|-------|
| `id` | INT (PK, AUTO_INCREMENT) | |
| `rule_name` | VARCHAR(255) | user-defined name |
| `ext_category` | VARCHAR(255) | nullable — e.g. `"Documents (.pdf,.docx,.txt)"` |
| `age_days` | VARCHAR(50) | nullable — e.g. `"New Files (< 30 Days)"` |
| `keyword_match` | VARCHAR(255) | nullable — keyword text to match |
| `destination_subfolder` | VARCHAR(255) | target folder path |
| `is_active` | TINYINT(1) | defaults to `1` |
| `execution_id` | INT | nullable, FK → `operation_history(id)` ON DELETE SET NULL |
| `rule_source` | VARCHAR(20) | `'batch'` or `'custom'`, defaults to `'custom'` |
| `created_at` | DATETIME | defaults to `CURRENT_TIMESTAMP` |

**`operation_history`** — audit log for file operations:
| Column | Type | Notes |
|--------|------|-------|
| `id` | INT (PK, AUTO_INCREMENT) | |
| `operation_type` | VARCHAR(50) | NOT NULL |
| `file_name` | VARCHAR(255) | nullable |
| `source_path` | VARCHAR(500) | nullable |
| `destination_path` | VARCHAR(500) | nullable |
| `file_size` | BIGINT | nullable |
| `status` | VARCHAR(20) | defaults to `'SUCCESS'` |
| `performed_at` | TIMESTAMP | defaults to `CURRENT_TIMESTAMP` |

**`imported_files`** — stores imported file/folder records:
| Column | Type | Notes |
|--------|------|-------|
| `id` | INT (PK, AUTO_INCREMENT) | |
| `file_name` | VARCHAR(255) | |
| `file_path` | TEXT | full source path |
| `file_extension` | VARCHAR(50) | nullable |
| `file_size` | BIGINT | bytes |
| `file_modified_date` | DATETIME | nullable — file's last-modified timestamp |
| `file_type` | VARCHAR(20) | `"File"` or `"Folder"` |
| `is_excluded` | TINYINT(1) | `1` = excluded from deep scan |
| `operation_type` | VARCHAR(10) | `"Copy"` or `"Cut"` |
| `source_path` | TEXT | nullable |
| `destination_path` | TEXT | nullable |
| `imported_date` | DATETIME | defaults to `CURRENT_TIMESTAMP` |

## Implemented Components

### `Program.cs`
Application entry point. Launches `FormDashboard`.

### `FormDashboard.cs` / `FormDashboard.Designer.cs`
Main application shell with:
- **Sidebar** (220px, left-docked) with 6 navigation buttons and a logo header
- **Header** (top panel, "Dashboard Overview" title)
- **`panelMain`** — content area that hosts child forms via `OpenChildForm()` (embeds as non-top-level, borderless, dock-filled controls)
- Only `btnFolderSelection` has a wired handler; all other buttons have empty click handlers

### `FormFolderSelection.cs` / `FormFolderSelection.Designer.cs`
Folder selection module — the only functional page. Layout:
- **Top panel** (`panelCard`) — source & destination folder pickers
- **Middle** — `ListView` showing folder contents with exclusion toggling
- **Bottom panel** (`panelImportArea`) — Copy/Cut radio buttons + **▶ Start Import** button

| Feature | Status | Details |
|---------|--------|---------|
| Destination folder picker | ✅ | `FolderBrowserDialog`, saved to MySQL `app_settings` table. Warns on overwrite (deletes old row + inserts new). |
| Import source folder picker | ✅ | `FolderBrowserDialog`, populates a `ListView` with subdirectories and files. |
| Folder listing | ✅ | Three-column `ListView`: Name, Type (Folder/File), Deep Scan Action. Custom checkbox images via `ImageList`. |
| Exclusion toggling | ✅ | Click a folder row to toggle state image — marks folder as "EXCLUDED (Move folder whole, skip inside)" with `LavenderBlush` background. |
| Validation status label | ✅ | Shows guidance — warns if subfolders exist but none excluded, confirms when exclusions are set. |
| Copy/Cut operation selector | ✅ | Two radio buttons — "Copy (keep original)" (default, checked) and "Cut (move files)". |
| Start Import button | ✅ | Clears `imported_files` table, counts all files recursively, then inserts each file/folder record with full metadata (name, path, extension, size, last-modified date, type, excluded flag, operation type, source & destination paths). Excluded folders are stored as a single folder row (contents skipped). |

### `FormImportProgress.cs` / `FormImportProgress.Designer.cs`
Progress dialog shown during import:
- **Progress bar** — determinate, updates per file
- **Status label** — shows current phase
- **Cancel button** — sets cancellation flag; import loop checks flag and exits early. All inserted records are then deleted from `imported_files`.
- **OK button** — disabled during import, enabled on completion; user must click OK to dismiss

### `FormConfigureRules.cs` / `FormConfigureRules.Designer.cs`
Rule management page for defining file-organisation automation. Layout:
- **Info banner** (`panelInfoBanner`, LightCyan, top) — fallback routing policy showing the actual destination path
- **Batch processors** (`panelBatchProcessors`, white) — three 1-click template buttons: Sort by File Type, File Age, Alphabetical Range. Each inserts pre-built rules into `organization_rules`.
- **Custom Rule Builder** (`panelCreateRule`, white, left) — rule name textbox, three checkbox-driven condition rows (Extension combo, Age combo, Keyword textbox) that enable/disable their controls, auto-populated destination path derived from rule name + `baseDestinationPath`, Browse override, and Save button.
- **Active Rules Matrix** (`panelActiveRules`, white, right) — `ListView` (ID, Rule Name, Active Conditions, Target Destination, Source) with Delete Selected (bottom-right) and Delete All Rules (bottom-left) buttons.

| Feature | Status | Details |
|---------|--------|---------|
| Load existing rules | ✅ | `LoadRulesFromDatabase()` queries active rules. Compiles "Active Conditions" from non-null fields. Shows 5 columns: ID, Name, Conditions, Target, Source. `Tag` holds DB ID. |
| Save new rule | ✅ | Inserts with `rule_source = 'custom'`. Calls `UpdateFormState()` which checks batch/custom counts. |
| Delete rule | ✅ | Confirmation, deletes by ID, calls `UpdateFormState()`. |
| Delete All Rules | ✅ | `btnDeleteAll_Click` — `DELETE FROM organization_rules`, calls `UpdateFormState()` which resets everything. |
| Browse destination | ✅ | `FolderBrowserDialog` lets user override auto-populated path. |
| Auto path from rule name | ✅ | `txtRuleName_TextChanged` sets `txtRuleDestination` via `Path.Combine()`. |
| Checkbox toggle logic | ✅ | Checked = enable + clear underyling control. Unchecked = disable + clear value. |
| Batch vs Custom tracking | ✅ | `rule_source` column: `'batch'` for batch processors, `'custom'` for manual saves. Visible in ListView as "Source" column. |
| Batch locks custom form | ✅ | If any batch rules exist, custom rule form is locked entirely. |
| Custom rules cap (10 max) | ✅ | `UpdateFormState()` counts custom rules. At 10, Save button + form are disabled with message. |
| Custom rules allowed without batch | ✅ | If no batch rules exist and custom count < 10, custom rule form is enabled. Shows "(N/10 used)" status. |
| Persists across form reopen | ✅ | `UpdateFormState()` runs on every load — state is determined from DB data, not in-memory flags. |
| Batch: Sort by File Type | ✅ | Inserts 3 rules with `rule_source = 'batch'`. Only available when no rules exist. |
| Batch: Sort by File Age | ✅ | Same guard. Inserts with `rule_source = 'batch'`. |
| Batch: Sort by Alphabetical | ✅ | Same guard. Inserts with `rule_source = 'batch'`. |
| execution_id on rules | ✅ | All INSERTs include `execution_id = NULL`. Set later by Preview/Organize. |
| Banner auto-update | ✅ | Reads `destination_folder_path` from `app_settings` on load. |
| Dashboard integration | ✅ | `OpenChildForm()` pattern via sidebar button. |

## What's Missing / Not Implemented
1. **Preview/organize execution** — no actual file moving/copying logic
2. **Duplicate detection** — no hash comparison or duplicate finding
3. **Operation history** — no audit log or history viewing
4. **Settings page** — no app-wide configuration UI
