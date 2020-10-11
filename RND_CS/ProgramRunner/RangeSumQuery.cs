using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class RangeSumQuery : Runner
    {
        public class NumArray
        {


            private int[] st = null;
            private int[] _nums = null;
            public NumArray(int[] nums)
            {
                //int levels = (int)Math.Ceiling(Math.Log2(nums.Length));
                int count = GetSizeOfSegmentTree(nums.Length);
                this.st = new int[count];
                this._nums = nums;
                SumOf(nums, 0, nums.Length -1, 0);
            }

            private int GetSizeOfSegmentTree(int n)
            {
                //Math.PIO
                // 2 * 2 ^Celling(Log n)  - 1
                int x = (int)Math.Ceiling(Math.Log2(n));
                int y = 2 * (int)Math.Pow(2, x) - 1;
                return y;
            }

            private int SumOf(int[] nums, int start, int end, int si)
            {
                if (start == end)
                {
                    st[si] = nums[start];
                    return st[si];
                }

                int mid = start + (end - start) / 2;

                int leftChildIndex = (2 * si) + 1;
                int rightChildIndex = (2 * si) + 2;

                st[si] = SumOf(nums, start, mid, leftChildIndex) + SumOf(nums, mid + 1, end, rightChildIndex);
                return st[si];
            }

            public void Update(int i, int val)
            {
                int diff = val - _nums[i];
                CommitUpdate(i, diff, 0, 0, _nums.Length - 1);
            }

            private void CommitUpdate(int i, int diff, int si, int sl, int sr)
            {

                if (i < sl || i > sr) return;
                if(sl == sr)
                {
                    st[si] += diff;
                    return;
                }

                st[si] += diff;
                int mid = sl + (sr - sl) / 2;
                CommitUpdate(i, diff, (2 * si + 1), sl, mid);
                CommitUpdate(i, diff, (2 * si + 2), mid + 1, sr);
            }

            public int SumRange(int i, int j)
            {
                return FindSumRange(i, j, 0, _nums.Length - 1, 0);
            }

            private int FindSumRange(int l, int r, int sl, int sr, int si)
            {
                if (l <= sl && r >= sr) return st[si];
                if (sr < l || sl > r) return 0;
                int mid = sl + (sr - sl) / 2;
                return FindSumRange(l, r, sl, mid, (2 * si + 1)) + FindSumRange(l, r, mid + 1, sr, (2 * si + 2));
            }
        }
        public override void Run(string[] args)
        {
            var narr = new NumArray(new int[] { 1, 3, 5, 9, 4, 6 });

            Debug.Assert(() => narr.SumRange(0, 2), 9);
            Debug.Assert(() => narr.SumRange(0, 5), 28);
            narr.Update(1, 2);
            Debug.Assert(() => narr.SumRange(0, 2),8);
        }
    }
}
