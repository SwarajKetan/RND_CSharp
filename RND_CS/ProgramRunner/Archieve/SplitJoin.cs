using System; using TinyRunner;
using System.Collections.Generic;
using System.Text;

namespace ProgramRunner
{
    
    using System.Linq;
    //[RunThis]
    [Skip]
    public class SplitJoin : Runner
    {
        public override void Run(string[] args)
        {
            //Debug.Assert(true == Testm(OPERATOR_NAME: "Avinash^Roshan^Singh\\Vivek^Ran", value: "Avinash^Roshan^Singh", valueWithcarets: "Avinash^Roshan^Singh"));
            //Debug.Assert(true == Testm(OPERATOR_NAME: "Avinash^Roshan^Singh", value: "Avinash^Roshan^Singh", valueWithcarets: "Avinash^Roshan^Singh"));
            //Debug.Assert(true == Testm(OPERATOR_NAME: "\\\\Avinash^Roshan^Singh", value: "Avinash^Roshan^Singh", valueWithcarets: "Avinash^Roshan^Singh"));
            //Debug.Assert(false == Testm(OPERATOR_NAME: "\\\\Avinash^Rosham^Singh", value: "Avinash^Roshan^Singh", valueWithcarets: "Avinash^Roshan^Singh"));

            //Debug.Assert(true == TestE(OPERATOR_NAME: "Avinash^Roshan^Singh\\Vivek^Ran", value: "Avinash^Roshan^Singh", valueWithcarets: "Avinash^Roshan^Singh"));
            //Debug.Assert(true == TestE(OPERATOR_NAME: "Avinash^Roshan^Singh", value: "Avinash^Roshan^Singh", valueWithcarets: "Avinash^Roshan^Singh"));
            //Debug.Assert(true == TestE(OPERATOR_NAME: "\\\\Avinash^Roshan^Singh", value: "Avinash^Roshan^Singh", valueWithcarets: "Avinash^Roshan^Singh"));
            //Debug.Assert(false == TestE(OPERATOR_NAME: "\\\\Avinash^Rosham^Singh", value: "Avinash^Roshan^Singh", valueWithcarets: "Avinash^Roshan^Singh"));
        }

        private bool Testm(string OPERATOR_NAME, string value, string valueWithcarets)
        {
            return (OPERATOR_NAME ?? "").Split('\\').Join((value ?? "").Split('\\'), x => x, y => y, (x, y) => x == y).Any()
            || (OPERATOR_NAME ?? "").Split('\\').Join((valueWithcarets ?? "").Split('\\'), x => x, y => y, (x, y) => x == y).Any();
        }

        private static bool TestE(string OPERATOR_NAME, string value, string valueWithcarets)
        {
            return (OPERATOR_NAME ?? "").Split('\\').Any(x => x == value || x==valueWithcarets);
        }
    }
}
