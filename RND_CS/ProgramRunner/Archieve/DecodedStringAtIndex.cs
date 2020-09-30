using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class DecodedStringAtIndex : Runner
    {
        public class Solution
        {
            public string DecodeAtIndex(string S, int K)
            {
                long size = 0;
                int N = S.Length;

                for (int i = 0; i < N; ++i)
                {
                    if (char.IsDigit(S[i]))
                        size *= S[i] - '0';
                    else
                        size++;
                }

                for (int i = N - 1; i >= 0; --i)
                {
                    K = (int)(K % size);
                    if (K == 0 && char.IsLetter(S[i]))
                        return (string)"" + S[i];

                    if (char.IsDigit(S[i]))
                        size /= S[i] - '0';
                    else
                        size--;
                }
                return S.Substring(K, 1);
            }
        }
        public override void Run(string[] args)
        {
            var sol = new Solution();
            Debug.Assert(() => sol.DecodeAtIndex("leet2code3", 10), "o");
            Debug.Assert(() => sol.DecodeAtIndex("ha22", 5), "h");
        }
    }
}
