using System; using TinyRunner;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class MagicSquiresInGrid : Runner
    {
        public class Solution
        {
            public int NumMagicSquaresInside(int[][] grid)
            {
                int count = 0;
                for (int i = 0; i+2 < grid.Length; i++)
                {
                    for (int j = 0; j+2 < grid[i].Length; j++)
                    {
                        if (IsMG(grid, i, j))
                            count += 1; 
                    }
                }
                return count;
            }

            bool IsMG(int[][] grid, int i, int j)
            {
                int top = 0, mid = 0, bot = 0, diag1 = 0, diag2 = 0, c1 = 0, c2 = 0, c3 = -1;

                if ((top = grid[i][j] + grid[i][j + 1] + grid[i][j + 2]) == (mid = grid[i + 1][j] + grid[i + 1][j + 1] + grid[i + 1][j + 2]) &&
                    mid == (bot = grid[i + 2][j] + grid[i + 2][j + 1] + grid[i + 2][j + 2]) &&
                    bot == (diag1 = grid[i][j] + grid[i + 1][j + 1] + grid[i + 2][j + 2]) &&
                    diag1 == (diag2 = grid[i][j + 2] + grid[i + 1][j + 1] + grid[i + 2][j]) &&
                    diag2 == (c1 = grid[i][j] + grid[i + 1][j] + grid[i + 2][j]) &&
                    c1 == (c2 = grid[i][j + 1] + grid[i + 1][j + 1] + grid[i + 2][j + 1]) &&
                    c2 == (c3 = grid[i][j + 2] + grid[i + 1][j + 2] + grid[i + 2][j + 2]))
                {
                    HashSet<int> zeroToNine = new HashSet<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                    for (int k = 0; k < 3; k++)
                    {
                        for (int m = 0; m < 3; m++)
                        {
                            zeroToNine.Remove(grid[i + k][j + m]);
                        }
                    }
                    if (zeroToNine.Count == 0)
                        return true;
                }
                return false;
            }
        }

        public override void Run(string[] args)
        {
            int[][] arr = new int[][] { new int[] { 5, 5, 5 }, new int[] { 5, 5, 5 }, new int[] { 5, 5, 5 } };
            int[][] arr2 = new int[][] { new int[] { 3, 2, 9, 2, 7 }, new int[] { 6, 1, 8, 4, 2 }, new int[] { 7, 5, 3, 2, 7 }, new int[] { 2, 9, 4, 9, 6 }, new int[] { 4, 3, 8, 2, 5 } };
            Assert(() => new Solution().NumMagicSquaresInside(arr), 0);
            Assert(() => new Solution().NumMagicSquaresInside(arr2), 1);
        }
    }
}
