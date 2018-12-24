using System;
using System.Collections;
using System.Linq;

namespace E2
{
    public class Q3BloomFilter
    {
       public static BitArray Filter;
        Func<string, int>[] HashFunctions;
        public static int[] ChosenX = new int[] { 100, 101, 245, 654, 300, 99, 380, 95, 154, 236, 247 };

        public Q3BloomFilter(int filterSize, int hashFnCount)
        {
            // زحمت بکشید پیاده سازی کنید

            //Random rnd = new Random();
            Filter = new BitArray(filterSize);
            HashFunctions = new Func<string, int>[hashFnCount];

            for (int i = 0; i < HashFunctions.Length; i++)
            {
                HashFunctions[i] = str => MyHashFunction(str,0,str.Length,ChosenX[i]);
            }
        }

        //public int MyHashFunction(string str, int num)
        //{
        //    return str.GetHashCode() + num;
        //}

        public void Add(string str)
        {
            // زحمت بکشید پیاده سازی کنید
            for (int i = 0; i < HashFunctions.Length; i++)
            {
                int num= MyHashFunction(str, 0, str.Length, ChosenX[i]);
                Filter[num] = true;
                    
            }
        }

        public bool Test(string str)
        {
            // زحمت بکشید پیاده سازی کنید
            int count = 0;
            for (int i = 0; i < HashFunctions.Length; i++)
            {
                int num = MyHashFunction(str, 0, str.Length, ChosenX[i]);
                if (Filter[num])
                    count++;
            }
            if (count == HashFunctions.Length)
                return true;
            else
                return false;
        }

        public const int BigPrimeNumber = 1000000007;
        //public const long ChosenX = 263;

        public static int MyHashFunction(string str, int start, int count,int x,
            int p = BigPrimeNumber)
        {
            int hash = 0;
            for (int i = str.Length-1; i >= 0; i--)
            {
                hash = ((hash * x + str[i] % p) + p) % p;
            }
            return (hash) % Filter.Count;
        }
    }
}