
CREATE DATABASE IF NOT EXISTS smart_file_organizer
    CHARACTER SET utf8mb4
    COLLATE utf8mb4_unicode_ci;

USE smart_file_organizer;
CREATE TABLE IF NOT EXISTS app_settings (
    id              INT             AUTO_INCREMENT PRIMARY KEY,
    setting_key     VARCHAR(100)    NOT NULL UNIQUE,
    setting_value   TEXT,
    updated_at      DATETIME        DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS imported_files (
    id                  INT             AUTO_INCREMENT PRIMARY KEY,
    file_name           VARCHAR(255)    NOT NULL,
    file_path           TEXT            NOT NULL,
    file_extension      VARCHAR(50)     NULL,
    file_size           BIGINT          NOT NULL DEFAULT 0,
    file_modified_date  DATETIME        NULL,
    file_type           VARCHAR(20)     NOT NULL DEFAULT 'File',
    is_excluded         TINYINT(1)      NOT NULL DEFAULT 0,
    operation_type      VARCHAR(10)     NOT NULL DEFAULT 'Copy',
    source_path         TEXT            NULL,
    destination_path    TEXT            NULL,
    predicted_destination TEXT          NULL,
    imported_date       DATETIME        NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


CREATE TABLE IF NOT EXISTS operation_history (
    id                  INT             AUTO_INCREMENT PRIMARY KEY,
    execution_id        VARCHAR(36)     NULL,
    operation_type      VARCHAR(50)     NOT NULL,
    file_name           VARCHAR(255)    NULL,
    source_path         VARCHAR(500)    NULL,
    destination_path    VARCHAR(500)    NULL,
    file_size           BIGINT          NULL,
    status              VARCHAR(20)     NOT NULL DEFAULT 'SUCCESS',
    performed_at        TIMESTAMP       NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


CREATE TABLE IF NOT EXISTS organization_rules (
    id                      INT             AUTO_INCREMENT PRIMARY KEY,
    rule_name               VARCHAR(255)    NOT NULL,
    ext_category            VARCHAR(255)    NULL,
    age_days                VARCHAR(50)     NULL,
    keyword_match           VARCHAR(255)    NULL,
    size_min                BIGINT          NULL,
    size_max                BIGINT          NULL,
    destination_subfolder   VARCHAR(255)    NOT NULL,
    is_active               TINYINT(1)      NOT NULL DEFAULT 1,
    execution_id            INT             NULL,
    rule_source             VARCHAR(20)     NOT NULL DEFAULT 'custom',
    created_at              DATETIME        NOT NULL DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (execution_id) REFERENCES operation_history(id) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


CREATE TABLE IF NOT EXISTS destination_file_data (
    id                  INT             AUTO_INCREMENT PRIMARY KEY,
    execution_id        VARCHAR(36)     NULL,
    file_name           VARCHAR(255)    NOT NULL,
    file_extension      VARCHAR(50)     NULL,
    file_size           BIGINT          NOT NULL DEFAULT 0,
    file_modified_date  DATETIME        NULL,
    file_type           VARCHAR(20)     NOT NULL DEFAULT 'File',
    is_excluded         TINYINT(1)      NOT NULL DEFAULT 0,
    operation_type      VARCHAR(10)     NOT NULL DEFAULT 'Copy',
    source_path         TEXT            NULL,
    destination_path    TEXT            NULL,
    file_hash           VARCHAR(64)     NULL,
    imported_date       DATETIME        NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


-- Upgrade existing tables — add missing columns if upgrading

ALTER TABLE organization_rules ADD COLUMN size_min BIGINT NULL AFTER keyword_match;
ALTER TABLE organization_rules ADD COLUMN size_max BIGINT NULL AFTER size_min;
ALTER TABLE operation_history ADD COLUMN execution_id VARCHAR(36) NULL AFTER id;
ALTER TABLE imported_files ADD COLUMN predicted_destination TEXT NULL AFTER destination_path;
ALTER TABLE destination_file_data ADD COLUMN execution_id VARCHAR(36) NULL AFTER id;
ALTER TABLE destination_file_data ADD COLUMN file_hash VARCHAR(64) NULL AFTER destination_path;
