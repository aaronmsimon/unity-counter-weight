using System.Collections.Generic;
using UnityEngine;

namespace CounterWeight.InteractionSystem
{
    [CreateAssetMenu(fileName = "New InteractionsList", menuName = "Interactions List")]
    public class InteractionsList : ScriptableObject
    {
        public List<string> interactionNames;
    }
}
