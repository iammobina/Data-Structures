using System;
using System.Collections.Generic;
using TestCommon;

namespace A6
{
    public class MoneyChange : Processor
    {
        private static readonly int[] COINS = new int[] { 1, 3, 4 };

        public MoneyChange(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
            //Write your code here
            List<long> MinN = new List<long>((int)n);
            long NCoins = 0;
            MinN.Add(0);

            for (int i = 1; i <= n; i++)
            {
                MinN.Add(long.MaxValue);
                for (int j = 0; j < COINS.Length; j++)
                    if (i >= COINS[j])
                    {
                        NCoins = MinN[i - COINS[j]] + 1;
                        if (NCoins < MinN[i])
                        {
                            MinN[i] = NCoins;
                        }
                        else
                        {
                            MinN[i] = MinN[i];
                        }

                    }
            }
            return MinN[(int)n];
        }
    }
}
