-- ============================================================
-- Create imported_files table (with full metadata + copy/cut support)
-- ============================================================

CREATE TABLE imported_files (
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
    imported_date       DATETIME        NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ============================================================
-- Create operation_history table (audit log for file operations)
-- ============================================================
CREATE TABLE IF NOT EXISTS operation_history (
    id                  INT             AUTO_INCREMENT PRIMARY KEY,
    operation_type      VARCHAR(50)     NOT NULL,
    file_name           VARCHAR(255)    NULL,
    source_path         VARCHAR(500)    NULL,
    destination_path    VARCHAR(500)    NULL,
    file_size           BIGINT          NULL,
    status              VARCHAR(20)     NOT NULL DEFAULT 'SUCCESS',
    performed_at        TIMESTAMP       NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ============================================================
-- organization_rules — automation rules for file routing
-- ============================================================
CREATE TABLE IF NOT EXISTS organization_rules (
    id                      INT             AUTO_INCREMENT PRIMARY KEY,
    rule_name               VARCHAR(255)    NOT NULL,
    ext_category            VARCHAR(255)    NULL,
    age_days                VARCHAR(50)     NULL,
    keyword_match           VARCHAR(255)    NULL,
    destination_subfolder   VARCHAR(255)    NOT NULL,
    is_active               TINYINT(1)      NOT NULL DEFAULT 1,
    execution_id            INT             NULL,
    rule_source             VARCHAR(20)     NOT NULL DEFAULT 'custom',
    created_at              DATETIME        NOT NULL DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (execution_id) REFERENCES operation_history(id) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- If upgrading an existing database (table already created without execution_id),
-- run this manually:
-- ALTER TABLE organization_rules
--     ADD COLUMN execution_id INT NULL AFTER is_active,
--     ADD FOREIGN KEY (execution_id) REFERENCES operation_history(id) ON DELETE SET NULL;
