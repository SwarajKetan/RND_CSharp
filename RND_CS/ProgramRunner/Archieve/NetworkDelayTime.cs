using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class NetworkDelayTime : Runner
    {
        public class Solution
        {
            public int NetworkDelayTime(int[][] times, int N, int K)
            {

                int sum = 0;
                int u = 0, v = 1, w = 2;
                Dictionary<int, List<int>> adj = new Dictionary<int, List<int>>();
                for (int i = 0; i < times.Length; i++)
                {
                    if (!adj.ContainsKey(times[i][u]))
                        adj.Add(times[i][u], new List<int>());

                    adj[times[i][u]].Add(times[i][v]);
                }

                return sum;
            }
        }

        public override void Run(string[] args)
        {
            var sol = new Solution();

            int[][] times = new int[][] { new int[] { 2, 1, 1 }, new int[] { 2, 3, 1 }, new int[] { 3, 4, 1 } };
            Debug.Assert(() => sol.NetworkDelayTime(times, 4, 2), 2);
        }
    }
}
