using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class UniqueuePaths2 : Runner
    {
        public class Solution
        {
            public int UniquePathsWithObstacles(int[][] obstacleGrid)
            {

                int m = obstacleGrid.Length;
                int n = obstacleGrid[0].Length;

                int[,] dp = new int[m, n];

                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if(obstacleGrid[i][j] == 1)
                        {
                            dp[i, j] = 0;
                            continue;
                        }

                        if (i == 0 || j == 0)
                        {
                            if (i == 0 && j > 0)
                            {
                                dp[i, j] = dp[i, j - 1];
                            }
                            else if (i > 0 && j == 0)
                            {
                                dp[i, j] = dp[i - 1, j];
                            }
                            else
                            {
                                dp[i, j] = 1;
                            }
                        }
                        else
                        {
                            dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                        }
                    }
                }

                return dp[m - 1, n - 1];
            }
        }

        public override void Run(string[] args)
        {

            var arr = new int[][]{
  new int[]{0,0,0},
  new int[]{0,1,0},
  new int[]{0,0,0}
};
            var sol = new Solution();
            Debug.Assert(() => sol.UniquePathsWithObstacles(arr), 2);
            Debug.Assert(() => sol.UniquePathsWithObstacles(new int[][] { new int[] { 1 } }), 0);
            var a2 = new int[][]{ new int[]{ 0,0}, new int[]{ 1,0} };
            Debug.Assert(() => sol.UniquePathsWithObstacles(a2), 1);
        }
    }
}
