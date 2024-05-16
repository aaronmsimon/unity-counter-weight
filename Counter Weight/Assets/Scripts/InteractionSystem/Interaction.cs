using System;
using CounterWeight.Variables;
using RoboRyanTron.Unite2017.Variables;

namespace CounterWeight.InteractionSystem
{
    [Serializable]
    public class Interaction
    {
        public StringVariable interactionName;
        public BoolVariable prerequisite;
        public BoolVariable completion;

        public void CompleteInteraction()
        {
            prerequisite.Value = true;
        }
    }
}
