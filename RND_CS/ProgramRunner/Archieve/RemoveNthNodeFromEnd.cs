using System; using TinyRunner;
using System.Collections.Generic;
using System.Text;

namespace ProgramRunner
{
    [Skip]
    public class RemoveNthNodeFromEnd : Runner
    {

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public class Solution
        {
            int c = 0;
            public ListNode RemoveNthFromEnd(ListNode head, int n)
            {
                return RemoveNthFromEndInternal(ref head, n);
            }

            public ListNode RemoveNthFromEndInternal(ref ListNode head, int n)
            {
                if (head == null)
                    return head;

                RemoveNthFromEndInternal(ref head.next, n);
                c++;
                if (n == c)
                    head = head.next;
                return head;
            }
        }

        public override void Run(string[] args)
        {
            var input = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(3)
                    {
                        next = new ListNode(4)
                        {
                            next = new ListNode(5)
                        }
                    }
                }
            };

            var r = new Solution().RemoveNthFromEnd(input, 2);
            var r2 = new Solution().RemoveNthFromEnd(new ListNode(1), 1);
            var r3 = new Solution().RemoveNthFromEnd(new ListNode(1) { next = new ListNode(2) }, 2);
        }
    }
}
