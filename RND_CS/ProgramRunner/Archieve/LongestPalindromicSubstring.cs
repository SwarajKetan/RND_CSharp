using System; using TinyRunner;
using System.Collections.Generic;
using System.Text;

namespace ProgramRunner
{
    [Skip]
    [Info(Comment = "https://www.youtube.com/watch?v=UflHuQj6MVA")]
    public class LongestPalindromicSubstring : Runner
    {
        public class Solution
        {
            public string LongestPalindrome(string s)
            {
                if (s.Length <= 1)
                    return s;

                int[,] dp = new int[s.Length, s.Length];
                int[] mr = new int[2] { 0, 0 };

                int i = 0, j = 0, jStart = 0;

                while (jStart < s.Length)
                {
                    i = 0;
                    j = jStart;
                    while (j < s.Length)
                    {
                        if (s[i] == s[j] && ((i + 1 >= j - 1) || (dp[i + 1, j - 1] == 1)))
                        {
                            dp[i, j] = 1;
                            mr[0] = i;
                            mr[1] = j;
                        }
                        i++;
                        j++;
                    }
                    jStart++;
                }

                return s.Substring(mr[0], mr[1] - mr[0] + 1);
            }
        }

        public override void Run(string[] args)
        {
            var sol = new Solution();
            Assert<string>(() => sol.LongestPalindrome("babad"), "aba");
            Assert<string>(() => sol.LongestPalindrome("a"), "a");
            Assert<string>(() => sol.LongestPalindrome("cbbd"), "bb");
            Assert<string>(() => sol.LongestPalindrome(""), "");
            Assert<string>(() => sol.LongestPalindrome("x"), "x");
        }
    }
}
