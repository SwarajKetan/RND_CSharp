using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class Search2DMatrix : Runner
    {
        public class Solution
        {
            public bool SearchMatrix(int[][] matrix, int target)
            {
                if (matrix.Length == 0 || matrix[0].Length == 0) return false;
                return Find(matrix, 0, matrix.Length - 1, target);
            }

            bool Find(int[][] matrix, int sr, int er, int target)
            {
                if (sr > er) return false;

                int mid = sr + (er - sr) / 2;

                if (target < matrix[mid][0])
                {
                    return Find(matrix, sr, mid - 1, target);
                }
                else if (target > matrix[mid][matrix[mid].Length - 1])
                    return Find(matrix, mid + 1, er, target);

                return Find2(matrix[mid], 0, matrix[mid].Length - 1, target);

            }

            bool Find2(int[] arr, int left, int right, int target)
            {
                if (left > right) return false;

                int mid = left + (right - left) / 2;

                if (arr[mid] == target) return true;

                if (arr[mid] > target)
                    return Find2(arr, left, mid - 1, target);
                return Find2(arr, mid + 1, right, target);
            }
        }
        public override void Run(string[] args)
        {
            var sol = new Solution();
            Debug.Assert(() => sol.SearchMatrix(new int[][] { new int[] { } }, 1), false);
            Debug.Assert(() => sol.SearchMatrix(new int[][] { new int[] { 1 } }, 2), false);
            Debug.Assert(() => sol.SearchMatrix(new int[][] { new int[] { 1 } }, 1), true);
            Debug.Assert(() => sol.SearchMatrix(new int[][] { new int[] { 2 } }, 2), true);
            Debug.Assert(() => sol.SearchMatrix(new int[][] { new int[] { 1 }, new int[] { 3 } }, 2), false);
        }
    }
}
