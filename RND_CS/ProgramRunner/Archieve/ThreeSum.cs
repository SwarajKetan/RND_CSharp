using System; using TinyRunner;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace ProgramRunner
{
    //[RunThis]
    [Skip]
    public class ThreeSum : Runner
    {
        public class Solution
        {
            public IList<IList<int>> ThreeSum(int[] nums)
            {
                Array.Sort(nums);
                Dictionary<string, int[]> entries = new Dictionary<string, int[]>();
                for (int i = 0; i < nums.Length; i++)
                {
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        for (int k = j + 1; k < nums.Length; k++)
                        {
                            if (nums[i] + nums[j] + nums[k] == 0)
                            {
                                int[] a = new int[] { nums[i], nums[j], nums[k] };
                                var key = $"{a[0]}.{a[1]}.{a[2]}";
                                if (!entries.ContainsKey(key))
                                {
                                    entries.Add(key,a);
                                }
                            }
                        }
                    }
                }
                return entries.Values.ToArray();
            }

        }

        public override void Run(string[] args)
        {
            int[] arr = new int[] { -1, 0, 1, 2, -1, -4 };
            var sol = new Solution();
            var res = sol.ThreeSum(arr);
        }
    }
}
