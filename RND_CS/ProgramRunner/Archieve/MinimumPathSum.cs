using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    [Info("#dynamicprogramming", "#memoization", ProblemLink = "https://leetcode.com/problems/minimum-path-sum/")]
    public class MinimumPathSum : Runner
    {
        public class Solution
        {
            public int MinPathSum(int[][] grid)
            {
                int m = grid.Length;
                int n = grid[0].Length;
                int[,] dp = new int[m, n];
                dp[0, 0] = grid[0][0];

                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid[i].Length; j++)
                    {
                        if (i > 0 && j > 0)
                        {
                            dp[i, j] = Math.Min(dp[i - 1, j], dp[i, j - 1]) + grid[i][j];
                            continue;
                        }

                        else if (i > 0)
                        {
                            dp[i, j] = grid[i][j] + dp[i - 1, j];
                            continue;
                        }

                        else if (j > 0)
                        {
                            dp[i, j] = grid[i][j] + dp[i, j - 1];
                        }
                    }
                }

                return dp[m - 1, n - 1];
            }
        }

        public override void Run(string[] args)
        {
            var grid = new int[][]{
                new int[]{ 1,3,1},
                new int[]{ 1,5,1},
                new int[]{ 4,2,1}
            };

            var sol = new Solution();
            Debug.Assert(() => sol.MinPathSum(grid), 7);
        }
    }
}
