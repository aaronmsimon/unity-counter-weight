using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CounterWeight.InteractionSystem;
using CounterWeight.Characters;

namespace CounterWeight.UI
{
    public class InteractionMenu : MonoBehaviour
    {
        [Header("Menu Graphics")]
        [SerializeField] private Button buttonPrefab;

        [Header("Source Data")]
        [SerializeField] private CurrentEnvironmentObject currentEnvironmentObject;
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
            TextMeshProUGUI label = buttonPrefab.GetComponentInChildren<TextMeshProUGUI>();
            Button button;
            // Inspect
            label.text = "Inspect";
            button = Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity, this.transform);
            button.onClick.AddListener(currentEnvironmentObject.environmentObject.Inspect);
            // Required Skill
            label.text = currentEnvironmentObject.environmentObject.requiredSkill.SkillName.Value;
            button = Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity, this.transform);
            button.onClick.AddListener(() => currentEnvironmentObject.environmentObject.Interact(TEMPORARY_character));
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
