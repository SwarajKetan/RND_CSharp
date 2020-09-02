using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class MaxIncreaseCitySkyline : Runner
    {
        public class Solution
        {
            int sum = 0;
            public int MaxIncreaseKeepingSkyline(int[][] grid)
            {
                int r = grid.Length;
                int c = grid[0].Length;

                int[] dpr = new int[r]; // romax
                int[] dpc = new int[c]; // col mx

                Traverse(grid, dpr, dpc, 0, 0);
                return sum;
            }

            void Traverse(int[][] grid, int[] dpr, int[] dpc, int r, int c)
            {
                if (r < 0 || c < 0 || r >= grid.Length || c >= grid[0].Length) return;

                if (dpr[r] < grid[r][c])
                    dpr[r] = grid[r][c];
                if (dpc[c] < grid[r][c])
                    dpc[c] = grid[r][c];

                Console.WriteLine($"R:{r}, C:{c}");

                Traverse(grid, dpr, dpc, r, c + 1);
                Traverse(grid, dpr, dpc, r + 1, c);

                int max = Math.Min(dpr[r], dpc[c]);
                if (max > grid[r][c])
                {
                    sum += max - grid[r][c];
                    grid[r][c] = max;
                }
            }
        }

        public override void Run(string[] args)
        {
            var sol = new Solution();
            int[][] a = new int[][] { new int[] { 3, 0, 8, 4 }, new int[] { 2, 4, 5, 7 }, new int[] { 9, 2, 6, 3 }, new int[] { 0, 3, 1, 0 } };
            Debug.Assert(() => sol.MaxIncreaseKeepingSkyline(a), 35);
        }
    }
}
