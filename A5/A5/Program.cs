using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A5
{
    public class Program
    {
        static void Main(string[] args)
        {
            ClosestPoints6(100, new long[]
                { -36,
575,
-346,
828,
862,
983 ,
308,
-25,
118,
-114,
985,
888,
313,
-358,
523,
217,
-987,
504,
270,
168,
-884,
8,
-668,
84,
404,
488,
3,
-911 ,
753 ,
496 ,
839 ,
772 ,
-675,
309 ,
-731 ,
440 ,
-699 ,
154 ,
-652 ,
-194 ,
854 ,
224 ,
705 ,
963 ,
-381 ,
-456 ,
-381 ,
-208 ,
624 ,
653 ,
616 ,
-466 ,
-550 ,
259 ,
240 ,
258 ,
628 ,
861 ,
975 ,
-38 ,
53 ,
980,
-868 ,
-617 ,
462 ,
-38 ,
-744 ,
-228,
304 ,
183 ,
-604 ,
-622,
-362,
206 ,
591 ,
-59 ,
377 ,
-739,
-497 ,
-405 ,
-898 ,
286 ,
-461 ,
586 ,
-665 ,
-305,
-45,
-728,
312,
734,
398,
257,
296,
-370,
229,
-135,
901,
116,
927,
-423}, new long[] { 642
, -190
, -518
, 296
, 542
, 322
, 774
, -290
, 469
, 270
,357
, 139
, -61
, -371
, 194
, -34
, -292
, -702
, -884
, -369
, 397
, 978
, -75
, -197
, 890
, 560
, -605
, 607
, -565
, 715
, 199
, -332
, 17
, -400
, -323
, 2
, -746
, -413
, 909
, -612
, 838
, 633
, 656
, 618
, 897
, -166
, 452
, -84
, -660
, 315
, -516
, -273
, -514
, -252
, 502
, 843
, 108
, -1000
, -861
, -332
, 690
, -628
, -395
, -152
, -763
, -992
, 491
, 369
, -504
, 219
, 214
, 117
, -299
, 510
, -209
, 485
, -16
, 925
,-839
, 844
, -589
, 2
, 250
, -863
, -509
, 478
, 743
, 839
, -137
, 431
, -128
, -330
, 476
, 271
, -154
, 142
, 338
, 985
,375
,387 });
        }
        public static long[] BinarySearch1(long[] a, long[] b)
        {
            List<long> Answer = new List<long>();
            foreach (var index in b)
            {
                long low = 0;
                long high = a.Length;

                while (true)
                {
                    long mid = low + ((high - low) / 2);
                    if (high < low || mid >= a.Length)
                    {
                        Answer.Add(-1);
                        break;
                    }
                    if (index == a[mid])
                    {
                        Answer.Add(mid);
                        break;
                    }
                    else if (index < a[mid])
                        high = mid - 1;
                    else
                        low = mid + 1;
                }
            }
            return Answer.ToArray();
        }

        public static string ProcessBinarySearch1(string inStr) =>
            TestTools.Process(inStr, BinarySearch1);

        public static long MajorityElement2(long n, long[] a)
        {
            //Using MergeSort Search 
            MergeSort(a, 0, a.Length - 1);
            long MajorityElement = n / 2;

            long Counter = 0;
            int j = 0;

            for (int i = 0; i < n; i++)
            {
                if (a[i] == a[MajorityElement])
                {
                    Counter++;
                }
                if (Counter > MajorityElement)
                {
                    j = 1;
                }
                else
                    j = 0;
            }

            return j;
        }

        public static string ProcessMajorityElement2(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)MajorityElement2);

        public static long[] ImprovingQuickSort3(long n, long[] a)
        {
            QuickSort(a, 0, n - 1);
            return a;
        }

        private static void QuickSort(long[] a, long low, long high)
        {
            if (high <= low)
                return;

            long i = 0, j = 0;

            PartionWith3Comparison(a, low, high, ref i, ref j);

            QuickSort(a, low, i - 1);
            QuickSort(a, j + 1, high);
        }

        private static void PartionWith3Comparison(long[] a, long low, long high, ref long middle, ref long middle1)
        {
            middle = low;
            long index = low;
            middle1 = high;
            long pivote = a[low];

            while (index <= middle1)
            {
                if (a[index] < pivote)
                {
                    Swap(ref a[middle], ref a[index]);
                    middle++;
                    index++;
                }

                else if (a[index] > pivote)
                {
                    Swap(ref a[middle1], ref a[index]);
                    middle1--;
                }

                else
                    index++;
            }
        }

        private static void Swap<T>(ref T n, ref T m)
        {
            T temp = n;
            n = m;
            m = temp;
        }

        public static string ProcessImprovingQuickSort3(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)ImprovingQuickSort3);

        public static long NumberofInversions4(long n, long[] a)
        {
            long[] copy = new long[n];
            return IntoHalf(a, copy, 0, a.Length - 1);
        }

        public static string ProcessNumberofInversions4(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)NumberofInversions4);

        public static long[] OrganizingLottery5(long[] points, long[] startSegments,
            long[] endSegment)
        {
            //write your code here
            return new long[] { 0 };
        }

        public static string ProcessOrganizingLottery5(string inStr) =>
            TestTools.Process(inStr, OrganizingLottery5);

        public static double ClosestPoints6(long n, long[] xPoints, long[] yPoints)
        {
            List<long> XCopy = new List<long>(xPoints);
            List<long> X = new List<long>((int)n);
            List<long> Y = new List<long>((int)n);
            //   return MDHalf(xPoints, Xcopy, yPoints, Ycopy, 0, n - 1);
            for (int i = 0; i < n; i++)
            {
                int index = XCopy.IndexOf(XCopy.Min());
                X.Add(XCopy[index]);
                Y.Add(yPoints[index]);
                XCopy[index] = long.MaxValue;
            }
            double Mindis = double.MaxValue;
            for (int i = 0; i < X.Count - 1; i++)
            {
                double a = (X[i + 1] - X[i])* (X[i + 1] - X[i]);
                double b =(Y[i + 1] - Y[i])* (Y[i + 1] - Y[i]);
                double ab = Math.Sqrt(a+b);
                if (ab < Mindis)
                    Mindis = ab;
            }
            return Math.Round(Mindis, 4);
            
        }

        public static string ProcessClosestPoints6(string inStr) =>
           TestTools.Process(inStr, (Func<long, long[], long[], double>)
               ClosestPoints6);

        public static void MergeSort(long[] input, int low, int high)
        {
            if (low < high)
            {
                int mid = (high + low) / 2;
                MergeSort(input, low, mid);
                MergeSort(input, mid + 1, high);
                Merge(input, low, mid, high);
            }
        }

        private static void Merge(long[] input, int low, int mid, int high)
        {
            int i, j, k;
            int leftSize = mid - low + 1;
            int RightSize = high - mid;

            long[] Right = new long[RightSize];
            long[] Left = new long[leftSize];

            for (i = 0; i < leftSize; ++i)
            {
                Left[i] = input[low + i];
            }

            for (j = 0; j < RightSize; ++j)
            {
                Right[j] = input[(mid + 1) + j];
            }

            i = 0;
            j = 0;
            k = low;
            while (i < leftSize && j < RightSize)
            {
                if (Left[i] < Right[j])
                {
                    input[k] = Left[i];
                    i++;
                }
                else
                {
                    input[k] = Right[j];
                    j++;
                }
                k++;
            }

            while (i < leftSize)
            {
                input[k] = Left[i];
                i++;
                k++;
            }
            while (j < RightSize)
            {
                input[k] = Right[j];
                j++;
                k++;
            }
        }

        public static long IntoHalf(long[] a, long[] Copy, long left, long right)
        {
            long inversionCount = 0;
            if (left < right)
            {
                long mid = (right + left) / 2;
                inversionCount = IntoHalf(a, Copy, left, mid);
                inversionCount += IntoHalf(a, Copy, mid + 1, right);
                inversionCount += Invmerge(a, Copy, left, mid + 1, right);
            }
            return inversionCount;
        }
        private static long Invmerge(long[] a, long[] copy, long left, long mid, long right)
        {
            long inveresionCount = 0;
            long i = left;
            long j = mid;
            long k = left;
            while ((i <= mid - 1) && (j <= right))
            {
                if (a[i] <= a[j])
                {
                    copy[k++] = a[i++];
                }
                else
                {
                    copy[k++] = a[j++];

                    inveresionCount = inveresionCount + (mid - i);
                }
            }
            while (i <= mid - 1)
            {
                copy[k++] = a[i++];
            }
            while (j <= right)
            {
                copy[k++] = a[j++];
            }
            for (i = left; i <= right; i++)
            {
                a[i] = copy[i];
            }
            return inveresionCount;
        }

        public static double MDHalf(long[] x, long[] XCopy, long[] y, long[] YCopy, long low, long high)
        {
            double mindis = 0;

            while (low < high)
            {
                long mid = (high + low) / 2;
                MDHalf(x, XCopy, y, YCopy, low, mid);
                MDHalf(x, XCopy, y, YCopy, mid + 1, high);
                MDWhileHalf(x, XCopy, y, YCopy, low, mid, high);
            }
            return mindis;
        }

        private static double MDWhileHalf(long[] x, long[] XCopy, long[] y, long[] YCopy, long low, long mid, long high)
        {
            List<double> Distances = new List<double>();
            long DistanceX = 0;
            long DistanceY = 0;
            long DistanceF = 0;
            long i = low;
            long j = mid;
            long k = low;
            while ((i <= mid) && (j <= high))
            {
                if (x[i] <= x[j])
                {
                    XCopy[k++] = x[i];
                    DistanceX = (i - j) * (i - j);
                }
                else
                {
                    XCopy[k++] = x[j];

                }
                if (y[i] <= y[j])
                {
                    YCopy[k++] = y[i];
                    DistanceY = (i - j) * (i - j);
                    DistanceF = DistanceX + DistanceY;
                }
                else
                {
                    YCopy[k++] = x[j];

                }
                Distances.Add(Math.Sqrt(DistanceF));
            }

            while (i <= mid - 1)
            {
                XCopy[k++] = x[i++];
                YCopy[k++] = y[i++];
            }
            while (j <= high)
            {
                XCopy[k++] = x[j++];
                YCopy[k++] = y[j++];
            }
            for (i = low; i < high; i++)
            {
                x[i] = XCopy[i];
                y[i] = YCopy[i];
            }
            double mindis = Distances.Min();
            return mindis;
        }
    }
}
