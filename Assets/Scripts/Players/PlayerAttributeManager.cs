using UnityEngine;

namespace Assets.Scripts.Players
{
    [CreateAssetMenu(fileName = "Player attributes", menuName = "ScriptableObjects/PlayerAttributeManager", order = 1)]
    public class PlayerAttributeManager : ScriptableObject
    {
        [field: SerializeField]
        public float GroundSpeed { get; set; }

        [field: SerializeField]
        public float AirSpeed { get; set; }

        [field: SerializeField]
        public float MaxJumpHeight { get; set; }

        [field: SerializeField]
        public float MaxJumpTime { get; set; }
    }
}
