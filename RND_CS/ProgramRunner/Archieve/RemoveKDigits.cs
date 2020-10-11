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
                if (num.Length == 0) return num;
                Stack<char> s = new Stack<char>();                
                for (int i = 0; i < num.Length; i++)
                {
                    if (s.Count > 0 && num[i] <= s.Peek() && k-- > 0)
                        s.Pop();
                    if (s.Count == 0 && num[i] == '0') continue;
                    s.Push(num[i]);
                }

                string ans = "";
                int takeCount = s.Count - (k < 0 ? 0 : k);
                while (takeCount-- > 0)
                    ans = s.Pop() + ans;
                return ans == "" ? "0" : ans;
            }
        }

        public override void Run(string[] args)
        {
            Solution sol = new Solution();
            Debug.Assert(()=> sol.RemoveKdigits("1432219", 3), "1219");
            Debug.Assert(()=> sol.RemoveKdigits("10200", 1) , "200");
            Debug.Assert(() => sol.RemoveKdigits("9", 1) , "0");
            Debug.Assert(() => sol.RemoveKdigits("1001", 2) , "0");
            Debug.Assert(()=>sol.RemoveKdigits("1234567890", 9) , "0");
        }
    }
}
