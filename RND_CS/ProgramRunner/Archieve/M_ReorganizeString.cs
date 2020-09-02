using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class ReorganizeString : Runner
    {
        public class Solution
        {
            public string ReorganizeString(string S)
            {
                char[] s = S.ToCharArray();

                if (S.Length <= 1) return S;
                Dictionary<char, int> map = new Dictionary<char, int>();
                for(int i = 0; i < S.Length; i++)
                {
                    if (!map.ContainsKey(S[i]))
                        map.Add(S[i], 0);
                    map[S[i]] += 1;
                }


                string res = "";
                while(map.Count >= 1)
                {

                }

                return "";

            }
        }
        public override void Run(string[] args)
        {
            var sol = new Solution();
            //Debug.Assert(() => sol.ReorganizeString("baaba"), "ababa");
            //Debug.Assert(() => sol.ReorganizeString("aab"), "aba");
            //Debug.Assert(() => sol.ReorganizeString("aaab"), "");
            Debug.Assert(() => sol.ReorganizeString("vvvlo"), "vlvov");
        }
    }
}
