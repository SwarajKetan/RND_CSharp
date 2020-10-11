using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class LongestIncreasingPath : Runner
    {
        public override void Run(string[] args)
        {
            var sol = new Solution();

            int[][] mat = new int[][]
            {
                new int[] { 3, 4, 5 },
                new int[] { 3, 2, 6 },
                new int[] { 2, 2, 1 }
            };

            Debug.Assert(() => sol.LongestIncreasingPath(mat), 4);
        }

        public class Solution
        {
            public int LongestIncreasingPath(int[][] matrix)
            {
                int m = matrix.Length;
                int n = matrix[0].Length;
                int ans = int.MinValue;
                bool[][] vis = new bool[m][];
                Array.Fill(vis, new bool[n]);

                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {

                        if (!vis[i][j])
                        {
                            int len = 0;
                            DFS(matrix, vis, i, j, m, n, int.MinValue, ref len);
                            ans = Math.Max(ans, len);
                            vis[i][j] = true;
                        }
                    }
                }
                return ans;
            }

            void DFS(int[][] mat, bool[][] vis, int r, int c, int m, int n, int prev, ref int len)
            {
                if (r < 0 || c < 0 || r >= m || c >= n || mat[r][c] == 0)
                    return;

                if (mat[r][c] <= prev) return;

                len++;
                
                int cur = mat[r][c];

                mat[r][c] = 0;

                DFS(mat, vis, r, c + 1, m, n, cur, ref len);
                DFS(mat, vis, r + 1, c, m, n, cur, ref len);
                DFS(mat, vis, r, c - 1, m, n, cur, ref len);
                DFS(mat, vis, r - 1, c, m, n, cur, ref len);

                mat[r][c] = cur;
            }
        }
    }
}
