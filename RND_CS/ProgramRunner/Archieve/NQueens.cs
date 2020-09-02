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
                N = n;
                PrintQueen(new char[n, n], 0, new HashSet<(int R, int C)>(), new HashSet<int>());
                return res;
            }

            List<IList<string>> res = new List<IList<string>>();
            int N = 0;
            bool IsSafeToPlace(int i, int j, HashSet<(int R, int C)> blockedCells, HashSet<int> blockedCols)
            {

                if (blockedCols.Contains(j)) return false;

                int r = i;
                int c = j;
                int k = 1;
                while (r - k > -1 && (c - k > -1 || c + k < N))
                {
                    if (blockedCells.Contains((r - k, c + k)) || blockedCells.Contains((r - k, c - k)))
                        return false;
                    k++;
                }

                return true;
            }

            private void PrintQueen(char[,] board, int i, HashSet<(int R, int C)> blockedCells, HashSet<int> blockedCols)
            {
                int len = board.GetLength(0);
                if (i == len)
                {
                    foreach (var bc in blockedCells)
                        board[bc.R, bc.C] = 'Q';
                    string[] arr = new string[len];
                    for (int m = 0; m < len; m++)
                    {
                        string tmp = "";
                        for (int n = 0; n < len; n++)
                            tmp += board[m, n] == '\0' ? '.' : board[m, n];
                        arr[m] = tmp;
                    }

                    res.Add(arr);
                    return;
                }

                for (int j = 0; j < len; j++)
                {
                    if (!IsSafeToPlace(i, j, blockedCells, blockedCols))
                        continue;

                    board[i, j] = 'Q';
                    blockedCells.Add((i, j));
                    blockedCols.Add(j);
                    PrintQueen(board, i + 1, blockedCells, blockedCols);
                    board[i, j] = '.';
                    blockedCells.Remove((i, j));
                    blockedCols.Remove(j);
                }

            }
        }
        public override void Run(string[] args)
        {
            var sol = new Solution();
            var res = sol.SolveNQueens(4);
        }
    }
}
