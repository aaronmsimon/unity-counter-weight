namespace CounterWeight.InteractionSystem
{
    public interface IInteractable
    {
        Interaction[] GetInteractions();
        void Interact(string functionName);
    }
}