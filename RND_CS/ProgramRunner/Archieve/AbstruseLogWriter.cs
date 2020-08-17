using System; using TinyRunner;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProgramRunner
{
    [Skip]
    public class AbstruseLogWriter : Runner
    {
        public string Path
        {
            get
            {
                return Environment.CurrentDirectory + "\\hub.log"; 
            }
        }
        private System.Timers.Timer Writer = null;

        public override void Run(string[] args)
        {
            Encoding encoding = Encoding.Unicode;
            //Writer = new System.Timers.Timer(2000);
            Random rand = new Random(0);
            var path = Environment.CurrentDirectory + "\\hub.log";
            if (!File.Exists(path))
                using (File.Create(path)) { };

            int limit = 100000;
            //List<byte[]> content = new List<byte[]>();
            

            using (var stream = new FileStream(path, FileMode.Append))
            {
                for (int i = 0; i < limit; i++)
                {
                    byte[] bytes = encoding.GetBytes($"Dummy log #{i} - {DateTime.Now}|");
                    stream.Write(bytes, 0, bytes.Length);               
                }
            }

            //Writer.Start();
            Console.ReadLine();
        }
    }
}
