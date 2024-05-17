using System.Reflection;
using UnityEngine;

namespace CounterWeight.InteractionSystem
{
    public class EnvironmentObject : MonoBehaviour, IInteractable
    {
        [SerializeField] private Interaction[] interactions;

        public Interaction[] GetInteractions()
        {
            return interactions;
        }
        
        public void Interact(string functionName)
        {
            MethodInfo methodInfo = this.GetType().GetMethod(functionName);
            if (methodInfo != null)
            {
                methodInfo.Invoke(this, null);
            }
            else
            {
                Debug.LogError("Method '" + functionName + "' not found on " + this);
            }
        }
    }
}
