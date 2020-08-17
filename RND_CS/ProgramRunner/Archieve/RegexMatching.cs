using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class RegexMatching : Runner
    {
        public class Solution
        {
            public bool IsMatch(string s, string p)
            {
                int[] arr = new int[1];
                int i = 0;
                arr[i] = ++i; // we can do

                return false;
            }
        }

        public override void Run(string[] args)
        {
            var sol = new Solution();

            Debug.Assert(() => sol.IsMatch("aa", "a"), false);
            Debug.Assert(() => sol.IsMatch("aa", "a*"), true);
            Debug.Assert(() => sol.IsMatch("aa", ".*"), true);
            Debug.Assert(() => sol.IsMatch("aab", "c*a*b"), true);
            Debug.Assert(() => sol.IsMatch("mississippi", "mis*is*p*."), false);
        }
    }
}
