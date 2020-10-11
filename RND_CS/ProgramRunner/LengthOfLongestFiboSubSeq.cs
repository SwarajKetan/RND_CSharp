using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class LengthOfLongestFiboSubSeq : Runner
    {
        public class Solution
        {
            int ans = int.MinValue;
            public int LenLongestFibSubseq(int[] A)
            {
                BackTrack(A, 2, A[0] + A[1], 0);
                return ans == 0 ? 0 : ans + 2;
            }

            void BackTrack(int[] nums, int start, int target, int len)
            {

                if (start >= nums.Length) return;

                if (nums[start] == target)
                {
                    len++;
                }
                else if (nums[start] > target)
                {
                    ans = Math.Max(ans, len);
                    return;
                }

                for (int i = start; i < nums.Length; i++)
                {
                    int rem = target - nums[i];

                    if (rem > 0)
                    {
                        for (int j = i + 1; j < nums.Length; j++)
                        {
                            BackTrack(nums, j + 1, nums[i] + nums[j], len);
                        } 
                    }
                }

            }
        }
        public override void Run(string[] args)
        {
            var sol = new Solution();
            Debug.Assert(() => sol.LenLongestFibSubseq(new int[] { 1, 3, 7, 11, 12, 14, 18 }), 3);
            //Debug.Assert(() => sol.LenLongestFibSubseq(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }), 5);
        }
    }
}
