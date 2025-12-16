// NPCDialogueManager.App/Forms/AccountsForm.cs
using System;
using System.Linq;
using System.Windows.Forms;
using NPCDialogueManager.Core.Models;
using NPCDialogueManager.Data.Repositories;

namespace NPCDialogueManager.App
{
    public partial class AccountsForm : Form
    {
        private readonly UserRepository _userRepo = new UserRepository();

        public AccountsForm()
        {
            InitializeComponent();
        }

        private void AccountsForm_Load(object sender, EventArgs e)
        {
            RefreshGrid();
            dgvAccounts.AutoGenerateColumns = true;

            // Hide sensitive columns
            if (dgvAccounts.Columns["PasswordHash"] != null)
                dgvAccounts.Columns["PasswordHash"].Visible = false;
            if (dgvAccounts.Columns["Id"] != null)
                dgvAccounts.Columns["Id"].Visible = false;
        }

        private void RefreshGrid()
        {
            dgvAccounts.DataSource = _userRepo.GetAllActive().ToList();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvAccounts.CurrentRow?.DataBoundItem is User user)
            {
                var confirm = MessageBox.Show(
                    $"Soft delete account '{user.Username}'?",
                    "Confirm",
                    MessageBoxButtons.YesNo
                );
                if (confirm == DialogResult.Yes)
                {
                    _userRepo.SoftDelete(user.Id);
                    RefreshGrid();
                }
            }
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            RefreshGrid();
        }
    }
}
