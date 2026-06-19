-- ============================================================
-- Migration 002: Add execution_id & new columns to pre-existing tables
-- ============================================================
-- Run this once via phpMyAdmin (SQL tab) or MySQL CLI.
--
-- If you get "Duplicate column" errors, the column already
-- exists and you can skip that ALTER.
-- ============================================================

ALTER TABLE operation_history
    ADD COLUMN execution_id VARCHAR(36) NULL AFTER id;

ALTER TABLE destination_file_data
    ADD COLUMN execution_id VARCHAR(36) NULL AFTER id;

ALTER TABLE organization_rules
    ADD COLUMN execution_id INT NULL AFTER is_active,
    ADD COLUMN rule_source VARCHAR(20) NOT NULL DEFAULT 'custom' AFTER execution_id,
    ADD COLUMN created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP AFTER rule_source;

ALTER TABLE imported_files
    ADD COLUMN predicted_destination TEXT NULL AFTER destination_path;
