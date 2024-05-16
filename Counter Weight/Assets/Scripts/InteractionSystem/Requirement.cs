using System;
using CounterWeight.Variables;

namespace CounterWeight.InteractionSystem
{
    [Serializable]
    public class Requirement
    {
        public BoolVariable requirementVar;
        public bool requiredBool;
    }
}
