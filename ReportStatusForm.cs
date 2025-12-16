using System;
using System.Linq;
using System.Windows.Forms;
using NPCDialogueManager.Core.Services;
using NPCDialogueManager.Data.Repositories;

namespace NPCDialogueManager.App
{
    public partial class ReportStatusForm : Form
    {
        private readonly NpcRepository _npcRepo = new NpcRepository();
        private readonly ReportingService _report = new ReportingService(new SessionRepository());

        public ReportStatusForm()
        {
            InitializeComponent();
        }

        private void ReportStatusForm_Load(object sender, EventArgs e)
        {
            cboNPC.DisplayMember = "Name";
            cboNPC.ValueMember = "Id";
            cboNPC.DataSource = _npcRepo.GetAll().ToList();
            dgvSessions.AutoGenerateColumns = true;
            dgvLogs.AutoGenerateColumns = true;
        }

        private void dgvSessions_SelectionChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSessions.CurrentRow?.DataBoundItem is NPCDialogueManager.Core.Models.DialogueSession s)
            {
                var logs = _report.GetSessionLogs(s.Id).OrderBy(l => l.Timestamp).ToList();
                dgvLogs.DataSource = logs;
            }
        }

        private void dgvLogs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboNPC_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var npc = cboNPC.SelectedItem as NPCDialogueManager.Core.Models.NPC;
            if (npc == null) return;
            var sessions = _report.GetSessionsForNpc(npc.Id).OrderByDescending(s => s.StartedAt).ToList();
            dgvSessions.DataSource = sessions;
            dgvLogs.DataSource = null;
        }
    }
}
