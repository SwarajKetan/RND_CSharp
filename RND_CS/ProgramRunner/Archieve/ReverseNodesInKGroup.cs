using System; using TinyRunner;
using System.Collections.Generic;
using System.Text;

namespace ProgramRunner
{
    [Skip]
    //[Info(ProblemLink = "https://leetcode.com/problems/reverse-nodes-in-k-group/")]
    public class ReverseNodesInKGroup : Runner
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
            // 1 -> 2 -> 3 -> 4 -> 5
            int tc = 0;
            public ListNode ReverseKGroup(ListNode head, int k)
            {
                return ReverseKGroupX(head, k, 1);
            }

            public ListNode ReverseKGroupX(ListNode head, int k, int count)
            {
                // 3
                if (head == null || head.next == null)
                    return head;

                count += 1;
                ListNode nxt = ReverseKGroupX(head.next, k, count);
                if (count % k == 0)
                {
                    tc = k;
                    return head;
                }
                // 4
                if (tc > 0)
                {
                    nxt.next = head;
                    tc -= 1;
                    return nxt;
                }
                return head;
            }

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

            var sol = new Solution();
            //sol.ReverseKGroup(head, 3);
            sol.ReverseKGroup(head, 2);
        }
    }
}
