using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    /// <summary>
    /// KMP Prefix table implementatioin
    /// </summary>
   [Skip]
    public class ShortestPalindrome : Runner
    {
        public class Solution
        {
            public string ShortestPalindrome(string s)
            {
                int[] pi = new int[s.Length];

                int k = 0;
                int maxIndex = 0;
                int maxval = 0;
                pi[0] = 0;
                for(int i = 1; i < s.Length; i++)
                {
                    if(s[i] != s[k])
                    {
                        pi[i] = 0;
                        k = 0;
                    }
                    else
                    {
                        pi[i] = pi[i - 1] + 1;
                        k += 1;
                        if(pi[i] > maxval && i + 1 != s.Length)
                        {
                            maxval = pi[i];
                            maxIndex = i;
                        }
                    }
                }
                
                string revfragment = "";
                for (int j = s.Length -1; j > maxIndex; j--)
                {
                    revfragment += s[j];
                }
                return revfragment + s;
            }

        }

        public override void Run(string[] args)
        {
            var sol = new Solution();
            Debug.Assert(() => sol.ShortestPalindrome("aacecaaa"), "aaacecaaa");
            Debug.Assert(() => sol.ShortestPalindrome("abcd"), "dcbabcd");
            Debug.Assert(() => sol.ShortestPalindrome("adcba"), "abcdadcba");
        }
    }
}
