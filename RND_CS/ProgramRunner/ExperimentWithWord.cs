using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class ExperimentWithWord : TinyRunner.Runner
    {
        public override void Run(string[] args)
        {
            string s1 = "hot";
            string s2 = "hit";
            int change = 0;
            for(int i = 0; i < s1.Length && change <= 1; i++)
            {
                change += s1[i] != s2[i] ? 1 : 0;
            }

            Debug.Assert(() => change, 1);
        }
    }
}
