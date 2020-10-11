using System;
using System.Collections.Generic;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class BestTimeToBuySellStockIII : Runner
    {
        public class Solution
        {
            public int MaxProfit(int[] prices)
            {
                if (prices.Length == 0) return 0;
                var dp = new int[3, prices.Length];
                for (int k = 1; k <= 2; k++)
                {
                    int min = prices[0];
                    for (int i = 1; i < prices.Length; i++)
                    {
                        min = Math.Min(min, prices[i] - dp[k - 1, i - 1]);
                        dp[k, i] = Math.Max(dp[k, i - 1], prices[i] - min);
                    }
                }
                return dp[2, prices.Length - 1];
            }
        }

        public override void Run(string[] args)
        {
            var sol = new Solution();
            Debug.Assert(() => sol.MaxProfit(new int[] { 3, 3, 5, 0, 0, 3, 1, 4 }), 6);
        }
    }
}
