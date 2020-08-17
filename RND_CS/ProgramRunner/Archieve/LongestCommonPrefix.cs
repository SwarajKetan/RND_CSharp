using System; using TinyRunner;
using System.Collections.Generic;
using System.Text;

namespace ProgramRunner
{
    [Skip]
    [Info( ProblemLink = "https://leetcode.com/problems/longest-common-prefix/")]
    public class LongestCommonPrefix : Runner
    {
        public class Solution
        {
            public string LongestCommonPrefix(string[] strs)
            {
                int indx = -1;
                int nos = strs.Length;
                if (nos == 0) return "";
                if (nos == 1) return strs[0];

                while (true)
                {
                    int i = 0;
                    int cur = indx + 1;
                    while (i + 1 < nos && cur < strs[i].Length && cur < strs[i + 1].Length && strs[i][cur] == strs[i + 1][cur])
                        i++;
                    if (i + 1 == nos)
                        indx++;
                    else
                        break;
                }
                return strs[0].Substring(0, indx + 1);

            }
        }

        public override void Run(string[] args)
        {
            var sol = new Solution();
            Assert(() => sol.LongestCommonPrefix(new string[] { "flower", "flow", "flight" }), "fl");
            Assert(() => sol.LongestCommonPrefix(new string[] { "" }), "");
            Assert(() => sol.LongestCommonPrefix(new string[] { "ab" }), "ab");
        }
    }
}
