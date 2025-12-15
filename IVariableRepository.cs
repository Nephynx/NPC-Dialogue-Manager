using System.Collections.Generic;
using NPCDialogueManager.Core.Models;

namespace NPCDialogueManager.Core.Interfaces
{
    public interface IVariableRepository
    {
        IEnumerable<DialogueVariable> GetVariables(string scope, int? npcId = null);
        void Upsert(DialogueVariable variable);
    }
}
