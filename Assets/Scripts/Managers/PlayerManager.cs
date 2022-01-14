using Assets.Scripts.Players.Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Managers
{
    public class MoveEvent : UnityEvent<float, float> { }
    public class FallenPlayerEvent : UnityEvent<IPlayer> { }
    public class PlayerManager : GameBehaviour
    {
        public IPlayer Player { get; set; }
        public Vector3 PlayerPos { get; set; }

        public MoveEvent OnMoveInput { get; set; }
        public UnityEvent OnJumpInput { get; set; }
        public FallenPlayerEvent OnPlayerHasFallen { get; set; }

        private void Start()
        {
            OnMoveInput = new MoveEvent();
            OnMoveInput.AddListener(Player.Movement);

            OnJumpInput = new UnityEvent();
            OnJumpInput.AddListener(Player.Jump);

            OnPlayerHasFallen = new FallenPlayerEvent();
            OnPlayerHasFallen.AddListener(gameManager.HandleFallenPlayer);

            PlayerPos = Player.Controller.transform.position;
        }
    }
}
