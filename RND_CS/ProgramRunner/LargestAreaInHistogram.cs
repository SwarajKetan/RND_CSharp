using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class LargestAreaInHistogram : Runner
    {
        public class Solution
        {
            public int LargestRectangleArea(int[] arr)
            {
                int size = arr.Length;
                if (size == 0) return 0;
                if (size == 1) return arr[0];

                int maxarea = int.MinValue;
                Stack<int> s = new Stack<int>(); // index
                int i = 0;
                while (i < size)
                {
                    if (s.Count == 0 || arr[i] >= arr[s.Peek()])
                    {
                        s.Push(i++);
                    }
                    else
                    {
                        int top = s.Pop();

                        int toparea = arr[top] * (s.Count == 0 ? i : (i - s.Peek() - 1));
                        maxarea = Math.Max(maxarea, toparea);
                    }
                }

                while(s.Count > 0)
                {
                    int index = s.Pop();
                    int len = s.Count == 0 ? -1 : s.Peek();
                    maxarea = Math.Max(maxarea, arr[index] * (i - len - 1));
                }

                return maxarea;
            }
        }
        public override void Run(string[] args)
        {
            Debug.Assert(() => new Solution().LargestRectangleArea(new int[] { 2, 1, 5, 6, 2, 3 }), 10);
        }
    }
}
