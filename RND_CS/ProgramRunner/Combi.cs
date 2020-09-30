using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class Combi : TinyRunner.Runner
    {
        List<string> ans = new List<string>();

        void Dfs(char[] s, int start)
        {
            if (start >= s.Length)
            {
                PrintLine($"{new string(s)}", ConsoleColor.Cyan);
                ans.Add(new string(s));
                return;
            }

            for (int i = start; i < s.Length; i++)
            {
                PrintLine($"i={i} start={start}", ConsoleColor.Green);
                Swap(ref s[i], ref s[start]);
                Dfs(s, start + 1);
                PrintLine($"i={i} start={start}", ConsoleColor.DarkGreen);
                Swap(ref s[i], ref s[start]);
            }
        }

        

        public override void Run(string[] args)
        {
            Dfs("abcd".ToCharArray(), 0);
        }
    }
}
