using CounterWeight.Characters;

namespace CounterWeight.InteractionSystem
{
    public interface IInteractable
    {
        void Inspect();
        void Interact(Character character);
    }
}
