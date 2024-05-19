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
            // mark if open/closed after unlock and then just locked before that?
            Debug.Log("inspect");
        }

        public void LockPick()
        {
            Debug.Log("picked!");
            CompleteInteraction("LockPick");
        }

        public void Open()
        {
            Debug.Log("door opened");
            CompleteInteraction("Open");
            // transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, 80f, transform.eulerAngles.z));
            transform.eulerAngles = new Vector3(270f, 0f, 80f);
        }

        public void Close()
        {
            // Debug.Log($"x: {transform.eulerAngles.x} y: {transform.eulerAngles.y} z: {transform.eulerAngles.z} ");
            Debug.Log("door closed");
            CompleteInteraction("Close");
            // transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, 180f, transform.eulerAngles.y));
            transform.eulerAngles = new Vector3(270f, 0f, 180f);
        }

        private void CompleteInteraction(string interactionName)
        {
            GetInteractions().SingleOrDefault(i => i.interactionName.Value == interactionName).CompleteInteraction();
        }
    }
}
