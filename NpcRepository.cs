using System;
using System.Collections.Generic;
using System.Data.SQLite;
using NPCDialogueManager.Core.Interfaces;
using NPCDialogueManager.Core.Models;

namespace NPCDialogueManager.Data.Repositories
{
    public class NpcRepository : INpcRepository
    {
        public IEnumerable<NPC> GetAll()
        {
            var list = new List<NPC>();
            using (var conn = Db.Open())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM NPCs ORDER BY Name";
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read()) list.Add(Map(r));
                }
            }
            return list;
        }

        public NPC GetById(int id)
        {
            using (var conn = Db.Open())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM NPCs WHERE Id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return null;
                    return Map(r);
                }
            }
        }

        public int Create(NPC npc)
        {
            using (var conn = Db.Open())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
INSERT INTO NPCs (Name, Description, IsActive, CreatedByUserId)
VALUES (@Name, @Description, @IsActive, @CreatedByUserId);
SELECT last_insert_rowid();";
                cmd.Parameters.AddWithValue("@Name", npc.Name);
                cmd.Parameters.AddWithValue("@Description", (object)npc.Description ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IsActive", npc.IsActive ? 1 : 0);
                cmd.Parameters.AddWithValue("@CreatedByUserId", (object)npc.CreatedByUserId ?? DBNull.Value);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void Update(NPC npc)
        {
            using (var conn = Db.Open())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
UPDATE NPCs SET Name=@Name, Description=@Description, IsActive=@IsActive
WHERE Id=@Id;";
                cmd.Parameters.AddWithValue("@Name", npc.Name);
                cmd.Parameters.AddWithValue("@Description", (object)npc.Description ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IsActive", npc.IsActive ? 1 : 0);
                cmd.Parameters.AddWithValue("@Id", npc.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var conn = Db.Open())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM NPCs WHERE Id=@Id;";
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        private static NPC Map(SQLiteDataReader r)
        {
            return new NPC
            {
                Id = Convert.ToInt32(r["Id"]),
                Name = Convert.ToString(r["Name"]),
                Description = r["Description"] == DBNull.Value ? null : Convert.ToString(r["Description"]),
                IsActive = Convert.ToInt32(r["IsActive"]) == 1,
                CreatedByUserId = r["CreatedByUserId"] == DBNull.Value ? (int?)null : Convert.ToInt32(r["CreatedByUserId"])
            };
        }
    }
}

