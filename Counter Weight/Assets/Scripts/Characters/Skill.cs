using CounterWeight.InteractionSystem;
using UnityEngine;

namespace CounterWeight.Characters
{
    [CreateAssetMenu(fileName = "New Skill", menuName = "Characters/Skill")]
    public class Skill : ScriptableObject
    {
        [SerializeField] private string skillName;

        public string SkillName { get { return skillName; } }
    }
}
