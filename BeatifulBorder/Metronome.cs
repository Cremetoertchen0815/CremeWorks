using System;

namespace CremeWorks.Common
{
    public class Metronome
    {
        private WinMMWrapper _timer = null;
        private const int ACCURACY = 2;

        private int _currentTick;
        private int _futureTick;

        public event Action Tick;

        public void Start(int tempoBPM)
        {
            _futureTick = 60000 / tempoBPM;
            if (_timer is null)
            {
                _currentTick = _futureTick;
                _timer = new WinMMWrapper(_currentTick, ACCURACY, WinMMWrapper.TimerEventType.Repeating, TickTimer);
                _timer.StartElapsedTimer();
            }
        }

        public void Stop()
        {
            _timer?.Stop();
            _timer = null;
        }

        private void TickTimer()
        {
            if (_currentTick != _futureTick)
            {
                _currentTick = _futureTick;
                _timer?.Stop();
                _timer = new WinMMWrapper(_currentTick, ACCURACY, WinMMWrapper.TimerEventType.Repeating, TickTimer);
                _timer.StartElapsedTimer();
            }

            Tick?.Invoke();
        }
    }

}