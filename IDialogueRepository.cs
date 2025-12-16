using System.Collections.Generic;

using NPCDialogueManager.Core.Models;

namespace NPCDialogueManager.Core.Interfaces
{
    public interface IDialogueRepository
    {
        IEnumerable<DialogueNode> GetNodesForNpc(int npcId);
        DialogueNode GetRootNode(int npcId);
        DialogueNode GetNodeById(int nodeId);
        IEnumerable<DialogueEdge> GetEdgesFromNode(int nodeId);
        int CreateNode(DialogueNode node);
        void UpdateNode(DialogueNode node);
        void DeleteNode(int nodeId);
        int CreateEdge(DialogueEdge edge);
        void DeleteEdge(int edgeId);
    }
}

