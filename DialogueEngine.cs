using System;
using System.Collections.Generic;
using System.Linq;
using NPCDialogueManager.Core.Interfaces;
using NPCDialogueManager.Core.Models;

namespace NPCDialogueManager.Core.DialogueEngine
{
    public class DialogueEngine
    {
        private readonly IDialogueRepository _dialogueRepo;
        private readonly IVariableRepository _varRepo;
        private DialogueNode _current;

        public DialogueEngine(IDialogueRepository dialogueRepo, IVariableRepository varRepo)
        {
            _dialogueRepo = dialogueRepo;
            _varRepo = varRepo;
        }

        public DialogueNode Start(int npcId)
        {
            _current = _dialogueRepo.GetRootNode(npcId);
            return _current;
        }

        public DialogueNode Current => _current;

        public IEnumerable<DialogueEdge> GetAvailableChoices(IDictionary<string, string> contextVars)
        {
            var edges = _dialogueRepo.GetEdgesFromNode(_current.Id);
            return edges.Where(e => EvaluateCondition(e.ConditionExpr, contextVars));
        }

        public DialogueNode Choose(DialogueEdge edge)
        {
            _current = _dialogueRepo.GetNodeById(edge.ToNodeId);
            return _current;
        }

        private bool EvaluateCondition(string expr, IDictionary<string, string> ctx)
        {
            if (string.IsNullOrWhiteSpace(expr)) return true;
            bool hasEq = expr.Contains("==");
            bool hasNe = expr.Contains("!=");
            string[] parts;
            if (hasEq)
            {
                parts = expr.Split(new[] { "==" }, StringSplitOptions.None);
            }
            else if (hasNe)
            {
                parts = expr.Split(new[] { "!=" }, StringSplitOptions.None);
            }
            else
            {
                return true;
            }
            if (parts.Length != 2) return true;
            var key = parts[0].Trim();
            var value = parts[1].Trim();
            if (!ctx.TryGetValue(key, out var v)) return hasNe; // if “!=” and missing, pass
            if (hasEq) return string.Equals(v, value, StringComparison.OrdinalIgnoreCase);
            return !string.Equals(v, value, StringComparison.OrdinalIgnoreCase);
        }
    }
}
