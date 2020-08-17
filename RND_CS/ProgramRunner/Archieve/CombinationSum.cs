using System; using TinyRunner;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgramRunner
{
    [Skip]
    public class CombinationSum : Runner
    {
        public class Solution
        {
            List<List<int>> res = new List<List<int>>();
            List<int> tmp = new List<int>();
            public IList<IList<int>> CombinationSum(int[] candidates, int target)
            {
                if (candidates.Length == 0)
                    return null;

                CSI(candidates, target, 0, 0);
                return res.ToArray();
            }

            void CSI(int[] candidates, int target, int sum, int start)
            {
                tmp.ForEach(x => Console.Write($" {x} "));
                Console.WriteLine();
                if (sum == target)
                {
                    res.Add(new List<int>(tmp));
                    return;
                }

                for (int i = start; i < candidates.Length; i++)
                {
                    if(sum + candidates[i] <= target)
                    {
                        tmp.Add(candidates[i]);
                        CSI(candidates, target, sum + candidates[i], i);
                        tmp.Remove(tmp.Last());
                    }
                }
            }
        }

        public override void Run(string[] args)
        {
            var r = new Solution().CombinationSum(new int[] { 2, 3, 6, 7 }, 7);
        }
    }
}
