using System;
using System.Windows.Forms;
using NPCDialogueManager.Core.Services;
using NPCDialogueManager.Data.Repositories;

namespace NPCDialogueManager.App
{
    public partial class AccountCreationForm : Form
    {
        private readonly AuthService _auth = new AuthService(new UserRepository());

        public AccountCreationForm()
        {
            InitializeComponent();
            tbPassword.UseSystemPasswordChar = true;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(tbUsername.Text) || string.IsNullOrWhiteSpace(tbPassword.Text) || string.IsNullOrWhiteSpace(tbDisplayName.Text))
                {
                    MessageBox.Show("cannot be empty");

                }
                else
                {
                    _auth.Register(tbUsername.Text.Trim(), tbPassword.Text, tbDisplayName.Text.Trim());
                    MessageBox.Show("Account created. You can log in now.");
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
