using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class DeleteNodesAndReturnForest : Runner
    {

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public class Solution
        {

            List<TreeNode> forest = new List<TreeNode>();
            HashSet<int> set = new HashSet<int>();

            public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete)
            {
                for (int i = 0; i < to_delete.Length; i++)
                    set.Add(to_delete[i]);

                TreeNode final = dfs(root);
                if (final != null)
                {
                    if (!set.Contains(final.val))
                        forest.Add(final);
                    else
                    {
                        if (final.left != null) forest.Add(final.left);
                        if (final.right != null) forest.Add(final.right);
                    }
                }
                return forest;
            }

            TreeNode dfs(TreeNode root)
            {
                if (root == null) return null;
                if (root.left == null && root.right == null) 
                    return root;

                if (root.left != null)
                {
                    TreeNode left = dfs(root.left);
                    if (set.Contains(left.val))
                    {
                        if (left.left != null) forest.Add(left.left);
                        if (left.right != null) forest.Add(left.right);
                        root.left = null;
                    }
                }

                if(root.right != null)
                {
                    TreeNode right = dfs(root.right);
                    if (set.Contains(right.val))
                    {
                        if(right.left!= null) forest.Add(right.left);
                        if(right.right != null) forest.Add(right.right);
                        root.right = null;
                    }
                }
                return root;
            }
        }


        public override void Run(string[] args)
        {
            var sol = new Solution();
            TreeNode tn = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(4),
                    right = new TreeNode(5)
                },
                right = new TreeNode(3)
                {
                    left = new TreeNode(6),
                    right = new TreeNode(7)
                }
            };


            TreeNode n2 = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(4),
                    right = new TreeNode(3)
                }
            };

            var res = sol.DelNodes(tn, new int[] { 3, 5 });
        }
    }
}
