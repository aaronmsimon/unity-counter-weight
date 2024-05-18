using System.Reflection;
using UnityEngine;
using CounterWeight.Characters;
using UnityEngine.Rendering.Universal;

namespace CounterWeight.InteractionSystem
{
    public enum EnvrionmentObjectArgs {
        Character
    }

    public class EnvironmentObject : MonoBehaviour, IInteractable
    {
        [SerializeField] private Interaction[] interactions;

        public Interaction[] GetInteractions()
        {
            return interactions;
        }
        
        public void Interact(Interaction interaction, object[] args)
        {
            string functionName = interaction.interactionName.Value;
            MethodInfo methodInfo = this.GetType().GetMethod(functionName);
            if (methodInfo != null)
            {
                Character character = (Character)args[(int)EnvrionmentObjectArgs.Character];

                // If character doesn't have the skill, then automatic fail
                Skill interactionSkill = interaction.skillCheck;                
                if (interactionSkill != null)
                {
                    int characterSkill = character.GetSkill(interactionSkill) != null ? character.GetSkill(interactionSkill).SkillLevel : -1;
                    if (characterSkill <= interactionSkill.SkillLevel)
                    {
                        Debug.Log("failed skill check for " + interactionSkill.SkillName.Value);
                        return;
                    }
                }
                methodInfo.Invoke(this, null);
            }
            else
            {
                Debug.LogError("Method '" + functionName + "' not found on " + this);
            }
        }
    }
}
