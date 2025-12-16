     namespace NPCDialogueManager.Core.Models
    {
        public class NPC
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public bool IsActive { get; set; }
            public int? CreatedByUserId { get; set; }
        }
    }
