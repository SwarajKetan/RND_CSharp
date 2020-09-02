using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class CourseSchedule_II : Runner
    {
        public class Solution
        {
            public int[] FindOrder(int numCourses, int[][] prerequisites)
            {

                // prepare adj list
                Dictionary<int, List<int>> adj = new Dictionary<int, List<int>>();
                for (int i = 0; i < prerequisites.Length; i++)
                {
                    if (!adj.ContainsKey(prerequisites[i][0]))
                        adj.Add(prerequisites[i][0], new List<int>());
                    adj[prerequisites[i][0]].Add(prerequisites[i][1]);
                }

                int[] visited = new int[numCourses];
                for (int i = 0; i < numCourses; i++)
                {
                    if (visited[i] == unprocesed)
                    {
                        if (HasCycle(adj, i, visited))
                            return new int[] { };
                        visited[i] = processed;
                    }
                }
                // if cycle not found, go for topological sort
                Stack<int> stk = new Stack<int>();
                visited = new int[numCourses];

                for (int i = 0; i < numCourses; i++)
                {
                    if (visited[i] == unprocesed)
                        Dfs(adj, i, visited, stk);
                }

                int[] res = new int[stk.Count];
                int k = stk.Count - 1;
                while (stk.Count > 0)
                {
                    res[k--] = stk.Pop();
                }

                return res;
            }

            void Dfs(Dictionary<int, List<int>> adj, int course, int[] visited, Stack<int> stk)
            {
                visited[course] = processed;

                if (adj.ContainsKey(course))
                {
                    foreach (int c in adj[course])
                    {
                        if (visited[c] == unprocesed)
                            Dfs(adj, c, visited, stk);
                    }
                }
                stk.Push(course);
            }

            int unprocesed = 0, processed = 2, processing = 1;
            bool HasCycle(Dictionary<int, List<int>> adj, int course, int[] visited)
            {
                if (visited[course] == processing) 
                    return true;
                visited[course] = processing;

                if (!adj.ContainsKey(course))
                {                    
                    return false;
                }

                foreach (var dependency in adj[course])
                {
                    if (visited[dependency] != processed)
                    {
                        if (HasCycle(adj, dependency, visited))
                            return true;
                        visited[dependency] = processed;
                    }
                }
                return false;
            }
        }
        public override void Run(string[] args)
        {
            var sol = new Solution();
            //var xx = sol.FindOrder(4, new int[][] { new int[] { 1, 0 }, new int[] { 2, 0 }, new int[] { 3, 1 }, new int[] { 3, 2 } });
            var xx2 = sol.FindOrder(2, new int[][] { new int[] { 0,1 }, new int[] { 1, 0 }});
        }
    }
}
