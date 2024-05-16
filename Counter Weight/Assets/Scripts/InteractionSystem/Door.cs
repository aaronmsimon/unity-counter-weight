using System.Linq;
using UnityEngine;

namespace CounterWeight.InteractionSystem
{
    public class Door : EnvironmentObject
    {
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
            transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - 100f));
        }

        public void Close()
        {
            Debug.Log("door closed");
            CompleteInteraction("Close");
            transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 100f));
        }

        private void CompleteInteraction(string interactionName)
        {
            GetInteractions().SingleOrDefault(i => i.interactionName.Value == interactionName).CompleteInteraction();
        }
    }
}
