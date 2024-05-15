using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using CounterWeight.InteractionSystem;

namespace CounterWeight.Characters
{
    public class Character : MonoBehaviour
    {
        [Header("Player Controls")]
        [SerializeField] private float moveSpeed;

        [Header("Interactions")]
        public List<Skill> skills = new List<Skill>();
        [SerializeField] Dictionary<Skill, int> testlist = new Dictionary<Skill, int>();
        [SerializeField] private float interactRange;
        [SerializeField] private bool showInteractRange;

        private PlayerControls playerControls;

        private void Awake()
        {
            playerControls = new PlayerControls();
        }

        private void OnEnable()
        {
            playerControls.Enable();

            playerControls.Gameplay.Interact.performed += test;
        }

        private void OnDisable()
        {
            playerControls.Disable();

            playerControls.Gameplay.Interact.performed -= test;
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

        public int GetSkillLevel(Skill querySkill)
        {
            // Retrieve skill level for the specified skill
            // You might implement this based on your game's logic
            foreach (Skill skill in skills)
            {
                // SkillName is actually the SO, so comparing is accurate, but using the instance in case another SO is made and compared by mistake
                if (skill.SkillName.GetInstanceID() == querySkill.SkillName.GetInstanceID())
                {
                    return skill.SkillLevel;
                }
            }
            return -1;
        }

        public Skill GetSkill(Skill querySkill)
        {
            // Retrieve skill level for the specified skill
            // You might implement this based on your game's logic
            foreach (Skill skill in skills)
            {
                if (skill.SkillName == querySkill.SkillName)
                {
                    return skill;
                }
            }
            return null;
        }

        // private void CheckForInteractables()
        // {
        //     Collider[] colliders = Physics.OverlapSphere(transform.position, interactRange);
        //     foreach (Collider collider in colliders)
        //     {
        //         if (collider.TryGetComponent(out Interactable interactable))
        //         {
        //             interactable.UpdateInteractionsList();
        //             showInteractPromptEventHandler.Raise();
        //             return;
        //         }
        //     }            
        //     hideInteractPromptEventHandler.Raise();
        //     hideInteractMenuEventHandler.Raise();
        // }

        // public void OnInteractable() {
        //     Collider[] colliders = Physics.OverlapSphere(transform.position, interactRange);
        //     foreach (Collider collider in colliders)
        //     {
        //         if (collider.TryGetComponent(out Interactable interactable))
        //         {
        //             if (interactionName.Value == "Inspect")
        //             {
        //                 Debug.Log(interactable.Inspect());
        //             } else
        //             {
        //                 Debug.Log(interactable.SkillCheck(skills.GetSkillByName(interactionName.Value)));
        //             }
        //         }
        //     }
        // }

        // private void Interact(InputAction.CallbackContext context) {
        //     Collider[] colliders = Physics.OverlapSphere(transform.position, interactRange);
        //     foreach (Collider collider in colliders)
        //     {
        //         if (collider.TryGetComponent(out Interactable interactable))
        //         {
        //             showInteractMenuEventHandler.Raise();
        //         }
        //     }
        // }

        private void OnDrawGizmos() {
            Gizmos.color = Color.red;
            if (showInteractRange)
            {
                Gizmos.DrawWireSphere(transform.position, interactRange);
            }
        }

        private void test(InputAction.CallbackContext context)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent(out IInteractable interactable))
                {
                    interactable.Interact(this);
                    return;
                }
            }            
        }
    }
}
