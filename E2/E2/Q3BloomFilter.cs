using System;
using System.Collections;
using System.Linq;

namespace E2
{
    public class Q3BloomFilter
    {
        BitArray Filter;
        Func<string, int>[] HashFunctions;

        public Q3BloomFilter(int filterSize, int hashFnCount)
        {
            // زحمت بکشید پیاده سازی کنید

            Random rnd = new Random();
            Filter = new BitArray(filterSize);
            HashFunctions = new Func<string, int>[hashFnCount];

            for (int i = 0; i < HashFunctions.Length; i++)
            {
                HashFunctions[i] = str => MyHashFunction(str, rnd.Next());
            }
        }

        public int MyHashFunction(string str, int num)
        {
            return str.GetHashCode() + num;
        }

        public void Add(string str)
        {
            // زحمت بکشید پیاده سازی کنید
        }

        public bool Test(string str)
        {
            // زحمت بکشید پیاده سازی کنید
            return true;
        }

        public const long BigPrimeNumber = 1000000007;
        public const long ChosenX = 263;

        public static long PolyHash(string str, long start, long count,
            long p = BigPrimeNumber, long x = ChosenX)
        {
            long hash = 0;
            for (int i = (int)(start + count - 1); i >= start; i--)
            {
                hash = ((hash * x + str[i] % p) + p) % p;
            }
            return hash;
        }
    }
}