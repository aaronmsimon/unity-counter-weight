using System.Linq;
using CounterWeight.Variables;
using UnityEngine;

namespace CounterWeight.InteractionSystem
{
    public class Door : EnvironmentObject
    {
        [Header("Scene Setup")]
        [SerializeField] private BoolVariable doorOpened;

        private void Start()
        {
            if (doorOpened.Value)
            {
                Open();
            }
            else
            {
                Close();
            }
        }

        public void Inspect()
        {
            Debug.Log("inspect");
        }

        public void UnlockWithKey()
        {
            Debug.Log("unlocked");
            CompleteInteraction("UnlockWithKey");
        }

        public void LockPick()
        {
            Debug.Log("picked!");
            CompleteInteraction("LockPick");
        }

        public void Open()
        {
            inspectReponse = "The door is open";
            CompleteInteraction("Open");
            transform.eulerAngles = new Vector3(270f, 0f, 80f);
        }

        public void Close()
        {
            inspectReponse = "The door is closed";
            CompleteInteraction("Close");
            transform.eulerAngles = new Vector3(270f, 0f, 180f);
        }

        private void CompleteInteraction(string interactionName)
        {
            GetInteractions().SingleOrDefault(i => i.interactionName.Value == interactionName).CompleteInteraction();
        }
    }
}
