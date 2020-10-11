using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class Alok : Runner
    {

        public override void Run(string[] args)
        {
            ListNode head = new ListNode(-1);
            ListNode cur = head;
            for(int i = 0; i < 6; i++)
            {
                cur.next = new ListNode(i);
                cur = cur.next;
            }
            var t = head.next;
        }
    }
}
