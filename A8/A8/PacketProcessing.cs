using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A8
{
    public class PacketProcessing : Processor
    {
        public PacketProcessing(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long[]>)Solve);

        public long[] Solve(long bufferSize,
            long[] arrivalTimes,
            long[] processingTimes)
        {
            List<long> EndTime = new List<long>(arrivalTimes.Length);
            long[] Result = new long[arrivalTimes.Length];

            for (int i = 0; i < arrivalTimes.Length; i++)
            {
                while (EndTime.Count > 0 && EndTime[0] <= arrivalTimes[i])
                    EndTime.RemoveAt(0);

                if (EndTime.Count < bufferSize)
                {
                    if (EndTime.Count == 0)
                    {
                        EndTime.Add(arrivalTimes[i] + processingTimes[i]);
                        Result[i] = arrivalTimes[i];
                    }

                    else
                    {
                        long StartPoint = arrivalTimes[i];

                        if (EndTime.LastOrDefault() > StartPoint)
                            StartPoint = EndTime.LastOrDefault();

                        else if (EndTime.LastOrDefault() == StartPoint)
                            StartPoint = EndTime.LastOrDefault() + 1;

                        EndTime.Add(StartPoint + processingTimes[i]);
                        Result[i] = StartPoint;
                    }
                }
                else
                    Result[i] = -1;
            }
            return Result;
        }
    }
}
