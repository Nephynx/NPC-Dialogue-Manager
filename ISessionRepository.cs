using System.Collections.Generic;
using NPCDialogueManager.Core.Models;

namespace NPCDialogueManager.Core.Interfaces
{
    public interface ISessionRepository
    {
        int StartSession(int npcId, int userId);
        void EndSession(int sessionId);
        void LogStep(int sessionId, int nodeId, string choiceText);
        IEnumerable<DialogueSessionLog> GetLogs(int sessionId);
        IEnumerable<DialogueSession> GetSessionsForNpc(int npcId);
    }
}

