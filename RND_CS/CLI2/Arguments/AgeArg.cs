using System;
using System.Collections.Generic;
using System.Text;

namespace CLI2.Arguments
{
    [Deco(Symbol ="-a")]
    public class AgeArg : Arg<int>
    {
        public AgeArg(string value) : base(value)
        {
            base.Value = Convert.ToInt32(value);
        }
    }
}
