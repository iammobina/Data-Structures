using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A7
{
    public class MaximizingArithmeticExpression : Processor
    {
        public MaximizingArithmeticExpression(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        public long Solve(string expression)
        {
            //Write your code here
            string[] SplitsOperatorAndNumbers = expression.Split(new char[] { '+', '-', '*' });
            //Add Numbers to Array by spliting expression(removes the chars above)
            long[] Numbers = new long[SplitsOperatorAndNumbers.Length];
            for (int i = 0; i < Numbers.Length; i++)
            {
                Numbers[i] = long.Parse(SplitsOperatorAndNumbers[i]);
            }
            SplitsOperatorAndNumbers = expression.Split(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',' ' });
            //Add Operators to Array by spliting expression(removes the chars above)
            string[] Operations = new string[SplitsOperatorAndNumbers.Length-2];
            for (int i = 0, j = 0; i < SplitsOperatorAndNumbers.Length; i++)
                if (SplitsOperatorAndNumbers[i] != "")
                    Operations[j++] = SplitsOperatorAndNumbers[i];

            //Processing To Find Max and Min
            long[,] Minimum = new long[Numbers.Length, Numbers.Length];
            long[,] Maximum = new long[Numbers.Length, Numbers.Length];

            for (int p = 0; p < Numbers.Length; p++)
                for (int l = 0; l < Numbers.Length; l++)
                {
                    Minimum[p, l] = long.MaxValue;
                    Maximum[p, l] = long.MinValue;
                    //در ماتریس اعدادمان قطر اصلی باید اعداد باشد بنابرین خواهیم داشت:
                    if (p == l)
                    {
                        Minimum[p, l] = Numbers[p];
                        Maximum[p, l] = Numbers[p];
                    }
                }
                for(int s=0;s<Numbers.Length;s++)
                    for(int b=0;b<Numbers.Length-s;b++)
                    {
                        int j = b + s;
                        Calculating(Maximum, Minimum, Operations, b, j);
                    } 
            
            return Maximum[0, Numbers.Length - 1];
        }

        public static void Calculating(long[,] Maximum, long[,] Minimum, string[] operations, int i, int j)
        {
            for (int k = i; k < j; k++)
            {
                long a = OperationsDefinition(operations[k], Maximum[i, k], Maximum[k + 1, j]);
                long b = OperationsDefinition(operations[k], Maximum[i, k], Minimum[k + 1, j]);
                long c = OperationsDefinition(operations[k], Minimum[i, k], Maximum[k + 1, j]);
                long d = OperationsDefinition(operations[k], Minimum[i, k], Minimum[k + 1, j]);
                Minimum[i, j] = Math.Min(Minimum[i,j],Math.Min(a,Math.Min (b,Math.Min (c,d))));
                Maximum[i, j] = Math.Max(Maximum[i, j], Math.Max(a, Math.Max(b, Math.Max(c, d))));
            }
        }


        public static long OperationsDefinition(string s, long a, long b)
        {
            long Answer = 0;
            if (s == "+")
                Answer = a + b;
            else if (s == "-")
                Answer = a - b;
            else if (s == "*")
                Answer = a * b;
            return Answer;
        }
    }
}
