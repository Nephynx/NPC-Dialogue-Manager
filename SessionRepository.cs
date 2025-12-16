using System;
using System.Collections.Generic;
using NPCDialogueManager.Core.Interfaces;
using NPCDialogueManager.Core.Models;

namespace NPCDialogueManager.Data.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        public int StartSession(int npcId, int userId)
        {
            using (var conn = Db.Open())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
INSERT INTO DialogueSessions (NpcId, UserId)
VALUES (@NpcId, @UserId);
SELECT last_insert_rowid();";
                cmd.Parameters.AddWithValue("@NpcId", npcId);
                cmd.Parameters.AddWithValue("@UserId", userId);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void EndSession(int sessionId)
        {
            using (var conn = Db.Open())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "UPDATE DialogueSessions SET EndedAt=CURRENT_TIMESTAMP WHERE Id=@Id";
                cmd.Parameters.AddWithValue("@Id", sessionId);
                cmd.ExecuteNonQuery();
            }
        }

        public void LogStep(int sessionId, int nodeId, string choiceText)
        {
            using (var conn = Db.Open())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
INSERT INTO DialogueSessionLogs (SessionId, NodeId, ChoiceText)
VALUES (@SessionId, @NodeId, @ChoiceText);";
                cmd.Parameters.AddWithValue("@SessionId", sessionId);
                cmd.Parameters.AddWithValue("@NodeId", nodeId);
                cmd.Parameters.AddWithValue("@ChoiceText", (object)choiceText ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<DialogueSessionLog> GetLogs(int sessionId)
        {
            var list = new List<DialogueSessionLog>();
            using (var conn = Db.Open())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM DialogueSessionLogs WHERE SessionId=@SessionId ORDER BY Timestamp";
                cmd.Parameters.AddWithValue("@SessionId", sessionId);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new DialogueSessionLog
                        {
                            Id = Convert.ToInt32(r["Id"]),
                            SessionId = Convert.ToInt32(r["SessionId"]),
                            NodeId = Convert.ToInt32(r["NodeId"]),
                            ChoiceText = r["ChoiceText"] == DBNull.Value ? null : Convert.ToString(r["ChoiceText"]),
                            Timestamp = DateTime.Parse(Convert.ToString(r["Timestamp"]))
                        });
                    }
                }
            }
            return list;
        }

        public IEnumerable<DialogueSession> GetSessionsForNpc(int npcId)
        {
            var list = new List<DialogueSession>();
            using (var conn = Db.Open())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM DialogueSessions WHERE NpcId=@NpcId ORDER BY StartedAt DESC";
                cmd.Parameters.AddWithValue("@NpcId", npcId);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new DialogueSession
                        {
                            Id = Convert.ToInt32(r["Id"]),
                            NpcId = Convert.ToInt32(r["NpcId"]),
                            UserId = Convert.ToInt32(r["UserId"]),
                            StartedAt = DateTime.Parse(Convert.ToString(r["StartedAt"])),
                            EndedAt = r["EndedAt"] == DBNull.Value ? (DateTime?)null : DateTime.Parse(Convert.ToString(r["EndedAt"]))
                        });
                    }
                }
            }
            return list;
        }
    }
}

