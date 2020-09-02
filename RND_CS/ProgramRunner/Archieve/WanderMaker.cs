using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using TinyRunner;

namespace ProgramRunner
{
    [Skip]
    public class WanderMaker : Runner
    {
        public int GetMaxProfit(int len, int[] prices)
        {
            for (int i = 1; i <= len; i++)
            {
                int pr = prices[i - 1] + prof(prices, i, len - i);
                if (pr > maxprofit)
                    maxprofit = pr;
            }
            return maxprofit;
        }

        int prof(int[] prices, int fragment, int available)
        {
            if (available - 1 < 0)
                return 0;
            if (available < fragment)
                return prices[available - 1];
            return prices[fragment - 1] + prof(prices, fragment, available - fragment);
        }

        int maxprofit = 0;

        public override void Run(string[] args)
        {
            Debug.Assert(() => GetMaxProfit(5, new int[] { 2, 6, 7, 10, 13 }), 14);
        }
    }
}
