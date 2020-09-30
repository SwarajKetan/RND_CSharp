using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class Alok : Runner
    {
        public bool IsPrime(int n)
        {
            int mid = n / 2;
            for(int i = 2; i <= mid; i++)
                if (n % i == 0) return false;
            return true;
        }

        public int[] RemoveDup(int[] arr)
        {
            Array.Sort(arr);
            // 4 8 8 21 21 32 34
            Stack<int> nodup = new Stack<int>();
            nodup.Push(arr[0]);
            for(int i = 1; i < arr.Length; i++)
            {
               if(nodup.Peek() == arr[i])
                {                   
                    while (i < arr.Length && arr[i] == nodup.Peek())
                        i++;
                    nodup.Pop();
                }
                if (i < arr.Length)
                    nodup.Push(arr[i]);
            }

            int[] ans = new int[nodup.Count];
            int k = 0;
            while(nodup.Count > 0)
                ans[k++] = nodup.Pop();

            return ans;
        }


        public void FileOperation()
        {
           string path = $"{Environment.SpecialFolder.Desktop}\\File01";
            if (System.IO.File.Exists(path))
            {
                var fileInfo = new System.IO.FileInfo(path);
                fileInfo.MoveTo($"{path}02");

                if (System.IO.File.Exists($"{path}02"))
                {
                    System.IO.File.Delete($"{path}02");
                }
            }
        }

        public override void Run(string[] args)
        {
            //Debug.Assert(() => IsPrime(2), true);
            //Debug.Assert(() => IsPrime(3), true);
            //Debug.Assert(() => IsPrime(4), false);
            //Debug.Assert(() => IsPrime(5), true);
            //Debug.Assert(() => IsPrime(9), false);

           //var res = RemoveDup(new int[] { 21, 21, 8, 4, 8, 32, 34 });
        }
    }
}
