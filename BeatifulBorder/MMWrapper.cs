using System;
using System.Runtime.InteropServices;

namespace CremeWorks.Common
{
    internal class WinMMWrapper
    {

        [DllImport("winMM.dll", SetLastError = true, EntryPoint = "timeKillEvent")]
        internal static extern void timeKillEvent(uint uTimerId);

        [DllImport("WinMM.dll", SetLastError = true, EntryPoint = "timeSetEvent")]
        internal static extern uint timeSetEvent(int msDelay, int msResolution,
            TimerEventHandler handler, ref int userCtx, int eventType);

        public delegate void TimerEventHandler(uint id, uint msg, ref int userCtx,
            int rsv1, int rsv2);

        public enum TimerEventType
        {
            OneTime = 0,
            Repeating = 1
        }

        private readonly Action _elapsedAction;
        private readonly int _elapsedMs;
        private readonly int _resolutionMs;
        private readonly TimerEventType _timerEventType;
        private readonly TimerEventHandler _timerEventHandler;
        private uint _handle = 0;

        public WinMMWrapper(int elapsedMs, int resolutionMs, TimerEventType timerEventType, Action elapsedAction)
        {
            _elapsedMs = elapsedMs;
            _resolutionMs = resolutionMs;
            _timerEventType = timerEventType;
            _elapsedAction = elapsedAction;
            _timerEventHandler = TickHandler;
        }

        public uint StartElapsedTimer()
        {
            var myData = 1; //dummy data
            return _handle = timeSetEvent(_elapsedMs, _resolutionMs, _timerEventHandler, ref myData, (int)_timerEventType);
        }

        private void TickHandler(uint id, uint msg, ref int userctx, int rsv1, int rsv2)
        {
            _elapsedAction();
        }

        public void Stop()
        {
            if (_handle > 0) timeKillEvent(_handle);
        }
    }
}