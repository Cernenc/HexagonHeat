using UnityEngine;

namespace Assets.Scripts.Players.Interfaces
{
    public interface IPlayer
    {
        CharacterController Controller { get; set; }
        void Jump();
        void Movement(float horizontal, float vertical);
    }
}
