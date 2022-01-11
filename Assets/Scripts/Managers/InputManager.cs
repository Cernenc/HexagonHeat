using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class InputManager : GameBehaviour
    {
        private void Awake()
        {

        }

        private void Update()
        {
            MovementInput();
            JumpInput();
        }

        public void MovementInput()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            
            playerManager.OnMoveInput.Invoke(horizontal, vertical);
        }

        public void JumpInput()
        {
            if (Input.GetButtonDown("Jump") && playerManager.Player.Controller.isGrounded)
            {
                playerManager.OnJumpInput.Invoke();
            }
        }
    }
}
