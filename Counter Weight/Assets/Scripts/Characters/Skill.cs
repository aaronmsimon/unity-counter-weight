using System;
using CounterWeight.Characters;
using RoboRyanTron.Unite2017.Variables;

namespace CounterWeight.InteractionSystem
{
    [Serializable]
    public class Skill
    {
        public StringVariable SkillName;
        public int SkillLevel;

        public bool CheckSkill(Character character)
        {
            // Perform skill check logic
            // For example, check if the character's skill level is sufficient
            return character.GetSkillLevel(this) >= SkillLevel;
        }
    }
}
