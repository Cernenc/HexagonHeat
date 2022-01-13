using Assets.Scripts.Hexagons;
using Assets.Scripts.Players.Interfaces;
using Assets.Scripts.RulesSet;
using Assets.Scripts.Tasks;
using Assets.Scripts.Timer;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class GameManager : GameBehaviour
    {
        [field: SerializeField]
        private RuleSetBehaviour RuleSet { get; set; }

        [field: SerializeField]
        private TaskSystemBehaviour TaskSystem { get; set; }

        [field: SerializeField]
        public HexGrid Grid { get; set; }
        public HexagonDrop Drop { get; set; }
        public TimerBehaviour Timer { get; private set; }

        public IPlayer[] NumberOfActivePlayers { get; set; }

        private void Awake()
        {
            Reset();
        }
        public void Start()
        {
            NumberOfActivePlayers = new IPlayer[1];
            NumberOfActivePlayers[0] = playerManager.Player;
            Timer = FindObjectOfType<TimerBehaviour>();
            RuleSet.gameManager = this;
            TaskSystem.gameManager = this;
            RuleSet.ShuffleAndRun();
        }

        private void HandleTaskEnd()
        {
            CheckPlayerLoss();
            Timer.Duration = 2f;
            Timer.TimerSetup(NextRound);
        }

        private void CheckPlayerLoss()
        {

        }

        private void Reset()
        {
            Drop = new HexagonDrop();
            Drop.Drops = new System.Collections.Generic.HashSet<HexCell>();
            Drop.OnHexDrop += HandleTaskEnd;
        }

        private void NextRound()
        {
            Reset();
            foreach (var cell in Grid.Cells)
            {
                cell.gameObject.SetActive(true);
            }
            TaskSystem.Setup();
            Timer.Duration = 2f;
            Timer.TimerSetup(TaskSystem.ChooseTask);
        }        
    }
}
