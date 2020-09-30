using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class MaxProduct : Runner
    {
        public override void Run(string[] args)
        {
            //string ccd = "I m ssks";
            //bool r = ccd.StartsWith("i");
            //Boolean B = ccd.StartsWith("i"); ;

            var sol = new Solution();
            string[] arr = new string[] { "abc", "a", "b", "" };
            Debug.Assert(() => sol.maxProduct(arr), 1);
        }

        class Solution
        {
           public int maxProduct(string[] words)
            {
                if (words == null || words.Length == 0)
                    return 0;
                int len = words.Length;
                int[] value = new int[len];
                for (int i = 0; i < len; i++)
                {
                    string word = words[i];
                    value[i] = 0;
                    foreach (char c in word) 
                        value[i] |= 1 << (c - 'a');
                }
                int maxProduct = 0;
                for (int i = 0; i < len; i++)
                {
                    for (int j = i + 1; j < len; j++)
                    {
                        if ((value[i] & value[j]) == 0)
                            maxProduct = Math.Max(maxProduct, words[i].Length * words[j].Length);
                    }
                }
                return maxProduct;
            }

            bool doShare(string a, string b)
            {

                int[] aux = new int[26];// = new int[26];

                for (int i = 0; i < a.Length; i++)
                {
                    aux[a[i] - 'a'] = 1;
                }

                for (int i = 0; i < b.Length; i++)
                {
                    if (aux[b[i] - 'a'] == 1)
                        return true;
                }
                return false;
            }
        };
    }
}
