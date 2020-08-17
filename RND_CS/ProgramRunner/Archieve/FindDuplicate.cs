using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class FindDuplicate : Runner
    {
        [Skip]
        [Info(ProblemLink = "https://leetcode.com/problems/find-the-duplicate-number/")]
        public class Solution
        {

            public int FindDuplicate(int[] nums)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[Math.Abs(nums[i])] < 0)
                        return Math.Abs(nums[i]);
                    else
                        nums[Math.Abs(nums[i])] = -nums[Math.Abs(nums[i])];
                }
                return -1;
            }
        }

        public override void Run(string[] args)
        {
            var sol = new Solution();
            Debug.Assert(() => sol.FindDuplicate(new int[] { 1, 3, 4, 2, 2 }), 2);
        }
    }
}
