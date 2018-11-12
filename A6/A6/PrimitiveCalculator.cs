using System;
using System.Collections.Generic;
using TestCommon;

namespace A6
{
    public class PrimitiveCalculator: Processor
    {
        public PrimitiveCalculator(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[]>)Solve);

        public long[] Solve(long n)
        {
            //Write your code here
            List<long> solve = new List<long>();
            solve.Add(0);
            solve.Add(1);

            // i is two cause i initilize it up there
            for (int i = 2; i <= n; i++)
            {
                if (i % 3 == 0)
                {
                    if (solve[i / 3] < solve[i - 1])
                    {
                        solve.Add(solve[i / 3] + 1);
                    }
                    else
                    {
                        solve.Add(solve[i - 1] + 1);
                    }
                }
                else if (i % 2 == 0)
                {
                    if (solve[i / 2] < solve[i - 1])
                    {
                        solve.Add(solve[i / 2] + 1);
                    }
                    else
                    {
                        solve.Add(solve[i - 1] + 1);
                    }
                }
                else
                    solve.Add(solve[i - 1] + 1);
            }

            List<long> Answer = new List<long>(solve.Count);
            Answer.Add(n);

            for (long i = n; i > 1;)
            {

                if (i % 3 == 0)
                {
                    if(solve[(int)i / 3] <= solve[(int)i - 1])
                    {
                        i = i / 3;
                    }
                    else
                    {
                        i = i - 1;
                    }
                    Answer.Add(i);
                }

                else if (i % 2 == 0)
                {
                    if (solve[(int)i / 2] <= solve[(int)i - 1])
                    {
                        i = i / 2;
                    }
                    else
                    {
                        i = i - 1;
                    }
                    Answer.Add(i);
                }
                else
                {
                    i--;
                    Answer.Add(i);
                }
            }

            Answer.Reverse();
            return Answer.ToArray();
        }
    }
}
