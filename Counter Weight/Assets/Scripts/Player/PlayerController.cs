using UnityEngine;

namespace CounterWeight.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed;

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
            transform.position += new Vector3(moveInput.x, 0f, moveInput.y) * speed * Time.deltaTime;
        }
    }
}
