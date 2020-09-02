using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    [Info("https://leetcode.com/problems/largest-number/submissions/")]
    public class LargestNumber : TinyRunner.Runner
    {
        public class Solution
        {
            class SpecialComparer : IComparer<int>
            {
                public int Compare(int a, int b)
                {
                    string sa = a.ToString();
                    string sb = b.ToString();

                    string m = sa + sb;
                    string n = sb + sa;
                    return m == n ? 0 : Convert.ToInt64(m) < Convert.ToInt64(n) ? -1 : 1;
                }
            }

            public string LargestNumber(int[] nums)
            {
                Array.Sort(nums, new SpecialComparer());
                if (nums.Length > 0 && nums[nums.Length - 1] == 0) return "0";
                string r = "";
                for (int i = nums.Length - 1; i >= 0; i--)
                    r += nums[i].ToString();
                return r;
            }
        }
        public override void Run(string[] args)
        {
            var sol = new Solution();
            Debug.Assert(() => sol.LargestNumber(new int[] { 10, 2 }), "210");
            Debug.Assert(() => sol.LargestNumber(new int[] { 3, 30, 34, 5, 9 }), "9534330");
            Debug.Assert(() => sol.LargestNumber(new int[] { 121, 12 }), "12121");
        }
    }
}
