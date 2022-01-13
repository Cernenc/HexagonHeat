using Assets.Scripts.Managers;
using Assets.Scripts.Players.Interfaces;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerLoss : MonoBehaviour
    {
        private GameManager _gameManager = null;
        private void Start()
        {
            _gameManager = FindObjectOfType<GameManager>();
        }
        private void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponent<IPlayer>();
            Debug.Log(player);
            _gameManager.playerManager.OnPlayerHasFallen.Invoke(player);
        }
    }
}
