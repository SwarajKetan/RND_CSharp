using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;
namespace ProgramRunner
{
    [Skip]
    public class ReplaceInts : Runner
    {
        string repl(string s)
        {
            string ans = "";          
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsDigit(s[i]))
                {
                    if (ans.Length > 0 && ans[ans.Length - 1] != '*')
                    {
                        ans += '*';
                        continue;
                    }
                    if (ans == "") ans += '*';
                }
                else 
                    ans += s[i];
            }
            return ans;
        }

        public override void Run(string[] args)
        {
            string ss = repl("I will eat 2 burgers 23 fries & 1.25 cokes l8r");

            Debug.Assert(() => repl("I will eat 2 burgers 23 fries & 1.25 cokes l8r"), "I will eat * burgers * fries & . cokes l*r");
        }
    }
}
