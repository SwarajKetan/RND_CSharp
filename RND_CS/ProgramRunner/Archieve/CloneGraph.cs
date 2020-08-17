using System; using TinyRunner;
using System.Collections.Generic;

using System.Net.NetworkInformation;
using System.Text;

namespace ProgramRunner
{
    [Skip]
    public class CloneGraph : Runner
    {
        public class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node()
            {
                val = 0;
                neighbors = new List<Node>();
            }

            public Node(int _val)
            {
                val = _val;
                neighbors = new List<Node>();
            }

            public Node(int _val, List<Node> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }

        public class Solution
        {
            Dictionary<int, Node> d = new Dictionary<int, Node>();
            public Node CloneGraph(Node node)
            {
                if (node == null)
                    return null;

                if (d.ContainsKey(node.val))
                    return d[node.val];

                Node nnode = new Node(node.val);
                d.Add(node.val, nnode);
                foreach (var nb in node.neighbors)
                {
                    var cg = CloneGraph(nb);
                    if (cg != null)
                        nnode.neighbors.Add(cg);
                }
                return nnode;
            }
        }

        public override void Run(string[] args)
        {
            var n = new Node(2);
            n.neighbors.Add(new Node(3));
            var x = new Node(4);
            x.neighbors.Add(n);
            n.neighbors.Add(x);

            Solution s = new Solution();
            var r = s.CloneGraph(n);
            //Debug.Assert(r.val , n.val);
            //Debug.Assert(r.neighbors[0].val , n.neighbors[0].val);
            //Debug.Assert(r.neighbors[1].val == n.neighbors[1].val);
        }
    }
}
