using System.Collections.Generic;
namespace NPCDialogueManager.Core.Models
{
    public class DialogueNode
    {
        public int Id { get; set; }
        public int NpcId { get; set; }
        public string NodeKey { get; set; }
        public string Text { get; set; }
        public bool IsRoot { get; set; }
        public List<DialogueEdge> Edges { get; set; } = new List<DialogueEdge>();
    }
}
