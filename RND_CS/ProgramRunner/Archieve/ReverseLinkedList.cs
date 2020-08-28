using System; using TinyRunner;
using System.Collections.Generic;
using System.Text;

namespace ProgramRunner
{
    [Skip]
    public class ReverseLinkedList : Runner
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

        ListNode rev = null;
        public ListNode Reverse(ListNode head)
        {
            if (head == null || head.next == null)
            {
                rev = head;
                return head;
            }

            ListNode x = Reverse(head.next);
            x.next = head;
            head.next = null;
            return head;
        }

        public override void Run(string[] args)
        {
            var head = new ListNode(1)
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


            
            _ = Reverse(head);
            var res = rev;
        }
    }
}
