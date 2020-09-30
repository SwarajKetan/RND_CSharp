using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    [Info("If the keys r strictly alphabets the  only it can be used")]
    public class HashMapUsingTrie : Runner
    {
        class TrieNode
        {
            public bool IsEndOfWord = false;
            public int val;
            public TrieNode[] Children = new TrieNode[26];
        }

        class HashMap
        {
            private TrieNode[] Bucket { get; }
            private int Size { get; }
            public HashMap(int size)
            {
                this.Size = size;
                this.Bucket = new TrieNode[size];
            }

            public void Insert(string key, int val)
            {
                int hashCode = Math.Abs(key.GetHashCode());
                int pos = hashCode % Size;
                if (Bucket[pos] == null)
                    Bucket[pos] = new TrieNode();
                InsertWord(Bucket[pos], key, val);
            }

            public int Get(string key)
            {
                int hashCode = Math.Abs(key.GetHashCode());
                int pos = hashCode % Size;
                if (Bucket[pos] == null)
                    throw new KeyNotFoundException();

                TrieNode root = Bucket[pos];
                // serach
                foreach(char c in key)
                {
                    int indx = c - 'a';
                    if (root.Children[indx] == null)
                        throw new KeyNotFoundException();
                    root = root.Children[indx];
                }

                if (root.IsEndOfWord)
                    return root.val;
                return int.MinValue;
            }

            void InsertWord(TrieNode root, string word, int val)
            {
                TrieNode cur = root;
                for (int i = 0; i < word.Length; i++)
                {
                    int index = word[i] - 'a';
                    if (cur.Children[index] == null)
                        cur.Children[index] = new TrieNode();
                    cur = cur.Children[index];
                }
                if (cur.IsEndOfWord)
                    throw new Exception("Duplicate key found");

                cur.IsEndOfWord = true;
                cur.val = val;
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

            Debug.Assert(() => map.Get("tuno"), 400);
            Debug.Assert(() => map.Get("zuno"), 100);
        }
    }
}
