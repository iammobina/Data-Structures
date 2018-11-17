using System;
using TestCommon;

namespace A7
{
    public class MaximumGold : Processor
    {
        public MaximumGold(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long W, long[] goldBars)
        {
            //Write your code here
            long[,] GoldValue = new long[W + 1, goldBars.Length + 1];
            long MaxValue = 0;

            for (int i = 1; i <= goldBars.Length; i++)
            {
                for (int w = 1; w <= W; w++)
                {
                    GoldValue[w, i] = GoldValue[w, i - 1];

                    if (goldBars[i - 1] <= w)
                    {
                        MaxValue = GoldValue[w - goldBars[i - 1], i - 1] + goldBars[i - 1];

                        if (GoldValue[w, i] < MaxValue)
                            GoldValue[w, i] = MaxValue;
                    }
                }
            }
            return GoldValue[W, goldBars.Length];
        }
    }
}
