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
            inspectReponse = "There is a computer on the desk with controls to various systems.";
            
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
