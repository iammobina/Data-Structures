using System;
using System.Collections;
using System.Linq;

namespace E2
{
    public class Q3BloomFilter
    {
        BitArray Filter;
        Func<string, int>[] HashFunctions;
        public static int[] ChosenX = new int[] { 150, 110, 56, 99, 101, 95, 25, 356, 100, 78, 333 };

        public Q3BloomFilter(int filterSize, int hashFnCount)
        {
            // زحمت بکشید پیاده سازی کنید

            Filter = new BitArray(filterSize);
            HashFunctions = new Func<string, int>[hashFnCount];
            for (int i = 0; i < HashFunctions.Length; i++)
            {
                HashFunctions[i] = str => MyHashFunction(str, 0, str.Length, ChosenX[i]);
            }
        }

        public const int BigPrimeNumber = 1000000007;

        public int MyHashFunction(
            string str, int start, int count, int x,
            int p = BigPrimeNumber)
        {
            int hash = 0;

            for (int i = str.Length - 1; i >= 0; i--)
                hash = (((hash * x + str[i]) % p) + p) % p;

            return (hash) % Filter.Count;
        }


        public void Add(string str)
        {
           
            for (int i = 0; i < HashFunctions.Length; i++)
            {
                int index = MyHashFunction(str, 0, str.Length, ChosenX[i]);
                Filter[index] = true;
            }

        }

        public bool Test(string str)
        {

            int counter = 0;
            for (int i = 0; i < HashFunctions.Length; i++)
            {
                int index = MyHashFunction(str, 0, str.Length, ChosenX[i]);
                if (Filter[index])
                    counter++;
            }

            if (counter == HashFunctions.Length)
                return true;
            else
                return false;
        }
    }
}