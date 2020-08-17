using System; using TinyRunner;
using System.Collections.Generic;

using System.Text;

namespace ProgramRunner
{
    [Skip]
    public class NumberOfIslands : Runner
    {
        public class Solution
        {
            public int NumIslands(char[][] grid)
            {

                int noi = 0;

                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid[i].Length; j++)
                    {
                        if (grid[i][j] == '1')
                            noi += EatAsFarWeCan(grid, i, j);
                    }

                }

                return noi;
            }

            int EatAsFarWeCan(char[][] grid, int i, int j)
            {

                if (i < 0 || i >= grid.Length || grid.Length == 0 || j < 0 || j >= grid[i].Length || grid[i][j] == '0')
                    return 0;

                grid[i][j] ='0'; // eating like a worm

                EatAsFarWeCan(grid, i - 1, j);
                EatAsFarWeCan(grid, i + 1, j);
                EatAsFarWeCan(grid, i, j - 1);
                EatAsFarWeCan(grid, i, j + 1);

                return 1;
            }
        }
        public override void Run(string[] args)
        {
            var grid1 = new char[][]
            {
                new char[]{'1', '1', '1', '1', '0'},
                new char[]{'1', '1', '0', '1', '0'},
                new char[]{'1', '1', '0', '0', '0'},
                new char[]{'0', '0', '0', '0', '0'}
            };

            var grid2 = new char[][]
            {
                new char[]{'1','1','0','0','0'},
                new char[]{'1','1','0','0','0'},
                new char[]{'0','0','1','0','0'},
                new char[]{'0','0','0','1','1'}
            };

            var sol = new Solution();
            Debug.Assert(()=> sol.NumIslands(grid1), 1);
            Debug.Assert(()=> sol.NumIslands(grid2), 3);
        }
    }
}
