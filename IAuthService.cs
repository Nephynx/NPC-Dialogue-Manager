using System.Collections.Generic;

using NPCDialogueManager.Core.Models;

namespace NPCDialogueManager.Core.Interfaces
{
    public interface IAuthService
    {
        User Login(string username, string password);
        int Register(string username, string password, string displayName);
        void UpdateAccount(User user, string newPassword = null);
    }

    public interface INpcService
    {
        IEnumerable<NPC> GetAll();
        NPC Create(string name, string description, int createdByUserId);
        void Update(NPC npc);
        void Delete(int id);
    }

    public interface IDialogueService
    {
        DialogueNode GetRoot(int npcId);
        DialogueNode GetNode(int nodeId);
        IEnumerable<DialogueEdge> GetChoices(int nodeId, IDictionary<string, string> contextVars);
        DialogueNode Traverse(int toNodeId);
    }

    public interface IReportingService
    {
        IEnumerable<DialogueSession> GetSessionsForNpc(int npcId);
        IEnumerable<DialogueSessionLog> GetSessionLogs(int sessionId);
    }
}
