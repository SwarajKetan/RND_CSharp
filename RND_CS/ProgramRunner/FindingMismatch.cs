using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class FindingMismatch : Runner
    {
        int GetMisMatch(int[] a, int[] b)
        {
            int sum = 0;
            int i = 0;
            for (; i < a.Length && i < b.Length; i++)
                sum += a[i] - b[i];
            sum += i < a.Length ? a[i] : -b[i];
            return sum;
        }
        public override void Run(string[] args)
        {
            int[] a = new int[] { 1, 2, -3, 4, 5 };
            int[] b = new int[] { 4, 2, 1, 5 };

            Debug.Assert(() => GetMisMatch(a, b), -3);
        }
    }
}
