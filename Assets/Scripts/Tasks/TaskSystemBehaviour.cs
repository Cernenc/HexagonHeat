using Assets.Scripts.Hexagons;
using Assets.Scripts.Managers;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Tasks
{
    public class TaskSystemBehaviour : MonoBehaviour
    {
        private HexagonDrop _drop = null;

        [SerializeField]
        private HexGrid _grid = null;
        private TaskSystem TaskSystem { get; set; }

        [field: SerializeField]
        private UnityEvent OnTaskChosen { get; set; }

        public GameManager gameManager { private get; set; }

        private void Start()
        {
            TaskSystem = new TaskSystem();
            TaskSystem.Grid = _grid;
            TaskSystem.OnTaskChosen += HandleChosenTask;
        }

        public void ChooseTask()
        {
            TaskSystem.ChooseTask();
        }

        private void HandleChosenTask()
        {
            _drop = new HexagonDrop();
            _drop.Drops = TaskSystem.CellsToDrop;
            Timer.TimerBehaviour timer = gameManager.Timer;
            timer.Duration = 5f;
            timer.TimerSetup();
            timer.OnTimerEnd = new UnityEvent();
            timer.OnTimerEnd.RemoveAllListeners();
            timer.OnTimerEnd.AddListener(_drop.Drop);

            OnTaskChosen.Invoke();
        }
    }
}
