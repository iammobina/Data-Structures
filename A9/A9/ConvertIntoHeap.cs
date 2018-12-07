using TestCommon;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace A9
{
    public class ConvertIntoHeap : Processor
    {
        public ConvertIntoHeap(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], Tuple<long, long>[]>)Solve);

        public Tuple<long, long>[] Solve(long[] array)
        {
            List<Tuple<long, long>> Movement = new List<Tuple<long, long>>();
            int n = array.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
            {
                CheckedHeapCondition(array, n, i,Movement);
            }
            return Movement.ToArray();
        }
        

        public void CheckedHeapCondition(long[] array, long n, long i, List<Tuple<long, long>> Movement)
        {
            long largest = i;
            long LeftChild = 2 * i + 1;
            long RightChild = 2 * i + 2;

            if (LeftChild < n && array[LeftChild] < array[largest])
                largest = LeftChild;

            if (RightChild < n && array[RightChild] < array[largest])
                largest = RightChild;

            if (largest != i)
            {
                Swap(array, i, largest,Movement);
                CheckedHeapCondition(array, n, largest,Movement);
            }
        }
        public void Swap(long[] arr, long x, long y, List<Tuple<long, long>> Movement)
        {
            long temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;
            Movement.Add(new Tuple<long, long>(x, y));
           
        }
    }
}