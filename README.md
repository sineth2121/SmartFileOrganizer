# SmartFileOrganizer

A Windows Forms app that helps you actually get your files in order. Pick a folder, set some rules, and let it sort everything out.

Built with .NET Framework 4.7.2, backed by MySQL.

## What it can do

Once you've run the SQL script in `Database/schema.sql` to set up the tables, you get:

- **Import folders** — pick a source folder, optionally exclude certain subfolders, choose Copy or Cut (move), and it'll scan everything into the database. Shows you what it's doing with a progress bar.
- **Build rules** — batch templates (sort by file type, age, alphabetical range, size, or date modified) or build custom rules with extension matching, age filters, keywords, and size ranges. Rules are first-match-wins.
- **Preview & organize** — see a tree of where everything *would* go before you commit. Then execute the move or copy. Logs everything to history.
- **Operation history** — look at past runs grouped by execution, see what was moved where, and undo them if you screwed up.
- **Duplicate cleaner** — scan by hash (MD5), name+size, name only, or size only. Shows you one set at a time, lets you pick which copies to delete.
- **Dashboard** — summary cards (imported count, organized count, active rules, duplicate stats), a pie chart of file types, a bar chart of ops per day, and drive space info.

## Things that are a bit janky

- **Connection string** is hardcoded in `DatabaseConfig.cs`. The Settings page lets you test a different connection, but it doesn't actually update the app's connection — only the Test Connection button works.
- `FormSettings` stores a handful of settings (`excluded_extensions`, `max_file_size_mb`, etc.) into the `app_settings` table, but they're not read anywhere yet. Future-proofing, I guess.
- Schema has to be created manually. Run `Database/schema.sql` in MySQL Workbench, phpMyAdmin, or whatever you use.
- Some event handlers in the designer files are just empty stubs that never got cleaned up. Doesn't break anything, just looks sloppy.

## Database tables

| Table | What it holds |
|---|---|
| `app_settings` | Key-value store for every setting (destination path, DB creds, toggles, etc.) |
| `imported_files` | Every file and folder scanned during import, with exclusion flags and predicted destinations |
| `organization_rules` | Rules that decide where files go — extension, keyword, age, size conditions |
| `destination_file_data` | Archive of files that have been organized (with hash for duplicate detection) |
| `operation_history` | Audit log of every copy/move/delete, grouped by execution_id for undo |

## Quick start

1. Clone or download.
2. Open `SmartFileOrganizer.slnx` in Visual Studio (2022 or later).
3. Restore NuGet packages.
4. Run the SQL in `Database/schema.sql` on your MySQL instance.
5. Update the connection string in `DatabaseConfig.cs` if your MySQL isn't the default localhost/root/no-password setup.
6. Hit F5.


