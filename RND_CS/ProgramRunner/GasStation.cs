using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class GasStation : Runner
    {
        public class Solution
        {
            public int CanCompleteCircuit(int[] gas, int[] cost)
            {
                int n = gas.Length;

                int rem = 0;
                int index = 0;
                int currentGas = 0;
                for (int i = 0; i < n; i++)
                {
                    int k = gas[i] - cost[i];
                    rem += k;
                    currentGas += k;

                    Debug.PrintLine($"k = {k} rem= {rem} curr= {currentGas}");

                    if(currentGas < 0)
                    {
                        index = i;
                        currentGas = 0;
                    }
                }

                return rem >= 0 ? index + 1 : -1;
            }
        }

        public override void Run(string[] args)
        {
            Debug.Assert(() => new Solution().CanCompleteCircuit(new int[] { 1, 2, 3, 4, 5 }, new int[] { 3, 4, 5, 1, 2 }), 3);
            Debug.Assert(() => new Solution().CanCompleteCircuit(new int[] { 2, 3, 4}, new int[] { 3, 4,3 }), -1);
        }
    }
}
