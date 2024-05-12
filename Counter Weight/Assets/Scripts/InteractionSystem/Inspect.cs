using UnityEngine;

namespace CounterWeight.InteractionSystem
{
    public class Inspect : MonoBehaviour, IInteractable
    {
        [SerializeField] private string response;

        public void Interact()
        {
            Debug.Log($"{this} was inspected");
        }

        public string TextResponse()
        {
            return response;
        }
    }
}
