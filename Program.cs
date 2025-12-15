using NPC_Dialogue_Manager;
using NPCDialogueManager.Data;
using System;
using System.Windows.Forms;

namespace NPCDialogueManager.App
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Db.ConnectionString = AppConfig.ConnectionString;
            Migrations.EnsureCreated();

            Application.Run(new LoginPageForm());
        }
    }
}
