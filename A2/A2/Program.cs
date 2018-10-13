using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2
{
    public class Program
    {
        static void Main(string[] args)
        {
            FastMaxPairWiseProduct(new List<int> { 1,2,6});
        }
        
        public static string Process(string Input)
        {
            var inData = Input.Split(new char[] { '\n', '\r', ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(s => int.Parse(s))
                .ToList();

           // return NaiveMaxPairWiseProduct(inData).ToString();
           return FastMaxPairWiseProduct(inData).ToString();

        }

        public static int NaiveMaxPairWiseProduct(List<int> numbers)
        {
            int Product = 0;
            int n = numbers.Count();
            for (int i = 0; i < n; i++)
            {
                for (int j = i+1; j < n; j++)
                {
                    Product = Math.Max(Product, numbers[i] * numbers[j]);
                }
            }
            return Product;
        }
        
        public static int FastMaxPairWiseProduct(List<int> Numbers)
        {
            int n = Numbers.Count();
            int i = 0;
            int index1 = 0;
          
            for (; i < n; i++)
            {
                if (Numbers[i] >= Numbers[index1])
                    index1=i ;
            }
            i = 0;
            int index2 = 1;
            for (; i < n; i++)
            {
                if (i != index1 && Numbers[i] >= Numbers[index2])
                    index2=i;
            }
            return Numbers[index1] * Numbers[index2];
        }

    }
}

