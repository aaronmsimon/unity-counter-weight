using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CounterWeight.InteractionSystem;
using RoboRyanTron.Unite2017.Variables;
using RoboRyanTron.Unite2017.Events;

namespace CounterWeight.UI
{
    public class InteractionMenu : MonoBehaviour
    {
        // [SerializeField] private InteractionsList interactionsList;
        [SerializeField] private Button buttonPrefab;
        [SerializeField] private GameEvent interaction;
        [SerializeField] private StringVariable interactionName;

        private RectTransform rectTransform;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        private void OnEnable()
        {
            PopulateInteractions();
        }

        private void OnDisable()
        {
            ClearInteractions();
        }

        private void PopulateInteractions()
        {
            // foreach (string interactionText in interactionsList.interactionNames)
            // {
            //     TextMeshProUGUI label = buttonPrefab.GetComponentInChildren<TextMeshProUGUI>();
            //     label.text = interactionText;
            //     Button button = Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity, this.transform);
            //     button.onClick.AddListener(() => {interactionName.Value = interactionText;interaction.Raise();});
            // }
        }

        private void ClearInteractions()
        {
            for (int i = rectTransform.childCount - 1; i >= 0; i--)
            {
                DestroyImmediate(rectTransform.GetChild(i).gameObject);
            }
        }
    }
}
