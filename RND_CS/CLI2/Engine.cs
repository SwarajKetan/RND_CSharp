using CLI2.Arguments;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLI2
{
    public class Engine
    {
        public void Print(NameArg name, AgeArg age)
        {
            Console.WriteLine($"Name = {name.Value} Age = {age.Value}");
        }
    }
}
