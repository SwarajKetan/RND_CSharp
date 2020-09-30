using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class QuickSort : Runner
    {
        int Get_nth_min(int[] nums, int n)
        {
            int nthmin = n;// 
            int pIndex = 0;
            int pivot = nums[nums.Length - 1];

            for(int i = pIndex; i < nums.Length; i++)
            {
                if(nums[i] <= pivot)
                {
                    int tmp = nums[pIndex];
                    nums[pIndex] = nums[i];
                    nums[i] = tmp;
                    pIndex++;
                }

                if (pIndex == nthmin - 1)
                    break;
            }
            return nums[pIndex];
        }

        public override void Run(string[] args)
        {
            int[] arr = new int[] { 20, 56, 2, 7, 9, 6, 1, 4 };
            Debug.Assert(() => Get_nth_min(arr, 3), 2);
        }
    }
}
