using System; using TinyRunner;
using System.Collections.Generic;

using System.Text;

namespace ProgramRunner
{
    //[RunThis]
    [Skip]
    public class LongestValidParenthesis : Runner
    {
        public override void Run(string[] args)
        {
            //throw new NotImplementedException();
            int r = 0;
            //Debug.Assert(2 == LVP("()"));
            //Debug.Assert(2 == LVP("())"));
            //Debug.Assert(2 == LVP("(()"));
            //Debug.Assert(4 == LVP("()()"));
            //Debug.Assert(4 == (r = LVP(")()())")), $"Expected 4 actual {r}");
            //Debug.Assert(0 == LVP(")"));
            //Debug.Assert(0 == LVP("("));
            //Debug.Assert(0 == LVP(""));
            //Debug.Assert(2 == LVP("()(()"));
            //Debug.Assert(6 == LVP("(())()"));
            //Debug.Assert(6 == LVP("()()()"));
            //Debug.Assert(8 == (r = LVP("()(()())")), $"Expected : {8} Actual : {r}");
            //Debug.Assert(4 == (r = LVP("(((()(()()")), $"Expected : {4} Actual : {r}");
            //Debug.Assert(6 == (r = LVP("(((()()()")), $"Expected : {6} Actual : {r}");
        }

        int LVP(string s)
        {
            var st = new Stack<int>();
            int max = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                    st.Push(i);
                else
                {
                    if(st.Count > 0)
                    {
                        int index = st.Pop();
                        if(s[index] == '(')
                        {
                            // calculate current max
                            int cmax = st.Count == 0 ? i + 1 : (i - st.Peek());
                            max = Math.Max(max, cmax);
                            continue;
                        }
                    }
                    st.Push(i);
                }
            }

            return max;
        }

    }
}
