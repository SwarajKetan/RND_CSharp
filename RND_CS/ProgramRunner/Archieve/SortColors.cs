using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class SortColors : Runner
    {
        public class Solution
        {
            public void SortColors(int[] nums)
            {

            }
        }

        public override void Run(string[] args)
        {
            var sol = new Solution();
            var arr = new int[] { 2, 0, 2, 0, 1, 1, 1, 2 };
            sol.SortColors(arr);
        }
    }
}
