using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CounterWeight.UI
{
    public class InteractionMenu : MonoBehaviour
    {
        [SerializeField] private Button buttonPrefab;

        public void AddButton(string buttonText)
        {
            TextMeshProUGUI label = buttonPrefab.GetComponentInChildren<TextMeshProUGUI>();
            label.text = buttonText;
            Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity, this.transform);
        }
    }
}
