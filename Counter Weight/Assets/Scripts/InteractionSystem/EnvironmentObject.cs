using UnityEngine;
using CounterWeight.Characters;

namespace CounterWeight.InteractionSystem
{
    public class EnvironmentObject : MonoBehaviour, IInteractable
    {
        public string inspectResponse;
        public Skill requiredSkill;

        public virtual void Inspect()
        {
            Debug.Log(inspectResponse);
        }

        public virtual void Interact(Character character)
        {
        }

        public Skill GetRequiredSkill()
        {
            return requiredSkill;
        }

        public bool SkillCheck(Character character)
        {
            // Check if the character passes the required skill check
            return requiredSkill.CheckSkill(character);
        }
    }
}
