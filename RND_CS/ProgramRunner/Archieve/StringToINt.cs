using System; using TinyRunner;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgramRunner
{
    [Skip]
    [Info(ProblemLink = "https://leetcode.com/problems/string-to-integer-atoi/submissions/")]
    public class StringToInt : Runner
    {
        public class Solution
        {
            HashSet<char> signs = new HashSet<char>() { '-', '+' };
            public int MyAtoi(string str)
            {
                List<char> dq = new List<char>();
                for (int i = 0; i < str.Length; i++)
                {
                    if (dq.Count > 0)
                    {
                        if (!IsNumeric(str[i]))
                            break;

                        dq.Add(str[i]);
                    }
                    else
                    {
                        if (str[i] == ' ')
                            continue;
                        if (signs.Contains(str[i]) || IsNumeric(str[i]))
                            dq.Add(str[i]);
                        else
                            break;
                    }
                }

                bool negative = dq.Count > 0 && dq[0] == '-';
                double num = 0;
                int j = 0;
                while (j < dq.Count)
                {
                    char c = dq[j++];
                    if (signs.Contains(c))
                        continue;
                    num += (c - 48) * Math.Pow(10, dq.Count - j);
                }
                if (negative)
                    num = -num;

                return num > int.MaxValue ? int.MaxValue : (num < int.MinValue) ? int.MinValue : (int)num;
            }
            bool IsNumeric(char c)
            {
                return 48 <= c && c <= 57;
            }
        }
        public override void Run(string[] args)
        {
            var sol = new Solution();
            Debug.Assert(() => sol.MyAtoi("42"), 42);
            Debug.Assert(() => sol.MyAtoi("     -42"), -42);
            Debug.Assert(() => sol.MyAtoi("4193 with words"), 4193);
            Debug.Assert(() => sol.MyAtoi("words and 987"), 0);
            Debug.Assert(() => sol.MyAtoi("+10"), 10);
            Debug.Assert(() => sol.MyAtoi("-10"), -10);
            Debug.Assert(() => sol.MyAtoi("+-2"), 0);
            Debug.Assert(() => sol.MyAtoi("+2-+56"), 2);
            Debug.Assert(() => sol.MyAtoi("  -0012a42"), -12);
            Debug.Assert(() => sol.MyAtoi("20000000000000000000"), int.MaxValue);

        }
    }
}

