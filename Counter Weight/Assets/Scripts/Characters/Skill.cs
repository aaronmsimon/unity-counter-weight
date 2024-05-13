using UnityEngine;

namespace CounterWeight.Characters
{
    [CreateAssetMenu(fileName = "New Skill", menuName = "Characters/Skill")]
    public class Skill : ScriptableObject
    {
        [SerializeField] private string skillName;
        [SerializeField] private int skillValue;

        public string SkillName { get { return skillName; } }
        public int SkillValue { get { return skillValue; } }
    }
}
