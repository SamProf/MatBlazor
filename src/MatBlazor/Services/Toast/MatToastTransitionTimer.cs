using System;
using System.Threading;

namespace MatBlazor
{
    public class MatToastTransitionTimer : IDisposable
    {
        private Action Callback { get; set; }
        private DateTime DueTime { get; set; }
        public int Duration { get; set; }
        private Timer Timer { get; set; }

        public double RemainingMilliseconds
        {
            get
            {
                var milliseconds = (DueTime - DateTime.Now).TotalMilliseconds;
                return milliseconds > 0 ? milliseconds : 0;
            }
        }

        public MatToastTransitionTimer(Action callback)
        {
            Callback = callback;
            Timer = new Timer(TransitionCallback, null, Timeout.Infinite, Timeout.Infinite);
        }

        public void Start(int duration)
        {
            Duration = duration <= 0 ? 0 : duration;
            DueTime = DateTime.Now.AddMilliseconds(Duration);

            if (duration == 0)
            {
                Callback?.Invoke();
            }
            else
            {
                Timer?.Change(Duration, Timeout.Infinite);
            }
        }

        public void Stop()
        {
            Duration = 0;
            Timer?.Change(Timeout.Infinite, Timeout.Infinite);
        }

        private void TransitionCallback(object state)
        {
            Callback?.Invoke();
        }

        public void Dispose()
        {
            Stop();
            Timer.Dispose();
            Timer = null;
            Callback = null;
        }
    }
}