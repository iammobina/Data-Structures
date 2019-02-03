using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A10
{
    class Program
    {
        static void Main(string[] args)
        {
          
            //PhoneBook pb = new PhoneBook("in_1.txt");
            //pb.Solve(new string[] { "add 3694011 nyhpl",
            //"del 1865098",
            //"del 8847056",
            //"find 8118901",
            //"find 3658536",
            //"add 5863367 فرشآورد",
            //"find 1830857",
            //"add 6427439 umahuzv",
            //"find 4602447",
            //"del 9283895",
            //"find 5572017",
            //"add 9427226 ميكاييل"} );


            //PhoneBook te = new PhoneBook("ss");
            //te.Solve(new string[] {"add 9999999 bigNum",
            //"find 9999999",
            //"add 9999998 notSoBig",
            //"del 9999998",
            //"find 9999998",
            //"add 1 aaaaaaaaaaaaaaa",
            //"add 2 testForLen",
            //"find 2",
            //"find 1" });

            //            PhoneBook t6 = new PhoneBook("tst6");
            //            t6.Solve(new string[] {"add 3870398 خوبروي",
            //"add 9241971 آتنايا",
            //"add 6907853 پايون",
            //"add 8396645 مهراسا ",
            //"find 3870398",
            //"find 9241971",
            //"find 6907853"});

            //RabinKarp rb = new RabinKarp("dd");
            //rb.Solve("aba", "abacaba");

            // PolyHash("world",0,4);
            HashingWithChain hs = new HashingWithChain("fff");
            hs.Solve(3,new string[]
            {
"check 0",
"find help",
"add help",
"add del",
"add add",
"find add",
"find del",
"del del",
"find del",
"check 0",
"check 1",
"check 2"
            });

            Console.Read();

        }

        public const long BigPrimeNumber = 1000000007;
        public const long ChosenX = 263;

        public static long PolyHash(string str, int start, int count,
            long p = BigPrimeNumber, long x = ChosenX)
        {
            long hash = 0;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                hash = (hash * x + str[i]);
            }
            long final = (hash % p) % str.Length;
            return final ;
        }
        

    }
}
