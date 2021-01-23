using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class Alok01 : Runner
    {
        private int GetDigitSum(int num)
        {
            return num < 10 ? num : num % 10 +  GetDigitSum(num / 10);
        }

        public int GetNext(int num)
        {
            int numsum = GetDigitSum(num);
            for (int i = num + 1; i < 500001; i++)
            {
                if (GetDigitSum(i) == numsum)
                    return i;
            }
            return -1;
        }

        public int GetPairSum(int[] A)
        {
            int[] num_sum = new int[A.Length];
            for(int i = 0; i < A.Length; i++)
                num_sum[i] = GetDigitSum(A[i]);

            int max = -1;
            for(int i = 0; i < A.Length; i++)
            {
                for(int j = i + 1; j < A.Length; j++)
                {
                    if(num_sum[i] == num_sum[j])
                    {
                        max = Math.Max(max, A[i] + A[j]);
                    }
                }
            }
            return max;

        }

        public override void Run(string[] args)
        {
            Debug.Assert(() => GetPairSum(new int[] { 42, 33, 60 }), 102);
            Debug.Assert(() => GetPairSum(new int[] { 42, 33, 60 }), 103);
        }
    }
}
