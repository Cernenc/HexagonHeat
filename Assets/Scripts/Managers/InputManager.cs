using Assets.Scripts.RulesSet;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class InputManager : GameBehaviour
    {
        private int _constHorizontal = 1;
        private int _constVertical = 1;

        private void Update()
        {
            MovementInput();
            JumpInput();
        }

        public void MovementInput()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            if (RulesRestrict.HasConstantMove)
            {
                if(horizontal < 0 && vertical == 0) { _constHorizontal = -1; _constVertical = 0; }
                if(horizontal > 0 && vertical == 0) { _constHorizontal = 1; _constVertical = 0; }
                if(vertical < 0 && horizontal == 0) { _constVertical = -1; _constHorizontal = 0; }
                if(vertical > 0 && horizontal == 0) { _constVertical = 1; _constHorizontal = 0; }
                if(vertical > 0 && horizontal > 0) { _constVertical = 1; _constHorizontal = 1; }
                if(vertical > 0 && horizontal < 0) { _constVertical = 1; _constHorizontal = -1; }
                if(vertical < 0 && horizontal < 0) { _constVertical = -1; _constHorizontal = -1; }
                if(vertical < 0 && horizontal > 0) { _constVertical = -1; _constHorizontal = 1; }

                playerManager.OnMoveInput.Invoke(_constHorizontal, _constVertical);
                return;
            }

            playerManager.OnMoveInput.Invoke(horizontal, vertical);
        }

        public void JumpInput()
        {
            if (Input.GetButtonDown("Jump") && playerManager.Player.Controller.isGrounded && RulesRestrict.CanJump)
            {
                playerManager.OnJumpInput.Invoke();
            }
        }
    }
}
