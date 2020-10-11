using System;
using System.Collections.Generic;
using System.Text;

namespace TinyRunner
{
    public sealed class ArgAttribute : Attribute
    {
        private string[] _args;
        public ArgAttribute(params string[] args)
        {
            _args = args;
        }


    }
}
