using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class FirstDuplicate : Runner
    {
        int Dup(int[] nums)
        {
            long flag = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                long mask = 1 << nums[i];
                if ((flag & mask) > 0)
                    return nums[i];
                flag = flag | mask;
            }
            return -1;
        }
        public override void Run(string[] args)
        {
            Debug.Assert(() => Dup(new int[] { 1, 3, 4, 2, 2 }), 2);
        }
    }
}
