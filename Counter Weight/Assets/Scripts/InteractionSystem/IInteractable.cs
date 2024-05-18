namespace CounterWeight.InteractionSystem
{
    public interface IInteractable
    {
        Interaction[] GetInteractions();
        void Interact(Interaction interaction, object[] args);
    }
}