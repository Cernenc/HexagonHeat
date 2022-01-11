using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class GameBehaviour : MonoBehaviour
    {
        protected CachedComponent<GameManager> _gameManager = new CachedComponent<GameManager>();
        protected GameManager gameManager
        {
            get
            {
                return _gameManager.Instance(this);
            }
        }

        private CachedComponent<PlayerManager> _playerManager = new CachedComponent<PlayerManager>();
        public PlayerManager playerManager
        {
            get
            {
                return _playerManager.Instance(this);
            }
        }

        private CachedComponent<InputManager> _inputManager = new CachedComponent<InputManager>();
        public InputManager inputManager
        {
            get
            {
                return _inputManager.Instance(this);
            }
        }
    }
}