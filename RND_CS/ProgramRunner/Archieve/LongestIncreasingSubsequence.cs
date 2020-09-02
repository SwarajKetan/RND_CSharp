using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    [Info("https://leetcode.com/problems/longest-increasing-subsequence/")]
    public class LongestIncreasingSubsequence : Runner
    {
        public class Solution
        {
            public int LengthOfLIS(int[] nums)
            {
                return 0;
            }
        }

        public override void Run(string[] args)
        {
            var sol = new Solution();
            Debug.Assert(() => sol.LengthOfLIS(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 }), 4);
        }
    }
}
