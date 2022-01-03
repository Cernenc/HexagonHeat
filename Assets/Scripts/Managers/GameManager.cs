using Assets.Scripts.Hexagons;
using Assets.Scripts.RulesSet;
using Assets.Scripts.Tasks;
using Assets.Scripts.Timer;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        [field: SerializeField]
        private RuleSetBehaviour RuleSet { get; set; }

        [field: SerializeField]
        private TaskSystemBehaviour TaskSystem { get; set; }

        [field: SerializeField]
        public HexGrid Grid { get; set; }
        public HexagonDrop Drop { get; set; }
        public TimerBehaviour Timer { get; private set; }

        private void Awake()
        {
            Reset();
        }

        private void HandleTaskEnd()
        {
            Timer.Duration = 2f;
            Timer.TimerSetup();
            Timer.OnTimerEnd = new UnityEvent();
            Timer.OnTimerEnd.RemoveAllListeners();
            Timer.OnTimerEnd.AddListener(NextRound);
            Timer.StartTimer();
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
            Timer.TimerSetup();
            Timer.OnTimerEnd = new UnityEvent();
            Timer.OnTimerEnd.RemoveAllListeners();
            Timer.OnTimerEnd.AddListener(TaskSystem.ChooseTask);
            Timer.StartTimer();
        }

        public void Start()
        {
            Timer = FindObjectOfType<TimerBehaviour>();
            RuleSet.gameManager = this;
            TaskSystem.gameManager = this;
            RuleSet.ShuffleAndRun();
        }
    }
}
