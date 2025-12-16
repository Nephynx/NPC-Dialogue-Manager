using NPCDialogueManager.Core.Models;
using NPCDialogueManager.Core.Services;
using NPCDialogueManager.Data.Repositories;
using System;
using System.Linq;
using System.Windows.Forms;

namespace NPCDialogueManager.App
{
    public partial class NPCManagerForm : Form
    {
        private readonly NpcService _npcService = new NpcService(new NpcRepository());

        public NPCManagerForm()
        {
            InitializeComponent();
        }

        private void NPCManagerForm_Load(object sender, EventArgs e)
        {
            RefreshGrid();
            dgvNPCs.AutoGenerateColumns = true;
        }

        private void RefreshGrid()
        {
            var data = _npcService.GetAll().ToList();
            dgvNPCs.DataSource = data;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name is required.");
                return;
            }
            var npc = _npcService.Create(txtName.Text.Trim(), txtDescription.Text.Trim(), AppConfig.CurrentUser.Id);
            RefreshGrid();
            SelectRowById(npc.Id);
        }

        private void dgvNPCs_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNPCs.CurrentRow?.DataBoundItem is NPC npc)
            {
                txtName.Text = npc.Name;
                txtDescription.Text = npc.Description;
                chkIsActive.Checked = npc.IsActive;
            }
        }

        private void SelectRowById(int id)
        {
            foreach (DataGridViewRow row in dgvNPCs.Rows)
            {
                if (row.DataBoundItem is NPC n && n.Id == id)
                {
                    row.Selected = true;
                    dgvNPCs.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (dgvNPCs.CurrentRow?.DataBoundItem is NPC npc)
            {
                npc.Name = txtName.Text.Trim();
                npc.Description = txtDescription.Text.Trim();
                _npcService.Update(npc);
                RefreshGrid();
                SelectRowById(npc.Id);
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvNPCs.CurrentRow?.DataBoundItem is NPC npc)
            {
                var confirm = MessageBox.Show($"Delete '{npc.Name}'?", "Confirm", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    _npcService.Delete(npc.Id);
                    RefreshGrid();
                }
            }
        }

        private void chkIsActive_CheckedChanged_1(object sender, EventArgs e)
        {
            if (dgvNPCs.CurrentRow?.DataBoundItem is NPC npc)
            {
                npc.IsActive = chkIsActive.Checked;
                _npcService.Update(npc);
                RefreshGrid();
                SelectRowById(npc.Id);
            }
        }
    }
}
