using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class DecodeWays : Runner
    {
        public class Solution
        {
            public int NumDecodings(string s)
            {
                // A -> Z 65-90
                // 1 -> 26
                if (s.Length == 0 || (s.Length == 1 && s[0] == '0'))
                    return 0;

                int n = s.Length;
                int[] dp = new int[n];
                dp[0] = 1; // upto 0 index
                dp[1] = dp[0] + (s[1] <= '6' ? 1 : 0);

                for (int i = 2; i < s.Length; i++)
                {
                    if (s[i - 1] > '2' | s[i] > '6' | s[i] == '0')
                    {
                        dp[i] = dp[i - 1];
                    }
                    else
                    {
                        dp[i] = dp[i - 1] + dp[i - 2];
                    }
                }
                return dp[n - 1];
            }

        }

        public override void Run(string[] args)
        {
            var sol = new Solution();
            Debug.Assert(() => sol.NumDecodings("12"), 2);
            Debug.Assert(() => sol.NumDecodings("226"), 3);
            Debug.Assert(() => sol.NumDecodings("39"), 1);
            Debug.Assert(() => sol.NumDecodings("229"), 2);
            Debug.Assert(() => sol.NumDecodings("399"), 1);
            Debug.Assert(() => sol.NumDecodings("206"), 1);
        }
    }
}
