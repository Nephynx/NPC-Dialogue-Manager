using System;
using System.Windows.Forms;

namespace NPCDialogueManager.App
{
    public partial class HomePageForm : Form
    {
        public HomePageForm()
        {
            InitializeComponent();
        }

        private void HomePageForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, {AppConfig.CurrentUser?.DisplayName}";

            lblAbout.Text = 
                "INTRODUCTION: NPC Dialogue Manager Project\n\n" +
                "a tool for managing how NPCs interact with players." +
                 "It lets developers create, organize, and play dialogues," +
                 "making NPC conversations dynamic and engaging. " +
                 "With the NPC Manager, Dialogue Manager," +
                 "and Dialogue Player, the system ensures smooth," +
                 "responsive interactions that enhance " +
                 "storytelling and player experience.";

        }
        private void btnManageNPCs_Click_1(object sender, EventArgs e)
        {
            using (var f = new NPCManagerForm()) f.ShowDialog();

        }

        private void btnManageDialogue_Click(object sender, EventArgs e)
        {
            using (var f = new NPCDialogueForm()) f.ShowDialog();
        }

        private void btnPlayDialogue_Click_1(object sender, EventArgs e)
        {
            using (var f = new DialoguePlayerForm()) f.ShowDialog();
        }

        private void btnReports_Click_1(object sender, EventArgs e)
        {
            using (var f = new ReportStatusForm()) f.ShowDialog();
        }

        private void btnEditAccount_Click_1(object sender, EventArgs e)
        {
            using (var f = new AccountEditingForm()) f.ShowDialog();
        }
        private void btnAccounts_Click(object sender, EventArgs e)
        {
            using (var f = new AccountsForm()) f.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}