using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class FindSecondMin : Runner
    {

        int Get2ndMin(int[] arr)
        {
            int min = int.MaxValue;
            int secondMin = int.MaxValue;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    secondMin = min;
                    min = arr[i];
                }
                else if (arr[i] < secondMin)
                {
                    secondMin = arr[i];
                }

            }

            return secondMin;
        }

        public override void Run(string[] args)
        {
            int[] arr = new int[] { 2, 8, 3, 4, 5, 7, 1 };

            Debug.Assert(() => Get2ndMin(arr), 2);
        }
    }
}
