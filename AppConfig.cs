using System;
using System.IO;
using NPCDialogueManager.Core.Models;

namespace NPCDialogueManager.App
{
    public static class AppConfig
    {
        public static string DbPath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "npc_dialogue.db");
        public static string ConnectionString => $"Data Source={DbPath};Version=3;";
        public static User CurrentUser { get; set; }
    }
}
