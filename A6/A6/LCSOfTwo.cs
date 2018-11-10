using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class LCSOfTwo: Processor
    {
        public LCSOfTwo(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long>)Solve);

        public long Solve(long[] seq1, long[] seq2)
        {
            //Write your code here
            long[,] Answer = new long[seq1.Length+1, seq2.Length + 1];
            for (int i = 0; i <= seq1.Length; i++)
            {
                for (int j = 0; j <= seq2.Length; j++)
                {
                    if (seq1[i - 1] == seq2[j - 1])
                        Answer[i, j] = Answer[i - 1, j - 1] + 1;
                    else
                        Answer[i, j] = Math.Max(Answer[i - 1, j], Answer[i, j - 1]);
                }
            }
            return Answer[seq1.Length, seq2.Length];
        }
    }
}
