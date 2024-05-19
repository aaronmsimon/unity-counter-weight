using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CounterWeight.InteractionSystem;
using CounterWeight.Characters;
using RoboRyanTron.Unite2017.Events;

namespace CounterWeight.UI
{
    public class InteractionMenu : MonoBehaviour
    {
        [Header("Menu Handling")]
        [SerializeField] private Button buttonPrefab;
        [SerializeField] private GameEvent closeMenu;

        [Header("Source Data")]
        [SerializeField] private CurrentInteractable currentInteractable;
        [SerializeField] private Character TEMPORARY_character;

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
            bool addInteraction;
            foreach (Interaction interaction in currentInteractable.interactable.GetInteractions())
            {
                addInteraction = true;
                foreach (Requirement prereq in interaction.prerequisite)
                {
                    if (prereq.requirementVar.Value != prereq.requiredBool)
                    {
                        addInteraction = false;
                        break;
                    }
                }
                foreach (Requirement req in interaction.completion)
                {
                    if (req.requirementVar.Value == req.requiredBool)
                    {
                        addInteraction = false;
                        break;
                    }
                }
                if (addInteraction)
                {
                    // All prerequisites met
                    TextMeshProUGUI label = buttonPrefab.GetComponentInChildren<TextMeshProUGUI>();
                    label.text = interaction.interactionName.Value;
                    Button button = Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity, this.transform);
                    object[] parameters = new object[] { TEMPORARY_character };
                    button.onClick.AddListener(() => {
                        currentInteractable.interactable.Interact(interaction, parameters);
                        closeMenu.Raise();
                    });
                }
            }
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
