using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace ProgramRunner
{
    [Skip]
    [Info("N-ary tree")]
    public class AsyncBinaryTree : Runner
    {
        class Node
        {
            public Node(int v) { Val = v; }
            public int Val;
            public Node[] Children;
        }

        class Solution
        {
            public ConcurrentBag<int> Result = new ConcurrentBag<int>();
            public void GetLeafAsync(Node node)
            {
                if (node.Children == null || node.Children.Length == 0)
                {
                    Result.Add(node.Val);
                    return;
                }
                Parallel.ForEach(node.Children, (n) => GetLeafAsync(n));
            }
        }

        public override void Run(string[] args)
        {
            var inp = new Node(1)
            {
                Children = new Node[]
                {
                    new Node(2), 
                    new Node(5)
                    {
                        Children = new Node[]
                        {
                            new Node(8),
                            new Node(19)
                        }
                    }
                }
            };

            var sol = new Solution();
            sol.GetLeafAsync(inp);

            foreach (var r in sol.Result)
                Console.Write($"{r}, ");

        }
    }
}
