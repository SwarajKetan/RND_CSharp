using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class GenerateCombinations : Runner
    {
        public void Generate(int[] nums)
        {
            int len = nums.Length;
            Print(len, nums, 0, new List<int>());
        }

        void Print(int len, int[] nums, int start, List<int> combi)
        {
            if(start == len)
            {
                foreach (var n in combi)
                    Console.Write($"{n}, ");
                Console.WriteLine();
                return;
            }

            for(int i = start; i < len; i++)
            {
                combi.Add(nums[i]);
                Print(len, nums, i + 1, combi);
                combi.RemoveAt(combi.Count -1);
            }
        }

        public override void Run(string[] args)
        {
            Generate(new int[] { 1,2,3 });
        }
    }
}
