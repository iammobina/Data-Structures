using System;
using TestCommon;

namespace A6
{
    public class LCSOfThree : Processor
    {
        public LCSOfThree(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long>)Solve);

        public long Solve(long[] seq1, long[] seq2, long[] seq3)
        {
            //Write your code here
            //-- instead of using this[,] i insist to use this one [][]
            long[][][] answers = new long[seq1.Length + 1][][];
            for (int i = 0; i < seq1.Length + 1; i++)
            {
                answers[i] = new long[seq2.Length + 1][];
                for (int j = 0; j < seq2.Length + 1; j++)
                {
                    answers[i][j] = new long[seq3.Length + 1];
                }
            }
            for (int i = 1; i <= seq1.Length; i++)
                for (int j = 1; j <= seq2.Length; j++)
                    for (int k = 1; k <= seq3.Length; k++)
                    {
                        if (seq1[i - 1] == seq2[j - 1] && seq1[i - 1] == seq3[k - 1])
                            answers[i][j][k] = answers[i - 1][j - 1][k - 1] + 1;
                        else
                            answers[i][j][k] = Math.Max(Math.Max(answers[i - 1][j][k], answers[i][j - 1][k]), answers[i][j][k - 1]);
                    }
            return answers[seq1.Length][seq2.Length][seq3.Length];
        }
    }
}
