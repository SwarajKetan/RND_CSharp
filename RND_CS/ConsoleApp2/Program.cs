using System;
using System.Collections.Concurrent;
using System.Timers;


namespace ConsoleApp2
{
    public class NonWastingCall
    {
        readonly BlockingCollection<Guid> ToBeDisposedTimers = new BlockingCollection<Guid>();
        readonly ConcurrentDictionary<Guid, Timer> TimedEvents = new ConcurrentDictionary<Guid, Timer>();

        public NonWastingCall ScheduledTimedOperation(double sleepTime, Action action)
        {
            var timer = new Timer(sleepTime) { Enabled = true };
            Guid guid = Guid.NewGuid();
            timer.Elapsed += (s, e) =>
            {
                action();
                ToBeDisposedTimers.Add(guid);
            };

            timer.Start();
            TimedEvents.TryAdd(guid, timer);
            return this;
        }

        private System.Threading.Tasks.Task _t;
        private static Lazy<NonWastingCall> _instance = new Lazy<NonWastingCall>(() => new NonWastingCall(), true); 
        private NonWastingCall()
        {
           _t =  System.Threading.Tasks.Task.Run(() => ProcessTimers());
        }
        public static NonWastingCall Instance
        {
            get
            {
                return _instance.Value;
            }
        }
        private void ProcessTimers()
        {
            while (ToBeDisposedTimers.TryTake(out Guid guid, System.Threading.Timeout.Infinite))
            {
                if (TimedEvents.TryRemove(guid, out Timer timer))
                {
                    timer.Stop();
                    timer.Dispose();
                    Console.WriteLine($"________________{guid} timer disposed {System.Threading.Thread.CurrentThread.ManagedThreadId}");
                }

                if (ToBeDisposedTimers.IsCompleted)
                {
                    ToBeDisposedTimers.Dispose();
                    break;
                }
            }
        }
    }


    class Program
    {
        static NonWastingCall nwc = NonWastingCall.Instance;
        static void Main(string[] args)
        {
            DoSomething();
            //
            Console.ReadLine();
        }

        public static void DoSomething()
        {
            Console.WriteLine($"{DateTime.Now} A {System.Threading.Thread.CurrentThread.ManagedThreadId}");
            DoSomething2();
        }
        public static void DoSomething2()
        {
            Console.WriteLine($"{DateTime.Now} B {System.Threading.Thread.CurrentThread.ManagedThreadId}");
            DoSomethingLong();
        }

        // Equivalent to thread sleep
        public static void DoSomethingLong()
        {
            Console.WriteLine($"{DateTime.Now} C {System.Threading.Thread.CurrentThread.ManagedThreadId}");
            // call DoSomethig3 10 seconds later
            nwc.ScheduledTimedOperation(10000, CallAfterSleep)
                .ScheduledTimedOperation(5000, DoSomething4)
                .ScheduledTimedOperation(5000, DoSomething5); 
            //System.Threading.Thread.Sleep(10000);
            //CallAfterSleep();
        }

        public static void CallAfterSleep()
        {
            Console.WriteLine($"{DateTime.Now} Wait over {System.Threading.Thread.CurrentThread.ManagedThreadId}");
        }

        public static void DoSomething3()
        {
            Console.WriteLine($"{DateTime.Now} D {System.Threading.Thread.CurrentThread.ManagedThreadId}");
            // sleep 10 seconds
        }

        public static void DoSomething4()
        {
            Console.WriteLine($"{DateTime.Now} 2nd sleep {System.Threading.Thread.CurrentThread.ManagedThreadId}");
            // sleep 10 seconds
        }

        public static void DoSomething5()
        {
            Console.WriteLine($"{DateTime.Now} 3rd sleep {System.Threading.Thread.CurrentThread.ManagedThreadId}");
            // sleep 10 seconds
        }
    }
}
