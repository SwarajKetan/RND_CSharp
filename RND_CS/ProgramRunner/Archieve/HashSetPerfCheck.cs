using System; using TinyRunner;
using System.Collections.Generic;
using System.Text;

namespace ProgramRunner
{
    [Skip]
    public class HashSetPerfCheck : Runner
    {
        public override void Run(string[] args)
        {
            Span<string> vals = new Span<string>();
            //vals.

            HashSet<string> hs = new HashSet<string>();

            try
            {
                hs.Add("abc");
                hs.Add("b");
                hs.Add("c");
                hs.Add("b");

                if (hs.Contains("k"))
                {

                }
            }
            catch (Exception ex)
            {

                throw;
            }


            //throw new NotImplementedException();
        }
    }
}
