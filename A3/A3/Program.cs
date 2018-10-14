using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Program
    {
        static void Main(string[] args)
        { }
        
        public static string Process(string inStr, Func<long, long> longProcessor)
        {
            long n = long.Parse(inStr);
            return longProcessor(n).ToString();
        }

        public static string Process(string inStr, Func<long, long, long> longProcessor)
        {
            var toks = inStr.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            long a = long.Parse(toks[0]);
            long b = long.Parse(toks[1]);
            return longProcessor(a, b).ToString();
        }

        public static string ProcessFibonacci(string inStr) => Process(inStr, Fibonacci);

        public static long Fibonacci(long n)
        {
            long FirstNumber = 0;
            long SecondNumber = 1;
            long ThirdNumber = 0;

            if (n < 2)
                return n;

            for (int i = 2; i <= n; i++)
            {

                ThirdNumber = (SecondNumber + FirstNumber);
                FirstNumber = SecondNumber;
                SecondNumber = ThirdNumber;
            }
            return ThirdNumber;
        }

        public static string ProcessFibonacci_LastDigit(string inStr) => Process(inStr, Fibonacci_LastDigit);
        public static long Fibonacci_LastDigit(long n)
        {
            long FirstNumber = 0;
            long SecondNumber = 1;
            long ThirdNumber = 0;

            for (int i = 2; i <= n; i++)
            {
                ThirdNumber = (SecondNumber + FirstNumber) % 10;
                FirstNumber = SecondNumber % 10;
                SecondNumber = ThirdNumber % 10;
            }
            return ThirdNumber;
        }

        public static string ProcessGCD(string inStr) => Process(inStr, GCD);
        public static long GCD(long a, long b)
        {
            if (a == 1 || b == 1)
                return 1;
            if (a % b == 0)
                return b;
            if (b % a == 0)
                return a;
            if (a > b)
                return GCD(b, a% b);
            else
                return GCD(a, b % a);
        }

        public static string ProcessLCM(string inStr) => Process(inStr, LCM);
        public static long LCM(long a, long b)
        {
            long Product = 0;
            Product = a * b;
            return Product / GCD(a, b);
        }

          public static string ProcessFibonacci_Mod(string inStr) => Process(inStr,Fibonacci_Mod);
          public static long Fibonacci_Mod(long n,long m)
          {
            List<long> F = new List<long> { 0, 1 };
            while (true)
            {
                F.Add((F[F.Count - 1] + F[F.Count - 2]) % m);
                if (F[F.Count - 1] == 1 && F[F.Count - 2] == 0)
                    break;
            }
            long Remainder = n % (F.Count - 2);
            return F[(int)Remainder];
        }

        public static string ProcessFibonacci_Sum(string inStr) => Process(inStr, Fibonacci_Sum);
        public static long Fibonacci_Sum(long n)
        {
            long One = 0;
            long Two = 1;
            long Three = 0;
            long Sum = 1;
            long[] Pisano = new long[61];
            Pisano[0] = 0; Pisano[1] = 1;
            for (int i = 2; i <= 60; i++)
            {
                Three = One + Two;
                One = Two;
                Two = Three;
                Sum += Three;
                Pisano[i] += Sum % 10;
            }
            long rest = n % 60;
            return Pisano[(int)rest];
        }

        public static string ProcessFibonacci_Partial_Sum(string inStr) => Process(inStr, Fibonacci_Partial_Sum);
        public static long Fibonacci_Partial_Sum(long n, long m)
        {
            if (n > m)
                return ((Fibonacci_Sum(n) + 10) - Fibonacci_Sum(m - 1)) % 10;
            else return
                    (Fibonacci_Sum(m) + 10 - Fibonacci_Sum(n - 1)) % 10;
        }


        public static string ProcessFibonacci_Sum_Squares(string inStr) => Process(inStr, Fibonacci_Sum_Squares);
        public static long Fibonacci_Sum_Squares(long n)
        {
            return(Fibonacci_Mod(n,10)*(Fibonacci_Mod(n,10)+Fibonacci_Mod(n-1,10)))% 10;

        }
    }
}
