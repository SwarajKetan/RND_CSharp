using System;
using System.Collections.Generic;
using System.Text;

namespace CLI2
{
    public abstract class Arg<T>
    {
        public Arg(string value)
        {
        }
        public T Value { get; protected set; }
    }
}
