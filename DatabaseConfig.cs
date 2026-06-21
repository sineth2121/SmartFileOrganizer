using MySql.Data.MySqlClient;

namespace SmartFileOrganizer
{
    public static class DatabaseConfig
    {
        private static string connectionString = "Server=localhost;Port=3306;Database=smart_file_organizer;Uid=root;Pwd=;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
