using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NPCDialogueManager.Core.DialogueEngine;
using NPCDialogueManager.Core.Models;
using NPCDialogueManager.Data.Repositories;

namespace NPCDialogueManager.App
{
    public partial class DialoguePlayerForm : Form
    {
        private readonly NpcRepository _npcRepo = new NpcRepository();
        private readonly DialogueRepository _dialogueRepo = new DialogueRepository();
        private readonly VariableRepository _varRepo = new VariableRepository();
        private readonly SessionRepository _sessionRepo = new SessionRepository();
        private DialogueEngine _engine;
        private int _sessionId;
        private NPC _npc;

        public DialoguePlayerForm()
        {
            InitializeComponent();
        }

        private void DialoguePlayerForm_Load(object sender, EventArgs e)
        {
            cboNPC.DisplayMember = "Name";
            cboNPC.ValueMember = "Id";
            cboNPC.DataSource = _npcRepo.GetAll().ToList();
            lstChoices.DisplayMember = "ChoiceText";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _npc = cboNPC.SelectedItem as NPC;
            if (_npc == null)
            {
                MessageBox.Show("Select an NPC.");
                return;
            }

            _engine = new DialogueEngine(_dialogueRepo, _varRepo);
            var root = _engine.Start(_npc.Id);
            if (root == null)
            {
                MessageBox.Show("This NPC has no root node.");
                return;
            }

            _sessionId = _sessionRepo.StartSession(_npc.Id, AppConfig.CurrentUser.Id);
            RenderNode(root);
        }

        private void RenderNode(DialogueNode node)
        {
            lblNpcName.Text = _npc.Name;
            txtNodeText.Text = node.Text;
            lstChoices.Items.Clear();

            var ctx = LoadContextVars();
            var choices = _engine.GetAvailableChoices(ctx).ToList();
            foreach (var c in choices) lstChoices.Items.Add(c);

            lblNodeId.Text = $"Node Id: {node.Id}";
        }

        private Dictionary<string, string> LoadContextVars()
        {
            var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (var v in _varRepo.GetVariables("Global"))
                dict[v.Key] = v.Value ?? "";
            foreach (var v in _varRepo.GetVariables("NPC", _npc.Id))
                dict[v.Key] = v.Value ?? "";
            // Optionally: per-user/session variables can be merged here later.
            return dict;
        }

        private void lstChoices_DoubleClick(object sender, EventArgs e)
        {
            if (lstChoices.SelectedItem is DialogueEdge edge)
            {
                _sessionRepo.LogStep(_sessionId, _engine.Current.Id, edge.ChoiceText);
                var next = _engine.Choose(edge);
                if (next == null)
                {
                    MessageBox.Show("No next node found.");
                    return;
                }
                RenderNode(next);
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (_sessionId > 0)
            {
                _sessionRepo.EndSession(_sessionId);
                _sessionId = 0;
            }
            MessageBox.Show("Dialogue ended.");
        }
    }
}
