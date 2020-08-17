using System; using TinyRunner;
using System.Collections.Generic;
using System.Text;

namespace ProgramRunner
{
    [Skip]
    [Info(Comment = "Timelimit exceeds")]
    public class SortList : Runner
    {
        public class Solution
        {
            public ListNode SortList(ListNode head)
            {
                if (head == null)
                    return head;

                var sorted = SortListX(head);
                sorted.next = SortList(sorted.next);
                return sorted;
            }

            public ListNode SortListX(ListNode head)
            {
                if (head == null || head.next == null)
                    return head;

                var next = SortListX(head.next);
                if (head.val <= next.val)
                {
                    head.next = next;
                    return head;
                }

                head.next = next.next;
                next.next = head;
                return next;
            }

        }

        public override void Run(string[] args)
        {
            var head = new ListNode(4)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(1)
                    {
                        next = new ListNode(3)
                    }
                }
            };

            var head2 = new ListNode(-1)
            {
                next = new ListNode(5)
                {
                    next = new ListNode(3)
                    {
                        next = new ListNode(4)
                        {
                            next = new ListNode(0)
                        }
                    }

                }
            };

            var sol = new Solution();
            //var res =  sol.SortList(head);
            var res2 = sol.SortList(head2);

        }
    }
}
