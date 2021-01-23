using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                Class1 c = new Class1();
                Stopwatch sw = new Stopwatch();
                sw.Start();
                bool res = await c.CallAsync<bool>(DoSomething, 3000);
                sw.Stop();
                Console.WriteLine($"elapsed {sw.ElapsedMilliseconds}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static bool DoSomething()
        {
            Thread.Sleep(5000);
            return true;
        }
    }
}
