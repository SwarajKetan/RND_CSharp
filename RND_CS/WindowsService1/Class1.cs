using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    public class Class1 : System.ServiceProcess.ServiceBase
    {
        protected override void OnStart(string[] args)
        {
            Console.WriteLine("hello started");
            //base.OnStart(args);
        }

        protected override void OnStop()
        {
            //
            Console.WriteLine("stopped");
        }
    }
}
