using System;
using RoboRyanTron.Unite2017.Events;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CounterWeight.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private GameEvent inspect;
        [SerializeField] private GameEvent interact;

        private PlayerControls playerControls;

        private void Awake()
        {
            playerControls = new PlayerControls();
        }

        private void OnEnable()
        {
            playerControls.Enable();

            // temp
            playerControls.Gameplay.Interact.performed += CheckCollisions;
            playerControls.Gameplay.KeyT.performed += Interact;
            playerControls.Gameplay.KeyY.performed += Inspect;
        }

        private void OnDisable()
        {
            playerControls.Disable();

            // temp
            playerControls.Gameplay.Interact.performed -= CheckCollisions;
            playerControls.Gameplay.KeyT.performed -= Interact;
            playerControls.Gameplay.KeyY.performed -= Inspect;
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

        // temporary
        private void Inspect(InputAction.CallbackContext context)
        {
            inspect.Raise();
        }
        private void Interact(InputAction.CallbackContext context)
        {
            interact.Raise();
        }
        private void CheckCollisions(InputAction.CallbackContext context) {
            float interactRange = 2f;
            Collider[] colliders = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent(out GameEventListener listener))
                {
                    foreach (GameEventListener action in listener.GetComponents<GameEventListener>()) {
                        Debug.Log(action.Event.name);
                    }
                }
            }
        }
    }
}
