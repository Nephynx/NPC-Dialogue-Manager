using NPCDialogueManager.Core.Services;
using NPCDialogueManager.Data.Repositories;
using System;
using System.Windows.Forms;

namespace NPCDialogueManager.App
{
    public partial class LoginPageForm : Form
    {
        private readonly AuthService _auth;

        public LoginPageForm()
        {
            InitializeComponent();
            _auth = new AuthService(new UserRepository());
            tbPassword.UseSystemPasswordChar = true;
        }

        private void btnLoginAccount_Click(object sender, EventArgs e)
        {
            var user = _auth.Login(tbUsername.Text.Trim(), tbPassword.Text);
            if (user == null)
            {
                MessageBox.Show("Invalid credentials.");
                return;
            }
            AppConfig.CurrentUser = user;
            var home = new HomePageForm();
            home.Show();
            this.Hide();
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var dlg = new AccountCreationForm())
            {
                dlg.ShowDialog();
            }
        }

        private void btnExitApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            tbPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
}
