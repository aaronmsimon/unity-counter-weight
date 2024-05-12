using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CounterWeight.InteractionSystem;

namespace CounterWeight.UI
{
    public class InteractionMenu : MonoBehaviour
    {
        [SerializeField] private Button buttonPrefab;

        public void AddButton(IInteractable interactable)
        {
            TextMeshProUGUI label = buttonPrefab.GetComponentInChildren<TextMeshProUGUI>();
            label.text = interactable.GetType().Name;
            Button button = Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity, this.transform);
            button.onClick.AddListener(interactable.Interact);
        }
    }
}
