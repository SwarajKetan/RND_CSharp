using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class ValidMountainArray : Runner
    {
        public override void Run(string[] args)
        {
            var sol = new Solution();
            Debug.Assert(()=> sol.ValidMountainArray(new int[] { 0, 3, 2, 1 }), true);
        }

        public class Solution
        {
            public bool ValidMountainArray(int[] A)
            {
                int i = 0;
                while (i + 1 < A.Length && A[i] < A[i + 1])
                    i++;
                int j = i;
                while (j + 1 < A.Length && A[j] > A[j + 1])
                    j++;

                return j == A.Length -1;
            }
        }

    }
}
