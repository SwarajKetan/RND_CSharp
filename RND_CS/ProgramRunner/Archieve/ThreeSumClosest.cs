using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    [Info("https://leetcode.com/problems/3sum-closest/")]
    public class ThreeSumClosest : Runner
    {
        public class Solution
        {
            public int ThreeSumClosest(int[] nums, int target)
            {
                Array.Sort(nums);
                int closest = nums[0] + nums[1] + nums[2];

                for (int i = 0; i < nums.Length; i++)
                {
                    int left = i + 1;
                    int right = nums.Length - 1;
                    while (left < right)
                    {
                        int sum = nums[i] + nums[left] + nums[right];
                        if (Math.Abs(sum - target) < Math.Abs(closest - target))
                        {
                            closest = sum;
                        }

                        if (sum == target)
                            return sum;
                        else if (sum < target)
                        {
                            left += 1;
                        }
                        else
                        {
                            right -= 1;
                        }
                    }
                }

                return closest;
            }
        }

        public override void Run(string[] args)
        {

            var sol = new Solution();

            Debug.Assert(() => sol.ThreeSumClosest(new int[] { -1, 2, 1, -4 }, 1), 2);
        }
    }
}
