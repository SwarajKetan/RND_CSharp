using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class CombinationSum_II : TinyRunner.Runner
    {
        public class Solution
        {

            int target = 0;
            public IList<IList<int>> CombinationSum2(int[] candidates, int target)
            {
                this.target = target;
                Array.Sort(candidates);
                List<IList<int>> res = new List<IList<int>>();
                Collect(candidates, res, new List<int>(), 0, 0);
                return res;
            }

            void Collect(int[] candidates, IList<IList<int>> result, List<int> res, int sum, int index)
            {
                if (sum == target)
                {
                    result.Add(new List<int>(res));
                    return;
                }

                for (int i = index; i < candidates.Length; i++)
                {
                    if (i > index && candidates[i] == candidates[i - 1])
                        continue;

                    if (sum + candidates[i] <= target)
                    {
                        res.Add(candidates[i]);
                        Collect(candidates, result, res, sum + candidates[i], i + 1);
                        res.RemoveAt(res.Count - 1);
                    }
                    else
                        break;
                }
            }
        }
        public override void Run(string[] args)
        {
            int[] arr = new int[] { 10, 1, 2, 7, 6, 1, 5 };
            var sol = new Solution();
            var es = sol.CombinationSum2(arr, 8);
        }
    }
}
