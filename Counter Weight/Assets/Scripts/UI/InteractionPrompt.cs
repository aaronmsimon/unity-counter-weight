using UnityEngine;
using CounterWeight.InteractionSystem;

namespace CounterWeight.UI
{
    public class InteractionPrompt : MonoBehaviour
    {
        [Header("UI Element Control")]
        [SerializeField] private GameObject prompt;

        [Header("Source Data")]
        [SerializeField] private CurrentInteractable currentInteractable;

        private void Update()
        {
            prompt.SetActive(currentInteractable.interactable != null);
        }
    }
}
