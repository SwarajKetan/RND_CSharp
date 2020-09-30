using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class QuickSortProgram : Runner
    {
        void QuickSort(int[] arr, int start, int end)
        {
            if(start < end)
            {
                int partitionIndex = Partition(arr, start, end);
                QuickSort(arr, start, partitionIndex - 1);
                QuickSort(arr, partitionIndex + 1, end);
            }
        }

        int Partition(int[] arr, int start, int end)
        {
            int pivot = arr[end];
            int pIndex = start; // partition index
            // anything lesser than the pivot to be placed on the left of the pIndex and anything
            // greater than the pivot to be placed on the right of the pIndex
            for(int i = start; i < end; i++)
            {
                if(arr[i] <= pivot)
                {
                    // swap
                    int tmp = arr[pIndex];
                    arr[pIndex] = arr[i];
                    arr[i] = tmp;

                    pIndex++;
                }
            }

            // swap between pivot and the partition index
            arr[end] = arr[pIndex];
            arr[pIndex] = pivot;

            return pIndex;
        }

        public override void Run(string[] args)
        {
            int[] arr = new int[] { 6, 8, 3, 4, 5, 7, 1, 2 };
            QuickSort(arr, 0, arr.Length - 1);
        }
    }
}
