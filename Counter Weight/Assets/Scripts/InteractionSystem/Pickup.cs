using UnityEngine;

namespace CounterWeight.InteractionSystem
{
    public class Pickup : MonoBehaviour, IInteractable
    {
        [SerializeField] private string response;

        public void Interact()
        {
            Debug.Log($"{this} was picked up");
        }

        public string TextResponse()
        {
            return response;
        }
    }
}
