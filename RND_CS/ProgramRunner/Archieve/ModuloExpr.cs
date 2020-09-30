using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class ModuloExpr : Runner
    {
        public override void Run(string[] args)
        {
            Debug.Assert(() => 5 % 6, 5);
            Debug.Assert(() => 6 % 5, 1);
            Debug.Assert(() => 5 % 12, 5);
            Debug.Assert(() => 5 % 5, 0);
        }
    }
}
