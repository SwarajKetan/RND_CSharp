using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class LRUCache : Runner
    {
        class Cache
        {
            int cacheSize = 0;
            public Cache(int cacheSize)
            {
                if (cacheSize == 0)
                    throw new ArgumentException();
                this.cacheSize = cacheSize;
                map = new Dictionary<int, ListNode>(cacheSize);
            }
            class ListNode
            {
                public char val;
                public ListNode(char val)
                {
                    this.val = val;
                }

                public ListNode prev;
                public ListNode next;
            }

            Dictionary<int, ListNode> map;

            ListNode head;
            ListNode tail;
            public void Put(char c)
            {
                Console.Write($"\nPUT: {c}");


                int hc = c.GetHashCode();
                if (map.ContainsKey(hc))
                    return;

                // First add
                ListNode nn = new ListNode(c);
                if (head == null)
                {
                    head = nn;
                    tail = head;
                    map.Add(hc, head);
                    return;
                }

                // Eviction
                if (map.Count == cacheSize)
                {
                    int th = tail.val.GetHashCode();
                    ListNode pre = tail.prev;
                    pre.next = null;
                    tail = pre;
                    map.Remove(th);
                }

                // Add
                nn.next = head;
                head.prev = nn;
                head = nn;
                map.Add(nn.val.GetHashCode(), nn);
            }

            public char Get(int num)
            {
                Console.WriteLine($"\nGET: {(char)num}");
                // num range between 65 -> 90

                char c = (char)num;
                int hc = c.GetHashCode();
                if (!map.ContainsKey(hc)) // cache miss
                    return '\0';
                ListNode hit = map[hc];

                if (hit == head)
                    return head.val;
                else if(hit == tail)
                {
                    tail = tail.prev;
                    tail.next = null;

                    hit.next = head;
                    head.prev = hit;
                    head = hit;
                    return hit.val;
                }

                ListNode pp = hit.prev;
                ListNode nn = hit.next;
                pp.next = nn;
                nn.prev = pp;

                hit.next = head;
                head.prev = hit;
                head = hit;
                return hit.val;
            }

            public override string ToString()
            {
                ListNode tmp = head;
                string ls = string.Empty;
                while(tmp!= null)
                {
                    ls += tmp.val + " <--> ";
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
            var cache = new Cache(3);

            cache.Put('A');
            Console.WriteLine(cache.ToString());
            cache.Put('B');
            Console.WriteLine(cache.ToString());
            cache.Put('C');
            Console.WriteLine(cache.ToString());
            cache.Put('B');
            Console.WriteLine(cache.ToString());
            cache.Put('D'); 
            Console.WriteLine(cache.ToString());

            cache.Get(67);
            Console.WriteLine(cache.ToString());
            cache.Put('F');
            Console.WriteLine(cache.ToString());
            cache.Put('H');
            Console.WriteLine(cache.ToString());
            cache.Put('I');
            Console.WriteLine(cache.ToString());
            cache.Get(70);
            Console.WriteLine(cache.ToString());
        }
    }
}
