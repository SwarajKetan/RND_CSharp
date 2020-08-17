using System; using TinyRunner;
using System.Collections.Generic;
using System.Text;

namespace ProgramRunner
{
    [Skip]
    public class CopyListWithRandomPointer : Runner
    {
        public class Node
        {
            public int val;
            public Node next;
            public Node random;
            public Node(int _val)
            {
                val = _val;
                next = null;
                random = null;
            }
        }

        public class Solution
        {

            Dictionary<Node, Node> kvps = new Dictionary<Node, Node>();
            public Node CopyRandomList(Node head)
            {
                if (head == null)
                    return null;

                Node nn = new Node(head.val);
                kvps.Add(head, nn);
                nn.next = CopyRandomList(head.next);

                if (head.random != null)
                    nn.random = kvps[head.random];

                return nn;
            }
        }

        public override void Run(string[] args)
        {
            Node n1 = new Node(1);
            Node n2 = new Node(2);
            n1.next = n2;
            n2.random = n1;
            n1.random = n1;

            var sol = new Solution();
            var res = sol.CopyRandomList(n1);
        }
    }
}
