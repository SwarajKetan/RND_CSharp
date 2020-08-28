using System;
using TinyRunner;
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

            public ListNode ReverseKGroup(ListNode head, int k)
            {
                int pos = 0;
                ListNode res = null;
                ListNode cur = head;
                ListNode thead = head;
                while(cur != null)
                {
                    ++pos;
                    if(pos % k == 1)
                    {
                        thead = cur;
                    }

                    if(pos % k == 0)
                    {
                        rev = null;
                        var last = Reverse(thead, k);
                        if(res == null)
                        {
                            res = rev;
                        }
                        cur = nextStart;
                        last.next = cur;
                        thead = cur;
                    }
                    else
                    {
                        cur = cur.next;
                    }

                }

                return res;
            }

            ListNode nextStart = null;
            ListNode rev = null;
            ListNode Reverse(ListNode head, int k)
            {
                if(k == 1)
                {
                    nextStart = head.next;
                    head.next = null;
                    rev = head;
                    return head;
                }

                ListNode r = Reverse(head.next, k - 1);


                r.next = head;
                head.next = null;
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
                            {
                                next = new ListNode(6)
                                {
                                    next = new ListNode(7)
                                    {
                                        next = new ListNode(8)
                                    }
                                }
                            }
                        }
                    }
                }
            };

            var sol = new Solution();
            //sol.ReverseKGroup(head, 3);
            ListNode res = sol.ReverseKGroup(head, 3);
        }
    }
}
