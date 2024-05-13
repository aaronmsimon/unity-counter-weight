using UnityEngine;
using CounterWeight.Characters;

namespace CounterWeight.InteractionSystem
{
    public class Interactable : MonoBehaviour
    {
        [SerializeField] private string inspectResponse;
        [SerializeField] private Skill[] skills;
        [SerializeField] private InteractionsList interactionsList;

        public Skill[] Skills
        {
            get { return skills; }
        }

        public string Inspect()
        {
            return inspectResponse;
        }

        public void UpdateInteractionsList()
        {
            // Empty the list
            interactionsList.interactionNames.Clear();
            // Add Inspect since all interactables get that
            interactionsList.interactionNames.Add("Inspect");
            // Add Skills as other interactions
            for (int i = 0; i < skills.Length; i++)
            {
                interactionsList.interactionNames.Add(skills[i].SkillName);
            }
        }

        public bool SkillCheck(Skill skill)
        {
            for (int i = 0; i < skills.Length; i++)
            {
                if (skills[i].SkillName == skill.SkillName)
                {
                    Debug.Log($"player skill: {skill.SkillValue} vs item skill: {skills[i].SkillValue}");
                    return skill.SkillValue > skills[i].SkillValue;
                }
            }
            return false;
        }
    }
}
