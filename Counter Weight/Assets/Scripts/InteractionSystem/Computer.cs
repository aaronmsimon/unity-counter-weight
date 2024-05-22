using System.Linq;
using CounterWeight.Variables;
using UnityEngine;

namespace CounterWeight.InteractionSystem
{
    public class Computer : EnvironmentObject
    {
        [SerializeField] private Light roomLight;

        [Header("Scene Setup")]
        [SerializeField] private BoolVariable lightsOn;

        private void Start()
        {
            if (lightsOn.Value)
            {
                TurnOnLights();
            }
            else
            {
                TurnOffLights();
            }
        }

        public void Inspect()
        {
            message.Value = "There is a computer on the desk with controls to various systems.";
        }

        public void EnterPassword()
        {
            message.Value = "Password entered successfully.";
            CompleteInteraction("EnterPassword");
        }

        public void Hack()
        {
            message.Value = "The computer has been hacked successfully.";
            CompleteInteraction("Hack");
        }

        public void TurnOnLights()
        {
            message.Value = null;
            CompleteInteraction("TurnOnLights");
            roomLight.gameObject.SetActive(true);
        }

        public void TurnOffLights()
        {
            message.Value = null;
            CompleteInteraction("TurnOffLights");
            roomLight.gameObject.SetActive(false);
        }

        private void CompleteInteraction(string interactionName)
        {
            GetInteractions().SingleOrDefault(i => i.interactionName.Value == interactionName).CompleteInteraction();
        }
    }
}
