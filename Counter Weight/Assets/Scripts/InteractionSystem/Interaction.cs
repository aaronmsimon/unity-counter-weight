using System;
using RoboRyanTron.Unite2017.Variables;
using CounterWeight.Variables;

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
