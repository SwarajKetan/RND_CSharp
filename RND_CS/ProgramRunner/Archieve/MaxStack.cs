using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
 [Skip]
    public class MaxStack2 : Runner
    {
        public class MaxStack
        {
            class ListNode
            {
                public int val;
                public ListNode(int v) { val = v; }
                public ListNode next;
            }

            ListNode head;
            Stack<int> stk;
            /** initialize your data structure here. */
            public MaxStack()
            {
                stk = new Stack<int>();
            }

            private void Place(int v)
            {
                var n = new ListNode(v);
                if (head == null)
                {
                    head = n;
                    return;
                }

                if(v >= head.val)
                {
                    n.next = head;
                    head = n;
                    return;
                }


                ListNode prev = head;
                ListNode cur = head.next;
                while(cur != null)
                {
                    if(v > cur.val)
                    {
                        n.next = cur;
                        prev.next = n;
                        break;
                    }

                    if(cur.next == null)
                    {
                        cur.next = n;
                        break;
                    }
                    prev = cur;
                    cur = cur.next;
                }


            }
            private void Remove(int v)
            {
                if(head.val == v)
                {
                    head = head.next;
                    return;
                }

                ListNode slow = head;
                ListNode cur = head.next;
                while(cur != null)
                {
                    if(cur.val == v)
                    {
                        slow.next = cur.next;
                        break;
                    }

                    slow = cur;
                    cur = cur.next;
                }
            }

            public void Push(int x)
            {
                stk.Push(x);
                //
                Place(x);
            }

            public int Pop()
            {
               var top = stk.Pop();
                Remove(top);
                return top;

            }

            public int Top()
            {
                return stk.Peek();
            }

            public int PeekMax()
            {
                return head.val;
            }

            public int PopMax()
            {
                int v = head.val;
                head = head.next;

                // remove item from stack
                var tmpstk = new Stack<int>();

                while (stk.Count > 0 && stk.Peek() != v)
                    tmpstk.Push(stk.Pop());

                stk.Pop();
                while (tmpstk.Count > 0)
                    stk.Push(tmpstk.Pop());

                return v;
            }
        }
        public override void Run(string[] args)
        {
            var ms = new MaxStack();
            ms.Push(2);
            ms.Push(3);
            ms.Push(6);
            ms.Push(1);
            ms.Push(5);
            ms.Push(4);
            Debug.Assert(() => ms.PeekMax(), 6);
            ms.PopMax();

            Debug.Assert(() => ms.PeekMax(), 5);
        }
    }
}
