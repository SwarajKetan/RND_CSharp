using System; using TinyRunner;
using System.Collections.Generic;

using System.Text;

namespace ProgramRunner
{
    [Skip]
    public class EditDistance : Runner
    {
        public class Solution
        {
            public int MinDistance(string word1, string word2)
            {

                int[,] arr = new int[word1.Length+1, word2.Length+1];

                for (int r = 0; r <= word1.Length; r++)
                {
                    for (int c = 0; c <= word2.Length; c++)
                    {
                        if (r == 0)
                        {
                            arr[0, c] = c;
                            continue;
                        }

                        if (c == 0)
                        {
                            arr[r, 0] = r;
                            continue;
                        }

                        arr[r, c] = (word1[r-1] == word2[c-1]) ? arr[r - 1, c - 1] : Min(arr[r - 1, c], arr[r, c - 1], arr[r - 1, c - 1]) + 1;

                    }
                }

                return arr[word1.Length, word2.Length];
            }

            int Min(int a, int b, int c)
            {
                return Math.Min(Math.Min(a, b), c);
            }
        }

        public override void Run(string[] args)
        {
            Solution s = new Solution();
            Debug.Assert(()=> s.MinDistance("ros", "horse") , 3);
        }
    }
}
