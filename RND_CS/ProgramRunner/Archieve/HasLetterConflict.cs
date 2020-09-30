using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class HasLetterConflict : Runner
    {
        bool Has(string a, string b)
        {
            int[] aux  = new int[26];// = new int[26];

            for (int i = 0; i < a.Length; i++)
            {
                aux[a[i] - 'a'] = 1;
            }

            for (int i = 0; i < b.Length; i++)
            {
                if (aux[b[i] - 'a'] == 1)
                    return true;
            }
            return false;
        }
        public override void Run(string[] args)
        {
            Debug.Assert(() => Has("a", "b"), false);
            Debug.Assert(() => Has("abcdrth", "kjyti"), true);
            Debug.Assert(() => Has("abgt", "bjug"), true);
            Debug.Assert(() => Has("abcdrth", "kjyi"), false);
        }
    }
}
