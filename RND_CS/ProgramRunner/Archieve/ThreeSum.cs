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
                HashSet<(int A, int B, int C)> res = new HashSet<(int A, int B, int C)>();
                if (nums.Length < 3)
                    return new int[][] { };// res.ToArray();

                Array.Sort(nums);

                for (int i = 0; i < nums.Length; i++)
                {
                    int left = i + 1;
                    int right = nums.Length - 1;

                    while (left < right)
                    {

                        int sum = nums[i] + nums[left] + nums[right];
                        if (sum == 0)
                        {
                            res.Add((nums[i], nums[left], nums[right] ));
                            break;
                        }
                        else if (sum < 0)
                            left += 1;
                        else
                            right -= 1;
                    }
                }

                List<int[]> arr = new List<int[]>();
                foreach(var set in res)
                    arr.Add(new int[] { set.A, set.B, set.C });

                return arr.ToArray();
            }
        }
        public override void Run(string[] args)
        {
            int[] arr = new int[] { -1, 0, 1, 2, -1, -4 };
            int[] arr2 = new int[] { 0, 0, 0, 0 };
            var sol = new Solution();
            var res = sol.ThreeSum(arr);
        }
    }
}
