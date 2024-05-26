using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using CounterWeight.InteractionSystem;
using RoboRyanTron.Unite2017.Events;
using RoboRyanTron.Unite2017.Variables;
using CounterWeight.Variables;

namespace CounterWeight.Characters
{
    public class Character : MonoBehaviour
    {
        [Header("Player Controls")]
        [SerializeField] private float moveSpeed;
        [SerializeField] private float collisionDistance;
        [SerializeField] private BoolVariable canMove;

        [Header("Interactions")]
        public List<Skill> skills = new List<Skill>();
        [SerializeField] Dictionary<Skill, int> testlist = new Dictionary<Skill, int>();
        [SerializeField] private float interactRange;
        [SerializeField] private bool showInteractRange;
        [SerializeField] private CurrentInteractable currentInteractable;
        [SerializeField] private FloatVariable skillTime;

        [Header("Interact Menu Events")]
        [SerializeField] private GameEvent hideInteractPrompt;
        [SerializeField] private GameEvent showInteractPrompt;
        [SerializeField] private GameEvent hideInteractMenu;
        [SerializeField] private GameEvent showInteractMenu;

        private Vector2 moveInput;
        private Vector3 moveDirection;
        private int WALK_HASH;

        private PlayerControls playerControls;
        private Animator animator;

        private void Awake()
        {
            playerControls = new PlayerControls();
            animator = GetComponent<Animator>();
        }

        private void Start()
        {
            WALK_HASH = Animator.StringToHash("isWalking");
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
            GetMoveInput();
            CalculateMoveDirection();
        }

        private void FixedUpdate()
        {
            if (!canMove.Value) return;
            Move();
        }

        private void Move()
        {
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
        }

        private void GetMoveInput()
        {
            moveInput = playerControls.Gameplay.Move.ReadValue<Vector2>();
            animator.SetBool(WALK_HASH, moveInput != Vector2.zero);
        }

        private void CalculateMoveDirection()
        {
            // Calculate movement direction relative to camera
            Vector3 cameraForward = Camera.main.transform.forward.normalized;
            Vector3 cameraRight = Camera.main.transform.right.normalized;
            cameraForward.y = 0f;
            cameraRight.y = 0f;
            moveDirection = cameraForward * moveInput.y + cameraRight * moveInput.x;
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

        public float GetSkillTime()
        {
            return skillTime.Value;
        }

        private void Interact(InputAction.CallbackContext context) {
            if (currentInteractable.interactable != null)
            {
                showInteractMenu.Raise();
            }
        }
    }
}
