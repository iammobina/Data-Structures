using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A10
{
    public class HashingWithChain : Processor
    {
        public HashingWithChain(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, string[], string[]>)Solve);


        protected LinkedList<string>[] Phony;
        //protected ArrayList arr;
        //protected List<List<string>>[] pho;
        static long bucket;

        public string[] Solve(long bucketCount, string[] commands)
        {
            bucket = bucketCount;
            //PhoneBooky = new Dictionary<string, long>(commands.Length);
            //HashSet<string> PhoneBook = new HashSet<string>();
            Phony = new LinkedList<string>[bucketCount];
            // pho = new List<List<string>>[commands.Length];
            //arr = new ArrayList();
            List<string> result = new List<string>();
            foreach (var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var arg = toks[1];
                
                switch (cmdType)
                {
                    case "add":
                        Add(arg,bucketCount);
                        break;
                    case "del":
                        Delete(arg,bucketCount);
                        break;
                    case "find":
                        result.Add(Find(arg,bucketCount));
                        break;
                    case "check":
                        result.Add(Check(int.Parse(arg)));
                        break;
                }
            }

            return result.ToArray();
        }

        public const long BigPrimeNumber = 1000000007;
        public const long ChosenX = 263;

        public static long PolyHash(string str, int start, int count, long bucket,
            long p = BigPrimeNumber, long x = ChosenX)
        {
            long hash = 0;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                hash = (hash * x + str[i])%p;
            }
            long final = ((hash % p +p))%p % bucket;
            return final;
        }

        public void Add(string str, long bu)
        {
            long hash = PolyHash(str, 0, str.Length, bu);
            //if (PhoneBook.Contains(str))
            //    return;
            //PhoneBook.Add(str);

            // Phony[hash].AddFirst(str);
            if (Phony[hash] == null)
            {
               Phony[hash]= new LinkedList<string>();
            }
            if(!Phony[hash].Contains(str))
            Phony[hash].AddFirst(str);

            // arr[(int)hash] = str;



        }

        public string Find(string str,long b)
        {
            long hash = PolyHash(str, 0, str.Length, b);
            if (Phony[hash] == null)
            {
                Phony[hash] = new LinkedList<string>();
            }
            if (Phony[hash].Contains(str))
                return "yes";
            return "no";
        }

        public void Delete(string str,long b)
        {
            long hash = PolyHash(str, 0, str.Length, b);
            if (Phony[hash] == null)
            {
                Phony[hash] = new LinkedList<string>();
            }
            if (Phony[hash].Contains(str))
            {
                Phony[hash].Remove(str);
            }
            else
                return;
        }

        public string Check(int i)
        {
            if (Phony[i] == null || Phony[i].Count == 0)
                return "-";
            else
            {
                string words = String.Join(" ", Phony[i]);
                return words;
            }
        }

    }
}
