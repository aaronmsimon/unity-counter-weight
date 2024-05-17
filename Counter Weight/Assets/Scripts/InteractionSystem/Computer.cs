using System.Linq;
using UnityEngine;

namespace CounterWeight.InteractionSystem
{
    public class Computer : EnvironmentObject
    {
        [SerializeField] private Light roomLight;

        public void Inspect()
        {
            Debug.Log("inspect");
        }

        public void Hack()
        {
            Debug.Log("hacked!");
            CompleteInteraction("Hack");
        }

        public void TurnOnLights()
        {
            CompleteInteraction("TurnOnLights");
            roomLight.gameObject.SetActive(true);
        }

        public void TurnOffLights()
        {
            CompleteInteraction("TurnOffLights");
            roomLight.gameObject.SetActive(false);
        }

        private void CompleteInteraction(string interactionName)
        {
            GetInteractions().SingleOrDefault(i => i.interactionName.Value == interactionName).CompleteInteraction();
        }
    }
}
