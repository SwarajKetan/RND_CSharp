using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class HeapSortDemo : Runner
    {
        public override void Run(string[] args)
        {
            int[] arr = { 55, 25, 89, 34, 12, 19, 78, 95, 1, 100 };
            int n = 10, i;
            Console.WriteLine("Heap Sort");
            Console.Write("Initial array is: ");
            for (i = 0; i < n; i++)
            {
                Console.Write(arr[i] + " ");
            }
           new example().heapSort(arr, 10);
            Console.Write("\nSorted Array is: ");
            for (i = 0; i < n; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }

        public class example
        {
            public void heapSort(int[] arr, int n)
            {
                for (int i = n / 2 - 1; i >= 0; i--)
                    heapify(arr, n, i);

                Print(arr);
                for (int i = n - 1; i >= 0; i--)
                {
                    int temp = arr[0];
                    arr[0] = arr[i];
                    arr[i] = temp;
                    heapify(arr, i, 0);
                    Print(arr);
                }
            }
            void heapify(int[] arr, int n, int i)
            {
                int largest = i;
                int left = 2 * i + 1;
                int right = 2 * i + 2;
                if (left < n && arr[left] > arr[largest])
                    largest = left;
                if (right < n && arr[right] > arr[largest])
                    largest = right;
                if (largest != i)
                {
                    int swap = arr[i];
                    arr[i] = arr[largest];
                    arr[largest] = swap;
                    heapify(arr, n, largest);
                }
            }

            void Print(int[] arr)
            {
                Console.WriteLine("\n");
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.Write(arr[i] + " ");
                }
                
            }
           
        }
    }
}
