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

            void solve(int[] nums, int index, int length)
            {
                if (index >= length)
                {
                    result.Add(nums);
                    return;
                }

                for (int i = index; i < length; i++)
                {
                    Swap(nums, i, index);
                    solve(nums, index + 1, length);
                    Swap(nums, i, index);

                }
            }

            //public IList<IList<int>> Permute(int[] nums)
            //{
            //    for (int i = 0; i < nums.Length; i++)
            //    {
            //        Swap(nums, 0, i);
            //        var k = GetCom(nums, 0);
            //        Swap(nums, 0, i);
            //        foreach (var itm in k)
            //        {
            //            Console.WriteLine($"{string.Join(',', itm)}");
            //            result.Add(itm);
            //        }

            //    }
            //    return result;
            //}

            //List<IList<int>> GetCom(int[] nums, int index)
            //{
            //    if(index == nums.Length - 1)
            //        return new List<IList<int>>() { new int[] { nums[index] } };

            //    var combos = GetCom(nums, index + 1);
            //    var tmp = new List<IList<int>>();
            //    foreach(var com in combos)
            //    {
            //        tmp.Add(Merge(new int[] { nums[index] }, com.ToArray()));
            //        tmp.Add(Merge(com.ToArray(), new int[] { nums[index] }));
            //    }
            //    return tmp;
            //}

            //List<int> Merge(int[] left,int[] right)
            //{
            //    var res = new List<int>(left);
            //    foreach (var n in right)
            //        res.Add(n);
            //    return res;                
            //}

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
