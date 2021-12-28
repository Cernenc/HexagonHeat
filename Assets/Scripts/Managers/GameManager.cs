using Assets.Scripts.RulesSet;
using Assets.Scripts.Tasks;
using Assets.Scripts.Timer;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        [field: SerializeField]
        private RuleSetBehaviour RuleSet { get; set; }

        [field: SerializeField]
        private TaskSystemBehaviour TaskSystem { get; set; }

        [field: SerializeField]
        private HexagonDrop Drop { get; set; }
        public TimerBehaviour Timer { get; private set; }

        public void Start()
        {
            Timer = FindObjectOfType<TimerBehaviour>();
            RuleSet.gameManager = this;
            TaskSystem.gameManager = this;

            RuleSet.ShuffleAndRun();
        }

        public void ResetRound()
        {

        }
    }
}
