using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class DetectCyclesIn2DGrid : Runner
    {
        public class Solution
        {
            public bool ContainsCycle(char[][] grid)
            {
                bool[][] seen = new bool[grid.Length][];
                Array.Fill(seen, new bool[grid[0].Length]);

                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid[0].Length; j++)
                    {
                        if (!seen[i][j] && search(grid, grid[i][j], i, j, seen))
                        {
                            return true;
                        }
                    }
                }

                return false;
            }

            private bool search(char[][] grid, char target, int i, int j, bool[][] seen)
            {
                if (i < 0 || j < 0 || i >= grid.Length || j >= grid[0].Length || grid[i][j] != target || seen[i][j])
                {
                    return false;
                }

                seen[i][j] = true;
                grid[i][j] = '#';

                bool found = search(grid, target, i + 1, j, seen)
                            || search(grid, target, i - 1, j, seen)
                            || search(grid, target, i, j - 1, seen)
                            || search(grid, target, i, j + 1, seen);

                grid[i][j] = target; // re-place char

                return found;
            }
        }

        public override void Run(string[] args)
        {
            var input = new char[][]
            {
                new char[]{ 'a', 'b', 'b' },
                new char[]{ 'b', 'z', 'b' },
                new char[]{ 'b', 'b', 'a' }
            };

            var sol = new Solution();
            Debug.Assert(() => sol.ContainsCycle(input), false);
        }
    }
}
