using UnityEngine;

namespace Assets.Scripts.Players
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 20;
        private Vector3 _velocity;
        [SerializeField]
        private float _gravity = -9.81f;

        [field: SerializeField]
        private Transform GroundCheck { get; set; }
        public float GroundDistance { get; } = 0.4f;
        

        public CharacterController Controller { get; set; }

        private void Start()
        {
            Controller = GetComponent<CharacterController>();
        }

        public void Update()
        {
            //_isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance);
            Movement();
            PlayerGravity();
        }

        private void Movement()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(horizontal, 0, vertical) * _speed * Time.deltaTime;

            Controller.Move(movement);
        }

        private void PlayerGravity()
        {
            //gravity -> velocity = 1/2 * gravity * time^2
            _velocity.y += _gravity * Time.deltaTime;
            Controller.Move(_velocity * Time.deltaTime);
        }
    }
}
