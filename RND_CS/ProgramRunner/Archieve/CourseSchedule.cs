using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class CourseSchedule : Runner
    {
        public class Solution
        {
            int unprocesed = 0, processed = 2, processing = 1;
            public bool CanFinish(int numCourses, int[][] prerequisites)
            {
                if (numCourses <= 1 || prerequisites.Length <= 1) return true;

                // adjacency list
                Dictionary<int, List<int>> adj = new Dictionary<int, List<int>>(prerequisites.Length);
                for (int i = 0; i < prerequisites.Length; i++)
                {
                    int course = prerequisites[i][0];
                    int precourse = prerequisites[i][1];
                    if (!adj.ContainsKey(course))
                        adj.Add(course, new List<int>());
                    adj[course].Add(precourse);
                }

                // visited
                int[] visited = new int[numCourses];
                for (int i = 0; i < numCourses; i++)
                {
                    if(visited[i] == unprocesed)
                    {
                        if (IsCyclic(adj, visited, i))
                            return false;
                        visited[i] = processed;
                    }
                    
                }
                return true;
                
            }

            bool IsCyclic(Dictionary<int, List<int>> adj, int[] visited, int course)
            {
                if (visited[course] == processing)
                    return true;

                visited[course] = processing;
                if (!adj.ContainsKey(course))
                    return false;

                foreach (var c in adj[course])
                {
                    if(visited[c] != processed)
                    {
                        if (IsCyclic(adj, visited, c))
                            return true;
                        visited[c] = processed;
                    }
                }
                return false;                
            }
        }

        public override void Run(string[] args)
        {
            var sol = new Solution();

            var prerequisites_1 = new int[][] { new int[] { 1, 0 } };
            var numcourses_1 = 2;

            var prerequisites_2 = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 } };
            var numcourses_2 = 2;

            var prerequisites_3 = new int[][] { new int[] { 0,1 }, new int[] { 3, 1 }, new int[] { 1,3 }, new int[] { 3,2 } };
            var numcourses_3 = 4;

            var prerequisites_4 = new int[][] { new int[] { 1,0 }, new int[] { 0,2}, new int[] { 2,1 }};
            var numcourses_4 = 3;

            var prerequisites_5 = new int[][] { new int[] { 1, 0 }, new int[] { 2,0 } };
            var numcourses_5 = 3;

            var prerequisites_6 = new int[][] { new int[] { 0, 1}, new int[] { 0, 2 }, new int[] { 1,2 } };
            var numcourses_6 = 3;

            var prerequisites_7 = new int[][] { new int[] { 1, 0 }, new int[] { 2, 1 } };
            var numcourses_7 = 3;

            Debug.Assert(() => sol.CanFinish(numcourses_1, prerequisites_1), true);
            Debug.Assert(() => sol.CanFinish(numcourses_2, prerequisites_2), false);
            Debug.Assert(() => sol.CanFinish(numcourses_3, prerequisites_3), false);
            Debug.Assert(() => sol.CanFinish(numcourses_4, prerequisites_4), false);
            Debug.Assert(() => sol.CanFinish(numcourses_5, prerequisites_5), true);
            Debug.Assert(() => sol.CanFinish(numcourses_6, prerequisites_6), true);
            Debug.Assert(() => sol.CanFinish(numcourses_7, prerequisites_7), true);

        }
    }
}
