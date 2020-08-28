using System;
using System.Collections.Generic;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class NQueens : Runner
    {
        public class Solution
        {
            public IList<IList<string>> SolveNQueens(int n)
            {
                PrintQueen(new char[n,n], 0);
                return res;
            }

            List<IList<string>> res = new List<IList<string>>();
            HashSet<(int QI, int QJ)> QPositions = new HashSet<(int QI, int QJ)>();

            bool IsSafeToPlace(int i, int j)
            {
                foreach(var (QI, QJ) in QPositions)
                {
                    if (QJ == j) return false;

                    if ((QI + 1 == i && QJ - 1 == j) || (QI + 1 == i && QJ + 1 == j))
                        return false;
                }
                return true;
            }

            private void PrintQueen(char[,] board, int i)
            {
                int len = board.GetLength(0);
                if (i == len)
                {
                    string[] arr = new string[len];

                    for (int m = 0; m < len; m++)
                    {
                        string tmp = "";
                        for (int n = 0; n < len; n++)
                        {
                            tmp += board[m,n] == '\0' ? '.' : board[m,n];
                        }
                        arr[m] = tmp;
                    }

                    res.Add(arr);
                    return;
                }

                for (int j = 0; j < len; j++)
                {
                    Console.WriteLine($"i = {i}  j = {j}");
                    if (IsSafeToPlace(i,j))
                    {
                        board[i,j] = 'Q';
                        QPositions.Add((i, j));
                        PrintQueen(board, i + 1);
                        board[i,j] = '.';
                        QPositions.Remove((i,j));
                    }
                }

            }
        }
        public override void Run(string[] args)
        {
            var sol = new Solution();
            var res = sol.SolveNQueens(5);
        }
    }
}
