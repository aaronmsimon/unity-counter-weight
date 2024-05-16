using UnityEngine;

namespace CounterWeight.InteractionSystem
{
    [CreateAssetMenu(fileName = "New CurrentInteractable", menuName = "Decoupling Code/Current Interactable")]
    public class CurrentInteractable : ScriptableObject
    {
        public IInteractable interactable;
    }
}
