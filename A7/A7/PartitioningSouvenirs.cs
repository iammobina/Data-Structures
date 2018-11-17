using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   
using TestCommon;

namespace A7
{
    public class PartitioningSouvenirs : Processor
    {
        public PartitioningSouvenirs(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long souvenirsCount, long[] souvenirs)
        {
            //Write your code here
            Array.Sort(souvenirs);
            Array.Reverse(souvenirs);
            long Answer = 0;
            double Section = souvenirs.Sum() / 3;
            long[,] Matrix = new long[(int)Section + 1, souvenirsCount + 1];

            for (int i = 0; i <= Section; i++)
            {
                for (int j = 1; j <= souvenirsCount; j++)
                {
                    long amount = i - souvenirs[j - 1];
                    if (souvenirs[j - 1] == i || (amount > 0 && Matrix[amount, j - 1] > 0))
                        if (Matrix[i, j - 1] == 0)
                            Matrix[i, j] = 1;
                        else
                            Matrix[i, j] = 2;
                    else
                        Matrix[i, j] = Matrix[i, j - 1];
                }
            }

            if (souvenirs.Sum() % 3 != 0 || souvenirsCount <= 2)
                return 0;

            if (Matrix[(int)Section, souvenirsCount] == 2)
                Answer = 1;
            else
                Answer = 0;

            return Answer;
        }

    }
}
