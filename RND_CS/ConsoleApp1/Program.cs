using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Pipes;

    class Program
    {
        public interface ILogHandler : IDisposable
        {
            void Log(string message);
        }

        public class RemoteLogHandler : ILogHandler
        {
            readonly NamedPipeServerStream pipeServer = new NamedPipeServerStream("abcpipe", PipeDirection.Out);
            readonly StreamWriter sw = null;

            public RemoteLogHandler()
            {
                pipeServer.WaitForConnection();
                sw = new StreamWriter(pipeServer) { AutoFlush = true };
            }
            public void Log(string message)
            {
                _ = sw.WriteLineAsync(message);
            }
            public void Dispose()
            {
                sw.Dispose();
                pipeServer.Dispose();
            }
        }


        static List<ILogHandler> providers = new List<ILogHandler>();

        static void Main(string[] args)
        {

            providers.Add(new RemoteLogHandler());

            Task.Run(() =>
            {
                while (true)
                {
                    providers.ForEach(p => p.Log(DateTime.Now.ToString()));
                    Thread.Sleep(1000);
                }
            });


            Console.ReadLine();
            Console.WriteLine("Server exit");
            providers.ForEach(p=> p.Dispose());
            Console.ReadLine();
        }

    }
}
