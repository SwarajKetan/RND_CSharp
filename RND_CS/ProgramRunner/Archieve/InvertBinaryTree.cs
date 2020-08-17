using System; using TinyRunner;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgramRunner
{
    [Skip]
    [Info]
    public class InvertBinaryTree : Runner
    {
        TreeNode Invert(TreeNode root)
        {
            if (root == null)
                return null;

            TreeNode tmp = root.left;
            root.left = Invert(root.right);
            root.right = Invert(tmp);
            return root;

        }

        public override void Run(string[] args)
        {
            TreeNode btree = new TreeNode(3)
            {
                left = new TreeNode(1)
                {
                    left = new TreeNode(0),
                    right = new TreeNode(2)
                },
                right = new TreeNode(5)
                {
                    left = new TreeNode(4),
                    right = new TreeNode(6)
                }
            };

            var res = Invert(btree);
        }
    }
}
