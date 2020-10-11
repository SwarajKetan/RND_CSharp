using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class TheMazeII
    {
        [Skip]
        public class Solution : Runner
        {

            int[] vertical = { -1, 1, 0, 0 };
            int[] horizontal = { 0, 0, -1, 1 };

            public override void Run(string[] args)
            {
                var maze = new int[][]
                {
                    new int[]{ 0, 0, 1, 0, 0 },
                    new int[]{ 0, 0, 0, 0, 0 },
                    new int[]{ 0, 0, 0, 1, 0 },
                    new int[]{ 1, 1, 0, 1, 1 },
                    new int[]{ 0, 0, 0, 0, 0 }
                };

                Debug.Assert(() => new Solution().ShortestDistance(maze, new int[] { 0, 4 }, new int[] { 4, 4 }), 12);
            }

            public int ShortestDistance(int[][] maze, int[] start, int[] destination)
            {
                throw new NotImplementedException();
            }

            bool dfs(int[][] m, int[] d, int r, int c)
            {
                if (m[r][c] == 2) return false;
                if (r == d[0] && c == d[1]) return true;

                m[r][c] = 2;
                bool reached = false;
                for (int i = 0; i < 4; i++)
                {
                    int x = r;
                    int y = c;

                    //to check the wall
                    while (x >= 0 && y >= 0 && x < m.Length && y < m[0].Length && m[x][y] != 1)
                    {
                        x += vertical[i];
                        y += horizontal[i];
                    }

                    // subtract to come out of the wall
                    reached = reached || dfs(m, d, x - vertical[i], y - horizontal[i]);
                }
                return reached;
            }
        }
    }
}
