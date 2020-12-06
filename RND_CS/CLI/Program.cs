using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CLI
{
    class Program
    {
        static Engine engine = null;

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"My Command-line tool v1.0 \n---------------------------------------------");
            Console.ResetColor();

            engine = new Engine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(engine.Help().Result);
            Console.ResetColor();
            Dictionary<string, MethodInfo> map = engine.GetMethodMap();

            #region Read user's input
            while (engine.On)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                string input = Console.ReadLine();
                string[] arr = input.Split(' ');

                int i = arr.Length - 1;
                List<object> parameters = new List<object>();

                List<(MethodInfo, List<object>)> invocationList = new List<(MethodInfo, List<object>)>();
                for (; i >= 0; i--)
                {
                    if (arr[i].Length == 0) continue;

                    if (arr[i][0] == '-')
                    {
                        Console.ResetColor();
                        if (!map.ContainsKey(arr[i]))
                        {
                            Console.WriteLine($"{arr[i]} is not a known command.");
                            break;
                        }

                        invocationList.Add((map[arr[i]], new List<object>(parameters)));
                        parameters.Clear();
                    }
                    else
                    {
                        parameters.Add(arr[i]);
                    }
                }

                #region Invocation
                Execute(invocationList);
                #endregion
            } 
            #endregion
            Console.ReadLine();
        }

        /// <summary>
        /// Write your code here, implement whatever way you want
        /// </summary>
        /// <param name="invocationList"></param>
        static void Execute(List<(MethodInfo, List<object>)> invocationList)
        {
            ICmdResult res = null;
            for (int k = invocationList.Count - 1; k >= 0; k--)
            {
                if (res != null)
                    invocationList[k].Item2.Add(res.Result);

                var cmdRes = invocationList[k].Item1.Invoke(engine, new[] { invocationList[k].Item2.ToArray<object>() }) as ICmdResult;
                if (cmdRes.Code == ResultCode.Error)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(cmdRes.Result);
                    Console.ResetColor();
                    break;
                }
                res = cmdRes;
            }
            Console.WriteLine(res?.Result);
        }


    }
}
