using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class PartitionArrayIntoThreePartsEqualSum : Runner
    {
        public class Solution
        {
            public bool CanThreePartsEqualSum(int[] A)
            {
                if (A.Length < 3) return false;
                Traverse(A, 0);
                return can && tmp == 0 && count >= 3;
            }

            int sum = 0;
            int partSum = 0;
            int tmp = 0;
            int count = 0;
            bool can = true;
            void Traverse(int[] arr, int i)
            {
                if (i == arr.Length)
                {
                    partSum = sum / 3;
                    can = sum % 3 == 0;
                    return;
                }
                sum += arr[i];
                Traverse(arr, i + 1);
                if (can)
                {
                    tmp += arr[i];
                    if (tmp == partSum)
                    {
                        tmp = 0;
                        count += 1;
                    } 
                }
            }

            public void Reset()
            {
                sum = 0;
                partSum = 0;
                tmp = 0;
                count = 0;
                can = true;
            }
        }
        public override void Run(string[] args)
        {
            var sol = new Solution();
            //Debug.Assert(() => sol.CanThreePartsEqualSum(new int[] { 0, 2, 1, -6, 6, -7, 9, 1, 2, 0, 1 }), true, tearDown: () => sol.Reset());
            //Debug.Assert(() => sol.CanThreePartsEqualSum(new int[] { 10, -10, 10, -10, 10, -10, 10, -10 }), true, tearDown: ()=> sol.Reset());
            Debug.Assert(() => sol.CanThreePartsEqualSum(new int[] { 1, -1, 1, -1 }), false, tearDown: () => sol.Reset());
        }
    }
}
