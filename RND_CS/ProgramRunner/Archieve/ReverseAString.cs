using System; using TinyRunner;
using System.Collections.Generic;
using System.Text;

namespace ProgramRunner
{
    [Skip]
    public class ReverseAString : Runner
    {
        public override void Run(string[] args)
        {
            char[] input = "Hi Swaraj".ToCharArray();
            //ReversePrint(input, 0);
            //var ret = ReverseReturn(input, 0);
            //Console.WriteLine($"\n{ret}");
            ReverseModify(input, 0);
        }

        void ReversePrint(string input, int i)
        {
            if (i == input.Length)
                return;

            ReversePrint(input, i + 1);
            Console.Write(input[i]);
        }

        string ReverseReturn(string input, int i)
        {
            if (i == input.Length)
                return "";

            return ReverseReturn(input, i + 1) + input[i];
        }

        void ReverseModify(char[] input, int i)
        {
            if (i == input.Length)
                return;

            char c = input[i];
            ReverseModify(input, i + 1);
            input[input.Length - i - 1] = c;
        }
    }
}
