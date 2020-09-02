using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class KthLargestElementInArray : Runner
    {
        public class Solution
        {

            class TreeNode
            {

                public int val;
                public TreeNode(int val)
                {
                    this.val = val;
                }

                public TreeNode left;
                public TreeNode right;
            }

            TreeNode maxHeap = null;
            public int FindKthLargest(int[] nums, int k)
            {
                return 0;
            }
        }
        public override void Run(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
