using Assets.Scripts.Environment.Physics;
using Assets.Scripts.Managers;
using Assets.Scripts.Players.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Players
{
    public class PlayerMovement : MonoBehaviour, IPlayer
    {
        private Vector3 _currentMovement;
        private float _gravity = -9.8f;
        private float _groundedGravity = -0.5f;
        private float _initialJumpVelocity;

        [field: SerializeField]
        public PlayerAttributeManager AttributeManager { get; set; }

        public CharacterController Controller { get; set; }

        private void Awake()
        {
            PlayerManager manager = FindObjectOfType<PlayerManager>();
            manager.Player = this;

            float timeToApex = AttributeManager.MaxJumpTime / 2;
            _gravity = (-2 * AttributeManager.MaxJumpHeight) / Mathf.Pow(timeToApex, 2);
            _initialJumpVelocity = (2 * AttributeManager.MaxJumpHeight) / timeToApex;
        }

        private void Start()
        {
            Controller = GetComponent<CharacterController>();
        }

        public void Update()
        {
            Controller.Move(_currentMovement * Time.deltaTime);
            HandlePlayerGravity();
        }

        public void Movement(float horizontal, float vertical)
        {
            if (Controller.isGrounded)
            {
                _currentMovement.x = horizontal * AttributeManager.GroundSpeed;
                _currentMovement.z = vertical * AttributeManager.GroundSpeed;
            }
            else
            {
                _currentMovement.x = horizontal * AttributeManager.AirSpeed;
                _currentMovement.z = vertical * AttributeManager.AirSpeed;
            }
        }

        public void Jump()
        {
            _currentMovement.y = _initialJumpVelocity;
        }

        private void HandlePlayerGravity()
        {
            if (Controller.isGrounded)
            {
                _currentMovement.y = _groundedGravity;
            }
            else
            {
                _currentMovement.y += _gravity * Time.deltaTime;
            }
        }
    }
}
