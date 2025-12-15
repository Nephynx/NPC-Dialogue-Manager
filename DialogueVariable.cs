namespace NPCDialogueManager.Core.Models
{
    public class DialogueVariable
    {
        public int Id { get; set; }
        public string Scope { get; set; } // Global/NPC/User
        public int? NpcId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
