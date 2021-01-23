using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thread_sleep_task_delay
{
    class Program
    {
        static void Main(string[] args)
        {
           if(!System.Threading.ThreadPool.SetMaxThreads(4, 2))
            {
                Console.WriteLine("unable to set max threads.");
                return;
            }
            try
            {
                DoSomething();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Task.WaitAll(tasks.ToArray());
            Console.ReadLine();
        }
        static Random rd = new Random();
        static List<Task> tasks = new List<Task>();
        static void DoSomething()
        {
            int i = 100000;
            while (--i > 0)
            {
                tasks.Add(Task.Run(() =>
                {
                    System.Threading.Thread.Sleep(rd.Next(30, 90));
                    Console.Write(System.Threading.Thread.CurrentThread.ManagedThreadId);
                }));
            }
        }
    }
}
