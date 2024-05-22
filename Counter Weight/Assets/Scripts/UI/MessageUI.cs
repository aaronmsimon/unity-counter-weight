using UnityEngine;
using RoboRyanTron.Unite2017.Variables;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace CounterWeight.UI
{
    public class MessageUI : MonoBehaviour
    {
        [Header("Scriptable Object Data")]
        [SerializeField] private StringVariable speaker;
        [SerializeField] private StringVariable message;

        [Header("UI Components")]
        [SerializeField] private TextMeshProUGUI speakerUI;
        [SerializeField] private TextMeshProUGUI messageUI;
        [SerializeField] private GameObject messageContainer;

        public void PopulateMessageUI()
        {
            speakerUI.text = speaker.Value;
            messageUI.text = message.Value;

            messageContainer.SetActive(message.Value != null);
        }

        private void Update()
        {
            InputSystem.onAnyButtonPress.CallOnce(ctrl => {
                messageContainer.SetActive(false);
            });
        }
    }
}
