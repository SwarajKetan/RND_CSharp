using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    [Info("https://leetcode.com/problems/longest-continuous-subarray-with-absolute-diff-less-than-or-equal-to-limit/")]
    public class LongestContSubarry : Runner
    {
        public class Solution
        {
            public int LongestSubarray(int[] nums, int limit)
            {
                int subArrLen = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    int diff = 0;
                    int len = 0;
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        int absdif = Math.Abs(nums[j] - nums[i]);
                        if(absdif > diff)
                        {
                            diff = absdif;
                            if(absdif <= limit)
                            {
                                len = j - i + 1;
                            }
                        }
                    }

                    if (len > subArrLen)
                        subArrLen = len;
                }
                return subArrLen;
            }
        }

        public override void Run(string[] args)
        {
            var sol = new Solution();
            Debug.Assert(() => sol.LongestSubarray(new int[] { 8, 2, 4, 7 }, 4), 2);
            Debug.Assert(() => sol.LongestSubarray(new int[] { 10, 1, 2, 4, 7, 2 }, 5), 4);
            Debug.Assert(() => sol.LongestSubarray(new int[] { 4, 2, 2, 2, 4, 4, 2, 2 }, 0), 3);
        }
    }
}
