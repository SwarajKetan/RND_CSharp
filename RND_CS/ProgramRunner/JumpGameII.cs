using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class JumpGameII : Runner
    {
        public class Solution
        {
            public int Jump(int[] nums)
            {
                int pos = 0;
                int des = 0;
                int jump = 0;

                for(int i = 0; i < nums.Length - 1; i++)
                {
                    des = Math.Max(des, i + nums[i]);
                    if(i == pos)
                    {
                        pos = des;
                        jump++;
                    }
                }
                return jump;
            }
        }

        public override void Run(string[] args)
        {
            var sol = new Solution();
            Debug.Assert(() => sol.Jump(new int[] { 2, 3, 1, 1, 4 }), 2);
            Debug.Assert(() => sol.Jump(new int[] { 2, 3, 0, 1, 4 }), 2);
            Debug.Assert(() => sol.Jump(new int[] { 3, 2, 1 }), 1);
        }
    }
}
