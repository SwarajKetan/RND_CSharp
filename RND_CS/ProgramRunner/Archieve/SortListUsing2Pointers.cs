using System; using TinyRunner;
using System.Collections.Generic;
using System.Text;

namespace ProgramRunner
{
    [Skip]
    //[RunThis]
    public class SortListUsing2Pointers : Runner
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
            public ListNode SortList(ListNode head)
            {
                if (head == null || head.next == null)
                    return head;

                ListNode slow = head;
                ListNode fast = head;
                ListNode tmp = head;

                while(fast != null && fast.next != null)
                {
                    tmp = slow;
                    slow = slow.next;
                    fast = fast.next.next;
                }
                tmp.next = null;
                ListNode left = SortList(head);
                ListNode right = SortList(slow);
                ListNode merged = Merge(left, right);
                return merged;
            }

            public ListNode Merge(ListNode a, ListNode b)
            {
                if (a == null && b == null) return null;
                if (a == null && b != null) return b;
                if (a != null && b == null) return a;
                bool aLesserThanb = (a.val <= b.val);
                ListNode merged = aLesserThanb ? a : b;
                merged.next = aLesserThanb ? Merge(a.next, b): Merge(a, b.next);
                return merged;
            }
        }

        public override void Run(string[] args)
        {
            //ListNode a = new ListNode(2)
            //{
            //    next = new ListNode(7)
            //};

            //ListNode b = new ListNode(3)
            //{
            //    next = new ListNode(8)
            //};

            //ListNode res = new Solution().Merge(a, b);

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
            var res = sol.SortList(head);
        }
    }
}
