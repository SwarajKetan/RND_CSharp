using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class Permutations : Runner
    {
        public class Solution
        {

            List<IList<int>> result = new List<IList<int>>();

            public IList<IList<int>> Permute(int[] nums)
            {
                solve(nums, 0, nums.Length);
                return result;
            }

            int counter = 1;
            void solve(int[] nums, int index, int length)
            {
                //Debug.PrintLine($"----------{counter++}----------------");
                if (index >= length)
                {
                    result.Add(nums);
                    return;
                }

                for (int i = index; i < length; i++)
                {
                    Debug.PrintLine($"------index = {index} i = {i}-----------");
                    //Swap(nums, i, index);
                    solve(nums, index + 1, length);
                    //Swap(nums, i, index);
                    Debug.PrintLine($"------index = {index} i = {i}-----------", ConsoleColor.Green);

                }
            }
            void Swap(int[] arr, int i, int j)
            {
                int tmp = arr[i];
                arr[i] = arr[j];
                arr[j] = tmp;
            }

            //private string Serialize(IList<int> arr)
            //{
            //   return string.Join(',', arr);
            //}

        }

        public override void Run(string[] args)
        {
            var arr = new int[] { 1, 2, 3 };
            var sol = new Solution();
            var res = sol.Permute(arr);

        }
    }
}
