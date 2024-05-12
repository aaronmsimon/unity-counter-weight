using UnityEngine;

namespace CounterWeight.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;

        private PlayerControls playerControls;

        private void Awake()
        {
            playerControls = new PlayerControls();
        }

        private void OnEnable()
        {
            playerControls.Enable();
        }

        private void OnDisable()
        {
            playerControls.Disable();
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            Vector2 moveInput = playerControls.Gameplay.Move.ReadValue<Vector2>();
            Vector3 moveDirection = new Vector3(moveInput.x, 0f, moveInput.y);
            Quaternion cameraRotation = Camera.main.transform.rotation;
            transform.position += cameraRotation * moveDirection * moveSpeed * Time.deltaTime;
        }
    }
}
