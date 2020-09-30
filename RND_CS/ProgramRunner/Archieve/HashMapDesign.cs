using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    // using linkedList
    public class HashMapDesign : Runner
    {
        class ListNode
        {
            public int val;
            public string key;
            public ListNode(string key, int val)
            {
                this.key = key;
                this.val = val;
            }
            public ListNode next;
        }

        class HashMap
        {
            private ListNode[] Bucket { get; }
            private int Size { get; }
            public HashMap(int size)
            {
                this.Size = size;
                this.Bucket = new ListNode[size];
            }

            public void Insert(string key, int val)
            {
                int hashCode = Math.Abs(key.GetHashCode());
                int pos = hashCode % Size;
                if(Bucket[pos] == null)
                {
                    Bucket[pos] = new ListNode(key, val);
                    return;
                }

                ListNode cur = Bucket[pos];
                while(cur!= null)
                {
                    if(cur.key == key) { break; }

                    if(cur.next == null)
                    {
                        cur.next = new ListNode(key, val);
                        break;
                    }

                    cur = cur.next;
                }
            }

            public int Get(string key)
            {
                int hashCode = Math.Abs(key.GetHashCode());
                int pos = hashCode % Size;
                if (Bucket[pos] == null)
                    throw new KeyNotFoundException();

                ListNode cur = Bucket[pos];
                while (cur != null)
                {
                    if (cur.key == key) { return cur.val; }
                    cur = cur.next;
                }
                throw new KeyNotFoundException();
            }
        }

        public override void Run(string[] args)
        {
            HashMap map = new HashMap(5);
            map.Insert("zuno", 100);
            map.Insert("sino", 200);
            map.Insert("vino", 300);
            map.Insert("tuno", 400);
            map.Insert("canu", 500);

            Debug.Assert(() => map.Get("sino"), 200);
        }
    }
}
