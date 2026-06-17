# SmartFileOrganizer

A Windows Forms (.NET Framework 4.7.2) application that organizes files in a user-specified folder based on customizable rules. It can scan folders, detect duplicates, and maintain an operation history.

## Current Implementation

### Forms

| Form | Purpose |
|---|---|
| `FormDashboard` | Main navigation shell with a sidebar containing six buttons: Folder Selection, Duplicate Cleaner, Scan Preview, Operation History, Configure Rules, and Settings. Only **Folder Selection** is currently wired to a child form. |
| `FormFolderSelection` | Allows the user to pick a **destination folder** (saved to the database) and an **import / source folder** (path selected via dialog but not yet persisted). |

### Database Layer

| Class | Purpose |
|---|---|
| `DatabaseConfig` | Static class providing a MySQL connection via `GetConnection()`. |

### Entry Point

`Program.cs` launches `FormDashboard` on startup. No automatic schema creation.

## Database

### Connection String

```
Server=localhost;Port=3306;Database=smart_file_organizer;Uid=root;Pwd=;
```

### Tables

Tables must be created manually (e.g., via MySQL Workbench or phpMyAdmin). The project does **not** auto-create them.

#### app_settings

Stores the base destination folder for organized files.

| Column | Type | Notes |
|---|---|---|
| `id` | INT | Primary key, auto-increment |
| `destination_folder_path` | VARCHAR(500) | NOT NULL |
| `created_at` | TIMESTAMP | DEFAULT CURRENT_TIMESTAMP |
| `updated_at` | TIMESTAMP | DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP |

#### source_folders

Stores folders selected for scanning.

| Column | Type | Notes |
|---|---|---|
| `id` | INT | Primary key, auto-increment |
| `folder_path` | VARCHAR(500) | NOT NULL |
| `is_imported` | TINYINT(1) | DEFAULT 0 |
| `added_at` | TIMESTAMP | DEFAULT CURRENT_TIMESTAMP |

#### organization_rules

Defines rules that determine how files are organized into subfolders.

| Column | Type | Notes |
|---|---|---|
| `id` | INT | Primary key, auto-increment |
| `rule_name` | VARCHAR(255) | NOT NULL |
| `source_pattern` | VARCHAR(255) | NOT NULL |
| `destination_subfolder` | VARCHAR(255) | NOT NULL |
| `is_active` | TINYINT(1) | DEFAULT 1 |
| `created_at` | TIMESTAMP | DEFAULT CURRENT_TIMESTAMP |
| `updated_at` | TIMESTAMP | DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP |

#### scanned_files

Records each file found during a folder scan.

| Column | Type | Notes |
|---|---|---|
| `id` | INT | Primary key, auto-increment |
| `source_folder_id` | INT | Foreign key → `source_folders(id)` ON DELETE CASCADE |
| `file_name` | VARCHAR(255) | NOT NULL |
| `file_path` | VARCHAR(500) | NOT NULL |
| `file_extension` | VARCHAR(50) | |
| `file_size` | BIGINT | |
| `file_hash` | VARCHAR(64) | |
| `scanned_at` | TIMESTAMP | DEFAULT CURRENT_TIMESTAMP |

#### operation_history

Logs every file move, copy, or delete operation performed by the application.

| Column | Type | Notes |
|---|---|---|
| `id` | INT | Primary key, auto-increment |
| `operation_type` | VARCHAR(50) | NOT NULL |
| `file_name` | VARCHAR(255) | |
| `source_path` | VARCHAR(500) | |
| `destination_path` | VARCHAR(500) | |
| `file_size` | BIGINT | |
| `status` | VARCHAR(20) | DEFAULT 'SUCCESS' |
| `performed_at` | TIMESTAMP | DEFAULT CURRENT_TIMESTAMP |

#### duplicate_groups

Groups duplicate files together by their hash.

| Column | Type | Notes |
|---|---|---|
| `id` | INT | Primary key, auto-increment |
| `file_hash` | VARCHAR(64) | NOT NULL |
| `file_size` | BIGINT | |
| `detected_at` | TIMESTAMP | DEFAULT CURRENT_TIMESTAMP |

#### duplicate_files

Individual files belonging to a duplicate group.

| Column | Type | Notes |
|---|---|---|
| `id` | INT | Primary key, auto-increment |
| `group_id` | INT | NOT NULL, Foreign key → `duplicate_groups(id)` ON DELETE CASCADE |
| `file_name` | VARCHAR(255) | |
| `file_path` | VARCHAR(500) | NOT NULL |
| `is_original` | TINYINT(1) | DEFAULT 0 |

### SQL Script

Run the following in your MySQL client to create all tables:

```sql
CREATE TABLE IF NOT EXISTS app_settings (
    id INT AUTO_INCREMENT PRIMARY KEY,
    destination_folder_path VARCHAR(500) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS source_folders (
    id INT AUTO_INCREMENT PRIMARY KEY,
    folder_path VARCHAR(500) NOT NULL,
    is_imported TINYINT(1) DEFAULT 0,
    added_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS organization_rules (
    id INT AUTO_INCREMENT PRIMARY KEY,
    rule_name VARCHAR(255) NOT NULL,
    source_pattern VARCHAR(255) NOT NULL,
    destination_subfolder VARCHAR(255) NOT NULL,
    is_active TINYINT(1) DEFAULT 1,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS scanned_files (
    id INT AUTO_INCREMENT PRIMARY KEY,
    source_folder_id INT,
    file_name VARCHAR(255) NOT NULL,
    file_path VARCHAR(500) NOT NULL,
    file_extension VARCHAR(50),
    file_size BIGINT,
    file_hash VARCHAR(64),
    scanned_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (source_folder_id) REFERENCES source_folders(id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS operation_history (
    id INT AUTO_INCREMENT PRIMARY KEY,
    operation_type VARCHAR(50) NOT NULL,
    file_name VARCHAR(255),
    source_path VARCHAR(500),
    destination_path VARCHAR(500),
    file_size BIGINT,
    status VARCHAR(20) DEFAULT 'SUCCESS',
    performed_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS duplicate_groups (
    id INT AUTO_INCREMENT PRIMARY KEY,
    file_hash VARCHAR(64) NOT NULL,
    file_size BIGINT,
    detected_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS duplicate_files (
    id INT AUTO_INCREMENT PRIMARY KEY,
    group_id INT NOT NULL,
    file_name VARCHAR(255),
    file_path VARCHAR(500) NOT NULL,
    is_original TINYINT(1) DEFAULT 0,
    FOREIGN KEY (group_id) REFERENCES duplicate_groups(id) ON DELETE CASCADE
);
```
