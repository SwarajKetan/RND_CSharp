using System; using TinyRunner;
using System.Collections.Generic;
using System.Text;

namespace ProgramRunner
{
    [Skip]
    //[RunThis]
    public class RottingOranges : Runner
    {
        public class Solution
        {
            Queue<(int I, int J)> rSet = new Queue<(int I, int J)>();
            int fSetCount = 0; int spoiledTotal = 0;
            public int OrangesRotting(int[][] grid)
            {
                rSet.Clear(); fSetCount = 0; spoiledTotal = 0;
                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid[i].Length; j++)
                    {
                        if (grid[i][j] == 1)
                            fSetCount += 1;
                        else if (grid[i][j] == 2)
                            rSet.Enqueue((i, j));
                    }
                }
                
                int count = 0; int tmp;
                while ((tmp = rSet.Count) > 0)
                {                    
                    int c = 0;
                    while (tmp-- > 0)
                    {
                        var (I, J) = rSet.Dequeue();
                        c += Spoil(grid, I, J + 1);
                        c += Spoil(grid, I + 1, J);
                        c += Spoil(grid, I - 1, J);
                        c += Spoil(grid, I, J - 1);
                    }
                    count += c > 0 ? 1 : 0;
                }
                return spoiledTotal == fSetCount ? count : -1;
            }

            int Spoil(int[][] grid, int i, int j)
            {
                if (i >= 0 && j >= 0 && i < grid.Length && j < grid[i].Length && grid[i][j] == 1)
                {
                    grid[i][j] = 2; rSet.Enqueue((i, j)); spoiledTotal += 1;
                    return 1;
                }
                return 0;
            }
        }

        public override void Run(string[] args)
        {
            var sol = new Solution();
            int[][] arr = new int[][] { new int[] { 1, 2 } };
            int[][] arr2 = new int[][] { new int[] { 2, 1, 1 }, new int[] { 0, 1, 1 }, new int[] { 1, 0, 1 } };
            int[][] arr3 = new int[][] { new int[] { 2, 1, 1 }, new int[] { 1, 1, 0 }, new int[] { 0, 1, 1 } };
            int[][] arr4 = new int[][] { new int[] { 1, 2, 1, 1, 2, 1, 1 } };
            Assert(() => sol.OrangesRotting(arr), 1);
            Assert(() => sol.OrangesRotting(arr2), -1);
            Assert(() => sol.OrangesRotting(arr3), 4);
            Assert(() => sol.OrangesRotting(arr4), 2);
        }
    }
}
