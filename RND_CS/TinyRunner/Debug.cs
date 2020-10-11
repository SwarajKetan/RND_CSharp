using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace TinyRunner
{
    public static class Debug
    {
        #region Assert
        public static void Assert<T>(Func<T> func, T expected, bool throwOnException = false, Action tearDown = null)
        {

            //if(typeof(T).GetInterfaces().Any(x=>x.Name == "IEnumerable" || x.Name == "IList"))
            //{
            //    throw new Exception("Can't assert collection type. Please use specific api.");
            //}

            var actual = func();
            string msg = $"Actual : {actual},\tExpected : {expected}";
            bool pass;
            if (!(pass = actual.Equals(expected)) && throwOnException)
                System.Diagnostics.Debug.Fail(msg);
            else
            {
                if (!pass)
                    PrintLine($"\t{(pass ? "Pass " : "Fail ")} -> {msg}", ConsoleColor.Red);
                else
                    PrintLine($"\t{(pass ? "Pass " : "Fail ")} -> {msg}", ConsoleColor.Green);
            }
            tearDown?.Invoke();
        }
        public static void AssertArray<T>(Func<T[]> func, T[] expected, bool throwOnException = false, Action tearDown = null)
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
                PrintFailure(msg);
            else
                PrintSuccess($"\t{(pass ? "Pass " : "Fail ")} -> {msg}");

            tearDown?.Invoke();
        }
        public static void AssertLinkedList<T>(Func<T> func, T expected, bool throwOnException = false, Action tearDown = null)
             where T : ListNode
        {
            throw new NotImplementedException();
            //var actual = func();
            //string msg = $"Actual : {Parse(actual)},\tExpected : {Parse(expected)}";

            //bool pass = actual.Length == expected.Length;
            //if (pass)
            //{
            //    for (int i = 0; i < expected.Length; i++)
            //    {
            //        pass &= actual[i].Equals(expected[i]);
            //    }
            //}

            //if (!pass && throwOnException)
            //    PrintFailure(msg);
            //else
            //    PrintSuccess($"\t{(pass ? "Pass " : "Fail ")} -> {msg}");

            //tearDown?.Invoke();
        }
        public static void AssertAny<T>(Func<T> func, Func<T, bool> funcExpected)
        {
            var actual = func();
            if (funcExpected(actual))
            {
                PrintSuccess("Passed");
            }
            else
            {
                PrintFailure("Failed");
            }
        }
        public static void PrintLine(string text, ConsoleColor color = ConsoleColor.Yellow)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void Print(string text, ConsoleColor color = ConsoleColor.Yellow)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        static string Parse<T>(T[] arr)
        {
            return string.Join(',', arr);
        }
        private static void PrintSuccess(string msg)
        {
            PrintLine(msg, ConsoleColor.Green);
        }
        private static void PrintFailure(string msg)
        {
            PrintLine(msg, ConsoleColor.Red);
        }
        #endregion
    }
}
