using UnityEngine;

namespace CounterWeight.InteractionSystem
{
    [CreateAssetMenu(fileName = "New CurrentEnvironmentObject", menuName = "Decoupling Code/Current Environment Object")]
    public class CurrentEnvironmentObject : ScriptableObject
    {
        public EnvironmentObject environmentObject;
    }
}
