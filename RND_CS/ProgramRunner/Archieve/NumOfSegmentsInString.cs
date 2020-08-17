using System; using TinyRunner;
using System.Collections.Generic;

using System.Text;

namespace ProgramRunner
{
    [Skip]
    public class NumOfSegmentsInString : Runner
    {
        public class Solution
        {
            public int CountSegments(string s)
            {
                s = s.Trim();
                if (s == "") return 0;

                int count = 1;
                for (int i = 0; i + 1 < s.Length; i++)
                {
                    if ((s[i] == ' ' && s[i + 1] != ' '))
                    {
                        count += 1;
                    }
                }

                return count;
            }
        }
        public override void Run(string[] args)
        {
            var sol = new Solution();
            Assert(() => sol.CountSegments("Hello, my name is John"), 5);
            Assert(() => sol.CountSegments(" Hello, my name is John "), 5);
            Assert(() => sol.CountSegments(" Hello, my name is John"), 5);
            Assert(() => sol.CountSegments(" Hello, my name is John "), 5);
            Assert(() => sol.CountSegments(" Hello,"), 1);
            Assert(() => sol.CountSegments("Hello,"), 1);
        }
    }
}
