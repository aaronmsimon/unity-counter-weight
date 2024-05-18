using System;
using RoboRyanTron.Unite2017.Variables;

namespace CounterWeight.InteractionSystem
{
    [Serializable]
    public class Interaction
    {
        public StringVariable interactionName;
        public Requirement[] prerequisite;
        public Requirement[] completion;
        public Skill skillCheck;

        public void CompleteInteraction()
        {
            foreach (Requirement req in completion)
            {
                req.requirementVar.Value = req.requiredBool;
            }
        }
    }
}
