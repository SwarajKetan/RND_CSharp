using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class NQueens_II : Runner
    {
        public class Solution
        {
            public int TotalNQueens(int n)
            {
                int[] pos = new int[n];
                for (int i = 0; i < n; i++)
                {
                    pos[i] = -1;
                }
                return TotalNQueens(n, 0, pos);
            }

            public int TotalNQueens(int n, int row, int[] pos)
            {
                if (row >= n)
                {
                    return 1;
                }
                int res = 0;
                for (int col = 0; col < n; col++)
                {
                    if (pos[col] == -1)
                    {
                        bool valid = true;
                        for (int i = 0; i < n && valid; i++)
                        {
                            valid = pos[i] == -1 || Math.Abs(i - col) != Math.Abs(row - pos[i]);
                        }
                        if (valid)
                        {
                            pos[col] = row;
                            res += TotalNQueens(n, row + 1, pos);
                            pos[col] = -1;
                        }
                    }
                }
                return res;
            }
        }
        public override void Run(string[] args)
        {
            var sol = new Solution();
            Debug.Assert(() => sol.TotalNQueens(4), 2);
            Debug.Assert(() => sol.TotalNQueens(5), 10);
        }
    }
}
