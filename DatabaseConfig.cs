using System;
using MySql.Data.MySqlClient;

namespace SmartFileOrganizer
{
    public static class DatabaseConfig
    {
        // 1. One global connection string used by the entire application
        private static string connectionString = "Server=localhost;Port=3306;Database=smart_file_organizer;Uid=root;Pwd=;";

        // 2. A global, static method that any form can call at any time
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
