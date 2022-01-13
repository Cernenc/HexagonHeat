using Assets.Scripts.Hexagons;
using Assets.Scripts.Players.Interfaces;
using Assets.Scripts.RulesSet;
using Assets.Scripts.Tasks;
using Assets.Scripts.Timer;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
        public List<IPlayer> NumberOfLostPlayers { get; set; }

        private void Awake()
        {
            Reset();
        }

        public void Start()
        {
            NumberOfLostPlayers = new List<IPlayer>();
            Timer = FindObjectOfType<TimerBehaviour>();
            RuleSet.gameManager = this;
            TaskSystem.gameManager = this;
            RuleSet.ShuffleAndRun();
        }

        private void HandleTaskEnd()
        {
            Timer.Duration = 2f;
            Timer.TimerSetup(NextRound);
        }

        public void HandleFallenPlayer(IPlayer player)
        {
            NumberOfLostPlayers.Add(player);
            Debug.Log(NumberOfLostPlayers.Count);
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
