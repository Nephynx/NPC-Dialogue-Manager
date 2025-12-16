using System;
using System.Windows.Forms;
using NPCDialogueManager.Core.Services;
using NPCDialogueManager.Data.Repositories;

namespace NPCDialogueManager.App
{
    public partial class AccountEditingForm : Form
    {
        private readonly AuthService _auth = new AuthService(new UserRepository());

        public AccountEditingForm()
        {
            InitializeComponent();
        }

        private void AccountEditingForm_Load(object sender, EventArgs e)
        {
            var u = AppConfig.CurrentUser;
            txtUsername.Text = u.Username;
            txtDisplayName.Text = u.DisplayName;
            txtUsername.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var u = AppConfig.CurrentUser;
            u.DisplayName = txtDisplayName.Text.Trim();
            var newPwd = string.IsNullOrWhiteSpace(txtNewPassword.Text) ? null : txtNewPassword.Text;
            _auth.UpdateAccount(u, newPwd);
            MessageBox.Show("Account updated.");
            this.Close();
        }
    }
}
