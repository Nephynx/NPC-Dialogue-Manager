using System;
using System.Collections.Generic;
using NPCDialogueManager.Core.Interfaces;
using NPCDialogueManager.Core.Models;

namespace NPCDialogueManager.Data.Repositories
{
    public class VariableRepository : IVariableRepository
    {
        public IEnumerable<DialogueVariable> GetVariables(string scope, int? npcId = null)
        {
            var list = new List<DialogueVariable>();
            using (var conn = Db.Open())
            using (var cmd = conn.CreateCommand())
            {
                if (npcId.HasValue)
                {
                    cmd.CommandText = "SELECT * FROM DialogueVariables WHERE Scope=@Scope AND NpcId=@NpcId";
                    cmd.Parameters.AddWithValue("@Scope", scope);
                    cmd.Parameters.AddWithValue("@NpcId", npcId.Value);
                }
                else
                {
                    cmd.CommandText = "SELECT * FROM DialogueVariables WHERE Scope=@Scope AND NpcId IS NULL";
                    cmd.Parameters.AddWithValue("@Scope", scope);
                }
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new DialogueVariable
                        {
                            Id = Convert.ToInt32(r["Id"]),
                            Scope = Convert.ToString(r["Scope"]),
                            NpcId = r["NpcId"] == DBNull.Value ? (int?)null : Convert.ToInt32(r["NpcId"]),
                            Key = Convert.ToString(r["Key"]),
                            Value = r["Value"] == DBNull.Value ? null : Convert.ToString(r["Value"])
                        });
                    }
                }
            }
            return list;
        }

        public void Upsert(DialogueVariable variable)
        {
            using (var conn = Db.Open())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
INSERT INTO DialogueVariables (Scope, NpcId, Key, Value)
VALUES (@Scope, @NpcId, @Key, @Value)
ON CONFLICT(Key) DO UPDATE SET Value=excluded.Value;";
                cmd.Parameters.AddWithValue("@Scope", variable.Scope);
                if (variable.NpcId.HasValue)
                    cmd.Parameters.AddWithValue("@NpcId", variable.NpcId.Value);
                else
                    cmd.Parameters.AddWithValue("@NpcId", DBNull.Value);
                cmd.Parameters.AddWithValue("@Key", variable.Key);
                cmd.Parameters.AddWithValue("@Value", (object)variable.Value ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

