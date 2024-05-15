using UnityEngine;
using CounterWeight.Characters;

namespace CounterWeight.InteractionSystem
{
    public class Interactable : MonoBehaviour
    {
        [SerializeField] private SkillLevel requiredSkill;

        public void Interact(Character character)
        {
            // Check if the character passes the required skill check
            if (requiredSkill.CheckSkill(character))
            {
                // Perform actions if skill check passed
                Debug.Log("Skill check passed!");
            }
            else
            {
                // Perform actions if skill check failed
                Debug.Log("Skill check failed!");
            }
        }
    }
}
