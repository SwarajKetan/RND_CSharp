using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class Jagged_vs_MultiDimen : TinyRunner.Runner
    {
        public override void Run(string[] args)
        {
            int[,]  a = new int[4, 5];

            Console.WriteLine($"Length {a.Length}");
            Console.WriteLine($"Rank {a.Rank}");
            Console.WriteLine($"Rows {a.GetLength(0)}");
            Console.WriteLine($"Columns {a.GetLength(1)}");

        }
    }
}
