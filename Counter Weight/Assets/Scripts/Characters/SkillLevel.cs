using System;
using UnityEngine;
using CounterWeight.Characters;

namespace CounterWeight.InteractionSystem
{
    [Serializable]
    public class SkillLevel : ISkillCheck
    {
        public Skill skill;
        public int level;

        public bool CheckSkill(Character character)
        {
            // Perform skill check logic
            // For example, check if the character's skill level is sufficient
            Debug.Log($"{skill.SkillName}: {level} and character skill is {character.GetSkillLevel(this)}");
            return character.GetSkillLevel(this) >= level;
        }
    }
}
