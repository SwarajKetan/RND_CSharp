using System;
using System.Collections.Generic;
using System.Text;

namespace CLI2.Arguments
{
    [Deco(Symbol = "-h")]
    public class HeightArg : Arg<Height>
    {
        public HeightArg(string value) : base(value)
        {
            this.Value = (Height)Convert.ToInt32(value);
        }
    }
}
