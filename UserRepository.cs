using NPCDialogueManager.Core.Interfaces;
using NPCDialogueManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace NPCDialogueManager.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User GetByUsername(string username)
        {
            using (var conn = Db.Open())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Users WHERE Username=@u AND IsActive=1";
                cmd.Parameters.AddWithValue("@u", username);
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read()) return null;
                    return Map(reader);
                }
            }
        }

        public void SoftDelete(int id)
        {
            using (var conn = Db.Open())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "UPDATE Users SET IsActive=0 WHERE Id=@Id;";
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<User> GetAllActive()
        {
            var list = new List<User>();
            using (var conn = Db.Open())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Users WHERE IsActive=1 ORDER BY Username";
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read()) list.Add(Map(r));
                }
            }
            return list;
        }



        public User GetById(int id)
        {
            using (var conn = Db.Open())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Users WHERE Id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read()) return null;
                    return Map(reader);
                }
            }
        }

        public int Create(User user)
        {
            using (var conn = Db.Open())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    INSERT INTO Users (Username, PasswordHash, DisplayName, Role)
                    VALUES (@Username, @PasswordHash, @DisplayName, @Role);
                    SELECT last_insert_rowid();";
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                cmd.Parameters.AddWithValue("@DisplayName", user.DisplayName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Role", user.Role ?? "User");
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void Update(User user)
        {
            using (var conn = Db.Open())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                   UPDATE Users SET
                   DisplayName = @DisplayName,
                   PasswordHash = @PasswordHash,
                   Role = @Role,
                   UpdatedAt = CURRENT_TIMESTAMP
                   WHERE Id = @Id;";
                cmd.Parameters.AddWithValue("@DisplayName", user.DisplayName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                cmd.Parameters.AddWithValue("@Role", user.Role ?? "User");
                cmd.Parameters.AddWithValue("@Id", user.Id);
                cmd.ExecuteNonQuery();
            }
        }

        private static User Map(SQLiteDataReader r)
        {
            return new User
            {
                Id = Convert.ToInt32(r["Id"]),
                Username = Convert.ToString(r["Username"]),
                PasswordHash = Convert.ToString(r["PasswordHash"]),
                DisplayName = r["DisplayName"] == DBNull.Value ? null : Convert.ToString(r["DisplayName"]),
                Role = Convert.ToString(r["Role"]),
                CreatedAt = DateTime.Parse(Convert.ToString(r["CreatedAt"])),
                UpdatedAt = r["UpdatedAt"] == DBNull.Value ? (DateTime?)null : DateTime.Parse(Convert.ToString(r["UpdatedAt"]))
            };
        }
    }
}

