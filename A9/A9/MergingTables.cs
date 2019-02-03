using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A9
{
    public class MergingTables : Processor
    {
        public MergingTables(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);

        public long[] Solve(long[] tableSizes, long[] sourceTables, long[] targetTables)
        {
            int sizeT= sourceTables.Length;
            List<long> Answer = new List<long>(sizeT);
            long[] Root = new long[tableSizes.Length];


            for (int i = 0; i < sizeT; i++)
            {
                long source = sourceTables[i] - 1;
                while (Root[source] != 0)
                {
                    source = Root[source];
                }

                long target = targetTables[i] - 1;
                while (Root[target] != 0)
                {
                    target = Root[target];
                }

                //Like the pdf said if they are not equal should copy source to destin
                //source delete and links added
                if (target != source)
                {
                    Root[source] = target;
                    tableSizes[target] += tableSizes[source];
                }

                Answer.Add(tableSizes.Max());
            }
            return Answer.ToArray();
        }
    }
}