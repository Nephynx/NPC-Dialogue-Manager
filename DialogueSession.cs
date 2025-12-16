using System;

namespace NPCDialogueManager.Core.Models
{
    public class DialogueSession
    {
        public int Id { get; set; }
        public int NpcId { get; set; }
        public int UserId { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }
    }
}
