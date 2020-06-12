using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ProgramRunner
{
    [RunThis]
    public class SimpleLogTextWriter : Runnable
    {

        private System.Timers.Timer Writer = null;
        public override void Run(string[] args)
        {
            Writer = new System.Timers.Timer(2000);
            Random rand = new Random(0);
            Writer.Elapsed += (s, e) =>
            {
                var path = Environment.CurrentDirectory + "\\hub.log";
                if (!File.Exists(path))
                    using (File.Create(path)) { };

                int limit = rand.Next(10);
                List<string> content = new List<string>();
                content.Add($"Writing {limit} logs");
                for (int i = 0; i < limit; i++)
                {
                    content.Add($"Dummy log #{i} - {DateTime.Now}");
                }

                File.AppendAllLines(path, content);
            };

            Writer.Start();
            Console.ReadLine();
        }
    }
}
