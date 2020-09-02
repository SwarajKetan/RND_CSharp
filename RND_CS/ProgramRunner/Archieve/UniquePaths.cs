using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class UniquePaths : Runner
    {
        public class Solution
        {
            public int UniquePaths(int m, int n)
            {
                int[,] dp = new int[m, n];

                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (i == 0 || j == 0)
                        {
                            dp[i, j] = 1;
                            continue;
                        }

                        dp[i, j] = dp[i - 1, j] + dp[i, j - 1];

                    }
                }
                return dp[m - 1, n - 1];

            }

        }

        public override void Run(string[] args)
        {
            var sol = new Solution();
            Debug.Assert(() => sol.UniquePaths(3, 2), 3);
            Debug.Assert(() => sol.UniquePaths(7, 3), 28);
        }
    }
}
