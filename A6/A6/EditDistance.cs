using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class EditDistance : Processor
    {
        public EditDistance(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long>)Solve);

        public long Solve(string str1, string str2)
        {
            //Write your code here
            long[,] editDistance = new long[str1.Length + 1, str2.Length + 1];
            for (int i = 0; i < str1.Length + 1; i++)
                editDistance[i, 0] = i;
            for (int j = 0; j < str2.Length + 1; j++)
                editDistance[0, j] = j;


            for (int j = 1; j <= str2.Length; j++)
            {
                for (int i = 1; i <= str1.Length; i++)
                {
                    if (str1[i - 1] == str2[j - 1])
                    {
                        //For Finding Minimum Math.min can take only two parametr
                        //Better to use your own 
                        if (str1[i - 1] == str2[j - 1])
                            editDistance[i, j] =MathMin3params(editDistance[i - 1, j] + 1,
                                editDistance[i, j - 1] + 1,
                                editDistance[i - 1, j - 1]);
                        else
                            editDistance[i, j] = MathMin3params(editDistance[i - 1, j] + 1,
                                editDistance[i, j - 1] + 1,
                                editDistance[i - 1, j - 1] + 1);
                    }
                }
            }

            return editDistance[str1.Length, str2.Length];
        }

        public long MathMin3params(long Params1, long Params2, long Params3)
        {
            Params1 = Math.Min(Params1, Params2);
            return Math.Min(Params1, Params3);
        }
    }
}
