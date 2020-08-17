using System; using TinyRunner;
using System.Collections.Generic;
using System.Text;

namespace ProgramRunner
{
    [Skip]
    [Info( Comment = "Pre-order binary tree traversal")]
    public class SerializeBinaryTree : Runner
    {
        Queue<int> q = new Queue<int>();
        void Serialize(TreeNode root)
        {
            if (root == null)
                return;
            if (root.left == null && root.right == null)
            {
                q.Enqueue(root.val);
                return;
            }

            Serialize(root.left);
            q.Enqueue(root.val);
            Serialize(root.right);
        }

        int[] SerializeMain(TreeNode root)
        {
            Serialize(root);
            int[] arr = new int[q.Count];
            int i = 0;
            while (q.Count > 0)
                arr[i++] = q.Dequeue();

            return arr;
        }

        public override void Run(string[] args)
        {
            TreeNode root = new TreeNode(3)
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

            Console.WriteLine();
            Assert<int>(() => SerializeMain(root), new int[] { 0, 1, 2, 3, 4, 5, 6 });
        }
    }
}
