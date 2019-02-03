using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A12
{
    public class Connecting1
    {
        public Connecting1(long first, long end)
        {
            First = first;
            End = end;
        }

        public long First { get; }
        public long End { get; }
    }
    public class Q1MazeExit : Processor
    {
        public Q1MazeExit(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long, long, long>)Solve);

        public long Solve(long nodeCount, long[][] edges, long StartNode, long EndNode)
        {
            // Your code here
            //دیکشنری نمیشه چون گفتش که یه ایتم با کی یکسان داری.
            //Dictionary<long, long> c = new Dictionary<long, long>((int)nodeCount);
            //تاپل تووی سرچ کردن کدوم نود نمیشه از کانتین استفاده کرد چون لانگه
            //List<Tuple<long, long>> Connecting = new List<Tuple<long, long>>((int)nodeCount);
            //foreach (var edgenodes in edges)
            //{
            //    Connecting.Add(new Tuple<long, long>(edgenodes[0], edgenodes[1]));
            //}
            //if (Traversed.Item1 == EndNode && Traversed.Item2 == true)
            //    Connection = 1;
            //Connecting.ToList();

            //foreach(var i in Connecting)
            //{
            //    if (Connecting.Exists(x => x.Item1 == StartNode && x.Item2 == EndNode))
            //        Connection = 1;
            //
            //IsItConnected(Traversed,Connecting, StartNode);

            //if(Traversed.Item1 ==EndNode)
            //    Connection = 1;

            long Connection = 0;
            List<long>[] Graph = LoadGraph(nodeCount, edges);


            bool[] CheckedRelation = new bool[nodeCount+5];
            IsItConnected(Graph,CheckedRelation,StartNode);

            if (CheckedRelation[EndNode] == true)
            {
                Connection = 1;
            }

             return Connection;
        }

        public List<long>[] LoadGraph(long nodeCount, long[][] edges)
        {
            List<long>[] Connecting = new List<long>[nodeCount + 5];

            for (int i = 0; i < Connecting.Length; i++)
                Connecting[i] = new List<long>();

            foreach (var vetex in edges)
            {
                Connecting[vetex[0]].Add(vetex[1]);
                Connecting[vetex[1]].Add(vetex[0]);
            }

            return Connecting;
        }

        public void IsItConnected(List<long>[] graph, bool[] checkedRelation, long startNode)
        {
            checkedRelation[startNode] = true;
            foreach (var i in graph[startNode])
            {
                if (checkedRelation[i] == false)
                {
                    IsItConnected(graph, checkedRelation, i);
                }
                    
            }
           
        }

        

        //public void IsItConnected(List<Tuple<long, long>> Connecting, long start)
        //{
        //    List<Tuple<long, bool>> Traversed = new List<Tuple<long, bool>>();
        //    Traversed.Add(new Tuple<long, bool>(start, true));
        //    foreach (var i in Connecting)
        //}
    }
}

