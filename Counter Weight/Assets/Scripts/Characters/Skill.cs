using UnityEngine;
using RoboRyanTron.Unite2017.Variables;

namespace CounterWeight.InteractionSystem
{
    [CreateAssetMenu(fileName = "New Skill", menuName = "Skill")]
    public class Skill : ScriptableObject
    {
        public StringVariable SkillName;
        public int SkillLevel;
    }
}
