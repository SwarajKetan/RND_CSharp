using System; using TinyRunner;
using System.Collections.Generic;

using System.Text;

namespace ProgramRunner
{
    [Skip]
    //[RunThis]
    public class ReverseVowels : Runner
    {
        public class Solution
        {
            public string ReverseVowels(string s)
            {
                var re = RV(s, 0);
                return re;
            }

            Queue<char> vq = new Queue<char>();
            HashSet<char> vowels = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            string RV(string s, int i)
            {
                if (i >= s.Length)
                    return "";
                if (vowels.Contains(s[i]))
                    vq.Enqueue(s[i]);
                var r = RV(s, i + 1);                
                if (vowels.Contains(s[i]))
                    return vq.Dequeue() + r;
                return s[i] + r; 
            }
        }

        public override void Run(string[] args)
        {
            var sol = new Solution();

            string res1 = sol.ReverseVowels("hello");
            string res2 = sol.ReverseVowels("leetcode");

            Debug.Assert(()=> sol.ReverseVowels("hello") , "holle");
            Debug.Assert(()=> sol.ReverseVowels("leetcode") , "leotcede");
        }
    }
}
