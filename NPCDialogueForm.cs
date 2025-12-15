using System;
using System.Linq;
using System.Windows.Forms;
using NPCDialogueManager.Core.Models;
using NPCDialogueManager.Data.Repositories;

namespace NPCDialogueManager.App
{
    public partial class NPCDialogueForm : Form
    {
        private readonly NpcRepository _npcRepo = new NpcRepository();
        private readonly DialogueRepository _dialogueRepo = new DialogueRepository();
        private NPC _selectedNpc;

        public NPCDialogueForm()
        {
            InitializeComponent();
        }

        private void NPCDialogueForm_Load(object sender, EventArgs e)
        {
            cboNPC.DisplayMember = "Name";
            cboNPC.ValueMember = "Id";
            cboNPC.DataSource = _npcRepo.GetAll().ToList();
            lstNodes.DisplayMember = "NodeKey";
            dgvEdges.AutoGenerateColumns = true;
        }

        private void cboNPC_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedNpc = cboNPC.SelectedItem as NPC;
            LoadNodes();
            ClearNodeEditor();
        }

        private void LoadNodes()
        {
            if (_selectedNpc == null) return;
            var nodes = _dialogueRepo.GetNodesForNpc(_selectedNpc.Id).ToList();
            lstNodes.DataSource = nodes;
            dgvEdges.DataSource = null;
        }

        private void lstNodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstNodes.SelectedItem is DialogueNode node)
            {
                txtNodeId.Text = node.Id.ToString();
                txtNodeKey.Text = node.NodeKey;
                txtNodeText.Text = node.Text;
                chkIsRoot.Checked = node.IsRoot;

                var edges = _dialogueRepo.GetEdgesFromNode(node.Id).ToList();
                dgvEdges.DataSource = edges;
            }
        }

        private void btnAddNode_Click(object sender, EventArgs e)
        {
            if (_selectedNpc == null)
            {
                MessageBox.Show("Select an NPC first.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNodeKey.Text) || string.IsNullOrWhiteSpace(txtNodeText.Text))
            {
                MessageBox.Show("NodeKey and Text are required.");
                return;
            }
            var node = new DialogueNode
            {
                NpcId = _selectedNpc.Id,
                NodeKey = txtNodeKey.Text.Trim(),
                Text = txtNodeText.Text,
                IsRoot = chkIsRoot.Checked
            };
            var id = _dialogueRepo.CreateNode(node);
            LoadNodes();
            SelectNodeById(id);
        }

        private void btnUpdateNode_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtNodeId.Text, out var nodeId)) return;
            var node = _dialogueRepo.GetNodeById(nodeId);
            if (node == null) return;

            node.NodeKey = txtNodeKey.Text.Trim();
            node.Text = txtNodeText.Text;
            node.IsRoot = chkIsRoot.Checked;
            _dialogueRepo.UpdateNode(node);
            LoadNodes();
            SelectNodeById(node.Id);
        }

        private void btnDeleteNode_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtNodeId.Text, out var nodeId)) return;
            var confirm = MessageBox.Show("Delete this node? Edges from it will be orphaned.", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                _dialogueRepo.DeleteNode(nodeId);
                LoadNodes();
                ClearNodeEditor();
            }
        }

        private void btnAddEdge_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtNodeId.Text, out var fromId))
            {
                MessageBox.Show("Select a node first.");
                return;
            }
            if (!int.TryParse(txtToNodeId.Text, out var toId))
            {
                MessageBox.Show("Enter a valid ToNodeId.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtChoiceText.Text))
            {
                MessageBox.Show("ChoiceText is required.");
                return;
            }
            var edge = new DialogueEdge
            {
                FromNodeId = fromId,
                ToNodeId = toId,
                ChoiceText = txtChoiceText.Text.Trim(),
                ConditionExpr = txtConditionExpr.Text.Trim()
            };
            _dialogueRepo.CreateEdge(edge);
            dgvEdges.DataSource = _dialogueRepo.GetEdgesFromNode(fromId).ToList();
        }

        private void btnDeleteEdge_Click(object sender, EventArgs e)
        {
            if (dgvEdges.CurrentRow?.DataBoundItem is DialogueEdge edge)
            {
                _dialogueRepo.DeleteEdge(edge.Id);
                if (int.TryParse(txtNodeId.Text, out var fromId))
                {
                    dgvEdges.DataSource = _dialogueRepo.GetEdgesFromNode(fromId).ToList();
                }
            }
        }

        private void SelectNodeById(int id)
        {
            for (int i = 0; i < lstNodes.Items.Count; i++)
            {
                if (lstNodes.Items[i] is DialogueNode n && n.Id == id)
                {
                    lstNodes.SelectedIndex = i;
                    break;
                }
            }
        }

        private void ClearNodeEditor()
        {
            txtNodeId.Text = "";
            txtNodeKey.Text = "";
            txtNodeText.Text = "";
            chkIsRoot.Checked = false;
            dgvEdges.DataSource = null;
        }
    }
}
