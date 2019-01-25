using System;
using System.Collections;
using System.Collections.Generic;
using TestCommon;

namespace A12
{
    public class Q2AddExitToMaze : Processor
    {
        public Q2AddExitToMaze(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long>)Solve);

        public long Solve(long nodeCount, long[][] edges)
        {
            // Your code here
            // ArrayList[] Graph = new ArrayList[nodeCount+1];
           
            List<long>[] Graph = LoadGraph(nodeCount,edges);
            return ConnectedNumber(Graph,nodeCount);

        }

        public static long ConnectedNumber(List<long>[] graph,long nodeCount)
        {
            int result = 0;
            //write your code here
            bool[] Connected = new bool[nodeCount + 1];
            for (int i = 1; i <= nodeCount; i++)
            {
                if (Connected[i] == false)
                {
                    FindConnection(i,Connected,graph);
                    result++;
                }
            }
            return result;
        }

        private static void FindConnection(long n,bool[] connected,List<long>[] graph)
        {
            //connected[x] = true;
            //foreach (var i in graph[x])
            //{
            //    if (connected[i] == false)
            //    FindConnection(graph, i, connected);
            //}
            Stack<long> s = new Stack<long>();
            s.Push(n);
            while (s.Count != 0)
            {
                var pop = s.Pop();
                if (connected[pop] == false)
                {
                    connected[pop] = true;
                }

                foreach (var vertex in graph[pop])
                {
                    if (connected[vertex] == false)
                    {
                        s.Push(vertex);
                    }    
                }
             }
        }
        public List<long>[] LoadGraph(long nodeCount, long[][] edges)
        {
            // for (int i = 0; i < nodeCount; i++)
            // {
            //     Graph[i] = new ArrayList();
            // }
            //foreach(var vertex in edges )
            // {
            //     Graph[vertex[0]].Add(vertex[1]);
            //     Graph[vertex[1]].Add(vertex[0]);
            // }
            List<long>[] Connecting = new List<long>[nodeCount + 1];

            for (int i = 0; i < Connecting.Length; i++)
                Connecting[i] = new List<long>();

            foreach (var vetex in edges)
            {
                Connecting[vetex[0]].Add(vetex[1]);
                Connecting[vetex[1]].Add(vetex[0]);
            }

            return Connecting;
        }
    }
}

