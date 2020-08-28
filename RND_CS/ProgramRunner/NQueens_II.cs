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
                PrintQueen(new char[n, n], 0);
                return res;
            }

            int res = 0;
            HashSet<(int QI, int QJ)> QPositions = new HashSet<(int QI, int QJ)>();

            bool IsSafeToPlace(int i, int j, int n)
            {
                foreach (var (QI, QJ) in QPositions)
                {
                    // vertical check
                    if (QJ == j)
                        return false;
                }

                // left diagonal and right diagional
                return IsSafe(i, j, n, true) && IsSafe(i, j, n, false);
            }

            bool IsSafe(int i, int j, int n, bool left)
            {
                if (j >= n || i < 0 || j < 0)
                    return true;

                if (QPositions.Contains((i, j)))
                    return false;

                if (left)
                    return IsSafe(i - 1, j - 1, n, true);
                else
                    return IsSafe(i - 1, j + 1, n, false);
            }

            private void PrintQueen(char[,] board, int i)
            {
                int len = board.GetLength(0);
                if (i == len)
                {
                    res += 1;
                    return;
                }

                for (int j = 0; j < len; j++)
                {
                    
                    if (IsSafeToPlace(i, j, len))
                    {
                        //Console.WriteLine($"i = {i} j = {j}");
                        board[i, j] = 'Q';
                        QPositions.Add((i, j));
                        PrintQueen(board, i + 1);
                        board[i, j] = '.';
                        QPositions.Remove((i, j));
                    }
                }

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
