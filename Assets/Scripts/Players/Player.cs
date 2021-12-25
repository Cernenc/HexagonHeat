using UnityEngine;

namespace Assets.Scripts.Players
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 0;

        public void Update()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(horizontal, 0, vertical);
            transform.Translate(_speed * Time.deltaTime * movement);
        }
    }
}
