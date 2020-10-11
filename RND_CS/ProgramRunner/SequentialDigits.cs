using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class SequentialDigits : Runner
    {
        public class Solution
        {

            List<int> ans = new List<int>();
            public IList<int> SequentialDigits(int low, int high)
            {
                int sum;
                for (int i = 1; i <= 9; i++)
                {
                    sum = 0;
                    for (int j = i; j <= 9; j++)
                    {
                        sum = sum * 10 + j;
                        if (sum > high) break;

                        if (sum >= low)
                        {
                            ans.Add(sum);
                        }
                    }
                }
                return ans;
            }


        }

        public override void Run(string[] args)
        {
            var res = new Solution().SequentialDigits(100, 300);
        }
    }
}
