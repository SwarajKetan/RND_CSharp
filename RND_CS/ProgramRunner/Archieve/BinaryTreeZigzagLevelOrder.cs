using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class BinaryTreeZigzagLevelOrder : Runner
    {
        public class Solution
        {
            public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
            {
                List<IList<int>> result = new List<IList<int>>();
                if (root == null) return result;
                Stack<TreeNode> S = new Stack<TreeNode>();
                S.Push(root);

                bool zig = true;

                while (S.Count > 0)
                {
                    int count = S.Count;
                    Queue<TreeNode> q = new Queue<TreeNode>(count);
                    while (S.Count > 0)
                        q.Enqueue(S.Pop());


                    List<int> tmp = new List<int>();                    
                    while(q.Count > 0)
                    {
                        var node = q.Dequeue();
                        tmp.Add(node.val);

                        if (zig)
                        {
                            if(node.left != null)
                                S.Push(node.left);
                            if (node.right != null)
                                S.Push(node.right);
                        }
                        else
                        {
                            if (node.right != null)
                                S.Push(node.right);
                            if (node.left != null)
                                S.Push(node.left);
                        }
                    }

                    zig = !zig;
                    result.Add(tmp);
                }

                return result;

            }
        }
        public override void Run(string[] args)
        {
            var tree = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(4)
                },
                right = new TreeNode(3)
                {
                    right = new TreeNode(5)
                }
            };

            var sol = new Solution();
            var res = sol.ZigzagLevelOrder(tree);

        }
    }
}
