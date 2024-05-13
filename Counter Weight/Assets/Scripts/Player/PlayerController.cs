// using CounterWeight.InteractionSystem;
using CounterWeight.InteractionSystem;
using CounterWeight.UI;
using RoboRyanTron.Unite2017.Events;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CounterWeight.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float interactRange;
        [SerializeField] private bool showInteractRange;
        [SerializeField] private GameEvent showInteractMenuEventHandler;
        [SerializeField] private GameEvent hideInteractMenuEventHandler;
        [SerializeField] private GameEvent showInteractPromptEventHandler;
        [SerializeField] private GameEvent hideInteractPromptEventHandler;
        // [SerializeField] private InteractionMenu interactionMenu;

        private PlayerControls playerControls;

        private void Awake()
        {
            playerControls = new PlayerControls();
        }

        private void OnEnable()
        {
            playerControls.Enable();

            // playerControls.Gameplay.Interact.performed += CheckCollisions;
            playerControls.Gameplay.Interact.performed += Interact;
        }

        private void OnDisable()
        {
            playerControls.Disable();

            // playerControls.Gameplay.Interact.performed -= CheckCollisions;
            playerControls.Gameplay.Interact.performed -= Interact;
        }

        private void Update()
        {
            Move();
            CheckForInteractables();
        }

        private void Move()
        {
            // Get input for movement
            Vector2 moveInput = playerControls.Gameplay.Move.ReadValue<Vector2>();
            float horizontalInput = moveInput.x;
            float verticalInput = moveInput.y;

            // Calculate movement direction relative to camera
            Vector3 cameraForward = Camera.main.transform.forward;
            Vector3 cameraRight = Camera.main.transform.right;
            cameraForward.y = 0f;
            cameraRight.y = 0f;
            cameraForward.Normalize();
            cameraRight.Normalize();
            Vector3 moveDirection = cameraForward * verticalInput + cameraRight * horizontalInput;

            // Apply movement
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
        }

        private void CheckForInteractables()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent(out Interactable interactable))
                {
                    interactable.UpdateInteractionsList();
                    showInteractPromptEventHandler.Raise();
                    return;
                }
            }            
            hideInteractPromptEventHandler.Raise();
            hideInteractMenuEventHandler.Raise();
        }

        private void CheckCollisions(InputAction.CallbackContext context) {
            Collider[] colliders = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliders)
            {
                // if (collider.TryGetComponent(out Interactions interactions))
                // {
                //     for (int i = 0; i < interactions.Interactables.Length; i++)
                //     {
                //         interactionMenu.AddButton(interactions.Interactables[i]);
                //     }
                //     openInteractMenuEventHandler.Raise();
                // }
            }
        }

        private void Interact(InputAction.CallbackContext context) {
            Collider[] colliders = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent(out Interactable interactable))
                {
                    for (int i = 0; i < interactable.Skills.Length; i++)
                    {
                        showInteractMenuEventHandler.Raise();
                    }
                }
            }
        }

        private void OnDrawGizmos() {
            Gizmos.color = Color.red;
            if (showInteractRange)
            {
                Gizmos.DrawWireSphere(transform.position, interactRange);
            }
        }
    }
}
