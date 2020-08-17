using System; using TinyRunner;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Linq;

namespace ProgramRunner
{
    //[RunThis]
    [Skip]
    public class StringReconstructionByHeight : Runner
    {
        public class Solution
        {
            public int[,] ReconstructQueue(int[][] people)
            {
                int len = people.Length;
                var sp = people.OrderBy(p => p[0]).ToArray();
                int[][] na = new int[len][];


                return null;
            }
        }

        public override void Run(string[] args)
        {
            int[][] input = new int[][] { new int[] { 7, 0 }, new int[] { 4, 4 }, new int[] { 7, 1 }, new int[] { 5, 0 }, new int[] { 6, 1 }, new int[] { 5, 2 } };
            int[][] output = new int[][] { new int[] { 5, 0 }, new int[] { 7, 0 }, new int[] { 5, 2 }, new int[] { 6, 1 }, new int[] { 4, 4 }, new int[] { 7, 1 } };

            var res = new Solution().ReconstructQueue(input);
        }
    }
}
