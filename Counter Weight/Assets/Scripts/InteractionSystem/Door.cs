using UnityEngine;

namespace CounterWeight.InteractionSystem
{
    public class Door : EnvironmentObject
    {
        public void Inspect()
        {
            Debug.Log("inspect");
        }

        public void LockPick()
        {
            Debug.Log("picked!");
        }
    }
}
