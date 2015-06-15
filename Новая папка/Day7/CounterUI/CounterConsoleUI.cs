using System;
using System.Threading;
using CountDown;

namespace CounterUI
{
    class CounterConsoleUI
    {
        static void Main(string[] args)
        {
            Counter counter = new Counter();
            ListenHelper helper = new ListenHelper(new SomeListener(counter), new AnotherListener(counter));
            helper.ListenAll();
            counter.Start(1000, "bla");
            Thread.Sleep(1100);
            counter.Start(1000, "kokoko");
            Thread.Sleep(1100);
            helper.StopListenAll();
            Console.ReadLine();

        }
    }
}
