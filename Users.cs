using System;

    namespace NPCDialogueManager.Core.Models
    {
        public class User
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public string PasswordHash { get; set; }
            public string DisplayName { get; set; }
            public string Role { get; set; } // Admin/User
            public DateTime CreatedAt { get; set; }
            public DateTime? UpdatedAt { get; set; }

        }
    }