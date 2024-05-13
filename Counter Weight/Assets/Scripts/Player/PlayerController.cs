using CounterWeight.Characters;
using CounterWeight.InteractionSystem;
using RoboRyanTron.Unite2017.Events;
using RoboRyanTron.Unite2017.Variables;
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
        [SerializeField] private StringVariable interactionName;

        private Skills skills;

        private PlayerControls playerControls;

        private void Awake()
        {
            skills = GetComponent<Skills>();

            playerControls = new PlayerControls();
        }

        private void OnEnable()
        {
            playerControls.Enable();

            playerControls.Gameplay.Interact.performed += Interact;
        }

        private void OnDisable()
        {
            playerControls.Disable();

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

        public void OnInteractable() {
            Collider[] colliders = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent(out Interactable interactable))
                {
                    if (interactionName.Value == "Inspect")
                    {
                        Debug.Log(interactable.Inspect());
                    } else
                    {
                        Debug.Log(interactable.SkillCheck(skills.GetSkillByName(interactionName.Value)));
                    }
                }
            }
        }

        private void Interact(InputAction.CallbackContext context) {
            Collider[] colliders = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent(out Interactable interactable))
                {
                    showInteractMenuEventHandler.Raise();
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
