using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class TheMaze : Runner
    {
        public class Solution
        {
            int[] vertical = { -1, 1, 0, 0 };
            int[] horizontal = { 0, 0, -1, 1 };

            public bool HasPath(int[][] maze, int[] start, int[] destination)
            {
                return dfs(maze, destination, start[0], start[1]);
            }


            bool dfs(int[][] m, int[] d, int r, int c)
            {
                if (m[r][c] == 2) return false;
                if (r == d[0] && c == d[1]) return true;

                m[r][c] = 2;
                bool reached = false;
                for (int i = 0; i < 4; i++)
                {
                    int x = r + vertical[i];
                    int y = c + horizontal[i];

                    while (x >= 0 && y >= 0 && x < m.Length && y < m[0].Length && m[x][y] != 1)
                    {
                        x += vertical[i];
                        y += horizontal[i];
                    }

                    //Console.WriteLine($"x= {x - vertical[i]} y={y - horizontal[i]}");
                    reached = reached || dfs(m, d, x - vertical[i], y - horizontal[i]);
                }
                return reached;
            }
        }
        public override void Run(string[] args)
        {
            /*
             [[0,0,1,0,0],[0,0,0,0,0],[0,0,0,1,0],[1,1,0,1,1],[0,0,0,0,0]]
                [0,4]
                [4,4]
             
             */
            //var sol = new Solution();

            var maze = new int[][]
            {
                new int[]{ 0, 0, 1, 0, 0 },
                new int[]{ 0,0,0,0,0 },
                new int[]{0,0,0,1,0 },
                new int[]{ 1,1,0,1,1},
                new int[]{ 0, 0, 0, 0, 0 }
            };


            /*
            
            maze 


            [[0,0,1,0,0],[0,0,0,0,0],[0,0,0,1,0],[1,1,0,1,1],[0,0,0,0,0]]
[0,4]
[3,2]

             */

            Debug.Assert(() => new Solution().HasPath(maze, new int[] { 0, 4 }, new int[] { 4, 4 }), true);
            Debug.Assert(() => new Solution().HasPath(maze, new int[] { 0, 4 }, new int[] { 3, 2 }), false);
        }
    }
}
