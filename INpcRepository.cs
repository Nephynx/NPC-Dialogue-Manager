using System.Collections.Generic;

using NPCDialogueManager.Core.Models;

namespace NPCDialogueManager.Core.Interfaces
{
    public interface INpcRepository
    {
        IEnumerable<NPC> GetAll();
        NPC GetById(int id);
        int Create(NPC npc);
        void Update(NPC npc);
        void Delete(int id);
    }
}
