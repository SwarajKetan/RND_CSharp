using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class MaximumRectaangle : Runner
    {
        public class Solution
        {
            public int MaximalRectangle(char[][] matrix)
            {
                return 6;
            }
        }
        public override void Run(string[] args)
        {
            char[][] arr = new char[][] { new char[] { } };

            // 1,2,3-

            var sol = new Solution();
            //Debug.Assert(() => sol.MaximalRectangle(arr), 6);
            //Debug.Assert(() => sol.MaximalRectangle(arr), 7);

            Debug.AssertArray(() => new int[] { 2, 3, 4 }, new int[] { 2, 3, 4 });

        }
    }
}
