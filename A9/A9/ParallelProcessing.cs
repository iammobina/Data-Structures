using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A9
{
    public class ParallelProcessing : Processor
    {
        public ParallelProcessing(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], Tuple<long, long>[]>)Solve);

        public Tuple<long, long>[] Solve(long threadCount, long[] jobDuration)
        {
            List<Tuple<long, long>> Answer = new List<Tuple<long, long>>();
            List<long> StartingPoint = new List<long>((int)threadCount);

            for (int i = 0; i < threadCount; i++)
            {
                Answer.Add(new Tuple<long, long>(i, 0));
                StartingPoint.Add(jobDuration[i]);
            }

            
            while (threadCount < jobDuration.Length)
            {
                for (int i = 0; i < StartingPoint.Count && threadCount < jobDuration.Length; i++)
                {
                    long Min = StartingPoint.Min();
                    long MinIndex = StartingPoint.IndexOf(Min);
                    Answer.Add(new Tuple<long, long>(MinIndex, Min));
                    StartingPoint[(int)MinIndex] += jobDuration[threadCount++];
                }
            }

            return Answer.ToArray();
        }
    }
}
