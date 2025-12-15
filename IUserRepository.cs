using NPCDialogueManager.Core.Models;

namespace NPCDialogueManager.Core.Interfaces
{
    public interface IUserRepository
    {
        User GetByUsername(string username);
        User GetById(int id);
        int Create(User user);
        void Update(User user);
    }
}
