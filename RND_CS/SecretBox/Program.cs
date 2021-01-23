using System;
using System.Collections.Generic;
using System.Reflection;

namespace SecretBox
{
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {

            //args = new string[] { "sbox - set facebook / website "www.facebook.com" / pwd "123" } 
            //new string[] { "sbox", "-get" };
            //new string[] { "sbox", "-setup", Environment.CurrentDirectory };

            //var xx = Environment.CommandLine;

            using (new ForeColor(ConsoleColor.Cyan))
            {
                var engine = new Engine();
                Dictionary<string, MethodInfo> map = engine.GetMethodMap();
                #region Read user's input
                string[] arr = args;

                int i = arr.Length - 1;
                List<object> parameters = new List<object>();

                List<(MethodInfo, List<object>)> invocationList = new List<(MethodInfo, List<object>)>();
                for (; i >= 0; i--)
                {
                    if (arr[i].Length == 0) continue;

                    if (arr[i][0] == '-')
                    {
                        if (!map.ContainsKey(arr[i]))
                        {
                            using (new ForeColor(ConsoleColor.Red))
                            {
                                Console.WriteLine($"{arr[i]} is not a known command.");
                            }
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
                Execute(engine, invocationList);
                #endregion
                #endregion 
            }
        }

        /// <summary>
        /// Write your code here, implement whatever way you want
        /// </summary>
        /// <param name="invocationList"></param>
        static void Execute(Engine engine, List<(MethodInfo, List<object>)> invocationList)
        {
            ICmdResult res = null;
            for (int k = invocationList.Count - 1; k >= 0; k--)
            {
                if (res != null)
                    invocationList[k].Item2.Add(res.Result);

                var cmdRes = invocationList[k].Item1.Invoke(engine, new[] { invocationList[k].Item2.ToArray<object>() }) as ICmdResult;
                if (cmdRes.Code == ResultCode.Error)
                {
                    using (new ForeColor(ConsoleColor.Red)) { Console.Write(cmdRes.Result); }
                    break;
                }
                res = cmdRes;
            }
            Console.WriteLine(res?.Result);
        }


    }
}
