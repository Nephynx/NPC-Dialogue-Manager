using System.Data.SQLite;

namespace NPCDialogueManager.Data
{
    public static class Db
    {
        public static string ConnectionString { get; set; }

        public static SQLiteConnection Open()
        {
            var conn = new SQLiteConnection(ConnectionString);
            conn.Open();
            return conn;
        }
    }
}
