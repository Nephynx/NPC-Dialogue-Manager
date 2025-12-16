using System;
using System.Text;

// NPCDialogueManager.Core/Services/AuthService.cs
using System.Security.Cryptography;
using NPCDialogueManager.Core.Interfaces;
using NPCDialogueManager.Core.Models;

namespace NPCDialogueManager.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _repo;
        public AuthService(IUserRepository repo) => _repo = repo;

        public User Login(string username, string password)
        {
            var user = _repo.GetByUsername(username);
            if (user == null) return null;
            var hash = Hash(password);
            return user.PasswordHash == hash ? user : null;
        }

        public int Register(string username, string password, string displayName)
        {
            var exists = _repo.GetByUsername(username);
            if (exists != null) throw new InvalidOperationException("Username already taken.");
            var user = new User
            {
                Username = username,
                PasswordHash = Hash(password),
                DisplayName = displayName,
                Role = "User",
                CreatedAt = DateTime.UtcNow
            };
            return _repo.Create(user);
        }

        public void UpdateAccount(User user, string newPassword = null)
        {
            if (!string.IsNullOrWhiteSpace(newPassword))
            {
                user.PasswordHash = Hash(newPassword);
            }
            _repo.Update(user);
        }

        private static string Hash(string input)
        {
            using (var sha = SHA256.Create())
            {
                var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}

