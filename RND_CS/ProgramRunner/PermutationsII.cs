using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class PermutationsII : Runner
    {
        public class Solution
        {
            int prev = int.MinValue;
            List<IList<int>> ans = new List<IList<int>>();
            public IList<IList<int>> PermuteUnique(int[] nums)
            {
                Array.Sort(nums);
                BackTrack(nums, 0);
                return ans;
            }

            void Swap(int[] nums, int i, int j)
            {
                int tmp = nums[i];
                nums[i] = nums[j];
                nums[j] = tmp;
            }

            void BackTrack(int[] nums, int start)
            {
                if (start >= nums.Length)
                {
                    ans.Add(new List<int>(nums));
                    return;
                }

                for (int i = start; i < nums.Length; i++)
                {
                    if (i == start || prev != nums[i])
                    {
                        prev = nums[i];

                        Swap(nums, start, i);
                        BackTrack(nums, start + 1);
                        Swap(nums, start, i);
                    }

                }

            }
        }
        public override void Run(string[] args)
        {
            var sol = new Solution();
            var ans = sol.PermuteUnique(new int[] { 0, 1, 0, 0, 9 });
        }
    }
}
