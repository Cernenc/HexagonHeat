using Assets.Scripts.Hexagons;
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
        private UnityEvent OnChooseTask { get; set; }

        private void Start()
        {
            TaskSystem = new TaskSystem();
            TaskSystem.Grid = _grid;
            TaskSystem.OnChooseTask += HandleChosenTask;

            _drop = new HexagonDrop();
        }

        public void ChooseTask()
        {
            TaskSystem.ChooseTask();
        }

        private void HandleChosenTask()
        {
            Timer.TimerBehaviour timer = FindObjectOfType<Timer.TimerBehaviour>();
            timer.Duration = 5f;
            timer.TimerSetup();
            timer.OnTimerEnd = new UnityEvent();
            timer.OnTimerEnd.RemoveAllListeners();
            timer.OnTimerEnd.AddListener(_drop.Drop);

            OnChooseTask.Invoke();
        }
    }
}
