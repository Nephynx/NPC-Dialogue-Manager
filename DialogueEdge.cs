namespace NPCDialogueManager.Core.Models
{
    public class DialogueEdge
    {
        public int Id { get; set; }
        public int FromNodeId { get; set; }
        public int ToNodeId { get; set; }
        public string ChoiceText { get; set; }
        public string ConditionExpr { get; set; }
    }
}
