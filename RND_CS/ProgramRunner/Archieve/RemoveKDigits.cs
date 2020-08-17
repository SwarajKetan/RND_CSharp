using System.Collections.Generic;

using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class RemoveKDigits : Runner
    {
        public class Solution
        {
            public string RemoveKdigits(string num, int k)
            {
                if (num.Length <= k)
                    return "0";

                // 48 = 0 , 57 = 9
                Stack<char> stk = new Stack<char>();
                for (int i = 0; i < num.Length; i++)
                {
                    if (stk.Count > 0 && stk.Peek() > num[i] && k > 0)
                    {
                        k--;
                        stk.Pop();
                    }                    
                    stk.Push(num[i]);
                }

                while(stk.Count > 0 && k > 0)
                {
                    stk.Pop();
                    k--;
                }


                string res = "";
                while(stk.Count > 0)
                {
                    char c = stk.Pop();

                    if (stk.Count == 0 && c == '0')
                        continue;

                    res = c + res;
                }
                return res == "" ? "0" : res;
            }
        }

        public override void Run(string[] args)
        {
            Solution sol = new Solution();
            //Debug.Assert(sol.RemoveKdigits("1432219", 3) == "1219");
            //Debug.Assert(sol.RemoveKdigits("10200",1) == "200");
            //Debug.Assert(sol.RemoveKdigits("9", 1) == "0");
            //Debug.Assert(sol.RemoveKdigits("1001", 2) =="0");
            Debug.Assert(()=>sol.RemoveKdigits("1234567890", 9) , "0");
        }
    }
}
