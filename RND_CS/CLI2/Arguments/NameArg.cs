using System;
using System.Collections.Generic;
using System.Text;

namespace CLI2.Arguments
{
    [Deco(Symbol = "-n")]
    public class NameArg : Arg<string>
    {
        public NameArg(string value) : base(value)
        {
            this.Value = value;
        }
    }
}
