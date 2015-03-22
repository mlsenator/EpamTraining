using System;
using System.Threading;

namespace CountDown
{
    public class Counter
    {
        private Timer timer;

        public event EventHandler<CounterEventArgs> TimeOut;

        public void Start(long milliseconds, string message)
        {
            CounterEventArgs e = new CounterEventArgs(message);
            timer = new Timer(OnTimeOut, e, milliseconds, Timeout.Infinite);
        }

        protected virtual void OnTimeOut(object obj)
        {
            ((CounterEventArgs)obj).Raise<CounterEventArgs>(TimeOut, this);
        }
    }

    public class CounterEventArgs : EventArgs
    {
        public string Message { get; private set;}
        public CounterEventArgs(string message)
        {
            Message = message;
        }
        
    }
}
