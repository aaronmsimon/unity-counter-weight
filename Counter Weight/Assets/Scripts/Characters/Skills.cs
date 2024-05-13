using UnityEngine;

namespace CounterWeight.Characters
{
    public class Skills : MonoBehaviour
    {
        [SerializeField] private Skill[] skills;

        public Skill GetSkillByName(string skillName)
        {
            for (int i = 0; i < skills.Length; i++)
            {
                if (skills[i].SkillName == skillName)
                {
                    return skills[i];
                }
            }
            return null;
        }
    }
}
