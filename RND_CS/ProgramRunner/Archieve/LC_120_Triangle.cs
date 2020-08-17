using System; using TinyRunner;
using System.Collections.Generic;
using System.Text;

namespace ProgramRunner
{
    [Skip]
    public class LC_120_Triangle : Runner
    {
        public override void Run(string[] args)
        {
            Console.WriteLine(
               new Solution()
                   .MinimumTotal(new int[][]
                   {
                    new int[]{ 2 },
                    new int[]{ 3, 4 },
                    new int[]{ 7, 5, 7 }

                   }));
        }

        public class Solution
        {
            public int MinimumTotal(IList<IList<int>> triangle)
            {
                if (triangle.Count == 0)
                    return 0;
                if (triangle.Count == 1)
                    return triangle[0][0];

                int[] dp = new int[triangle.Count];
                dp[0] = triangle[0][0];
                int li = (triangle[1][0] <= triangle[1][1]) ? 0 : 1;
                dp[1] = dp[0] + triangle[1][li];
                for (int i = 2; i < triangle.Count; i++)
                {
                    li = (triangle[i][li] <= triangle[i][li + 1]) ? li : li + 1;
                    dp[i] = dp[i - 1] + triangle[i][li];
                }
                return dp[triangle.Count - 1];
            }
        }
    }
}
