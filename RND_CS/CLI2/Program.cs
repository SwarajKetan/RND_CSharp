using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using CLI2.Arguments;

namespace CLI2
{
    class Program
    {
        // cli2 -m Run
        static void Main(string[] args)
        {
            string methodName = "print";

            Dictionary<string, string> _args = new Dictionary<string, string>();
            _args.Add("-n", "simpu");
            _args.Add("-a", "19");
            _args.Add("-h", "2");
                         

            var me = typeof(Engine).GetMethods().Where(m=> m.IsPublic).Where( x=>x.Name.ToLower() == methodName).FirstOrDefault();
            List<object> objects = new List<object>();
            foreach(var para in me.GetParameters())
            {
                var attr = para.ParameterType.GetCustomAttribute<DecoAttribute>();
                var val = Activator.CreateInstance(para.ParameterType, new object[] { _args[attr.Symbol] });
                objects.Add(val);
            }

            me.Invoke(new Engine(), objects.ToArray());
            Console.ReadLine();
        }

    }
}
