using System;
using System.Collections.Generic;
using System.Text;

namespace TinyRunner
{
    public static class Debug
    {
        #region Assert
        public static void Assert<T>(Func<T> func, T expected, bool throwOnException = false, Action tearDown = null)
        {
            var actual = func();
            string msg = $"Actual : {actual},\tExpected : {expected}";
            bool pass;
            if (!(pass = actual.Equals(expected)) && throwOnException)
                System.Diagnostics.Debug.Fail(msg);
            else
            {
                if (!pass)
                {
                    PrintLine($"\t{(pass ? "Pass " : "Fail ")} -> {msg}", ConsoleColor.Red);
                }
                else
                {
                    PrintLine($"\t{(pass ? "Pass " : "Fail ")} -> {msg}", ConsoleColor.Green);
                }
            }
            tearDown?.Invoke();
        }

        public static void PrintLine(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void Assert<T>(Func<T[]> func, T[] expected, bool throwOnException = false)
        {
            var actual = func();
            string msg = $"Actual : {Parse(actual)},\tExpected : {Parse(expected)}";

            bool pass = actual.Length == expected.Length;
            if (pass)
            {
                for (int i = 0; i < expected.Length; i++)
                {
                    pass &= actual[i].Equals(expected[i]);
                }
            }

            if (!pass && throwOnException)
                System.Diagnostics.Debug.Fail(msg);
            else
                Console.WriteLine($"\t{(pass ? "Pass " : "Fail ")} -> {msg}");
        }

        static string Parse<T>(T[] arr)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < arr.Length; i++)
            {
                sb.Append($"{arr[i]},");
            }
            return sb.ToString();
        }
        #endregion
    }
}
