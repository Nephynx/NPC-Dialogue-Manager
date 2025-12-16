using System.Collections.Generic;

using NPCDialogueManager.Core.Interfaces;
using NPCDialogueManager.Core.Models;

namespace NPCDialogueManager.Core.Services
{
    public class ReportingService : IReportingService
    {
        private readonly ISessionRepository _sessions;
        public ReportingService(ISessionRepository sessions) => _sessions = sessions;

        public IEnumerable<DialogueSession> GetSessionsForNpc(int npcId) => _sessions.GetSessionsForNpc(npcId);

        public IEnumerable<DialogueSessionLog> GetSessionLogs(int sessionId) => _sessions.GetLogs(sessionId);
    }
}

