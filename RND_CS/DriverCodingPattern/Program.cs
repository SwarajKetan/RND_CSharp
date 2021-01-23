using System;

namespace DriverCodingPattern
{
    class Program
    {

        public class Chain
        {
            public Chain IfTrue(Func<bool> action, string logText)
            {
                if (action() && logText != string.Empty)
                    LogInfoInternal(logText);
                return this;
            }

            public Chain IfFalse(Func<bool> action, string logText)
            {
                if (!action() && logText != string.Empty)
                    LogInfoInternal(logText);
                return this;
            }
        }

        static void Main(string[] args)
        {

            Chain chain = new Chain();
            chain
                .IfTrue(() => IsGood(out int x, out string name), "log if not good")
                .IfFalse(() => IsBad(out int x, out string n), "bad");


            Console.ReadLine();
        }

        static void LogInfoInternal(string logText) => Console.WriteLine(logText);
        
        static bool IsGood(out int val, out string name)
        {
            val = 10;
            name = "Chinu";
            return true;
        }

        static bool IsBad(out int val, out string name)
        {
            val = 1;
            name = "Chinu";
            return true;
        }
    }
}
