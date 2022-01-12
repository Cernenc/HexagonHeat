using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.Timer
{
    public class TimerBehaviour : MonoBehaviour
    {
        [field: SerializeField]
        public float Duration = 2f;

        [field: SerializeField]
        public Text CountdownInformation { get; set; }

        public UnityEvent OnTimerEnd { get; set; } = null;

        private bool TimerIsStarting { get; set; }

        private Timer _timer = null;

        private void Start()
        {
            TimerSetup();
            TimerIsStarting = false;
        }

        public void TimerSetup(UnityAction action = null)
        {
            _timer = new Timer();
            _timer.RemainingSeconds = Duration;
            _timer.OnTimerEnd += HandleTimerEnd;
            OnTimerEnd = new UnityEvent();
            OnTimerEnd.RemoveAllListeners();
            OnTimerEnd.AddListener(action);
            StartTimer();
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
                ShowTimer();
            }
        }

        private void ShowTimer()
        {
            CountdownInformation.text = _timer.RemainingSeconds.ToString("0.00");
        }
    }
}
