using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{

    [Skip]

    public class LRUCacheLC : Runner
    {
        public class LRUCache
        {
            class ListNode
            {
                public int key;
                public int val;
                public ListNode next;
                public ListNode prev;
                public ListNode(int key, int val)
                {
                    this.key = key;
                    this.val = val;
                }
            }

            private int capacity;
            //<key,ReferenceToListNode>
            private readonly Dictionary<int, ListNode> map;
            private ListNode head;
            private ListNode tail;

            public LRUCache(int capacity)
            {
                this.capacity = capacity;
                this.map = new Dictionary<int, ListNode>(capacity);
            }

            public int Get(int key)
            {
                if (!map.ContainsKey(key))
                    return -1;

                ListNode target = map[key];

                if (target == head)
                    return head.val;
                else if (target == tail)
                {
                    ListNode secondLast = tail.prev;
                    secondLast.next = null;
                    tail = secondLast;
                }
                else
                {
                    ListNode left = target.prev;
                    ListNode right = target.next;
                    left.next = right;
                    right.prev = left;
                }
                target.next = head;
                head.prev = target;
                head = target;

                return target.val;

            }

            public void Put(int key, int value)
            {
                //Console.Write($"\nPUT: key:{key}, val:{value}");

                if (map.ContainsKey(key))
                {
                    Get(key);
                    map[key].val = value;
                    return;
                }

                if (map.Count >= capacity)
                {
                    // evict the oldest item
                    ListNode secondLast = tail.prev;
                    if (secondLast != null)
                        secondLast.next = null;
                    map.Remove(tail.key);
                    tail = secondLast;
                }

                ListNode first = new ListNode(key, value);
                if (map.Count == 0)
                {
                    head = first;
                    tail = first;
                }
                else
                {
                    first.next = head;
                    head.prev = first;
                    head = first;
                }
                map.Add(key, first);
            }

            public override string ToString()
            {
                ListNode tmp = head;
                string ls = string.Empty;
                while (tmp != null)
                {
                    ls += tmp.val + " --> ";
                    tmp = tmp.next;
                }

                string mapss = string.Empty;
                foreach (var kvp in map)
                    mapss += $"{kvp.Key},{kvp.Value.val} ";

                return "\n" + ls + "\n" + mapss;

            }
        }

        public override void Run(string[] args)
        {
            var cache = new LRUCache(2);
            cache.Put(2, 1);
            Console.WriteLine(cache);
            cache.Put(1, 1);
            Console.WriteLine(cache);
            cache.Put(2, 3);
            Console.WriteLine(cache);
            cache.Put(4, 1);
            Console.WriteLine(cache);
            Debug.Assert(()=>cache.Get(1), -1);
            Console.WriteLine(cache);
            Debug.Assert(()=>cache.Get(2), 3);
            Console.WriteLine(cache);
        }
    }
}
