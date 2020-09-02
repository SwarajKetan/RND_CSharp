using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class FindCommonCharacters : Runner
    {
        public class Solution
        {
            public IList<string> CommonChars(string[] A)
            {

                var map = new Dictionary<int, Dictionary<char, int>>();

                for (int w = 0; w < A.Length; w++)
                {

                    var xmap = new Dictionary<char, int>();
                    for (int c = 0; c < A[w].Length; c++)
                    {

                        if (!xmap.ContainsKey(A[w][c]))
                        {
                            xmap.Add(A[w][c], 0);
                        }
                        xmap[A[w][c]] += 1;
                    }
                    map.Add(w, xmap);
                }

                List<string> result = new List<string>();
                foreach (var d in map[0])
                {

                    char c = d.Key;
                    int mv = d.Value;
                    for (int i = 1; i < map.Count; i++)
                    {
                        if (!map[i].ContainsKey(c))
                        {
                            mv = 0;
                            break;
                        }
                        mv = Math.Min(map[i][c], mv);
                    }

                    while (mv > 0)
                    {
                        result.Add(c.ToString());
                        mv--;
                    }
                }

                return result;
            }
        }

        public override void Run(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
