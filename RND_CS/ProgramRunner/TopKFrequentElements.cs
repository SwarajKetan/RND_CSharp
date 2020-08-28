using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class TopKFrequentElements : Runner
    {
        public class Solution
        {
            class SpecialComparer : IComparer<int>
            {
                public int Compare(int x, int y)
                {
                    int msbx = Math.Abs(x) / mul;
                    int msby = Math.Abs(y) / mul;
                    return msbx == msby ? 0 : msbx < msby ? -1 : 1;
                }
            }

            static int mul = 0;
            public int[] TopKFrequent(int[] nums, int k)
            {
                int max = int.MinValue;
                Dictionary<int, int> map = new Dictionary<int, int>();
                Dictionary<int, int> sign = new Dictionary<int, int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    if (!map.ContainsKey(nums[i]))
                    {
                        map.Add(nums[i], 0);
                        sign.Add(nums[i], nums[i] < 0 ? -1 : 1);
                        if (Math.Abs(nums[i]) > max)
                            max = Math.Abs(nums[i]);
                    }
                    map[nums[i]] += 1;
                }

                mul = (int)Math.Pow(10, max.ToString().Length);

                int[] arr = new int[map.Count];
                int j = 0;
                foreach(var kvp in map)
                {
                    arr[j++] = sign[kvp.Key] * kvp.Value * mul + kvp.Key;
                }

                Array.Sort(arr, new SpecialComparer());

                int[] res = new int[k];
                for(int i = 0; i < k; i++)
                {                    
                    int tmp = arr[arr.Length - i - 1];
                    res[i] = (tmp >= 0) ? (tmp - ((tmp / mul) * mul))
                            : (tmp + (-1) * ((tmp / mul) * mul));
                }

                return res;

            }
        }

        public override void Run(string[] args)
        {
            var sol = new Solution();
            var r0 = sol.TopKFrequent(new int[] { -1, -1, -1, 3, 3, 2 }, 2);
            var r = sol.TopKFrequent(new int[] { 1, 1, 1, 3, 3, 2 }, 2);
            var r2 = sol.TopKFrequent(new int[] { -1, 1 }, 1);
        }

    }
}
