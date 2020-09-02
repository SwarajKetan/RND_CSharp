using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    [Info("Timelimit exceeded")]
    public class MinimumHeightTrees : Runner
    {
        public class Solution
        {

            int unprocessed = 0, processed = 1;
            public IList<int> FindMinHeightTrees(int n, int[][] edges)
            {
                if (edges.Length == 0)
                    return new List<int>() { 0 };

                // prepare adj list
                var adj = new Dictionary<int, List<int>>(n);
                for (int i = 0; i < edges.Length; i++)
                {
                    int s = edges[i][0]; // source
                    int d = edges[i][1]; // destination

                    if (!adj.ContainsKey(s))
                        adj.Add(s, new List<int>());
                    if (!adj.ContainsKey(d))
                        adj.Add(d, new List<int>());

                    adj[s].Add(d);
                    adj[d].Add(s);
                }

                // dfs to get depth
                int[] depth = new int[n];
                var res = new List<int>();
                int min = int.MaxValue;
                for (int i = 0; i < n; i++)
                {
                    depth[i] = DepthOf(adj, new int[n], i);
                    if (min > depth[i])
                    {
                        min = depth[i];
                        res.Clear();
                        res.Add(i);
                    }
                    else if (min == depth[i])
                    {
                        res.Add(i);
                    }
                }

                return res;

            }

            int DepthOf(Dictionary<int, List<int>> adj, int[] visited, int num)
            {
                if (visited[num] == processed) return 0;
                visited[num] = processed;

                int max = 0;
                foreach (int a in adj[num])
                {
                    if (visited[a] == unprocessed)
                    {
                        int k = DepthOf(adj, visited, a);
                        visited[a] = processed;

                        if (k > max)
                            max = k;
                    }
                }
                return 1 + max;
            }
        }

        public override void Run(string[] args)
        {
            var sol = new Solution();
            var edges = new int[][] { new int[] { 0, 3 }, new int[] { 1, 3 }, new int[] { 2, 3 }, new int[] { 4, 3 }, new int[] { 5, 4 } };
            var res = sol.FindMinHeightTrees(6, edges);
            var res2 = sol.FindMinHeightTrees(1, new int[][] { });
        }
    }
}
