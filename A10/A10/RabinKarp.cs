using System;
using System.Collections.Generic;
using TestCommon;

namespace A10
{
    public class RabinKarp : Processor
    {
        public RabinKarp(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long[]>)Solve);

        public long[] Solve(string pattern, string text)
        {
            //List<long> occurrences = new List<long>();
            //int startIdx = 0;
            //int foundIdx = 0;
            //while ((foundIdx = text.IndexOf(pattern, startIdx)) >= startIdx)
            //{
            //    startIdx = foundIdx + 1;
            //    occurrences.Add(foundIdx);
            //}
            //return occurrences.ToArray();
            List<long> occurrences = new List<long>();
            //Random rand = new Random();
            //long x = rand.Next(1, (int)p - 1);
            long Phash = PolyHash(pattern, 0, pattern.Length);
            long[] H = PreComputeHashes(text, pattern.Length);

            for (int i = 0; i < text.Length - pattern.Length + 1; i++)
            {
                if(Phash!=H[i])
                    continue;

                 if (AreEqual(pattern, text, i, i + pattern.Length))
                        occurrences.Add(i);

            }
            return occurrences.ToArray();
        }



        public static long[] PreComputeHashes(string T, int P, long p= BigPrimeNumber, long x = ChosenX)
        {
            long[] H = new long[T.Length - P + 1];
            H[T.Length - P] = PolyHash(T, T.Length - P, P);
            long y = 1;
            for (int k = 1; k <= P; k++)
            {
                y = (((y * x) % p )+ p) % p;
            }
            for (int i = T.Length - P - 1; i >= 0; i--)
            {
                H[i] = ((x * H[i + 1] + T[i] - y * T[P + i]) % p + p )% p;
        }
            return H;
        }
        public const long BigPrimeNumber = 1000000007;
        public const long ChosenX = 263;

        public static long PolyHash(string str, long start, long count,
            long p = BigPrimeNumber, long x = ChosenX)
        {
            long hash = 0;
            for (int i =(int) (start+count - 1); i >= start; i--)
            {
                hash = ((hash * x + str[i]% p )+ p) % p;
            }
            return hash;
        }
        public bool AreEqual(string s1, string s2,int start,int count)
        {
            //if (s1.Length != s2.Length)
            //    return false; 

            for (int i=start;i<count;i++)
            {
                if (s1[i-start] != s2[i])
                    return false;
            }
            return true;
        }
    }
}


