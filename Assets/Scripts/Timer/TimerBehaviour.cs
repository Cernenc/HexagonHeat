﻿using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.Timer
{
    public class TimerBehaviour : MonoBehaviour
    {
        [field: SerializeField]
        public float Duration = 2f;
        private Text _countdownLabel = null;
        [field: SerializeField]
        public Text CountdownInformation { get; set; }
        public UnityEvent OnTimerEnd { get; set; } = null;
        private bool TimerIsStarting { get; set; }
        private Timer _timer = null;

        private void Start()
        {
            TimerSetup();
            TimerIsStarting = false;
            _countdownLabel = Instantiate<Text>(CountdownInformation);
            //_countdownLabel.gameObject.SetActive(false);
            _countdownLabel.rectTransform.SetParent(GetComponentInChildren<Canvas>().gameObject.transform, false);
            StartTimer();
        }

        public void TimerSetup(UnityAction action = null)
        {
            _timer = new Timer();
            _timer.RemainingSeconds = Duration;
            _timer.OnTimerEnd += HandleTimerEnd;
            OnTimerEnd = new UnityEvent();
            OnTimerEnd.RemoveAllListeners();
            OnTimerEnd.AddListener(action);
        }

        public void RemoveListeners()
        {
            OnTimerEnd.RemoveAllListeners();
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
            _countdownLabel.text = _timer.RemainingSeconds.ToString("0.00");
        }
    }
}
