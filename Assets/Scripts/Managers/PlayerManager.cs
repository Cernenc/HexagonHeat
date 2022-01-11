using Assets.Scripts.Players.Interfaces;
using UnityEngine.Events;

namespace Assets.Scripts.Managers
{
    public class MoveEvent : UnityEvent<float, float> { }
    public class PlayerManager : GameBehaviour
    {
        public IPlayer Player { get; set; }

        //public UnityEvent<float, float> OnMoveInput { get; set; }
        public MoveEvent OnMoveInput { get; set; }
        public UnityEvent OnJumpInput { get; set; }

        private void Start()
        {
            OnMoveInput = new MoveEvent();
            OnMoveInput.AddListener(Player.Movement);

            OnJumpInput = new UnityEvent();
            OnJumpInput.AddListener(Player.Jump);
        }
    }
}
