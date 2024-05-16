namespace CounterWeight.InteractionSystem
{
    public interface IInteractable
    {
        delegate void InteractDelegate();

        Interaction[] GetInteractions();
        void Interact(string functionName);

    }
}