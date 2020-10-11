using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;
using System.Linq;
namespace ProgramRunner
{
    [Skip]
    public class CombinationSumIII : Runner
    {
        public class Solution
        {
            List<IList<int>> ans = new List<IList<int>>();
            public IList<IList<int>> CombinationSum3(int k, int n)
            {
                BackTrack(0, n, 1, k, new List<int>());
                return ans;
            }

            void BackTrack(int sum, int target, int start, int k, List<int> tmp)
            {
                if (tmp.Count == k && sum == target)
                {
                    ans.Add(new List<int>(tmp));
                    return;
                }

                if (tmp.Count > k || start > 9) return;

                for (int i = start; i <= 9; i++)
                {
                    if (sum + i <= target)
                    {
                        tmp.Add(i);
                        BackTrack(sum + i, target, i + 1, k, tmp);
                        tmp.RemoveAt(tmp.Count - 1);
                    }
                }
            }
        }
        public override void Run(string[] args)
        {
            var sol = new Solution();
            var res = sol.CombinationSum3(9, 45);
        }
    }
}
