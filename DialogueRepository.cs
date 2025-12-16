using System;
using System.Collections.Generic;
using System.Data.SQLite;
using NPCDialogueManager.Core.Interfaces;
using NPCDialogueManager.Core.Models;

namespace NPCDialogueManager.Data.Repositories
{
    public class DialogueRepository : IDialogueRepository
    {
        public IEnumerable<DialogueNode> GetNodesForNpc(int npcId)
        {
            var list = new List<DialogueNode>();
            using (var conn = Db.Open())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM DialogueNodes WHERE NpcId=@NpcId ORDER BY Id";
                cmd.Parameters.AddWithValue("@NpcId", npcId);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read()) list.Add(MapNode(r));
                }
            }
            return list;
        }

        public DialogueNode GetRootNode(int npcId)
        {
            using (var conn = Db.Open())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM DialogueNodes WHERE NpcId=@NpcId AND IsRoot=1 LIMIT 1";
                cmd.Parameters.AddWithValue("@NpcId", npcId);
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return null;
                    return MapNode(r);
                }
            }
        }

        public DialogueNode GetNodeById(int nodeId)
        {
            using (var conn = Db.Open())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM DialogueNodes WHERE Id=@Id";
                cmd.Parameters.AddWithValue("@Id", nodeId);
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return null;
                    return MapNode(r);
                }
            }
        }

        public IEnumerable<DialogueEdge> GetEdgesFromNode(int nodeId)
        {
            var list = new List<DialogueEdge>();
            using (var conn = Db.Open())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM DialogueEdges WHERE FromNodeId=@FromNodeId ORDER BY Id";
                cmd.Parameters.AddWithValue("@FromNodeId", nodeId);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read()) list.Add(MapEdge(r));
                }
            }
            return list;
        }

        public int CreateNode(DialogueNode node)
        {
            using (var conn = Db.Open())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
INSERT INTO DialogueNodes (NpcId, NodeKey, Text, IsRoot)
VALUES (@NpcId, @NodeKey, @Text, @IsRoot);
SELECT last_insert_rowid();";
                cmd.Parameters.AddWithValue("@NpcId", node.NpcId);
                cmd.Parameters.AddWithValue("@NodeKey", node.NodeKey);
                cmd.Parameters.AddWithValue("@Text", node.Text);
                cmd.Parameters.AddWithValue("@IsRoot", node.IsRoot ? 1 : 0);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void UpdateNode(DialogueNode node)
        {
            using (var conn = Db.Open())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
UPDATE DialogueNodes SET NodeKey=@NodeKey, Text=@Text, IsRoot=@IsRoot WHERE Id=@Id;";
                cmd.Parameters.AddWithValue("@NodeKey", node.NodeKey);
                cmd.Parameters.AddWithValue("@Text", node.Text);
                cmd.Parameters.AddWithValue("@IsRoot", node.IsRoot ? 1 : 0);
                cmd.Parameters.AddWithValue("@Id", node.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteNode(int nodeId)
        {
            using (var conn = Db.Open())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM DialogueNodes WHERE Id=@Id;";
                cmd.Parameters.AddWithValue("@Id", nodeId);
                cmd.ExecuteNonQuery();
            }
        }

        public int CreateEdge(DialogueEdge edge)
        {
            using (var conn = Db.Open())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
INSERT INTO DialogueEdges (FromNodeId, ToNodeId, ChoiceText, ConditionExpr)
VALUES (@FromNodeId, @ToNodeId, @ChoiceText, @ConditionExpr);
SELECT last_insert_rowid();";
                cmd.Parameters.AddWithValue("@FromNodeId", edge.FromNodeId);
                cmd.Parameters.AddWithValue("@ToNodeId", edge.ToNodeId);
                cmd.Parameters.AddWithValue("@ChoiceText", edge.ChoiceText);
                cmd.Parameters.AddWithValue("@ConditionExpr", (object)edge.ConditionExpr ?? DBNull.Value);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void DeleteEdge(int edgeId)
        {
            using (var conn = Db.Open())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM DialogueEdges WHERE Id=@Id;";
                cmd.Parameters.AddWithValue("@Id", edgeId);
                cmd.ExecuteNonQuery();
            }
        }

        private static DialogueNode MapNode(SQLiteDataReader r)
        {
            return new DialogueNode
            {
                Id = Convert.ToInt32(r["Id"]),
                NpcId = Convert.ToInt32(r["NpcId"]),
                NodeKey = Convert.ToString(r["NodeKey"]),
                Text = Convert.ToString(r["Text"]),
                IsRoot = Convert.ToInt32(r["IsRoot"]) == 1
            };
        }

        private static DialogueEdge MapEdge(SQLiteDataReader r)
        {
            return new DialogueEdge
            {
                Id = Convert.ToInt32(r["Id"]),
                FromNodeId = Convert.ToInt32(r["FromNodeId"]),
                ToNodeId = Convert.ToInt32(r["ToNodeId"]),
                ChoiceText = Convert.ToString(r["ChoiceText"]),
                ConditionExpr = r["ConditionExpr"] == DBNull.Value ? null : Convert.ToString(r["ConditionExpr"])
            };
        }
    }
}

