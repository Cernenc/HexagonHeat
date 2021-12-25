using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Timer
{
    public class TimerBehaviour : MonoBehaviour
    {
        [field: SerializeField]
        public float Duration = 2f;

        public UnityEvent OnTimerEnd { get; set; } = null;

        private bool TimerIsStarting { get; set; }

        private Timer _timer = null;

        private void Start()
        {
            TimerSetup();
            TimerIsStarting = false;
        }

        public void TimerSetup()
        {
            _timer = new Timer();
            _timer.RemainingSeconds = Duration;
            _timer.OnTimerEnd += HandleTimerEnd;
        }

        private void HandleTimerEnd()
        {
            TimerIsStarting = false;
            OnTimerEnd.Invoke();
        }

        public void StartTimer()
        {
            TimerIsStarting = true;
        }

        private void Update()
        {
            if (TimerIsStarting)
            {
                _timer.Tick(Time.deltaTime);
            }
        }
    }
}
