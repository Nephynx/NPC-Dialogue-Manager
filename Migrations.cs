using System.Data.SQLite;

namespace NPCDialogueManager.Data
{
    public static class Migrations
    {
        public static void EnsureCreated()
        {
            using (var conn = Db.Open())
            using (var cmd = conn.CreateCommand())
            {
                // Create tables if they don't exist
                cmd.CommandText = @"
CREATE TABLE IF NOT EXISTS Users (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Username TEXT UNIQUE NOT NULL,
    PasswordHash TEXT NOT NULL,
    DisplayName TEXT,
    Role TEXT NOT NULL DEFAULT 'User',
    CreatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt DATETIME
);

CREATE TABLE IF NOT EXISTS NPCs (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL,
    Description TEXT,
    IsActive INTEGER NOT NULL DEFAULT 1,
    CreatedByUserId INTEGER,
    FOREIGN KEY (CreatedByUserId) REFERENCES Users(Id)
);

CREATE TABLE IF NOT EXISTS DialogueNodes (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    NpcId INTEGER NOT NULL,
    NodeKey TEXT NOT NULL,
    Text TEXT NOT NULL,
    IsRoot INTEGER NOT NULL DEFAULT 0,
    FOREIGN KEY (NpcId) REFERENCES NPCs(Id)
);

CREATE TABLE IF NOT EXISTS DialogueEdges (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    FromNodeId INTEGER NOT NULL,
    ToNodeId INTEGER NOT NULL,
    ChoiceText TEXT NOT NULL,
    ConditionExpr TEXT,
    FOREIGN KEY (FromNodeId) REFERENCES DialogueNodes(Id),
    FOREIGN KEY (ToNodeId) REFERENCES DialogueNodes(Id)
);

CREATE TABLE IF NOT EXISTS DialogueVariables (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Scope TEXT NOT NULL,
    NpcId INTEGER,
    Key TEXT NOT NULL,
    Value TEXT,
    FOREIGN KEY (NpcId) REFERENCES NPCs(Id)
);

CREATE TABLE IF NOT EXISTS DialogueSessions (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    NpcId INTEGER NOT NULL,
    UserId INTEGER NOT NULL,
    StartedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    EndedAt DATETIME,
    FOREIGN KEY (NpcId) REFERENCES NPCs(Id),
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

CREATE TABLE IF NOT EXISTS DialogueSessionLogs (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    SessionId INTEGER NOT NULL,
    NodeId INTEGER NOT NULL,
    ChoiceText TEXT,
    Timestamp DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (SessionId) REFERENCES DialogueSessions(Id),
    FOREIGN KEY (NodeId) REFERENCES DialogueNodes(Id)
);
";
                cmd.ExecuteNonQuery();
            }

            // Ensure IsActive column exists in Users
            EnsureColumnExists("Users", "IsActive", "INTEGER NOT NULL DEFAULT 1");
        }

        private static void EnsureColumnExists(string table, string column, string definition)
        {
            using (var conn = Db.Open())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = $"PRAGMA table_info({table});";
                using (var reader = cmd.ExecuteReader())
                {
                    bool found = false;
                    while (reader.Read())
                    {
                        if (reader["name"].ToString().Equals(column, System.StringComparison.OrdinalIgnoreCase))
                        {
                            found = true;
                            break;
                        }
                    }
                    reader.Close();

                    if (!found)
                    {
                        using (var alter = conn.CreateCommand())
                        {
                            alter.CommandText = $"ALTER TABLE {table} ADD COLUMN {column} {definition};";
                            alter.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}
