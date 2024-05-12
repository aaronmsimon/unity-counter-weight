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
        [SerializeField] private GameEvent openInteractMenuEventHandler;
        [SerializeField] private InteractionMenu interactionMenu;

        private PlayerControls playerControls;

        private void Awake()
        {
            playerControls = new PlayerControls();
        }

        private void OnEnable()
        {
            playerControls.Enable();

            playerControls.Gameplay.Interact.performed += CheckCollisions;
        }

        private void OnDisable()
        {
            playerControls.Disable();

            playerControls.Gameplay.Interact.performed -= CheckCollisions;
        }

        private void Update()
        {
            Move();
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

        private void CheckCollisions(InputAction.CallbackContext context) {
            float interactRange = 2f;
            Collider[] colliders = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent(out Interactions interactions))
                {
                    for (int i = 0; i < interactions.Interactables.Length; i++)
                    {
                        interactionMenu.AddButton(interactions.Interactables[i]);
                    }
                    openInteractMenuEventHandler.Raise();
                }
            }
        }
    }
}
