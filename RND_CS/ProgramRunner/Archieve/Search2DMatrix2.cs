using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    [Info("Binary Search", "https://leetcode.com/problems/search-a-2d-matrix-ii/")]
    public class Search2DMatrix2 : Runner
    {
        public class Solution
        {
            public bool SearchMatrix(int[,] matrix, int target)
            {
                if (matrix.Length == 0) return false;

                int numrows = matrix.GetLength(0);
                int numcols = matrix.GetLength(1);
                int r = 0;
                int c = numcols - 1;

                while (r < numrows && c >= 0)
                {
                    if (matrix[r, c] == target)
                        return true;

                    if (r + 1 < numrows && c + 1 < numcols && target > matrix[r, c + 1] && target > matrix[r + 1, c])
                    {
                        r += 1;
                        c += 1;
                        continue;
                    }

                    if (matrix[r, c] < target)
                        r += 1;
                    else
                        c -= 1;
                }
                return false;
            }

        }

        public override void Run(string[] args)
        {
            int[,] arr = new int[5, 5]
            {
              { 1, 4, 7, 11, 15 },
              { 2, 5, 8, 12, 19 },
              { 3, 6, 9, 16, 22 },
              { 10, 13, 14, 17, 24 },
              { 18, 21, 23, 26, 30 }
            };

            var sol = new Solution();
            Debug.Assert(() => sol.SearchMatrix(arr, 13), true);
            Debug.Assert(() => sol.SearchMatrix(arr, 18), true);
            Debug.Assert(() => sol.SearchMatrix(arr, 1), true);
            Debug.Assert(() => sol.SearchMatrix(arr, 4), true);
            Debug.Assert(() => sol.SearchMatrix(arr, 2), true);
        }
    }
}
