using UnityEngine;

namespace CounterWeight.InteractionSystem
{
    public class Interactions : MonoBehaviour
    {
        private IInteractable[] interactables;

        private void Start()
        {
            interactables = GetComponents<IInteractable>();
        }

        public IInteractable[] Interactables
        {
            get
            {
                return interactables;
            }
        }
    }
}
