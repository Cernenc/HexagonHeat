using Assets.Scripts.Hexagons;
using Assets.Scripts.Players.Interfaces;
using Assets.Scripts.RulesSet;
using Assets.Scripts.Tasks;
using Assets.Scripts.Timer;
using System.Collections.Generic;
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
        public HexagonGameBehaviour HexagonBehaviour { get; set; }
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
            StartMatch();
        }

        private void StartMatch()
        {
            foreach(var player in NumberOfLostPlayers)
            {
                player.Controller.transform.position = new Vector3(0, 3.3f, 0);
            }
            RuleSet.ShuffleAndRun();
        }

        private void Reset()
        {
            HexagonBehaviour = new HexagonGameBehaviour();
            HexagonBehaviour.FieldsToDrop = new System.Collections.Generic.HashSet<HexCell>();
            HexagonBehaviour.OnHexDrop += HandleTaskEnd;
        }
        
        private void HandleTaskEnd()
        {
            Timer.Duration = 2f;
            Timer.TimerSetup(NextRound);
        }

        public void HandleFallenPlayer(IPlayer player)
        {
            NumberOfLostPlayers.Add(player);
            CheckLastPlayer();
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

        private void CheckLastPlayer()
        {
            if(NumberOfLostPlayers.Count != 1)
            {
                NextRound();
                return;
            }

            EndMatch();
        }

        private void EndMatch()
        {
            StartMatch();
        }
    }
}
