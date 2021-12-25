using System;

namespace Assets.Scripts.Timer
{
    public class Timer
    {
        public Action OnTimerEnd { get; set; }
        public float RemainingSeconds { get; set; }

        public void Tick(float deltaTime)
        {
            if (RemainingSeconds <= 0)
            {
                return;
            }

            RemainingSeconds = RemainingSeconds - deltaTime;
            CheckTimerEnd();
        }

        private void CheckTimerEnd()
        {
            if (RemainingSeconds > 0)
            {
                return;
            }

            RemainingSeconds = 0f;
            OnTimerEnd?.Invoke();
        }
    }
}
