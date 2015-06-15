using System;

namespace CountDown
{
    public class SomeListener: IListener
    {
        private Counter counter;
        public SomeListener(Counter counter)
        {
            this.counter = counter;
        }
        public void Listen()
        {
            counter.TimeOut += TimeOut;
        }
        public void StopListen()
        {
            counter.TimeOut -= TimeOut;
        }
        void TimeOut(object sender, CounterEventArgs e)
        {
            Console.WriteLine("Some Listener is here >>> " + e.Message);
        }
    }
    public class AnotherListener : IListener
    {
        private Counter counter;
        public AnotherListener(Counter counter)
        {
            this.counter = counter;
        }
        public void Listen()
        {
            counter.TimeOut += TimeOut;
        }
        public void StopListen()
        {
            counter.TimeOut -= TimeOut;
        }
        void TimeOut(object sender, CounterEventArgs e)
        {
            Console.WriteLine("Another Listener is here >>> " + e.Message);
        }
    }


}
