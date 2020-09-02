using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class PrintWordsVertically : Runner
    {
        public class Solution
        {
            public IList<string> PrintVertically(string s)
            {

                string[] arr = s.Split(' ');
                PadIfRequired(arr, 0);
                List<string> res = new List<string>();
                for (int i = 0; i < maxLen; i++)
                {

                    string tmp = "";
                    for (int j = 0; j < arr.Length; j++)
                    {
                        tmp += arr[j][i];
                    }
                    res.Add(tmp.TrimEnd());
                }
                return res;

            }

            int maxLen = 0;
            void PadIfRequired(string[] arr, int i)
            {
                if (i == arr.Length)
                    return;

                if (arr[i].Length > maxLen)
                    maxLen = arr[i].Length;

                PadIfRequired(arr, i + 1);
                arr[i] = arr[i].PadRight(maxLen, ' ');
            }
        }

        public override void Run(string[] args)
        {
            var sol = new Solution();
            var ers =  sol.PrintVertically("TO BE OR NOT TO BE");
        }
    }
}
