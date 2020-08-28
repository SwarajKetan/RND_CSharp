using System;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class RegexMatching : Runner
    {
        public class Solution
        {
            public bool IsMatch(string s, string p)
            {
                //if (p == string.Empty) return s.Length == 0;

                //string m = string.Empty;
                //for (int i = 0; i < s.Length; i++)
                //{
                //   if(s[i] == )
                //}
                return true;
            }

        }

        public override void Run(string[] args)
        {
            var sol = new Solution();

            Debug.Assert(() => sol.IsMatch("aa", "a"), false);
            Debug.Assert(() => sol.IsMatch("aa", "a*"), true);
            Debug.Assert(() => sol.IsMatch("aa", ".*"), true);
            Debug.Assert(() => sol.IsMatch("aab", "c*a*b"), true);
            Debug.Assert(() => sol.IsMatch("mississippi", "mis*is*p*."), false);
        }
    }
}
