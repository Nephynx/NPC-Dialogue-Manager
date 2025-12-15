using System.Collections.Generic;
using NPCDialogueManager.Core.Interfaces;
using NPCDialogueManager.Core.Models;

namespace NPCDialogueManager.Core.Services
{
    public class NpcService : INpcService
    {
        private readonly INpcRepository _repo;
        public NpcService(INpcRepository repo) => _repo = repo;

        public IEnumerable<NPC> GetAll() => _repo.GetAll();

        public NPC Create(string name, string description, int createdByUserId)
        {
            var npc = new NPC { Name = name, Description = description, IsActive = true, CreatedByUserId = createdByUserId };
            npc.Id = _repo.Create(npc);
            return npc;
        }

        public void Update(NPC npc) => _repo.Update(npc);

        public void Delete(int id) => _repo.Delete(id);
    }
}

