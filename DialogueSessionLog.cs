using System;

namespace NPCDialogueManager.Core.Models
{
    public class DialogueSessionLog
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public int NodeId { get; set; }
        public string ChoiceText { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
