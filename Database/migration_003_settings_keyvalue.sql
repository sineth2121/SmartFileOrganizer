-- Migration 003: Convert app_settings from single-row to key-value pattern
-- This enables storing multiple settings without schema changes.

-- Step 1: Create the new key-value table
CREATE TABLE IF NOT EXISTS app_settings_new (
    id INT AUTO_INCREMENT PRIMARY KEY,
    setting_key VARCHAR(100) NOT NULL UNIQUE,
    setting_value TEXT,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Step 2: Migrate existing destination_folder_path if the old table exists
INSERT IGNORE INTO app_settings_new (setting_key, setting_value, updated_at)
SELECT 'destination_folder_path', destination_folder_path, COALESCE(created_at, NOW())
FROM app_settings
WHERE destination_folder_path IS NOT NULL AND destination_folder_path != '';

-- Step 3: Drop old table and rename new one
DROP TABLE IF EXISTS app_settings_old;
ALTER TABLE app_settings RENAME TO app_settings_old;
ALTER TABLE app_settings_new RENAME TO app_settings;
DROP TABLE IF EXISTS app_settings_old;
