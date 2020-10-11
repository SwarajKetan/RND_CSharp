using System;
using System.Collections.Generic;
using System.Text;

namespace TinyRunner
{
    public static class StringExtensions
    {
        public static TreeNode ToBinaryTree(this string str)
        {
            throw new NotImplementedException();
        }
        public static void Print<T>(this T[] arr, string msg = "")
        {
            Debug.Print($"{msg}");
            foreach (var x in arr) Debug.Print($"{x},");
            Debug.Print("\n");
        }

        //public static T As<T>(this string s)
        //{

        //}

    }
}
