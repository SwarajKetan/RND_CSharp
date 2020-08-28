using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class KthSmallestElementInBst : Runner
    {
        public class Solution
        {
            public int KthSmallest(TreeNode root, int k)
            {
                Traverse(root);
                while(k > 1)
                {
                    Q.Dequeue();
                    k--;
                }
                return Q.Dequeue();
            }

            Queue<int> Q = new Queue<int>();
            void Traverse(TreeNode root)
            {
                if(root == null) return; 

                if (root.left == null && root.right == null)
                {
                    Q.Enqueue(root.val);
                    return;
                }

                Traverse(root.left);
                Q.Enqueue(root.val);
                Traverse(root.right);
            }

        }

        public override void Run(string[] args)
        {
            var tree = new TreeNode(5)
            {
                left = new TreeNode(3)
                {
                    left = new TreeNode(2)
                    {
                        left = new TreeNode(1)
                    },
                    right = new TreeNode(4)
                },
                right = new TreeNode(6)
            };

            var sol = new Solution();

            Debug.Assert(() => sol.KthSmallest(tree, 3), 3);
        }
    }
}
