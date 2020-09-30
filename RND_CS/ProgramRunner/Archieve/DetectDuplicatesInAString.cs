using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    [Info("Bitmasking")]
    public class DetectDuplicatesInAString : Runner
    {
        bool HasDuplicate(string s)
        {
            int flag = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int index = s[i] - 'a';
                int mask = 1 << index;
                if ((flag & mask) > 0)
                {
                    return false;
                }

                flag = flag | mask;

            }

            return true;
        }
        public override void Run(string[] args)
        {
            Debug.Assert(() => HasDuplicate("acba"), true);
        }
    }
}
