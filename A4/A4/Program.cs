using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A4
{//clean code crtl+k+f
    public class Program
    {
        static void Main(string[] args)
        {

            CollectingSingnatures4(4, new long[] { 4, 1, 2, 5 }, new long[] { 7, 3, 5, 6 });
        }

        public static string ProcessChangingMoney1(string inStr) => TestTools.Process(inStr, (Func<long, long>)ChangingMoney1);
        public static long ChangingMoney1(long money)
        {
            long CountTen = 0;
            long CountFive = 0;
            long CountOne = 0;
            CountTen = money / 10;
            CountFive = money % 10 / 5;
            CountOne = money % 10 % 5;
            return CountTen + CountFive + CountOne;
        }


        public static string ProcessMaximizingLoot2(string inStr) => TestTools.Process(inStr, (Func<long, long[], long[], long>)MaximizingLoot2);
        public static long MaximizingLoot2(long capacity, long[] weights, long[] values)
        {
            int MaxIndex = 0;
            Double FinalValue = 0;
            List<double> Ratio = new List<double>(weights.Length);
            for (int i = 0; i < weights.Length; i++)
            {
                Ratio.Add((double)values[i] / (double)weights[i]);
            }

            for (int j = 0; j < weights.Length; j++)
            {
                MaxIndex = Ratio.IndexOf(Ratio.Max());

                if (weights[MaxIndex] > capacity)
                {
                    weights[MaxIndex] = capacity;
                    FinalValue += (int)(capacity * Ratio[MaxIndex]);
                    Ratio[MaxIndex] = 0;
                    return (long)FinalValue;
                }

                if (capacity >= weights[MaxIndex])
                {
                    capacity -= weights[MaxIndex];
                    FinalValue += values[MaxIndex];
                    Ratio[MaxIndex] = 0;
                    if (capacity == 0)
                        break;
                }
            }
            return (long)FinalValue;
        }


        public static string ProcessMaximizingOnlineAdRevenue3(string inStr) => TestTools.Process(inStr, (Func<long, long[], long[], long>)MaximizingOnlineAdRevenue3);
        public static long MaximizingOnlineAdRevenue3(long slotCount, long[] AdRevenue, long[] averageDailyClick)
        {
            List<long> AdsRevenue = new List<long>();
            List<long> AverageDailyClicks = new List<long>();
            List<long> Multiply = new List<long>();
            long MaxIndexAdsRevenue = 0;
            long MaxIndexAverageDailyClicks = 0;
            long Efficient = 0;
            for (int i = 0; i < slotCount; i++)
            {
                AdsRevenue.Add(AdRevenue[i]);
                AverageDailyClicks.Add(averageDailyClick[i]);
            }
            for (int j = 0; j < slotCount; j++)
            {
                MaxIndexAdsRevenue = AdsRevenue.IndexOf(AdsRevenue.Max());
                MaxIndexAverageDailyClicks = AverageDailyClicks.IndexOf(AverageDailyClicks.Max());
                Multiply.Add(AdsRevenue[(int)MaxIndexAdsRevenue] * AverageDailyClicks[(int)MaxIndexAverageDailyClicks]);
                Efficient += AdsRevenue[(int)MaxIndexAdsRevenue] * AverageDailyClicks[(int)MaxIndexAverageDailyClicks];
                AdsRevenue[(int)MaxIndexAdsRevenue] = long.MinValue;
                AverageDailyClicks[(int)MaxIndexAverageDailyClicks] = long.MinValue;

            }
            return (long)Efficient;
        }


        public static string ProcessCollectingSingnatures4(string inStr) => TestTools.Process(inStr, (Func<long, long[], long[], long>)CollectingSingnatures4);
        public static long CollectingSingnatures4(long tenantCount, long[] startTimes, long[] endTimes)
        {
            Array.Sort(endTimes, startTimes);
            List<long> StartPoint = new List<long>(startTimes);
            List<long> EndPoint = new List<long>(endTimes);
            List<long> CopyEndPoint = new List<long>(endTimes);
            List<long> CopyStartPoint = new List<long>(startTimes);
            long point = 0;
            while (EndPoint.Count > 0)
            {
                for (int j = 1; j < EndPoint.Count(); j++)
                {
                    if (StartPoint[j] <= EndPoint[0] && EndPoint[0] <= EndPoint[j])
                    {
                        CopyEndPoint.Remove(EndPoint[j]);
                        CopyStartPoint.Remove(StartPoint[j]);
                    }
                }
                CopyEndPoint.Remove(EndPoint[0]);
                EndPoint = new List<long>(CopyEndPoint);
                CopyStartPoint.Remove(StartPoint[0]);
                StartPoint = new List<long>(CopyStartPoint);
                point++;
            }

            return point;
        }

        public static string ProcessMaximizeSalary6(string inStr) => TestTools.Process(inStr, MaximizeSalary6);
        public static string MaximizeSalary6(long n, long[] numbers)
        {
            List<long> ListNumbers = new List<long>(numbers);
            List<string> listString = new List<string>();
            string Result = "";
            while (ListNumbers.Count != 0)
            {
                int index = 0;
                for (int i = 1; i < ListNumbers.Count; i++)
                {
                    string a = ListNumbers[index].ToString();
                    string b = ListNumbers[i].ToString();
                    if (long.Parse(a + b) < long.Parse(b + a))
                    {
                        index = i;
                    }
                    else
                        continue;
                }
                Result += ListNumbers[index];
                ListNumbers.RemoveAt(index);
            }
            return Result;
        }

        public static string ProcessMaximizeNumberOfPricePlaces5(string inStr) => TestTools.Process(inStr, (Func<long, long[]>)MaximizeNumberOfPricePlaces5);
        public static long[] MaximizeNumberOfPricePlaces5(long n)
        {
            List<long> SumList = new List<long>();
            long Sum = 0;
            for (long i = 1; i <= n + 1; i++)
            {
                Sum += i;
                if (Sum <= n)
                    SumList.Add(i);
                else
                {
                    SumList[SumList.Count - 1] += (n + i) - Sum;
                    break;
                }
            }
            return SumList.ToArray();
        }
    }
}