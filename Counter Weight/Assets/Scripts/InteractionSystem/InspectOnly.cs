using UnityEngine;

namespace CounterWeight.InteractionSystem
{
    public class InspectOnly : EnvironmentObject
    {
        [SerializeField] private string inspectResponse;

        public void Inspect()
        {
            Debug.Log(inspectResponse);
        }
    }
}
