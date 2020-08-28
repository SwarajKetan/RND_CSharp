using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    [Info("Trie problem")]
    public class LongestWordInDictionary : Runner
    {
        public class Solution
        {
            class TrieNode
            {
                public TrieNode[] Children = new TrieNode[26];// 26 letters
                public bool IsEndOfWord;
            }

            void InsertWord(TrieNode root, string word)
            {
                TrieNode cur = root;
                for (int i = 0; i < word.Length; i++)
                {
                    int index = word[i] - 'a';
                    if (cur.Children[index] == null)
                        cur.Children[index] = new TrieNode();
                    cur = cur.Children[index];
                }
                cur.IsEndOfWord = true;
            }

            TrieNode root = new TrieNode() { IsEndOfWord = true };
            public string LongestWord(string[] words)
            {
                HashSet<char> letters = new HashSet<char>();
                for (int i = 0; i < words.Length; i++)
                {
                    InsertWord(root, words[i]);
                }

                return FindLongest(root);
            }

            string FindLongest(TrieNode root)
            {
                if (root == null) return "";

                string longest = "";
                for (int i = 0; i < root.Children.Length; i++)
                {
                    string tmp = "";
                    if (root.Children[i] != null && root.Children[i].IsEndOfWord)
                    {
                        char k = (char)(i + 'a');
                        tmp = k + FindLongest(root.Children[i]);
                    }

                    if (tmp.Length > longest.Length)
                        longest = tmp;
                }
                return longest;
            }

            //bool Search(TrieNode root, string word)
            //{
            //    TrieNode cur = root;
            //    for (int i = 0; i < word.Length; i++)
            //    {
            //        int index = word[i] - 'a';
            //        if (cur.Children[index] == null)
            //            return false;
            //        cur = cur.Children[index];
            //    }
            //    return cur != null && cur.IsEndOfWord;
            //}


            public void ResetTrie()
            {
                root = new TrieNode() { IsEndOfWord = true };
            }
        }

        public override void Run(string[] args)
        {
            var sol = new Solution();
            Debug.Assert(() => sol.LongestWord(new string[] { "w", "wo", "wor", "worl", "world" }), "world", tearDown: () => sol.ResetTrie());
            Debug.Assert(() => sol.LongestWord(new string[] { "a", "banana", "app", "appl", "ap", "apply", "apple" }), "apple", tearDown: () => sol.ResetTrie());
            Debug.Assert(() => sol.LongestWord(new string[] { "a", "banana", "app", "appl", "ap", "apple", "apply" }), "apple", tearDown: () => sol.ResetTrie());
            Debug.Assert(() => sol.LongestWord(new string[] { "m", "mo", "moc", "moch", "mocha", "l", "la", "lat", "latt", "latte", "c", "ca", "cat" }), "latte", tearDown: () => sol.ResetTrie());
            Debug.Assert(() => sol.LongestWord(new string[] { "yo", "ew", "fc", "zrc", "yodn", "fcm", "qm", "qmo", "fcmz", "z", "ewq", "yod", "ewqz", "y" }), "yodn", tearDown: () => sol.ResetTrie());
            Debug.Assert(() => sol.LongestWord(new string[] { "rac", "rs", "ra", "on", "r", "otif", "o", "onpdu", "rsf", "rs", "ot", "oti", "racy", "onpd" }), "otif", tearDown: () => sol.ResetTrie());
            Debug.Assert(() => sol.LongestWord(new string[] { "ogz", "eyj", "e", "ey", "hmn", "v", "hm", "ogznkb", "ogzn", "hmnm", "eyjuo", "vuq", "ogznk", "og", "eyjuoi", "d" }), "eyj", tearDown: () => sol.ResetTrie());
        }
    }
}
