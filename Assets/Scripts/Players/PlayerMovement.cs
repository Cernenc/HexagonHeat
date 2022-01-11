using Assets.Scripts.Environment.Physics;
using Assets.Scripts.Managers;
using Assets.Scripts.Players.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Players
{
    public class PlayerMovement : MonoBehaviour, IPlayer
    {
        private Vector3 _currentMovement;
        private Vector3 _velocity;
        private float _gravity = -9.8f;
        private float _groundedGravity = -0.5f;

        [field: SerializeField]
        public PlayerAttributeManager AttributeManager { get; set; }

        public CharacterController Controller { get; set; }

        private void Awake()
        {
            PlayerManager manager = FindObjectOfType<PlayerManager>();
            manager.Player = this;

            float timeToApex = AttributeManager.MaxJumpHeight / 2;
            _gravity = (-2 * AttributeManager.MaxJumpHeight) / Mathf.Pow(timeToApex, 2);
        }

        private void Start()
        {
            Controller = GetComponent<CharacterController>();
        }

        public void Update()
        {
            HandlePlayerGravity();
        }

        public void Movement(float horizontal, float vertical)
        {
            Vector3 movement = new Vector3(horizontal, 0, vertical) * AttributeManager.Speed * Time.deltaTime;

            Controller.Move(movement);
        }

        public void Jump()
        {
            _velocity.y += Mathf.Sqrt(AttributeManager.MaxJumpHeight * -3.0f * Gravity.GravityValue);
            Controller.Move(_velocity * Time.deltaTime);
        }

        private void HandlePlayerGravity()
        {
            if (Controller.isGrounded)
            {
                _currentMovement.y = _groundedGravity;
            }
            else
            {
                _currentMovement.y = _gravity;
            }

            Controller.Move(_currentMovement * Time.deltaTime);
        }
    }
}
